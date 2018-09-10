using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvCashieringManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvCashieringManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        /// <summary>
        /// This procedure inserts, and updates a student balance forwarded
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="balanceInfo"></param>
        public void InsertUpdateStudentBalanceForwarded(CommonExchange.SysAccess userInfo, CommonExchange.StudentBalanceForwarded balanceInfo) { }

        /// <summary>
        /// This procedure deletes a student balance forwarded
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="balanceInfo"></param>
        public void DeleteStudentBalanceForwarded(CommonExchange.SysAccess userInfo, CommonExchange.StudentBalanceForwarded balanceInfo) { }

        //this procedure inserts a new student payment
        public void InsertStudentPayments(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPayments) { }

        //this procedure updates a student payment
        public void UpdateStudentPayments(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPayments) { }

        //this procedure deletes a student payment
        public void DeleteStudentPayments(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPayments) { }

        //this procedure inserts a student discount
        public void InsertStudentDiscounts(CommonExchange.SysAccess userInfo, CommonExchange.StudentDiscounts studentDiscounts) { }

        //this procedure updates a student discount
        public void UpdateStudentDiscounts(CommonExchange.SysAccess userInfo, CommonExchange.StudentDiscounts studentDiscounts) { }

        //this procedure deletes a student discount
        public void DeleteStudentDiscounts(CommonExchange.SysAccess userInfo, CommonExchange.StudentDiscounts studentDiscounts) { }

        //this procedure inserts a student reimbursements
        public void InsertStudentReimbursements(CommonExchange.SysAccess userInfo, CommonExchange.StudentReimbursements studentReimbursements) { }

        //this procedure updates a student reimbursements
        public void UpdateStudentReimbursements(CommonExchange.SysAccess userInfo, CommonExchange.StudentReimbursements studentReimbursements) { }

        //this procedure deletes a student reimbursements
        public void DeleteStudentReimbursements(CommonExchange.SysAccess userInfo, CommonExchange.StudentReimbursements studentReimbursements) { }

        //this procedure inserts a student credit memo
        public void InsertStudentCreditMemo(CommonExchange.SysAccess userInfo, CommonExchange.StudentCreditMemo studentCreditMemo) { }

        //this procedure updates a student credit memo
        public void UpdateStudentCreditMemo(CommonExchange.SysAccess userInfo, CommonExchange.StudentCreditMemo studentCreditMemo) { }

        //this procedure delete a student credit memo
        public void DeleteStudentCreditMemo(CommonExchange.SysAccess userInfo, CommonExchange.StudentCreditMemo studentCreditMemo) { }

        //this procedure inserts a new student promissory note
        public void InsertStudentPromissoryNote(CommonExchange.SysAccess userInfo, CommonExchange.StudentPromissoryNote studentPromissoryNote) { }

        //this procedure updates a student promissory note
        public void UpdateStudentPromissoryNote(CommonExchange.SysAccess userInfo, CommonExchange.StudentPromissoryNote studentPromissoryNote) { }

        //this procedure deletes a student promissory note
        public void DeleteStudentPromissoryNote(CommonExchange.SysAccess userInfo, CommonExchange.StudentPromissoryNote studentPromissoryNote) { }

        //this procedure inserts a new cancelled receipt no
        public void InsertCancelledReceiptNo(CommonExchange.SysAccess userInfo, CommonExchange.CancelledReceiptNo receiptNoInfo) { }

        //this procedure updates a cancelled receipt no
        public void UpdateCancelledReceiptNo(CommonExchange.SysAccess userInfo, CommonExchange.CancelledReceiptNo receiptNoInfo) { }

        //this procedure deletes a cancelled receipt no
        public void DeleteCancelledReceiptNo(CommonExchange.SysAccess userInfo, CommonExchange.CancelledReceiptNo receiptNoInfo) { }

        /// <summary>
        /// This procedure inserts a miscellaneous income
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="miscellaneousIncomeInfo"></param>
        public void InsertMiscellaneousIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscIncomeInfo) { }

        /// <summary>
        /// This procedure updates a miscellaneous income
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="miscIncomeInfo"></param>
        public void UpdateMiscellaneousIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscIncomeInfo) { }

        /// <summary>
        /// This procedure deletes a miscellaneous income
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="miscIncomeInfo"></param>
        public void DeleteMiscellaneousIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscIncomeInfo) { }

        /// <summary>
        /// This procedure inserts a new breakdown bank deposit
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="breakdownDeposit"></param>
        public void InsertBreakdownBankDeposit(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakdownDeposit) { }

        /// <summary>
        /// This procedure updates a breakdown bank deposit
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="breakdownDeposit"></param>
        public void UpdateBreakdownBankDeposit(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakdownDeposit) { }

        /// <summary>
        /// This procedure deletes a breakdown bank deposit
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="breakdownDeposit"></param>
        public void DeleteBreakdownBankDeposit(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakdownDeposit) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this procedure returns the student promissory note by date start and end
        public DataTable SelectBySysIDStudentListDateStartEndStudentPromissoryNote(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd, String serverDateTime)
        {
            DataTable dbTable = new DataTable();
            
            return dbTable;

        } //------------------------------------------     

        //this procedure returns the payments and discounts by date start and end of the student
        public DataTable SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd, String serverDateTime)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------------------

        //this function gets the student information table query
        public DataTable SelectByDateStartEndCourseScholarshipListStudentDiscounts(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            String courseIdList, String scholarshipSysIdList, String serverDateTime)
        {
            DataTable dbTable = new DataTable();
            
            return dbTable;

        } //------------------------------

        //this function gets the student credit memo
        public DataTable SelectByDateStartEndStudentCreditMemo(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            Boolean isConsolidated, String serverDateTime)
        {
            DataTable dbTable = new DataTable();
            
            return dbTable;

        } //------------------------------

        //this function gets the cancelled receipt no
        public DataTable SelectCancelledReceiptNo(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

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
            DataTable dbTable = new DataTable();

            return dbTable;

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
            DataTable dbTable = new DataTable();

            return dbTable;
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
            DataTable dbTable = new DataTable();

            return dbTable;

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
            DataTable dbTable = new DataTable();

            return dbTable;
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
            DataTable dbTable = new DataTable();

            return dbTable;

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
            DataTable dbTable = new DataTable();

            return dbTable;
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
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-------------------------------------------

        //this function is used to determine if the student has a payment for a certain date start and date end
        public Boolean IsExistsPaymentBySysIDStudentDateStartEndStudentPayments(CommonExchange.SysAccess userInfo,
            String studentSysId, String dateStart, String dateEnd)
        {
            Boolean isExist = false;

            return isExist;
        } //------------------------------

        //this function is used to determine if the receipt no already exists
        public Boolean IsExistsReceiptNoStudentPayments(CommonExchange.SysAccess userInfo, Int64 paymentId, String receiptNo)
        {
            Boolean isExist = false;

            return isExist;
        } //------------------------------

        //this function is used to determine if the student has already a balance forwarded amount
        public Boolean IsExistsSysIDStudentStudentBalanceForwarded(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //------------------------------

        //this function is used to get data tables stored in one dataset used for cashiering manager
        public DataSet GetDataSetForCashiering(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
