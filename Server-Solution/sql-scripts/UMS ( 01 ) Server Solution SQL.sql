--******************************************************--
-- This SQL Statements is used for the St. Paul			--
-- 		University UMS									--
--Programmed by: Judyll Mark T. Agan					--
--Date created: April 01, 2007							--
--SERVER SOLUTIONS [ 1 ]
--******************************************************--

USE db_umsdev_03_30_2007
GO

-- ###########################################DROP TABLE CONSTRAINTS ##############################################################

--verifies if the Code_Reference_Code_Entity_ID_FK constraint exists
IF OBJECT_ID('ums.code_reference', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.code_reference
	DROP CONSTRAINT Code_Reference_Code_Entity_ID_FK
END
GO
-----------------------------------------------------

--verifies if the System_User_Info_Created_By_FK constraint exists--
IF OBJECT_ID('ums.system_user_info', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.system_user_info
	DROP CONSTRAINT System_User_Info_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the System_User_Info_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.system_user_info', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.system_user_info
	DROP CONSTRAINT System_User_Info_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Access_Rights_Granted_System_User_ID_FK constraint exists--
IF OBJECT_ID('ums.access_rights_granted', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.access_rights_granted
	DROP CONSTRAINT Access_Rights_Granted_System_User_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Access_Rights_Granted_Access_Rights_FK constraint exists--
IF OBJECT_ID('ums.access_rights_granted', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.access_rights_granted
	DROP CONSTRAINT Access_Rights_Granted_Access_Rights_FK
END
GO
-----------------------------------------------------

--verifies if the Access_Rights_Granted_Department_ID_FK constraint exists--
IF OBJECT_ID('ums.access_rights_granted', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.access_rights_granted
	DROP CONSTRAINT Access_Rights_Granted_Department_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Access_Rights_Granted_Created_By_FK constraint exists--
IF OBJECT_ID('ums.access_rights_granted', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.access_rights_granted
	DROP CONSTRAINT Access_Rights_Granted_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Access_Rights_Granted_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.access_rights_granted', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.access_rights_granted
	DROP CONSTRAINT Access_Rights_Granted_Edited_By_FK
END
GO
-----------------------------------------------------

-- verifies if the Transaction_Log_System_User_ID_FK constraint exists
IF OBJECT_ID('ums.transaction_log', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transaction_log
	DROP CONSTRAINT Transaction_Log_System_User_ID_FK 
END
GO
/*-------------------------------------------------*/

--verifies if the Payroll_Standard_Created_By_FK constraint exists
IF OBJECT_ID('ums.payroll_standard', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.payroll_standard
	DROP CONSTRAINT Payroll_Standard_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Payroll_Standard_Edited_By_FK constraint exists
IF OBJECT_ID('ums.payroll_standard', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.payroll_standard
	DROP CONSTRAINT Payroll_Standard_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Registrar_Standard_Created_By_FK constraint exists
IF OBJECT_ID('ums.registrar_standard', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.registrar_standard
	DROP CONSTRAINT Registrar_Standard_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Registrar_Standard_Edited_By_FK constraint exists
IF OBJECT_ID('ums.registrar_standard', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.registrar_standard
	DROP CONSTRAINT Registrar_Standard_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Finance_Standard_Created_By_FK constraint exists
IF OBJECT_ID('ums.finance_standard', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.finance_standard
	DROP CONSTRAINT Finance_Standard_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Finance_Standard_Edited_By_FK constraint exists
IF OBJECT_ID('ums.finance_standard', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.finance_standard
	DROP CONSTRAINT Finance_Standard_Edited_By_FK
END
GO
-----------------------------------------------------

-- ########################################END DROP TABLE CONSTRAINTS ##############################################################



-- ########################################DROP DEPENDENT TABLE CONSTRAINTS ##############################################################

--verifies if the Rank_Salary_Rate_Created_By_FK constraint exists
IF OBJECT_ID('ums.rank_salary_rate', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.rank_salary_rate
	DROP CONSTRAINT Rank_Salary_Rate_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Rank_Salary_Rate_Edited_By_FK constraint exists
IF OBJECT_ID('ums.rank_salary_rate', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.rank_salary_rate
	DROP CONSTRAINT Rank_Salary_Rate_Edited_By_FK
END
GO
-----------------------------------------------------


--verifies if the Sss_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.sss_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.sss_information
	DROP CONSTRAINT Sss_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Sss_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.sss_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.sss_information
	DROP CONSTRAINT Sss_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Sss_Range_Created_By_FK constraint exists--
IF OBJECT_ID('ums.sss_range', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.sss_range
	DROP CONSTRAINT Sss_Range_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Sss_Range_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.sss_range', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.sss_range
	DROP CONSTRAINT Sss_Range_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the PhilHealth_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.philhealth_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.philhealth_information
	DROP CONSTRAINT PhilHealth_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the PhilHealth_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.philhealth_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.philhealth_information
	DROP CONSTRAINT PhilHealth_Information_Edited_By_FK
END
GO
-----------------------------------------------------	

--verifies if the PhilHealth_Range_Created_By_FK constraint exists--
IF OBJECT_ID('ums.philhealth_range', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.philhealth_range
	DROP CONSTRAINT PhilHealth_Range_Created_By_FK
END
GO
-----------------------------------------------------	

--verifies if the PhilHealth_Range_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.philhealth_range', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.philhealth_range
	DROP CONSTRAINT PhilHealth_Range_Edited_By_FK
END
GO
-----------------------------------------------------	

--verifies if the Person_Information_Life_Status_Code_FK constraint exists--
IF OBJECT_ID('ums.person_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_information
	DROP CONSTRAINT Person_Information_Life_Status_Code_FK
END
GO
-----------------------------------------------------	

--verifies if the Person_Information_Gender_Code_FK constraint exists--
IF OBJECT_ID('ums.person_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_information
	DROP CONSTRAINT Person_Information_Gender_Code_FK
END
GO
-----------------------------------------------------	

--verifies if the Person_Information_Marital_Status_Code_FK constraint exists--
IF OBJECT_ID('ums.person_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_information
	DROP CONSTRAINT Person_Information_Marital_Status_Code_FK
END
GO
-----------------------------------------------------	

--verifies if the Person_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.person_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_information
	DROP CONSTRAINT Person_Information_Created_By_FK
END
GO
-----------------------------------------------------	

--verifies if the Person_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.person_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_information
	DROP CONSTRAINT Person_Information_Edited_By_FK
END
GO
-----------------------------------------------------	

--verifies if the Person_Image_Created_By_FK constraint exists--
IF OBJECT_ID('ums.person_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_image
	DROP CONSTRAINT Person_Image_Created_By_FK
END
GO
-----------------------------------------------------	

--verifies if the Person_Image_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.person_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_image
	DROP CONSTRAINT Person_Image_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Employee_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.employee_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_information
	DROP CONSTRAINT Employee_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Employee_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.employee_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_information
	DROP CONSTRAINT Employee_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the School_Year_Created_By_FK constraint exists
IF OBJECT_ID('ums.school_year', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_year
	DROP CONSTRAINT School_Year_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the School_Year_Edited_By_FK constraint exists
IF OBJECT_ID('ums.school_year', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_year
	DROP CONSTRAINT School_Year_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Salary_Information_Department_ID_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information
	DROP CONSTRAINT Salary_Information_Department_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Salary_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information
	DROP CONSTRAINT Salary_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Salary_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information
	DROP CONSTRAINT Salary_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Deduction_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.deduction_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.deduction_information
	DROP CONSTRAINT Deduction_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Deduction_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.deduction_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.deduction_information
	DROP CONSTRAINT Deduction_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Employee_Deduction_Created_By_FK constraint exists--
IF OBJECT_ID('ums.employee_deduction', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_deduction
	DROP CONSTRAINT Employee_Deduction_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Employee_Deduction_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.employee_deduction', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_deduction
	DROP CONSTRAINT Employee_Deduction_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Earning_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.earning_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.earning_information
	DROP CONSTRAINT Earning_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Earning_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.earning_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.earning_information
	DROP CONSTRAINT Earning_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Employee_Earning_Created_By_FK constraint exists--
IF OBJECT_ID('ums.employee_earning', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_earning
	DROP CONSTRAINT Employee_Earning_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Employee_Earning_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.employee_earning', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_earning
	DROP CONSTRAINT Employee_Earning_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Loan_Type_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.loan_type_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_type_information
	DROP CONSTRAINT Loan_Type_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Loan_Type_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.loan_type_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_type_information
	DROP CONSTRAINT Loan_Type_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Loan_Remittance_Created_By_FK constraint exists--
IF OBJECT_ID('ums.loan_remittance', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_remittance
	DROP CONSTRAINT Loan_Remittance_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Loan_Remittance_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.loan_remittance', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_remittance
	DROP CONSTRAINT Loan_Remittance_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Loan_Remittance_Audit_Deleted_By_FK constraint exists--
IF OBJECT_ID('ums.loan_remittance_audit', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_remittance_audit
	DROP CONSTRAINT Loan_Remittance_Audit_Deleted_By_FK
END
GO
-----------------------------------------------------

--verifies if the Employee_Remittance_Created_By_FK constraint exists--
IF OBJECT_ID('ums.employee_remittance', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_remittance
	DROP CONSTRAINT Employee_Remittance_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Employee_Remittance_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.employee_remittance', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_remittance
	DROP CONSTRAINT Employee_Remittance_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Semester_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.semester_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.semester_information
	DROP CONSTRAINT Semester_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Semester_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.semester_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.semester_information
	DROP CONSTRAINT Semester_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Classroom_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.classroom_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.classroom_information
	DROP CONSTRAINT Classroom_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Classroom_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.classroom_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.classroom_information
	DROP CONSTRAINT Classroom_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Subject_Information_Department_ID_FK constraint exists
IF OBJECT_ID('ums.subject_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_information
	DROP CONSTRAINT Subject_Information_Department_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Subject_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.subject_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_information
	DROP CONSTRAINT Subject_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Subject_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.subject_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_information
	DROP CONSTRAINT Subject_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Subject_Prerequisite_Created_By_FK constraint exists
IF OBJECT_ID('ums.subject_prerequisite', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_prerequisite
	DROP CONSTRAINT Subject_Prerequisite_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Subject_Prerequisite_Edited_By_FK constraint exists
IF OBJECT_ID('ums.subject_prerequisite', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_prerequisite
	DROP CONSTRAINT Subject_Prerequisite_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Course_Information_Department_ID_FK constraint exists
IF OBJECT_ID('ums.course_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_information
	DROP CONSTRAINT Course_Information_Department_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Course_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.course_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_information
	DROP CONSTRAINT Course_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Course_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.course_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_information
	DROP CONSTRAINT Course_Information_Edited_By_FK
END
GO
-----------------------------------------------------


--verifies if the Course_Major_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.course_major_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_major_information
	DROP CONSTRAINT Course_Major_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Course_Major_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.course_major_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_major_information
	DROP CONSTRAINT Course_Major_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Course_Year_Level_Created_By_FK constraint exists
IF OBJECT_ID('ums.course_year_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_year_level
	DROP CONSTRAINT Course_Year_Level_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Course_Year_Level_Edited_By_FK constraint exists
IF OBJECT_ID('ums.course_year_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_year_level
	DROP CONSTRAINT Course_Year_Level_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_information
	DROP CONSTRAINT Student_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_information
	DROP CONSTRAINT Student_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Image_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_image
	DROP CONSTRAINT Student_Image_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Image_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_image
	DROP CONSTRAINT Student_Image_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Special_Class_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.special_class_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_information
	DROP CONSTRAINT Special_Class_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Special_Class_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.special_class_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_information
	DROP CONSTRAINT Special_Class_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Special_Class_Load_Created_By_FK constraint exists
IF OBJECT_ID('ums.special_class_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_load
	DROP CONSTRAINT Special_Class_Load_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Special_Class_Load_Edited_By_FK constraint exists
IF OBJECT_ID('ums.special_class_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_load
	DROP CONSTRAINT Special_Class_Load_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.schedule_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information
	DROP CONSTRAINT Schedule_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.schedule_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information
	DROP CONSTRAINT Schedule_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_Details_Created_By_FK constraint exists
IF OBJECT_ID('ums.schedule_information_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information_details
	DROP CONSTRAINT Schedule_Information_Details_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_Details_Edited_By_FK constraint exists
IF OBJECT_ID('ums.schedule_information_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information_details
	DROP CONSTRAINT Schedule_Information_Details_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Subject_Schedule_Created_By_FK constraint exists
IF OBJECT_ID('ums.subject_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_schedule
	DROP CONSTRAINT Subject_Schedule_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Subject_Schedule_Edited_By_FK constraint exists
IF OBJECT_ID('ums.subject_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_schedule
	DROP CONSTRAINT Subject_Schedule_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Information_Department_ID_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_information
	DROP CONSTRAINT Auxiliary_Service_Information_Department_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_information
	DROP CONSTRAINT Auxiliary_Service_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_information
	DROP CONSTRAINT Auxiliary_Service_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Schedule_Created_By_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_schedule
	DROP CONSTRAINT Auxiliary_Service_Schedule_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Schedule_Edited_By_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_schedule
	DROP CONSTRAINT Auxiliary_Service_Schedule_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Details_Created_By_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_details
	DROP CONSTRAINT Auxiliary_Service_Details_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Details_Edited_By_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_details
	DROP CONSTRAINT Auxiliary_Service_Details_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Teacher_Load_Created_By_FK constraint exists
IF OBJECT_ID('ums.teacher_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.teacher_load
	DROP CONSTRAINT Teacher_Load_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Teacher_Load_Edited_By_FK constraint exists
IF OBJECT_ID('ums.teacher_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.teacher_load
	DROP CONSTRAINT Teacher_Load_Edited_By_FK
END
GO
-----------------------------------------------------	

--verifies if the Student_Load_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_load
	DROP CONSTRAINT Student_Load_Created_By_FK
END
GO
-----------------------------------------------------	

--verifies if the Student_Load_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_load
	DROP CONSTRAINT Student_Load_Edited_By_FK
END
GO
-----------------------------------------------------	

--verifies if the School_Fee_Particular_Created_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_particular', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_particular
	DROP CONSTRAINT School_Fee_Particular_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Particular_Edited_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_particular', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_particular
	DROP CONSTRAINT School_Fee_Particular_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_information
	DROP CONSTRAINT School_Fee_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_information
	DROP CONSTRAINT School_Fee_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Level_Created_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_level
	DROP CONSTRAINT School_Fee_Level_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Level_Edited_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_level
	DROP CONSTRAINT School_Fee_Level_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Course_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_course', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_course
	DROP CONSTRAINT Student_Enrolment_Course_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Course_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_course', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_course
	DROP CONSTRAINT Student_Enrolment_Course_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Level_SysID_FinanceStd_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_level
	DROP CONSTRAINT Student_Enrolment_Level_SysID_FinanceStd_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Level_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_level
	DROP CONSTRAINT Student_Enrolment_Level_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Level_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_level
	DROP CONSTRAINT Student_Enrolment_Level_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Details_Created_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_details
	DROP CONSTRAINT School_Fee_Details_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Details_Edited_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_details
	DROP CONSTRAINT School_Fee_Details_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Additional_Fee_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_additional_fee', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_additional_fee
	DROP CONSTRAINT Student_Additional_Fee_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Additional_Fee_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_additional_fee', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_additional_fee
	DROP CONSTRAINT Student_Additional_Fee_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Optional_Fee_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_optional_fee', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_optional_fee
	DROP CONSTRAINT Student_Optional_Fee_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Optional_Fee_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_optional_fee', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_optional_fee
	DROP CONSTRAINT Student_Optional_Fee_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Payments_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_payments', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_payments
	DROP CONSTRAINT Student_Payments_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Payments_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_payments', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_payments
	DROP CONSTRAINT Student_Payments_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Scholarship_Information_Department_ID_FK constraint exists
IF OBJECT_ID('ums.scholarship_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.scholarship_information
	DROP CONSTRAINT Scholarship_Information_Department_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Scholarship_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.scholarship_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.scholarship_information
	DROP CONSTRAINT Scholarship_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Scholarship_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.scholarship_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.scholarship_information
	DROP CONSTRAINT Scholarship_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Scholarship_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_scholarship', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_scholarship
	DROP CONSTRAINT Student_Scholarship_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Scholarship_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_scholarship', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_scholarship
	DROP CONSTRAINT Student_Scholarship_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Discounts_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_discounts', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_discounts
	DROP CONSTRAINT Student_Discounts_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Discounts_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_discounts', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_discounts
	DROP CONSTRAINT Student_Discounts_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Reimbursements_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_reimbursements', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_reimbursements
	DROP CONSTRAINT Student_Reimbursements_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Reimbursements_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_reimbursements', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_reimbursements
	DROP CONSTRAINT Student_Reimbursements_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Credit_Memo_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_credit_memo', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_credit_memo
	DROP CONSTRAINT Student_Credit_Memo_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Credit_Memo_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_credit_memo', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_credit_memo
	DROP CONSTRAINT Student_Credit_Memo_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Promissory_Note_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_promissory_note', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_promissory_note
	DROP CONSTRAINT Student_Promissory_Note_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Promissory_Note_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_promissory_note', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_promissory_note
	DROP CONSTRAINT Student_Promissory_Note_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Cancelled_Receipt_No_Created_By_FK constraint exists
IF OBJECT_ID('ums.cancelled_receipt_no', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.cancelled_receipt_no
	DROP CONSTRAINT Cancelled_Receipt_No_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Cancelled_Receipt_No_Edited_By_FK constraint exists
IF OBJECT_ID('ums.cancelled_receipt_no', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.cancelled_receipt_no
	DROP CONSTRAINT Cancelled_Receipt_No_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Balance_Forwarded_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_balance_forwarded', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_balance_forwarded
	DROP CONSTRAINT Student_Balance_Forwarded_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Balance_Forwarded_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_balance_forwarded', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_balance_forwarded
	DROP CONSTRAINT Student_Balance_Forwarded_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Major_Exam_Schedule_Created_By_FK constraint exists
IF OBJECT_ID('ums.major_exam_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.major_exam_schedule
	DROP CONSTRAINT Major_Exam_Schedule_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Major_Exam_Schedule_Edited_By_FK constraint exists
IF OBJECT_ID('ums.major_exam_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.major_exam_schedule
	DROP CONSTRAINT Major_Exam_Schedule_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Enrolment_Course_Major_Created_By_FK constraint exists
IF OBJECT_ID('ums.enrolment_course_major', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.enrolment_course_major
	DROP CONSTRAINT Enrolment_Course_Major_Created_By_FK
END
GO
-----------------------------------------------------	

--verifies if the Enrolment_Course_Major_Edited_By_FK constraint exists
IF OBJECT_ID('ums.enrolment_course_major', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.enrolment_course_major
	DROP CONSTRAINT Enrolment_Course_Major_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Person_Relationship_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.person_relationship_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_relationship_information
	DROP CONSTRAINT Person_Relationship_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Person_Relationship_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.person_relationship_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_relationship_information
	DROP CONSTRAINT Person_Relationship_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Transcript_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.transcript_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_information
	DROP CONSTRAINT Transcript_Information_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Transcript_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.transcript_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_information
	DROP CONSTRAINT Transcript_Information_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Transcript_Image_Created_By_FK constraint exists
IF OBJECT_ID('ums.transcript_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_image
	DROP CONSTRAINT Transcript_Image_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Transcript_Image_Edited_By_FK constraint exists
IF OBJECT_ID('ums.transcript_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_image
	DROP CONSTRAINT Transcript_Image_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Transcript_Details_Created_By_FK constraint exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_details
	DROP CONSTRAINT Transcript_Details_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Transcript_Details_Edited_By_FK constraint exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_details
	DROP CONSTRAINT Transcript_Details_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Campus_Access_Details_Created_By_FK constraint exists
IF OBJECT_ID('ums.campus_access_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.campus_access_details
	DROP CONSTRAINT Campus_Access_Details_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Campus_Access_Details_Edited_By_FK constraint exists
IF OBJECT_ID('ums.campus_access_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.campus_access_details
	DROP CONSTRAINT Campus_Access_Details_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Chart_Of_Accounts_Created_By_FK constraint exists
IF OBJECT_ID('ums.chart_of_accounts', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.chart_of_accounts
	DROP CONSTRAINT Chart_Of_Accounts_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Chart_Of_Accounts_Edited_By_FK constraint exists
IF OBJECT_ID('ums.chart_of_accounts', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.chart_of_accounts
	DROP CONSTRAINT Chart_Of_Accounts_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Miscellaneous_Income_Created_By_FK constraint exists
IF OBJECT_ID('ums.miscellaneous_income', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.miscellaneous_income
	DROP CONSTRAINT Miscellaneous_Income_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Miscellaneous_Income_Edited_By_FK constraint exists
IF OBJECT_ID('ums.miscellaneous_income', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.miscellaneous_income
	DROP CONSTRAINT Miscellaneous_Income_Edited_By_FK
END
GO
-----------------------------------------------------

--verifies if the Breakdown_Bank_Deposit_Created_By_FK constraint exists
IF OBJECT_ID('ums.breakdown_bank_deposit', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.breakdown_bank_deposit
	DROP CONSTRAINT Breakdown_Bank_Deposit_Created_By_FK
END
GO
-----------------------------------------------------

--verifies if the Breakdown_Bank_Deposit_Edited_By_FK constraint exists
IF OBJECT_ID('ums.breakdown_bank_deposit', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.breakdown_bank_deposit
	DROP CONSTRAINT Breakdown_Bank_Deposit_Edited_By_FK
END
GO
-----------------------------------------------------

-- ######################################END DROP DEPENDENT TABLE CONSTRAINTS ############################################################



-- #########################################################GENERAL PROCEDURES AND FUNCTIONS##################################################

-- verifies if the "ShowErrorMsg" procedure already exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'ShowErrorMsg')
   DROP PROCEDURE ums.ShowErrorMsg
GO

CREATE PROCEDURE ums.ShowErrorMsg

	@request varchar(200) = '',
	@table varchar(200) = ''

AS
	
	RAISERROR (N'%s \n%s %s \n%s %s \n\n%s', 10, 128, N'The server DENIED the current request.', 'Query: ',
				@request, 'Table: ', @table, N'Please contact the system administrator.') WITH NOWAIT

GO
----------------------------------------------------

-- verifies if the "GetServerDateTime" procedure already exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetServerDateTime')
   DROP PROCEDURE ums.GetServerDateTime
GO

CREATE PROCEDURE ums.GetServerDateTime
AS
	SELECT GETDATE()	
GO
----------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetServerDateTime TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "CreateTemporaryTable" procedure already exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'CreateTemporaryTable')
   DROP PROCEDURE ums.CreateTemporaryTable
GO

CREATE PROCEDURE ums.CreateTemporaryTable

	@system_user_id varchar(50) = '',
	@network_information varchar(MAX) = ''

AS
	
	IF NOT EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		CREATE TABLE ##ums_network_information_table
		(
			system_user_id varchar(50) NOT NULL PRIMARY KEY,
			network_information varchar(MAX)
		)
	END

	IF NOT EXISTS (SELECT * FROM ##ums_network_information_table WHERE system_user_id = @system_user_id)
	BEGIN
		INSERT INTO ##ums_network_information_table
		(
			system_user_id,
			network_information
		)
		VALUES
		(
			@system_user_id,
			@network_information
		)
	END
	ELSE
	BEGIN
		UPDATE ##ums_network_information_table SET
			network_information = @network_information
		WHERE
			system_user_id = @system_user_id
	END

GO
----------------------------------------------------

-- verifies if the "GetPayrollEffectivityDate" function already exist
IF OBJECT_ID (N'ums.GetPayrollEffectivityDate') IS NOT NULL
   DROP FUNCTION ums.GetPayrollEffectivityDate
GO

CREATE FUNCTION ums.GetPayrollEffectivityDate
(	
	@initial_date datetime
)
RETURNS datetime
AS
BEGIN
	
	DECLARE @effectivity_date datetime
	DECLARE @payroll_cutoff_day tinyint
	DECLARE @month tinyint
	DECLARE @year smallint
	
	SELECT @payroll_cutoff_day = payroll_cutoff_day FROM ums.payroll_standard WHERE effectivity_date = (SELECT MAX(effectivity_date) FROM ums.payroll_standard)
	
	IF DAY(@initial_date) > @payroll_cutoff_day
	BEGIN

		SET @month = MONTH(DATEADD(mm, 1, @initial_date))
		SET @year = YEAR(DATEADD(mm, 1, @initial_date))
		
	END
	ELSE
	BEGIN

		SET @month = MONTH(@initial_date)
		SET @year = YEAR(@initial_date)

	END

	RETURN CONVERT(datetime, (CONVERT(varchar, @month) + '/' + '1' + '/' + CONVERT(varchar, @year)) + ' 12:00:00 AM', 101)

END
GO
------------------------------------------------------

-- verifies if the "GetEnrolmentEffectivityDate" function already exist
IF OBJECT_ID (N'ums.GetEnrolmentEffectivityDate') IS NOT NULL
   DROP FUNCTION ums.GetEnrolmentEffectivityDate
GO

CREATE FUNCTION ums.GetEnrolmentEffectivityDate
(	
	@initial_date datetime
)
RETURNS datetime
AS
BEGIN
	
	DECLARE @effectivity_date datetime
	DECLARE @enrolment_cutoff_day tinyint
	DECLARE @month tinyint
	DECLARE @year smallint
	
	SELECT @enrolment_cutoff_day = enrolment_cutoff_day FROM ums.finance_standard WHERE effectivity_date = (SELECT MAX(effectivity_date) FROM ums.finance_standard)
	
	IF DAY(@initial_date) > @enrolment_cutoff_day
	BEGIN

		SET @month = MONTH(DATEADD(mm, 1, @initial_date))
		SET @year = YEAR(DATEADD(mm, 1, @initial_date))
		
	END
	ELSE
	BEGIN

		SET @month = MONTH(@initial_date)
		SET @year = YEAR(@initial_date)

	END

	RETURN CONVERT(datetime, (CONVERT(varchar, @month) + '/' + '1' + '/' + CONVERT(varchar, @year)) + ' 12:00:00 AM', 101)

END
GO
------------------------------------------------------

-- verifies if the "IterateListToTable" function already exist
IF OBJECT_ID (N'ums.IterateListToTable') IS NOT NULL
   DROP FUNCTION ums.IterateListToTable
GO

CREATE FUNCTION ums.IterateListToTable
(	
	@list nvarchar(MAX),
	@delimiter nchar(1) = N','
)
RETURNS @return_table TABLE (list_id int IDENTITY(1,1) NOT NULL,
								var_str varchar(4000) NOT NULL,
								nvar_str nvarchar(2000) NOT NULL)
AS
BEGIN
	
	DECLARE @endpos int
	DECLARE @startpos int
	DECLARE @textpos int
	DECLARE @chunklen smallint
	DECLARE @tmpstr nvarchar (4000)
	DECLARE @leftover nvarchar (4000)
	DECLARE @tmpval nvarchar (4000)

	SET @textpos = 1
	SET @leftover = ''
	
	WHILE @textpos <= DATALENGTH(@list) / 2
	BEGIN

		SET @chunklen = 4000 - DATALENGTH(@leftover) / 2
		SET @tmpstr = @leftover + SUBSTRING(@list, @textpos, @chunklen)
		SET @textpos = @textpos + @chunklen

		SET @startpos = 0
		SET @endpos = CHARINDEX(@delimiter COLLATE Slovenian_BIN2, @tmpstr)

		WHILE @endpos > 0
		BEGIN

			SET @tmpval = LTRIM(RTRIM(SUBSTRING(@tmpstr, @startpos + 1, @endpos - @startpos - 1)))

			INSERT @return_table (var_str, nvar_str) VALUES (@tmpval, @tmpval)

			SET @startpos = @endpos
			SET @endpos = CHARINDEX(@delimiter COLLATE Slovenian_BIN2, @tmpstr, @startpos + 1)
		
		END

		SET @leftover = RIGHT(@tmpstr, DATALENGTH(@tmpstr) / 2 - @startpos)

	END

	INSERT @return_table (var_str, nvar_str) VALUES (LTRIM(RTRIM(@leftover)), LTRIM(RTRIM(@leftover)))

	RETURN

END
GO
------------------------------------------------------


-- ######################################################END GENERAL PROCEDURES AND FUNCTIONS###################################################





-- ################################################TABLE "code_entity" OBJECTS######################################################
-- verifies if the code_entity table existss
IF OBJECT_ID('ums.code_entity', 'U') IS NOT NULL
	DROP TABLE ums.code_entity
GO

CREATE TABLE ums.code_entity 			
(
	code_entity_id varchar (50) NOT NULL 
		CONSTRAINT Code_Entity_Code_Entity_ID_PK PRIMARY KEY (code_entity_id)
		CONSTRAINT Code_Entity_Code_Entity_ID_CK CHECK (code_entity_id LIKE 'ETID%'),
	entity_description varchar (100) NOT NULL
		CONSTRAINT Code_Entity_Entity_Description_UQ UNIQUE (entity_description),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Code_Entity_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the code_entity table 
CREATE INDEX Code_Entity_Code_Entity_ID_Index
	ON ums.code_entity (code_entity_id ASC)
GO
------------------------------------------------------------------

-- verifies that the trigger "Code_Entity_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Code_Entity_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Code_Entity_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Code_Entity_Trigger_Instead_Update
	ON  ums.code_entity
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a code entity', 'Code Entity'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Code_Entity_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Code_Entity_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Code_Entity_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Code_Entity_Trigger_Instead_Delete
	ON  ums.code_entity
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a code entity', 'Code Entity'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectCodeEntity" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectCodeEntity')
   DROP PROCEDURE ums.SelectCodeEntity
GO

CREATE PROCEDURE ums.SelectCodeEntity
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			cdt.code_entity_id AS code_entity_id,
			cdt.entity_description AS entity_description
		FROM
			ums.code_entity AS cdt
		ORDER BY
			entity_description ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a code entity', 'Code Entity'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectCodeEntity TO db_umsusers
GO
-------------------------------------------------------------

-- ################################################END TABLE "code_entity" OBJECTS###################################################





-- ################################################TABLE "code_reference" OBJECTS######################################################
-- verifies if the code_reference table existss
IF OBJECT_ID('ums.code_reference', 'U') IS NOT NULL
	DROP TABLE ums.code_reference
GO

CREATE TABLE ums.code_reference 			
(
	code_reference_id varchar (50) NOT NULL
		CONSTRAINT Code_Reference_Code_Reference_ID_PK PRIMARY KEY (code_reference_id)
		CONSTRAINT Code_Reference_Code_Reference_ID_CK CHECK (code_reference_id LIKE 'CODE%'),
	code_entity_id varchar (50) NOT NULL 
		CONSTRAINT Code_Reference_Code_Entity_ID_FK FOREIGN KEY REFERENCES ums.code_entity(code_entity_id) ON UPDATE NO ACTION
		CONSTRAINT Code_Reference_Code_Entity_ID_UQ UNIQUE (code_entity_id, reference_code, code_description),
	reference_code varchar (50) NOT NULL
		CONSTRAINT Code_Reference_Reference_Code_UQ	UNIQUE (reference_code, code_entity_id, code_description),
	code_description varchar (100) NOT NULL
		CONSTRAINT Code_Reference_Code_Description_UQ UNIQUE (code_description, code_entity_id, reference_code),
	reference_flag tinyint NOT NULL DEFAULT (0),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Code_Reference_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the code_reference table 
CREATE INDEX Code_Reference_Code_Reference_ID_Index
	ON ums.code_reference (code_reference_id ASC)
GO
------------------------------------------------------------------

-- verifies that the trigger "Code_Reference_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Code_Reference_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Code_Reference_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Code_Reference_Trigger_Instead_Update
	ON  ums.code_reference
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a code reference', 'Code Reference'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Code_Reference_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Code_Reference_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Code_Reference_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Code_Reference_Trigger_Instead_Delete
	ON  ums.code_reference
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a code reference', 'Code Reference'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectCodeReference" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectCodeReference')
   DROP PROCEDURE ums.SelectCodeReference
GO

CREATE PROCEDURE ums.SelectCodeReference
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			crf.code_reference_id AS code_reference_id,
			crf.code_entity_id AS code_entity_id,
			crf.reference_code AS reference_code,
			crf.code_description AS code_description,
			crf.reference_flag AS reference_flag,
			cdt.entity_description AS entity_description
		FROM
			ums.code_reference AS crf
		INNER JOIN ums.code_entity AS cdt ON cdt.code_entity_id = crf.code_entity_id
		ORDER BY
			entity_description, code_description ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a code reference', 'Code Reference'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectCodeReference TO db_umsusers
GO
-------------------------------------------------------------

-- ################################################END TABLE "code_entity" OBJECTS###################################################




-- ################################################TABLE "department_information" OBJECTS######################################################
-- verifies if the department_information table existss
IF OBJECT_ID('ums.department_information', 'U') IS NOT NULL
	DROP TABLE ums.department_information
GO

CREATE TABLE ums.department_information 			
(
	department_id varchar (50) NOT NULL 
		CONSTRAINT Department_Information_Department_ID_PK PRIMARY KEY (department_id)
		CONSTRAINT Department_Information_Department_ID_CK CHECK (department_id LIKE 'DEPT%'),
	department_name varchar (100) NOT NULL
		CONSTRAINT Department_Information_Department_Name_UQ UNIQUE (department_name),
	acronym varchar (10) NULL
		CONSTRAINT Department_Information_Acronym_UQ UNIQUE (acronym),
	id_prefix varchar (20) NOT NULL
		CONSTRAINT Department_Information_ID_Prefix_UQ UNIQUE (id_prefix),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Department_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the department_information table 
CREATE INDEX Department_Information_Department_ID_Index
	ON ums.department_information (department_id ASC)
GO
------------------------------------------------------------------

-- verifies that the trigger "Department_Information_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Department_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Department_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Department_Information_Trigger_Instead_Update
	ON  ums.department_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a department information', 'Department Information'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Department_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Department_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Department_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Department_Information_Trigger_Instead_Delete
	ON  ums.department_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a department information', 'Department Information'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectDepartmentInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectDepartmentInformation')
   DROP PROCEDURE ums.SelectDepartmentInformation
GO

CREATE PROCEDURE ums.SelectDepartmentInformation
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			di.department_id AS department_id,
			di.department_name AS department_name,
			di.acronym AS acronym,
			di.id_prefix AS id_prefix
		FROM
			ums.department_information AS di
		ORDER BY di.department_name ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a deparment information', 'Department Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectDepartmentInformation TO db_umsusers
GO
-------------------------------------------------------------

-- ################################################END TABLE "department_information" OBJECTS###################################################






-- ################################################TABLE "system_access_rights" OBJECTS######################################################
-- verifies if the system_access_rights table exists
IF OBJECT_ID('ums.system_access_rights', 'U') IS NOT NULL
	DROP TABLE ums.system_access_rights
GO

CREATE TABLE ums.system_access_rights 			
(
	access_rights varchar (50) NOT NULL DEFAULT('')		
		CONSTRAINT System_Access_Rights_Access_Code_PK PRIMARY KEY (access_rights),
	access_index tinyint NOT NULL
		CONSTRAINT System_Access_Rights_Access_Index_UQ UNIQUE (access_index),
	access_description varchar (100) NOT NULL
		CONSTRAINT System_Access_Rights_Access_Description_UQ UNIQUE (access_description),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT System_Access_Rights_Unique_ID_UQ UNIQUE (unique_id)	
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- verifies that the trigger "System_Access_Rights_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.System_Access_Rights_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.System_Access_Rights_Trigger_Instead_Update
GO

CREATE TRIGGER ums.System_Access_Rights_Trigger_Instead_Update
	ON  ums.system_access_rights
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a system access rights', 'System Access Rights'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "System_Access_Rights_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.System_Access_Rights_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.System_Access_Rights_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.System_Access_Rights_Trigger_Instead_Delete
	ON  ums.system_access_rights
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a system access code', 'System Access Rights'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectSystemAccessRights" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectSystemAccessRights')
   DROP PROCEDURE ums.SelectSystemAccessRights
GO

CREATE PROCEDURE ums.SelectSystemAccessRights
	
	@system_user_id varchar(50) = ''
	
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT
			access_rights,
			access_index,
			access_description
		FROM
			ums.system_access_rights
		WHERE
			(NOT access_rights = '@T6&62W9Txw,.*%w9Tq2Uzo93r54Qe&34zAeiY&@')
		ORDER BY
			access_index ASC
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query system access rights', 'System Access Rights'
	END
	
GO
-------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectSystemAccessRights TO db_umsusers
GO
-------------------------------------------------------------

-- ##############################################END TABLE "system_access_rights" OBJECTS######################################################






-- ################################################TABLE "system_user_info" OBJECTS######################################################
-- verifies if the system_user_info table exists
IF OBJECT_ID('ums.system_user_info', 'U') IS NOT NULL
	DROP TABLE ums.system_user_info
GO

--USE THIS TO DETERMINE THE CHARACTERS THAT WILL BE ACCEPTED FOR THE USERNAME AND PASSWORD FIELD
--USE master
--GO
--
--SELECT number, char(number)
--FROM
--	spt_values
--WHERE type='p' AND number BETWEEN 1 AND 127
--AND CHAR(number) NOT LIKE '[^ -~0-z]'

CREATE TABLE ums.system_user_info 			
(
	system_user_id varchar (50) NOT NULL 
		CONSTRAINT System_User_Info_System_User_ID_PK PRIMARY KEY (system_user_id),
	system_user_name varchar (50) NOT NULL
		CONSTRAINT System_User_Info_System_User_Name_UQ UNIQUE (system_user_name)
		CONSTRAINT System_User_Info_System_User_Name_CK CHECK ((LEN(system_user_name) >= 6) AND (system_user_name NOT LIKE '%[^ -~0-z]%')),
	system_user_password varchar (50) NOT NULL
		CONSTRAINT System_User_Info_System_User_Password_CK CHECK ((LEN(system_user_password) >= 6) AND (system_user_password NOT LIKE '%[^ -~0-z]%')),
	system_user_status bit NOT NULL DEFAULT (0),		-- 1 - Access Grant  0 - Access Denied

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT System_User_Info_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT System_User_Info_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT System_User_Info_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the system_user_info table using system_user_id as index key
CREATE INDEX System_User_Info_System_User_ID_Index
	ON ums.system_user_info (system_user_id ASC)
GO
------------------------------------------------------------------

-- ###############################################END TABLE "system_user_info" OBJECTS###################################################





-- ################################################TABLE "access_rights_granted" OBJECTS######################################################
-- verifies if the access_rights_granted table exists
IF OBJECT_ID('ums.access_rights_granted', 'U') IS NOT NULL
	DROP TABLE ums.access_rights_granted
GO

CREATE TABLE ums.access_rights_granted 			
(
	rights_granted_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Access_Rights_Granted_ID_PK PRIMARY KEY (rights_granted_id),
	system_user_id varchar (50) NOT NULL
		CONSTRAINT Access_Rights_Granted_System_User_ID_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
		CONSTRAINT Access_Rights_Granted_System_User_ID_UQ UNIQUE (system_user_id, access_rights),
	access_rights varchar (50) NOT NULL 
		CONSTRAINT Access_Rights_Granted_Access_Rights_FK FOREIGN KEY REFERENCES ums.system_access_rights(access_rights) ON UPDATE NO ACTION
		CONSTRAINT Access_Rights_Granted_Access_Rights_UQ UNIQUE (access_rights, system_user_id),
	department_id varchar (50) NOT NULL
		CONSTRAINT Access_Rights_Granted_Department_ID_FK FOREIGN KEY REFERENCES ums.department_information(department_id) ON UPDATE NO ACTION,

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Access_Rights_Granted_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Access_Rights_Granted_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Access_Rights_Granted_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the access_rights_granted table 
CREATE INDEX Access_Rights_Granted_Rights_Granted_ID_Index
	ON ums.access_rights_granted (rights_granted_id ASC)
GO
------------------------------------------------------------------

-- verifies if the procedure "InsertAccessRightsGranted" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertAccessRightsGranted')
   DROP PROCEDURE ums.InsertAccessRightsGranted
GO

CREATE PROCEDURE ums.InsertAccessRightsGranted
	
	@system_user_id varchar (50) = '',
	@access_rights varchar (50) = '',
	@department_id varchar (50) = '',

	@network_information varchar(MAX) = '',
	@created_by varchar(50)
	
AS

	IF ums.IsSystemAdminSystemUserInfo(@created_by) = 1
	BEGIN

		IF EXISTS (SELECT system_user_id FROM ums.system_user_info WHERE (system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
															(system_user_id = @system_user_id) AND
															(system_user_status = 1)) AND
			EXISTS (SELECT access_rights FROM ums.system_access_rights WHERE (access_rights = @access_rights COLLATE SQL_Latin1_General_CP1_CS_AS) AND
																(access_rights = @access_rights))
		BEGIN

			EXECUTE ums.CreateTemporaryTable @created_by, @network_information

			INSERT INTO ums.access_rights_granted
			(
				system_user_id,
				access_rights,
				department_id,

				created_by
			)
			VALUES
			(
				@system_user_id,
				@access_rights,
				@department_id,

				@created_by
			)

		END

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert an access rights granted', 'Access Rights Granted'
	END
	
GO
-------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertAccessRightsGranted TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateAccessRightsGranted" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateAccessRightsGranted')
   DROP PROCEDURE ums.UpdateAccessRightsGranted
GO

CREATE PROCEDURE ums.UpdateAccessRightsGranted
	
	@rights_granted_id bigint = 0,
	@system_user_id varchar (50) = '',
	@access_rights varchar (50) = '',
	@department_id varchar (50) = '',

	@network_information varchar(MAX) = '',
	@edited_by varchar(50)
	
AS

	IF ums.IsSystemAdminSystemUserInfo(@edited_by) = 1
	BEGIN

		IF EXISTS (SELECT system_user_id FROM ums.system_user_info WHERE (system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
															(system_user_id = @system_user_id) AND
															(system_user_status = 1)) AND
			EXISTS (SELECT access_rights FROM ums.system_access_rights WHERE (access_rights = @access_rights COLLATE SQL_Latin1_General_CP1_CS_AS) AND
																(access_rights = @access_rights))
		BEGIN

			EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

			UPDATE ums.access_rights_granted SET
				department_id = @department_id,

				edited_by = @edited_by
			WHERE
				(system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
				(system_user_id = @system_user_id) AND
				(access_rights = @access_rights COLLATE SQL_Latin1_General_CP1_CS_AS) AND
				(access_rights = @access_rights) AND
				(rights_granted_id = @rights_granted_id)
		END

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update an access rights granted', 'Access Rights Granted'
	END
	
GO
-------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateAccessRightsGranted TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteAccessRightsGranted" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteAccessRightsGranted')
   DROP PROCEDURE ums.DeleteAccessRightsGranted
GO

CREATE PROCEDURE ums.DeleteAccessRightsGranted
	
	@rights_granted_id bigint = 0,
	@system_user_id varchar (50) = '',
	@access_rights varchar (50) = '',

	@network_information varchar(MAX) = '',
	@deleted_by varchar(50)
	
AS

	IF ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1
	BEGIN

		IF EXISTS (SELECT system_user_id FROM ums.system_user_info WHERE (system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
															(system_user_id = @system_user_id) AND
															(system_user_status = 1)) AND
			EXISTS (SELECT access_rights FROM ums.system_access_rights WHERE (access_rights = @access_rights COLLATE SQL_Latin1_General_CP1_CS_AS) AND
																(access_rights = @access_rights))
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.access_rights_granted SET
				edited_by = @deleted_by
			WHERE
				(system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
				(system_user_id = @system_user_id) AND
				(access_rights = @access_rights COLLATE SQL_Latin1_General_CP1_CS_AS) AND
				(access_rights = @access_rights) AND
				(rights_granted_id = @rights_granted_id)

			DELETE FROM ums.access_rights_granted
			WHERE
				(system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
				(system_user_id = @system_user_id) AND
				(access_rights = @access_rights COLLATE SQL_Latin1_General_CP1_CS_AS) AND
				(access_rights = @access_rights) AND
				(rights_granted_id = @rights_granted_id)
		END

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete an access rights granted', 'Access Rights Granted'
	END
	
GO
-------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteAccessRightsGranted TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectBySystemUserIdAccessRightsGranted" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySystemUserIdAccessRightsGranted')
   DROP PROCEDURE ums.SelectBySystemUserIdAccessRightsGranted
GO

CREATE PROCEDURE ums.SelectBySystemUserIdAccessRightsGranted
	
	@system_user_id varchar (50) = '',
	@system_user_name varchar(50) = '',
	@system_user_password varchar(50) = ''

AS
	SELECT
		arg.rights_granted_id AS rights_granted_id,		

		sar.access_index AS access_index,
		sar.access_description AS access_description,

		di.department_id AS department_id,
		di.department_name AS department_name,
		di.acronym AS acronym,
		di.id_prefix AS id_prefix
	FROM
		ums.access_rights_granted AS arg
	INNER JOIN ums.system_user_info AS sui ON sui.system_user_id = arg.system_user_id
	INNER JOIN ums.system_access_rights AS sar ON sar.access_rights = arg.access_rights
	INNER JOIN ums.department_information AS di ON di.department_id = arg.department_id
	WHERE 
		(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
		(sui.system_user_name = @system_user_name COLLATE SQL_Latin1_General_CP1_CS_AS) AND 
		(sui.system_user_password = @system_user_password COLLATE SQL_Latin1_General_CP1_CS_AS) AND
		(sui.system_user_id = @system_user_id) AND
		(sui.system_user_name = @system_user_name) AND
		(sui.system_user_password = @system_user_password) AND
		(sui.system_user_status = 1)	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySystemUserIdAccessRightsGranted TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectForUpdateAccessRightsGranted" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectForUpdateAccessRightsGranted')
   DROP PROCEDURE ums.SelectForUpdateAccessRightsGranted
GO

CREATE PROCEDURE ums.SelectForUpdateAccessRightsGranted
	
	@retrieve_system_user_id varchar (50) = '',

	@system_user_id varchar(50) = ''

AS

	IF ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1
	BEGIN

		SELECT
			arg.rights_granted_id AS rights_granted_id,		

			sar.access_index AS access_index,
			sar.access_rights AS access_rights,
			sar.access_description AS access_description,

			di.department_id AS department_id,
			di.department_name AS department_name,
			di.acronym AS acronym,
			di.id_prefix AS id_prefix
		FROM
			ums.access_rights_granted AS arg
		INNER JOIN ums.system_user_info AS sui ON sui.system_user_id = arg.system_user_id
		INNER JOIN ums.system_access_rights AS sar ON sar.access_rights = arg.access_rights
		INNER JOIN ums.department_information AS di ON di.department_id = arg.department_id
		WHERE 
			(sui.system_user_id = @retrieve_system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
			(sui.system_user_id = @retrieve_system_user_id) AND
			(sui.system_user_status = 1)	

	END
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectForUpdateAccessRightsGranted TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsSystemAdminSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsSystemAdminSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsSystemAdminSystemUserInfo
GO

CREATE FUNCTION ums.IsSystemAdminSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@c^jy#A*%ke_&yz!Ob0w%Pyg-Rt#l_$qiZ-Qt*m@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsPayrollMasterSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsPayrollMasterSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsPayrollMasterSystemUserInfo
GO

CREATE FUNCTION ums.IsPayrollMasterSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@8se%72jKl$yTb*-!dPqo[zAm<?!#aIqBza#d./@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsCollegeRegistrarSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsCollegeRegistrarSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsCollegeRegistrarSystemUserInfo
GO

CREATE FUNCTION ums.IsCollegeRegistrarSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@4Iw%&z_q${:,tY2*!9eZoY&+|uTqY<.wVx\aDe@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsHighSchoolGradeSchoolRegistrarSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo
GO

CREATE FUNCTION ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@y*Va1-$:}[2oPzNWi_^#/G!bYk~<U%+?gARt*C@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsOfficeUserSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsOfficeUserSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsOfficeUserSystemUserInfo
GO

CREATE FUNCTION ums.IsOfficeUserSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@7W_*xAuIz%qTm^rYmq!a38&z#s{>zX2*pUw[#Z@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsStudentDataControllerSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsStudentDataControllerSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsStudentDataControllerSystemUserInfo
GO

CREATE FUNCTION ums.IsStudentDataControllerSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@b&#jSxI;!^[Gy]wU_<.A*zYp:%$H~aPuE%cM=|@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsIDMakerSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsIDMakerSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsIDMakerSystemUserInfo
GO

CREATE FUNCTION ums.IsIDMakerSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@bT7*zi9_!,[QzPeR#=lSi-^38tPwxBm%2yM*yv@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsCashierSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsCashierSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsCashierSystemUserInfo
GO

CREATE FUNCTION ums.IsCashierSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@Lg+zT$`=,#uWb/pQi!2*5Rw4%zPiZ-!3qP:283@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsBookkeeperSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsBookkeeperSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsBookkeeperSystemUserInfo
GO

CREATE FUNCTION ums.IsBookkeeperSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@G[23#0zQ>/5TQ2_3R+|~23GbzO967#wT&w32:>@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsVpOfFinanceSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsVpOfFinanceSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsVpOfFinanceSystemUserInfo
GO

CREATE FUNCTION ums.IsVpOfFinanceSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@3T*7z_23!+Er+=45yUqP>;%*We23tYz0+<23&7@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------


-- verifies if the "IsGateKeepersSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsGateKeepersSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsGateKeepersSystemUserInfo
GO

CREATE FUNCTION ums.IsGateKeepersSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@u^c%Iq_!vBi*_.>:A{?^=_-QuZp|slTwoQ$*;X@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsSecretaryVpOfAcademicAffairsSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo
GO

CREATE FUNCTION ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@h74E*,:!#aE43Bm|~*gHaQp,Z*_=$^`;gcZm&9@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsVpOfAcademicAffairsSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsVpOfAcademicAffairsSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsVpOfAcademicAffairsSystemUserInfo
GO

CREATE FUNCTION ums.IsVpOfAcademicAffairsSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@oRwPc_+=tY/~\#zQ58!*$cPa:+Zy829xz;%^aG@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsStudentSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsStudentSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsStudentSystemUserInfo
GO

CREATE FUNCTION ums.IsStudentSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@Y6eRt#x_iOzP:qs172#4-3V,xe+23f7q9MwqUe@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsASPNETSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsASPNETSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsASPNETSystemUserInfo
GO

CREATE FUNCTION ums.IsASPNETSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@T6&62W9Txw,.*%w9Tq2Uzo93r54Qe&34zAeiY&@'))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsInstructorProfessorSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsInstructorProfessorSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsInstructorProfessorSystemUserInfo
GO

CREATE FUNCTION ums.IsInstructorProfessorSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(arg.access_rights = '@Uy5!xR2zP+nTf5*.GQ`|sR42*2XzMnu72$3p=2@'))					
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsActiveSystemUserInfo" function already exist
IF OBJECT_ID (N'ums.IsActiveSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.IsActiveSystemUserInfo
GO

CREATE FUNCTION ums.IsActiveSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT 
					sui.system_user_id 
				FROM 
					ums.system_user_info AS sui
				INNER JOIN ums.access_rights_granted AS arg ON arg.system_user_id = sui.system_user_id
				WHERE 
					(sui.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
					(sui.system_user_id = @system_user_id) AND
					(sui.system_user_status = 1) AND
					(NOT access_rights = '@Y6eRt#x_iOzP:qs172#4-3V,xe+23f7q9MwqUe@') AND		--not a student
					(NOT access_rights = '@T6&62W9Txw,.*%w9Tq2Uzo93r54Qe&34zAeiY&@') AND		--not ASP.NET
					(NOT access_rights = '@Uy5!xR2zP+nTf5*.GQ`|sR42*2XzMnu72$3p=2@'))			--not an instructor
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

/*verifies if the "GetAccessRightsDepartmentInfoSystemUserInfo" function already exist*/
IF OBJECT_ID (N'ums.GetAccessRightsDepartmentInfoSystemUserInfo') IS NOT NULL
   DROP FUNCTION ums.GetAccessRightsDepartmentInfoSystemUserInfo
GO

CREATE FUNCTION ums.GetAccessRightsDepartmentInfoSystemUserInfo
(	
	@system_user_id varchar(50) = ''
)
RETURNS varchar(MAX)
AS
BEGIN
	
	DECLARE @access_description varchar(MAX)

	SELECT 
		@access_description = COALESCE(@access_description + ', ', '') + sar.access_description + ' (' + di.department_name + ')'
	FROM 
		ums.access_rights_granted AS arg
	INNER JOIN ums.system_access_rights AS sar ON sar.access_rights = arg.access_rights
	INNER JOIN ums.department_information AS di ON di.department_id = arg.department_id
	WHERE
		(arg.system_user_id = @system_user_id COLLATE SQL_Latin1_General_CP1_CS_AS) AND
		(arg.system_user_id = @system_user_id)
		
	RETURN ISNULL(@access_description, '')

END
GO
--------------------------------------------------------

-- ###########################################END TABLE "access_rights_granted" OBJECTS######################################################






-- ###########################################TABLE "transaction_log" OBJECTS############################################################
-- verifies if the transaction_log table exists
IF OBJECT_ID('ums.transaction_log', 'U') IS NOT NULL
	DROP TABLE ums.transaction_log
GO
-----------------------------------------------------

-- creates the table "transaction_log"
CREATE TABLE ums.transaction_log
(
	transaction_id bigint NOT NULL IDENTITY (1,1) NOT FOR REPLICATION
		CONSTRAINT Transaction_Log_Transaction_ID_PK PRIMARY KEY (transaction_id),
	transaction_date datetime NOT NULL DEFAULT (GETDATE()),
	system_user_id varchar (50) NOT NULL 
		CONSTRAINT Transaction_Log_System_User_ID_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,	
	network_information varchar (MAX) NULL DEFAULT (''),
	transaction_done varchar (MAX) NOT NULL DEFAULT(''),
	access_description varchar (MAX) NOT NULL DEFAULT (''),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Transaction_Log_Unique_ID_UQ UNIQUE (unique_id)	
	
) ON [PRIMARY]
GO
-----------------------------------------------

-- create an index of the transaction_log table using cart_id as index key
CREATE INDEX Transaction_Log_Transaction_ID_Index
	ON ums.transaction_log (transaction_id DESC)
GO
-----------------------------------------------------------------

-- verifies that the trigger "Transaction_Log_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Transaction_Log_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Transaction_Log_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Transaction_Log_Trigger_Instead_Update
	ON  ums.transaction_log
	INSTEAD OF UPDATE 
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a record', 'Transaction Log'
	
GO
---------------------------------------------------------------------

-- verifies that the trigger "Transaction_Log_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Transaction_Log_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Transaction_Log_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Transaction_Log_Trigger_Instead_Delete
	ON  ums.transaction_log
	INSTEAD OF DELETE 
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a record', 'Transaction Log'
	
GO
---------------------------------------------------------------------

-- verifies if the procedure "InsertTransactionLog" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertTransactionLog')
   DROP PROCEDURE ums.InsertTransactionLog
GO

CREATE PROCEDURE ums.InsertTransactionLog
	
	@system_user_id varchar(50) = '',
	@network_information varchar (MAX) = '',
	@transaction_done varchar(MAX) = ''

AS

	INSERT INTO ums.transaction_log
	(
		system_user_id,
		network_information,
		transaction_done,
		access_description		
	)
	VALUES
	(
		@system_user_id,
		@network_information,
		@transaction_done,
		ums.GetAccessRightsDepartmentInfoSystemUserInfo(@system_user_id)
	)
	
GO
-------------------------------------------------------

-- ##########################################END TABLE "transaction_log" OBJECTS########################################################





-- ################################################TABLE "payroll_standard" OBJECTS######################################################
-- verifies if the payroll_standard table exists
IF OBJECT_ID('ums.payroll_standard', 'U') IS NOT NULL
	DROP TABLE ums.payroll_standard
GO

CREATE TABLE ums.payroll_standard 			
(
	sysid_payrollstd varchar (50) NOT NULL 
		CONSTRAINT Payroll_Standard_SysID_PayrollStd_PK PRIMARY KEY (sysid_payrollstd)
		CONSTRAINT Payroll_Standard_SysID_PayrollStd_CK CHECK (sysid_payrollstd LIKE 'SYSPSD%'),	
	effectivity_date datetime NOT NULL DEFAULT (GETDATE()),
	payroll_cutoff_day tinyint NOT NULL DEFAULT (1)
		CONSTRAINT Payroll_Standard_Payroll_Cutoff_Day_CK CHECK (payroll_cutoff_day >= 1 AND payroll_cutoff_day <= 28),	
		
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Payroll_Standard_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Payroll_Standard_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Payroll_Standard_Unique_ID_UQ UNIQUE (unique_id)	
	
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the payroll_standard table 
CREATE INDEX Payroll_Standard_SysID_PayrollStd_Index
	ON ums.payroll_standard (sysid_payrollstd DESC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Payroll_Standard_Trigger_Instead_Insert" already exist*/
IF OBJECT_ID ('ums.Payroll_Standard_Trigger_Instead_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Payroll_Standard_Trigger_Instead_Insert
GO

CREATE TRIGGER ums.Payroll_Standard_Trigger_Instead_Insert
	ON  ums.payroll_standard
	INSTEAD OF INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_payrollstd varchar (50)
	DECLARE @effectivity_date datetime
	DECLARE @payroll_cutoff_day tinyint
	DECLARE @created_by varchar (50)

	DECLARE @payroll_cutoff_day_b tinyint
	
	SELECT 
		@sysid_payrollstd = i.sysid_payrollstd,
		@effectivity_date = i.effectivity_date,
		@payroll_cutoff_day = i.payroll_cutoff_day,
		@created_by = i.created_by
	FROM INSERTED AS i

	SET @payroll_cutoff_day_b = 0

	SELECT
		@payroll_cutoff_day_b = payroll_cutoff_day
	FROM
		ums.payroll_standard
	WHERE
		effectivity_date = (SELECT MAX(effectivity_date) FROM ums.payroll_standard)

	IF (NOT @payroll_cutoff_day = @payroll_cutoff_day_b)
	BEGIN

		INSERT INTO ums.payroll_standard
		(
			sysid_payrollstd,
			effectivity_date,
			payroll_cutoff_day,
			created_by
		)
		VALUES
		(
			@sysid_payrollstd,
			@effectivity_date,
			@payroll_cutoff_day,
			@created_by
		)

		SET @transaction_done = 'CREATED a new payroll standard ' + 
								'[Standard ID: ' + ISNULL(@sysid_payrollstd, '') +
								'][Effectivity Date: ' + ISNULL((CONVERT(varchar, @effectivity_date, 101)), '') +
								'][Payroll Cut-off Day: ' + ISNULL((CONVERT(varchar, @payroll_cutoff_day)), '') +
								']'

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
		END
				
		EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

	END

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Payroll_Standard_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Payroll_Standard_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Payroll_Standard_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Payroll_Standard_Trigger_Instead_Update
	ON  ums.payroll_standard
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a payroll standard', 'Payroll Standard'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Payroll_Standard_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Payroll_Standard_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Payroll_Standard_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Payroll_Standard_Trigger_Instead_Delete
	ON  ums.payroll_standard
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a payroll standard', 'Payroll Standard'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "InsertPayrollStandard" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertPayrollStandard')
   DROP PROCEDURE ums.InsertPayrollStandard
GO

CREATE PROCEDURE ums.InsertPayrollStandard

	@sysid_payrollstd varchar (50) = '',
	@payroll_cutoff_day tinyint = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsVpOfFinanceSystemUserInfo(@created_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.payroll_standard
		(
			sysid_payrollstd,
			payroll_cutoff_day,
			created_by
		)
		VALUES
		(
			@sysid_payrollstd,
			@payroll_cutoff_day,
			@created_by
		)		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new payroll standard', 'Payroll Standard'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertPayrollStandard TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectPayrollStandard" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectPayrollStandard')
   DROP PROCEDURE ums.SelectPayrollStandard
GO

CREATE PROCEDURE ums.SelectPayrollStandard

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN
		
		SELECT 
			payroll_cutoff_day
		FROM 
			ums.payroll_standard
		WHERE
			effectivity_date = (SELECT MAX(effectivity_date) FROM ums.payroll_standard)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a payroll standard', 'Payroll Standard'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectPayrollStandard TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountPayrollStandard" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountPayrollStandard')
   DROP PROCEDURE ums.GetCountPayrollStandard
GO

CREATE PROCEDURE ums.GetCountPayrollStandard

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_payrollstd) FROM ums.payroll_standard
				
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a payroll standard', 'Payroll Standard'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountPayrollStandard TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsSysIDPayrollStandard" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsSysIDPayrollStandard')
   DROP PROCEDURE ums.IsExistsSysIDPayrollStandard
GO

CREATE PROCEDURE ums.IsExistsSysIDPayrollStandard

	@sysid_payrollstd varchar (50) = '',
	@system_user_id varchar (50) = ''	
		
AS
	
	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsSysIDPayrollStd(@sysid_payrollstd)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a payroll standard', 'Payroll Standard'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsSysIDPayrollStandard TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistsSysIDPayrollStd" function already exist
IF OBJECT_ID (N'ums.IsExistsSysIDPayrollStd') IS NOT NULL
   DROP FUNCTION ums.IsExistsSysIDPayrollStd
GO

CREATE FUNCTION ums.IsExistsSysIDPayrollStd
(	
	@sysid_payrollstd varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_payrollstd FROM ums.payroll_standard WHERE sysid_payrollstd = @sysid_payrollstd)
	BEGIN
		SET @result = 1
	END	
	
	RETURN @result
END
GO
------------------------------------------------------


-- #############################################END TABLE "payroll_standard" OBJECTS######################################################




-- ################################################TABLE "registrar_standard" OBJECTS######################################################
-- verifies if the registrar_standard table exists
IF OBJECT_ID('ums.registrar_standard', 'U') IS NOT NULL
	DROP TABLE ums.registrar_standard
GO

CREATE TABLE ums.registrar_standard 			
(
	sysid_registrarstd varchar (50) NOT NULL 
		CONSTRAINT Registrar_Standard_SysID_RegistrarStd_PK PRIMARY KEY (sysid_registrarstd)
		CONSTRAINT Registrar_Standard_SysID_RegistrarStd_CK CHECK (sysid_registrarstd LIKE 'SYSRSD%'),
	effectivity_date datetime NOT NULL DEFAULT (GETDATE()),
	school_year_start tinyint NOT NULL DEFAULT (6)
		CONSTRAINT Registrar_Standard_School_Year_Start_CK CHECK (school_year_start >= 1 AND school_year_start <= 12),
	semester_months tinyint NOT NULL DEFAULT (5)
		CONSTRAINT Registrar_Standard_Semester_Months_CK CHECK (semester_months >= 1 AND semester_months <= 5),
	summer_months tinyint NOT NULL DEFAULT (2)
		CONSTRAINT Registrar_Standard_Summer_Months_CK CHECK (summer_months >= 1 AND summer_months <= 2),
		
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Registrar_Standard_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Registrar_Standard_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Registrar_Standard_Unique_ID_UQ UNIQUE (unique_id)	
	
	
) ON [PRIMARY]
GO
----------------------------------------------------------------

-- create an index of the registrar_standard table 
CREATE INDEX Registrar_Standard_SysID_RegistrarStd_Index
	ON ums.registrar_standard (sysid_registrarstd DESC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Registrar_Standard_Trigger_Instead_Insert" already exist*/
IF OBJECT_ID ('ums.Registrar_Standard_Trigger_Instead_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Registrar_Standard_Trigger_Instead_Insert
GO

CREATE TRIGGER ums.Registrar_Standard_Trigger_Instead_Insert
	ON  ums.registrar_standard
	INSTEAD OF INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_registrarstd varchar (50)
	DECLARE @effectivity_date datetime
	DECLARE @school_year_start tinyint
	DECLARE @semester_months tinyint
	DECLARE @summer_months tinyint
	DECLARE @created_by varchar (50)

	DECLARE @school_year_start_b tinyint
	DECLARE @semester_months_b tinyint
	DECLARE @summer_months_b tinyint
	
	SELECT 
		@sysid_registrarstd = i.sysid_registrarstd,
		@effectivity_date = i.effectivity_date,
		@school_year_start = i.school_year_start,
		@semester_months = i.semester_months,
		@summer_months = i.summer_months,
		@created_by = i.created_by
	FROM INSERTED AS i	

	SET @school_year_start_b = 0
	SET @semester_months_b = 0
	SET @summer_months_b = 0

	SELECT
		@school_year_start_b = school_year_start,
		@semester_months_b = semester_months,
		@summer_months_b = summer_months
	FROM
		ums.registrar_standard
	WHERE
		effectivity_date = (SELECT MAX(effectivity_date) FROM ums.registrar_standard)

	IF (NOT @school_year_start = @school_year_start_b) OR
		(NOT @semester_months = @semester_months_b) OR
		(NOT @summer_months = @summer_months_b)
	BEGIN

		INSERT INTO ums.registrar_standard
		(
			sysid_registrarstd,
			effectivity_date,
			school_year_start,
			semester_months,
			summer_months,
			created_by
		)
		VALUES
		(
			@sysid_registrarstd,
			@effectivity_date,
			@school_year_start,
			@semester_months,
			@summer_months,
			@created_by
		)

		SET @transaction_done = 'CREATED a new registrar standard ' + 
							'[Standard ID: ' + ISNULL(@sysid_registrarstd, '') +
							'][Effectivity Date: ' + ISNULL((CONVERT(varchar, @effectivity_date, 101)), '') +
							'][School Year Month Start: ' + DATENAME(month, CONVERT(datetime, (CONVERT(varchar, @school_year_start) + 
									'/01/' + CONVERT(varchar, YEAR(GETDATE()))), 101)) +	
							'][Number of Semester Months: ' + ISNULL((CONVERT(varchar, @semester_months)), '') +
							'][Number of Summer Months: ' + + ISNULL((CONVERT(varchar, @summer_months)), '') +
							']'

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
		END
				
		EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	
		
	END		

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Registrar_Standard_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Registrar_Standard_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Registrar_Standard_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Registrar_Standard_Trigger_Instead_Update
	ON  ums.registrar_standard
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a registrar standard', 'Registrar Standard'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Registrar_Standard_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Registrar_Standard_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Registrar_Standard_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Registrar_Standard_Trigger_Instead_Delete
	ON  ums.registrar_standard
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a registrar standard', 'Registrar Standard'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "InsertRegistrarStandard" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertRegistrarStandard')
   DROP PROCEDURE ums.InsertRegistrarStandard
GO

CREATE PROCEDURE ums.InsertRegistrarStandard

	@sysid_registrarstd varchar (50) = '',
	@school_year_start tinyint = 0,
	@semester_months tinyint = 0,
	@summer_months tinyint = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@created_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.registrar_standard
		(
			sysid_registrarstd,
			school_year_start,
			semester_months,
			summer_months,
			created_by
		)
		VALUES
		(
			@sysid_registrarstd,
			@school_year_start,
			@semester_months,
			@summer_months,
			@created_by
		)		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new registrar standard', 'Registrar Standard'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertRegistrarStandard TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectRegistrarStandard" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectRegistrarStandard')
   DROP PROCEDURE ums.SelectRegistrarStandard
GO

CREATE PROCEDURE ums.SelectRegistrarStandard

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN
		
		SELECT 
			school_year_start, 
			semester_months, 
			summer_months 
		FROM 
			ums.registrar_standard
		WHERE
			effectivity_date = (SELECT MAX(effectivity_date) FROM ums.registrar_standard)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a registrar standard', 'Registrar Standard'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectRegistrarStandard TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountRegistarStandard" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountRegistarStandard')
   DROP PROCEDURE ums.GetCountRegistarStandard
GO

CREATE PROCEDURE ums.GetCountRegistarStandard

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_registrarstd) FROM ums.registrar_standard
				
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a registrar standard', 'Registrar Standard'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountRegistarStandard TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsSysIDRegistrarStandard" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsSysIDRegistrarStandard')
   DROP PROCEDURE ums.IsExistsSysIDRegistrarStandard
GO

CREATE PROCEDURE ums.IsExistsSysIDRegistrarStandard

	@sysid_registrarstd varchar (50) = '',
	@system_user_id varchar (50) = ''	
		
AS
	
	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsSysIDRegistrarStd(@sysid_registrarstd)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a registrar standard', 'Registrar Standard'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsSysIDRegistrarStandard TO db_umsusers
GO
-------------------------------------------------------------


-- verifies if the "IsExistsSysIDRegistrarStd" function already exist
IF OBJECT_ID (N'ums.IsExistsSysIDRegistrarStd') IS NOT NULL
   DROP FUNCTION ums.IsExistsSysIDRegistrarStd
GO

CREATE FUNCTION ums.IsExistsSysIDRegistrarStd
(	
	@sysid_registrarstd varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_registrarstd FROM ums.registrar_standard WHERE sysid_registrarstd = @sysid_registrarstd)
	BEGIN
		SET @result = 1
	END	
	
	RETURN @result
END
GO
------------------------------------------------------

-- #############################################END TABLE "registrar_standard" OBJECTS######################################################




-- ################################################TABLE "finance_standard" OBJECTS######################################################
-- verifies if the finance_standard table exists
IF OBJECT_ID('ums.finance_standard', 'U') IS NOT NULL
	DROP TABLE ums.finance_standard
GO

CREATE TABLE ums.finance_standard 			
(
	sysid_financestd varchar (50) NOT NULL 
		CONSTRAINT Finance_Standard_SysID_FinanceStd_PK PRIMARY KEY (sysid_financestd)
		CONSTRAINT Finance_Standard_SysID_FinanceStd_CK CHECK (sysid_financestd LIKE 'SYSFSD%'),	
	effectivity_date datetime NOT NULL DEFAULT (GETDATE()),
	international_percentage float (3) NOT NULL DEFAULT (0)
		CONSTRAINT Finance_Standard_International_Percentage_CK CHECK (international_percentage >= 0),
	enrolment_cutoff_day tinyint NOT NULL DEFAULT (1)
		CONSTRAINT Finance_Standard_Enrolment_Cutoff_Day_CK CHECK (enrolment_cutoff_day >= 1 AND enrolment_cutoff_day <= 28),
		
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Finance_Standard_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Finance_Standard_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Finance_Standard_Unique_ID_UQ UNIQUE (unique_id)	
	
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the finance_standard table 
CREATE INDEX Finance_Standard_SysID_FinanceStd_Index
	ON ums.finance_standard (sysid_financestd DESC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Finance_Standard_Trigger_Instead_Insert" already exist*/
IF OBJECT_ID ('ums.Finance_Standard_Trigger_Instead_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Finance_Standard_Trigger_Instead_Insert
GO

CREATE TRIGGER ums.Finance_Standard_Trigger_Instead_Insert
	ON  ums.finance_standard
	INSTEAD OF INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_financestd varchar (50)
	DECLARE @effectivity_date datetime
	DECLARE @international_percentage float
	DECLARE @enrolment_cutoff_day tinyint
	DECLARE @created_by varchar (50)

	DECLARE @international_percentage_b float
	DECLARE @enrolment_cutoff_day_b tinyint
	
	SELECT 
		@sysid_financestd = i.sysid_financestd,
		@effectivity_date = i.effectivity_date,
		@international_percentage = i.international_percentage,
		@enrolment_cutoff_day = i.enrolment_cutoff_day,
		@created_by = i.created_by
	FROM INSERTED AS i	

	SET @international_percentage_b = 0	
	SET @enrolment_cutoff_day_b = 0

	SELECT
		@international_percentage_b = international_percentage,
		@enrolment_cutoff_day_b = enrolment_cutoff_day
	FROM
		ums.finance_standard
	WHERE
		effectivity_date = (SELECT MAX(effectivity_date) FROM ums.finance_standard)

	IF (NOT @international_percentage = @international_percentage_b) OR
		(NOT @enrolment_cutoff_day = @enrolment_cutoff_day_b)
	BEGIN

		INSERT INTO ums.finance_standard
		(
			sysid_financestd,
			effectivity_date,
			international_percentage,
			enrolment_cutoff_day,
			created_by
		)
		VALUES
		(
			@sysid_financestd,
			@effectivity_date,
			@international_percentage,
			@enrolment_cutoff_day,
			@created_by
		)		

		SET @transaction_done = 'CREATED a new finance standard ' + 
								'[Standard ID: ' + ISNULL(@sysid_financestd, '') +
								'][Effectivity Date: ' + ISNULL((CONVERT(varchar, @effectivity_date, 101)), '') +
								'][International Student Percentage Increase: ' + ISNULL((CONVERT(varchar, @international_percentage)), '') +
								'][Enrolment Cut-off Day: ' + ISNULL((CONVERT(varchar, @enrolment_cutoff_day)), '') +	
								']'

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
		END
				
		EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

	END

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Finance_Standard_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Finance_Standard_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Finance_Standard_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Finance_Standard_Trigger_Instead_Update
	ON  ums.finance_standard
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a finance standard', 'Finance Standard'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Finance_Standard_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Finance_Standard_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Finance_Standard_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Finance_Standard_Trigger_Instead_Delete
	ON  ums.finance_standard
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a finance standard', 'Finance Standard'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "InsertFinanceStandard" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertFinanceStandard')
   DROP PROCEDURE ums.InsertFinanceStandard
GO

CREATE PROCEDURE ums.InsertFinanceStandard

	@sysid_financestd varchar (50) = '',
	@international_percentage float = 0,
	@enrolment_cutoff_day tinyint = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsVpOfFinanceSystemUserInfo(@created_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.finance_standard
		(
			sysid_financestd,
			international_percentage,
			enrolment_cutoff_day,
			created_by
		)
		VALUES
		(
			@sysid_financestd,
			@international_percentage,
			@enrolment_cutoff_day,
			@created_by
		)		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new finance standard', 'Finance Standard'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertFinanceStandard TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectFinanceStandard" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectFinanceStandard')
   DROP PROCEDURE ums.SelectFinanceStandard
GO

CREATE PROCEDURE ums.SelectFinanceStandard

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN
		
		SELECT 
			international_percentage,
			enrolment_cutoff_day
		FROM 
			ums.finance_standard
		WHERE
			effectivity_date = (SELECT MAX(effectivity_date) FROM ums.finance_standard)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a finance standard', 'Finance Standard'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectFinanceStandard TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountFinanceStandard" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountFinanceStandard')
   DROP PROCEDURE ums.GetCountFinanceStandard
GO

CREATE PROCEDURE ums.GetCountFinanceStandard

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) 
	BEGIN

		SELECT COUNT(sysid_financestd) FROM ums.finance_standard
				
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a finance standard', 'Finance Standard'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountFinanceStandard TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsSysIDFinanceStandard" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsSysIDFinanceStandard')
   DROP PROCEDURE ums.IsExistsSysIDFinanceStandard
GO

CREATE PROCEDURE ums.IsExistsSysIDFinanceStandard

	@sysid_financestd varchar (50) = '',
	@system_user_id varchar (50) = ''	
		
AS
	
	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) 
	BEGIN

		SELECT ums.IsExistsSysIDFinanceStd(@sysid_financestd)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a finance standard', 'Finance Standard'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsSysIDFinanceStandard TO db_umsusers
GO
-------------------------------------------------------------


-- verifies if the "IsExistsSysIDFinanceStd" function already exist
IF OBJECT_ID (N'ums.IsExistsSysIDFinanceStd') IS NOT NULL
   DROP FUNCTION ums.IsExistsSysIDFinanceStd
GO

CREATE FUNCTION ums.IsExistsSysIDFinanceStd
(	
	@sysid_financestd varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_financestd FROM ums.finance_standard WHERE sysid_financestd = @sysid_financestd)
	BEGIN
		SET @result = 1
	END	
	
	RETURN @result
END
GO
------------------------------------------------------


-- #############################################END TABLE "finance_standard" OBJECTS######################################################



-- ######################################RESTORE DEPENDENT TABLE CONSTRAINTS#############################################################


--verifies if the Rank_Salary_Rate_Created_By_FK constraint exists
IF OBJECT_ID('ums.rank_salary_rate', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.rank_salary_rate WITH NOCHECK
	ADD CONSTRAINT Rank_Salary_Rate_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Rank_Salary_Rate_Edited_By_FK constraint exists
IF OBJECT_ID('ums.rank_salary_rate', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.rank_salary_rate WITH NOCHECK
	ADD CONSTRAINT Rank_Salary_Rate_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Sss_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.sss_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.sss_information WITH NOCHECK
	ADD CONSTRAINT Sss_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Sss_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.sss_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.sss_information WITH NOCHECK
	ADD CONSTRAINT Sss_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Sss_Range_Created_By_FK constraint exists--
IF OBJECT_ID('ums.sss_range', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.sss_range WITH NOCHECK
	ADD CONSTRAINT Sss_Range_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Sss_Range_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.sss_range', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.sss_range WITH NOCHECK
	ADD CONSTRAINT Sss_Range_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the PhilHealth_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.philhealth_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.philhealth_information WITH NOCHECK
	ADD CONSTRAINT PhilHealth_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the PhilHealth_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.philhealth_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.philhealth_information WITH NOCHECK
	ADD CONSTRAINT PhilHealth_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the PhilHealth_Range_Created_By_FK constraint exists--
IF OBJECT_ID('ums.philhealth_range', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.philhealth_range WITH NOCHECK
	ADD CONSTRAINT PhilHealth_Range_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the PhilHealth_Range_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.philhealth_range', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.philhealth_range WITH NOCHECK
	ADD CONSTRAINT PhilHealth_Range_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the Employee_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.employee_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_information WITH NOCHECK
	ADD CONSTRAINT Employee_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Person_Information_Life_Status_Code_FK constraint exists--
IF OBJECT_ID('ums.person_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_information WITH NOCHECK
	ADD CONSTRAINT Person_Information_Life_Status_Code_FK FOREIGN KEY (life_status_code) REFERENCES ums.code_reference(code_reference_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the Person_Information_Gender_Code_FK constraint exists--
IF OBJECT_ID('ums.person_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_information WITH NOCHECK
	ADD CONSTRAINT Person_Information_Gender_Code_FK FOREIGN KEY (gender_code) REFERENCES ums.code_reference(code_reference_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the Person_Information_Marital_Status_Code_FK constraint exists--
IF OBJECT_ID('ums.person_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_information WITH NOCHECK
	ADD CONSTRAINT Person_Information_Marital_Status_Code_FK FOREIGN KEY (marital_status_code) REFERENCES ums.code_reference(code_reference_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the Person_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.person_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_information WITH NOCHECK
	ADD CONSTRAINT Person_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the Person_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.person_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_information WITH NOCHECK
	ADD CONSTRAINT Person_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the Person_Image_Created_By_FK constraint exists--
IF OBJECT_ID('ums.person_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_image WITH NOCHECK
	ADD CONSTRAINT Person_Image_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the Person_Image_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.person_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_image WITH NOCHECK
	ADD CONSTRAINT Person_Image_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Employee_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.employee_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_information WITH NOCHECK
	ADD CONSTRAINT Employee_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the School_Year_Created_By_FK constraint exists
IF OBJECT_ID('ums.school_year', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_year WITH NOCHECK
	ADD CONSTRAINT School_Year_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the School_Year_Edited_By_FK constraint exists
IF OBJECT_ID('ums.school_year', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_year WITH NOCHECK
	ADD CONSTRAINT School_Year_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Salary_Information_Department_ID_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information WITH NOCHECK
	ADD CONSTRAINT Salary_Information_Department_ID_FK FOREIGN KEY (department_id) REFERENCES ums.department_information(department_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Salary_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information WITH NOCHECK
	ADD CONSTRAINT Salary_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Salary_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information WITH NOCHECK
	ADD CONSTRAINT Salary_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Deduction_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.deduction_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.deduction_information WITH NOCHECK
	ADD CONSTRAINT Deduction_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Deduction_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.deduction_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.deduction_information WITH NOCHECK
	ADD CONSTRAINT Deduction_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Employee_Deduction_Created_By_FK constraint exists--
IF OBJECT_ID('ums.employee_deduction', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_deduction WITH NOCHECK
	ADD CONSTRAINT Employee_Deduction_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Employee_Deduction_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.employee_deduction', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_deduction WITH NOCHECK
	ADD CONSTRAINT Employee_Deduction_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Earning_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.earning_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.earning_information WITH NOCHECK
	ADD CONSTRAINT Earning_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Earning_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.earning_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.earning_information WITH NOCHECK
	ADD CONSTRAINT Earning_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Employee_Earning_Created_By_FK constraint exists--
IF OBJECT_ID('ums.employee_earning', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_earning WITH NOCHECK
	ADD CONSTRAINT Employee_Earning_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Employee_Earning_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.employee_earning', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_earning WITH NOCHECK
	ADD CONSTRAINT Employee_Earning_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Loan_Type_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.loan_type_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_type_information WITH NOCHECK
	ADD CONSTRAINT Loan_Type_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Loan_Type_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.loan_type_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_type_information WITH NOCHECK
	ADD CONSTRAINT Loan_Type_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Loan_Remittance_Created_By_FK constraint exists--
IF OBJECT_ID('ums.loan_remittance', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_remittance WITH NOCHECK
	ADD CONSTRAINT Loan_Remittance_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Loan_Remittance_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.loan_remittance', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_remittance WITH NOCHECK
	ADD CONSTRAINT Loan_Remittance_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Loan_Remittance_Audit_Deleted_By_FK constraint exists--
IF OBJECT_ID('ums.loan_remittance_audit', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_remittance_audit WITH NOCHECK
	ADD CONSTRAINT Loan_Remittance_Audit_Deleted_By_FK FOREIGN KEY (deleted_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Employee_Remittance_Created_By_FK constraint exists--
IF OBJECT_ID('ums.employee_remittance', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_remittance WITH NOCHECK
	ADD CONSTRAINT Employee_Remittance_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Employee_Remittance_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.employee_remittance', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_remittance WITH NOCHECK
	ADD CONSTRAINT Employee_Remittance_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Semester_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.semester_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.semester_information WITH NOCHECK
	ADD CONSTRAINT Semester_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Semester_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.semester_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.semester_information WITH NOCHECK
	ADD CONSTRAINT Semester_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Classroom_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.classroom_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.classroom_information WITH NOCHECK
	ADD CONSTRAINT Classroom_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Classroom_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.classroom_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.classroom_information WITH NOCHECK
	ADD CONSTRAINT Classroom_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Subject_Information_Department_ID_FK constraint exists
IF OBJECT_ID('ums.subject_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_information WITH NOCHECK
	ADD CONSTRAINT Subject_Information_Department_ID_FK FOREIGN KEY (department_id) REFERENCES ums.department_information(department_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Subject_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.subject_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_information WITH NOCHECK
	ADD CONSTRAINT Subject_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Subject_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.subject_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_information WITH NOCHECK
	ADD CONSTRAINT Subject_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Subject_Prerequisite_Created_By_FK constraint exists
IF OBJECT_ID('ums.subject_prerequisite', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_prerequisite WITH NOCHECK
	ADD CONSTRAINT Subject_Prerequisite_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Subject_Prerequisite_Edited_By_FK constraint exists
IF OBJECT_ID('ums.subject_prerequisite', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_prerequisite WITH NOCHECK
	ADD CONSTRAINT Subject_Prerequisite_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Course_Information_Department_ID_FK constraint exists
IF OBJECT_ID('ums.course_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_information WITH NOCHECK
	ADD CONSTRAINT Course_Information_Department_ID_FK FOREIGN KEY (department_id) REFERENCES ums.department_information(department_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Course_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.course_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_information WITH NOCHECK
	ADD CONSTRAINT Course_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Course_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.course_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_information WITH NOCHECK
	ADD CONSTRAINT Course_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------



--verifies if the Course_Major_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.course_major_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_major_information WITH NOCHECK
	ADD CONSTRAINT Course_Major_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Course_Major_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.course_major_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_major_information WITH NOCHECK
	ADD CONSTRAINT Course_Major_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Course_Year_Level_Created_By_FK constraint exists
IF OBJECT_ID('ums.course_year_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_year_level WITH NOCHECK
	ADD CONSTRAINT Course_Year_Level_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Course_Year_Level_Edited_By_FK constraint exists
IF OBJECT_ID('ums.course_year_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_year_level WITH NOCHECK
	ADD CONSTRAINT Course_Year_Level_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_information WITH NOCHECK
	ADD CONSTRAINT Student_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_information WITH NOCHECK
	ADD CONSTRAINT Student_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Image_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_image WITH NOCHECK
	ADD CONSTRAINT Student_Image_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Image_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_image WITH NOCHECK
	ADD CONSTRAINT Student_Image_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Special_Class_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.special_class_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_information WITH NOCHECK
	ADD CONSTRAINT Special_Class_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Special_Class_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.special_class_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_information WITH NOCHECK
	ADD CONSTRAINT Special_Class_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Special_Class_Load_Created_By_FK constraint exists
IF OBJECT_ID('ums.special_class_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_load WITH NOCHECK
	ADD CONSTRAINT Special_Class_Load_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Special_Class_Load_Edited_By_FK constraint exists
IF OBJECT_ID('ums.special_class_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_load WITH NOCHECK
	ADD CONSTRAINT Special_Class_Load_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.schedule_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information WITH NOCHECK
	ADD CONSTRAINT Schedule_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.schedule_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information WITH NOCHECK
	ADD CONSTRAINT Schedule_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_Details_Created_By_FK constraint exists
IF OBJECT_ID('ums.schedule_information_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information_details WITH NOCHECK
	ADD CONSTRAINT Schedule_Information_Details_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_Details_Edited_By_FK constraint exists
IF OBJECT_ID('ums.schedule_information_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information_details WITH NOCHECK
	ADD CONSTRAINT Schedule_Information_Details_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------


--verifies if the Subject_Schedule_Created_By_FK constraint exists
IF OBJECT_ID('ums.subject_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_schedule WITH NOCHECK
	ADD CONSTRAINT Subject_Schedule_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Subject_Schedule_Edited_By_FK constraint exists
IF OBJECT_ID('ums.subject_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_schedule WITH NOCHECK
	ADD CONSTRAINT Subject_Schedule_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Information_Department_ID_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_information WITH NOCHECK
	ADD CONSTRAINT Auxiliary_Service_Information_Department_ID_FK FOREIGN KEY (department_id) REFERENCES ums.department_information(department_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_information WITH NOCHECK
	ADD CONSTRAINT Auxiliary_Service_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_information WITH NOCHECK
	ADD CONSTRAINT Auxiliary_Service_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Schedule_Created_By_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_schedule WITH NOCHECK
	ADD CONSTRAINT Auxiliary_Service_Schedule_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Schedule_Edited_By_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_schedule WITH NOCHECK
	ADD CONSTRAINT Auxiliary_Service_Schedule_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Details_Created_By_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_details WITH NOCHECK
	ADD CONSTRAINT Auxiliary_Service_Details_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Details_Edited_By_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_details WITH NOCHECK
	ADD CONSTRAINT Auxiliary_Service_Details_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------


--verifies if the Teacher_Load_Created_By_FK constraint exists
IF OBJECT_ID('ums.teacher_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.teacher_load WITH NOCHECK
	ADD CONSTRAINT Teacher_Load_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Teacher_Load_Edited_By_FK constraint exists
IF OBJECT_ID('ums.teacher_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.teacher_load WITH NOCHECK
	ADD CONSTRAINT Teacher_Load_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the Student_Load_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_load WITH NOCHECK
	ADD CONSTRAINT Student_Load_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the Student_Load_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_load WITH NOCHECK
	ADD CONSTRAINT Student_Load_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the School_Fee_Particular_Created_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_particular', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_particular WITH NOCHECK
	ADD CONSTRAINT School_Fee_Particular_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Particular_Edited_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_particular', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_particular WITH NOCHECK
	ADD CONSTRAINT School_Fee_Particular_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_information WITH NOCHECK
	ADD CONSTRAINT School_Fee_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_information WITH NOCHECK
	ADD CONSTRAINT School_Fee_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Level_Created_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_level WITH NOCHECK
	ADD CONSTRAINT School_Fee_Level_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Level_Edited_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_level WITH NOCHECK
	ADD CONSTRAINT School_Fee_Level_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Course_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_course', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_course WITH NOCHECK
	ADD CONSTRAINT Student_Enrolment_Course_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Course_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_course', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_course WITH NOCHECK
	ADD CONSTRAINT Student_Enrolment_Course_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Level_SysID_FinanceStd_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_level WITH NOCHECK
	ADD CONSTRAINT Student_Enrolment_Level_SysID_FinanceStd_FK FOREIGN KEY (sysid_financestd) REFERENCES ums.finance_standard(sysid_financestd) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Level_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_level WITH NOCHECK
	ADD CONSTRAINT Student_Enrolment_Level_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Level_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_level WITH NOCHECK
	ADD CONSTRAINT Student_Enrolment_Level_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Details_Created_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_details WITH NOCHECK
	ADD CONSTRAINT School_Fee_Details_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Details_Edited_By_FK constraint exists
IF OBJECT_ID('ums.school_fee_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_details WITH NOCHECK
	ADD CONSTRAINT School_Fee_Details_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Additional_Fee_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_additional_fee', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_additional_fee WITH NOCHECK
	ADD CONSTRAINT Student_Additional_Fee_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Additional_Fee_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_additional_fee', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_additional_fee WITH NOCHECK
	ADD CONSTRAINT Student_Additional_Fee_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Optional_Fee_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_optional_fee', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_optional_fee WITH NOCHECK
	ADD CONSTRAINT Student_Optional_Fee_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Optional_Fee_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_optional_fee', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_optional_fee WITH NOCHECK
	ADD CONSTRAINT Student_Optional_Fee_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Payments_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_payments', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_payments WITH NOCHECK
	ADD CONSTRAINT Student_Payments_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Payments_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_payments', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_payments WITH NOCHECK
	ADD CONSTRAINT Student_Payments_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Scholarship_Information_Department_ID_FK constraint exists
IF OBJECT_ID('ums.scholarship_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.scholarship_information WITH NOCHECK
	ADD CONSTRAINT Scholarship_Information_Department_ID_FK FOREIGN KEY (department_id) REFERENCES ums.department_information(department_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Scholarship_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.scholarship_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.scholarship_information WITH NOCHECK
	ADD CONSTRAINT Scholarship_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Scholarship_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.scholarship_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.scholarship_information WITH NOCHECK
	ADD CONSTRAINT Scholarship_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Scholarship_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_scholarship', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_scholarship WITH NOCHECK
	ADD CONSTRAINT Student_Scholarship_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Scholarship_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_scholarship', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_scholarship WITH NOCHECK
	ADD CONSTRAINT Student_Scholarship_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Discounts_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_discounts', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_discounts WITH NOCHECK
	ADD CONSTRAINT Student_Discounts_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Discounts_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_discounts', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_discounts WITH NOCHECK
	ADD CONSTRAINT Student_Discounts_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Reimbursements_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_reimbursements', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_reimbursements WITH NOCHECK
	ADD CONSTRAINT Student_Reimbursements_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Reimbursements_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_reimbursements', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_reimbursements WITH NOCHECK
	ADD CONSTRAINT Student_Reimbursements_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Credit_Memo_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_credit_memo', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_credit_memo WITH NOCHECK
	ADD CONSTRAINT Student_Credit_Memo_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Credit_Memo_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_credit_memo', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_credit_memo WITH NOCHECK
	ADD CONSTRAINT Student_Credit_Memo_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Promissory_Note_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_promissory_note', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_promissory_note WITH NOCHECK
	ADD CONSTRAINT Student_Promissory_Note_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Promissory_Note_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_promissory_note', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_promissory_note WITH NOCHECK
	ADD CONSTRAINT Student_Promissory_Note_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Cancelled_Receipt_No_Created_By_FK constraint exists
IF OBJECT_ID('ums.cancelled_receipt_no', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.cancelled_receipt_no WITH NOCHECK
	ADD CONSTRAINT Cancelled_Receipt_No_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Cancelled_Receipt_No_Edited_By_FK constraint exists
IF OBJECT_ID('ums.cancelled_receipt_no', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.cancelled_receipt_no WITH NOCHECK
	ADD CONSTRAINT Cancelled_Receipt_No_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Balance_Forwarded_Created_By_FK constraint exists
IF OBJECT_ID('ums.student_balance_forwarded', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_balance_forwarded WITH NOCHECK
	ADD CONSTRAINT Student_Balance_Forwarded_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Balance_Forwarded_Edited_By_FK constraint exists
IF OBJECT_ID('ums.student_balance_forwarded', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_balance_forwarded WITH NOCHECK
	ADD CONSTRAINT Student_Balance_Forwarded_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Major_Exam_Schedule_Created_By_FK constraint exists
IF OBJECT_ID('ums.major_exam_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.major_exam_schedule WITH NOCHECK
	ADD CONSTRAINT Major_Exam_Schedule_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Major_Exam_Schedule_Edited_By_FK constraint exists
IF OBJECT_ID('ums.major_exam_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.major_exam_schedule WITH NOCHECK
	ADD CONSTRAINT Major_Exam_Schedule_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Enrolment_Course_Major_Created_By_FK constraint exists
IF OBJECT_ID('ums.enrolment_course_major', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.enrolment_course_major WITH NOCHECK
	ADD CONSTRAINT Enrolment_Course_Major_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------	

--verifies if the Enrolment_Course_Major_Edited_By_FK constraint exists
IF OBJECT_ID('ums.enrolment_course_major', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.enrolment_course_major WITH NOCHECK
	ADD CONSTRAINT Enrolment_Course_Major_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Person_Relationship_Information_Created_By_FK constraint exists--
IF OBJECT_ID('ums.person_relationship_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_relationship_information WITH NOCHECK
	ADD CONSTRAINT Person_Relationship_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Person_Relationship_Information_Edited_By_FK constraint exists--
IF OBJECT_ID('ums.person_relationship_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.person_relationship_information WITH NOCHECK
	ADD CONSTRAINT Person_Relationship_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Transcript_Information_Created_By_FK constraint exists
IF OBJECT_ID('ums.transcript_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_information WITH NOCHECK
	ADD CONSTRAINT Transcript_Information_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Transcript_Information_Edited_By_FK constraint exists
IF OBJECT_ID('ums.transcript_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_information WITH NOCHECK
	ADD CONSTRAINT Transcript_Information_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Transcript_Image_Created_By_FK constraint exists
IF OBJECT_ID('ums.transcript_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_image WITH NOCHECK
	ADD CONSTRAINT Transcript_Image_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Transcript_Image_Edited_By_FK constraint exists
IF OBJECT_ID('ums.transcript_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_image WITH NOCHECK
	ADD CONSTRAINT Transcript_Image_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Transcript_Details_Created_By_FK constraint exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_details WITH NOCHECK
	ADD CONSTRAINT Transcript_Details_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Transcript_Details_Edited_By_FK constraint exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_details WITH NOCHECK
	ADD CONSTRAINT Transcript_Details_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Campus_Access_Details_Created_By_FK constraint exists
IF OBJECT_ID('ums.campus_access_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.campus_access_details WITH NOCHECK
	ADD CONSTRAINT Campus_Access_Details_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Campus_Access_Details_Edited_By_FK constraint exists
IF OBJECT_ID('ums.campus_access_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.campus_access_details WITH NOCHECK
	ADD CONSTRAINT Campus_Access_Details_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Chart_Of_Accounts_Created_By_FK constraint exists
IF OBJECT_ID('ums.chart_of_accounts', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.chart_of_accounts WITH NOCHECK
	ADD CONSTRAINT Chart_Of_Accounts_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Chart_Of_Accounts_Edited_By_FK constraint exists
IF OBJECT_ID('ums.chart_of_accounts', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.chart_of_accounts WITH NOCHECK
	ADD CONSTRAINT Chart_Of_Accounts_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Miscellaneous_Income_Created_By_FK constraint exists
IF OBJECT_ID('ums.miscellaneous_income', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.miscellaneous_income WITH NOCHECK
	ADD CONSTRAINT Miscellaneous_Income_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Miscellaneous_Income_Edited_By_FK constraint exists
IF OBJECT_ID('ums.miscellaneous_income', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.miscellaneous_income WITH NOCHECK
	ADD CONSTRAINT Miscellaneous_Income_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Breakdown_Bank_Deposit_Created_By_FK constraint exists
IF OBJECT_ID('ums.breakdown_bank_deposit', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.breakdown_bank_deposit WITH NOCHECK
	ADD CONSTRAINT Breakdown_Bank_Deposit_Created_By_FK FOREIGN KEY (created_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Breakdown_Bank_Deposit_Edited_By_FK constraint exists
IF OBJECT_ID('ums.breakdown_bank_deposit', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.breakdown_bank_deposit WITH NOCHECK
	ADD CONSTRAINT Breakdown_Bank_Deposit_Edited_By_FK FOREIGN KEY (edited_by) REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------


-- ###################################END RESTORE DEPENDENT TABLE CONSTRAINTS############################################################



-- ############################################INITIAL DATABASE INFORMATION#############################################################

-- for system_access_code
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@c^jy#A*%ke_&yz!Ob0w%Pyg-Rt#l_$qiZ-Qt*m@', 0, 'System Administrator')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@8se%72jKl$yTb*-!dPqo[zAm<?!#aIqBza#d./@', 1, 'Payroll Master')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@7W_*xAuIz%qTm^rYmq!a38&z#s{>zX2*pUw[#Z@', 2, 'Office User')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@4Iw%&z_q${:,tY2*!9eZoY&+|uTqY<.wVx\aDe@', 3, 'College Registrar')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@y*Va1-$:}[2oPzNWi_^#/G!bYk~<U%+?gARt*C@', 4, 'HS/GS Registrar')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@b&#jSxI;!^[Gy]wU_<.A*zYp:%$H~aPuE%cM=|@', 5, 'Student''s Data Controller')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@bT7*zi9_!,[QzPeR#=lSi-^38tPwxBm%2yM*yv@', 6, 'ID Maker')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@u^c%Iq_!vBi*_.>:A{?^=_-QuZp|slTwoQ$*;X@', 7, 'GateKeepers')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@Lg+zT$`=,#uWb/pQi!2*5Rw4%zPiZ-!3qP:283@', 8, 'Cashier')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@G[23#0zQ>/5TQ2_3R+|~23GbzO967#wT&w32:>@', 9, 'Bookkeeper')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@3T*7z_23!+Er+=45yUqP>;%*We23tYz0+<23&7@', 10, 'VP of Finance Affairs')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@h74E*,:!#aE43Bm|~*gHaQp,Z*_=$^`;gcZm&9@', 11, 'Secretary of the VP of Academic Affairs')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@oRwPc_+=tY/~\#zQ58!*$cPa:+Zy829xz;%^aG@', 12, 'VP of Academic Affairs')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@Y6eRt#x_iOzP:qs172#4-3V,xe+23f7q9MwqUe@', 13, 'Student')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@T6&62W9Txw,.*%w9Tq2Uzo93r54Qe&34zAeiY&@', 14, 'ASP.NET')
INSERT INTO ums.system_access_rights(access_rights, access_index, access_description) VALUES ('@Uy5!xR2zP+nTf5*.GQ`|sR42*2XzMnu72$3p=2@', 15, 'Instructor/Professor')
GO

-- ums.department_information
-- is used to determine what department the employee, system user and a subject belongs
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT001', 'Information Communication Technology', 'ICT', 'ICT')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT002', 'Arts and Education', 'CAED', 'A')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT003', 'Business Education', 'CBED', 'B')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT004', 'Canteen', 'C', 'C')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT005', 'Document and Data Control Center', 'D', 'D')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT006', 'EDP', 'E', 'E')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT007', 'Faculty', 'F', 'F')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT008', 'Grade School', 'G.S.', 'G')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT009', 'High School', 'H.S.', 'H')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT010', 'Information', 'I', 'I')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT011', 'Christian Formation Office', 'CFO', 'J')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT012', 'Medical', 'K', 'K')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT013', 'Lay Administrator', 'L', 'L')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT014', 'Maintenance', 'M', 'M')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT015', 'Nursing', 'CN', 'N')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT016', 'Graduate School', 'Grad. Sch.', 'O')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT017', 'President''s Office', 'P', 'P')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT018', 'Finance', 'Q', 'Q')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT019', 'Registrar', 'R', 'R')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT020', 'Staff', 'S', 'S')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT021', 'Administrative VP', 'T', 'T')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT022', 'Community Extension Services', 'U', 'U')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT023', 'Research Office', 'V', 'V')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT024', 'Academic Non-Teaching', 'W', 'W')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT025', 'Academic VP', 'X', 'X')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT026', 'Guidance', 'Y', 'Y')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT027', 'Library (College)', 'Zc', 'Zc')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT028', 'Library (High School)', 'Zh', 'Zh')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT029', 'Library (Grade School)', 'Zg', 'Zg')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT030', 'Science Laboratory (College)', 'SLc', 'SLc')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT031', 'Science Laboratory (High School)', 'SLh', 'SLh')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT032', 'Science Laboratory (Grade School)', 'SLg', 'SLg')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT033', 'Tech. Lab. (College)', 'TLc', 'TLc')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT034', 'Tech. Lab. (High School)', 'TLh', 'TLh')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT035', 'Tech. Lab. (Grade School)', 'TLg', 'TLg')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT036', 'Alumni', 'AL', 'AL')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT037', 'Dormitory', 'DO', 'DO')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT038', 'Religious Administrators', 'RA', 'RA')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT039', 'Security Guard', 'SG', 'SG')
INSERT INTO ums.department_information(department_id, department_name, acronym, id_prefix) VALUES ('DEPT040', 'Agency Personnel', 'AP', 'AP')
GO

-- verifies that the trigger "System_User_Info_Trigger_Instead_Insert" already exist
IF OBJECT_ID ('ums.System_User_Info_Trigger_Instead_Insert','TR') IS NOT NULL
   DISABLE TRIGGER ums.System_User_Info_Trigger_Instead_Insert ON ums.system_user_info
GO
-- verifies that the trigger "Access_Rights_Granted_Trigger_Insert" already exist
IF OBJECT_ID ('ums.Access_Rights_Granted_Trigger_Insert','TR') IS NOT NULL
   DISABLE TRIGGER ums.Access_Rights_Granted_Trigger_Insert ON ums.access_rights_granted
GO

INSERT INTO ums.system_user_info(system_user_id, system_user_name, system_user_password, system_user_status, created_by)
	VALUES ('#K8@-+rYz&^s!@N!=|iKk!$H@jM#', 'Judyll', 'co0408de', 1, '#K8@-+rYz&^s!@N!=|iKk!$H@jM#')
INSERT INTO ums.access_rights_granted(system_user_id, access_rights, department_id, created_by)
	VALUES ('#K8@-+rYz&^s!@N!=|iKk!$H@jM#', '@c^jy#A*%ke_&yz!Ob0w%Pyg-Rt#l_$qiZ-Qt*m@', 'DEPT001', '#K8@-+rYz&^s!@N!=|iKk!$H@jM#')

INSERT INTO ums.system_user_info(system_user_id, system_user_name, system_user_password, system_user_status, created_by)
	VALUES ('#Tuy@i*2sz@kUw-2!us%WBxYzwP#', 'Initi@lD@t@', '?r0gr@mm3r', 1, '#K8@-+rYz&^s!@N!=|iKk!$H@jM#')
INSERT INTO ums.access_rights_granted(system_user_id, access_rights, department_id, created_by)
	VALUES ('#Tuy@i*2sz@kUw-2!us%WBxYzwP#', '@c^jy#A*%ke_&yz!Ob0w%Pyg-Rt#l_$qiZ-Qt*m@', 'DEPT001', '#K8@-+rYz&^s!@N!=|iKk!$H@jM#')

INSERT INTO ums.system_user_info(system_user_id, system_user_name, system_user_password, system_user_status, created_by)
	VALUES ('#W3B@cc3$$at^wf8OqPqzY23:w7#', '@$p.N3t', 'Cl1.3Nt', 1, '#K8@-+rYz&^s!@N!=|iKk!$H@jM#')
INSERT INTO ums.access_rights_granted(system_user_id, access_rights, department_id, created_by)
	VALUES ('#W3B@cc3$$at^wf8OqPqzY23:w7#', '@T6&62W9Txw,.*%w9Tq2Uzo93r54Qe&34zAeiY&@', 'DEPT001', '#K8@-+rYz&^s!@N!=|iKk!$H@jM#')
GO

IF OBJECT_ID ('ums.System_User_Info_Trigger_Instead_Insert','TR') IS NOT NULL
	ENABLE TRIGGER ums.System_User_Info_Trigger_Instead_Insert ON ums.system_user_info
GO
IF OBJECT_ID ('ums.Access_Rights_Granted_Trigger_Insert','TR') IS NOT NULL
	ENABLE TRIGGER ums.Access_Rights_Granted_Trigger_Insert ON ums.access_rights_granted
GO

-- for registrar_standard table
INSERT INTO ums.registrar_standard(sysid_registrarstd, effectivity_date, school_year_start, semester_months, summer_months, created_by)
	VALUES ('SYSRSD0001', CONVERT(datetime, '06/01/2007', 101), 6, 5, 2, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
GO

-- ums.payroll_standard
-- is used to get the standards of the payroll
INSERT INTO ums.payroll_standard(sysid_payrollstd, effectivity_date, payroll_cutoff_day, created_by) 
	VALUES ('SYSPSD0001', CONVERT(datetime, '06/01/2007', 101), 12, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
GO

-- ums.finance_standard
-- is used to get the standards of the finance
INSERT INTO ums.finance_standard(sysid_financestd, effectivity_date, international_percentage, enrolment_cutoff_day, created_by) 
	VALUES ('SYSFSD0001', CONVERT(datetime, '06/01/2007', 101), 100, 28, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
GO


--ums.code_entity  REF: CommonExchange.CodeEntityId
INSERT INTO ums.code_entity(code_entity_id, entity_description) VALUES ('ETID001', 'Gender')
INSERT INTO ums.code_entity(code_entity_id, entity_description) VALUES ('ETID002', 'Marital Status')
INSERT INTO ums.code_entity(code_entity_id, entity_description) VALUES ('ETID003', 'Life Status')
GO

--(ETID001) Gender
INSERT INTO ums.code_reference(code_reference_id, code_entity_id, reference_code, code_description, reference_flag)
	VALUES ('CODE000001', 'ETID001', 'M', 'Male', 1)
INSERT INTO ums.code_reference(code_reference_id, code_entity_id, reference_code, code_description, reference_flag)
	VALUES ('CODE000002', 'ETID001', 'F', 'Female', 2)
GO

--(ETID002) Marital Status
INSERT INTO ums.code_reference(code_reference_id, code_entity_id, reference_code, code_description, reference_flag)
	VALUES ('CODE000003', 'ETID002', 'D', 'Divorced', 1)
INSERT INTO ums.code_reference(code_reference_id, code_entity_id, reference_code, code_description, reference_flag)
	VALUES ('CODE000004', 'ETID002', 'M', 'Married', 1)
INSERT INTO ums.code_reference(code_reference_id, code_entity_id, reference_code, code_description, reference_flag)
	VALUES ('CODE000005', 'ETID002', 'P', 'Life Partner', 1)
INSERT INTO ums.code_reference(code_reference_id, code_entity_id, reference_code, code_description)
	VALUES ('CODE000006', 'ETID002', 'S', 'Single')
INSERT INTO ums.code_reference(code_reference_id, code_entity_id, reference_code, code_description)
	VALUES ('CODE000007', 'ETID002', 'U', 'Unknown')
INSERT INTO ums.code_reference(code_reference_id, code_entity_id, reference_code, code_description, reference_flag)
	VALUES ('CODE000008', 'ETID002', 'W', 'Windowed', 2)
INSERT INTO ums.code_reference(code_reference_id, code_entity_id, reference_code, code_description, reference_flag)
	VALUES ('CODE000009', 'ETID002', 'X', 'Legally Separated', 1)

--(ETID003) Life Status
INSERT INTO ums.code_reference(code_reference_id, code_entity_id, reference_code, code_description, reference_flag)
	VALUES ('CODE000010', 'ETID003', 'L', 'Living', 1)
INSERT INTO ums.code_reference(code_reference_id, code_entity_id, reference_code, code_description, reference_flag)
	VALUES ('CODE000011', 'ETID003', 'D', 'Deceased', 2)


-- ##########################################END INITIAL DATABASE INFORMATION#############################################################




