using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class FeeRegisterDetailedReportControl
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CashieringLogic _cashieringManager;

        protected String _dateStart = String.Empty;
        protected String _dateEnd = String.Empty;

        protected Boolean _isSemestral;
        #endregion

        #region Class Constructors
        public FeeRegisterDetailedReportControl()
        {
            this.InitializeComponent();
        }

        public FeeRegisterDetailedReportControl(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;

            this.Load += new EventHandler(ClassLoad);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.cbxCourse.SelectedIndexChanged += new EventHandler(cbxCourseSelectedIndexChanged);
            this.lnkCourseAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCourseAllLinkClicked);
            this.lnkCourseNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCourseNoneLinkClicked);
            this.cbxYearLevel.SelectedIndexChanged += new EventHandler(cbxYearLevelSelectedIndexChanged);
            this.lnkYearLevelAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkYearLevelAllLinkClicked);
            this.lnkYearLevelNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkYearLevelNoneLinkClicked);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnGenerateReport.Click += new EventHandler(btnGenerateReportClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################Class FeeRegisterReportControl EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _cashieringManager.InitializeSchoolYearCombo(this.cboYear);
        }//------------------------------

        //###########################################COMBOBOX cboYear EVENTS#####################################################
        //event is raised when the selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            _dateStart = _cashieringManager.GetSchoolYearDateStart(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString()
                  + " 12:00:00 AM";
            _dateEnd = _cashieringManager.GetSchoolYearDateEnd(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString()
                + " 11:59:59 PM";

            _isSemestral = false;

            _cashieringManager.InitializeCourseCheckedListBox(this.cbxCourse, _isSemestral);
            _cashieringManager.InitializeYearLevelCheckedListBox(this.cbxYearLevel, _isSemestral);

            this.SetAllListAsChecked(this.cbxCourse, lblCourseCount, false);
            this.SetAllListAsChecked(this.cbxYearLevel, this.lblYearLevelCount, false);

            _cashieringManager.InitializeSemesterCombo(this.cboSemester, this.cboYear.SelectedIndex);
        }//-------------------------
        //###########################################END COMBOBOX cboYear EVENTS#####################################################

        //###########################################COMBOBOX cboSemester EVENTS#####################################################
        //event is raised when the selected index is changed
        private void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            _dateStart = _cashieringManager.GetSemesterDateStart(_cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                    this.cboSemester.SelectedIndex)).ToLongDateString() + " 12:00:00 AM";
            _dateEnd = _cashieringManager.GetSemesterDateEnd(_cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                this.cboSemester.SelectedIndex)).ToLongDateString() + " 11:59:59 PM";

            _isSemestral = true;

            _cashieringManager.InitializeCourseCheckedListBox(this.cbxCourse, _isSemestral);
            _cashieringManager.InitializeYearLevelCheckedListBox(this.cbxYearLevel, _isSemestral);

            this.SetAllListAsChecked(this.cbxCourse, lblCourseCount, false);
            this.SetAllListAsChecked(this.cbxYearLevel, this.lblYearLevelCount, false);
        }//----------------------------
        //###########################################END COMBOBOX cboSemester EVENTS#####################################################

        //###########################################CHECKEDLISTBOX cbxCourse EVENTS#####################################################
        //event is raised when the checked is changed
        private void cbxCourseSelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblCourseCount.Text = cbxCourse.CheckedItems.Count.ToString();

            this.btnGenerateReport.Enabled = this.cbxCourse.CheckedIndices.Count > 0 && this.cbxYearLevel.CheckedIndices.Count > 0 ? true : false;
        }//--------------------------
        //###########################################END CHECKEDLISTBOX cbxCourse EVENTS#####################################################

        //###########################################LINKLABEL lnkCourseNone EVENTS#####################################################
        //event is raised when the control link is clicked
        private void lnkCourseNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxCourse, lblCourseCount, false);

            this.btnGenerateReport.Enabled = this.cbxCourse.CheckedIndices.Count > 0 && this.cbxYearLevel.CheckedIndices.Count > 0 ? true : false;
        }//---------------------
        //###########################################END LINKLABEL lnkCourseNone EVENTS#####################################################

        //###########################################LINKLABEL lnkCourseAll EVENTS#####################################################
        //event is raised when the control link is clicked
        private void lnkCourseAllLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxCourse, lblCourseCount, true);

            this.btnGenerateReport.Enabled = this.cbxCourse.CheckedIndices.Count > 0 && this.cbxYearLevel.CheckedIndices.Count > 0 ? true : false;
        }//-------------------------
        //###########################################END LINKLABEL lnkCourseAll EVENTS#####################################################

        //###########################################CHECKEDLISTBOX cbxYearLevel EVENTS#####################################################
        //event is raised when the checked is changed
        private void cbxYearLevelSelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblYearLevelCount.Text = this.cbxYearLevel.CheckedIndices.Count.ToString();

            this.btnGenerateReport.Enabled = this.cbxCourse.CheckedIndices.Count > 0 && this.cbxYearLevel.CheckedIndices.Count > 0 ? true : false;
        }//-------------------------
        //###########################################END CHECKEDLISTBOX cbxYearLevel EVENTS#####################################################

        //###########################################LINKLABEL lnkYearLevelNone EVENTS#####################################################
        //event is raised when the control link is clicked
        private void lnkYearLevelNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxYearLevel, this.lblYearLevelCount, false);

            this.btnGenerateReport.Enabled = this.cbxCourse.CheckedIndices.Count > 0 && this.cbxYearLevel.CheckedIndices.Count > 0 ? true : false;
        }//------------------------
        //###########################################END LINKLABEL lnkYearLevelNone EVENTS#####################################################

        //###########################################LINKLABEL lnkYearLevelAll EVENTS#####################################################
        //event is raised when the control link is clicked
        private void lnkYearLevelAllLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxYearLevel, this.lblYearLevelCount, true);

            this.btnGenerateReport.Enabled = this.cbxCourse.CheckedIndices.Count > 0 && this.cbxYearLevel.CheckedIndices.Count > 0 ? true : false;
        }//-----------------------------
        //###########################################END LINKLABEL lnkYearLevelAll EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control link is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//------------------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################

        //###########################################BUTTON btnGenerateReport EVENTS#####################################################
        //event is raised when the control link is clicked
        protected virtual void btnGenerateReportClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String sem = String.Empty;

                sem = this.cboSemester.SelectedIndex != -1 ? " - " + this.cboSemester.Text : String.Empty;

                _cashieringManager.PrintFeesRegisterDetailed(_userInfo, _dateStart, _dateEnd, this.cboYear.Text + sem,
                    _isSemestral, this.cbxCourse, this.cbxYearLevel, this.progressBar);

                this.progressBar.Value = 0;

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error");
            }
        }//----------------------
        //###########################################END BUTTON btnGenerateReport EVENTS#####################################################
        #endregion

        #region Programmers-Defined Void Procedures
        //this procedure checks all the list in the checkbox
        private void SetAllListAsChecked(CheckedListBox cbxBase, Label lblBase, Boolean isChecked)
        {
            for (Int32 i = 0; i < cbxBase.Items.Count; i++)
            {
                cbxBase.SetItemChecked(i, isChecked);
            }

            lblBase.Text = cbxBase.CheckedItems.Count.ToString();

        } //-----------------------------
        #endregion
    }
}
