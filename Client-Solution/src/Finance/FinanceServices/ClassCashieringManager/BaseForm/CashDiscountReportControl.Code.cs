using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class CashDiscountReportControl
    {
        #region Class Data Member Decleration
        private CommonExchange.SysAccess _userInfo;
        private CashieringLogic _cashieringManager;
        #endregion

          #region Class Constructors
        public CashDiscountReportControl(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;

            this.Load += new EventHandler(ClassLoad);
            this.btnShowResult.Click += new EventHandler(btnShowResultClick);
            this.btnPrint.Click += new EventHandler(btnPrintClick);
            this.btnClose.Click += new EventHandler(btnCloseClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS CashReceiptReportControl EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            this.dtpStart.Value = this.dtpEnd.Value = DateTime.Parse(_cashieringManager.ServerDateTime);
        }//------------------------
        //###########################################END CLASS CashReceiptReportControl EVENTS#####################################################

        //###########################################BUTTON btnShowResult EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnShowResultClick(object sender, EventArgs e)
        {
            String dateStart, dateEnd = String.Empty;

            dateStart = this.dtpStart.Value.ToShortDateString() + " 12:00:00 AM";
            dateEnd = this.dtpEnd.Value.ToShortDateString() + " 11:59:59 PM";

            if (DateTime.Compare(DateTime.Parse(dateStart), DateTime.Parse(dateEnd)) < 0)
            {
                this.SearchForCashReciptDetails(dateStart, dateEnd);               
            }
            else
            {
                MessageBox.Show("Date start must me greater than date end.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//-------------------------
        //###########################################END BUTTON btnShowResult EVENTS#####################################################

        //###########################################BUTTON btnPrint EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnPrintClick(object sender, EventArgs e)
        {
            String dateStart, dateEnd = String.Empty;

            dateStart = this.dtpStart.Value.ToShortDateString() + " 12:00:00 AM";
            dateEnd = this.dtpEnd.Value.ToShortDateString() + " 11:59:59 PM";
          
            this.Cursor = Cursors.WaitCursor;

            _cashieringManager.PrintCashDiscountsReport(_userInfo, dateStart, dateEnd, this.chkIsConsolidated.Checked);
          
        }//------------------------
        //###########################################END BUTTON btnPrint EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################
        #endregion


        #region Programmer's Defined Void Procedures
        //this procedure will call the initialization of controls/search of cash recipet details per date range
        private void SearchForCashReciptDetails(String dateStart, String dateEnd)
        {
            this.Cursor = Cursors.WaitCursor;

            _cashieringManager.SelectByDateStartEndCashDiscountsStudentPaymentMiscellaneousIncome(_userInfo, dateStart, dateEnd,
                this.chkIsConsolidated.Checked);

            _cashieringManager.InitializeDiscountListView(this.lsvCashReceiptDetails);

            this.Cursor = Cursors.Arrow;
        }//------------------------------
        #endregion

    }
}
