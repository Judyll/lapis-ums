using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class FeeRegisterSummarizedReportControl
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CashieringLogic _cashieringManager;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;

        private Boolean _isSemestral = false;
        #endregion

        #region Class Constructors
        public FeeRegisterSummarizedReportControl(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;

            this.Load += new EventHandler(ClassLoad);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.cbxCourseGroup.SelectedIndexChanged += new EventHandler(cbxCourseGroupSelectedIndexChanged);
            this.lnkCourseGroupAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCourseGroupAllLinkClicked);
            this.lnkCourseGroupNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCourseGroupNoneLinkClicked);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnGenerateReport.Click += new EventHandler(btnGenerateReportClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################Class FeeRegisterSummarizedReportControl EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _cashieringManager.InitializeSchoolYearCombo(this.cboYear);

        }//-----------------------
        //###########################################END Class FeeRegisterSummarizedReportControl EVENTS#####################################################

        //###########################################COMBOBOX cboYear EVENTS#####################################################
        //event is raised when the selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            _dateStart = _cashieringManager.GetSchoolYearDateStart(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString()
                    + " 12:00:00 AM";
            _dateEnd = _cashieringManager.GetSchoolYearDateEnd(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString()
                + " 11:59:59 PM";

            _isSemestral = false;

            _cashieringManager.InitializeCourseGroupListBox(this.cbxCourseGroup, _isSemestral);

            _cashieringManager.InitializeSemesterCombo(this.cboSemester, this.cboYear.SelectedIndex);
        }//----------------------
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

            _cashieringManager.InitializeCourseGroupListBox(this.cbxCourseGroup, _isSemestral);
        }//----------------------------
        //###########################################END COMBOBOX cboSemester EVENTS#####################################################

        //###########################################CHECKEDLISTBOX cbxCourseGroup EVENTS#####################################################
        //event is raised when the checked is changed
        private void cbxCourseGroupSelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblCourseCount.Text = this.cbxCourseGroup.CheckedIndices.Count.ToString();

            this.btnGenerateReport.Enabled = this.cbxCourseGroup.CheckedIndices.Count > 0 ? true : false;
        }//------------------------
        //###########################################END CHECKEDLISTBOX cbxCourseGroup EVENTS#####################################################

        //###########################################LINKLABEL lnkCourseGroupNone EVENTS#####################################################
        //event is raised when the control link is clicked
        private void lnkCourseGroupNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxCourseGroup, this.lblCourseCount, false);

            this.btnGenerateReport.Enabled = this.cbxCourseGroup.CheckedIndices.Count > 0 ? true : false;
        }//----------------------
        //###########################################END LINKLABEL lnkCourseGroupNone EVENTS#####################################################

        //###########################################LINKLABEL lnkCourseGroupAll EVENTS#####################################################
        //event is raised when the control link is clicked
        private void lnkCourseGroupAllLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxCourseGroup, this.lblCourseCount, true);

            this.btnGenerateReport.Enabled = this.cbxCourseGroup.CheckedIndices.Count > 0 ? true : false;
        }//----------------------
        //###########################################END LINKLABEL lnkCourseGroupAll EVENTS#####################################################

        //###########################################BUTTON btnGenerateReport EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnGenerateReportClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String sem = String.Empty;

                sem = this.cboSemester.SelectedIndex != -1 ? " - " + this.cboSemester.Text : String.Empty;

                _cashieringManager.PrintFeeRegisterSummarized(_userInfo, _dateStart, _dateEnd, this.cboYear.Text + sem,
                    _isSemestral, this.cbxCourseGroup, this.progressBar);

                this.progressBar.Value = 0;

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error");
            }
        }//---------------------------
        //###########################################End BUTTON btnGenerateReport EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-------------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################

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
