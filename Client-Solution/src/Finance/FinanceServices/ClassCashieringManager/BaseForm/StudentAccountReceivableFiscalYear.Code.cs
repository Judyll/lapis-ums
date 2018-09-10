using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentAccountReceivableFiscalYear
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CashieringLogic _cashieringManager;

        private String _yearId = String.Empty;
        private String _semesterId = String.Empty;
        #endregion

        #region Class Constructors
        public StudentAccountReceivableFiscalYear(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;


            this.Load += new EventHandler(ClassLoad);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnGenerateReport.Click += new EventHandler(btnGenerateReportClick);
        }        
        #endregion

        #region Class Event Void Procedures
        //###########################################Class StudentAccountReceivablePerTerm EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            this.btnGenerateReport.Enabled = false;

            _cashieringManager.InitializeSchoolYearComboNoSummer(this.cboYear);
        }//-----------------------
        //###########################################END Class StudentAccountReceivablePerTerm EVENTS#####################################################

        //###########################################COMBOBOX cboYear EVENTS#####################################################
        //event is raised when the selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            _yearId = _cashieringManager.GetSchoolYearYearIdNoSummer(this.cboYear.SelectedIndex);

            this.btnGenerateReport.Enabled = true;
        }//------------------------
        //###########################################END COMBOBOX cboYear EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control link is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################

        //###########################################BUTTON btnGenerateReport EVENTS#####################################################
        //event is raised when the control link is clicked
        private void btnGenerateReportClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _cashieringManager.PrintStudentAccountsReceivablePerFiscalYear(_userInfo, _yearId, this.cboYear.Text.Substring(5, this.cboYear.Text.Length-5), this.progressBar);

                this.progressBar.Value = 0;

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error");
            }
        }//------------------
        //###########################################END BUTTON btnGenerateReport EVENTS#####################################################

        #endregion
    }
}
