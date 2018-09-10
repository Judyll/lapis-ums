using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class CashReceiptReportControl
    {
        #region Class Data Member Decleration
        private CommonExchange.SysAccess _userInfo;
        private CashieringLogic _cashieringManager;
        #endregion

        #region Class Properties Declaration
        private Boolean _isForDetails = false;
        public Boolean IsForDetails
        {
            set { _isForDetails = value; }
        }

        private Boolean _isForSummarized = false;
        public Boolean IsForSummarized
        {
            set { _isForSummarized = value; }
        }
        #endregion

        #region Class Constructors
        public CashReceiptReportControl(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
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
            if (_isForDetails)
            {
                this.lnkCreateBreakDownDeposit.Visible = true;

                this.lsvBankDeposits.MouseDoubleClick += new MouseEventHandler(lsvBankDepositsMouseDoubleClick);
                this.lnkCreateBreakDownDeposit.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkCreateBreakDownDepositLinkClicked);
            }

            this.dtpStart.Value = this.dtpEnd.Value = DateTime.Parse(_cashieringManager.ServerDateTime);

            this.pnlDetails.Visible = this.lsvCashReceiptDetails.Visible = this.pnlSummarized.Visible = this.lsvCashReceipsSummariezed.Visible = false;

            if (_isForDetails)
            {
                this.pnlDetails.Visible = this.lsvCashReceiptDetails.Visible = true;
            }
            else if (_isForSummarized)
            {
                this.pnlSummarized.Visible = this.lsvCashReceipsSummariezed.Visible = true;
            }
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
                if (_isForDetails)
                {
                    this.SearchForCashReciptDetails(dateStart, dateEnd);
                }
                else if (_isForSummarized)
                {
                    this.SearchForCashReciptSummarized(dateStart, dateEnd);
                }
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

            if (_isForDetails)
            {
                this.Cursor = Cursors.WaitCursor;

                _cashieringManager.PrintCashReceiptDetailReport(_userInfo, dateStart, dateEnd, this.chkIsConsolidated.Checked);

                this.Cursor = Cursors.Arrow;
            }
            else if (_isForSummarized)
            {
                this.Cursor = Cursors.WaitCursor;

                _cashieringManager.PrintCashReceiptSummarizedReport(_userInfo, dateStart, dateEnd, this.chkIsConsolidated.Checked);

                this.Cursor = Cursors.Arrow;
            }
        }//------------------------
        //###########################################END BUTTON btnPrint EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################

        //###########################################LISTVIEW lsbBankDeposit EVENTS#####################################################
        //event is raised when the control is clicked
        private void lsvBankDepositsMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((this.lsvBankDeposits.Items.Count > 0 && this.lsvBankDeposits.FocusedItem != null) && this.lsvBankDeposits.GetItemAt(e.X, e.Y) != null)
                {
                    String dateStart, dateEnd = String.Empty;

                    dateStart = this.dtpStart.Value.ToShortDateString() + " 12:00:00 AM";
                    dateEnd = this.dtpEnd.Value.ToShortDateString() + " 11:59:59 PM";

                    String accountSysId = this.lsvBankDeposits.GetItemAt(e.X, e.Y).SubItems[5].Text;

                    if (!String.IsNullOrEmpty(accountSysId))
                    {
                        using (BreakDownBankDepositUpdate frmUpdate = new BreakDownBankDepositUpdate(_userInfo,
                            _cashieringManager.GetDetailsBreakDownBankDepositInformation(accountSysId), _cashieringManager, dateStart, dateEnd))
                        {
                            frmUpdate.ShowDialog(this);

                            if (frmUpdate.HasUpdated || frmUpdate.HasDeleted)
                            {
                                this.SearchForCashReciptDetails(dateStart, dateEnd);
                            }
                        }
                    }
                }
            }
        }//------------------
        //###########################################END LISTVIEW lsbBankDeposit EVENTS#####################################################

        //###########################################LINKLABEL lsbBankDeposit EVENTS#####################################################
        //event is raised when the control is clicked
        private void lnkCreateBreakDownDepositLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String dateStart, dateEnd = String.Empty;

            dateStart = this.dtpStart.Value.ToShortDateString() + " 12:00:00 AM";
            dateEnd = this.dtpEnd.Value.ToShortDateString() + " 11:59:59 PM";

            using (BreakDownBankDepositCreate frmCreate = new BreakDownBankDepositCreate(_userInfo, _cashieringManager, dateStart, dateEnd))
            {
                frmCreate.ShowDialog(this);

                if (frmCreate.HasRecorded)
                {
                    this.SearchForCashReciptDetails(dateStart, dateEnd);
                }
            }
        }//-------------------------
        //###########################################END LINKLABEL lsbBankDeposit EVENTS#####################################################
        #endregion

        #region Programmer's Defined Void Procedures
        //this procedure will call the initialization of controls/search of cash recipet details per date range
        private void SearchForCashReciptDetails(String dateStart, String dateEnd)
        {
            this.Cursor = Cursors.WaitCursor;

            _cashieringManager.SelectByDateStartEndCashReceiptsDetailedStudentPaymentMiscellaneousIncome(_userInfo, dateStart, dateEnd, 
                this.chkIsConsolidated.Checked);

            _cashieringManager.SelectByDateStartEndCashReceiptsDetailedBreakdownBankDeposit(_userInfo, dateStart, dateEnd, this.chkIsConsolidated.Checked);

            _cashieringManager.InitializeBreakDownBankDepositDetailsSummarizedListView(this.lsvBankDeposits, true);
            _cashieringManager.InitializeCashReceiptsDetailsListView(this.lsvCashReceiptDetails, this.lblTotalCashReceipts, this.lblTotalDeposits, this.lblShortage);

            this.Cursor = Cursors.Arrow;
        }//------------------------------

        //this procedure will call the initialization of controls/search of cash recipet summarized per date range
        private void SearchForCashReciptSummarized(String dateStart, String dateEnd)
        {
            this.Cursor = Cursors.WaitCursor;

            _cashieringManager.SelectByDateStartEndCashReceiptsSummarizedStudentPaymentMiscellaneousIncome(_userInfo, dateStart, dateEnd,
                this.chkIsConsolidated.Checked);

            _cashieringManager.SelectByDateStartEndCashReceiptsSummarizedBreakdownBankDeposit(_userInfo, dateStart, dateEnd, this.chkIsConsolidated.Checked);

            _cashieringManager.InitializeBreakDownBankDepositDetailsSummarizedListView(this.lsvBankDeposits, false);
            _cashieringManager.InitializeSummariedCashReceiptListView(this.lsvCashReceipsSummariezed, this.lblTotalCashReceipts, this.lblTotalDeposits, this.lblShortage);

            this.Cursor = Cursors.Arrow;
        }//------------------------------
        #endregion
    }
}
