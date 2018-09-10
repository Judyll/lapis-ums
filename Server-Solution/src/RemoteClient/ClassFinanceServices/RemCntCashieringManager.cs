using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntCashieringManager : IDisposable
    {
        #region Constructor and Destructor
        public RemCntCashieringManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        /// <summary>
        /// This procedure inserts, and updates a student balance forwarded
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="balanceInfo"></param>
        public void InsertUpdateStudentBalanceForwarded(CommonExchange.SysAccess userInfo, CommonExchange.StudentBalanceForwarded balanceInfo) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertUpdateStudentBalanceForwarded");

            remServer.InsertUpdateStudentBalanceForwarded(userInfo, balanceInfo);
        } //--------------------------------------------

        /// <summary>
        /// This procedure deletes a student balance forwarded
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="balanceInfo"></param>
        public void DeleteStudentBalanceForwarded(CommonExchange.SysAccess userInfo, CommonExchange.StudentBalanceForwarded balanceInfo) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteStudentBalanceForwarded");

            remServer.DeleteStudentBalanceForwarded(userInfo, balanceInfo);
        } //--------------------------------------------

        //this procedure inserts a new student payment
        public void InsertStudentPayments(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPayments)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertStudentPayments");

            remServer.InsertStudentPayments(userInfo, studentPayments);
        } //---------------------------------------

        //this procedure updates a student payment
        public void UpdateStudentPayments(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPayments)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateStudentPayments");

            remServer.UpdateStudentPayments(userInfo, studentPayments);
        } //--------------------------------------

        //this procedure deletes a student payment
        public void DeleteStudentPayments(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPayments) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteStudentPayments");

            remServer.DeleteStudentPayments(userInfo, studentPayments);
        } //---------------------------------------

        //this procedure inserts a student discount
        public void InsertStudentDiscounts(CommonExchange.SysAccess userInfo, CommonExchange.StudentDiscounts studentDiscounts) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertStudentDiscounts");

            remServer.InsertStudentDiscounts(userInfo, studentDiscounts);
        } //---------------------------------

        //this procedure updates a student discount
        public void UpdateStudentDiscounts(CommonExchange.SysAccess userInfo, CommonExchange.StudentDiscounts studentDiscounts) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateStudentDiscounts");

            remServer.UpdateStudentDiscounts(userInfo, studentDiscounts);
        } //-------------------------------

        //this procedure deletes a student discount
        public void DeleteStudentDiscounts(CommonExchange.SysAccess userInfo, CommonExchange.StudentDiscounts studentDiscounts) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteStudentDiscounts");

            remServer.DeleteStudentDiscounts(userInfo, studentDiscounts);
        } //------------------------------------

        //this procedure inserts a student reimbursements
        public void InsertStudentReimbursements(CommonExchange.SysAccess userInfo, CommonExchange.StudentReimbursements studentReimbursements) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertStudentReimbursements");

            remServer.InsertStudentReimbursements(userInfo, studentReimbursements);
        } //-------------------------------------

        //this procedure updates a student reimbursements
        public void UpdateStudentReimbursements(CommonExchange.SysAccess userInfo, CommonExchange.StudentReimbursements studentReimbursements)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateStudentReimbursements");

            remServer.UpdateStudentReimbursements(userInfo, studentReimbursements);
        } //-------------------------------------

        //this procedure deletes a student reimbursements
        public void DeleteStudentReimbursements(CommonExchange.SysAccess userInfo, CommonExchange.StudentReimbursements studentReimbursements)
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteStudentReimbursements");

            remServer.DeleteStudentReimbursements(userInfo, studentReimbursements);
        } //-----------------------------------

        //this procedure inserts a student credit memo
        public void InsertStudentCreditMemo(CommonExchange.SysAccess userInfo, CommonExchange.StudentCreditMemo studentCreditMemo)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertStudentCreditMemo");

            remServer.InsertStudentCreditMemo(userInfo, studentCreditMemo);
        } //-----------------------------------

        //this procedure update a student credit memo
        public void UpdateStudentCreditMemo(CommonExchange.SysAccess userInfo, CommonExchange.StudentCreditMemo studentCreditMemo)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateStudentCreditMemo");

            remServer.UpdateStudentCreditMemo(userInfo, studentCreditMemo);
        } //-----------------------------------

        //this procedure delete a student credit memo
        public void DeleteStudentCreditMemo(CommonExchange.SysAccess userInfo, CommonExchange.StudentCreditMemo studentCreditMemo)
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteStudentCreditMemo");

            remServer.DeleteStudentCreditMemo(userInfo, studentCreditMemo);
        } //-----------------------------------

        //this procedure inserts a new student promissory note
        public void InsertStudentPromissoryNote(CommonExchange.SysAccess userInfo, CommonExchange.StudentPromissoryNote studentPromissoryNote)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertStudentPromissoryNote");

            remServer.InsertStudentPromissoryNote(userInfo, studentPromissoryNote);
        } //-----------------------------------    

        //this procedure updates a student promissory note
        public void UpdateStudentPromissoryNote(CommonExchange.SysAccess userInfo, CommonExchange.StudentPromissoryNote studentPromissoryNote)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateStudentPromissoryNote");

            remServer.UpdateStudentPromissoryNote(userInfo, studentPromissoryNote);
        } //-----------------------------------   

        //this procedure deletes a student promissory note
        public void DeleteStudentPromissoryNote(CommonExchange.SysAccess userInfo, CommonExchange.StudentPromissoryNote studentPromissoryNote)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteStudentPromissoryNote");

            remServer.DeleteStudentPromissoryNote(userInfo, studentPromissoryNote);
        } //----------------------------------- 

        //this procedure inserts a new cancelled receipt no
        public void InsertCancelledReceiptNo(CommonExchange.SysAccess userInfo, CommonExchange.CancelledReceiptNo receiptNoInfo) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertCancelledReceiptNo");

            remServer.InsertCancelledReceiptNo(userInfo, receiptNoInfo);
        } //-------------------------------------------

        //this procedure updates a cancelled receipt no
        public void UpdateCancelledReceiptNo(CommonExchange.SysAccess userInfo, CommonExchange.CancelledReceiptNo receiptNoInfo) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateCancelledReceiptNo");

            remServer.UpdateCancelledReceiptNo(userInfo, receiptNoInfo);
        } //---------------------------------------------

        //this procedure deletes a cancelled receipt no
        public void DeleteCancelledReceiptNo(CommonExchange.SysAccess userInfo, CommonExchange.CancelledReceiptNo receiptNoInfo) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteCancelledReceiptNo");

            remServer.DeleteCancelledReceiptNo(userInfo, receiptNoInfo);
        } //-----------------------------------------------

        /// <summary>
        /// This procedure inserts a miscellaneous income
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="miscellaneousIncomeInfo"></param>
        public void InsertMiscellaneousIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscIncomeInfo) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertMiscellaneousIncome");

            remServer.InsertMiscellaneousIncome(userInfo, miscIncomeInfo);
        } //-------------------------------------------------

        /// <summary>
        /// This procedure updates a miscellaneous income
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="miscIncomeInfo"></param>
        public void UpdateMiscellaneousIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscIncomeInfo) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateMiscellaneousIncome");

            remServer.UpdateMiscellaneousIncome(userInfo, miscIncomeInfo);
        } //-------------------------------------

        /// <summary>
        /// This procedure deletes a miscellaneous income
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="miscIncomeInfo"></param>
        public void DeleteMiscellaneousIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscIncomeInfo) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteMiscellaneousIncome");

            remServer.DeleteMiscellaneousIncome(userInfo, miscIncomeInfo);
        } //---------------------------------------

        /// <summary>
        /// This procedure inserts a new breakdown bank deposit
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="breakdownDeposit"></param>
        public void InsertBreakdownBankDeposit(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakdownDeposit) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertBreakdownBankDeposit");

            remServer.InsertBreakdownBankDeposit(userInfo, breakdownDeposit);
        } //------------------------------------------

        /// <summary>
        /// This procedure updates a breakdown bank deposit
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="breakdownDeposit"></param>
        public void UpdateBreakdownBankDeposit(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakdownDeposit) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateBreakdownBankDeposit");

            remServer.UpdateBreakdownBankDeposit(userInfo, breakdownDeposit);
        } //-----------------------------------------------

        /// <summary>
        /// This procedure deletes a breakdown bank deposit
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="breakdownDeposit"></param>
        public void DeleteBreakdownBankDeposit(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakdownDeposit) 
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteBreakdownBankDeposit");

            remServer.DeleteBreakdownBankDeposit(userInfo, breakdownDeposit);
        } //-------------------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this procedure returns the student promissory note by date start and end
        public DataTable SelectBySysIDStudentListDateStartEndStudentPromissoryNote(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd, String serverDateTime)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentListDateStartEndStudentPromissoryNote");

            return remServer.SelectBySysIDStudentListDateStartEndStudentPromissoryNote(userInfo, studentSysIdList,
                dateStart, dateEnd, serverDateTime);

        } //------------------------------------------     

        //this procedure returns the payments and discounts by date start and end of the student
        public DataTable SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd, String serverDateTime)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager), 
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement");

            return remServer.SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement(userInfo, studentSysIdList, 
                dateStart, dateEnd, serverDateTime);
        } //-------------------------------------------  

        //this function gets the student information table query
        public DataTable SelectByDateStartEndCourseScholarshipListStudentDiscounts(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            String courseIdList, String scholarshipSysIdList, String serverDateTime)
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndCourseScholarshipListStudentDiscounts");

            return remServer.SelectByDateStartEndCourseScholarshipListStudentDiscounts(userInfo, dateStart, dateEnd, courseIdList, 
                scholarshipSysIdList, serverDateTime);
        } //-------------------------------------------  

        //this function gets the student credit memo
        public DataTable SelectByDateStartEndStudentCreditMemo(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            Boolean isConsolidated, String serverDateTime)
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndStudentCreditMemo");

            return remServer.SelectByDateStartEndStudentCreditMemo(userInfo, dateStart, dateEnd, isConsolidated, serverDateTime);

        } //------------------------------

        //this function gets the cancelled receipt no
        public DataTable SelectCancelledReceiptNo(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectCancelledReceiptNo");

            return remServer.SelectCancelledReceiptNo(userInfo, serverDateTime);
        } //------------------------------

        /// <summary>
        /// This function returns the miscellaneous income by query string and date start and date end
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="queryString"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public DataTable SelectByQueryStringDateStartEndMiscellaneousIncome(CommonExchange.SysAccess userInfo, String queryString,
            String dateStart, String dateEnd, String serverDateTime)
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByQueryStringDateStartEndMiscellaneousIncome");

            return remServer.SelectByQueryStringDateStartEndMiscellaneousIncome(userInfo, queryString, dateStart, dateEnd, serverDateTime);

        } //--------------------------------------------

        /// <summary>
        /// This function returns the cash receipts detailed
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="isConsolidated"></param>
        /// <returns></returns>
        public DataTable SelectByDateStartEndCashReceiptsDetailedStudentPaymentMiscellaneousIncome(CommonExchange.SysAccess userInfo,
            String dateStart, String dateEnd, Boolean isConsolidated, String serverDateTime)
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndCashReceiptsDetailedStudentPaymentMiscellaneousIncome");

            return remServer.SelectByDateStartEndCashReceiptsDetailedStudentPaymentMiscellaneousIncome(userInfo, 
                dateStart, dateEnd, isConsolidated, serverDateTime);
        } //-------------------------------------------

        /// <summary>
        /// This function returns the cash receipts summarized table
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public DataTable SelectByDateStartEndCashReceiptsSummarizedStudentPaymentMiscellaneousIncome(CommonExchange.SysAccess userInfo,
            String dateStart, String dateEnd, Boolean isConsolidated)
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndCashReceiptsSummarizedStudentPaymentMiscellaneousIncome");

            return remServer.SelectByDateStartEndCashReceiptsSummarizedStudentPaymentMiscellaneousIncome(userInfo,
                dateStart, dateEnd, isConsolidated);

        } //------------------------------

        /// <summary>
        /// This function returns the breakdown bank deposit for cash receipts detailed
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="isConsolidated"></param>
        /// <param name="serverDateTime"></param>
        /// <returns></returns>
        public DataTable SelectByDateStartEndCashReceiptsDetailedBreakdownBankDeposit(CommonExchange.SysAccess userInfo,
            String dateStart, String dateEnd, Boolean isConsolidated, String serverDateTime)
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndCashReceiptsDetailedBreakdownBankDeposit");

            return remServer.SelectByDateStartEndCashReceiptsDetailedBreakdownBankDeposit(userInfo,
                dateStart, dateEnd, isConsolidated, serverDateTime);
        } //-------------------------------------------

        /// <summary>
        /// This function returns the breakdown bank deposit for cash receipts summarized table
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public DataTable SelectByDateStartEndCashReceiptsSummarizedBreakdownBankDeposit(CommonExchange.SysAccess userInfo,
            String dateStart, String dateEnd, Boolean isConsolidated)
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndCashReceiptsSummarizedBreakdownBankDeposit");

            return remServer.SelectByDateStartEndCashReceiptsSummarizedBreakdownBankDeposit(userInfo,
                dateStart, dateEnd, isConsolidated);

        } //------------------------------

        /// <summary>
        /// This function returns the cash receipts query
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="isConsolidated"></param>
        /// <returns></returns>
        public DataTable SelectByQueryStringDateStartEndCashReceiptsQueryStudentPaymentMiscellaneousIncome(CommonExchange.SysAccess userInfo, String queryString,
            String dateStart, String dateEnd, String accountCreditSysIdList, String serverDateTime)
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByQueryStringDateStartEndCashReceiptsQueryStudentPaymentMiscellaneousIncome");

            return remServer.SelectByQueryStringDateStartEndCashReceiptsQueryStudentPaymentMiscellaneousIncome(userInfo, queryString,
                dateStart, dateEnd, accountCreditSysIdList, serverDateTime);
        } //-------------------------------------------

        /// <summary>
        /// This function returns the cash discounts
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="isConsolidated"></param>
        /// <returns></returns>
        public DataTable SelectByDateStartEndCashDiscountsStudentPaymentMiscellaneousIncome(CommonExchange.SysAccess userInfo,
            String dateStart, String dateEnd, Boolean isConsolidated, String serverDateTime)
        {
            RemoteServerLib.RemSrvCashieringManager remServer =
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndCashDiscountsStudentPaymentMiscellaneousIncome");

            return remServer.SelectByDateStartEndCashDiscountsStudentPaymentMiscellaneousIncome(userInfo, dateStart, dateEnd,
                isConsolidated, serverDateTime);
        } //-------------------------------------------

        //this function is used to determine if the student has a payment for a certain date start and date end
        public Boolean IsExistsPaymentBySysIDStudentDateStartEndStudentPayments(CommonExchange.SysAccess userInfo,
            String studentSysId, String dateStart, String dateEnd)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                   TcpRemoteServer.GetRemoteServerTcp() + "IsExistsPaymentBySysIDStudentDateStartEndStudentPayments");

            return remServer.IsExistsPaymentBySysIDStudentDateStartEndStudentPayments(userInfo, studentSysId, dateStart, dateEnd);
        } //----------------------------------------

        //this function is used to determine if the receipt no already exists
        public Boolean IsExistsReceiptNoStudentPayments(CommonExchange.SysAccess userInfo, Int64 paymentId, String receiptNo)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsExistsReceiptNoStudentPayments");

            return remServer.IsExistsReceiptNoStudentPayments(userInfo, paymentId, receiptNo);
        } //----------------------------------------

        //this function is used to determine if the student has already a balance forwarded amount
        public Boolean IsExistsSysIDStudentStudentBalanceForwarded(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsExistsSysIDStudentStudentBalanceForwarded");

            return remServer.IsExistsSysIDStudentStudentBalanceForwarded(userInfo, studentSysId);
        } //------------------------------

        //this function is used to get data tables stored in one dataset used for cashiering manager
        public DataSet GetDataSetForCashiering(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            RemoteServerLib.RemSrvCashieringManager remServer = 
                (RemoteServerLib.RemSrvCashieringManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvCashieringManager),
                TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForCashiering");

            return remServer.GetDataSetForCashiering(userInfo, serverDateTime);
        } //----------------------------------

        #endregion
    }
}
