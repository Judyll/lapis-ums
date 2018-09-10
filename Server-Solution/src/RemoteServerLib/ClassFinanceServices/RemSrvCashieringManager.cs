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
        public void InsertUpdateStudentBalanceForwarded(CommonExchange.SysAccess userInfo, CommonExchange.StudentBalanceForwarded balanceInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertUpdateStudentBalanceForwarded";

                    sqlComm.Parameters.Add("@balance_id", SqlDbType.BigInt).Value = balanceInfo.BalanceId;
                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = balanceInfo.StudentInfo.StudentSysId;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = balanceInfo.Amount;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------  

        /// <summary>
        /// This procedure deletes a student balance forwarded
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="balanceInfo"></param>
        public void DeleteStudentBalanceForwarded(CommonExchange.SysAccess userInfo, CommonExchange.StudentBalanceForwarded balanceInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteStudentBalanceForwarded";

                    sqlComm.Parameters.Add("@balance_id", SqlDbType.BigInt).Value = balanceInfo.BalanceId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------  

        //this procedure inserts a new student payment
        public void InsertStudentPayments(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPayments)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertStudentPayments";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentPayments.StudentInfo.StudentSysId;
                    sqlComm.Parameters.Add("@payment_date", SqlDbType.DateTime).Value = DateTime.Parse(studentPayments.ReflectedDate);
                    sqlComm.Parameters.Add("@receipt_date", SqlDbType.DateTime).Value = DateTime.Parse(studentPayments.ReceiptDate);
                    sqlComm.Parameters.Add("@receipt_no", SqlDbType.VarChar).Value = studentPayments.ReceiptNo;
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = studentPayments.Remarks;
                    sqlComm.Parameters.Add("@is_downpayment", SqlDbType.Bit).Value = studentPayments.IsDownpayment;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = studentPayments.Amount;

                    if (studentPayments.DiscountAmount >= 0)
                    {
                        sqlComm.Parameters.Add("@discount_amount", SqlDbType.Decimal).Value = studentPayments.DiscountAmount;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@discount_amount", SqlDbType.Decimal).Value = DBNull.Value;
                    }

                    if (studentPayments.AmountTendered >= 0)
                    {
                        sqlComm.Parameters.Add("@amount_tendered", SqlDbType.Decimal).Value = studentPayments.AmountTendered;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@amount_tendered", SqlDbType.Decimal).Value = DBNull.Value;
                    }

                    sqlComm.Parameters.Add("@bank", SqlDbType.VarChar).Value = studentPayments.Bank;
                    sqlComm.Parameters.Add("@check_no", SqlDbType.VarChar).Value = studentPayments.CheckNo;
                    sqlComm.Parameters.Add("@sysid_account_credit", SqlDbType.VarChar).Value = studentPayments.AccountCreditInfo.AccountSysId;
                    sqlComm.Parameters.Add("@is_miscellaneous_income", SqlDbType.Bit).Value = studentPayments.IsMiscellaneousIncome;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------    

        //this procedure updates a student payment
        public void UpdateStudentPayments(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPayments)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateStudentPayments";

                    sqlComm.Parameters.Add("@payment_id", SqlDbType.BigInt).Value = studentPayments.PaymentId;
                    sqlComm.Parameters.Add("@payment_date", SqlDbType.DateTime).Value = DateTime.Parse(studentPayments.ReflectedDate);
                    sqlComm.Parameters.Add("@receipt_date", SqlDbType.DateTime).Value = DateTime.Parse(studentPayments.ReceiptDate);
                    sqlComm.Parameters.Add("@receipt_no", SqlDbType.VarChar).Value = studentPayments.ReceiptNo;
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = studentPayments.Remarks;
                    sqlComm.Parameters.Add("@is_downpayment", SqlDbType.Bit).Value = studentPayments.IsDownpayment;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = studentPayments.Amount;

                    if (studentPayments.DiscountAmount >= 0)
                    {
                        sqlComm.Parameters.Add("@discount_amount", SqlDbType.Decimal).Value = studentPayments.DiscountAmount;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@discount_amount", SqlDbType.Decimal).Value = DBNull.Value;
                    }

                    if (studentPayments.AmountTendered >= 0)
                    {
                        sqlComm.Parameters.Add("@amount_tendered", SqlDbType.Decimal).Value = studentPayments.AmountTendered;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@amount_tendered", SqlDbType.Decimal).Value = DBNull.Value;
                    }

                    sqlComm.Parameters.Add("@bank", SqlDbType.VarChar).Value = studentPayments.Bank;
                    sqlComm.Parameters.Add("@check_no", SqlDbType.VarChar).Value = studentPayments.CheckNo;
                    sqlComm.Parameters.Add("@sysid_account_credit", SqlDbType.VarChar).Value = studentPayments.AccountCreditInfo.AccountSysId;
                    sqlComm.Parameters.Add("@is_miscellaneous_income", SqlDbType.Bit).Value = studentPayments.IsMiscellaneousIncome;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------  

        //this procedure deletes a student payment
        public void DeleteStudentPayments(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPayments)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteStudentPayments";

                    sqlComm.Parameters.Add("@payment_id", SqlDbType.BigInt).Value = studentPayments.PaymentId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------  

        //this procedure inserts a student discount
        public void InsertStudentDiscounts(CommonExchange.SysAccess userInfo, CommonExchange.StudentDiscounts studentDiscounts)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertStudentDiscounts";

                    sqlComm.Parameters.Add("@sysid_studentscholarship", SqlDbType.VarChar).Value = studentDiscounts.StudentScholarshipInfo.StudentScholarshipSysId;
                    sqlComm.Parameters.Add("@discount_date", SqlDbType.DateTime).Value = DateTime.Parse(studentDiscounts.ReflectedDate);
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = studentDiscounts.Remarks;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = studentDiscounts.Amount;
                    sqlComm.Parameters.Add("@is_downpayment", SqlDbType.Bit).Value = studentDiscounts.IsDownpayment;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure updates a student discount
        public void UpdateStudentDiscounts(CommonExchange.SysAccess userInfo, CommonExchange.StudentDiscounts studentDiscounts)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateStudentDiscounts";

                    sqlComm.Parameters.Add("@discount_id", SqlDbType.BigInt).Value = studentDiscounts.DiscountId;
                    sqlComm.Parameters.Add("@discount_date", SqlDbType.DateTime).Value = DateTime.Parse(studentDiscounts.ReflectedDate);
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = studentDiscounts.Remarks;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = studentDiscounts.Amount;
                    sqlComm.Parameters.Add("@is_downpayment", SqlDbType.Bit).Value = studentDiscounts.IsDownpayment;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure deletes a student discount
        public void DeleteStudentDiscounts(CommonExchange.SysAccess userInfo, CommonExchange.StudentDiscounts studentDiscounts)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteStudentDiscounts";

                    sqlComm.Parameters.Add("@discount_id", SqlDbType.BigInt).Value = studentDiscounts.DiscountId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure inserts a student reimbursements
        public void InsertStudentReimbursements(CommonExchange.SysAccess userInfo, CommonExchange.StudentReimbursements studentReimbursements)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertStudentReimbursements";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentReimbursements.StudentInfo.StudentSysId;
                    sqlComm.Parameters.Add("@reimbursement_date", SqlDbType.DateTime).Value = DateTime.Parse(studentReimbursements.ReflectedDate);
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = studentReimbursements.Remarks;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = studentReimbursements.Amount;
                    sqlComm.Parameters.Add("@is_downpayment", SqlDbType.Bit).Value = studentReimbursements.IsDownpayment;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure updates a student reimbursements
        public void UpdateStudentReimbursements(CommonExchange.SysAccess userInfo, CommonExchange.StudentReimbursements studentReimbursements)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateStudentReimbursements";

                    sqlComm.Parameters.Add("@reimbursement_id", SqlDbType.BigInt).Value = studentReimbursements.ReimbursementId;
                    sqlComm.Parameters.Add("@reimbursement_date", SqlDbType.DateTime).Value = DateTime.Parse(studentReimbursements.ReflectedDate);
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = studentReimbursements.Remarks;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = studentReimbursements.Amount;
                    sqlComm.Parameters.Add("@is_downpayment", SqlDbType.Bit).Value = studentReimbursements.IsDownpayment;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure deletes a student reimbursements
        public void DeleteStudentReimbursements(CommonExchange.SysAccess userInfo, CommonExchange.StudentReimbursements studentReimbursements)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteStudentReimbursements";

                    sqlComm.Parameters.Add("@reimbursement_id", SqlDbType.BigInt).Value = studentReimbursements.ReimbursementId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure inserts a student credit memo
        public void InsertStudentCreditMemo(CommonExchange.SysAccess userInfo, CommonExchange.StudentCreditMemo studentCreditMemo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertStudentCreditMemo";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentCreditMemo.StudentInfo.StudentSysId;
                    sqlComm.Parameters.Add("@memo_date", SqlDbType.DateTime).Value = DateTime.Parse(studentCreditMemo.ReflectedDate);
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = studentCreditMemo.Remarks;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = studentCreditMemo.Amount;
                    sqlComm.Parameters.Add("@is_downpayment", SqlDbType.Bit).Value = studentCreditMemo.IsDownpayment;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure updates a student credit memo
        public void UpdateStudentCreditMemo(CommonExchange.SysAccess userInfo, CommonExchange.StudentCreditMemo studentCreditMemo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateStudentCreditMemo";

                    sqlComm.Parameters.Add("@memo_id", SqlDbType.BigInt).Value = studentCreditMemo.MemoId;
                    sqlComm.Parameters.Add("@memo_date", SqlDbType.DateTime).Value = DateTime.Parse(studentCreditMemo.ReflectedDate);
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = studentCreditMemo.Remarks;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = studentCreditMemo.Amount;
                    sqlComm.Parameters.Add("@is_downpayment", SqlDbType.Bit).Value = studentCreditMemo.IsDownpayment;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure delete a student credit memo
        public void DeleteStudentCreditMemo(CommonExchange.SysAccess userInfo, CommonExchange.StudentCreditMemo studentCreditMemo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteStudentCreditMemo";

                    sqlComm.Parameters.Add("@memo_id", SqlDbType.BigInt).Value = studentCreditMemo.MemoId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure inserts a new student promissory note
        public void InsertStudentPromissoryNote(CommonExchange.SysAccess userInfo, CommonExchange.StudentPromissoryNote studentPromissoryNote)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertStudentPromissoryNote";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentPromissoryNote.StudentInfo.StudentSysId;
                    sqlComm.Parameters.Add("@note_received_date", SqlDbType.DateTime).Value = DateTime.Parse(studentPromissoryNote.ReflectedDate);
                    sqlComm.Parameters.Add("@reference_no", SqlDbType.VarChar).Value = studentPromissoryNote.ReferenceNo;
                    sqlComm.Parameters.Add("@promissory_note", SqlDbType.VarChar).Value = studentPromissoryNote.PromissoryNote;
                    sqlComm.Parameters.Add("@is_downpayment", SqlDbType.Bit).Value = studentPromissoryNote.IsDownpayment;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------    

        //this procedure updates a student promissory note
        public void UpdateStudentPromissoryNote(CommonExchange.SysAccess userInfo, CommonExchange.StudentPromissoryNote studentPromissoryNote)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateStudentPromissoryNote";

                    sqlComm.Parameters.Add("@promissory_note_id", SqlDbType.BigInt).Value = studentPromissoryNote.PromissoryNoteId;
                    sqlComm.Parameters.Add("@note_received_date", SqlDbType.DateTime).Value = DateTime.Parse(studentPromissoryNote.ReflectedDate);
                    sqlComm.Parameters.Add("@reference_no", SqlDbType.VarChar).Value = studentPromissoryNote.ReferenceNo;
                    sqlComm.Parameters.Add("@promissory_note", SqlDbType.VarChar).Value = studentPromissoryNote.PromissoryNote;
                    sqlComm.Parameters.Add("@is_downpayment", SqlDbType.Bit).Value = studentPromissoryNote.IsDownpayment;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------   

        //this procedure deletes a student promissory note
        public void DeleteStudentPromissoryNote(CommonExchange.SysAccess userInfo, CommonExchange.StudentPromissoryNote studentPromissoryNote)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteStudentPromissoryNote";

                    sqlComm.Parameters.Add("@promissory_note_id", SqlDbType.BigInt).Value = studentPromissoryNote.PromissoryNoteId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //----------------------------------- 

        //this procedure inserts a new cancelled receipt no
        public void InsertCancelledReceiptNo(CommonExchange.SysAccess userInfo, CommonExchange.CancelledReceiptNo receiptNoInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertCancelledReceiptNo";

                    sqlComm.Parameters.Add("@receipt_no", SqlDbType.VarChar).Value = receiptNoInfo.ReceiptNo;
                    sqlComm.Parameters.Add("@receipt_date", SqlDbType.DateTime).Value = DateTime.Parse(receiptNoInfo.ReceiptDate);
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = receiptNoInfo.Remarks;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------    

        //this procedure updates a cancelled receipt no
        public void UpdateCancelledReceiptNo(CommonExchange.SysAccess userInfo, CommonExchange.CancelledReceiptNo receiptNoInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateCancelledReceiptNo";

                    sqlComm.Parameters.Add("@receipt_no", SqlDbType.VarChar).Value = receiptNoInfo.ReceiptNo;
                    sqlComm.Parameters.Add("@receipt_date", SqlDbType.DateTime).Value = DateTime.Parse(receiptNoInfo.ReceiptDate);
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = receiptNoInfo.Remarks;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------    

        //this procedure deletes a cancelled receipt no
        public void DeleteCancelledReceiptNo(CommonExchange.SysAccess userInfo, CommonExchange.CancelledReceiptNo receiptNoInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteCancelledReceiptNo";

                    sqlComm.Parameters.Add("@receipt_no", SqlDbType.VarChar).Value = receiptNoInfo.ReceiptNo;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------   

        /// <summary>
        /// This procedure inserts a miscellaneous income
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="miscellaneousIncomeInfo"></param>
        public void InsertMiscellaneousIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscIncomeInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertMiscellaneousIncome";

                    sqlComm.Parameters.Add("@received_from", SqlDbType.VarChar).Value = miscIncomeInfo.ReceivedFrom;

                    if (String.IsNullOrEmpty(miscIncomeInfo.StudentInfo.StudentSysId))
                    {
                        sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = miscIncomeInfo.StudentInfo.StudentSysId;
                    }

                    if (String.IsNullOrEmpty(miscIncomeInfo.EmployeeInfo.EmployeeSysId))
                    {
                        sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = miscIncomeInfo.EmployeeInfo.EmployeeSysId;
                    }

                    sqlComm.Parameters.Add("@payment_date", SqlDbType.DateTime).Value = DateTime.Parse(miscIncomeInfo.ReflectedDate);
                    sqlComm.Parameters.Add("@receipt_date", SqlDbType.DateTime).Value = DateTime.Parse(miscIncomeInfo.ReceiptDate);
                    sqlComm.Parameters.Add("@receipt_no", SqlDbType.VarChar).Value = miscIncomeInfo.ReceiptNo;
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = miscIncomeInfo.Remarks;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = miscIncomeInfo.Amount;

                    if (miscIncomeInfo.DiscountAmount >= 0)
                    {
                        sqlComm.Parameters.Add("@discount_amount", SqlDbType.Decimal).Value = miscIncomeInfo.DiscountAmount;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@discount_amount", SqlDbType.Decimal).Value = DBNull.Value;
                    }

                    if (miscIncomeInfo.AmountTendered >= 0)
                    {
                        sqlComm.Parameters.Add("@amount_tendered", SqlDbType.Decimal).Value = miscIncomeInfo.AmountTendered;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@amount_tendered", SqlDbType.Decimal).Value = DBNull.Value;
                    }

                    sqlComm.Parameters.Add("@bank", SqlDbType.VarChar).Value = miscIncomeInfo.Bank;
                    sqlComm.Parameters.Add("@check_no", SqlDbType.VarChar).Value = miscIncomeInfo.CheckNo;
                    sqlComm.Parameters.Add("@sysid_account_credit", SqlDbType.VarChar).Value = miscIncomeInfo.AccountCreditInfo.AccountSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------    

        /// <summary>
        /// This procedure updates a miscellaneous income
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="miscIncomeInfo"></param>
        public void UpdateMiscellaneousIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscIncomeInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateMiscellaneousIncome";

                    sqlComm.Parameters.Add("@payment_id", SqlDbType.BigInt).Value = miscIncomeInfo.PaymentId;
                    sqlComm.Parameters.Add("@received_from", SqlDbType.VarChar).Value = miscIncomeInfo.ReceivedFrom;

                    if (String.IsNullOrEmpty(miscIncomeInfo.StudentInfo.StudentSysId))
                    {
                        sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = miscIncomeInfo.StudentInfo.StudentSysId;
                    }

                    if (String.IsNullOrEmpty(miscIncomeInfo.EmployeeInfo.EmployeeSysId))
                    {
                        sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = miscIncomeInfo.EmployeeInfo.EmployeeSysId;
                    }

                    sqlComm.Parameters.Add("@payment_date", SqlDbType.DateTime).Value = DateTime.Parse(miscIncomeInfo.ReflectedDate);
                    sqlComm.Parameters.Add("@receipt_date", SqlDbType.DateTime).Value = DateTime.Parse(miscIncomeInfo.ReceiptDate);
                    sqlComm.Parameters.Add("@receipt_no", SqlDbType.VarChar).Value = miscIncomeInfo.ReceiptNo;
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = miscIncomeInfo.Remarks;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = miscIncomeInfo.Amount;

                    if (miscIncomeInfo.DiscountAmount >= 0)
                    {
                        sqlComm.Parameters.Add("@discount_amount", SqlDbType.Decimal).Value = miscIncomeInfo.DiscountAmount;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@discount_amount", SqlDbType.Decimal).Value = DBNull.Value;
                    }

                    if (miscIncomeInfo.AmountTendered >= 0)
                    {
                        sqlComm.Parameters.Add("@amount_tendered", SqlDbType.Decimal).Value = miscIncomeInfo.AmountTendered;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@amount_tendered", SqlDbType.Decimal).Value = DBNull.Value;
                    }

                    sqlComm.Parameters.Add("@bank", SqlDbType.VarChar).Value = miscIncomeInfo.Bank;
                    sqlComm.Parameters.Add("@check_no", SqlDbType.VarChar).Value = miscIncomeInfo.CheckNo;
                    sqlComm.Parameters.Add("@sysid_account_credit", SqlDbType.VarChar).Value = miscIncomeInfo.AccountCreditInfo.AccountSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------  

        /// <summary>
        /// This procedure deletes a miscellaneous income
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="miscIncomeInfo"></param>
        public void DeleteMiscellaneousIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscIncomeInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteMiscellaneousIncome";

                    sqlComm.Parameters.Add("@payment_id", SqlDbType.BigInt).Value = miscIncomeInfo.PaymentId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------  

        /// <summary>
        /// This procedure inserts a new breakdown bank deposit
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="breakdownDeposit"></param>
        public void InsertBreakdownBankDeposit(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakdownDeposit)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertBreakdownBankDeposit";

                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(breakdownDeposit.DateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(breakdownDeposit.DateEnd);
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = breakdownDeposit.Amount;
                    sqlComm.Parameters.Add("@sysid_account", SqlDbType.VarChar).Value = breakdownDeposit.AccountInfo.AccountSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------    

        /// <summary>
        /// This procedure updates a breakdown bank deposit
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="breakdownDeposit"></param>
        public void UpdateBreakdownBankDeposit(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakdownDeposit)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateBreakdownBankDeposit";

                    sqlComm.Parameters.Add("@breakdown_id", SqlDbType.BigInt).Value = breakdownDeposit.BreakdownId;
                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(breakdownDeposit.DateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(breakdownDeposit.DateEnd);
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = breakdownDeposit.Amount;
                    sqlComm.Parameters.Add("@sysid_account", SqlDbType.VarChar).Value = breakdownDeposit.AccountInfo.AccountSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------  

        /// <summary>
        /// This procedure deletes a breakdown bank deposit
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="breakdownDeposit"></param>
        public void DeleteBreakdownBankDeposit(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakdownDeposit)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteBreakdownBankDeposit";

                    sqlComm.Parameters.Add("@breakdown_id", SqlDbType.BigInt).Value = breakdownDeposit.BreakdownId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------  

        #endregion

        #region Programmer-Defined Function Procedures

        //this procedure returns the student promissory note by date start and end
        public DataTable SelectBySysIDStudentListDateStartEndStudentPromissoryNote(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd, String serverDateTime)
        {
            DataTable dbTable = new DataTable("PromissoryNoteBySysIDStudentListByDateStartEndTable");
            dbTable.Columns.Add("promissory_note_id", System.Type.GetType("System.Int64"));
            dbTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            dbTable.Columns.Add("reflected_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("received_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("reference_no", System.Type.GetType("System.String"));
            dbTable.Columns.Add("promissory_note", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_downpayment", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_included_in_post", System.Type.GetType("System.Boolean"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentListDateStartEndStudentPromissoryNote";

                    sqlComm.Parameters.Add("@sysid_student_list", SqlDbType.NVarChar).Value = studentSysIdList;
                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(dateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(dateEnd);

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["promissory_note_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "promissory_note_id", Int64.Parse("0"));
                                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student", String.Empty);
                                newRow["reflected_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "reflected_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["received_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["reference_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "reference_no", String.Empty);
                                newRow["promissory_note"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "promissory_note", String.Empty);
                                newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_downpayment", false);
                                newRow["is_included_in_post"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_included_in_post", false);
                                
                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }

                    dbTable.AcceptChanges();

                }
            }

            return dbTable;

        } //------------------------------------------     

        //this procedure returns the payments and discounts by date start and end of the student
        public DataTable SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd, String serverDateTime)
        {
            DataTable dbTable = new DataTable("PaymentsDiscountsBySysIDStudentListByDateStartEndTable");
            dbTable.Columns.Add("payment_discount_reimbursement_id", System.Type.GetType("System.Int64"));
            dbTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            dbTable.Columns.Add("reflected_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("receipt_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("received_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("receipt_no", System.Type.GetType("System.String"));
            dbTable.Columns.Add("remarks_discount_reimbursement_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_downpayment", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("discount_amount", System.Type.GetType("System.Decimal"));
			dbTable.Columns.Add("amount_tendered", System.Type.GetType("System.Decimal"));
			dbTable.Columns.Add("bank", System.Type.GetType("System.String"));
            dbTable.Columns.Add("check_no", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_miscellaneous_income", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_payment", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_discount", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_reimbursement", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_credit_memo", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_balance_forwarded", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_included_in_post", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("sysid_account_credit", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_code", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_name", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement";

                    sqlComm.Parameters.Add("@sysid_student_list", SqlDbType.NVarChar).Value = studentSysIdList;
                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(dateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(dateEnd);

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["payment_discount_reimbursement_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,     
                                    "payment_discount_reimbursement_id", Int64.Parse("0"));
                                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student", String.Empty);
                                newRow["reflected_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "reflected_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["receipt_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "receipt_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["received_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["receipt_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "receipt_no", String.Empty);
                                newRow["remarks_discount_reimbursement_description"] = 
                                    RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "remarks_discount_reimbursement_description", String.Empty);
                                newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_downpayment", false);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));
                                newRow["discount_amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "discount_amount", Decimal.Parse("0"));
                                newRow["amount_tendered"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount_tendered", Decimal.Parse("0"));
                                newRow["bank"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "bank", String.Empty);
                                newRow["check_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "check_no", String.Empty);
                                newRow["is_miscellaneous_income"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_miscellaneous_income", false);
                                newRow["is_payment"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_payment", false);
                                newRow["is_discount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_discount", false);
                                newRow["is_reimbursement"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_reimbursement", false);
                                newRow["is_credit_memo"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_credit_memo", false);
                                newRow["is_balance_forwarded"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_balance_forwarded", false);
                                newRow["is_included_in_post"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_included_in_post", false);
                                newRow["sysid_account_credit"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_account_credit", String.Empty);
                                newRow["account_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_code", String.Empty);
                                newRow["account_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_name", String.Empty);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }

                    dbTable.AcceptChanges();

                }
            }

            return dbTable;

        } //------------------------------------------    

        //this function gets the student discount
        public DataTable SelectByDateStartEndCourseScholarshipListStudentDiscounts(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            String courseIdList, String scholarshipSysIdList, String serverDateTime)
        {
            DataTable dbTable = new DataTable("StudentDiscountByDateStartEndCourseScholarshipListTable");
            dbTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
			dbTable.Columns.Add("student_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("card_number", System.Type.GetType("System.String"));
			dbTable.Columns.Add("scholarship", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_international", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("is_no_downpayment_required", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("sysid_person", System.Type.GetType("System.String"));
			dbTable.Columns.Add("last_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("first_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("middle_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("present_address", System.Type.GetType("System.String"));
			dbTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));
			dbTable.Columns.Add("home_address", System.Type.GetType("System.String"));
			dbTable.Columns.Add("home_phone_nos", System.Type.GetType("System.String"));

			dbTable.Columns.Add("life_status_code_code_reference_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("life_status_code_code_entity_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("life_status_code_reference_code", System.Type.GetType("System.String"));
			dbTable.Columns.Add("life_status_code_code_description", System.Type.GetType("System.String"));

			dbTable.Columns.Add("gender_code_code_reference_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("gender_code_code_entity_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("gender_code_reference_code", System.Type.GetType("System.String"));
			dbTable.Columns.Add("gender_code_code_description", System.Type.GetType("System.String"));
			dbTable.Columns.Add("gender_code_reference_flag", System.Type.GetType("System.Byte"));

			dbTable.Columns.Add("course_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_current_course", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
			dbTable.Columns.Add("sysid_feelevel", System.Type.GetType("System.String"));
			dbTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_graduate_student", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("level_section", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_major_title", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_major_title_acronym", System.Type.GetType("System.String"));
			dbTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
			dbTable.Columns.Add("year_level_acronym", System.Type.GetType("System.String"));
			dbTable.Columns.Add("department_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_title", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_acronym", System.Type.GetType("System.String"));
			dbTable.Columns.Add("department_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("department_acronym", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("group_description", System.Type.GetType("System.String"));
			dbTable.Columns.Add("year_description", System.Type.GetType("System.String"));
			dbTable.Columns.Add("semester_description", System.Type.GetType("System.String"));

			dbTable.Columns.Add("sysid_studentscholarship", System.Type.GetType("System.String"));
			dbTable.Columns.Add("sysid_scholarship", System.Type.GetType("System.String"));
			dbTable.Columns.Add("scholarship_description", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_non_academic", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("discount_id", System.Type.GetType("System.Int64"));
			dbTable.Columns.Add("reflected_date", System.Type.GetType("System.String"));
			dbTable.Columns.Add("received_date", System.Type.GetType("System.String"));
			dbTable.Columns.Add("remarks", System.Type.GetType("System.String"));
			dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("is_downpayment", System.Type.GetType("System.Boolean"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByDateStartEndCourseScholarshipListStudentDiscounts";

                    DateTime dStart = DateTime.MinValue;
                    DateTime dEnd = DateTime.MinValue;

                    if ((String.IsNullOrEmpty(dateStart) || !DateTime.TryParse(dateStart, out dStart)) ||
                        (String.IsNullOrEmpty(dateEnd) || !DateTime.TryParse(dateEnd, out dEnd)))
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = dStart;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = dEnd;
                    }

                    if (String.IsNullOrEmpty(courseIdList))
                    {
                        sqlComm.Parameters.Add("@course_id_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@course_id_list", SqlDbType.NVarChar).Value = courseIdList;
                    }

                    if (String.IsNullOrEmpty(scholarshipSysIdList))
                    {
                        sqlComm.Parameters.Add("@sysid_scholarship_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_scholarship_list", SqlDbType.NVarChar).Value = scholarshipSysIdList;
                    }

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student", String.Empty);
                                newRow["student_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "student_id", String.Empty);
                                newRow["card_number"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "card_number", String.Empty);
                                newRow["scholarship"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "scholarship", String.Empty);
                                newRow["is_international"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_international", false);
                                newRow["is_no_downpayment_required"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_no_downpayment_required", false);
                                newRow["sysid_person"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_person", String.Empty);
                                newRow["last_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "last_name", String.Empty);
                                newRow["first_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "first_name", String.Empty);
                                newRow["middle_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "middle_name", String.Empty);
                                newRow["present_address"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "present_address", String.Empty);
                                newRow["present_phone_nos"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "present_phone_nos", String.Empty);
                                newRow["home_address"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "home_address", String.Empty);
                                newRow["home_phone_nos"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "home_phone_nos", String.Empty);;

                                newRow["life_status_code_code_reference_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "life_status_code_code_reference_id", String.Empty);
                                newRow["life_status_code_code_entity_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "life_status_code_code_entity_id", String.Empty);
                                newRow["life_status_code_reference_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "life_status_code_reference_code", String.Empty);
                                newRow["life_status_code_code_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "life_status_code_code_description", String.Empty);

                                newRow["gender_code_code_reference_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_code_reference_id", String.Empty);
                                newRow["gender_code_code_entity_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_code_entity_id", String.Empty);
                                newRow["gender_code_reference_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "gender_code_reference_code", String.Empty);
                                newRow["gender_code_code_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "gender_code_code_description", String.Empty);
                                newRow["gender_code_reference_flag"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "gender_code_reference_flag", Byte.Parse("0"));

                                newRow["course_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_id", String.Empty);
                                newRow["is_current_course"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_current_course", false);
                                newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_enrolmentlevel", String.Empty);
                                newRow["sysid_feelevel"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_feelevel", String.Empty);
                                newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_semester", String.Empty);
                                newRow["is_graduate_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_graduate_student", false);
                                newRow["level_section"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "level_section", String.Empty);
                                newRow["course_major_title"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_major_title", String.Empty);
                                newRow["course_major_title_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "course_major_title_acronym", String.Empty);
                                newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_level_description", String.Empty);
                                newRow["year_level_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_level_acronym", String.Empty);
                                newRow["department_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_id", String.Empty);
                                newRow["course_title"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_title", String.Empty);
                                newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_acronym", String.Empty);
                                newRow["department_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_name", String.Empty);
                                newRow["department_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_acronym", String.Empty);
                                newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_group_id", String.Empty);
                                newRow["group_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "group_description", String.Empty);
                                newRow["year_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_description", String.Empty);
                                newRow["semester_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "semester_description", String.Empty);

                                newRow["sysid_studentscholarship"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "sysid_studentscholarship", String.Empty);
                                newRow["sysid_scholarship"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_scholarship", String.Empty);
                                newRow["scholarship_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "scholarship_description", String.Empty);
                                newRow["is_non_academic"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_non_academic", false);
                                newRow["discount_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "discount_id", Int64.Parse("0"));
                                newRow["reflected_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "reflected_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["received_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["remarks"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "remarks", String.Empty);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));
                                newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_downpayment", false);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }

                    dbTable.AcceptChanges();
                }
            }

            return dbTable;

        } //------------------------------

        //this function gets the student credit memo
        public DataTable SelectByDateStartEndStudentCreditMemo(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            Boolean isConsolidated, String serverDateTime)
        {
            DataTable dbTable = new DataTable("StudentCreditMemoByDateStartEndTable");
            dbTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            dbTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("card_number", System.Type.GetType("System.String"));
            dbTable.Columns.Add("scholarship", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_international", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_no_downpayment_required", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("sysid_person", System.Type.GetType("System.String"));
            dbTable.Columns.Add("last_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("first_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("middle_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("present_address", System.Type.GetType("System.String"));
            dbTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));
            dbTable.Columns.Add("home_address", System.Type.GetType("System.String"));
            dbTable.Columns.Add("home_phone_nos", System.Type.GetType("System.String"));

            dbTable.Columns.Add("life_status_code_code_reference_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("life_status_code_code_entity_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("life_status_code_reference_code", System.Type.GetType("System.String"));
            dbTable.Columns.Add("life_status_code_code_description", System.Type.GetType("System.String"));

            dbTable.Columns.Add("gender_code_code_reference_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("gender_code_code_entity_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("gender_code_reference_code", System.Type.GetType("System.String"));
            dbTable.Columns.Add("gender_code_code_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("gender_code_reference_flag", System.Type.GetType("System.Byte"));

            dbTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_current_course", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_feelevel", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_graduate_student", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("level_section", System.Type.GetType("System.String"));
            dbTable.Columns.Add("course_major_title", System.Type.GetType("System.String"));
            dbTable.Columns.Add("course_major_title_acronym", System.Type.GetType("System.String"));
            dbTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("year_level_acronym", System.Type.GetType("System.String"));
            dbTable.Columns.Add("department_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            dbTable.Columns.Add("course_acronym", System.Type.GetType("System.String"));
            dbTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("department_acronym", System.Type.GetType("System.String"));
            dbTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("group_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("semester_description", System.Type.GetType("System.String"));

            dbTable.Columns.Add("memo_id", System.Type.GetType("System.Int64"));
			dbTable.Columns.Add("reflected_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("received_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("remarks", System.Type.GetType("System.String"));
            dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("is_downpayment", System.Type.GetType("System.Boolean"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByDateStartEndStudentCreditMemo";

                    DateTime dStart = DateTime.MinValue;
                    DateTime dEnd = DateTime.MinValue;

                    if ((String.IsNullOrEmpty(dateStart) || !DateTime.TryParse(dateStart, out dStart)) ||
                        (String.IsNullOrEmpty(dateEnd) || !DateTime.TryParse(dateEnd, out dEnd)))
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = dStart;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = dEnd;
                    }

                    sqlComm.Parameters.Add("@is_consolidated", SqlDbType.Bit).Value = isConsolidated;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student", String.Empty);
                                newRow["student_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "student_id", String.Empty);
                                newRow["card_number"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "card_number", String.Empty);
                                newRow["scholarship"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "scholarship", String.Empty);
                                newRow["is_international"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_international", false);
                                newRow["is_no_downpayment_required"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_no_downpayment_required", false);
                                newRow["sysid_person"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_person", String.Empty);
                                newRow["last_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "last_name", String.Empty);
                                newRow["first_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "first_name", String.Empty);
                                newRow["middle_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "middle_name", String.Empty);
                                newRow["present_address"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "present_address", String.Empty);
                                newRow["present_phone_nos"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "present_phone_nos", String.Empty);
                                newRow["home_address"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "home_address", String.Empty);
                                newRow["home_phone_nos"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "home_phone_nos", String.Empty); ;

                                newRow["life_status_code_code_reference_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "life_status_code_code_reference_id", String.Empty);
                                newRow["life_status_code_code_entity_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "life_status_code_code_entity_id", String.Empty);
                                newRow["life_status_code_reference_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "life_status_code_reference_code", String.Empty);
                                newRow["life_status_code_code_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "life_status_code_code_description", String.Empty);

                                newRow["gender_code_code_reference_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_code_reference_id", String.Empty);
                                newRow["gender_code_code_entity_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_code_entity_id", String.Empty);
                                newRow["gender_code_reference_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_reference_code", String.Empty);
                                newRow["gender_code_code_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_code_description", String.Empty);
                                newRow["gender_code_reference_flag"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_reference_flag", Byte.Parse("0"));

                                newRow["course_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_id", String.Empty);
                                newRow["is_current_course"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_current_course", false);
                                newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_enrolmentlevel", String.Empty);
                                newRow["sysid_feelevel"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_feelevel", String.Empty);
                                newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_semester", String.Empty);
                                newRow["is_graduate_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_graduate_student", false);
                                newRow["level_section"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "level_section", String.Empty);
                                newRow["course_major_title"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_major_title", String.Empty);
                                newRow["course_major_title_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "course_major_title_acronym", String.Empty);
                                newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_level_description", String.Empty);
                                newRow["year_level_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_level_acronym", String.Empty);
                                newRow["department_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_id", String.Empty);
                                newRow["course_title"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_title", String.Empty);
                                newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_acronym", String.Empty);
                                newRow["department_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_name", String.Empty);
                                newRow["department_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_acronym", String.Empty);
                                newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_group_id", String.Empty);
                                newRow["group_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "group_description", String.Empty);
                                newRow["year_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_description", String.Empty);
                                newRow["semester_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "semester_description", String.Empty);

                                newRow["memo_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "memo_id", Int64.Parse("0"));
                                newRow["reflected_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "reflected_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["received_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["remarks"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "remarks", String.Empty);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));
                                newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_downpayment", false);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }

                    dbTable.AcceptChanges();
                }
            }

            return dbTable;

        } //------------------------------

        //this function gets the cancelled receipt no
        public DataTable SelectCancelledReceiptNo(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataTable dbTable = new DataTable("CancelledReceiptNoTable");
            dbTable.Columns.Add("receipt_no", System.Type.GetType("System.String"));
            dbTable.Columns.Add("receipt_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("date_cancelled", System.Type.GetType("System.String"));
            dbTable.Columns.Add("remarks", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectCancelledReceiptNo";

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["receipt_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "receipt_no", String.Empty);
                                newRow["receipt_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "receipt_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["date_cancelled"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_cancelled",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["remarks"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "remarks", String.Empty);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }

                    dbTable.AcceptChanges();

                }
            }

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
            DataTable dbTable = new DataTable("MiscellaneousIncomeByQueryStringDateStartEndTable");
            dbTable.Columns.Add("payment_id", System.Type.GetType("System.Int64"));
            dbTable.Columns.Add("received_from", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
            dbTable.Columns.Add("reflected_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("receipt_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("received_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("receipt_no", System.Type.GetType("System.String"));
            dbTable.Columns.Add("remarks", System.Type.GetType("System.String"));
            dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("discount_amount", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("amount_tendered", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("bank", System.Type.GetType("System.String"));
            dbTable.Columns.Add("check_no", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_account_credit", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_code", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_name", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByQueryStringDateStartEndMiscellaneousIncome";

                    if (String.IsNullOrEmpty(queryString))
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;
                    }

                    DateTime dStart = DateTime.MinValue;
                    DateTime dEnd = DateTime.MinValue;

                    if ((String.IsNullOrEmpty(dateStart) || !DateTime.TryParse(dateStart, out dStart)) ||
                        (String.IsNullOrEmpty(dateEnd) || !DateTime.TryParse(dateEnd, out dEnd)))
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = dStart;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = dEnd;
                    }

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["payment_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "payment_id", Int64.Parse("0"));
                                newRow["received_from"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_from", String.Empty);
                                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student", String.Empty);
                                newRow["sysid_employee"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_employee", String.Empty);
                                newRow["reflected_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "reflected_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["receipt_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "receipt_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["received_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["receipt_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "receipt_no", String.Empty);
                                newRow["remarks"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "remarks", String.Empty);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));
                                newRow["discount_amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "discount_amount", Decimal.Parse("0"));
                                newRow["amount_tendered"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount_tendered", Decimal.Parse("0"));
                                newRow["bank"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "bank", String.Empty);
                                newRow["check_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "check_no", String.Empty);
                                newRow["sysid_account_credit"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_account_credit", String.Empty);
                                newRow["account_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_code", String.Empty);
                                newRow["account_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_name", String.Empty);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }

                    dbTable.AcceptChanges();
                }
            }

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
            DataTable dbTable = new DataTable("CashReceiptsDetailedByDateStartEndTable");
            dbTable.Columns.Add("sysid_account", System.Type.GetType("System.String"));
		    dbTable.Columns.Add("account_code", System.Type.GetType("System.String"));
	        dbTable.Columns.Add("account_name", System.Type.GetType("System.String"));
		    dbTable.Columns.Add("sysid_account_summary", System.Type.GetType("System.String"));
		    dbTable.Columns.Add("account_code_summary", System.Type.GetType("System.String"));
		    dbTable.Columns.Add("account_name_summary", System.Type.GetType("System.String"));
		    dbTable.Columns.Add("received_from", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_student_employee", System.Type.GetType("System.String"));
		    dbTable.Columns.Add("received_date", System.Type.GetType("System.String"));
		    dbTable.Columns.Add("receipt_no", System.Type.GetType("System.String"));
		    dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
		    dbTable.Columns.Add("is_miscellaneous_income", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("course_department_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("acronym", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByDateStartEndCashReceiptsDetailedStudentPaymentMiscellaneousIncome";

                    DateTime dStart = DateTime.MinValue;
                    DateTime dEnd = DateTime.MinValue;

                    if ((String.IsNullOrEmpty(dateStart) || !DateTime.TryParse(dateStart, out dStart)) ||
                        (String.IsNullOrEmpty(dateEnd) || !DateTime.TryParse(dateEnd, out dEnd)))
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = dStart;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = dEnd;
                    }

                    sqlComm.Parameters.Add("@is_consolidated", SqlDbType.Bit).Value = isConsolidated;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_account"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_account", String.Empty);
                                newRow["account_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_code", String.Empty);
                                newRow["account_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_name", String.Empty);
                                newRow["sysid_account_summary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_account_summary",
                                    String.Empty);
                                newRow["account_code_summary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_code_summary",
                                    String.Empty);
                                newRow["account_name_summary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_name_summary",
                                    String.Empty);
                                newRow["received_from"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_from", String.Empty);
                                newRow["sysid_student_employee"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student_employee", String.Empty);
                                newRow["received_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_date", 
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["receipt_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "receipt_no", String.Empty);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));
                                newRow["is_miscellaneous_income"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_miscellaneous_income", false);
                                newRow["course_department_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_department_id", String.Empty);
                                newRow["acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "acronym", String.Empty);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }

                    dbTable.AcceptChanges();
                }
            }

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
            DataTable dbTable = new DataTable("CashReceiptsSummarizedByDateStartEndTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByDateStartEndCashReceiptsSummarizedStudentPaymentMiscellaneousIncome";

                    DateTime dStart = DateTime.MinValue;
                    DateTime dEnd = DateTime.MinValue;

                    if ((String.IsNullOrEmpty(dateStart) || !DateTime.TryParse(dateStart, out dStart)) ||
                        (String.IsNullOrEmpty(dateEnd) || !DateTime.TryParse(dateEnd, out dEnd)))
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = dStart;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = dEnd;
                    }

                    sqlComm.Parameters.Add("@is_consolidated", SqlDbType.Bit).Value = isConsolidated;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                }
            }

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
            DataTable dbTable = new DataTable("BreakdownBankDepositCashReceiptsDetailedByDateStartEndTable");
            dbTable.Columns.Add("sysid_account", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_code", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_account_summary", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_code_summary", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_name_summary", System.Type.GetType("System.String"));
            dbTable.Columns.Add("breakdown_id", System.Type.GetType("System.Int64"));
		    dbTable.Columns.Add("date_start", System.Type.GetType("System.String"));
		    dbTable.Columns.Add("date_end", System.Type.GetType("System.String"));
            dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByDateStartEndCashReceiptsDetailedBreakdownBankDeposit";

                    DateTime dStart = DateTime.MinValue;
                    DateTime dEnd = DateTime.MinValue;

                    if ((String.IsNullOrEmpty(dateStart) || !DateTime.TryParse(dateStart, out dStart)) ||
                        (String.IsNullOrEmpty(dateEnd) || !DateTime.TryParse(dateEnd, out dEnd)))
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = dStart;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = dEnd;
                    }

                    sqlComm.Parameters.Add("@is_consolidated", SqlDbType.Bit).Value = isConsolidated;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_account"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_account", String.Empty);
                                newRow["account_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_code", String.Empty);
                                newRow["account_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_name", String.Empty);
                                newRow["sysid_account_summary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_account_summary",
                                    String.Empty);
                                newRow["account_code_summary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_code_summary",
                                    String.Empty);
                                newRow["account_name_summary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_name_summary",
                                    String.Empty);
                                newRow["breakdown_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "breakdown_id", Int64.Parse("0"));
                                newRow["date_start"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_start", 
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["date_end"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_end", 
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }

                    dbTable.AcceptChanges();
                }
            }

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
            DataTable dbTable = new DataTable("BreakdownBankDepositCashReceiptsSummarizedByDateStartEndTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByDateStartEndCashReceiptsSummarizedBreakdownBankDeposit";

                    DateTime dStart = DateTime.MinValue;
                    DateTime dEnd = DateTime.MinValue;

                    if ((String.IsNullOrEmpty(dateStart) || !DateTime.TryParse(dateStart, out dStart)) ||
                        (String.IsNullOrEmpty(dateEnd) || !DateTime.TryParse(dateEnd, out dEnd)))
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = dStart;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = dEnd;
                    }

                    sqlComm.Parameters.Add("@is_consolidated", SqlDbType.Bit).Value = isConsolidated;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                }
            }

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
            DataTable dbTable = new DataTable("CashReceiptsQueryTable");
            dbTable.Columns.Add("sysid_account", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_code", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_account_summary", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_code_summary", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_name_summary", System.Type.GetType("System.String"));
            dbTable.Columns.Add("received_from", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_student_employee", System.Type.GetType("System.String"));
            dbTable.Columns.Add("received_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("receipt_no", System.Type.GetType("System.String"));
            dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("is_miscellaneous_income", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("course_department_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("acronym", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByQueryStringDateStartEndCashReceiptsQueryStudentPaymentMiscellaneousIncome";

                    if (String.IsNullOrEmpty(queryString))
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;
                    }

                    DateTime dStart = DateTime.MinValue;
                    DateTime dEnd = DateTime.MinValue;

                    if ((String.IsNullOrEmpty(dateStart) || !DateTime.TryParse(dateStart, out dStart)) ||
                        (String.IsNullOrEmpty(dateEnd) || !DateTime.TryParse(dateEnd, out dEnd)))
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = dStart;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = dEnd;
                    }

                    if (String.IsNullOrEmpty(accountCreditSysIdList))
                    {
                        sqlComm.Parameters.Add("@sysid_account_credit_list", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_account_credit_list", SqlDbType.VarChar).Value = accountCreditSysIdList;
                    }

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_account"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_account", String.Empty);
                                newRow["account_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_code", String.Empty);
                                newRow["account_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_name", String.Empty);
                                newRow["sysid_account_summary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_account_summary",
                                    String.Empty);
                                newRow["account_code_summary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_code_summary",
                                    String.Empty);
                                newRow["account_name_summary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_name_summary",
                                    String.Empty);
                                newRow["received_from"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_from", String.Empty);
                                newRow["sysid_student_employee"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student_employee", String.Empty);
                                newRow["received_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_date",
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["receipt_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "receipt_no", String.Empty);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));
                                newRow["is_miscellaneous_income"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_miscellaneous_income", false);
                                newRow["course_department_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_department_id", String.Empty);
                                newRow["acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "acronym", String.Empty);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }

                    dbTable.AcceptChanges();
                }
            }

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
            DataTable dbTable = new DataTable("CashReceiptsDetailedByDateStartEndTable");
            dbTable.Columns.Add("sysid_account", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_code", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_account_summary", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_code_summary", System.Type.GetType("System.String"));
            dbTable.Columns.Add("account_name_summary", System.Type.GetType("System.String"));
            dbTable.Columns.Add("received_from", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_student_employee", System.Type.GetType("System.String"));
            dbTable.Columns.Add("received_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("receipt_no", System.Type.GetType("System.String"));
            dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("discount_amount", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("is_miscellaneous_income", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("course_department_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("acronym", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByDateStartEndCashDiscountsStudentPaymentMiscellaneousIncome";

                    DateTime dStart = DateTime.MinValue;
                    DateTime dEnd = DateTime.MinValue;

                    if ((String.IsNullOrEmpty(dateStart) || !DateTime.TryParse(dateStart, out dStart)) ||
                        (String.IsNullOrEmpty(dateEnd) || !DateTime.TryParse(dateEnd, out dEnd)))
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = dStart;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = dEnd;
                    }

                    sqlComm.Parameters.Add("@is_consolidated", SqlDbType.Bit).Value = isConsolidated;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_account"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_account", String.Empty);
                                newRow["account_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_code", String.Empty);
                                newRow["account_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_name", String.Empty);
                                newRow["sysid_account_summary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_account_summary",
                                    String.Empty);
                                newRow["account_code_summary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_code_summary",
                                    String.Empty);
                                newRow["account_name_summary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "account_name_summary",
                                    String.Empty);
                                newRow["received_from"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_from", String.Empty);
                                newRow["sysid_student_employee"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student_employee", String.Empty);
                                newRow["received_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_date",
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["receipt_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "receipt_no", String.Empty);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));
                                newRow["discount_amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "discount_amount", Decimal.Parse("0"));
                                newRow["is_miscellaneous_income"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_miscellaneous_income", false);
                                newRow["course_department_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_department_id", String.Empty);
                                newRow["acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "acronym", String.Empty);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }

                    dbTable.AcceptChanges();
                }
            }

            return dbTable;
        } //-------------------------------------------

        //this function is used to determine if the student has a payment for a certain date start and date end
        public Boolean IsExistsPaymentBySysIDStudentDateStartEndStudentPayments(CommonExchange.SysAccess userInfo,
            String studentSysId, String dateStart, String dateEnd)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsPaymentBySysIDStudentDateStartEndStudentPayments";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;
                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(dateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(dateEnd);

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //------------------------------

        //this function is used to determine if the receipt no already exists
        public Boolean IsExistsReceiptNoStudentPayments(CommonExchange.SysAccess userInfo, Int64 paymentId, String receiptNo)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsReceiptNoStudentPayments";

                    sqlComm.Parameters.Add("@payment_id", SqlDbType.BigInt).Value = paymentId;
                    sqlComm.Parameters.Add("@receipt_no", SqlDbType.VarChar).Value = receiptNo;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //------------------------------

        //this function is used to determine if the student has already a balance forwarded amount
        public Boolean IsExistsSysIDStudentStudentBalanceForwarded(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsSysIDStudentStudentBalanceForwarded";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //------------------------------

        //this function is used to get data tables stored in one dataset used for cashiering manager
        public DataSet GetDataSetForCashiering(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //get the school fee particular table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeParticularTable(auth.Connection, userInfo.UserId));
                //--------------------------------

                //get the school fee particular for additional fee table
                dbSet.Tables.Add(ProcStatic.GetForAdditionalFeeSchoolFeeParticularTable(auth.Connection, userInfo.UserId));
                //-----------------------------------------

                //get the school fee information table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //--------------------------------

                //get the school semester table
                dbSet.Tables.Add(ProcStatic.GetSemesterInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //--------------------------------

                //gets the school fee category table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeCategoryTable(auth.Connection, userInfo.UserId));
                //----------------------------------------

                //gets the course information table
                dbSet.Tables.Add(ProcStatic.GetCourseInformationTable(auth.Connection, userInfo.UserId));
                //---------------------------

                //gets the year level information table
                dbSet.Tables.Add(ProcStatic.GetYearLevelInformationTable(auth.Connection, userInfo.UserId));
                //-----------------------------------------------

                //gets the course group table
                dbSet.Tables.Add(ProcStatic.GetCourseGroupTable(auth.Connection, userInfo.UserId));
                //-----------------------------------

                //gets the scholarship information table
                dbSet.Tables.Add(ProcStatic.GetScholarshipInformationTable(auth.Connection, userInfo.UserId));
                //-----------------------------------------------

            }

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
