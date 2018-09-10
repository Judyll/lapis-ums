using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class SubjectServiceSearchOnTextBoxListTeacherLoad
    {
        #region Class Properties Declaration
        private Boolean _isIregularLoading = false;
        public Boolean IsIrregularLoading
        {
            get { return _isIregularLoading; }
            set { _isIregularLoading = value; }
        }
        #endregion

        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;

        private TeacherLoadingLogic _teacherLoadingManager;

        private String _yearId = String.Empty;
        private String _semesterSysid = String.Empty;
        private String _employeeId = String.Empty;

        private Int32 _selected = 0;

        private Boolean _isChecked = false;
        #endregion

        #region Class Constructors
        public SubjectServiceSearchOnTextBoxListTeacherLoad(CommonExchange.SysAccess userInfo, TeacherLoadingLogic teacherLoadingManager, 
            Int32 primaryIndex, String yearId, String semesterId, String employeeId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            _teacherLoadingManager = teacherLoadingManager;

            _yearId = yearId;
            _semesterSysid = semesterId;
            _employeeId = employeeId;

            this.PrimaryIndex = primaryIndex;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.chkIsIrregular.CheckedChanged += new EventHandler(chkIsIrregularCheckedChanged);
            this.dgvList.CellEnter += new DataGridViewCellEventHandler(dgvListCellEnter);
            this.dgvList.CellContentClick += new DataGridViewCellEventHandler(dgvListCellContentClick);
            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
            this.pbxChecked.Click += new EventHandler(pbxCheckedClick);
            this.pbxInsertSubjects.Click += new EventHandler(pbxInsertSubjectsClick);
        }//--------------------------
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS SubjectSearchOnTextBoxListStudentLoading EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_teacherLoadingManager.SubjectServiceTableFormat);

            base.ClassLoad(sender, e);           

            ToolTip ttTool = new ToolTip();

            ttTool.SetToolTip(this.pbxInsertSubjects, "Load Selected Schedule/Service.");

            this.pbxChecked.Location = new Point(12, 19);

            this.dgvList.ReadOnly = false;

            this.chkIsIrregular.Checked = _isIregularLoading;
        }//----------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            
        }//------------------------------
        //####################################END CLASS SubjectSearchOnTextBoxListStudentLoading EVENTS####################################

        //#############################################PICTUREBOX pbxDone EVENTS##############################################################
        //event is raised when the picturebox is clicked
        protected override void pbxDoneClick(object sender, EventArgs e)
        {
            _isIregularLoading = false;

            base.pbxDoneClick(sender, e);
        }//-------------------------
        //#############################################END PICTUREBOX pbxDone EVENTS##############################################################

        //##################################CHECKBOX chkIsIrregularLoading EVENTS######################################################
        //event is raised when the checked status is changed
        private void chkIsIrregularCheckedChanged(object sender, EventArgs e)
        {
            _isIregularLoading = this.chkIsIrregular.Checked;
        }//--------------------------
        //##################################END CHECKBOX chkIsIrregularLoading EVENTS######################################################

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_teacherLoadingManager.GetSearchedSubjectScheduleServiceInformation(((TextBox)sender).Text, _yearId, _semesterSysid));

                    this.SelectFirstRowInDataGridView();                  
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Student List");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }

            base.txtSearchKeyUp(sender, e);
        }//--------------------
        //##################################END TEXTBOX txtSearch EVENTS##########################################################

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################     
        //event is raised when the mouse is enter
        private void dgvListCellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                this.dgvList.BeginEdit(true);                

                DataGridViewCell dgvCell = this.dgvList.Rows[e.RowIndex].Cells["sysid_schedule"];

                dgvCell.ErrorText = String.Empty;

                this.dgvList[0, e.RowIndex].ReadOnly = false;

                String strTemp = String.Empty;

                if (_teacherLoadingManager.HasConflictSchedule((System.Data.DataTable)this.dgvList.DataSource,
                   this.dgvList.Rows[e.RowIndex].Cells["sysid_schedule"].Value.ToString(), _employeeId, ref strTemp))
                {
                    this.dgvList[0, e.RowIndex].ReadOnly = true;
                    this.dgvList.ShowRowErrors = true;
                }


                this.dgvList.EndEdit();
            }
            else
            {
                this.dgvList.Rows[e.RowIndex].ReadOnly = true;
            }
        }//-----------------------

        //event is raised when the cell content is clicked
        private void dgvListCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                this.dgvList.ShowCellErrors = false;

                String scheduleInformation = String.Empty;

                DataGridViewCell dgvCell = this.dgvList.Rows[e.RowIndex].Cells["sysid_schedule"];

                for (Int32 x = 0; x < this.dgvList.Rows.Count; x++)
                {
                    DataGridViewCell dgvCellClear = this.dgvList.Rows[x].Cells["sysid_schedule"];

                    dgvCellClear.ErrorText = String.Empty;
                }

                if (!(Boolean)this.dgvList.Rows[e.RowIndex].Cells["checkbox_column"].Value &&
                   (_teacherLoadingManager.HasConflictSchedule((System.Data.DataTable)this.dgvList.DataSource,
                   this.dgvList.Rows[e.RowIndex].Cells["sysid_schedule"].Value.ToString(), _employeeId, ref scheduleInformation)))
                {
                    String value = String.Empty;

                    if (!String.IsNullOrEmpty(scheduleInformation))
                    {
                        value = scheduleInformation.Remove(scheduleInformation.Length - 2, 2);
                    }

                    dgvCell.ErrorText = value;

                    ToolTip errToolTip = new ToolTip();

                    errToolTip.Show(dgvCell.ErrorText, this.dgvList, 10);

                    this.dgvList.Rows[e.RowIndex].Cells["checkbox_column"].Value = false;

                    this.dgvList.ShowCellErrors = true;
                }
                else
                {
                    DataGridViewCheckBoxCell checkedCell = this.dgvList.Rows[e.RowIndex].Cells["checkbox_column"] as DataGridViewCheckBoxCell;

                    this.dgvList.Rows[e.RowIndex].Cells["checkbox_column"].Value = (Boolean)checkedCell.Value;

                    if (!checkedCell.ReadOnly)
                    {
                        if (!(Boolean)checkedCell.Value)
                        {
                            _selected++;
                        }
                        else
                        {
                            _selected--;
                        }
                    }

                    this.lblSelected.Text = _selected.ToString();
                }

                this.dgvList.EndEdit();
            }
        }//-------------------------

        //event is raised when the control is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {
        }//----------------------
        //####################################################END DATAGRIDVIEW dgvList EVENTS####################################################     

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.txtSearch.Clear();
            this.dgvList.Refresh();

            this.Cursor = Cursors.Arrow;
        }//----------------------
        //##################################END PICTUREBOX pbxRefresh EVENTS######################################################

        //##################################PICTUREBOX pbxChecked EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxCheckedClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            _isChecked = !_isChecked;

            _selected = 0;

            this.dgvList.EndEdit();

            this.dgvList.ShowCellErrors = _isChecked ? true : false;

            for (Int32 x = 0; x < this.dgvList.Rows.Count; x++)
            {
                String scheduleInformation = String.Empty;

                DataGridViewCell dgvCell = this.dgvList.Rows[x].Cells["sysid_schedule"];

                dgvCell.ErrorText = String.Empty;

                if (!(Boolean)this.dgvList.Rows[x].Cells["checkbox_column"].Value &&
                    _teacherLoadingManager.HasConflictSchedule((System.Data.DataTable)this.dgvList.DataSource,
                    this.dgvList.Rows[x].Cells["sysid_schedule"].Value.ToString(), _employeeId, ref scheduleInformation))
                {
                    String value = String.Empty;

                    if (!String.IsNullOrEmpty(scheduleInformation))
                    {
                        value = scheduleInformation.Remove(scheduleInformation.Length - 2, 2);
                    }

                    dgvCell.ErrorText = value;

                    ToolTip errToolTip = new ToolTip();

                    errToolTip.Show(dgvCell.ErrorText, this.dgvList, 10);
                }
                else
                {
                    dgvList.Rows[x].Cells["checkbox_column"].Value = _isChecked;

                    this.dgvList[0, x].ReadOnly = false;

                    if (_isChecked)
                    {
                        _selected++;
                    }
                }
            }

            this.lblSelected.Text = _selected.ToString();

            this.pbxInsertSubjects.Focus();

            this.Cursor = Cursors.Arrow;
        }//--------------------
        //##################################END PICTUREBOX pbxChecked EVENTS######################################################

        //##################################PICTUREBOX pbxInsertSubjects EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxInsertSubjectsClick(object sender, EventArgs e)
        {
            Boolean hasInserted = false;
            Boolean hasErrors = false;

            this.dgvList.EndEdit();

            this.dgvList.ShowCellErrors = true;

            DataTable conflictSchduleTable = _teacherLoadingManager.SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad(_userInfo,
                (DataTable)this.dgvList.DataSource, _employeeId);

            for (Int32 x = 0; x < this.dgvList.Rows.Count; x++)
            {
                if ((Boolean)this.dgvList.Rows[x].Cells["checkbox_column"].Value)
                {
                    if (!_teacherLoadingManager.HasConflictSchedule(conflictSchduleTable, dgvList.Rows[x].Cells["sysid_schedule"].Value.ToString()))
                    {
                        _teacherLoadingManager.InsertTeacherLoadCached(_employeeId, dgvList.Rows[x].Cells["sysid_schedule"].Value.ToString());

                        hasInserted = true;
                    }
                    else
                    {
                        this.dgvList.Rows[x].Cells["checkbox_column"].Value = false;

                        DataGridViewCell dgvCell = this.dgvList.Rows[x].Cells["sysid_schedule"];

                        CommonExchange.Employee empInfo = _teacherLoadingManager.GetEmployeeInformation(_userInfo, _employeeId);

                        dgvCell.ErrorText = "This schedule conflicts with another schedule that has been loaded to " +
                            RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(empInfo.PersonInfo.LastName, empInfo.PersonInfo.FirstName, 
                            empInfo.PersonInfo.MiddleName) + " from another department.";

                        ToolTip errToolTip = new ToolTip();

                        errToolTip.Show(dgvCell.ErrorText, this.dgvList, 10);

                        hasErrors = true;
                    }
                }


            }

            if (hasInserted)
            {
                _hasSelected = true;
                this.Close();
            }
            else if (!hasErrors)
            {
                MessageBox.Show("There is no subject schedule / service that has been selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }//-------------------------
        //##################################END PICTUREBOX pbxInsertSubjects EVENTS######################################################
        #endregion
    }
}
