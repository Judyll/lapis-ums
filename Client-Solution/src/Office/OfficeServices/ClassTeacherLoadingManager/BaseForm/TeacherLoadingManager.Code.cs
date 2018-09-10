using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace OfficeServices
{
    partial class TeacherLoadingManager : IDisposable
    {
        #region Class General Variable Declaration
        private CommonExchange.SysAccess _userInfo;
        private TeacherLoadingLogic _teacherLoadingManager;

        private Boolean _canUserDeload = false;
        private Boolean _isRecordLocked = false;
        private Boolean _hasEnterAskConfirmation = false;
        private Boolean _askConfirmation = true;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
        private String _sysIdScheduleServiceDetails = String.Empty;
        private String _scheduleServiceDetailsCodeTitle = String.Empty;

        private Int32 _oldIndexYear = -1;
        private Int32 _oldIndexSemester = -1;
        #endregion

        #region Class Constructor and distructor
        public TeacherLoadingManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.txtEmployeeSearch.KeyPress += new KeyPressEventHandler(txtEmployeeSearchKeyPress);
            this.txtScheduleSearch.KeyPress += new KeyPressEventHandler(txtScheduleSearchKeyPress);
            this.trvEmployee.KeyUp += new KeyEventHandler(trvEmployeeKeyUp);
            this.trvEmployee.NodeMouseClick += new TreeNodeMouseClickEventHandler(trvEmployeeNodeMouseClick);
            this.btnLoadScheduleDetails.Click += new EventHandler(btnLoadScheduleDetailsClick);
            this.btnRecord.Click += new EventHandler(btnRecordClick);
            this.btnPrintTeacherLoad.Click += new EventHandler(btnPrintTeacherLoadClick);
            this.btnPrintAll.Click += new EventHandler(btnPrintAllClick);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnLegend.Click += new EventHandler(btnLegendClick);
            this.lsvSubjectServiceLoad.MouseDown += new MouseEventHandler(lsvSubjectServiceLoadMouseDown);
            this.lnkDeloadScheduleServiceDetails.Click += new EventHandler(lnkDeloadScheduleServiceDetailsClick);
            this.lnkPrintStudentEnrolled.Click += new EventHandler(lnkPrintStudentEnrolledClick);
        }

        void IDisposable.Dispose()
        {
            if (this.pbxIntructor.Image != null)
            {
                pbxIntructor.Image.Dispose();
                pbxIntructor.Image = null;

                this.pbxIntructor.Dispose();
                this.pbxIntructor = null;
            }

            GC.SuppressFinalize(this);
            GC.Collect();
        }
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS TeacherLoading EVENTS#######################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _teacherLoadingManager = new TeacherLoadingLogic(_userInfo);

            try
            {
                if (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo))
                {
                    _canUserDeload = true;
                }
                else if (!(RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessSecretaryOftheVpOfAcademicAffairs(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }              
                
                if (RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo))
                {
                    this.btnRecord.Visible = this.btnLoadScheduleDetails.Visible = this.toolStripSeparator.Visible = false;
                }

                if (RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo))
                {
                    this.btnLoadScheduleDetails.Enabled = this.lnkPrintStudentEnrolled.Visible = this.txtScheduleSearch.Enabled = false;
                }

                this.btnRecord.Enabled = false;

                _teacherLoadingManager.InitializeSchoolYearCombo(this.cboYear);               

                if (!(CommonExchange.EnrolmentComponent.IncludeCollege || CommonExchange.EnrolmentComponent.IncludeGradeSchoolKinder))
                {
                    this.cboSemester.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
        }//------------------------------

        //event is raised when the class is clossing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (this.btnRecord.Enabled)
            {
                String strMsg = "There has been changes made in the current schedule information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _teacherLoadingManager.DeleteImageDirectory(Application.StartupPath);
                }
            }
        }//-------------------------------
        //############################################END CLASS TeacherLoading EVENTS#######################################################

        //################################################COMBOBOX choYear EVENTS####################################################
        //event is raised when the control selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.AskConfirmationForTeacherLoading("school year", true, false))
            {
                if (this.cboYear.SelectedIndex != -1)
                {
                    _teacherLoadingManager.InitializeSemesterCombo(this.cboSemester, this.cboYear.SelectedIndex);

                    _dateStart =
                           _teacherLoadingManager.GetSchoolYearDateStart(_teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString()
                            + " 12:00:00 AM";
                    _dateEnd =
                        _teacherLoadingManager.GetSchoolYearDateEnd(_teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString()
                         + " 11:59:59 PM";

                    _teacherLoadingManager.SelectByDateStartEndForTeacherLoadingTeacherLoad(_userInfo, _dateStart, _dateEnd);

                    this.InitializeEmployeeInformationTreeView();
                }

                this.ResetControls();

                this.SetRecordStatus();

                _oldIndexYear = this.cboYear.SelectedIndex;

                //to reset ask confirmation flag
                _hasEnterAskConfirmation = false;
            }

            this.Cursor = Cursors.Arrow;
        }//--------------------------------
        //################################################END COMBOBOX choYear EVENTS####################################################

        //################################################COMBOBOX choSemester EVENTS####################################################
        //event is raised when cboSemester selected index changed
        private void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.AskConfirmationForTeacherLoading("semester", false, true))
            {
                _dateStart = _teacherLoadingManager.GetSemesterDateStart(_teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                       this.cboSemester.SelectedIndex)).ToShortDateString() + " 12:00:00 AM";
                _dateEnd = _teacherLoadingManager.GetSemesterDateEnd(_teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                    this.cboSemester.SelectedIndex)).ToShortDateString() + " 11:59:59 PM";

                _teacherLoadingManager.SelectByDateStartEndForTeacherLoadingTeacherLoad(_userInfo, _dateStart, _dateEnd);

                this.InitializeEmployeeInformationTreeView();

                this.ResetControls();

                this.SetRecordStatus();

                _oldIndexSemester = this.cboSemester.SelectedIndex;

                //to reset ask confirmation flag
                _hasEnterAskConfirmation = false;
            }

            this.Cursor = Cursors.Arrow;
        }//-----------------------------
        //################################################END COMBOBOX choSemester EVENTS####################################################

        //################################################TEXTBOX txtEmployeeSearch EVENTS####################################################
        //event is raised when txtEmployeeSearch Key Press
        private void txtEmployeeSearchKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.InitializeEmployeeInformationTreeView();

                this.ResetControls();
            }
        }//----------------------------
        //################################################END TEXTBOX txtEmployeeSearch EVENTS####################################################

        //################################################TEXTBOX txtScheduleSearch EVENTS####################################################
        //event is raised when txtScheduleSearch Key Press
        private void txtScheduleSearchKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Cursor = Cursors.WaitCursor;

                using (ScheduleSearchOnTextBoxList frmSearch = new ScheduleSearchOnTextBoxList(_userInfo, _teacherLoadingManager,
                    this.txtScheduleSearch.Text, _dateStart, _dateEnd))
                {
                    frmSearch.AdoptGridSize = false;
                    frmSearch.ShowDialog(this);
                }

                this.Cursor = Cursors.Arrow;
            }
        } //--------------------------
        //################################################END TEXTBOX txtScheduleSearch EVENTS####################################################

        //################################################TREEVIEW trvEmployee EVENTS####################################################
        //event is raised when trvEmployee Node Mouse Clicked
        private void trvEmployeeNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.trvEmployee.SelectedNode = e.Node;

            this.InitializeInsturctorInfomation();
        }//----------------------------

        //event is raised when the key is up
        private void trvEmployeeKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                this.InitializeInsturctorInfomation();
            }
        }//----------------------------
        //################################################END TREEVIEW trvEmployee EVENTS####################################################

        //################################################BUTTON btnLoadScheduleDetails EVENTS####################################################
        //event is raised when the control is clicked
        private void btnLoadScheduleDetailsClick(object sender, EventArgs e)
        {
            this.AddSubjectLoad(false);

            this.InitializeInsturctorInfomation();
        }//----------------------------
        //################################################END BUTTON btnLoadScheduleDetails EVENTS####################################################

        //################################################BUTTON btnRecord EVENTS####################################################
        //event is raised when btnRecord is Clicked
        private void btnRecordClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                String strMsg = "Are you sure you want to record the new teacher load?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The teacher load has been successfully recorded.";                   

                    _teacherLoadingManager.InsertDeleteTeacherLoad(_userInfo);                                       

                    _teacherLoadingManager.SelectByDateStartEndForTeacherLoadingTeacherLoad(_userInfo,
                        _teacherLoadingManager.GetSchoolYearDateStart(
                        _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString() + " 12:00:00 AM",
                        _teacherLoadingManager.GetSchoolYearDateEnd(
                        _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString() + " 11:59:59 PM");

                    if (!String.IsNullOrEmpty(_teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text)))
                    {
                        if (this.cboSemester.SelectedIndex >= 0)
                        {
                            _teacherLoadingManager.InitializeSubjectServiceLoadListView(this.lsvSubjectServiceLoad, this.lstDeloadedSchedule,
                                this.tblLoadedSchedule, this.tblDeloadedSchedule, 
                                _teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text),
                                _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex),
                                _teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex));
                        }
                        else
                        {
                            _teacherLoadingManager.InitializeSubjectServiceLoadListView(this.lsvSubjectServiceLoad, this.lstDeloadedSchedule,
                                this.tblLoadedSchedule, this.tblDeloadedSchedule, 
                                _teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text),
                                _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), String.Empty);
                        }
                    }

                    this.btnRecord.Enabled = false;

                    this.btnPrintAll.Enabled = this.btnPrintTeacherLoad.Enabled = true;

                    MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Recording");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//-----------------------
        //################################################END BUTTON btnRecord EVENTS####################################################

        //################################################BUTTON btnPrintTeacherLoad EVENTS####################################################
        //event is raised when lblPrintTeacherLoad is Clicked
        private void btnPrintTeacherLoadClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String strSemester = cboSemester.SelectedIndex >= 0 ? cboSemester.Text : "";

                if (this.cboSemester.SelectedIndex >= 0)
                {
                    _teacherLoadingManager.PrintTeacherLoad(_userInfo, this.cboYear.Text + " - " + strSemester,
                        _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex),
                        _teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                        this.trvEmployee.SelectedNode.Text, false);
                }
                else
                {
                    _teacherLoadingManager.PrintTeacherLoad(_userInfo, this.cboYear.Text + " - " + strSemester,
                        _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), "",
                        this.trvEmployee.SelectedNode.Text, false);
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error loading print teacher load module.\n\n" + ex.Message, "Error Printing");
            }
        }//---------------------
        //################################################END BUTTON btnPrintTeacherLoad EVENTS####################################################

        //################################################BUTTON btnPrintAll EVENTS####################################################
        //event is raised when btnPrintAll is Clicked
        void btnPrintAllClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String strSemester = cboSemester.SelectedIndex >= 0 ? cboSemester.Text : String.Empty;

                if (this.cboSemester.SelectedIndex >= 0)
                {
                    _teacherLoadingManager.PrintTeacherLoad(_userInfo, this.cboYear.Text + " - " + strSemester,
                        _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex),
                        _teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                        this.txtEmployeeSearch.Text, true);
                }
                else
                {
                    _teacherLoadingManager.PrintTeacherLoad(_userInfo, this.cboYear.Text + " - " + strSemester,
                        _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), String.Empty, this.txtEmployeeSearch.Text, true);
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error loading print teacher load module.\n\n" + ex.Message, "Error Printing");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//--------------------------------
        //################################################END BUTTON btnPrintAll EVENTS####################################################

        //################################################BUTTON btnClose EVENTS####################################################
        //event is raised when btnPrintAll is Clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------------
        //################################################END BUTTON btnClose EVENTS####################################################

        //################################################BUTTON btnLegend EVENTS####################################################
        //event is raised when btnPrintAll is Clicked
        private void btnLegendClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (BaseServices.SubjectLegend frmLegend = new BaseServices.SubjectLegend())
                {
                    frmLegend.ShowDialog(this);
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Subject Schedule Type Module.\n\n" + ex.Message, "Error Loading");
            }
        }//-------------------------
        //################################################END BUTTON btnLegend EVENTS####################################################

        //################################################LISTVIEW lstSubjectServiceLoad EVENTS####################################################
        //event is raised when btnRecord is Clicked
        private void lsvSubjectServiceLoadMouseDown(object sender, MouseEventArgs e)
        {
            if (_canUserDeload)
            {
                if ((e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) &&
                (this.lsvSubjectServiceLoad.Items.Count > 0 && this.lsvSubjectServiceLoad.FocusedItem != null))
                {
                    if (this.lsvSubjectServiceLoad.SelectedItems.Count > 0)
                    {
                        if (this.lsvSubjectServiceLoad.GetItemAt(e.X, e.Y) != null && e.Button == MouseButtons.Right)
                        {
                            String strMsg = "Deload subject schedule / service details - [" + this.lsvSubjectServiceLoad.GetItemAt(e.X, e.Y).SubItems[1].Text + "].";

                            _scheduleServiceDetailsCodeTitle = this.lsvSubjectServiceLoad.GetItemAt(e.X, e.Y).SubItems[1].Text;

                            _sysIdScheduleServiceDetails = this.lsvSubjectServiceLoad.GetItemAt(e.X, e.Y).Text;

                            this.cmsDeloadPrintStudentEnrolledList.Items[0].Text = strMsg;
                            this.cmsDeloadPrintStudentEnrolledList.Show(this.lsvSubjectServiceLoad, new Point(e.X, e.Y));
                            this.lnkDeloadScheduleServiceDetails.Visible = true;
                        }
                    }                    
                }
            }

            if ((e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) &&
               (this.lsvSubjectServiceLoad.Items.Count > 0 && this.lsvSubjectServiceLoad.FocusedItem != null))
            {
                if (this.lsvSubjectServiceLoad.SelectedItems.Count > 0)
                {
                    if (this.lsvSubjectServiceLoad.GetItemAt(e.X, e.Y) != null && e.Button == MouseButtons.Right)
                    {
                        _sysIdScheduleServiceDetails = this.lsvSubjectServiceLoad.GetItemAt(e.X, e.Y).Text;

                        this.cmsDeloadPrintStudentEnrolledList.Show(this.lsvSubjectServiceLoad, new Point(e.X, e.Y));
                    }
                }
            }
        }//---------------------
        //################################################END LISTVIEW lstSubjectServiceLoad EVENTS####################################################

        //################################################LABEL lblDeloadScheduleServiceDetails EVENTS####################################################
        //event is raised when the control is clicked
        private void lnkDeloadScheduleServiceDetailsClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_sysIdScheduleServiceDetails))
            {
                String strMsg = "Are you sure you want to deload [" + _scheduleServiceDetailsCodeTitle + "] ?";

                _scheduleServiceDetailsCodeTitle = String.Empty;

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Deload", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    _teacherLoadingManager.DeleteTeacherLoad(_sysIdScheduleServiceDetails);

                    if (!String.IsNullOrEmpty(_teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text)))
                    {
                        if (this.cboSemester.SelectedIndex >= 0)
                        {
                            _teacherLoadingManager.InitializeSubjectServiceLoadListView(this.lsvSubjectServiceLoad, this.lstDeloadedSchedule,
                                this.tblLoadedSchedule, this.tblDeloadedSchedule, 
                                _teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text),
                                _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex),
                                _teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex));
                        }
                        else
                        {
                            _teacherLoadingManager.InitializeSubjectServiceLoadListView(this.lsvSubjectServiceLoad, this.lstDeloadedSchedule,
                                this.tblLoadedSchedule, this.tblDeloadedSchedule, 
                                _teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text),
                                _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), String.Empty);
                        }

                        this.btnRecord.Enabled = true;

                        this.InitializeInsturctorInfomation();
                    }               
                }
            }
        }//-----------------------
        //################################################END LABEL lblDeloadScheduleServiceDetails EVENTS####################################################

        //################################################Label lblPrintStudentEnrolledList EVENTS####################################################
        //event is raised when lblPrintTeacherLoad is Clicked
        private void lnkPrintStudentEnrolledClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String strSemester = cboSemester.SelectedIndex >= 0 ? " - " + cboSemester.Text : "";

                _teacherLoadingManager.PrintStudentEnrolledList(_userInfo, _sysIdScheduleServiceDetails, this.cboYear.Text + strSemester);

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Printing");
            }
        }//----------------------
        //################################################END Label lblPrintStudentEnrolledList EVENTS####################################################
        #endregion

        #region Programer-Defined Void Procedures
        //this procedure will Set Message Board GroupBox
        private void ResetControls()
        {
            this.lblEmpId.Text = "--";
            this.lblInstructor.Text = "Please Select an Instructor";
            this.lblStatusType.Text = "--";
            this.lblEmpDepartment.Text = "--";
            this.lblUnitsLabHoursLoaded.Text = "--";
            this.lblUnitsLabHoursDeloaded.Text = "--";
            this.lblPreperation.Text = "--";

            this.txtScheduleSearch.Text = String.Empty;

            this.pbxIntructor.Image = null;

            this.lsvSubjectServiceLoad.Items.Clear();

            this.btnLoadScheduleDetails.Enabled = this.tabScheduleDetails.Enabled = this.btnRecord.Enabled = this.btnPrintTeacherLoad.Enabled = false;
        }//----------------------------

        //this procedure will initialize instructor information upon selected index in the treeview control
        private void InitializeInsturctorInfomation()
        {
            this.pbxIntructor.Image = null;

            if (!String.IsNullOrEmpty(_teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text)))
            {
                if (this.cboSemester.SelectedIndex >= 0)
                {
                    _teacherLoadingManager.InitializeSubjectServiceLoadListView(this.lsvSubjectServiceLoad, this.lstDeloadedSchedule,
                                this.tblLoadedSchedule, this.tblDeloadedSchedule, 
                        _teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text),
                        _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex),
                        _teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex));

                    _teacherLoadingManager.SetInstructorInformationControls(_teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text),
                        this.lblUnitsLabHoursLoaded, this.lblUnitsLabHoursDeloaded, _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex),
                        _teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex));

                    this.lblPreperation.Text = _teacherLoadingManager.GetNumberOfPreperation(_teacherLoadingManager.GetEmployeeScheduleSysId(
                        this.trvEmployee.SelectedNode.Text),
                        _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex),
                        _teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex)).ToString();
                }
                else
                {
                    _teacherLoadingManager.InitializeSubjectServiceLoadListView(this.lsvSubjectServiceLoad, this.lstDeloadedSchedule,
                                this.tblLoadedSchedule, this.tblDeloadedSchedule, 
                        _teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text),
                        _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), String.Empty);

                    _teacherLoadingManager.SetInstructorInformationControls(_teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text),
                        this.lblUnitsLabHoursLoaded, this.lblUnitsLabHoursDeloaded, _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), String.Empty);

                    this.lblPreperation.Text = _teacherLoadingManager.GetNumberOfPreperation(_teacherLoadingManager.GetEmployeeScheduleSysId(
                        this.trvEmployee.SelectedNode.Text),
                        _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), String.Empty).ToString();
                }

                _teacherLoadingManager.InitializeSpecialClassLoadedWithdrawnListView(this.lstSpecialClass, this.lblSpecialClass, this.tblSpecialClass,
                    _teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text), false);
                _teacherLoadingManager.InitializeSpecialClassLoadedWithdrawnListView(this.lstWithdrawnSpecialClass, 
                    this.lblWithdrawn, this.tblWithdrawnSpecialClass, _teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text), true);

                CommonExchange.Employee empInfo = _teacherLoadingManager.GetEmployeeInformation(_userInfo,
                    _teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text));

                this.lblEmpId.Text = empInfo.EmployeeId;
                this.lblInstructor.Text = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(empInfo.PersonInfo.LastName, empInfo.PersonInfo.FirstName,
                    empInfo.PersonInfo.MiddleName);
                this.lblStatusType.Text = empInfo.SalaryInfo.EmployeeStatusInfo.StatusDescription + " - " + empInfo.SalaryInfo.EmploymentTypeInfo.TypeDescription;
                this.lblEmpDepartment.Text = empInfo.SalaryInfo.DepartmentInfo.DepartmentName;

                if (!String.IsNullOrEmpty(empInfo.PersonInfo.PersonImagesFolder(Application.StartupPath) + empInfo.PersonInfo.PersonSysId))
                {
                    if (File.Exists(empInfo.PersonInfo.PersonImagesFolder(Application.StartupPath) + empInfo.PersonInfo.PersonSysId + ".jpg"))
                    {
                        this.pbxIntructor.Image = Image.FromFile(empInfo.PersonInfo.PersonImagesFolder(Application.StartupPath) + empInfo.PersonInfo.PersonSysId + ".jpg");
                    }
                }                
            }

            this.tabScheduleDetails.Enabled = true;

            this.btnPrintTeacherLoad.Enabled = this.lsvSubjectServiceLoad.Items.Count == 0 ? false : true;

            if (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(_userInfo))
            {
                this.btnLoadScheduleDetails.Enabled = !_isRecordLocked ? true : false;
            }
        }//-------------------------------

        //this procedure will add subject load
        private void AddSubjectLoad(Boolean isIrregularLoading)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String semesterSysId = String.Empty;

                if (this.cboSemester.SelectedIndex >= 0)
                {
                    semesterSysId = _teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex);
                }
               
                using (SubjectServiceSearchOnTextBoxListTeacherLoad frmSearch = new SubjectServiceSearchOnTextBoxListTeacherLoad(_userInfo,
                    _teacherLoadingManager, 1, _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), semesterSysId,
                    _teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text)))
                {
                    frmSearch.IsIrregularLoading = isIrregularLoading;
                    frmSearch.AdoptGridSize = false;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        if (!String.IsNullOrEmpty(_teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text)))
                        {
                            if (this.cboSemester.SelectedIndex >= 0)
                            {
                                _teacherLoadingManager.InitializeSubjectServiceLoadListView(this.lsvSubjectServiceLoad, this.lstDeloadedSchedule,
                                    this.tblLoadedSchedule, this.tblDeloadedSchedule, 
                                    _teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text),
                                    _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex),
                                    _teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex));
                            }
                            else
                            {
                                _teacherLoadingManager.InitializeSubjectServiceLoadListView(this.lsvSubjectServiceLoad, this.lstDeloadedSchedule,
                                    this.tblLoadedSchedule, this.tblDeloadedSchedule, 
                                    _teacherLoadingManager.GetEmployeeScheduleSysId(this.trvEmployee.SelectedNode.Text),
                                    _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), String.Empty);
                            }

                            this.btnRecord.Enabled = true;

                            this.btnPrintAll.Enabled = this.btnPrintTeacherLoad.Enabled = false;
                        }                       
                    }

                    isIrregularLoading = frmSearch.IsIrregularLoading;
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message + "\n\nError Loading Subject Search Module", "Error Loading");
            }

            if (isIrregularLoading)
            {
                this.AddSubjectLoad(isIrregularLoading);
            }
        }//---------------------------

        //this procedure will InitializeEmployee Information Tree View
        private void InitializeEmployeeInformationTreeView()
        {
            if (this.cboSemester.SelectedIndex >= 0)
            {
                _teacherLoadingManager.GetSearchedEmployee(this.trvEmployee, this.txtEmployeeSearch.Text,
                    _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex),
                    _teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex));

                this.btnPrintAll.Enabled = _teacherLoadingManager.HasTeacherLoad(_teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex),
                    _teacherLoadingManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex));
            }
            else
            {
                _teacherLoadingManager.GetSearchedEmployee(this.trvEmployee, this.txtEmployeeSearch.Text,
                    _teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), "");

                this.btnPrintAll.Enabled = _teacherLoadingManager.HasTeacherLoad(_teacherLoadingManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), String.Empty);
            }

            _teacherLoadingManager.InitializePersonImageTable(_userInfo, Application.StartupPath);

            _teacherLoadingManager.SelectBySysIDEmployeeListDateStartEndSpecialClassInformation(_userInfo, _dateStart, _dateEnd);
        }//--------------------------

        //this procedure determines if the record is Locked or Open
        private void SetRecordStatus()
        {
            if (RemoteClient.ProcStatic.IsRecordLocked(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                DateTime.Parse(_teacherLoadingManager.ServerDateTime), (Int32)CommonExchange.SystemRange.MonthAllowance))
            {
                this.lblStatus.Text = "This record is LOCKED";

                this.pbxLocked.Visible = true;
                this.pbxUnlock.Visible = false;

                this.btnLoadScheduleDetails.Enabled = false;

                this.btnRecord.Visible = false;

                _isRecordLocked = true;
            }
            else
            {
                this.lblStatus.Text = "This record is OPEN.";

                this.pbxLocked.Visible = false;
                this.pbxUnlock.Visible = true;

                this.btnRecord.Visible = true;

                _isRecordLocked = false;
            }

            if (RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo))
            {
                this.btnLoadScheduleDetails.Enabled = false;
            }

            if (RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo))
            {
                this.btnRecord.Visible = this.btnLoadScheduleDetails.Enabled = this.lnkDeloadScheduleServiceDetails.Visible = false;
            }

        }//------------------------
        #endregion

        #region Programmers Defined Functions
        //this function will asked confimation of teacher loading
        private Boolean AskConfirmationForTeacherLoading(String msgDescription, Boolean isYear, Boolean isSemester)
        {
            Boolean isConfermed = false;

            if (_askConfirmation && this.btnRecord.Enabled)
            {
                String strMsg = "There are unrecorded teacher load, changing " + msgDescription +
                   " without recording it causes data lost.\n\n" + "Are you sure you want to continue?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    _askConfirmation = false;

                    if (isYear)
                    {
                        if (this.cboYear.SelectedIndex == _oldIndexYear)
                        {
                            _askConfirmation = true;
                        }

                        this.cboYear.SelectedIndex = _oldIndexYear;
                    }
                    else if (isSemester)
                    {
                        if (this.cboSemester.SelectedIndex == _oldIndexSemester)
                        {
                            _askConfirmation = true;
                        }

                        this.cboSemester.SelectedIndex = _oldIndexSemester;
                    }

                    _hasEnterAskConfirmation = true;
                }
                else
                {
                    isConfermed = true;
                }
            }
            else
            {
                _askConfirmation = true;

                if (_hasEnterAskConfirmation)
                {
                    isConfermed = false;
                }
                else
                {
                    isConfermed = true;

                    _hasEnterAskConfirmation = false;
                }
            }

            return isConfermed;
        }//----------------------
        #endregion
    }
}
