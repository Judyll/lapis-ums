using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class CashReceiptQueryReportControl
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CashieringLogic _cashieringManager;

        private CommonExchange.ChartOfAccount _chartOfAccountInfo;

        private String _accountCreditSysIdList = String.Empty;
        #endregion

        #region Class Constructors
        public CashReceiptQueryReportControl(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;

            this.Load += new EventHandler(ClassLoad);
            this.btnSearchCreditEntry.Click += new EventHandler(btnSearchCreditEntryClick);
            this.lnkResetQuery.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkResetQueryLinkClicked);
            this.txtSearch.KeyPress += new KeyPressEventHandler(txtSearchKeyPress);
            this.btnShowResult.Click += new EventHandler(btnShowResultClick);
            this.btnPrint.Click += new EventHandler(btnPrintClick);
            this.btnClose.Click += new EventHandler(btnCloseClick);
        }      
        #endregion

        #region Class Event Void Procedures
        //###########################################Class CashReceiptQueryReportControl EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _chartOfAccountInfo = new CommonExchange.ChartOfAccount();

            this.txtSearch.Focus();
        }//---------------------------
        //###########################################END Class CashReceiptQueryReportControl EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################

        //###########################################BUTTON btnSearchCreditEntry EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnSearchCreditEntryClick(object sender, EventArgs e)
        {
            this.ShowSearchCreditEntry(false);
        }//-----------------------------------
        //###########################################END BUTTON btnSearchCreditEntry EVENTS#####################################################

        //###########################################LINKLABEL lnkResetQuery EVENTS#####################################################
        //event is raised when the control link is clicked
        private void lnkResetQueryLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.txtCreditEntry.Text = _accountCreditSysIdList = String.Empty;

            this.txtSearch.Text = String.Empty;
            this.txtSearch.Focus();

            this.dtpStart.Value = this.dtpEnd.Value = DateTime.Parse(_cashieringManager.ServerDateTime);

            this.chkIncludeDate.Checked = false;

            this.lsvCashReceiptQuery.Items.Clear();

            _cashieringManager.ClearCashReceiptQueryTable();
        }//------------------------
        //###########################################END LINKLABEL lnkResetQuery EVENTS#####################################################

        //###########################################TEXTBOX txtSearch EVENTS#####################################################
        //event is raised when the control key is pressed
        private void txtSearchKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.btnSearchCreditEntry.Focus();
            }
        }//----------------------------
        //###########################################END TEXTBOX txtSearch EVENTS#####################################################

        //###########################################BUTTON btnShowResult EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnShowResultClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            String accountCreditList = String.Empty;

            if (_accountCreditSysIdList.Length >= 2)
            {
                accountCreditList = _accountCreditSysIdList.ToString().Substring(0, _accountCreditSysIdList.Length - 2);
            }

            if (this.chkIncludeDate.Checked)
            {
                String dateStart, dateEnd = String.Empty;

                dateStart = this.dtpStart.Value.ToShortDateString() + " 12:00:00 AM";
                dateEnd = this.dtpEnd.Value.ToShortDateString() + " 11:59:59 PM";

                if (DateTime.Compare(DateTime.Parse(dateStart), DateTime.Parse(dateEnd)) < 0)
                {
                    _cashieringManager.InitializeCashReceiptQueryListView(this.lsvCashReceiptQuery, _userInfo, this.txtSearch.Text, dateStart, dateEnd, accountCreditList);
                }
                else
                {
                    MessageBox.Show("Date start must me greater than date end.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _cashieringManager.InitializeCashReceiptQueryListView(this.lsvCashReceiptQuery, _userInfo, this.txtSearch.Text, String.Empty, String.Empty, accountCreditList);
            }

            this.Cursor = Cursors.Arrow;
        }//----------------------------
        //###########################################END BUTTON btnShowResult EVENTS#####################################################

        //###########################################BUTTON btnPrint EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnPrintClick(object sender, EventArgs e)
        {
            String dateStart, dateEnd = String.Empty;

            dateStart = this.dtpStart.Value.ToShortDateString() + " 12:00:00 AM";
            dateEnd = this.dtpEnd.Value.ToShortDateString() + " 11:59:59 PM";

          
            this.Cursor = Cursors.WaitCursor;

            _cashieringManager.PrintCashReceiptQueryReport(_userInfo, dateStart, dateEnd, this.chkIncludeDate.Checked);

            this.Cursor = Cursors.Arrow;
         
        }//------------------------
        //###########################################END BUTTON btnPrint EVENTS#####################################################

        #endregion

        #region Programmer's Defined Void Procedures
        //this procedure will show the search credit Entry
        private void ShowSearchCreditEntry(Boolean allowMultipleInsert)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (ChartOfAccountSearchedOnTextBoxList frmSearch = new ChartOfAccountSearchedOnTextBoxList(_userInfo, _cashieringManager))
                {
                    frmSearch.PrimaryIndex = 4;
                    frmSearch.AdoptGridSize = false;
                    frmSearch.AllowMultipleInsert = allowMultipleInsert;
                    frmSearch.ShowAllowMultipleInsert(true);
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        _chartOfAccountInfo = _cashieringManager.GetChartOfAccountInformation(frmSearch.PrimaryId);

                        _accountCreditSysIdList += _chartOfAccountInfo.AccountSysId + ", ";

                        this.txtCreditEntry.Text += (!String.IsNullOrEmpty(_chartOfAccountInfo.AccountSysId) ? _chartOfAccountInfo.AccountName : String.Empty) + ", ";

                        _chartOfAccountInfo = new CommonExchange.ChartOfAccount();

                        allowMultipleInsert = frmSearch.AllowMultipleInsert;
                    }
                    else
                    {
                        allowMultipleInsert = false;
                    }
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }

            if (allowMultipleInsert)
            {
                this.ShowSearchCreditEntry(allowMultipleInsert);
            }
        }//----------------------------------
        #endregion
    }
}
