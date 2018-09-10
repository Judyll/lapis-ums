using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class SchoolFeeManager
    {
        #region Class Struct Declaration
        struct ControlTabIndex
        {
            private Int32 _gradeSchoolIndex;
            public Int32 GradeSchoolIndex
            {
                get { return _gradeSchoolIndex; }
                set { _gradeSchoolIndex = value; }
            }

            private Int32 _highSchoolIndex;
            public Int32 HighSchoolIndex
            {
                get { return _highSchoolIndex; }
                set { _highSchoolIndex = value; }
            }

            private Int32 _collegeIndex;
            public Int32 CollegeIndex
            {
                get { return _collegeIndex; }
                set { _collegeIndex = value; }
            }

            private Int32 _graduateSchoolIndex;
            public Int32 GraduateSchoolIndex
            {
                get { return _graduateSchoolIndex; }
                set { _graduateSchoolIndex = value; }
            }

            private Int32 _crashCourseIndex;
            public Int32 CrashCourseIndex
            {
                get { return _crashCourseIndex; }
                set { _crashCourseIndex = value; }
            }
        }
        #endregion

        #region Class General Variable Declaration
        private CommonExchange.SysAccess _userInfo;
        private SchoolFeeLogic _schoolFeeManager;
        private CommonExchange.SchoolFeeInformation _feeInfo;

        private ControlTabIndex _tabStruct;

        private Boolean _hasUpdated = false;
        private Boolean _hasRepeated = false;
        private Boolean _hasRecorded = true;
        private Int32 _cboYearIndex = -1;
        private String _courseGroupId = String.Empty;
        private ErrorProvider _errProvider;
        private DateTime _dateEnd = DateTime.MinValue;
        #endregion

        #region Class Constructors
        public SchoolFeeManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.cboYear.Click += new EventHandler(cboYearClick);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.lnkCreateFee.Click += new EventHandler(lnkCreateFeeClick);
            this.lnkSchoolFeeMaintenance.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkSchoolFeeMaintenanceLinkClicked);
            this.tabSchoolFeeList.SelectedIndexChanged += new EventHandler(tabSchoolFeeListSelectedIndexChanged);
            this.lsvGradeSchool.MouseDown += new MouseEventHandler(listViewMouseDown);
            this.lsvHighSchool.MouseDown += new MouseEventHandler(listViewMouseDown);
            this.lsvCollege.MouseDown += new MouseEventHandler(listViewMouseDown);
            this.lsvGraduateSchool.MouseDown += new MouseEventHandler(listViewMouseDown);
            this.btnSearchdParticular.Click += new EventHandler(btnAddParticularClick);
            this.btnRecord.Click += new EventHandler(btnRecordClick);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnPrint.Click += new EventHandler(btnPrintClick);
        } 
        #endregion

        #region Class Event Void Procedures
        //#####################################################CLASS SCHOOLFEEMANAGER EVENTS #################################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                _schoolFeeManager = new SchoolFeeLogic(_userInfo);
                _feeInfo = new CommonExchange.SchoolFeeInformation();

                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }
                else
                {
                    _schoolFeeManager.InitializeSchoolYearCombo(this.cboYear);

                    if (String.IsNullOrEmpty(_feeInfo.SchoolYearInfo.YearId))
                    {
                        this.lblStatus.Visible = this.btnRecord.Visible = false;
                    }

                    this.InitializeListViewControl();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
        }//-----------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasRecorded)
            {
                String strMsg = "There has been changes made in the current School Fee Module. \nExiting will not save this changes." +
                              "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//-----------------------------------
        //#####################################################END CLASS SCHOOLFEEMANAGER EVENTS #################################################################

        //#####################################################BUTTON btnClose EVENTS#############################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------------------
        //#####################################################END BUTTON btnClose EVENTS#############################################################  

        //#####################################################COMBOBOX cboYear EVENTS############################################################################
        //event is raised when the control is clicked
        private void cboYearClick(object sender, EventArgs e)
        {
            _cboYearIndex = this.cboYear.SelectedIndex;
        }//-------------------------      

        //event is raised when the control index is change
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_hasUpdated && !_hasRepeated)
            {
                String strMsg = "There has been changes made in the current School Fee Module. \nChanging the school year will not save this changes." +
                             "\n\nAre you sure you want to change the school year?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    _hasRepeated = true;

                    this.cboYear.SelectedIndex = _cboYearIndex;
                }
                else
                {
                    _schoolFeeManager.ClearCachedData();

                    _feeInfo.SchoolYearInfo.YearId = _schoolFeeManager.GetSchoolYearYearId(this.cboYear.SelectedIndex);

                    _schoolFeeManager.SelectByDateStartEndSchoolFeeDetails(_userInfo,
                              _schoolFeeManager.GetSchoolYearDateStart(_feeInfo.SchoolYearInfo.YearId).ToShortDateString() + " 12:00:00 AM",
                              _schoolFeeManager.GetSchoolYearDateEnd(_feeInfo.SchoolYearInfo.YearId).ToShortDateString() + " 11:59:59 PM",
                              _schoolFeeManager.GetSysIdSchoolFeeInformation(_feeInfo.SchoolYearInfo.YearId));

                    _dateEnd = _schoolFeeManager.GetSchoolYearDateEnd(_feeInfo.SchoolYearInfo.YearId);

                    _hasUpdated = false;                    
                }
            }
            else if (!_hasUpdated && !_hasRepeated)
            {
                _feeInfo.SchoolYearInfo.YearId = _schoolFeeManager.GetSchoolYearYearId(this.cboYear.SelectedIndex);

                _schoolFeeManager.SelectByDateStartEndSchoolFeeDetails(_userInfo,
                          _schoolFeeManager.GetSchoolYearDateStart(_feeInfo.SchoolYearInfo.YearId).ToShortDateString() + " 12:00:00 AM",
                          _schoolFeeManager.GetSchoolYearDateEnd(_feeInfo.SchoolYearInfo.YearId).ToShortDateString() + " 11:59:59 PM",
                          _schoolFeeManager.GetSysIdSchoolFeeInformation(_feeInfo.SchoolYearInfo.YearId));

                _dateEnd = _schoolFeeManager.GetSchoolYearDateEnd(_feeInfo.SchoolYearInfo.YearId);
            }

            this.PopulateListViewControl();

            this.lblStatus.Visible = true;

            if (this.cboYear.SelectedIndex >= 0 &&
               RemoteClient.ProcStatic.IsRecordLocked(_dateEnd, DateTime.Parse(_schoolFeeManager.ServerDateTime), (Int32)CommonExchange.SystemRange.MonthAllowance))
            {
                this.lblStatus.Text = "This record is LOCKED";

                this.pbxLocked.Visible = true;
                this.pbxUnlock.Visible = false;

                this.btnRecord.Visible = this.lnkSchoolFeeMaintenance.Visible = this.lnkCreateFee.Visible = false;
            }
            else
            {
                this.lblStatus.Text = "This record is OPEN";

                this.pbxLocked.Visible = false;
                this.pbxUnlock.Visible = true;

                this.btnRecord.Visible = true;

                this.lnkSchoolFeeMaintenance.Visible = _schoolFeeManager.IsExistsYearIDSchoolFeeInformation(_feeInfo.SchoolYearInfo.YearId) ? true : false;
            }

            this.tabSchoolFeeList.Focus();

            _hasRepeated = false;
        }//-------------------------------------
        //#####################################################END COMBOBOX cboYear EVENTS#####################################################################

        //#####################################################LABEL lnkCreateFee EVENTS#######################################################################
        //event is raised when the link is clicked
        private void lnkCreateFeeClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControls())
                {
                    String strMsg = "Are you sure you want to create a new school fees for the year " + this.cboYear.Text + "?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The new school fees for the year " + this.cboYear.Text + " has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;
                        
                        _schoolFeeManager.InsertNewSchoolFeeInformation(_userInfo, ref _feeInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;
                        _hasRecorded = true;

                        this.tabSchoolFeeList.Enabled = this.lnkSchoolFeeMaintenance.Visible = true;
                        this.lnkCreateFee.Visible = false;

                        this.InitializeListViewControl();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message + "\n\nError Creating new School Fee Information", "Error Creating");
            }
        }//--------------------------------------
        //#####################################################END LABEL lnkCreateFee EVENTS###################################################################              

        //#####################################################LINKLABEL lnkSchoolFeeMaintenance EVENTS######################################################
        //event is raised when the link is clicked
        private void lnkSchoolFeeMaintenanceLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                using (SchoolFeeMaintenance frmMaintenace = new SchoolFeeMaintenance(_userInfo, _feeInfo, _schoolFeeManager, _courseGroupId))
                {
                    frmMaintenace.DataSource = _schoolFeeManager.GetSchoolFeeByYearLevel(_courseGroupId, _feeInfo.SchoolYearInfo.YearId);
              
                    frmMaintenace.ShowDialog(this);

                    if (frmMaintenace.HasUpdated)
                    {
                        this.PopulateListViewControl();

                        _hasUpdated = true;
                        _hasRecorded = false;
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message + "\n\nError Loading School Fee Maintenance Module.", "Error Loading");
            }
        }//-------------------------------------
        //#####################################################END LINKLABEL lnkSchoolFeeMaintenance EVENTS######################################################

        //#####################################################TABCONTROL tabSchoolFeeList EVENTS######################################################
        //event is raised when the control selected index changed
        private void tabSchoolFeeListSelectedIndexChanged(object sender, EventArgs e)
        { 
            if (this.tabSchoolFeeList.SelectedIndex == _tabStruct.GradeSchoolIndex)
            {
                _courseGroupId = CommonExchange.CourseGroupId.GradeSchoolKinder;

                this.lnkSchoolFeeMaintenance.Enabled = CommonExchange.EnrolmentComponent.IncludeGradeSchoolKinder ? true : false;
            }
            else if (this.tabSchoolFeeList.SelectedIndex == _tabStruct.HighSchoolIndex)
            {
                _courseGroupId = CommonExchange.CourseGroupId.HighSchool;

                this.lnkSchoolFeeMaintenance.Enabled = CommonExchange.EnrolmentComponent.IncludeHighSchool ? true : false;
            }
            else if (this.tabSchoolFeeList.SelectedIndex == _tabStruct.CollegeIndex)
            {
                _courseGroupId = CommonExchange.CourseGroupId.College;

                this.lnkSchoolFeeMaintenance.Enabled = CommonExchange.EnrolmentComponent.IncludeCollege ? true : false;
            }
            else if (this.tabSchoolFeeList.SelectedIndex == _tabStruct.GraduateSchoolIndex)
            {
                _courseGroupId = CommonExchange.CourseGroupId.GraduateSchoolDoctorate;

                this.lnkSchoolFeeMaintenance.Enabled = CommonExchange.EnrolmentComponent.IncludeGraduateSchoolDoctorate ? true : false;
            }
            else if (this.tabSchoolFeeList.SelectedIndex == _tabStruct.CrashCourseIndex)
            {
                _courseGroupId = CommonExchange.CourseGroupId.CrashCourse;

                this.lnkSchoolFeeMaintenance.Enabled = CommonExchange.EnrolmentComponent.IncludeCrashCourse ? true : false;
            }
            else
            {
                this.lnkSchoolFeeMaintenance.Enabled = false;
            }
        }//-----------------------------------
        //#####################################################END TABCONTROL tabSchoolFeeList EVENTS######################################################

        //#####################################################LISTVIEW Mouse Move EVENTS######################################################      
        //event is raised when the mouse is down
        private void listViewMouseDown(object sender, MouseEventArgs e)
        {
            //ListView lsvBase = (ListView)sender;

            //Int32 colHight = lsvBase.Items[0].Bounds.Height;

            //Int32 itemHeight = 0;
            //for (Int32 itemCount = 0; itemCount < lsvBase.Items.Count; itemCount++)
            //{
            //    itemHeight += lsvBase.Items[itemCount].Bounds.Height;
            //}
            //itemHeight += colHight;

            //Int32 itemWidth = 0;
            //for (Int32 colCount = 0; colCount < lsvBase.Columns.Count; colCount++)
            //{
            //    itemWidth += lsvBase.Columns[colCount].Width;
            //}

            //if (e.X >= itemWidth || e.Y >= itemHeight)
            //{
            //    return;
            //}

            //Int32 x = 0, y = 0;
            //Int32 widthLen = lsvBase.Columns[0].Width;
            //Int32 heightLen = colHight + lsvBase.Items[0].Bounds.Height;

            //while (e.X > widthLen)
            //{
            //    x++;

            //    widthLen += lsvBase.Columns[x].Width;
            //}

            //while (e.Y > heightLen)
            //{
            //    y++;

            //    heightLen += lsvBase.Items[y].Bounds.Height;
            //}

            //if (lsvBase.GetItemAt(e.X, e.Y) != null && x < lsvBase.GetItemAt(e.X, e.Y).SubItems.Count)
            //{
            //    if (lsvBase.GetItemAt(e.X, e.Y).SubItems[x].BackColor != Color.FromKnownColor(KnownColor.Window))
            //    {
            //        this.lblLegend.Text = _schoolFeeManager.SetLegendText(lsvBase.GetItemAt(e.X, e.Y).SubItems[x].BackColor);
            //    }
            //    else
            //    {
            //        this.lblLegend.Text = String.Empty;
            //    }
            //}
        }//------------------------------
        //#####################################################END LISTVIEW Mouse Down EVENTS######################################################

        //#####################################################BUTTON btnAddParticular EVENTS#############################################################
        //event is raised when the button is clicked
        private void btnAddParticularClick(object sender, EventArgs e)
        {
            try
            {
                using (ParticularSearchOnTextBoxList frmSearched = new ParticularSearchOnTextBoxList(_userInfo, _schoolFeeManager))
                {
                    frmSearched.AdoptGridSize = true;
                    frmSearched.ShowDialog(this);

                    this.PopulateListViewControl();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message + "\n\nError Loading Add Particular Module.", "Error Loading");
            }
        }//-------------------------------------
        //#####################################################END BUTTON btnAddParticular EVENTS#########################################################

        //#####################################################BUTTON btnRecord EVENTS#############################################################
        //event is raised when the button is clicked
        private void btnRecordClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you want to record the new school fee details?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The school fee details has been successfully recorded.";

                    this.Cursor = Cursors.WaitCursor;

                    _schoolFeeManager.RecordSchoolFeeDetails(_userInfo);

                    this.PopulateListViewControl();

                    this.Cursor = Cursors.Arrow;

                    MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    _hasUpdated = false;
                    _hasRecorded = true;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message + "\n\nError recording new school fees details.", "Error Recording");
            }
        }//--------------------------------
        //#####################################################END BUTTON btnRecord EVENTS#############################################################

        //#####################################################BUTTON btnPrint EVENTS#############################################################
        //event is raised when the button is clicked
        private void btnPrintClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            _schoolFeeManager.PrintSchoolFeesDetails(_userInfo, lsvGradeSchool, lsvHighSchool, lsvCollege, lsvGraduateSchool, this.cboYear.Text);

            this.Cursor = Cursors.Arrow;
        }//-------------------------------      
        //#####################################################END BUTTON btnPrint EVENTS#############################################################
        #endregion

        #region Programers-Defined Void Procedures        
        //this procedure will Initialized List View Control
        private void InitializeListViewControl()
        {
            Int32 indexCount = 0;

            Boolean firstEntry = false;

            if (CommonExchange.EnrolmentComponent.IncludeGradeSchoolKinder)
            {
                _schoolFeeManager.InitializeListViewColumns(CommonExchange.CourseGroupId.GradeSchoolKinder, this.lsvGradeSchool, 100);

                _tabStruct.GradeSchoolIndex = indexCount;

                indexCount++;

                if (!firstEntry)
                {
                    _courseGroupId = CommonExchange.CourseGroupId.GradeSchoolKinder;

                    this.tabSchoolFeeList.SelectedIndex = 0;

                    firstEntry = true;
                }
            }
            else
            {
                this.tabSchoolFeeList.TabPages.RemoveAt(indexCount);

                _tabStruct.GradeSchoolIndex = -1;
            }

            if (CommonExchange.EnrolmentComponent.IncludeHighSchool)
            {
                _schoolFeeManager.InitializeListViewColumns(CommonExchange.CourseGroupId.HighSchool, this.lsvHighSchool, 100);

                _tabStruct.HighSchoolIndex = indexCount;

                indexCount++;

                if (!firstEntry)
                {
                    _courseGroupId = CommonExchange.CourseGroupId.HighSchool;

                    this.tabSchoolFeeList.SelectedIndex = 1;

                    firstEntry = true;
                }
            }
            else
            {
                this.tabSchoolFeeList.TabPages.RemoveAt(indexCount);

                _tabStruct.HighSchoolIndex = -1;
            }

            if (CommonExchange.EnrolmentComponent.IncludeCollege)
            {
                _schoolFeeManager.InitializeListViewColumns(CommonExchange.CourseGroupId.College, this.lsvCollege, 100);

                _tabStruct.CollegeIndex = indexCount;

                indexCount++;

                if (!firstEntry)
                {
                    _courseGroupId = CommonExchange.CourseGroupId.College;

                    this.tabSchoolFeeList.SelectedIndex = 2;

                    firstEntry = true;
                }
            }
            else
            {
                this.tabSchoolFeeList.TabPages.RemoveAt(indexCount);

                _tabStruct.CollegeIndex = -1;
            }

            if (CommonExchange.EnrolmentComponent.IncludeGraduateSchoolDoctorate)
            {
                _schoolFeeManager.InitializeListViewColumns(CommonExchange.CourseGroupId.GraduateSchoolDoctorate, this.lsvGraduateSchool, 100);

                _tabStruct.GraduateSchoolIndex = indexCount;

                indexCount++;

                if (!firstEntry)
                {
                    _courseGroupId = CommonExchange.CourseGroupId.GraduateSchoolDoctorate;

                    this.tabSchoolFeeList.SelectedIndex = 3;

                    firstEntry = true;
                }
            }
            else
            {
                this.tabSchoolFeeList.TabPages.RemoveAt(indexCount);

                _tabStruct.GraduateSchoolIndex = -1;
            }

            if (CommonExchange.EnrolmentComponent.IncludeCrashCourse)
            {
                _schoolFeeManager.InitializeListViewColumns(CommonExchange.CourseGroupId.CrashCourse, this.lsvCrashCourse, 110);

                _tabStruct.CrashCourseIndex = indexCount;

                indexCount++;

                if (!firstEntry)
                {
                    _courseGroupId = CommonExchange.CourseGroupId.CrashCourse;

                    this.tabSchoolFeeList.SelectedIndex = 4;

                    firstEntry = true;
                }
            }
            else
            {
                this.tabSchoolFeeList.TabPages.RemoveAt(indexCount);

                _tabStruct.CrashCourseIndex = -1;
            }
        }//--------------------------------
      
        //this procedure will Populate ListView Control
        private void PopulateListViewControl()
        {
            if (!_schoolFeeManager.IsExistsYearIDSchoolFeeInformation(_feeInfo.SchoolYearInfo.YearId))
            {
                this.lsvGradeSchool.Items.Clear();
                this.lsvHighSchool.Items.Clear();
                this.lsvCollege.Items.Clear();
                this.lsvGraduateSchool.Items.Clear();
                this.lsvCrashCourse.Items.Clear();

                if (!String.IsNullOrEmpty(_feeInfo.SchoolYearInfo.YearId))
                {
                    this.lnkCreateFee.Visible = true;
                }

                this.lnkSchoolFeeMaintenance.Visible = false;
            }
            else
            {   
                _schoolFeeManager.InitializeListViewDetails(this.lsvGradeSchool, CommonExchange.CourseGroupId.GradeSchoolKinder, true);
                _schoolFeeManager.InitializeListViewDetails(this.lsvHighSchool, CommonExchange.CourseGroupId.HighSchool, true);
                _schoolFeeManager.InitializeListViewDetails(this.lsvCollege, CommonExchange.CourseGroupId.College, false);
                _schoolFeeManager.InitializeListViewDetails(this.lsvGraduateSchool, CommonExchange.CourseGroupId.GraduateSchoolDoctorate, false);
                _schoolFeeManager.InitializeListViewDetails(this.lsvCrashCourse, CommonExchange.CourseGroupId.CrashCourse, false);

                this.tabSchoolFeeList.Enabled = true;

                _feeInfo.FeeInformationSysId = _schoolFeeManager.GetSysIdSchoolFeeInformation(_feeInfo.SchoolYearInfo.YearId);

                this.lnkCreateFee.Visible = false;

            }
        }//------------------------------
        #endregion

        #region Programes-Defined Functions
        //this procedure will Validate Controls
        private Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.toolBarSchoolFee, "");

            if (_schoolFeeManager.IsExistsYearIDSchoolFeeInformation(_feeInfo.SchoolYearInfo.YearId))
            {
                _errProvider.SetIconAlignment(this.toolBarSchoolFee, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.toolBarSchoolFee, "The School Fee Information is aleady exist.");
                isValid = false;
            }

            return isValid;
        }//-------------------------------
        #endregion
    }
}
