using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentBalanceReport
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CashieringLogic _cashieringManager;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
        #endregion

        #region Class Constructors
        public StudentBalanceReport(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;

            this.Load += new EventHandler(StudentBalanceReportLoad);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.rdbAll.CheckedChanged += new EventHandler(rdbAllCheckedChanged);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnGenerateReport.Click += new EventHandler(btnGenerateReportClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################Class StudentBalanceReport EVENTS#####################################################
        //event is raised when the class is loaded
        private void StudentBalanceReportLoad(object sender, EventArgs e)
        {
            _cashieringManager.InitializeSchoolYearCombo(this.cboYear);
        }//-----------------------
        //###########################################EDN Class StudentBalanceReport EVENTS#####################################################

        //###########################################COMBOBOX cboYear EVENTS#####################################################
        //event is raised when the selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            _dateStart = _cashieringManager.GetSchoolYearDateStart(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString()
                   + " 12:00:00 AM";
            _dateEnd = _cashieringManager.GetSchoolYearDateEnd(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString()
                + " 11:59:59 PM";

            _cashieringManager.InitializeSemesterCombo(this.cboSemester, this.cboYear.SelectedIndex);            
        }//---------------------
        //###########################################END COMBOBOX cboYear EVENTS#####################################################

        //###########################################COMBOBOX cboSemester EVENTS#####################################################
        //event is raised when the selected index is changed
        private void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            _dateStart = _cashieringManager.GetSemesterDateStart(_cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                    this.cboSemester.SelectedIndex)).ToLongDateString() + " 12:00:00 AM";
            _dateEnd = _cashieringManager.GetSemesterDateEnd(_cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                this.cboSemester.SelectedIndex)).ToLongDateString() + " 11:59:59 PM";
        }//-------------------
        //###########################################END COMBOBOX cboSemester EVENTS#####################################################

        //###########################################RADIOBUTTON rdbAll EVENTS#####################################################
        //event is raised when the selected index is changed
        private void rdbAllCheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbAll.Checked)
            {
                _cashieringManager.InitializeSchoolYearCombo(this.cboYear);

                this.cboSemester.Enabled = false;
            }
            else
            {
                this.cboSemester.Enabled = true;
            }
        }//-------------------------
        //###########################################END RADIOBUTTON rdbAll EVENTS#####################################################

        //###########################################BUTTON btnGenerateReport EVENTS#####################################################
        //event is raised when the control link is clicked
        private void btnGenerateReportClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String sem = String.Empty;

                sem = this.cboSemester.SelectedIndex != -1 ? " - " + this.cboSemester.Text : String.Empty;

               
                _cashieringManager.PrintStudetBalanceProoflist(_userInfo, _dateStart, _dateEnd,
                    _dateEnd, this.cboYear.Text + sem, this.rdbAll.Checked, this.progressBar);

                this.progressBar.Value = 0;

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error");
            }
        }//------------------
        //###########################################END BUTTON btnGenerateReport EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control link is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################

        #endregion
    }
}
