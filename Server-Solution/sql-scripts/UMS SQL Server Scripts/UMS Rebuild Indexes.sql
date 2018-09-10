USE db_spud_092509 --db_umsdev_03_30_2007 
GO

--ums.access_point_information
ALTER INDEX Access_Point_Information_Access_Point_ID_Index ON ums.access_point_information
REBUILD;

--ums.access_rights_granted
ALTER INDEX Access_Rights_Granted_Rights_Granted_ID_Index ON ums.access_rights_granted
REBUILD;

--ums.auxiliary_service_details
ALTER INDEX Auxiliary_Service_Details_SysID_AuxDetails_Index ON ums.auxiliary_service_details
REBUILD;

--ums.auxiliary_service_information
ALTER INDEX Auxiliary_Service_Information_SysID_Subject_Index ON ums.auxiliary_service_information
REBUILD;

--ums.auxiliary_service_schedule
ALTER INDEX Auxiliary_Service_Schedule_SysID_AuxServiceSchedule_Index ON ums.auxiliary_service_schedule
REBUILD;

--ums.breakdown_bank_deposit
ALTER INDEX Breakdown_Bank_Deposit_Breakdown_ID_Index ON ums.breakdown_bank_deposit
REBUILD;

--ums.campus_access_details
ALTER INDEX Campus_Access_Details_Details_ID_Index ON ums.campus_access_details
REBUILD;

--ums.cancelled_receipt_no
ALTER INDEX Cancelled_Receipt_No_Receipt_No_Index ON ums.cancelled_receipt_no
REBUILD;

ALTER INDEX Cancelled_Receipt_No_Created_On_Index ON ums.cancelled_receipt_no
REBUILD;

ALTER INDEX Cancelled_Receipt_No_Created_By_Index ON ums.cancelled_receipt_no
REBUILD;

--ums.chart_of_accounts
ALTER INDEX Chart_Of_Accounts_SysID_Account_Index ON ums.chart_of_accounts
REBUILD;

--ums.classroom_information
ALTER INDEX Classroom_Information_SysID_Classroom_Index ON ums.classroom_information
REBUILD;

--ums.code_entity
ALTER INDEX Code_Entity_Code_Entity_ID_Index ON ums.code_entity
REBUILD;

--ums.code_reference
ALTER INDEX Code_Reference_Code_Reference_ID_Index ON ums.code_reference
REBUILD;

--ums.course_information
ALTER INDEX Course_Information_Course_ID_Index ON ums.course_information
REBUILD;

--ums.course_major_information
ALTER INDEX Course_Major_Information_Major_Information_ID_Index ON ums.course_major_information
REBUILD;

--ums.course_year_level
ALTER INDEX Course_Year_Level_Course_Year_Level_ID_Index ON ums.course_year_level
REBUILD;

--ums.deduction_information
ALTER INDEX Deduction_Information_SysId_Deduction_Index ON ums.deduction_information
REBUILD;

--ums.department_information
ALTER INDEX Department_Information_Department_ID_Index ON ums.department_information
REBUILD;

--ums.earning_information
ALTER INDEX Earning_Information_SysId_Earning_Index ON ums.earning_information
REBUILD;

--ums.employee_deduction
ALTER INDEX Employee_Deduction_Deduction_ID_Index ON ums.employee_deduction
REBUILD;

--ums.employee_earning
ALTER INDEX Employee_Earning_Earning_ID_Index ON ums.employee_earning
REBUILD;

--ums.employee_information
ALTER INDEX Employee_Information_SysID_Employee_Index ON ums.employee_information
REBUILD;

--ums.employee_remittance
ALTER INDEX Employee_Remittance_Remittance_ID_Index ON ums.employee_remittance
REBUILD;

--ums.enrolment_course_major
ALTER INDEX Enrolment_Course_Major_Course_Major_ID_Index ON ums.enrolment_course_major
REBUILD;

--ums.finance_standard
ALTER INDEX Finance_Standard_SysID_FinanceStd_Index ON ums.finance_standard
REBUILD;

--ums.loan_remittance
ALTER INDEX Loan_Remittance_SysId_Remittance_Index ON ums.loan_remittance
REBUILD;

