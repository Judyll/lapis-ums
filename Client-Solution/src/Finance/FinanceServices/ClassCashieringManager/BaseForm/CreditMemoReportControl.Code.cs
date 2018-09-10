using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class CreditMemoReportControl
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CashieringLogic _cashieringManager;
        #endregion

        #region Class Constructors
        public CreditMemoReportControl(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;

            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnGenerateReport.Click += new EventHandler(btnGenerateReportClick);            
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################

        //###########################################BUTTON btnGenerateReport EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnGenerateReportClick(object sender, EventArgs e)
        {
            String dateStart, dateEnd = String.Empty;

            dateStart = this.dtpStart.Value.ToShortDateString() + " 12:00:00 AM";
            dateEnd = this.dtpEnd.Value.ToShortDateString() + " 11:59:59 PM";

            if (DateTime.Compare(DateTime.Parse(dateStart), DateTime.Parse(dateEnd)) < 0)
            {
                this.Cursor = Cursors.WaitCursor;

                _cashieringManager.PrintCreditMemoProoflist(_userInfo, dateStart, dateEnd, this.chkIsConsolidated.Checked, this.progressBar);

                this.Cursor = Cursors.Arrow;

                this.progressBar.Value = 0;
            }
            else
            {
                MessageBox.Show("Date start must me greater than date end.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//----------------------
        //###########################################END BUTTON btnGenerateReport EVENTS#####################################################
        #endregion
    }
}
