using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace AdministratorServices
{
    partial class TransactionDone
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private AdministrtationLogic _administrationManager;
        private CommonExchange.TransactionLog _transactionLogInfo;
        DataTable _transactionDoneTable;
        #endregion

        #region Class Constructors
        public TransactionDone(CommonExchange.SysAccess userInfo, AdministrtationLogic adminitrationManager, CommonExchange.TransactionLog transactionLogInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _administrationManager = adminitrationManager;
            _transactionLogInfo = transactionLogInfo;

            this.Load += new EventHandler(ClassLoad);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnPrint.Click += new EventHandler(btnPrintClick);
        }       
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS TransactionDone EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            
            _transactionDoneTable = new DataTable("TransactionTable");
            _transactionDoneTable.Columns.Add("transaction", System.Type.GetType("System.String"));

            this.lblCompleteName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_transactionLogInfo.UserInfo.PersonInfo.LastName,
                _transactionLogInfo.UserInfo.PersonInfo.FirstName,
                _transactionLogInfo.UserInfo.PersonInfo.MiddleName);
            this.lblAccess.Text = _transactionLogInfo.AccessDescription;
            this.lblUserName.Text = _transactionLogInfo.UserInfo.UserName;
            this.lblTransactionDate.Text = _transactionLogInfo.TransactionDate;
            this.lblNetworkInformation.Text = _transactionLogInfo.NetworkInformation;

            String transactionDone = _transactionLogInfo.TransactionDone;

            transactionDone = transactionDone.Replace("]", "");

            String[] resultArray = transactionDone.Split('[');
            String outPut = String.Empty;

            foreach (String subString in resultArray)
            {
                outPut += subString + "\n";

                DataRow newRow = _transactionDoneTable.NewRow();

                newRow["transaction"] = subString;

                _transactionDoneTable.Rows.Add(newRow);
            }

            this.txtTransactionDone.Text = outPut;
        }//-----------------------------
        //###########################################END CLASS TransactionDone EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//---------------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnPrintClick(object sender, EventArgs e)
        {
            try
            {
                using (AdministratorServices.ClassAdministratorServices.CrystalReport.CrystalTransaction rptTransaction =
                    new AdministratorServices.ClassAdministratorServices.CrystalReport.CrystalTransaction())
                {
                    rptTransaction.Database.Tables["transaction_table"].SetDataSource(_transactionDoneTable);
                    rptTransaction.SetParameterValue("@complete_name", 
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_transactionLogInfo.UserInfo.PersonInfo.LastName,
                        _transactionLogInfo.UserInfo.PersonInfo.FirstName, _transactionLogInfo.UserInfo.PersonInfo.MiddleName));
                    rptTransaction.SetParameterValue("@user_name", _transactionLogInfo.UserInfo.UserName);
                    rptTransaction.SetParameterValue("@access", _transactionLogInfo.AccessDescription);
                    rptTransaction.SetParameterValue("@transaction_date", _transactionLogInfo.TransactionDate);
                    rptTransaction.SetParameterValue("@network_information", _transactionLogInfo.NetworkInformation);
                    rptTransaction.SetParameterValue("@print_Info", "Date/Time Printed: " + 
                        DateTime.Parse(_administrationManager.ServerDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_administrationManager.ServerDateTime).ToShortTimeString() + "      Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_userInfo.PersonInfo.LastName, _userInfo.PersonInfo.FirstName,
                        _userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptTransaction))
                    {
                        frmViewer.Text = "Transaction Log";
                        frmViewer.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Printing");
            }
        }//------------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################
        #endregion 
    }
}