--ums.loan_type_information
ALTER INDEX Loan_Type_Information_SysId_Loan_Index ON ums.loan_type_information
REBUILD;

--ums.major_exam_schedule
ALTER INDEX Major_Exam_Schedule_Major_Exam_ID_Index ON ums.major_exam_schedule
REBUILD;

--ums.miscellaneous_income
ALTER INDEX Miscellaneous_Income_Payment_ID_Index ON ums.miscellaneous_income
REBUILD;

ALTER INDEX Miscellaneous_Income_Receipt_Date_Index ON ums.miscellaneous_income
REBUILD;

ALTER INDEX Miscellaneous_Income_Created_On_Index ON ums.miscellaneous_income
REBUILD;

ALTER INDEX Miscellaneous_Income_Created_By_Index ON ums.miscellaneous_income
REBUILD;

--ums.payroll_standard
ALTER INDEX Payroll_Standard_SysID_PayrollStd_Index ON ums.payroll_standard
REBUILD;

--ums.person_image
ALTER INDEX Person_Image_Image_ID_Index ON ums.person_image
REBUILD;

--ums.person_information
ALTER INDEX Person_Information_SysID_Person_Index ON ums.person_information
REBUILD;

--ums.person_relationship_information
ALTER INDEX Person_Relationship_Information_Relationship_ID_Index ON ums.person_relationship_information
REBUILD;

--ums.philhealth_information
ALTER INDEX PhilHealth_Information_Sss_ID_Index ON ums.philhealth_information
REBUILD;

--ums.philhealth_range
ALTER INDEX PhilHealth_Range_Range_ID_Index ON ums.philhealth_range
REBUILD;

--ums.rank_category
ALTER INDEX Rank_Category_Category_ID_Index ON ums.rank_category
REBUILD;

--ums.rank_degree
ALTER INDEX Rank_Degree_Degree_ID_Index ON ums.rank_degree
REBUILD;

--ums.rank_level
ALTER INDEX Rank_Level_Level_ID_Index ON ums.rank_level
REBUILD;

--ums.rank_salary_rate
ALTER INDEX Rank_Salary_Rate_Rate_ID_Index ON ums.rank_salary_rate
REBUILD;

--ums.registrar_standard
ALTER INDEX Registrar_Standard_SysID_RegistrarStd_Index ON ums.registrar_standard
REBUILD;

--ums.relationship_type
ALTER INDEX Relationship_Type_Relationship_Type_ID_Index ON ums.relationship_type
REBUILD;

--ums.salary_information
ALTER INDEX Salary_Information_Salary_ID_Index ON ums.salary_information
REBUILD;

--ums.schedule_information
ALTER INDEX Schedule_Information_SysID_Schedule_Index ON ums.schedule_information
REBUILD;

--ums.schedule_information_details
ALTER INDEX Schedule_Information_Details_SysID_SchedDetails_Index ON ums.schedule_information_details
REBUILD;

--ums.scholarship_information
ALTER INDEX Scholarship_Information_SysID_Scholarship_Index ON ums.scholarship_information
REBUILD;

--ums.school_fee_details
ALTER INDEX School_Fee_Details_SysID_FeeDetails_Index ON ums.school_fee_details
REBUILD;

--ums.school_fee_information
ALTER INDEX School_Fee_Information_SysID_SchoolFee_Index ON ums.school_fee_information
REBUILD;

--ums.school_fee_level
ALTER INDEX School_Fee_Level_SysID_FeeLevel_Index ON ums.school_fee_level
REBUILD;

--ums.school_fee_particular
ALTER INDEX School_Fee_Particular_SysID_FeeParticular_Index ON ums.school_fee_particular
REBUILD;

--ums.school_year
ALTER INDEX School_Year_Year_ID_Index ON ums.school_year
REBUILD;

--ums.school_year
ALTER INDEX School_Year_Date_Start_Index ON ums.school_year
REBUILD;

--ums.school_year
ALTER INDEX School_Year_Date_End_Index ON ums.school_year
REBUILD;

--ums.semester_information
ALTER INDEX Semester_Information_SysID_Semester_Index ON ums.semester_information
REBUILD;

--ums.semester_information
ALTER INDEX Semester_Information_Date_Start_Index ON ums.semester_information
REBUILD;

