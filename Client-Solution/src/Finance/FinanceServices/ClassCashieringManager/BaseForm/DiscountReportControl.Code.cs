using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace FinanceServices
{
    partial class DiscountReportControl
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CashieringLogic _cashieringManager;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
        #endregion

        #region Class Constructors
        public DiscountReportControl(CommonExchange.SysAccess userInfo, CashieringLogic cashieringLogic)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringLogic;

            this.Load += new EventHandler(ClassLoad);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.cbxCourse.SelectedIndexChanged += new EventHandler(cbxCourseSelectedIndexChanged);
            this.cbxScholarship.SelectedIndexChanged += new EventHandler(cbxScholarshipSelectedIndexChanged);
            this.lnkCourseAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCourseAllLinkClicked);
            this.lnkCourseNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCourseNoneLinkClicked);
            this.lnkScholarshipAll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkScholarshipAllLinkClicked);
            this.lnkScholarshipNone.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkScholarshipNoneLinkClicked);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnGenerateReport.Click += new EventHandler(btnGenerateReportClick);            
        }

        #endregion

        #region Class Event Void Procedures
        //###########################################Class DiscountReportControl EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _cashieringManager.InitializeSchoolYearCombo(this.cboYear);
            _cashieringManager.InitializeCourseCheckedListBox(this.cbxCourse);
            _cashieringManager.InitializeScholarshipListBox(this.cbxScholarship);
        }//-------------------------
        //###########################################EDND Class DiscountReportControl EVENTS#####################################################

        //###########################################COMBOBOX cboYear EVENTS#####################################################
        //event is raised when the selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            _dateStart = _cashieringManager.GetSchoolYearDateStart(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString()
                   + " 12:00:00 AM";
            _dateEnd = _cashieringManager.GetSchoolYearDateEnd(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString()
                + " 11:59:59 PM";

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
        }//----------------------------
        //###########################################END COMBOBOX cboSemester EVENTS#####################################################

        //###########################################CHECKEDLISTBOX cbxScholarship EVENTS#####################################################
        //event is raised when the checked is changed
        private void cbxScholarshipSelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblScholarshipCount.Text = cbxScholarship.CheckedItems.Count.ToString();

            this.btnGenerateReport.Enabled = cbxScholarship.CheckedIndices.Count > 0 && this.cbxCourse.CheckedIndices.Count > 0 ? true : false;
        }//---------------------------------
        //###########################################END CHECKEDLISTBOX cbxScholarship EVENTS#####################################################

        //###########################################CHECKEDLISTBOX cbxCourse EVENTS#####################################################
        //event is raised when the checked is changed
        private void cbxCourseSelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblCourseCount.Text = cbxCourse.CheckedItems.Count.ToString();

            this.btnGenerateReport.Enabled = cbxScholarship.CheckedIndices.Count > 0 && this.cbxCourse.CheckedIndices.Count > 0 ? true : false;
        }//--------------------------
        //###########################################END CHECKEDLISTBOX cbxCourse EVENTS#####################################################

        //###########################################LINKLABEL lnkScholarshipNone EVENTS#####################################################
        //event is raised when the control link is clicked
        private void lnkScholarshipNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxScholarship, lblScholarshipCount, false);

            this.btnGenerateReport.Enabled = cbxScholarship.CheckedIndices.Count > 0 && this.cbxCourse.CheckedIndices.Count > 0 ? true : false;
        }//-------------------------
        //###########################################END LINKLABEL lnkScholarshipNone EVENTS#####################################################

        //###########################################LINKLABEL lnkScholarshipAll EVENTS#####################################################
        //event is raised when the control link is clicked
        private void lnkScholarshipAllLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxScholarship, lblScholarshipCount, true);

            this.btnGenerateReport.Enabled = cbxScholarship.CheckedIndices.Count > 0 && this.cbxCourse.CheckedIndices.Count > 0 ? true : false;
        }//---------------------
        //###########################################END LINKLABEL lnkScholarshipAll EVENTS#####################################################

        //###########################################LINKLABEL lnkCourseNone EVENTS#####################################################
        //event is raised when the control link is clicked
        private void lnkCourseNoneLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxCourse, lblCourseCount, false);

            this.btnGenerateReport.Enabled = cbxScholarship.CheckedIndices.Count > 0 && this.cbxCourse.CheckedIndices.Count > 0 ? true : false;
        }//---------------------
        //###########################################END LINKLABEL lnkCourseNone EVENTS#####################################################

        //###########################################LINKLABEL lnkCourseAll EVENTS#####################################################
        //event is raised when the control link is clicked
        private void lnkCourseAllLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.SetAllListAsChecked(this.cbxCourse, lblCourseCount, true);

            this.btnGenerateReport.Enabled = cbxScholarship.CheckedIndices.Count > 0 && this.cbxCourse.CheckedIndices.Count > 0 ? true : false;
        }//-------------------------
        //###########################################END LINKLABEL lnkCourseAll EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-------------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################

        //###########################################BUTTON btnGenerateReport EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnGenerateReportClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String sem = String.Empty;

                sem = this.cboSemester.SelectedIndex != -1 ? " - " + this.cboSemester.Text : String.Empty;

                _cashieringManager.PrintDiscountReport(_userInfo, _dateStart, _dateEnd, this.cbxCourse, 
                    this.cbxScholarship, this.cboYear.Text + sem, this.progressBar);

                this.progressBar.Value = 0;

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error");
            }
        }//---------------------------
        //###########################################End BUTTON btnGenerateReport EVENTS#####################################################
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