--ums.semester_information
ALTER INDEX Semester_Information_Date_End_Index ON ums.semester_information
REBUILD;

--ums.special_class_information
ALTER INDEX Special_Class_Information_SysID_Special_Index ON ums.special_class_information
REBUILD;

--ums.special_class_load
ALTER INDEX Special_Class_Load_Load_ID_Index ON ums.special_class_load
REBUILD;

--ums.sss_information
ALTER INDEX Sss_Information_Sss_ID_Index ON ums.sss_information
REBUILD;

--ums.sss_range
ALTER INDEX Sss_Range_Range_ID_Index ON ums.sss_range
REBUILD;

--ums.student_additional_fee
ALTER INDEX Student_Additional_Fee_Additional_Fee_ID_Index ON ums.student_additional_fee
REBUILD;

--ums.student_balance_forwarded
ALTER INDEX Student_Balance_Forwarded_Balance_ID_Index ON ums.student_balance_forwarded
REBUILD;

--ums.student_credit_memo
ALTER INDEX Student_Credit_Memo_Memo_ID_Index ON ums.student_credit_memo
REBUILD;

--ums.student_discounts
ALTER INDEX Student_Discounts_Discount_ID_Index ON ums.student_discounts
REBUILD;

--ums.student_enrolment_course
ALTER INDEX Student_Enrolment_Course_SysID_EnrolmentCourse_Index ON ums.student_enrolment_course
REBUILD;

--ums.student_enrolment_level
ALTER INDEX Student_Enrolment_Level_SysID_EnrolmentLevel_Index ON ums.student_enrolment_level
REBUILD;

--ums.student_information
ALTER INDEX Student_Information_SysID_Student_Index ON ums.student_information
REBUILD;

--ums.student_load
ALTER INDEX Student_Load_Load_ID_Index ON ums.student_load
REBUILD;

--ums.student_optional_fee
ALTER INDEX Student_Optional_Fee_Optional_Fee_ID_Index ON ums.student_optional_fee
REBUILD;

--ums.student_payments
ALTER INDEX Student_Payments_Payment_ID_Index ON ums.student_payments
REBUILD;

ALTER INDEX Student_Payments_Receipt_Date_Index ON ums.student_payments
REBUILD;

ALTER INDEX Student_Payments_Created_On_Index ON ums.student_payments
REBUILD;

ALTER INDEX Student_Payments_Created_By_Index ON ums.student_payments
REBUILD;

--ums.student_promissory_note
ALTER INDEX Student_Promissory_Note_Promissory_Note_ID_Index ON ums.student_promissory_note
REBUILD;

--ums.student_reimbursements
ALTER INDEX Student_Reimbursements_Reimbursement_ID_Index ON ums.student_reimbursements
REBUILD;

--ums.student_scholarship
ALTER INDEX Student_Scholarship_SysID_StudentScholarship_Index ON ums.student_scholarship
REBUILD;

--ums.subject_information
ALTER INDEX Subject_Information_SysID_Subject_Index ON ums.subject_information
REBUILD;

--ums.subject_prerequisite
ALTER INDEX Subject_Prerequisite_Prerequisite_ID_Index ON ums.subject_prerequisite
REBUILD;

--ums.subject_schedule
ALTER INDEX Subject_Schedule_Schedule_ID_Index ON ums.subject_schedule
REBUILD;

--ums.system_user_info
ALTER INDEX System_User_Info_System_User_ID_Index ON ums.system_user_info
REBUILD;

--ums.teacher_load
ALTER INDEX Teacher_Load_Load_ID_Index ON ums.teacher_load
REBUILD;

--ums.transaction_log
ALTER INDEX Transaction_Log_Transaction_ID_Index ON ums.transaction_log
REBUILD;

--ums.transcript_details
ALTER INDEX Transcript_Details_Transcript_ID_Index ON ums.transcript_details
REBUILD;

--ums.transcript_image
ALTER INDEX Transcript_Image_Image_ID_Index ON ums.transcript_image
REBUILD;

--ums.transcript_information
ALTER INDEX Transcript_Information_SysID_Transcript_Index ON ums.transcript_information
REBUILD;