--******************************************************--
-- This SQL Statements is used for the St. Paul			--
-- 		University UMS									--
--Programmed by: Judyll Mark T. Agan					--
--Date created: April 01, 2007							--
--PAYROLL SOLUTIONS [ 3 ]								--
--******************************************************--

USE db_umsdev_03_30_2007
GO

-- ###########################################TABLE CONSTRAINTS OBJECTS##############################################################


--verifies if the Rank_Level_Rank_Group_Id_FK constraint exists
IF OBJECT_ID('ums.rank_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.rank_level
	DROP CONSTRAINT Rank_Level_Rank_Group_Id_FK
END
GO
-----------------------------------------------------

--verifies if the Employment_Type_Rank_Group_ID_FK constraint exists
IF OBJECT_ID('ums.employment_type', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employment_type
	DROP CONSTRAINT Employment_Type_Rank_Group_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Rank_Category_Level_ID_FK constraint exists
IF OBJECT_ID('ums.rank_category', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.rank_category
	DROP CONSTRAINT Rank_Category_Level_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Rank_Degree_Category_ID_FK constraint exists
IF OBJECT_ID('ums.rank_degree', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.rank_degree
	DROP CONSTRAINT Rank_Degree_Category_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Rank_Salary_Rate_Degree_ID_FK constraint exists
IF OBJECT_ID('ums.rank_salary_rate', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.rank_salary_rate
	DROP CONSTRAINT Rank_Salary_Rate_Degree_ID_FK
END
GO
-----------------------------------------------------

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

--verifies if the Sss_Range_Sss_ID_FK constraint exists--
IF OBJECT_ID('ums.sss_range', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.sss_range
	DROP CONSTRAINT Sss_Range_Sss_ID_FK
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

--verifies if the PhilHealth_Range_PhilHealth_ID_FK constraint exists--
IF OBJECT_ID('ums.philhealth_range', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.philhealth_range
	DROP CONSTRAINT PhilHealth_Range_PhilHealth_ID_FK
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

--verifies if the Salary_Information_SysID_Employee_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information
	DROP CONSTRAINT Salary_Information_SysID_Employee_FK
END
GO
-----------------------------------------------------

--verifies if the Salary_Information_Employment_ID_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information
	DROP CONSTRAINT Salary_Information_Employment_ID_FK
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

--verifies if the Salary_Information_Status_ID_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information
	DROP CONSTRAINT Salary_Information_Status_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Salary_Information_Level_ID_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information
	DROP CONSTRAINT Salary_Information_Level_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Salary_Information_Category_ID_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information
	DROP CONSTRAINT Salary_Information_Category_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Salary_Information_Degree_ID_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information
	DROP CONSTRAINT Salary_Information_Degree_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Salary_Information_Degree_ID_Level_Points_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information
	DROP CONSTRAINT Salary_Information_Degree_ID_Level_Points_FK
END
GO
-----------------------------------------------------

--verifies if the Salary_Information_Rate_ID_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information
	DROP CONSTRAINT Salary_Information_Rate_ID_FK
END
GO
-----------------------------------------------------

----verifies if the Salary_Information_Sss_ID_FK constraint exists--
--IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
--BEGIN
--	ALTER TABLE ums.salary_information
--	DROP CONSTRAINT Salary_Information_Sss_ID_FK
--END
--GO
-------------------------------------------------------

----verifies if the Salary_Information_PhilHealth_ID_FK constraint exists--
--IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
--BEGIN
--	ALTER TABLE ums.salary_information
--	DROP CONSTRAINT Salary_Information_PhilHealth_ID_FK
--END
--GO
-------------------------------------------------------

--verifies if the Salary_Information_Rest_Day_FK constraint exists--
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.salary_information
	DROP CONSTRAINT Salary_Information_Rest_Day_FK
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

--verifies if the Employee_Deduction_SysId_Deduction_FK constraint exists--
IF OBJECT_ID('ums.employee_deduction', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_deduction
	DROP CONSTRAINT Employee_Deduction_SysId_Deduction_FK
END
GO
-----------------------------------------------------

--verifies if the Employee_Deduction_SysID_Employee_FK constraint exists--
IF OBJECT_ID('ums.employee_deduction', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_deduction
	DROP CONSTRAINT Employee_Deduction_SysID_Employee_FK
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

--verifies if the Employee_Earning_SysId_Earning_FK constraint exists--
IF OBJECT_ID('ums.employee_earning', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_earning
	DROP CONSTRAINT Employee_Earning_SysId_Earning_FK
END
GO
-----------------------------------------------------

--verifies if the Employee_Earning_SysID_Employee_FK constraint exists--
IF OBJECT_ID('ums.employee_earning', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_earning
	DROP CONSTRAINT Employee_Earning_SysID_Employee_FK
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

--verifies if the Loan_Remittance_SysID_Employee_FK constraint exists--
IF OBJECT_ID('ums.loan_remittance', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_remittance
	DROP CONSTRAINT Loan_Remittance_SysID_Employee_FK
END
GO
-----------------------------------------------------

--verifies if the Loan_Remittance_SysId_Loan_FK constraint exists--
IF OBJECT_ID('ums.loan_remittance', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_remittance
	DROP CONSTRAINT Loan_Remittance_SysId_Loan_FK
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

--verifies if the Loan_Remittance_Audit_SysID_Employee_FK constraint exists--
IF OBJECT_ID('ums.loan_remittance_audit', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_remittance_audit
	DROP CONSTRAINT Loan_Remittance_Audit_SysID_Employee_FK
END
GO
-----------------------------------------------------

--verifies if the Loan_Remittance_Audit_SysId_Loan_FK constraint exists--
IF OBJECT_ID('ums.loan_remittance_audit', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.loan_remittance_audit
	DROP CONSTRAINT Loan_Remittance_Audit_SysId_Loan_FK
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

--verifies if the Employee_Remittance_SysId_Remittance_FK constraint exists--
IF OBJECT_ID('ums.employee_remittance', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.employee_remittance
	DROP CONSTRAINT Employee_Remittance_SysId_Remittance_FK
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



-- ########################################END TABLE CONSTRAINTS OBJECTS##############################################################





-- #########################################DROP DEPENDENT TABLE CONSTRAINTS ############################################################

--verifies if the Special_Class_Information_SysID_Employee_FK constraint exists
IF OBJECT_ID('ums.special_class_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_information
	DROP CONSTRAINT Special_Class_Information_SysID_Employee_FK
END
GO
-----------------------------------------------------

--verifies if the Subject_Schedule_Week_ID_FK constraint exists
IF OBJECT_ID('ums.subject_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_schedule
	DROP CONSTRAINT Subject_Schedule_Week_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Teacher_Load_SysID_Employee_FK constraint exists
IF OBJECT_ID('ums.teacher_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.teacher_load
	DROP CONSTRAINT Teacher_Load_SysID_Employee_FK
END
GO
-----------------------------------------------------

--verifies if the Miscellaneous_Income_SysID_Employee_FK constraint exists
IF OBJECT_ID('ums.miscellaneous_income', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.miscellaneous_income
	DROP CONSTRAINT Miscellaneous_Income_SysID_Employee_FK
END
GO
-----------------------------------------------------

-- ##########################################END DROP DEPENDENT TABLE CONSTRAINTS ############################################################




-- ################################################TABLE "rank_group" OBJECTS######################################################
-- verifies if the rank_group table exists
IF OBJECT_ID('ums.rank_group', 'U') IS NOT NULL
	DROP TABLE ums.rank_group
GO

CREATE TABLE ums.rank_group 			
(
	rank_group_id varchar (50) NOT NULL 
		CONSTRAINT Rank_Group_Group_ID_PK PRIMARY KEY (rank_group_id)
		CONSTRAINT Rank_Group_Group_ID_CK CHECK (rank_group_id LIKE 'RG%'),
	group_no tinyint NOT NULL
		CONSTRAINT Rank_Group_Group_No_UQ UNIQUE (group_no),		
	group_description varchar (100) NOT NULL
		CONSTRAINT Rank_Group_Group_Description_UQ UNIQUE (group_description),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Rank_Group_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- verifies that the trigger "Rank_Group_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Rank_Group_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Rank_Group_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Rank_Group_Trigger_Instead_Update
	ON  ums.rank_group
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a rank group', 'Rank Group'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Rank_Group_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Rank_Group_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Rank_Group_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Rank_Group_Trigger_Instead_Delete
	ON  ums.rank_group
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a rank group', 'Rank Group'
	
GO
-------------------------------------------------------------------------

-- ################################################END TABLE "rank_group" OBJECTS###################################################





-- ################################################TABLE "employment_type" OBJECTS######################################################
-- verifies if the employment_type table exists
IF OBJECT_ID('ums.employment_type', 'U') IS NOT NULL
	DROP TABLE ums.employment_type
GO

CREATE TABLE ums.employment_type 			
(
	employment_id varchar (50) NOT NULL 
		CONSTRAINT Employment_Type_Employment_ID_PK PRIMARY KEY (employment_id)
		CONSTRAINT Employment_Type_Employment_ID_CK CHECK (employment_id LIKE 'ET%'),
	rank_group_id varchar (50) NOT NULL
		CONSTRAINT Employment_Type_Rank_Group_ID_FK FOREIGN KEY REFERENCES ums.rank_group(rank_group_id) ON UPDATE NO ACTION,
	type_no tinyint NOT NULL
		CONSTRAINT Employment_Type_Type_No_UQ UNIQUE (type_no),
	type_description varchar (100) NOT NULL
		CONSTRAINT Employment_Type_Type_Description_UQ UNIQUE (type_description),
	type_acronym varchar (50) NOT NULL,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Employment_Type_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- verifies that the trigger "Employment_Type_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Employment_Type_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Employment_Type_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Employment_Type_Trigger_Instead_Update
	ON  ums.employment_type
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update an employment type', 'Employment Type'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Employment_Type_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Employment_Type_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Employment_Type_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Employment_Type_Trigger_Instead_Delete
	ON  ums.employment_type
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete an employment type', 'Employment Type'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectEmploymentType" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectEmploymentType')
   DROP PROCEDURE ums.SelectEmploymentType
GO

CREATE PROCEDURE ums.SelectEmploymentType
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			et.employment_id AS employment_id,
			et.rank_group_id AS rank_group_id,
			et.type_no AS type_no,
			et.type_description AS type_description,
			et.type_acronym AS type_acronym
		FROM
			ums.employment_type AS et
		ORDER BY et.employment_id ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query employee employment type', 'Employment Type'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectEmploymentType TO db_umsusers
GO
-------------------------------------------------------------


-- ################################################END TABLE "employment_type" OBJECTS###################################################



-- ################################################TABLE "rank_level" OBJECTS######################################################
-- verifies if the rank_level table exists
IF OBJECT_ID('ums.rank_level', 'U') IS NOT NULL
	DROP TABLE ums.rank_level
GO

CREATE TABLE ums.rank_level 			
(
	level_id varchar (50) NOT NULL 
		CONSTRAINT Rank_Level_Level_ID_PK PRIMARY KEY (level_id)
		CONSTRAINT Rank_Level_Level_ID_CK CHECK (level_id LIKE 'RL%'),	
	rank_group_id varchar (50) NOT NULL
		CONSTRAINT Rank_Level_Rank_Group_Id_FK FOREIGN KEY REFERENCES ums.rank_group(rank_group_id) ON UPDATE NO ACTION,	
	level_no tinyint NOT NULL
		CONSTRAINT Rank_Level_Level_No_UQ UNIQUE (level_no),
	level_description varchar (100) NOT NULL
		CONSTRAINT Rank_Level_Level_Description_UQ UNIQUE (level_description),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Rank_Level_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the rank_level table 
CREATE INDEX Rank_Level_Level_ID_Index
	ON ums.rank_level (level_id DESC)
GO
------------------------------------------------------------------

-- verifies that the trigger "Rank_Level_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Rank_Level_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Rank_Level_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Rank_Level_Trigger_Instead_Update
	ON  ums.rank_level
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a rank level', 'Rank Level'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Rank_Level_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Rank_Level_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Rank_Level_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Rank_Level_Trigger_Instead_Delete
	ON  ums.rank_level
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a rank level', 'Rank Level'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectCurrentRankLevel" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectCurrentRankLevel')
   DROP PROCEDURE ums.SelectCurrentRankLevel
GO

CREATE PROCEDURE ums.SelectCurrentRankLevel
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			rl.level_id AS level_id,
			rl.rank_group_id AS rank_group_id,
			rl.level_no AS level_no,
			rl.level_description AS level_description
		FROM
			ums.rank_level AS rl
		ORDER BY 
			rl.level_id ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query employee rank level', 'Rank Level'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectCurrentRankLevel TO db_umsusers
GO
-------------------------------------------------------------

-- #############################################END TABLE "rank_level" OBJECTS######################################################



-- ################################################TABLE "rank_category" OBJECTS######################################################
-- verifies if the rank_category table exists
IF OBJECT_ID('ums.rank_category', 'U') IS NOT NULL
	DROP TABLE ums.rank_category
GO

CREATE TABLE ums.rank_category 			
(
	category_id varchar (50) NOT NULL 
		CONSTRAINT Rank_Category_Category_ID_PK PRIMARY KEY (category_id)
		CONSTRAINT Rank_Category_Category_ID_CK CHECK (category_id LIKE 'RC%'),	
	level_id varchar (50) NOT NULL
		CONSTRAINT Rank_Category_Level_ID_FK FOREIGN KEY REFERENCES ums.rank_level(level_id) ON UPDATE NO ACTION,
	category_no tinyint NOT NULL,		
	category_description varchar (100) NOT NULL,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Rank_Category_Unique_ID_UQ UNIQUE (unique_id)	
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the rank_category table 
CREATE INDEX Rank_Category_Category_ID_Index
	ON ums.rank_category (category_id DESC)
GO
------------------------------------------------------------------

-- verifies that the trigger "Rank_Category_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Rank_Category_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Rank_Category_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Rank_Category_Trigger_Instead_Update
	ON  ums.rank_category
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a rank category', 'Rank Category'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Rank_Category_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Rank_Category_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Rank_Category_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Rank_Category_Trigger_Instead_Delete
	ON  ums.rank_category
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a rank category', 'Rank Category'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectCurrentRankCategory" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectCurrentRankCategory')
   DROP PROCEDURE ums.SelectCurrentRankCategory
GO

CREATE PROCEDURE ums.SelectCurrentRankCategory
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			rc.category_id AS category_id,
			rc.level_id AS level_id,
			rc.category_no AS category_no,
			rc.category_description AS category_description
		FROM
			ums.rank_category AS rc
		ORDER BY 
			rc.category_id ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query employee rank category', 'Rank Category'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectCurrentRankCategory TO db_umsusers
GO
-------------------------------------------------------------


-- #############################################END TABLE "rank_category" OBJECTS######################################################



-- ################################################TABLE "rank_degree" OBJECTS######################################################
-- verifies if the rank_degree table exists
IF OBJECT_ID('ums.rank_degree', 'U') IS NOT NULL
	DROP TABLE ums.rank_degree
GO

CREATE TABLE ums.rank_degree 			
(
	degree_id varchar (50) NOT NULL 
		CONSTRAINT Rank_Degree_Degree_ID_PK PRIMARY KEY (degree_id)
		CONSTRAINT Rank_Degree_Degree_ID_CK CHECK (degree_id LIKE 'RD%'),	
	category_id varchar (50) NOT NULL
		CONSTRAINT Rank_Degree_Category_ID_FK FOREIGN KEY REFERENCES ums.rank_category(category_id) ON UPDATE NO ACTION,
	degree_no tinyint NOT NULL,		
	degree_description varchar (100) NOT NULL,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Rank_Degree_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the rank_degree table 
CREATE INDEX Rank_Degree_Degree_ID_Index
	ON ums.rank_degree (degree_id DESC)
GO
------------------------------------------------------------------

-- verifies that the trigger "Rank_Degree_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Rank_Degree_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Rank_Degree_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Rank_Degree_Trigger_Instead_Update
	ON  ums.rank_degree
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a rank degree', 'Rank Degree'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Rank_Degree_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Rank_Degree_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Rank_Degree_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Rank_Degree_Trigger_Instead_Delete
	ON  ums.rank_degree
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a rank degree', 'Rank Degree'
	
GO
-------------------------------------------------------------------------

-- #############################################END TABLE "rank_degree" OBJECTS######################################################




-- ################################################TABLE "rank_salary_rate" OBJECTS######################################################
-- verifies if the rank_salary_rate table exists
IF OBJECT_ID('ums.rank_salary_rate', 'U') IS NOT NULL
	DROP TABLE ums.rank_salary_rate
GO

CREATE TABLE ums.rank_salary_rate 			
(
	rate_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Rank_Salary_Rate_Rate_ID_PK PRIMARY KEY (rate_id),
	degree_id varchar (50) NOT NULL
		CONSTRAINT Rank_Salary_Rate_Degree_ID_FK FOREIGN KEY REFERENCES ums.rank_degree(degree_id) ON UPDATE NO ACTION,
	effectivity_date datetime NOT NULL DEFAULT (GETDATE()),
	level_points varchar (20) NOT NULL DEFAULT (''),
	previous_rate decimal (12, 2) NOT NULL DEFAULT (0.00),
	increase_rate decimal (12, 2) NOT NULL DEFAULT (0.00),
		
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Rank_Salary_Rate_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Rank_Salary_Rate_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Rank_Salary_Rate_Unique_ID_UQ UNIQUE (unique_id)
	
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the rank_salary_rate table 
CREATE INDEX Rank_Salary_Rate_Rate_ID_Index
	ON ums.rank_salary_rate (rate_id DESC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Rank_Salary_Rate_Trigger_Instead_Insert" already exist*/
IF OBJECT_ID ('ums.Rank_Salary_Rate_Trigger_Instead_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Rank_Salary_Rate_Trigger_Instead_Insert
GO

CREATE TRIGGER ums.Rank_Salary_Rate_Trigger_Instead_Insert
	ON  ums.rank_salary_rate
	INSTEAD OF INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar(MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @degree_id varchar (50)
	DECLARE @effectivity_date datetime
	DECLARE @level_points varchar (20)
	DECLARE @previous_rate decimal (12, 2)
	DECLARE @increase_rate decimal (12, 2)

	DECLARE @created_by varchar (50)

	DECLARE @level_points_b varchar (20)
	DECLARE @previous_rate_b decimal (12, 2)	
	DECLARE @increase_rate_b decimal (12, 2)

	DECLARE @has_update bit
	
	SELECT 
		@degree_id = degree_id,
		@effectivity_date = effectivity_date,
		@level_points = level_points,
		@previous_rate = previous_rate,
		@increase_rate = increase_rate,
		@created_by = created_by	
	FROM 
		INSERTED	

	SET @has_update = 0
	SET @previous_rate_b = 0
	SET @increase_rate_b = 0

	-- check if there are changes in the existing rank salary rate before creating a rank salary rate
	IF EXISTS (SELECT rate_id FROM ums.rank_salary_rate WHERE degree_id = @degree_id)
	BEGIN

		SELECT 
			@level_points_b = level_points,
			@previous_rate_b = previous_rate,
			@increase_rate_b = increase_rate		
		FROM 
			ums.rank_salary_rate
		WHERE	
			degree_id = @degree_id AND
			effectivity_date = (SELECT MAX(effectivity_date) FROM ums.rank_salary_rate WHERE degree_id = @degree_id)

		-- check if there are new updates for the resent rank salary rate of the employee
		IF (NOT ISNULL(@level_points, '') = ISNULL(@level_points_b, '')) OR
			(NOT ISNULL(CONVERT(varchar, CONVERT(money, @previous_rate), 1), '') = ISNULL(CONVERT(varchar, CONVERT(money, @previous_rate_b), 1), '')) OR
			(NOT ISNULL(CONVERT(varchar, CONVERT(money, @increase_rate), 1), '') = ISNULL(CONVERT(varchar, CONVERT(money, @increase_rate_b), 1), ''))
		BEGIN
			SET @has_update = 1
		END	
		ELSE
		BEGIN
			SET @has_update = 0
		END
	END
	ELSE
	BEGIN
		SET @has_update = 1
	END
	
	IF @has_update = 1
	BEGIN

		INSERT INTO ums.rank_salary_rate
		(
			degree_id,
			effectivity_date,
			level_points,
			previous_rate,
			increase_rate,
			created_by
		)
		VALUES
		(
			@degree_id,
			@effectivity_date,
			@level_points,
			@previous_rate,
			@increase_rate,
			@created_by
		)

		SET @transaction_done = 'INSERTED a new rank salary rate ' + 
							'][Effectivity Date: ' + ISNULL((CONVERT(varchar, @effectivity_date, 101)), '') +
							'][Rank Level: ' + ISNULL((SELECT 
															ISNULL(rl.level_description, '') 
														FROM ums.rank_level AS rl
														INNER JOIN ums.rank_category AS rc ON rc.level_id = rl.level_id
														INNER JOIN ums.rank_degree AS rd ON rd.category_id = rc.category_id
														WHERE 
															rd.degree_id = @degree_id), '') +
							'][Rank Category: ' + ISNULL((SELECT 
															ISNULL(rc.category_description, '') 
														FROM ums.rank_category AS rc
														INNER JOIN ums.rank_degree AS rd ON rd.category_id = rc.category_id
														WHERE 
															rd.degree_id = @degree_id), '') +
							'][Rank Degree: ' + ISNULL((SELECT 
															ISNULL(rd.degree_description, '') 
														FROM ums.rank_degree AS rd
														WHERE 
															rd.degree_id = @degree_id), '') +
							'][Level Points: ' + ISNULL(@level_points, '') +
							'][Previous Rate: ' + ISNULL(CONVERT(varchar, CONVERT(money, @previous_rate), 1), '') + 
							'][Increase Rate: ' + ISNULL(CONVERT(varchar, CONVERT(money, @increase_rate), 1), '') + 
							']'

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
		END

		EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

	END

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Rank_Salary_Rate_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Rank_Salary_Rate_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Rank_Salary_Rate_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Rank_Salary_Rate_Trigger_Instead_Update
	ON  ums.rank_salary_rate
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar(MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @rate_id bigint
	DECLARE @degree_id varchar (50)
	DECLARE @effectivity_date datetime
	DECLARE @level_points varchar (20)
	DECLARE @previous_rate decimal (12, 2)
	DECLARE @increase_rate decimal (12, 2)

	DECLARE @edited_by varchar (50)

	DECLARE @level_points_b varchar (20)
	DECLARE @previous_rate_b decimal (12, 2)	
	DECLARE @increase_rate_b decimal (12, 2)	

	DECLARE @has_update bit
	
	SELECT 
		@rate_id = rate_id,
		@degree_id = degree_id,
		@effectivity_date = effectivity_date,
		@level_points = level_points,
		@previous_rate = previous_rate,
		@increase_rate = increase_rate,
		@edited_by = edited_by	
	FROM 
		INSERTED

	SELECT 
		@level_points_b = level_points,
		@previous_rate_b = previous_rate,
		@increase_rate_b = increase_rate	
	FROM 
		ums.rank_salary_rate
	WHERE
		rate_id = @rate_id	

	SET @transaction_done = ''
	SET @has_update = 0	

	IF (NOT ISNULL(@level_points, '') = ISNULL(@level_points_b, ''))
	BEGIN
		SET @transaction_done = @transaction_done + '[Level Points Before: ' + ISNULL(@level_points_b, '') + ']' +
													'[Level Points After: ' + ISNULL(@level_points, '') + ']'
		SET @has_update = 1
	END

	IF (NOT ISNULL(CONVERT(varchar, CONVERT(money, @previous_rate), 1), '') = ISNULL(CONVERT(varchar, CONVERT(money, @previous_rate_b), 1), ''))
	BEGIN
		SET @transaction_done = @transaction_done + '[Previous Rate Before: ' + ISNULL(CONVERT(varchar, CONVERT(money, @previous_rate_b), 1), '') + ']' +
													'[Previous Rate After: ' + ISNULL(CONVERT(varchar, CONVERT(money, @previous_rate), 1), '') + ']'
		SET @has_update = 1
	END

	IF (NOT ISNULL(CONVERT(varchar, CONVERT(money, @increase_rate), 1), '') = ISNULL(CONVERT(varchar, CONVERT(money, @increase_rate_b), 1), ''))
	BEGIN
		SET @transaction_done = @transaction_done + '[Increase Rate Before: ' + ISNULL(CONVERT(varchar, CONVERT(money, @increase_rate_b), 1), '') + ']' +
													'[Increase Rate After: ' + ISNULL(CONVERT(varchar, CONVERT(money, @increase_rate), 1), '') + ']'
		SET @has_update = 1
	END

	IF @has_update = 1
	BEGIN

		UPDATE ums.rank_salary_rate SET
			level_points = @level_points,
			previous_rate = @previous_rate,
			increase_rate = @increase_rate,
			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			rate_id = @rate_id		
	
		SET @transaction_done = 'UPDATED a rank salary rate ' + 
							'][Effectivity Date: ' + ISNULL((CONVERT(varchar, @effectivity_date, 101)), '') +
							'][Rank Level: ' + ISNULL((SELECT 
															ISNULL(rl.level_description, '') 
														FROM ums.rank_level AS rl
														INNER JOIN ums.rank_category AS rc ON rc.level_id = rl.level_id
														INNER JOIN ums.rank_degree AS rd ON rd.category_id = rc.category_id
														WHERE 
															rd.degree_id = @degree_id), '') +
							'][Rank Category: ' + ISNULL((SELECT 
															ISNULL(rc.category_description, '') 
														FROM ums.rank_category AS rc
														INNER JOIN ums.rank_degree AS rd ON rd.category_id = rc.category_id
														WHERE 
															rd.degree_id = @degree_id), '') +
							'][Rank Degree: ' + ISNULL((SELECT 
															ISNULL(rd.degree_description, '') 
														FROM ums.rank_degree AS rd
														WHERE 
															rd.degree_id = @degree_id), '') +
							']' + @transaction_done

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
		END

		EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done	
	END

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Rank_Salary_Rate_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Rank_Salary_Rate_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Rank_Salary_Rate_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Rank_Salary_Rate_Trigger_Instead_Delete
	ON  ums.rank_salary_rate
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a rank salary rate', 'Rank Salary Rate'
	
GO
-------------------------------------------------------------------------


-- verifies if the procedure "InsertUpdateRankSalaryRate" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertUpdateRankSalaryRate')
   DROP PROCEDURE ums.InsertUpdateRankSalaryRate
GO

CREATE PROCEDURE ums.InsertUpdateRankSalaryRate

	@degree_id varchar (50) = '',
	@level_points varchar (20) = '',
	@previous_rate decimal (12, 2) = '',
	@increase_rate decimal (12, 2) = '',

	@network_information varchar (MAX) = '',
	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		IF EXISTS (SELECT degree_id FROM ums.rank_degree WHERE degree_id = @degree_id)
		BEGIN

			EXECUTE ums.CreateTemporaryTable @system_user_id, @network_information

			DECLARE @rate_id bigint

			SET @rate_id = 0

			SELECT @rate_id = rate_id FROM ums.rank_salary_rate WHERE degree_id = @degree_id AND 
								effectivity_date = ums.GetPayrollEffectivityDate(GETDATE()) 

			IF @rate_id > 0
			BEGIN

				UPDATE ums.rank_salary_rate SET
					level_points = @level_points,
					previous_rate = @previous_rate,
					increase_rate = @increase_rate,			
					edited_by = @system_user_id
				WHERE
					rate_id = @rate_id			
					
			END	
			ELSE
			BEGIN

				DECLARE @effectivity_date datetime

				IF EXISTS (SELECT rate_id FROM ums.rank_salary_rate WHERE degree_id = @degree_id) -- check if there is already an existing rank salary rate
				BEGIN
					SET @effectivity_date = ums.GetPayrollEffectivityDate(GETDATE())
				END
				ELSE
				BEGIN
					
					IF EXISTS (SELECT year_id FROM ums.school_year) AND
						(GETDATE() <= (SELECT MAX(date_end) FROM ums.school_year)) -- used if it the creation of the rank salary rate for the first time
					BEGIN
						SELECT @effectivity_date = date_start FROM ums.school_year WHERE GETDATE() BETWEEN date_start AND date_end
					END
					ELSE
					BEGIN
						SET @effectivity_date = CONVERT(datetime, CONVERT(varchar, GETDATE(), 101) + ' 12:00:00 AM', 101)
					END

				END

				INSERT INTO ums.rank_salary_rate
				(
					degree_id,
					effectivity_date,
					level_points,
					previous_rate,
					increase_rate,
					created_by
				)
				VALUES
				(
					@degree_id,
					@effectivity_date,
					@level_points,
					@previous_rate,
					@increase_rate,
					@system_user_id
				)			
				
			END
		END
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert/Update a rank salary rate', 'Rank Salary Rate'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertUpdateRankSalaryRate TO db_umsusers
GO
-------------------------------------------------------------


-- verifies if the procedure "SelectCurrentRankDegree" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectCurrentRankDegree')
   DROP PROCEDURE ums.SelectCurrentRankDegree
GO

CREATE PROCEDURE ums.SelectCurrentRankDegree
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			DISTINCT rd.degree_id AS degree_id,
			rd.category_id AS category_id,
			rd.degree_no AS degree_no,
			rd.degree_description AS degree_description,
			rc.category_id AS category_id,
			rc.category_description AS category_description,
			rc.category_no AS category_no,
			rl.level_id AS level_id,
			rl.level_description AS level_description,
			rl.level_no AS level_no,
			rsr.rate_id AS rate_id,
			rsr.level_points AS level_points,
			rsr.previous_rate AS previous_rate,
			rsr.increase_rate AS increase_rate
		FROM
			ums.rank_degree AS rd
		INNER JOIN ums.rank_category AS rc ON rc.category_id = rd.category_id
		INNER JOIN ums.rank_level AS rl ON rl.level_id = rc.level_id
		INNER JOIN ums.rank_salary_rate AS rsr ON rsr.degree_id = rd.degree_id
		WHERE
			rsr.effectivity_date = (SELECT MAX(t_rsr.effectivity_date) FROM ums.rank_salary_rate AS t_rsr WHERE t_rsr.degree_id = rd.degree_id)
		ORDER BY 
			level_no, category_no, degree_no ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query employee rank degree', 'Rank Degree'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectCurrentRankDegree TO db_umsusers
GO
-------------------------------------------------------------


-- #############################################END TABLE "rank_salary_rate" OBJECTS######################################################





-- ################################################TABLE "sss_information" OBJECTS######################################################
-- verifies if the sss_information table exists
IF OBJECT_ID('ums.sss_information', 'U') IS NOT NULL
	DROP TABLE ums.sss_information
GO

CREATE TABLE ums.sss_information 			
(
	sss_id varchar (50) NOT NULL 
		CONSTRAINT Sss_Information_Sss_ID_PK PRIMARY KEY (sss_id)
		CONSTRAINT Sss_Information_Sss_ID_CK CHECK (sss_id LIKE 'SSS%'),
	effectivity_date datetime NOT NULL DEFAULT (GETDATE()),	
			
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Sss_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Sss_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Sss_Information_Unique_ID_UQ UNIQUE (unique_id)
	
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the sss_information table 
CREATE INDEX Sss_Information_Sss_ID_Index
	ON ums.sss_information (sss_id ASC)
GO
------------------------------------------------------------------


-- #############################################END TABLE "sss_information" OBJECTS######################################################


-- ################################################TABLE "sss_range" OBJECTS######################################################
-- verifies if the sss_range table exists
IF OBJECT_ID('ums.sss_range', 'U') IS NOT NULL
	DROP TABLE ums.sss_range
GO

CREATE TABLE ums.sss_range 			
(
	range_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Sss_Range_Range_ID_PK PRIMARY KEY (range_id),
	sss_id varchar (50) NOT NULL 
		CONSTRAINT Sss_Range_Sss_ID_FK FOREIGN KEY REFERENCES ums.sss_information(sss_id) ON UPDATE NO ACTION,
	sal_min decimal (12, 2) NOT NULL,
	sal_max decimal (12, 2) NOT NULL,
	contribution decimal (12, 2) NOT NULL,	
			
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Sss_Range_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Sss_Range_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Sss_Range_Unique_ID_UQ UNIQUE (unique_id)
	
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the sss_range table 
CREATE INDEX Sss_Range_Range_ID_Index
	ON ums.sss_range (range_id DESC)
GO
------------------------------------------------------------------


-- #############################################END TABLE "sss_range" OBJECTS######################################################



-- ################################################TABLE "philhealth_information" OBJECTS######################################################
-- verifies if the philhealth_information table exists
IF OBJECT_ID('ums.philhealth_information', 'U') IS NOT NULL
	DROP TABLE ums.philhealth_information
GO

CREATE TABLE ums.philhealth_information 			
(
	philhealth_id varchar (50) NOT NULL 
		CONSTRAINT PhilHealth_Information_PhilHealth_ID_PK PRIMARY KEY (philhealth_id)
		CONSTRAINT PhilHealth_Information_PhilHealth_ID_CK CHECK (philhealth_id LIKE 'PHL%'),
	effectivity_date datetime NOT NULL DEFAULT (GETDATE()),	
			
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT PhilHealth_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT PhilHealth_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT PhilHealth_Information_Unique_ID_UQ UNIQUE (unique_id)
	
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the philhealth_information table 
CREATE INDEX PhilHealth_Information_Sss_ID_Index
	ON ums.philhealth_information (philhealth_id DESC)
GO
------------------------------------------------------------------


-- #############################################END TABLE "philhealth_information" OBJECTS######################################################




-- ################################################TABLE "philhealth_range" OBJECTS######################################################
-- verifies if the philhealth_range table exists
IF OBJECT_ID('ums.philhealth_range', 'U') IS NOT NULL
	DROP TABLE ums.philhealth_range
GO

CREATE TABLE ums.philhealth_range 			
(
	range_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT PhilHealth_Range_Range_ID_PK PRIMARY KEY (range_id),
	philhealth_id varchar (50) NOT NULL 
		CONSTRAINT PhilHealth_Range_PhilHealth_ID_FK FOREIGN KEY REFERENCES ums.philhealth_information(philhealth_id) ON UPDATE NO ACTION,
	sal_min decimal (12, 2) NOT NULL,
	sal_max decimal (12, 2) NOT NULL,
	contribution decimal (12, 2) NOT NULL,	
			
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT PhilHealth_Range_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT PhilHealth_Range_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT PhilHealth_Range_Unique_ID_UQ UNIQUE (unique_id)
	
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the philhealth_range table 
CREATE INDEX PhilHealth_Range_Range_ID_Index
	ON ums.philhealth_range (range_id DESC)
GO
------------------------------------------------------------------


-- #############################################END TABLE "philhealth_range" OBJECTS######################################################




-- ################################################TABLE "week_day" OBJECTS######################################################
-- verifies if the week_day table exists
IF OBJECT_ID('ums.week_day', 'U') IS NOT NULL
	DROP TABLE ums.week_day
GO

CREATE TABLE ums.week_day 			
(
	week_id tinyint NOT NULL 
		CONSTRAINT Week_Day_Week_ID_PK PRIMARY KEY (week_id),		
	week_description varchar (100) NOT NULL
		CONSTRAINT Week_Day_Week_Description_UQ UNIQUE (week_description),
	acronym varchar (20) NOT NULL
		CONSTRAINT Week_Day_Acronym_UQ UNIQUE (acronym),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Week_Day_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- verifies that the trigger "Week_Day_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Week_Day_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Week_Day_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Week_Day_Trigger_Instead_Update
	ON  ums.week_day
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a week day', 'Week Day'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Week_Day_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Week_Day_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Week_Day_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Week_Day_Trigger_Instead_Delete
	ON  ums.week_day
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a week day', 'Week Day'
	
GO
-------------------------------------------------------------------------


-- verifies if the procedure "SelectWeekDay" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectWeekDay')
   DROP PROCEDURE ums.SelectWeekDay
GO

CREATE PROCEDURE ums.SelectWeekDay
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT 
			wd.week_id AS week_id,
			wd.week_description AS week_description,
			wd.acronym AS acronym
		FROM
			ums.week_day AS wd
		ORDER BY wd.week_id ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query week day', 'Week Day'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectWeekDay TO db_umsusers
GO
-------------------------------------------------------------

-- ################################################END TABLE "week_day" OBJECTS######################################################





-- ################################################TABLE "employment_status" OBJECTS######################################################
-- verifies if the employment_status table exists
IF OBJECT_ID('ums.employment_status', 'U') IS NOT NULL
	DROP TABLE ums.employment_status
GO

CREATE TABLE ums.employment_status 			
(
	status_id tinyint NOT NULL 
		CONSTRAINT Employment_Status_Status_ID_PK PRIMARY KEY (status_id),		
	status_description varchar (100) NOT NULL
		CONSTRAINT Employment_Status_Status_Description_UQ UNIQUE (status_description),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Employment_Status_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- verifies that the trigger "Employment_Status_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Employment_Status_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Employment_Status_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Employment_Status_Trigger_Instead_Update
	ON  ums.employment_status
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update an employment status', 'Employment Status'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Employment_Status_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Employment_Status_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Employment_Status_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Employment_Status_Trigger_Instead_Delete
	ON  ums.employment_status
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete an employment status', 'Employment Status'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectEmploymentStatus" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectEmploymentStatus')
   DROP PROCEDURE ums.SelectEmploymentStatus
GO

CREATE PROCEDURE ums.SelectEmploymentStatus
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT 
			es.status_id AS status_id,
			es.status_description AS status_description
		FROM
			ums.employment_status AS es
		ORDER BY es.status_id ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query employment status', 'Employment Status'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectEmploymentStatus TO db_umsusers
GO
-------------------------------------------------------------


-- ################################################END TABLE "employment_status" OBJECTS###################################################





-- ##########################################TABLE "employee_information" OBJECTS########################################################

-- verifies if the employee_information table exists
IF OBJECT_ID('ums.employee_information', 'U') IS NOT NULL
	DROP TABLE ums.employee_information
GO
---------------------------------------------------- 

-- creates the table "employee_information"
CREATE TABLE ums.employee_information 			
(
	sysid_employee varchar (50) NOT NULL 
		CONSTRAINT Employee_Information_SysID_Employee_PK PRIMARY KEY (sysid_employee)
		CONSTRAINT Employee_Information_SysID_Employee_CK CHECK (sysid_employee LIKE 'SYSEMP%'),
	employee_id varchar (50) NOT NULL
		CONSTRAINT Employee_Information_Employee_ID_UQ UNIQUE (employee_id),
	e_code varchar (50) NULL,
	card_number varchar (50) NULL,

	pagibig_memid varchar (50) NULL,
	sss_memid varchar (50) NULL,
	philhealth_memid varchar (50) NULL,

	other_employee_information varchar (MAX) NULL,
	
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Employee_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Employee_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Employee_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the employee_information table 
CREATE INDEX Employee_Information_SysID_Employee_Index
	ON ums.employee_information (sysid_employee ASC)
GO
------------------------------------------------------------------

-- ########################################END TABLE "employee_information" OBJECTS######################################################




-- ##########################################TABLE "salary_information" OBJECTS########################################################

-- verifies if the salary_information table exists
IF OBJECT_ID('ums.salary_information', 'U') IS NOT NULL
	DROP TABLE ums.salary_information
GO
---------------------------------------------------- 

-- creates the table "salary_information"
CREATE TABLE ums.salary_information 			
(
	salary_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Salary_Information_Salary_ID_PK PRIMARY KEY (salary_id),
	sysid_employee varchar (50) NOT NULL 
		CONSTRAINT Salary_Information_SysID_Employee_FK FOREIGN KEY REFERENCES ums.employee_information(sysid_employee) ON UPDATE NO ACTION,
	effectivity_date datetime NOT NULL DEFAULT (GETDATE()),
	employment_id varchar (50) NOT NULL 
		CONSTRAINT Salary_Information_Employment_ID_FK FOREIGN KEY REFERENCES ums.employment_type(employment_id) ON UPDATE NO ACTION,
	department_id varchar (50) NOT NULL
		CONSTRAINT Salary_Information_Department_ID_FK FOREIGN KEY REFERENCES ums.department_information(department_id) ON UPDATE NO ACTION,
	status_id tinyint NOT NULL 
		CONSTRAINT Salary_Information_Status_ID_FK FOREIGN KEY REFERENCES ums.employment_status(status_id) ON UPDATE NO ACTION,
	level_id varchar (50) NULL 
		CONSTRAINT Salary_Information_Level_ID_FK FOREIGN KEY REFERENCES ums.rank_level(level_id) ON UPDATE NO ACTION,
	category_id varchar (50) NULL 
		CONSTRAINT Salary_Information_Category_ID_FK FOREIGN KEY REFERENCES ums.rank_category(category_id) ON UPDATE NO ACTION,
	degree_id varchar (50) NULL 
		CONSTRAINT Salary_Information_Degree_ID_FK FOREIGN KEY REFERENCES ums.rank_degree(degree_id) ON UPDATE NO ACTION,
	degree_id_level_points varchar (50) NULL 
		CONSTRAINT Salary_Information_Degree_ID_Level_Points_FK FOREIGN KEY REFERENCES ums.rank_degree(degree_id) ON UPDATE NO ACTION,
	rate_id bigint NULL
		CONSTRAINT Salary_Information_Rate_ID_FK FOREIGN KEY REFERENCES ums.rank_salary_rate(rate_id) ON UPDATE NO ACTION,

	is_fixed_loginout bit NOT NULL DEFAULT (1),
	first_in varchar (12) NOT NULL
		CONSTRAINT Salary_Information_First_In_CK CHECK ((first_in LIKE '[0-1][0-2]:[0-5][0-9]%' OR first_in LIKE '[0-9]:[0-5][0-9]%') AND 
			(first_in LIKE '%[AM]' OR first_in LIKE '%[PM]' OR first_in LIKE '%[am]' OR first_in LIKE '%[pm]')),
	first_out varchar (12) NOT NULL
		CONSTRAINT Salary_Information_First_Out_CK CHECK ((first_out LIKE '[0-1][0-2]:[0-5][0-9]%' OR first_out LIKE '[0-9]:[0-5][0-9]%') AND 
			(first_out LIKE '%[AM]' OR first_out LIKE '%[PM]' OR first_out LIKE '%[am]' OR first_out LIKE '%[pm]')),
	second_in varchar (12) NOT NULL
		CONSTRAINT Salary_Information_Second_In_CK CHECK ((second_in LIKE '[0-1][0-2]:[0-5][0-9]%' OR second_in LIKE '[0-9]:[0-5][0-9]%') AND 
			(second_in LIKE '%[AM]' OR second_in LIKE '%[PM]' OR second_in LIKE '%[am]' OR second_in LIKE '%[pm]')),
	second_out varchar (12) NOT NULL
		CONSTRAINT Salary_Information_Second_Out_CK CHECK ((second_out LIKE '[0-1][0-2]:[0-5][0-9]%' OR second_out LIKE '[0-9]:[0-5][0-9]%') AND 
			(second_out LIKE '%[AM]' OR second_out LIKE '%[PM]' OR second_out LIKE '%[am]' OR second_out LIKE '%[pm]')),
	rest_day tinyint NOT NULL DEFAULT (0)
		CONSTRAINT Salary_Information_Rest_Day_FK FOREIGN KEY REFERENCES ums.week_day(week_id) ON UPDATE NO ACTION,
	
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Salary_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Salary_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Salary_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the salary_information table 
CREATE INDEX Salary_Information_Salary_ID_Index
	ON ums.salary_information (salary_id DESC)
GO
------------------------------------------------------------------


-- verifies if the procedure "InsertUpdateSalaryInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertUpdateSalaryInformation')
   DROP PROCEDURE ums.InsertUpdateSalaryInformation
GO

CREATE PROCEDURE ums.InsertUpdateSalaryInformation

	@sysid_employee varchar (50) = '',
	@employment_id varchar (50)  = '',
	@department_id varchar (50) = '',
	@status_id tinyint = 0,
	@level_id varchar (50) = '',
	@category_id varchar (50) = '',
	@degree_id varchar (50) = '',
	@degree_id_level_points varchar (50) = '',
	@rate_id bigint = 0,
	@is_fixed_loginout bit = 0,
	@first_in varchar (12) = '',
	@first_out varchar (12) = '',
	@second_in varchar (12) = '',
	@second_out varchar (12) = '',
	@rest_day tinyint = 0,

	@network_information varchar (MAX) = '',
	@system_user_id varchar (50) = ''
		
AS

	IF EXISTS (SELECT sysid_employee FROM ums.employee_information WHERE sysid_employee = @sysid_employee)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @system_user_id, @network_information

		DECLARE @salary_id bigint

		SET @salary_id = 0

		SELECT @salary_id = salary_id FROM ums.salary_information WHERE sysid_employee = @sysid_employee AND 
							effectivity_date = ums.GetPayrollEffectivityDate(GETDATE()) 

		IF @salary_id > 0
		BEGIN

			UPDATE ums.salary_information SET
				employment_id = @employment_id,
				department_id = @department_id,
				status_id = @status_id,
				level_id = @level_id,
				category_id = @category_id,
				degree_id = @degree_id,
				degree_id_level_points = @degree_id_level_points,
				rate_id = @rate_id,
				is_fixed_loginout = @is_fixed_loginout,
				first_in = @first_in,
				first_out = @first_out,
				second_in = @second_in,
				second_out = @second_out,
				rest_day = @rest_day,

				edited_by = @system_user_id
			WHERE
				salary_id = @salary_id			
				
		END	
		ELSE
		BEGIN

			DECLARE @effectivity_date datetime

			IF EXISTS (SELECT sysid_employee FROM ums.salary_information WHERE sysid_employee = @sysid_employee) -- check if there is already an existing salary information
			BEGIN
				SET @effectivity_date = ums.GetPayrollEffectivityDate(GETDATE())
			END
			ELSE
			BEGIN
				
				IF EXISTS (SELECT year_id FROM ums.school_year)  AND
					(GETDATE() <= (SELECT MAX(date_end) FROM ums.school_year)) -- used if it the creation of the employee salary information for the first time
				BEGIN
					SELECT @effectivity_date = date_start FROM ums.school_year WHERE GETDATE() BETWEEN date_start AND date_end
				END
				ELSE
				BEGIN
					SET @effectivity_date = CONVERT(datetime, CONVERT(varchar, GETDATE(), 101) + ' 12:00:00 AM', 101)
				END

			END
			
			INSERT INTO ums.salary_information
			(
				sysid_employee,
				employment_id,
				department_id,
				effectivity_date,
				status_id,
				level_id,
				category_id,
				degree_id,
				degree_id_level_points,
				rate_id,
				is_fixed_loginout,
				first_in,
				first_out,
				second_in,
				second_out,
				rest_day,
				created_by
			)
			VALUES
			(
				@sysid_employee,
				@employment_id,
				@department_id,
				@effectivity_date,
				@status_id,
				@level_id,
				@category_id,
				@degree_id,
				@degree_id_level_points,
				@rate_id,
				@is_fixed_loginout,
				@first_in,
				@first_out,
				@second_in,
				@second_out,
				@rest_day,
				@system_user_id
			)
		END
	END
	
GO
---------------------------------------------------------


-- ########################################END TABLE "salary_information" OBJECTS######################################################





-- ##########################################TABLE "deduction_information" OBJECTS########################################################

-- verifies if the deduction_information table exists
IF OBJECT_ID('ums.deduction_information', 'U') IS NOT NULL
	DROP TABLE ums.deduction_information
GO
---------------------------------------------------- 

-- creates the table "deduction_information"
CREATE TABLE ums.deduction_information 			
(
	sysid_deduction varchar (50) NOT NULL
		CONSTRAINT Deduction_Information_SysId_Deduction_PK PRIMARY KEY (sysid_deduction)
		CONSTRAINT Deduction_Information_SysId_Deduction_CK CHECK (sysid_deduction LIKE 'SYSDEC%'),
	deduction_description varchar (50) NOT NULL
		CONSTRAINT Deduction_Information_Deduction_Description_UQ UNIQUE (deduction_description),	

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Deduction_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Deduction_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Deduction_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the deduction_information table 
CREATE INDEX Deduction_Information_SysId_Deduction_Index
	ON ums.deduction_information (sysid_deduction ASC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Deduction_Information_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.Deduction_Information_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Deduction_Information_Trigger_Insert
GO

CREATE TRIGGER ums.Deduction_Information_Trigger_Insert
	ON  ums.deduction_information
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_deduction varchar (50)
	DECLARE @deduction_description varchar (50)
	DECLARE @created_by varchar (50)
	
	SELECT 
		@sysid_deduction = sysid_deduction,
		@deduction_description = deduction_description,
		@created_by = created_by
	FROM INSERTED	

	SET @transaction_done = 'CREATED a deduction information ' + 
							'[System ID: ' + @sysid_deduction +
							'][Description: ' + @deduction_description +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Deduction_Information_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Deduction_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Deduction_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Deduction_Information_Trigger_Instead_Update
	ON  ums.deduction_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_deduction varchar (50)
	DECLARE @deduction_description varchar (50)
	DECLARE @edited_by varchar (50)

	DECLARE @deduction_description_b varchar (50)

	DECLARE @has_update bit
	
	SELECT 
		@sysid_deduction = sysid_deduction,
		@deduction_description = deduction_description,
		@edited_by = edited_by
	FROM INSERTED	

	SELECT
		@deduction_description_b = deduction_description
	FROM ums.deduction_information
	WHERE
		sysid_deduction = @sysid_deduction

	SET @transaction_done = ''
	SET @has_update = 0

	IF NOT ISNULL(@deduction_description COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@deduction_description_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Description Before: ' + ISNULL(@deduction_description_b, '') + ']' +
													'[Description After: ' + ISNULL(@deduction_description, '') + ']' 
		SET @has_update = 1
	END

	IF @has_update = 1
	BEGIN

		UPDATE ums.deduction_information SET
			deduction_description = @deduction_description,
			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			sysid_deduction = @sysid_deduction		

		SET @transaction_done = 'UPDATED a deduction information ' + 
								'[System ID: ' + ISNULL(@sysid_deduction, '') + ']' +
								@transaction_done

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
		END
				
		EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done
	
	END

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Deduction_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Deduction_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Deduction_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Deduction_Information_Trigger_Instead_Delete
	ON  ums.deduction_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a deduction information', 'Deduction Information'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "InsertDeductionInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertDeductionInformation')
   DROP PROCEDURE ums.InsertDeductionInformation
GO

CREATE PROCEDURE ums.InsertDeductionInformation

	@sysid_deduction varchar (50) = '',
	@deduction_description varchar (50) = '',

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@created_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@created_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.deduction_information
		(
			sysid_deduction,
			deduction_description,
			created_by
		)
		VALUES
		(
			@sysid_deduction,
			@deduction_description,
			@created_by
		)		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert a deduction information', 'Deduction Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertDeductionInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateDeductionInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateDeductionInformation')
   DROP PROCEDURE ums.UpdateDeductionInformation
GO

CREATE PROCEDURE ums.UpdateDeductionInformation

	@sysid_deduction varchar (50) = '',
	@deduction_description varchar (50) = '',

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@edited_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@edited_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.deduction_information SET
			deduction_description = @deduction_description,
			edited_by = @edited_by
		WHERE
			sysid_deduction = @sysid_deduction
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update a deduction information', 'Deduction Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateDeductionInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectDeductionInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectDeductionInformation')
   DROP PROCEDURE ums.SelectDeductionInformation
GO

CREATE PROCEDURE ums.SelectDeductionInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT sysid_deduction, deduction_description FROM ums.deduction_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a deduction information', 'Deduction Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectDeductionInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountDeductionInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountDeductionInformation')
   DROP PROCEDURE ums.GetCountDeductionInformation
GO

CREATE PROCEDURE ums.GetCountDeductionInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_deduction) FROM ums.deduction_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a deduction information', 'Deduction Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountDeductionInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsDescriptionDeductionInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsDescriptionDeductionInformation')
   DROP PROCEDURE ums.IsExistsDescriptionDeductionInformation
GO

CREATE PROCEDURE ums.IsExistsDescriptionDeductionInformation

	@sysid_deduction varchar (50) = '',
	@deduction_description varchar (50) = '',
	@system_user_id varchar(50) = ''
		
AS

	IF ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1 OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsDescriptionDeductionInfo(@sysid_deduction, @deduction_description)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a deduction information', 'Deduction Information'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsDescriptionDeductionInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsSysIDDeductionInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsSysIDDeductionInformation')
   DROP PROCEDURE ums.IsExistsSysIDDeductionInformation
GO

CREATE PROCEDURE ums.IsExistsSysIDDeductionInformation

	@sysid_deduction varchar (50) = '',
	@system_user_id varchar(50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN
	
		SELECT ums.IsExistsSysIDDeductionInfo(@sysid_deduction)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a deduction information', 'Deduction Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsSysIDDeductionInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistsSysIDDeductionInfo" function already exist
IF OBJECT_ID (N'ums.IsExistsSysIDDeductionInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistsSysIDDeductionInfo
GO

CREATE FUNCTION ums.IsExistsSysIDDeductionInfo
(	
	@sysid_deduction varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_deduction FROM ums.deduction_information WHERE sysid_deduction = @sysid_deduction)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------


-- verifies if the "IsExistsDescriptionDeductionInfo" function already exist
IF OBJECT_ID (N'ums.IsExistsDescriptionDeductionInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistsDescriptionDeductionInfo
GO

CREATE FUNCTION ums.IsExistsDescriptionDeductionInfo
(	
	@sysid_deduction varchar (50) = '',
	@deduction_description varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_deduction FROM ums.deduction_information WHERE ((REPLACE(deduction_description, ' ', '')) LIKE REPLACE(@deduction_description, ' ', ''))
						AND NOT sysid_deduction = @sysid_deduction)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result

END
GO
------------------------------------------------------

-- ##########################################END TABLE "deduction_information" OBJECTS########################################################






-- ##########################################TABLE "employee_deduction" OBJECTS########################################################

-- verifies if the employee_deduction table exists
IF OBJECT_ID('ums.employee_deduction', 'U') IS NOT NULL
	DROP TABLE ums.employee_deduction
GO
---------------------------------------------------- 

-- creates the table "employee_deduction"
CREATE TABLE ums.employee_deduction 			
(
	deduction_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Employee_Deduction_Deduction_ID_PK PRIMARY KEY (deduction_id),
	deduction_date datetime NOT NULL DEFAULT (GETDATE()),
	sysid_deduction varchar (50) NOT NULL
		CONSTRAINT Employee_Deduction_SysId_Deduction_FK FOREIGN KEY REFERENCES ums.deduction_information(sysid_deduction) ON UPDATE NO ACTION,
	sysid_employee varchar (50) NOT NULL 
		CONSTRAINT Employee_Deduction_SysID_Employee_FK FOREIGN KEY REFERENCES ums.employee_information(sysid_employee) ON UPDATE NO ACTION,	
	amount decimal (12, 2) NOT NULL,	

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Employee_Deduction_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Employee_Deduction_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Employee_Deduction_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the employee_deduction table 
CREATE INDEX Employee_Deduction_Deduction_ID_Index
	ON ums.employee_deduction (deduction_id DESC)
GO
------------------------------------------------------------------

-- verifies if the procedure "InsertEmployeeDeduction" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertEmployeeDeduction')
   DROP PROCEDURE ums.InsertEmployeeDeduction
GO

CREATE PROCEDURE ums.InsertEmployeeDeduction

	@deduction_date datetime,
	@sysid_deduction varchar (50) = '',
	@sysid_employee varchar (50) = '',
	@amount decimal (12, 2) = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@created_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@created_by) = 1) AND
		EXISTS (SELECT salary_id FROM ums.salary_information WHERE sysid_employee = @sysid_employee AND status_id <> 4 AND 
					effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = @sysid_employee))
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.employee_deduction
		(
			deduction_date,
			sysid_deduction,
			sysid_employee,
			amount,
			created_by
		)
		VALUES
		(
			@deduction_date,
			@sysid_deduction,
			@sysid_employee,
			@amount,
			@created_by
		)		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert an employeee deduction', 'Employee Deduction'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertEmployeeDeduction TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateEmployeeDeduction" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateEmployeeDeduction')
   DROP PROCEDURE ums.UpdateEmployeeDeduction
GO

CREATE PROCEDURE ums.UpdateEmployeeDeduction

	@deduction_id bigint = 0,
	@deduction_date datetime,
	@sysid_employee varchar (50) = '',
	@amount decimal (12, 2) = 0,

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@edited_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@edited_by) = 1) AND
		EXISTS (SELECT salary_id FROM ums.salary_information WHERE sysid_employee = @sysid_employee AND status_id <> 4 AND 
					effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = @sysid_employee))
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.employee_deduction SET
			deduction_date = @deduction_date,			
			amount = @amount,
			edited_by = @edited_by
		WHERE
			deduction_id = @deduction_id
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update an employeee deduction', 'Employee Deduction'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateEmployeeDeduction TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteEmployeeDeduction" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteEmployeeDeduction')
   DROP PROCEDURE ums.DeleteEmployeeDeduction
GO

CREATE PROCEDURE ums.DeleteEmployeeDeduction

	@deduction_id bigint = 0,
	@sysid_employee varchar (50) = '',

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@deleted_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@deleted_by) = 1) AND
		EXISTS (SELECT salary_id FROM ums.salary_information WHERE sysid_employee = @sysid_employee AND status_id <> 4 AND 
					effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = @sysid_employee))
	BEGIN

		EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information
						
		UPDATE ums.employee_deduction SET
			edited_by = @deleted_by
		WHERE
			deduction_id = @deduction_id
				
		DELETE FROM ums.employee_deduction WHERE deduction_id = @deduction_id
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete an employeee deduction', 'Employee Deduction'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteEmployeeDeduction TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByDateFromDateToSysIDEmployeeEmployeeDeduction" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByDateFromDateToSysIDEmployeeEmployeeDeduction')
   DROP PROCEDURE ums.SelectByDateFromDateToSysIDEmployeeEmployeeDeduction
GO

CREATE PROCEDURE ums.SelectByDateFromDateToSysIDEmployeeEmployeeDeduction

	@sysid_employee varchar (50) = '',
	@date_from datetime,
	@date_to datetime,	

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN		

		SELECT 
			ed.deduction_id AS deduction_id, 
			ed.deduction_date AS deduction_date, 
			di.deduction_description AS deduction_description, 
			ed.amount AS amount
		FROM 
			ums.employee_deduction AS ed
		INNER JOIN ums.deduction_information AS di ON di.sysid_deduction = ed.sysid_deduction
		WHERE 
			ed.sysid_employee = @sysid_employee AND (ed.deduction_date BETWEEN @date_from AND @date_to)
		ORDER BY
			ed.deduction_date DESC
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an employeee deduction', 'Employee Deduction'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByDateFromDateToSysIDEmployeeEmployeeDeduction TO db_umsusers
GO
-------------------------------------------------------------

-- ##########################################END TABLE "employee_deduction" OBJECTS########################################################


-- ##########################################TABLE "earning_information" OBJECTS###########################################################

-- verifies if the earning_information table exists
IF OBJECT_ID('ums.earning_information', 'U') IS NOT NULL
	DROP TABLE ums.earning_information
GO
---------------------------------------------------- 

-- creates the table "earning_information"
CREATE TABLE ums.earning_information 			
(
	sysid_earning varchar (50) NOT NULL
		CONSTRAINT Earning_Information_SysId_Earning_PK PRIMARY KEY (sysid_earning)
		CONSTRAINT Earning_Information_SysId_Earning_CK CHECK (sysid_earning LIKE 'SYSINC%'),
	earning_description varchar (50) NOT NULL
		CONSTRAINT Earning_Information_Earning_Description_UQ UNIQUE (earning_description),	

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Earning_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Earning_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Earning_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the earning_information table 
CREATE INDEX Earning_Information_SysId_Earning_Index
	ON ums.earning_information (sysid_earning ASC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Earning_Information_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.Earning_Information_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Earning_Information_Trigger_Insert
GO

CREATE TRIGGER ums.Earning_Information_Trigger_Insert
	ON  ums.earning_information
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_earning varchar (50)
	DECLARE @earning_description varchar (50)
	DECLARE @created_by varchar (50)
	
	SELECT 
		@sysid_earning = sysid_earning,
		@earning_description = earning_description,
		@created_by = created_by
	FROM INSERTED	

	SET @transaction_done = 'CREATED an earning information ' + 
							'[System ID: ' + @sysid_earning +
							'][Description: ' + @earning_description +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Earning_Information_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Earning_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Earning_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Earning_Information_Trigger_Instead_Update
	ON  ums.earning_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_earning varchar (50)
	DECLARE @earning_description varchar (50)
	DECLARE @edited_by varchar (50)

	DECLARE @earning_description_b varchar (50)

	DECLARE @has_update bit
	
	SELECT 
		@sysid_earning = sysid_earning,
		@earning_description = earning_description,
		@edited_by = edited_by
	FROM INSERTED	

	SELECT
		@earning_description_b = earning_description
	FROM ums.earning_information
	WHERE
		sysid_earning = @sysid_earning

	SET @transaction_done = ''
	SET @has_update = 0

	IF NOT ISNULL(@earning_description COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@earning_description_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Description Before: ' + ISNULL(@earning_description_b, '') + ']' +
													'[Description After: ' + ISNULL(@earning_description, '') + ']' 
		SET @has_update = 1
	END

	IF @has_update = 1
	BEGIN

		UPDATE ums.earning_information SET
			earning_description = @earning_description,
			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			sysid_earning = @sysid_earning		

		SET @transaction_done = 'UPDATED an earning information ' + 
								'[System ID: ' + ISNULL(@sysid_earning, '') + ']' +
								@transaction_done

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
		END
				
		EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done
	
	END

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Earning_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Earning_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Earning_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Earning_Information_Trigger_Instead_Delete
	ON  ums.earning_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete an earning information', 'Earning Information'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "InsertEarningInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertEarningInformation')
   DROP PROCEDURE ums.InsertEarningInformation
GO

CREATE PROCEDURE ums.InsertEarningInformation

	@sysid_earning varchar (50) = '',
	@earning_description varchar (50) = '',

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@created_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@created_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.earning_information
		(
			sysid_earning,
			earning_description,
			created_by
		)
		VALUES
		(
			@sysid_earning,
			@earning_description,
			@created_by
		)		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert an earning information', 'Earning Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertEarningInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateEarningInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateEarningInformation')
   DROP PROCEDURE ums.UpdateEarningInformation
GO

CREATE PROCEDURE ums.UpdateEarningInformation

	@sysid_earning varchar (50) = '',
	@earning_description varchar (50) = '',

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@edited_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@edited_by) = 1) 
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.earning_information SET
			earning_description = @earning_description,
			edited_by = @edited_by
		WHERE
			sysid_earning = @sysid_earning
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update an earning information', 'Earning Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateEarningInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectEarningInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectEarningInformation')
   DROP PROCEDURE ums.SelectEarningInformation
GO

CREATE PROCEDURE ums.SelectEarningInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) 
	BEGIN

		SELECT sysid_earning, earning_description FROM ums.earning_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an earning information', 'Earning Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectEarningInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountEarningInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountEarningInformation')
   DROP PROCEDURE ums.GetCountEarningInformation
GO

CREATE PROCEDURE ums.GetCountEarningInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_earning) FROM ums.earning_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an earning information', 'Earning Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountEarningInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsDescriptionEarningInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsDescriptionEarningInformation')
   DROP PROCEDURE ums.IsExistsDescriptionEarningInformation
GO

CREATE PROCEDURE ums.IsExistsDescriptionEarningInformation

	@sysid_earning varchar (50) = '',
	@earning_description varchar (50) = '',
	@system_user_id varchar(50) = ''
		
AS

	IF ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1 OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN
	
		SELECT ums.IsExistsDescriptionEarningInfo(@sysid_earning, @earning_description)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an earning information', 'Earning Information'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsDescriptionEarningInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsSysIDEarningInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsSysIDEarningInformation')
   DROP PROCEDURE ums.IsExistsSysIDEarningInformation
GO

CREATE PROCEDURE ums.IsExistsSysIDEarningInformation

	@sysid_earning varchar (50) = '',
	@system_user_id varchar(50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsSysIDEarningInfo(@sysid_earning)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an earning information', 'Earning Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsSysIDEarningInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistsSysIDEarningInfo" function already exist
IF OBJECT_ID (N'ums.IsExistsSysIDEarningInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistsSysIDEarningInfo
GO

CREATE FUNCTION ums.IsExistsSysIDEarningInfo
(	
	@sysid_earning varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_earning FROM ums.earning_information WHERE sysid_earning = @sysid_earning)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------


-- verifies if the "IsExistsDescriptionEarningInfo" function already exist
IF OBJECT_ID (N'ums.IsExistsDescriptionEarningInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistsDescriptionEarningInfo
GO

CREATE FUNCTION ums.IsExistsDescriptionEarningInfo
(	
	@sysid_earning varchar (50) = '',
	@earning_description varchar (50) = ''

)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_earning FROM ums.earning_information WHERE ((REPLACE(earning_description, ' ', '')) LIKE REPLACE(@earning_description, ' ', ''))
						AND NOT sysid_earning = @sysid_earning)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result

END
GO
------------------------------------------------------


-- ##########################################END TABLE "earning_information" OBJECTS########################################################





-- ##########################################TABLE "employee_earning" OBJECTS########################################################

-- verifies if the employee_earning table exists
IF OBJECT_ID('ums.employee_earning', 'U') IS NOT NULL
	DROP TABLE ums.employee_earning
GO
---------------------------------------------------- 

-- creates the table "employee_earning"
CREATE TABLE ums.employee_earning 			
(
	earning_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Employee_Earning_Earning_ID_PK PRIMARY KEY (earning_id),
	earning_date datetime NOT NULL DEFAULT (GETDATE()),
	sysid_earning varchar (50) NOT NULL
		CONSTRAINT Employee_Earning_SysId_Earning_FK FOREIGN KEY REFERENCES ums.earning_information(sysid_earning) ON UPDATE NO ACTION,
	sysid_employee varchar (50) NOT NULL 
		CONSTRAINT Employee_Earning_SysID_Employee_FK FOREIGN KEY REFERENCES ums.employee_information(sysid_employee) ON UPDATE NO ACTION,
	amount decimal (12, 2) NOT NULL,	

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Employee_Earning_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Employee_Earning_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Employee_Earning_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the employee_earning table 
CREATE INDEX Employee_Earning_Earning_ID_Index
	ON ums.employee_earning (earning_id DESC)
GO
------------------------------------------------------------------


-- verifies if the procedure "InsertEmployeeEarning" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertEmployeeEarning')
   DROP PROCEDURE ums.InsertEmployeeEarning
GO

CREATE PROCEDURE ums.InsertEmployeeEarning

	@earning_date datetime,
	@sysid_earning varchar (50) = '',
	@sysid_employee varchar (50) = '',
	@amount decimal (12, 2) = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@created_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@created_by) = 1) AND
		EXISTS (SELECT salary_id FROM ums.salary_information WHERE sysid_employee = @sysid_employee AND status_id <> 4 AND 
					effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = @sysid_employee))
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.employee_earning
		(
			earning_date,
			sysid_earning,
			sysid_employee,
			amount,
			created_by
		)
		VALUES
		(
			@earning_date,
			@sysid_earning,
			@sysid_employee,
			@amount,
			@created_by
		)		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert an employeee earning', 'Employee Earning'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertEmployeeEarning TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateEmployeeEarning" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateEmployeeEarning')
   DROP PROCEDURE ums.UpdateEmployeeEarning
GO

CREATE PROCEDURE ums.UpdateEmployeeEarning

	@earning_id bigint = 0,
	@earning_date datetime,
	@sysid_employee varchar (50) = '',
	@amount decimal (12, 2) = 0,

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@edited_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@edited_by) = 1) AND
		EXISTS (SELECT salary_id FROM ums.salary_information WHERE sysid_employee = @sysid_employee AND status_id <> 4 AND 
					effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = @sysid_employee))
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.employee_earning SET
			earning_date = @earning_date,			
			amount = @amount,
			edited_by = @edited_by
		WHERE
			earning_id = @earning_id
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update an employeee earning', 'Employee Earning'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateEmployeeEarning TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteEmployeeEarning" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteEmployeeEarning')
   DROP PROCEDURE ums.DeleteEmployeeEarning
GO

CREATE PROCEDURE ums.DeleteEmployeeEarning

	@earning_id bigint = 0,
	@sysid_employee varchar (50) = '',

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@deleted_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@deleted_by) = 1) AND
		EXISTS (SELECT salary_id FROM ums.salary_information WHERE sysid_employee = @sysid_employee AND status_id <> 4 AND 
					effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = @sysid_employee))
	BEGIN

		EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information
						
		UPDATE ums.employee_earning SET
			edited_by = @deleted_by
		WHERE
			earning_id = @earning_id
				
		DELETE FROM ums.employee_earning WHERE earning_id = @earning_id
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete an employeee earning', 'Employee Earnings'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteEmployeeEarning TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByDateFromDateToSysIDEmployeeEmployeeEarning" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByDateFromDateToSysIDEmployeeEmployeeEarning')
   DROP PROCEDURE ums.SelectByDateFromDateToSysIDEmployeeEmployeeEarning
GO

CREATE PROCEDURE ums.SelectByDateFromDateToSysIDEmployeeEmployeeEarning
	
	@sysid_employee varchar (50) = '',
	@date_from datetime,
	@date_to datetime,

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) 
	BEGIN		

		SELECT 
			ee.earning_id AS earning_id, 
			ee.earning_date AS earning_date, 
			ei.earning_description AS earning_description, 
			ee.amount AS amount
		FROM 
			ums.employee_earning AS ee
		INNER JOIN ums.earning_information AS ei ON ei.sysid_earning = ee.sysid_earning
		WHERE 
			ee.sysid_employee = @sysid_employee AND (ee.earning_date BETWEEN @date_from AND @date_to)
		ORDER BY
			ee.earning_date DESC
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an employeee earning', 'Employee Earning'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByDateFromDateToSysIDEmployeeEmployeeEarning TO db_umsusers
GO
-------------------------------------------------------------

-- ##########################################END TABLE "employee_earning" OBJECTS########################################################



-- ##########################################TABLE "loan_type_information" OBJECTS###########################################################

-- verifies if the loan_type_information table exists
IF OBJECT_ID('ums.loan_type_information', 'U') IS NOT NULL
	DROP TABLE ums.loan_type_information
GO
---------------------------------------------------- 

-- creates the table "loan_type_information"
CREATE TABLE ums.loan_type_information 			
(
	sysid_loan varchar (50) NOT NULL
		CONSTRAINT Loan_Type_Information_ID_PK PRIMARY KEY (sysid_loan),
		CONSTRAINT Loan_Type_Information_ID_CK CHECK (sysid_loan LIKE 'SYSLON%'),
	loan_description varchar (50) NOT NULL
		CONSTRAINT Loan_Type_Information_Loan_Description_UQ UNIQUE (loan_description),

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Loan_Type_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Loan_Type_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Loan_Type_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the loan_type_information table 
CREATE INDEX Loan_Type_Information_SysId_Loan_Index
	ON ums.loan_type_information (sysid_loan ASC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Loan_Type_Information_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.Loan_Type_Information_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Loan_Type_Information_Trigger_Insert
GO

CREATE TRIGGER ums.Loan_Type_Information_Trigger_Insert
	ON  ums.loan_type_information
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_loan varchar (50)
	DECLARE @loan_description varchar (50)
	DECLARE @created_by varchar (50)
	
	SELECT 
		@sysid_loan = sysid_loan,
		@loan_description = loan_description,
		@created_by = created_by
	FROM INSERTED	

	SET @transaction_done = 'CREATED a loan type information ' + 
							'[Type ID: ' + @sysid_loan +
							'][Description: ' + @loan_description +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Loan_Type_Information_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Loan_Type_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Loan_Type_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Loan_Type_Information_Trigger_Instead_Update
	ON  ums.loan_type_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_loan varchar (50)
	DECLARE @loan_description varchar (50)
	DECLARE @edited_by varchar (50)

	DECLARE @loan_description_b varchar (50)

	DECLARE @has_update bit
	
	SELECT 
		@sysid_loan = sysid_loan,
		@loan_description = loan_description,
		@edited_by = edited_by
	FROM INSERTED	

	SELECT
		@loan_description_b = loan_description
	FROM ums.loan_type_information
	WHERE
		sysid_loan = @sysid_loan

	SET @transaction_done = ''
	SET @has_update = 0

	IF NOT ISNULL(@loan_description COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@loan_description_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Description Before: ' + ISNULL(@loan_description_b, '') + ']' +
													'[Description After: ' + ISNULL(@loan_description, '') + ']' 
		SET @has_update = 1
	END

	IF @has_update = 1
	BEGIN

		UPDATE ums.loan_type_information SET
			loan_description = @loan_description,
			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			sysid_loan = @sysid_loan		

		SET @transaction_done = 'UPDATED a loan type information ' + 
								'[Type ID: ' + ISNULL(@sysid_loan, '') + ']' +
								@transaction_done

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
		END
				
		EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done
	
	END

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Loan_Type_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Loan_Type_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Loan_Type_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Loan_Type_Information_Trigger_Instead_Delete
	ON  ums.loan_type_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a loan type information', 'Loan Type Information'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "InsertLoanTypeInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertLoanTypeInformation')
   DROP PROCEDURE ums.InsertLoanTypeInformation
GO

CREATE PROCEDURE ums.InsertLoanTypeInformation

	@sysid_loan varchar (50) = '',
	@loan_description varchar (50) = '',

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@created_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@created_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.loan_type_information
		(
			sysid_loan,
			loan_description,
			created_by
		)
		VALUES
		(
			@sysid_loan,
			@loan_description,
			@created_by
		)		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert a loan type information', 'Loan Type Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertLoanTypeInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateLoanTypeInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateLoanTypeInformation')
   DROP PROCEDURE ums.UpdateLoanTypeInformation
GO

CREATE PROCEDURE ums.UpdateLoanTypeInformation

	@sysid_loan varchar (50) = '',
	@loan_description varchar (50) = '',

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@edited_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@edited_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.loan_type_information SET
			loan_description = @loan_description,
			edited_by = @edited_by
		WHERE
			sysid_loan = @sysid_loan
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Updated a loan type information', 'Loan Type Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateLoanTypeInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectLoanTypeInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectLoanTypeInformation')
   DROP PROCEDURE ums.SelectLoanTypeInformation
GO

CREATE PROCEDURE ums.SelectLoanTypeInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) 
	BEGIN

		SELECT sysid_loan, loan_description FROM ums.loan_type_information ORDER BY sysid_loan ASC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a loan type information', 'Loan Type Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectLoanTypeInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountLoanTypeInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountLoanTypeInformation')
   DROP PROCEDURE ums.GetCountLoanTypeInformation
GO

CREATE PROCEDURE ums.GetCountLoanTypeInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) 
	BEGIN

		SELECT COUNT(sysid_loan) FROM ums.loan_type_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a loan type information', 'Loan Type Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountLoanTypeInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsDescriptionLoanTypeInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsDescriptionLoanTypeInformation')
   DROP PROCEDURE ums.IsExistsDescriptionLoanTypeInformation
GO

CREATE PROCEDURE ums.IsExistsDescriptionLoanTypeInformation

	@sysid_loan varchar (50) = '',
	@loan_description varchar (50) = '',
	@system_user_id varchar(50) = ''
		
AS

	IF ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1 OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsDescriptionLoanTypeInfo(@sysid_loan, @loan_description)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a loan type information', 'Loan Type Information'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsDescriptionLoanTypeInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsSysIDLoanTypeInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsSysIDLoanTypeInformation')
   DROP PROCEDURE ums.IsExistsSysIDLoanTypeInformation
GO

CREATE PROCEDURE ums.IsExistsSysIDLoanTypeInformation

	@sysid_loan varchar (50) = '',
	@system_user_id varchar(50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsSysIDLoanTypeInfo(@sysid_loan)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a loan type information', 'Loan Type Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsSysIDLoanTypeInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistsSysIDLoanTypeInfo" function already exist
IF OBJECT_ID (N'ums.IsExistsSysIDLoanTypeInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistsSysIDLoanTypeInfo
GO

CREATE FUNCTION ums.IsExistsSysIDLoanTypeInfo
(	
	@sysid_loan varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_loan FROM ums.loan_type_information WHERE sysid_loan = @sysid_loan)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsExistsDescriptionLoanTypeInfo" function already exist
IF OBJECT_ID (N'ums.IsExistsDescriptionLoanTypeInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistsDescriptionLoanTypeInfo
GO

CREATE FUNCTION ums.IsExistsDescriptionLoanTypeInfo
(	
	@sysid_loan varchar (50) = '',
	@loan_description varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT sysid_loan FROM ums.loan_type_information WHERE ((REPLACE(loan_description, ' ', '')) LIKE REPLACE(@loan_description, ' ', ''))
						AND NOT sysid_loan = @sysid_loan)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result

END
GO
------------------------------------------------------


-- ##########################################END TABLE "loan_type_information" OBJECTS###########################################################





-- ##########################################TABLE "loan_remittance" OBJECTS###########################################################

-- verifies if the loan_remittance_audit table exists
IF OBJECT_ID('ums.loan_remittance_audit', 'U') IS NOT NULL
	DROP TABLE ums.loan_remittance_audit
GO
---------------------------------------------------- 

-- creates the table "loan_remittance_audit"
CREATE TABLE ums.loan_remittance_audit 			
(
	sysid_remittance varchar (50) NOT NULL
		CONSTRAINT Loan_Remittance_Audit_SysId_Remittance_PK PRIMARY KEY (sysid_remittance)
		CONSTRAINT Loan_Remittance_Audit_SysId_Remittance_CK CHECK (sysid_remittance LIKE 'SYSLNR%'),
	sysid_employee varchar (50) NOT NULL 
		CONSTRAINT Loan_Remittance_Audit_SysID_Employee_FK FOREIGN KEY REFERENCES ums.employee_information(sysid_employee) ON UPDATE NO ACTION,
	sysid_loan varchar (50) NOT NULL
		CONSTRAINT Loan_Remittance_Audit_SysId_Loan_FK FOREIGN KEY REFERENCES ums.loan_type_information(sysid_loan) ON UPDATE NO ACTION,
	reference_no varchar (100) NULL,
	release_date datetime NOT NULL,
	maturity_date datetime NOT NULL,
	principal_interest decimal (12, 2) NOT NULL,
	monthly_pay decimal (12, 2) NOT NULL,

	deleted_on datetime NOT NULL DEFAULT (GETDATE()),
	deleted_by varchar (50) NOT NULL
		CONSTRAINT Loan_Remittance_Audit_Deleted_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Loan_Remittance_Audit_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- verifies if the loan_remittance table exists
IF OBJECT_ID('ums.loan_remittance', 'U') IS NOT NULL
	DROP TABLE ums.loan_remittance
GO
---------------------------------------------------- 

-- creates the table "loan_remittance"
CREATE TABLE ums.loan_remittance 			
(
	sysid_remittance varchar (50) NOT NULL
		CONSTRAINT Loan_Remittance_SysId_Remittance_PK PRIMARY KEY (sysid_remittance)
		CONSTRAINT Loan_Remittance_SysId_Remittance_CK CHECK (sysid_remittance LIKE 'SYSLNR%'),
	sysid_employee varchar (50) NOT NULL 
		CONSTRAINT Loan_Remittance_SysID_Employee_FK FOREIGN KEY REFERENCES ums.employee_information(sysid_employee) ON UPDATE NO ACTION,
	sysid_loan varchar (50) NOT NULL
		CONSTRAINT Loan_Remittance_SysId_Loan_FK FOREIGN KEY REFERENCES ums.loan_type_information(sysid_loan) ON UPDATE NO ACTION,
	reference_no varchar (100) NULL,
	release_date datetime NOT NULL,
	maturity_date datetime NOT NULL,
	principal_interest decimal (12, 2) NOT NULL,
	monthly_pay decimal (12, 2) NOT NULL,

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Loan_Remittance_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Loan_Remittance_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Loan_Remittance_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the loan_remittance table 
CREATE INDEX Loan_Remittance_SysId_Remittance_Index
	ON ums.loan_remittance (sysid_remittance DESC)
GO
------------------------------------------------------------------

-- verifies if the procedure "InsertLoanRemittance" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertLoanRemittance')
   DROP PROCEDURE ums.InsertLoanRemittance
GO

CREATE PROCEDURE ums.InsertLoanRemittance

	@sysid_remittance varchar (50) = '',
	@sysid_employee varchar (50) = '',
	@sysid_loan varchar (50) = '',
	@reference_no varchar (100) = '',
	@release_date datetime,
	@maturity_date datetime,
	@principal_interest decimal (12, 2) = 0,
	@monthly_pay decimal (12, 2) = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@created_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@created_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.loan_remittance
		(
			sysid_remittance,
			sysid_employee,
			sysid_loan,
			reference_no,
			release_date,
			maturity_date,
			principal_interest,
			monthly_pay,
			created_by
		)
		VALUES
		(
			@sysid_remittance,
			@sysid_employee,
			@sysid_loan,
			@reference_no,
			@release_date,
			@maturity_date,
			@principal_interest,
			@monthly_pay,
			@created_by
		)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert a loan remittance', 'Loan Remittance'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertLoanRemittance TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateLoanRemittance" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateLoanRemittance')
   DROP PROCEDURE ums.UpdateLoanRemittance
GO

CREATE PROCEDURE ums.UpdateLoanRemittance

	@sysid_remittance varchar (50) = '',
	@sysid_loan varchar (50) = '',
	@reference_no varchar (100) = '',
	@release_date datetime,
	@maturity_date datetime,
	@principal_interest decimal (12, 2) = 0,
	@monthly_pay decimal (12, 2) = 0,

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@edited_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@edited_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.loan_remittance SET
			sysid_loan = @sysid_loan,
			reference_no = @reference_no,
			release_date = @release_date,
			maturity_date = @maturity_date,
			principal_interest = @principal_interest,
			monthly_pay = @monthly_pay,
			edited_by = @edited_by
		WHERE
			sysid_remittance = @sysid_remittance
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update a loan remittance', 'Loan Remittance'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateLoanRemittance TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteLoanRemittance" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteLoanRemittance')
   DROP PROCEDURE ums.DeleteLoanRemittance
GO

CREATE PROCEDURE ums.DeleteLoanRemittance

	@sysid_remittance varchar (50) = '',

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@deleted_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@deleted_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

		UPDATE ums.loan_remittance SET
			edited_by = @deleted_by
		WHERE
			sysid_remittance = @sysid_remittance

		EXECUTE ums.DeleteByLoanEmployeeRemittance @sysid_remittance, @network_information, @deleted_by

		DELETE FROM ums.loan_remittance WHERE sysid_remittance = @sysid_remittance
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete a loan remittance', 'Loan Remittance'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteLoanRemittance TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountLoanRemittance" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountLoanRemittance')
   DROP PROCEDURE ums.GetCountLoanRemittance
GO

CREATE PROCEDURE ums.GetCountLoanRemittance

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.CountTotalLoanRemittance()
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a loan remittance', 'Loan Remittance'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountLoanRemittance TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByEmployeeIDLoanRemittance" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByEmployeeIDLoanRemittance')
   DROP PROCEDURE ums.SelectByEmployeeIDLoanRemittance
GO

CREATE PROCEDURE ums.SelectByEmployeeIDLoanRemittance

	@sysid_employee varchar (50) = '',
	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT 
			lr.sysid_remittance AS sysid_remittance,
			lr.sysid_loan AS sysid_loan,
			lr.reference_no AS reference_no,
			lti.loan_description AS loan_description,
			lr.release_date AS release_date,
			lr.maturity_date AS maturity_date,
			lr.principal_interest AS principal_interest,
			lr.monthly_pay AS monthly_pay
		FROM ums.loan_remittance AS lr
		INNER JOIN ums.loan_type_information AS lti ON lti.sysid_loan = lr.sysid_loan
		WHERE
			lr.sysid_employee = @sysid_employee
		ORDER BY
			lr.release_date DESC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a loan remittance', 'Loan Remittance'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByEmployeeIDLoanRemittance TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsSysIDLoanRemittance" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsSysIDLoanRemittance')
   DROP PROCEDURE ums.IsExistsSysIDLoanRemittance
GO

CREATE PROCEDURE ums.IsExistsSysIDLoanRemittance

	@sysid_remittance varchar (50) = '',
	@system_user_id varchar(50) = ''
		
AS

	IF ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1 OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsSysIDLoanRem(@sysid_remittance)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a loan remittance', 'Loan Remittance'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsSysIDLoanRemittance TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistsSysIDLoanRem" function already exist
IF OBJECT_ID (N'ums.IsExistsSysIDLoanRem') IS NOT NULL
   DROP FUNCTION ums.IsExistsSysIDLoanRem
GO

CREATE FUNCTION ums.IsExistsSysIDLoanRem
(	
	@sysid_remittance varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_remittance FROM ums.loan_remittance WHERE sysid_remittance = @sysid_remittance) OR
		EXISTS (SELECT sysid_remittance FROM ums.loan_remittance_audit WHERE sysid_remittance = @sysid_remittance)
	BEGIN
		SET @result = 1
	END
	ELSE
	BEGIN
		SET @result = 0
	END	
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "GetCountOutstandingLoans" function already exist
IF OBJECT_ID (N'ums.GetCountOutstandingLoans') IS NOT NULL
   DROP FUNCTION ums.GetCountOutstandingLoans
GO

CREATE FUNCTION ums.GetCountOutstandingLoans
(	
	@sysid_employee varchar (50) = ''
)
RETURNS smallint
AS
BEGIN
	
	DECLARE @result smallint

	DECLARE @sysid_remittance varchar (50)
	DECLARE @principal_interest decimal (12, 2)

	SET @result = 0

	DECLARE outstanding_loans_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
		FOR SELECT lr.sysid_remittance, lr.principal_interest
				FROM ums.loan_remittance AS lr	
				WHERE lr.sysid_employee = @sysid_employee
		
	OPEN outstanding_loans_cursor

	FETCH NEXT FROM outstanding_loans_cursor
		INTO @sysid_remittance, @principal_interest

	WHILE @@FETCH_STATUS = 0
	BEGIN

		DECLARE @remittance_sum decimal (12, 2)

		SET @remittance_sum = 0

		IF EXISTS (SELECT sysid_remittance FROM employee_remittance WHERE sysid_remittance = @sysid_remittance)
		BEGIN		
			SELECT @remittance_sum = SUM(amount_paid) FROM employee_remittance WHERE sysid_remittance = @sysid_remittance
		END

		IF @remittance_sum < @principal_interest
		BEGIN
			SET @result = @result + 1
		END
			
		FETCH NEXT FROM outstanding_loans_cursor
			INTO @sysid_remittance, @principal_interest

	END
	
	CLOSE outstanding_loans_cursor
	DEALLOCATE outstanding_loans_cursor
	
	RETURN @result

END
GO
------------------------------------------------------

/*verifies if the "CountTotalLoanRemittance" function already exist*/
IF OBJECT_ID (N'ums.CountTotalLoanRemittance') IS NOT NULL
   DROP FUNCTION ums.CountTotalLoanRemittance
GO

CREATE FUNCTION ums.CountTotalLoanRemittance
(		
)
RETURNS int
AS
BEGIN
	
	DECLARE @total int 
	DECLARE @total_audit int
	
	SELECT 
		@total = COUNT(sysid_remittance) 
	FROM 
		ums.loan_remittance

	SELECT 
		@total_audit = COUNT(sysid_remittance) 
	FROM 
		ums.loan_remittance_audit

	RETURN (@total + @total_audit)

END
GO
/*-------------------------------------------------------*/

-- ##########################################END TABLE "loan_remittance" OBJECTS###########################################################



-- ##########################################TABLE "employee_remittance" OBJECTS###########################################################

-- verifies if the employee_remittance table exists
IF OBJECT_ID('ums.employee_remittance', 'U') IS NOT NULL
	DROP TABLE ums.employee_remittance
GO
---------------------------------------------------- 

-- creates the table "employee_remittance"
CREATE TABLE ums.employee_remittance 			
(
	remittance_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Employee_Remittance_ID_PK PRIMARY KEY (remittance_id),
	sysid_remittance varchar (50) NOT NULL
		CONSTRAINT Employee_Remittance_SysId_Remittance_FK FOREIGN KEY REFERENCES ums.loan_remittance(sysid_remittance) ON UPDATE NO ACTION,
	remittance_date datetime NOT NULL,
	pay_month smallint NOT NULL,
	pay_balance smallint NOT NULL,
	amount_paid decimal (12, 2) NOT NULL,
	amount_balance decimal (12, 2) NOT NULL,	

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Employee_Remittance_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Employee_Remittance_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Employee_Remittance_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the employee_remittance table 
CREATE INDEX Employee_Remittance_Remittance_ID_Index
	ON ums.employee_remittance (remittance_id DESC)
GO
------------------------------------------------------------------

-- verifies if the procedure "InsertEmployeeRemittance" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertEmployeeRemittance')
   DROP PROCEDURE ums.InsertEmployeeRemittance
GO

CREATE PROCEDURE ums.InsertEmployeeRemittance

	@sysid_remittance varchar (50) = '',
	@remittance_date datetime,
	@pay_month smallint = 0,
	@pay_balance smallint = 0,
	@amount_paid decimal (12, 2) = 0,
	@amount_balance decimal (12, 2) = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@created_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@created_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.employee_remittance
		(
			sysid_remittance,
			remittance_date,
			pay_month,
			pay_balance,
			amount_paid,
			amount_balance,
			created_by
		)
		VALUES
		(
			@sysid_remittance,
			@remittance_date,
			@pay_month,
			@pay_balance,
			@amount_paid,
			@amount_balance,
			@created_by
		)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert an employee remittance', 'Employee Remittance'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertEmployeeRemittance TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateEmployeeRemittance" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateEmployeeRemittance')
   DROP PROCEDURE ums.UpdateEmployeeRemittance
GO

CREATE PROCEDURE ums.UpdateEmployeeRemittance

	@remittance_id bigint = 0,
	@remittance_date datetime,
	@pay_month smallint = 0,
	@pay_balance smallint = 0,
	@amount_paid decimal (12, 2) = 0,
	@amount_balance decimal (12, 2) = 0,

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@edited_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@edited_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.employee_remittance SET
			remittance_date = @remittance_date,
			pay_month = @pay_month,
			pay_balance = @pay_balance,
			amount_paid = @amount_paid,
			amount_balance = @amount_balance,
			edited_by = @edited_by
		WHERE
			remittance_id = @remittance_id
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update an employee remittance', 'Employee Remittance'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateEmployeeRemittance TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteByRemittanceEmployeeRemittance" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteByRemittanceEmployeeRemittance')
   DROP PROCEDURE ums.DeleteByRemittanceEmployeeRemittance
GO

CREATE PROCEDURE ums.DeleteByRemittanceEmployeeRemittance

	@remittance_id bigint = 0,

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@deleted_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@deleted_by) = 1)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

		UPDATE ums.employee_remittance SET
			edited_by = @deleted_by
		WHERE
			@remittance_id = @remittance_id

		DELETE FROM ums.employee_remittance WHERE remittance_id = @remittance_id
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete an employee remittance', 'Employee Remittance'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteByRemittanceEmployeeRemittance TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteByLoanEmployeeRemittance" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteByLoanEmployeeRemittance')
   DROP PROCEDURE ums.DeleteByLoanEmployeeRemittance
GO

CREATE PROCEDURE ums.DeleteByLoanEmployeeRemittance

	@sysid_remittance varchar (50) = '',

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@deleted_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@deleted_by) = 1) 
	BEGIN

		UPDATE ums.employee_remittance SET
			edited_by = @deleted_by
		WHERE
			sysid_remittance = @sysid_remittance

		DELETE FROM ums.employee_remittance WHERE sysid_remittance = @sysid_remittance
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete an employee remittance', 'Employee Remittance'
	END
	
GO
---------------------------------------------------------

-- verifies if the procedure "SelectByEmployeeIDEmployeeRemittance" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByEmployeeIDEmployeeRemittance')
   DROP PROCEDURE ums.SelectByEmployeeIDEmployeeRemittance
GO

CREATE PROCEDURE ums.SelectByEmployeeIDEmployeeRemittance

	@sysid_employee varchar (50) = '',
	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT 
			er.remittance_id AS remittance_id,
			er.sysid_remittance AS sysid_remittance,
			er.remittance_date AS remittance_date,
			er.pay_month AS pay_month,
			er.pay_balance AS pay_balance,
			er.amount_paid AS amount_paid,
			er.amount_balance AS amount_balance
		FROM ums.employee_remittance AS er
		INNER JOIN ums.loan_remittance AS lr ON lr.sysid_remittance = er.sysid_remittance
		WHERE
			lr.sysid_employee = @sysid_employee
		ORDER BY
			er.remittance_date ASC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an employee remittance', 'Employee Remittance'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByEmployeeIDEmployeeRemittance TO db_umsusers
GO
-------------------------------------------------------------

-- ##########################################END TABLE "employee_remittance" OBJECTS###########################################################



-- ######################################RESTORE DEPENDENT TABLE CONSTRAINTS#############################################################

--verifies if the Special_Class_Information_SysID_Employee_FK constraint exists
IF OBJECT_ID('ums.special_class_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_information WITH NOCHECK
	ADD CONSTRAINT Special_Class_Information_SysID_Employee_FK FOREIGN KEY (sysid_employee) REFERENCES ums.employee_information(sysid_employee) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Subject_Schedule_Week_ID_FK constraint exists
IF OBJECT_ID('ums.subject_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_schedule WITH NOCHECK
	ADD CONSTRAINT Subject_Schedule_Week_ID_FK FOREIGN KEY (week_id) REFERENCES ums.week_day(week_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Teacher_Load_SysID_Employee_FK constraint exists
IF OBJECT_ID('ums.teacher_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.teacher_load WITH NOCHECK
	ADD CONSTRAINT Teacher_Load_SysID_Employee_FK FOREIGN KEY (sysid_employee) REFERENCES ums.employee_information(sysid_employee) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Miscellaneous_Income_SysID_Employee_FK constraint exists
IF OBJECT_ID('ums.miscellaneous_income', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.miscellaneous_income WITH NOCHECK
	ADD CONSTRAINT Miscellaneous_Income_SysID_Employee_FK FOREIGN KEY (sysid_employee) REFERENCES ums.employee_information(sysid_employee) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

-- ######################################END RESTORE DEPENDENT TABLE CONSTRAINTS#############################################################




-- ############################################INITIAL DATABASE INFORMATION#############################################################

-- ums.week_day
INSERT INTO ums.week_day(week_id, week_description, acronym) VALUES (0, 'Sunday', 'Sun')
INSERT INTO ums.week_day(week_id, week_description, acronym) VALUES (1, 'Monday', 'M')
INSERT INTO ums.week_day(week_id, week_description, acronym) VALUES (2, 'Tuesday', 'T')
INSERT INTO ums.week_day(week_id, week_description, acronym) VALUES (3, 'Wednesday', 'W')
INSERT INTO ums.week_day(week_id, week_description, acronym) VALUES (4, 'Thursday', 'Th')
INSERT INTO ums.week_day(week_id, week_description, acronym) VALUES (5, 'Friday', 'F')
INSERT INTO ums.week_day(week_id, week_description, acronym) VALUES (6, 'Saturday', 'Sat')

-- ums.employment_status
-- is used to determine the employee status
INSERT INTO ums.employment_status(status_id, status_description) VALUES (1, 'Temporary/Part-Time')
INSERT INTO ums.employment_status(status_id, status_description) VALUES (2, 'Probationary')
INSERT INTO ums.employment_status(status_id, status_description) VALUES (3, 'Regular')
INSERT INTO ums.employment_status(status_id, status_description) VALUES (4, 'LAY-OFF')
GO

-- ums.rank_group
-- is used to determine the rank group of the employee
INSERT INTO ums.rank_group(rank_group_id, group_no, group_description) VALUES ('RG01', 1, 'College Faculty')
INSERT INTO ums.rank_group(rank_group_id, group_no, group_description) VALUES ('RG02', 2, 'Grade School / High School Faculty')
INSERT INTO ums.rank_group(rank_group_id, group_no, group_description) VALUES ('RG03', 3, 'Staff / Academic Non-Teaching')
INSERT INTO ums.rank_group(rank_group_id, group_no, group_description) VALUES ('RG04', 4, 'Maintenance')
GO

-- ums.employment_type
-- is used to determine the employment type of the employee to get the rank and basic salary
INSERT INTO ums.employment_type(employment_id, rank_group_id, type_no, type_description, type_acronym) 
					VALUES ('ET01', 'RG01', 1, 'Graduate School Faculty', 'Faculty')
INSERT INTO ums.employment_type(employment_id, rank_group_id, type_no, type_description, type_acronym) 
					VALUES ('ET02', 'RG01', 2, 'Graduate School and College Faculty', 'Faculty')
INSERT INTO ums.employment_type(employment_id, rank_group_id, type_no, type_description, type_acronym) 
					VALUES ('ET03', 'RG02', 3, 'Graduate School and H.S. Faculty', 'Faculty')
INSERT INTO ums.employment_type(employment_id, rank_group_id, type_no, type_description, type_acronym) 
					VALUES ('ET04', 'RG02', 4, 'Graduate School, G.S./Kindergarten Faculty', 'Faculty')
INSERT INTO ums.employment_type(employment_id, rank_group_id, type_no, type_description, type_acronym) 
					VALUES ('ET05', 'RG01', 5, 'College Faculty', 'Faculty')
INSERT INTO ums.employment_type(employment_id, rank_group_id, type_no, type_description, type_acronym) 
					VALUES ('ET06', 'RG02', 6, 'High School Faculty', 'Faculty')
INSERT INTO ums.employment_type(employment_id, rank_group_id, type_no, type_description, type_acronym) 
					VALUES ('ET07', 'RG02', 7, 'Grade School/Kindergarten Faculty', 'Faculty')
INSERT INTO ums.employment_type(employment_id, rank_group_id, type_no, type_description, type_acronym) 
					VALUES ('ET08', 'RG03', 8, 'Non-Teaching Staff', 'Staff')
INSERT INTO ums.employment_type(employment_id, rank_group_id, type_no, type_description, type_acronym) 
					VALUES ('ET09', 'RG03', 9, 'Academic Non-Teaching Staff', 'Staff')
INSERT INTO ums.employment_type(employment_id, rank_group_id, type_no, type_description, type_acronym) 
					VALUES ('ET10', 'RG04', 10, 'Maintenance', 'Maintenance')
GO

-- ums.rank_level
-- this is used for the rank level information and determine what rank level an employment category belongs
INSERT INTO ums.rank_level(level_id, rank_group_id, level_no, level_description) VALUES ('RL001', 'RG04', 1, 'Level I')
INSERT INTO ums.rank_level(level_id, rank_group_id, level_no, level_description) VALUES ('RL002', 'RG04', 2, 'Level II')
INSERT INTO ums.rank_level(level_id, rank_group_id, level_no, level_description) VALUES ('RL003', 'RG03', 3, 'Level III')
INSERT INTO ums.rank_level(level_id, rank_group_id, level_no, level_description) VALUES ('RL004', 'RG03', 4, 'Level IV')
INSERT INTO ums.rank_level(level_id, rank_group_id, level_no, level_description) VALUES ('RL005', 'RG03', 5, 'Level V')
INSERT INTO ums.rank_level(level_id, rank_group_id, level_no, level_description) VALUES ('RL006', 'RG03', 6, 'Level VI')
INSERT INTO ums.rank_level(level_id, rank_group_id, level_no, level_description) VALUES ('RL007', 'RG02', 7, 'Level VII')
INSERT INTO ums.rank_level(level_id, rank_group_id, level_no, level_description) VALUES ('RL008', 'RG01', 8, 'Level VIII')
GO

-- ums.rank_category
-- Level I (Maintenance)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00001', 'RL001', 1, 'Hiring')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00002', 'RL001', 3, 'Rank 1')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00003', 'RL001', 4, 'Rank 2')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00004', 'RL001', 5, 'Rank 3')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00005', 'RL001', 6, 'Rank 4')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00006', 'RL001', 7, 'Rank 5')

-- Level II (Maintenance)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00007', 'RL002', 1, 'Hiring')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00008', 'RL002', 3, 'Rank 1')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00009', 'RL002', 4, 'Rank 2')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00010', 'RL002', 5, 'Rank 3')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00011', 'RL002', 6, 'Rank 4')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00012', 'RL002', 7, 'Rank 5')

-- Level III (Staff)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00013', 'RL003', 1, 'Hiring')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00014', 'RL003', 3, 'Rank 1')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00015', 'RL003', 4, 'Rank 2')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00016', 'RL003', 5, 'Rank 3')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00017', 'RL003', 6, 'Rank 4')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00018', 'RL003', 7, 'Rank 5')

-- Level IV (Staff)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00019', 'RL004', 1, 'Hiring')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00020', 'RL004', 3, 'Rank 1')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00021', 'RL004', 4, 'Rank 2')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00022', 'RL004',	5, 'Rank 3')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00023', 'RL004', 6, 'Rank 4')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00024', 'RL004', 7, 'Rank 5')

-- Level V (Staff)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00025', 'RL005', 1, 'Hiring')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00026', 'RL005', 3, 'Rank 1')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00027', 'RL005', 4, 'Rank 2')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00028', 'RL005', 5, 'Rank 3')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00029', 'RL005', 6, 'Rank 4')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00030', 'RL005', 7, 'Rank 5')

-- Level VI (Staff)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00031', 'RL006', 1, 'Hiring')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00032', 'RL006', 3, 'Rank 1')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00033', 'RL006', 4, 'Rank 2')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00034', 'RL006', 5, 'Rank 3')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00035', 'RL006', 6, 'Rank 4')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00036', 'RL006', 7, 'Rank 5')

-- Level VII (Grade School and High School)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00037', 'RL007', 1, 'Hiring')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00038', 'RL007', 2, 'Year')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00039', 'RL007', 3, 'Teacher')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00040', 'RL007', 4, 'Junior Teacher')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00041', 'RL007', 5, 'Senior Teacher')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00042', 'RL007', 6, 'Master Teacher')

-- Level VIII (College Faculty)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00043', 'RL008', 1, 'Hiring')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00044', 'RL008', 2, 'Year')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00045', 'RL008', 3, 'Assistant Instructor')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00046', 'RL008', 4, 'Instructor')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00047', 'RL008', 5, 'Senior Instructor')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00048', 'RL008', 6, 'Assistant Professor')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00049', 'RL008', 7, 'Associate Professor')
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00050', 'RL008', 8, 'Full Pledge')

-- Level I (Maintenance)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00051', 'RL001', 2, 'Regular')

-- Level II (Maintenance)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00052', 'RL002', 2, 'Regular')

-- Level III (Staff)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00053', 'RL003', 2, 'Regular')

-- Level IV (Staff)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00054', 'RL004', 2, 'Regular')

-- Level V (Staff)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00055', 'RL005', 2, 'Regular')

-- Level VI (Staff)
INSERT INTO ums.rank_category(category_id, level_id, category_no, category_description) VALUES ('RC00056', 'RL006', 2, 'Regular')

GO

-- ums.rank_degree
-- Level I (Maintenance)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00001', 'RC00001', 1, 'Hiring')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00002', 'RC00002', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00003', 'RC00002', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00004', 'RC00002', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00005', 'RC00003', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00006', 'RC00003', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00007', 'RC00003', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00008', 'RC00004', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00009', 'RC00004', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00010', 'RC00004', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00011', 'RC00005', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00012', 'RC00005', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00013', 'RC00005', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00014', 'RC00006', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00015', 'RC00006', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00016', 'RC00006', 3, 'C')

-- Level II (Maintenance)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00017', 'RC00007', 1, 'Hiring')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00018', 'RC00008', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00019', 'RC00008', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00020', 'RC00008', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00021', 'RC00009', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00022', 'RC00009', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00023', 'RC00009', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00024', 'RC00010', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00025', 'RC00010', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00026', 'RC00010', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00027', 'RC00011', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00028', 'RC00011', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00029', 'RC00011', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00030', 'RC00012', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00031', 'RC00012', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00032', 'RC00012', 3, 'C')

-- Level III (Staff)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00033', 'RC00013', 1, 'Hiring')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00034', 'RC00014', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00035', 'RC00014', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00036', 'RC00014', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00037', 'RC00015', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00038', 'RC00015', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00039', 'RC00015', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00040', 'RC00016', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00041', 'RC00016', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00042', 'RC00016', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00043', 'RC00017', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00044', 'RC00017', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00045', 'RC00017', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00046', 'RC00018', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00047', 'RC00018', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00048', 'RC00018', 3, 'C')

-- Level IV (Staff)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00049', 'RC00019', 1, 'Hiring')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00050', 'RC00020', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00051', 'RC00020', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00052', 'RC00020', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00053', 'RC00021', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00054', 'RC00021', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00055', 'RC00021', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00056', 'RC00022', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00057', 'RC00022', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00058', 'RC00022', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00059', 'RC00023', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00060', 'RC00023', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00061', 'RC00023', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00062', 'RC00024', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00063', 'RC00024', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00064', 'RC00024', 3, 'C')

-- Level V (Staff)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00065', 'RC00025', 1, 'Hiring')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00066', 'RC00026', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00067', 'RC00026', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00068', 'RC00026', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00069', 'RC00027', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00070', 'RC00027', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00071', 'RC00027', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00072', 'RC00028', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00073', 'RC00028', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00074', 'RC00028', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00075', 'RC00029', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00076', 'RC00029', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00077', 'RC00029', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00078', 'RC00030', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00079', 'RC00030', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00080', 'RC00030', 3, 'C')

-- Level VI (Staff)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00081', 'RC00031', 1, 'Hiring')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00082', 'RC00032', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00083', 'RC00032', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00084', 'RC00032', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00085', 'RC00033', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00086', 'RC00033', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00087', 'RC00033', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00088', 'RC00034', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00089', 'RC00034', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00090', 'RC00034', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00091', 'RC00035', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00092', 'RC00035', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00093', 'RC00035', 3, 'C')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00094', 'RC00036', 1, 'A')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00095', 'RC00036', 2, 'B')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00096', 'RC00036', 3, 'C')

-- Level VII (Grade School and High School)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00097', 'RC00037', 1, 'Hiring')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00098', 'RC00038', 1, '1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00099', 'RC00038', 2, '2')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00100', 'RC00038', 3, '3')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00101', 'RC00039', 1, '1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00102', 'RC00039', 2, '2')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00103', 'RC00039', 3, '3')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00104', 'RC00039', 4, '4')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00105', 'RC00039', 5, '5')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00106', 'RC00040', 1, '1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00107', 'RC00040', 2, '2')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00108', 'RC00040', 3, '3')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00109', 'RC00040', 4, '4')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00110', 'RC00040', 5, '5')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00111', 'RC00041', 1, '1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00112', 'RC00041', 2, '2')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00113', 'RC00041', 3, '3')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00114', 'RC00041', 4, '4')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00115', 'RC00041', 5, '5')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00116', 'RC00042', 1, '1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00117', 'RC00042', 2, '2')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00118', 'RC00042', 3, '3')

-- Level VIII (College Faculty)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00119', 'RC00043', 1, 'Hiring')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00120', 'RC00044', 1, '1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00121', 'RC00044', 2, '2')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00122', 'RC00044', 3, '3')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00123', 'RC00045', 1, '1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00124', 'RC00045', 2, '2')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00125', 'RC00045', 3, '3')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00126', 'RC00046', 1, '1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00127', 'RC00046', 2, '2')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00128', 'RC00046', 3, '3')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00129', 'RC00047', 1, '1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00130', 'RC00047', 2, '2')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00131', 'RC00047', 3, '3')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00132', 'RC00048', 1, '1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00133', 'RC00048', 2, '2')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00134', 'RC00048', 3, '3')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00135', 'RC00049', 1, '1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00136', 'RC00049', 2, '2')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00137', 'RC00049', 3, '3')

INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00138', 'RC00050', 1, '1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00139', 'RC00050', 2, '2')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00140', 'RC00050', 3, '3')

-- Level I (Maintenance)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00141', 'RC00051', 1, 'Regular')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00142', 'RC00051', 2, 'Year 1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00143', 'RC00051', 3, 'Year 2')

-- Level II (Maintenance)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00144', 'RC00052', 1, 'Regular')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00145', 'RC00052', 2, 'Year 1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00146', 'RC00052', 3, 'Year 2')

-- Level III (Staff)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00147', 'RC00053', 1, 'Regular')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00148', 'RC00053', 2, 'Year 1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00149', 'RC00053', 3, 'Year 2')

-- Level IV (Staff)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00150', 'RC00054', 1, 'Regular')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00151', 'RC00054', 2, 'Year 1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00152', 'RC00054', 3, 'Year 2')

-- Level V (Staff)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00153', 'RC00055', 1, 'Regular')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00154', 'RC00055', 2, 'Year 1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00155', 'RC00055', 3, 'Year 2')

-- Level VI (Staff)
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00156', 'RC00056', 1, 'Regular')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00157', 'RC00056', 2, 'Year 1')
INSERT INTO ums.rank_degree(degree_id, category_id, degree_no, degree_description) VALUES ('RD00158', 'RC00056', 3, 'Year 2')


GO

-- rank_salary_rate
-- is used to insert the rank salary rate
-- Level I (Maintenance)
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00001', 'NA', 7500.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00141', 'NA', 7700.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00142', 'NA', 7900.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00143', 'NA', 8100.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00002', '52-Below', 8689.36, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00003', '53-56', 8923.66, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00004', '57-60', 9164.80, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00005', '61-64', 9650.89, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00006', '65-68', 9913.33, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00007', '69-72', 10183.44, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00008', '73-76', 10557.75, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00009', '77-79', 10846.65, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00010', '80-82', 11143.99, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00011', '83-85', 11555.93, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00012', '86-88', 11873.97, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00013', '89-91', 12201.29, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00014', '92-94', 12654.69, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00015', '95-97', 13004.83, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00016', '98-100', 13365.20, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

-- Level II (Maintenance)
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00017', 'NA', 7700.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00144', 'NA', 7900.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00145', 'NA', 8100.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00146', 'NA', 8300.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00018', '52-Below', 8933.51, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00019', '53-56', 9174.83, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00020', '57-60', 9423.20, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00021', '61-64', 9923.89, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00022', '65-68', 10194.20, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00023', '69-72', 10472.41, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00024', '73-76', 10857.95, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00025', '77-79', 11155.50, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00026', '80-82', 11461.77, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00027', '83-85', 11886.07, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00028', '86-88', 12213.64, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00029', '89-91', 12550.80, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00030', '92-94', 13017.81, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00031', '95-97', 13378.43, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00032', '98-100', 13749.62, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

-- Level III (Staff)
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00033', 'NA', 8000.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00147', 'NA', 8200.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00148', 'NA', 8500.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00149', 'NA', 8700.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00034', '58-Below', 9268.79, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00035', '59-61', 9519.78, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00036', '62-64', 9778.07, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00037', '65-67', 10298.79, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00038', '68-70', 10579.93, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00039', '71-73', 10869.26, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00040', '74-76', 11270.23, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00041', '77-79', 11579.69, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00042', '80-82', 11898.19, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00043', '83-85', 12339.46, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00044', '86-88', 12680.14, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00045', '89-91', 13019.76, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00046', '92-94', 13516.14, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00047', '95-97', 13891.52, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00048', '98-100', 14277.54, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

-- Level IV (Staff)
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00049', 'NA', 8300.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00150', 'NA', 8500.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00151', 'NA', 8800.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00152', 'NA', 9100.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00050', '58-Below', 9617.38, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00051', '59-61', 9878.53, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00052', '62-64', 10147.16, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00053', '65-67', 10688.69, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00054', '68-70', 10981.07, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00055', '71-73', 11281.98, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00056', '74-76', 11698.88, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00057', '77-79', 12020.83, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00058', '80-82', 12352.08, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00059', '83-85', 12800.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00060', '86-88', 13165.30, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00061', '89-91', 13529.96, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00062', '92-94', 14035.08, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00063', '95-97', 14425.13, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00064', '98-100', 14826.61, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

-- Level V (Staff)
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00065', 'NA', 8700.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00153', 'NA', 8900.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00154', 'NA', 9200.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00155', 'NA', 9500.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00066', '58-Below', 10070.82, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00067', '59-61', 10344.88, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00068', '62-64', 10626.96, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00069', '65-67', 11195.58, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00070', '68-70', 11502.58, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00071', '71-73', 11818.53, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00072', '74-76', 12256.37, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00073', '77-79', 12594.31, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00074', '80-82', 12942.12, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00075', '83-85', 13424.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00076', '86-88', 13796.01, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00077', '89-91', 14178.91, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00078', '92-94', 14709.28, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00079', '95-97', 15118.83, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00080', '98-100', 15540.39, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

-- Level VI (Staff)
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00081', 'NA', 9200.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00156', 'NA', 9400.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00157', 'NA', 9700.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00158', 'NA', 10000.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00082', '58-Below', 10546.74, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00083', '59-61', 10834.56, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00084', '62-64', 11130.74, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00085', '65-67', 11727.78, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00086', '68-70', 12050.13, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00087', '71-73', 12381.88, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00088', '74-76', 12841.64, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00089', '77-79', 13196.46, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00090', '80-82', 13561.65, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00091', '83-85', 14067.63, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00092', '86-88', 14458.23, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00093', '89-91', 14860.28, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00094', '92-94', 15417.16, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00095', '95-97', 15747.20, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00096', '98-100', 16289.84, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

-- Level VII (Grade School and High School)
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00097', 'NA', 11000.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00098', 'NA', 10750.00, 350.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00099', 'NA', 10850.00, 450.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00100', 'NA', 11000.00, 500.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00101', '36-Below', 11762.99, 588.15, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00102', '37-40.5', 12087.50, 604.38, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00103', '41-44.5', 12421.50, 621.08, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00104', '45-48.5', 12871.09, 643.55, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00105', '49-52.5', 13228.07, 661.40, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00106', '53-57.5', 13609.17, 680.46, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00107', '58-61.5', 14104.38, 705.22, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00108', '62-66.5', 14497.39, 724.87, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00109', '67-69.5', 14901.92, 745.10, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00110', '70-73.5', 15447.13, 772.36, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00111', '74-77.5', 15894.78, 794.74, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00112', '78-81.5', 16340.19, 817.01, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00113', '82-85.5', 16940.78, 847.04, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00114', '86-89.5', 17416.93, 870.85, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00115', '90-93.5', 17907.05, 895.35, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00116', '94-95.5', 18585.33, 929.27, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00117', '96-97.5', 19109.64, 955.48, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00118', '98-100', 19649.33, 982.47, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

-- Level VIII (College Faculty)
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00119', 'NA', 11000.00, 500.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00120', 'NA', 11100.00, 500.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00121', 'NA', 11300.00, 400.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00122', 'NA', 11500.00, 400.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00123', '36-Below', 11992.53, 599.63, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00124', '37-40.5', 12321.63, 616.08, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00125', '41-44.5', 12660.31, 633.02, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00126', '45-48.5', 13130.20, 656.51, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00127', '49-52.5', 13492.36, 674.62, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00128', '53-57.5', 13865.07, 693.25, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00129', '58-61.5', 14382.04, 719.10, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00130', '62-66.5', 14780.62, 739.03, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00131', '67-69.5', 15190.80, 759.54, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00132', '70-73.5', 15759.61, 787.98, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00133', '74-77.5', 16198.29, 809.91, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00134', '78-81.5', 16649.76, 832.49, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00135', '82-85.5', 17275.66, 863.78, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00136', '86-89.5', 17758.49, 887.92, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00137', '90-93.5', 18255.44, 912.77, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

EXECUTE ums.InsertUpdateRankSalaryRate 'RD00138', '94-95.5', 18944.18, 947.21, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00139', '96-97.5', 19475.67, 973.78, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertUpdateRankSalaryRate 'RD00140', '98-100', 20022.68, 1001.13, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
GO

-- sss_information
-- is used to get the sss information
INSERT INTO ums.sss_information(sss_id, effectivity_date, created_by) VALUES('SSS001', CONVERT(datetime, '01/01/2007', 101), '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
GO

-- sss_range
-- is used to get the sss range 
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 1000.00, 1249.99, 33.30, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 1250.00, 1749.99, 50.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 1750.00, 2249.99, 66.70, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 2250.00, 2749.99, 83.30, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 2750.00, 3249.99, 100.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 3250.00, 3749.99, 116.70, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 3750.00, 4249.99, 133.30, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 4250.00, 4749.99, 150.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 4750.00, 5249.99, 166.70, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 5250.00, 5749.99, 183.30, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 5750.00, 6249.99, 200.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 6250.00, 6749.99, 216.70, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 6750.00, 7249.99, 233.30, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 7250.00, 7749.99, 250.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 7750.00, 8249.99, 266.70, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 8250.00, 8749.99, 283.30, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 8750.00, 9249.99, 300.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 9250.00, 9749.99, 316.70, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 9750.00, 10249.99, 333.30, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 10250.00, 10749.99, 350.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 10750.00, 11249.99, 366.70, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 11250.00, 11749.99, 383.30, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 11750.00, 12249.99, 400.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 12250.00, 12749.99, 416.70, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 12750.00, 13249.99, 433.30, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 13250.00, 13749.99, 450.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 13750.00, 14249.99, 466.70, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 14250.00, 14749.99, 483.30, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.sss_range(sss_id, sal_min, sal_max, contribution, created_by) VALUES('SSS001', 14750.00, 14750.00, 500.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')


-- philhealth_information
-- is used to get the philhealth information
INSERT INTO ums.philhealth_information(philhealth_id, effectivity_date, created_by) VALUES('PHL001', CONVERT(datetime, '01/01/2007', 101), '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
GO

-- philhealth_range
-- is used to get the philhealth range 
INSERT INTO ums.philhealth_range(philhealth_id, sal_min, sal_max, contribution, created_by) VALUES('PHL001', 0.00, 4999.99, 50.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.philhealth_range(philhealth_id, sal_min, sal_max, contribution, created_by) VALUES('PHL001', 5000.00, 5999.99, 62.50, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.philhealth_range(philhealth_id, sal_min, sal_max, contribution, created_by) VALUES('PHL001', 6000.00, 6999.99, 75.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.philhealth_range(philhealth_id, sal_min, sal_max, contribution, created_by) VALUES('PHL001', 7000.00, 7999.99, 87.50, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.philhealth_range(philhealth_id, sal_min, sal_max, contribution, created_by) VALUES('PHL001', 8000.00, 8999.99, 100.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.philhealth_range(philhealth_id, sal_min, sal_max, contribution, created_by) VALUES('PHL001', 9000.00, 9999.99, 112.50, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.philhealth_range(philhealth_id, sal_min, sal_max, contribution, created_by) VALUES('PHL001', 10000.00, 10999.99, 125.50, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.philhealth_range(philhealth_id, sal_min, sal_max, contribution, created_by) VALUES('PHL001', 11000.00, 11999.99, 137.50, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.philhealth_range(philhealth_id, sal_min, sal_max, contribution, created_by) VALUES('PHL001', 12000.00, 12999.99, 150.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.philhealth_range(philhealth_id, sal_min, sal_max, contribution, created_by) VALUES('PHL001', 13000.00, 13999.99, 162.50, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.philhealth_range(philhealth_id, sal_min, sal_max, contribution, created_by) VALUES('PHL001', 14000.00, 14999.99, 175.00, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.philhealth_range(philhealth_id, sal_min, sal_max, contribution, created_by) VALUES('PHL001', 15000.00, 75000, 187.50, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')



-- ##########################################END INITIAL DATABASE INFORMATION#############################################################



-- ########################################FOR CODE DEBUGGING########################################################################

--	@sysid_employee varchar (50) = '',
--	@employee_id varchar (50) = '',
--	@e_code varchar (50) = '',
--	@pagibig_memid varchar (50)
--	@sss_memid varchar (50)
--	@philhealth_memid varchar (50)
--	@last_name varchar (50) = '',
--	@first_name varchar (50) = '',
--	@middle_name varchar (50) = '',
--	@birthdate datetime,
--	@other_information varchar (1000) = '',
--
--	@e_mail varchar (50) = '',
--	@present_address varchar (500) = '',
--	@present_phone_nos varchar (100) = '',
--	@home_address varchar (500) = '',
--	@home_phone_nos varchar (100) = '',
--	@place_birth varchar (500) = '',
--	@citizenship varchar (100) = '',
--	@nationality varchar (100) = '',
--	@religion varchar (100) = '',
--
--	@emer_name varchar (150) = '',
--	@emer_address varchar (500) = '',
--	@emer_phone_nos varchar (100) = '',
--	@emer_relationship varchar (100) = '',
--
--	@employment_id varchar (50)  = '',
--  @department_id varchar (50) = '',
--	@status_id tinyint = 0,
--	@level_id varchar (50) = '',
--	@category_id varchar (50) = '',
--	@degree_id varchar (50) = '',
--	@pagibig_contribution decimal (12, 2) = 0,
--	@first_in varchar (12) = '',
--	@first_out varchar (12) = '',
--	@second_in varchar (12) = '',
--	@second_out varchar (12) = '',e
--	@rest_day tinyint = 0,
--	@masteral_rate decimal (12, 2) = 0,
--
--	@created_by varchar (50) = ''	

--EXECUTE ums.InsertEmployeeInformation 'SYSEMP001', 'C2002-001-B', NULL, NULL, NULL, NULL, 'College', 'Part-time', 'Hiring', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET05', 'DEPT003', 1, 'RL008', 'RC00043', 'RD00119', 'RD00119', 119, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP002', 'C2002-002-B', NULL, NULL, NULL, NULL, 'College', 'Probitionary', 'Year I', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET05', 'DEPT002', 2, 'RL008', 'RC00044', 'RD00120', 'RD00120', 120, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP003', 'C2002-003-B', NULL, NULL, NULL, NULL, 'College', 'Probitionary', 'Year II', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET05', 'DEPT001', 2, 'RL008', 'RC00044', 'RD00121', 'RD00121', 121, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP004', 'C2002-004-B', NULL, NULL, NULL, NULL, 'College', 'Probitionary', 'Year III', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET05', 'DEPT001', 2, 'RL008', 'RC00044', 'RD00122', 'RD00122', 122, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP005', 'C2002-005-B', NULL, NULL, NULL, NULL, 'College', 'Regular', 'Instructor Two', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET05', 'DEPT001', 3, 'RL008', 'RC00046', 'RD00127', 'RD00127', 127, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP006', 'C2002-006-B', NULL, NULL, NULL, NULL, 'College', 'Lay-off', 'Senior Instructor Two', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET05', 'DEPT001', 4, 'RL008', 'RC00047', 'RD00130', 'RD00130', 130, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP007', 'C2002-007-N', NULL, NULL, NULL, NULL, 'Nursing', 'Part-time', 'Hiring', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET05', 'DEPT001', 1, 'RL008', 'RC00043', 'RD00119', 'RD00119', 119, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP008', 'C2002-008-N', NULL, NULL, NULL, NULL, 'Nursing', 'Probitionary', 'Year I', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET05', 'DEPT001', 2, 'RL008', 'RC00044', 'RD00120', 'RD00120', 120, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP009', 'C2002-009-N', NULL, NULL, NULL, NULL, 'Nursing', 'Probitionary', 'Year II', NULL, NULL,
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET05', 'DEPT001', 2, 'RL008', 'RC00044', 'RD00121', 'RD00121', 121, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP010', 'C2002-010-N', NULL, NULL, NULL, NULL, 'Nursing', 'Probitionary', 'Year III', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Sample', 'Sample', 'Sample', 'Sample', 
--			'ET05', 'DEPT001', 2, 'RL008', 'RC00044', 'RD00122', 'RD00122', 122, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP011', 'C2002-011-N', NULL, NULL, NULL, NULL, 'Nursing', 'Regular', 'Senior Instructor Two', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Sample', 'Sample', 'Sample', 'Sample', 
--			'ET05', 'DEPT001', 3, 'RL008', 'RC00047', 'RD00130', 'RD00130', 130, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP012', 'C2002-012-N', NULL, NULL, NULL, NULL, 'Nursing', 'Lay-off', 'Assistant Professor Two', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Sample', 'Sample', 'Sample', 'Sample', 
--			'ET05', 'DEPT001', 4, 'RL008', 'RC00048', 'RD00133', 'RD00133', 133, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP013', 'H2002-013-H', NULL, NULL, NULL, NULL, 'High School', 'Part-time', 'Hiring', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET06', 'DEPT001', 1, 'RL007', 'RC00037', 'RD00097', 'RD00097', 97, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP014', 'H2002-014-H', NULL, NULL, NULL, NULL, 'High School', 'Probitionary', 'Year I', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET06', 'DEPT001', 2, 'RL007', 'RC00038', 'RD00098', 'RD00098', 98, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP015', 'H2002-015-H', NULL, NULL, NULL, NULL, 'High School', 'Probitionary', 'Year II', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Sample', 'Sample', 'Sample', 'Sample', 
--			'ET06', 'DEPT001', 2, 'RL007', 'RC00038', 'RD00099', 'RD00099', 99, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP016', 'H2002-016-H', NULL, NULL, NULL, NULL, 'High School', 'Probitionary', 'Year III', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET06', 'DEPT001', 2, 'RL007', 'RC00038', 'RD00100', 'RD00100', 100, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP017', 'H2002-017-H', NULL, NULL, NULL, NULL, 'High School', 'Regular', 'Junior Teacher III', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET06', 'DEPT009', 3, 'RL007', 'RC00040', 'RD00108', 'RD00108', 108, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP018', 'H2002-018-H', NULL, NULL, NULL, NULL, 'High School', 'Lay-off', 'Senior Teacher V', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET06', 'DEPT001', 4, 'RL007', 'RC00041', 'RD00115', 'RD00115', 115, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP019', 'G2002-019-G', NULL, NULL, NULL, NULL, 'Grade/Kinder', 'Part-time', 'Hiring', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET07', 'DEPT001', 1, 'RL007', 'RC00037', 'RD00097', 'RD00097', 97, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP020', 'G2002-020-G', NULL, NULL, NULL, NULL, 'Grade/Kinder', 'Probitionary', 'Year I', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET07', 'DEPT001', 2, 'RL007', 'RC00038', 'RD00098', 'RD00098', 98, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP021', 'K2002-021-K', NULL, NULL, NULL, NULL, 'Grade/Kinder', 'Probitionary', 'Year II', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET07', 'DEPT001', 2, 'RL007', 'RC00038', 'RD00099', 'RD00099', 99, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP022', 'K2002-022-K', NULL, NULL, NULL, NULL, 'Grade/Kinder', 'Probitionary', 'Year III', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET07', 'DEPT001', 2, 'RL007', 'RC00038', 'RD00100', 'RD00100', 100, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP023', 'G2002-023-G', NULL, NULL, NULL, NULL, 'Grade/Kinder', 'Regular', 'Teacher II', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Sample', 'Sample', 'Sample', 'Sample', 
--			'ET07', 'DEPT001', 3, 'RL007', 'RC00039', 'RD00102', 'RD00102', 102, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP024', 'G2002-024-G', NULL, NULL, NULL, NULL, 'Grade/Kinder', 'Lay-off', 'Master Teacher II', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET07', 'DEPT001', 4, 'RL007', 'RC00042', 'RD00117', 'RD00117', 117, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP025', 'S2002-025-E', NULL, NULL, NULL, NULL, 'Staff', 'Part-time', 'Level III Hiring', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET08', 'DEPT001', 1, 'RL003', 'RC00013', 'RD00033', 'RD00033', 33, 200.00, '5:00 AM', '9:00 AM', '10:00 AM', '2:00 PM', 4, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP026', 'S2002-026-E', NULL, NULL, NULL, NULL, 'Staff', 'Probitionary', 'Level III Rank I-B', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET08', 'DEPT001', 2, 'RL003', 'RC00014', 'RD00035', 'RD00035', 35, 200.00, '1:00 PM', '5:00 PM', '6:00 PM', '10:00 PM', 2, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP027', 'S2002-027-E', NULL, NULL, NULL, NULL, 'Staff', 'Regular', 'Level III Rank III-A', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET08', 'DEPT001', 3, 'RL003', 'RC00016', 'RD00040', 'RD00040', 40, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP028', 'S2002-028-E', NULL, NULL, NULL, NULL, 'Staff', 'Lay-off', 'Level III Rank II-C', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET08', 'DEPT001', 4, 'RL003', 'RC00015', 'RD00039', 'RD00039', 39, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP029', 'S2002-029-E', NULL, NULL, NULL, NULL, 'Staff', 'Part-time', 'Level IV Hiring', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET08', 'DEPT001', 1, 'RL004', 'RC00019', 'RD00049', 'RD00049', 49, 200.00, '6:00 AM', '10:00 AM', '11:00 AM', '3:00 PM', 4, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP030', 'S2002-030-E', NULL,  NULL, NULL, NULL, 'Staff', 'Probitionary', 'Level IV Rank I-A', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET08', 'DEPT001', 2, 'RL004', 'RC00020', 'RD00050', 'RD00050', 50, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 6, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP031', 'S2002-031-E', NULL, NULL, NULL, NULL, 'Staff', 'Regular', 'Level IV Rank IV-C', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET08', 'DEPT001', 3, 'RL004', 'RC00023', 'RD00059', 'RD00059', 59, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP032', 'S2002-032-E', NULL, NULL, NULL, NULL, 'Staff', 'Lay-off', 'Level IV Rank V-C', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET08', 'DEPT001', 4, 'RL004', 'RC00024', 'RD00064', 'RD00064', 64, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP033', 'S2002-033-E', NULL, NULL, NULL, NULL, 'Staff', 'Part-time', 'Level V Hiring', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET08', 'DEPT001', 1, 'RL005', 'RC00025', 'RD00065', 'RD00065', 65, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 4, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP034', 'S2002-034-E', NULL, NULL, NULL, NULL, 'Staff', 'Probitionary', 'Level V Rank I-C', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET08', 'DEPT001', 2, 'RL005', 'RC00026', 'RD00068', 'RD00068', 68, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 6, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP035', 'S2002-035-E', NULL, NULL, NULL, NULL, 'Staff', 'Regular', 'Level V Rank IV-A', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET08', 'DEPT001', 3, 'RL005', 'RC00029', 'RD00075', 'RD00075', 75, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP036', 'S2002-036-E', NULL, NULL, NULL, NULL, 'Staff', 'Lay-off', 'Level V Rank IV-B', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET08', 'DEPT001', 4, 'RL005', 'RC00029', 'RD00076', 'RD00076', 76, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP037', 'S2002-037-E', NULL, NULL, NULL, NULL, 'Academic-Non Teaching', 'Part-time', 'Level VI Hiring', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET09', 'DEPT001', 1, 'RL006', 'RC00031', 'RD00081', 'RD00081', 81, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 4, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP038', 'S2002-038-E', NULL, NULL, NULL, NULL, 'Academic-Non Teaching', 'Probitionary', 'Level VI Rank I-B', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET09', 'DEPT001', 2, 'RL006', 'RC00032', 'RD00083', 'RD00083', 83, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 6, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP039', 'S2002-039-E', NULL, NULL, NULL, NULL, 'Academic-Non Teaching', 'Regular', 'Level VI Rank III-C', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET09', 'DEPT001', 3, 'RL006', 'RC00034', 'RD00090', 'RD00090', 90, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP040', 'S2002-040-E', NULL, NULL, NULL, NULL, 'Academic-Non Teaching', 'Lay-off', 'Level VI Rank IV-B', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET09', 'DEPT001', 4, 'RL006', 'RC00035', 'RD00092', 'RD00092', 92, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP041', 'S2002-041-E', NULL, NULL, NULL, NULL, 'Maintenance', 'Part-time', 'Level I Hiring', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET10', 'DEPT001', 1, 'RL001', 'RC00001', 'RD00001', 'RD00001', 1, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 4, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP042', 'S2002-042-E', NULL, NULL, NULL, NULL, 'Maintenance', 'Probitionary', 'Level I Rank I-A', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET10', 'DEPT001', 2, 'RL001', 'RC00002', 'RD00002', 'RD00002', 2, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 6, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP043', 'S2002-043-E', NULL, NULL, NULL, NULL, 'Maintenance', 'Regular', 'Level I Rank II-C', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET10', 'DEPT001', 3, 'RL001', 'RC00003', 'RD00007', 'RD00007', 7, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP044', 'S2002-044-E', NULL, NULL, NULL, NULL, 'Maintenance', 'Lay-off', 'Level I Rank IV-B', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET10', 'DEPT001', 4, 'RL001', 'RC00005', 'RD00012', 'RD00012', 12, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP045', 'S2002-045-E', NULL, NULL, NULL, NULL, 'Maintenance', 'Part-time', 'Level II Hiring', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET10', 'DEPT001', 1, 'RL002', 'RC00007', 'RD00017', 'RD00017', 17, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 4, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP046', 'S2002-046-E', NULL, NULL, NULL, NULL, 'Maintenance', 'Probitionary', 'Level II Rank II-C', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET10', 'DEPT001', 2, 'RL002', 'RC00009', 'RD00023', 'RD00023', 23, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 6, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP047', 'S2002-047-E', NULL, NULL, NULL, NULL, 'Maintenance', 'Regular', 'Level II Rank III-A', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET10', 'DEPT001', 3, 'RL002', 'RC00010', 'RD00024', 'RD00024', 24, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP048', 'S2002-048-E', NULL, NULL, NULL, NULL, 'Maintenance', 'Lay-off', 'Level II Rank IV-A', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET10', 'DEPT001', 4, 'RL002', 'RC00011', 'RD00027', 'RD00027', 27, 200.00, '8:00 AM', '12:00 PM', '1:00 PM', '5:00 PM', 0, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO	
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP049', 'G2002-049-B', NULL, NULL, NULL, NULL, 'Graduate School', 'Part-time', 'Hiring', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET01', 'DEPT001', 1, 'RL008', 'RC00043', 'RD00119', 'RD00119', 119, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, 250.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO
--EXECUTE ums.InsertEmployeeInformation 'SYSEMP050', 'G2002-050-B', NULL, NULL, NULL, NULL, 'Graduate School College', 'Senior Instructor', 'Two (2)', NULL, NULL, 
--			NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'To be Change', 'To be Change', '1111-1111-1111', 'To be Change', 
--			'ET01', 'DEPT001', 1, 'RL008', 'RC00047', 'RD00130', 'RD00130', 130, 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 0, 150.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO
--
--
--
----CREATE PROCEDURE ums.InsertEmployeeDeduction
----
----	@deduction_date datetime,
----	@sysid_deduction varchar (50) = '',
----	@sysid_employee varchar (50) = '',
----	@amount decimal (12, 2) = 0,
----
----	@network_information varchar (MAX) = '',
----	@created_by varchar (50) = ''	
----		
----AS
--
----CREATE PROCEDURE ums.InsertDeductionInformation
----
----	@sysid_deduction varchar (50) = '',
----	@deduction_description varchar (50) = '',
----
----	@network_information varchar (MAX) = '',
----	@created_by varchar (50) = ''	
----		
----AS
--EXECUTE ums.InsertDeductionInformation 'SYSDEC001', 'Canteen Charges', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO
--
--
--DECLARE @date datetime
--SET @date = GETDATE()
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertEmployeeDeduction @date, 'SYSDEC001', 'SYSEMP001', 123.50, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO
--
----CREATE PROCEDURE ums.InsertLoanTypeInformation
----
----	@sysid_loan varchar (50) = '',
----	@loan_description varchar (50) = '',
----
----	@network_information varchar (MAX) = '',
----	@created_by varchar (50) = ''	
----
--
--EXECUTE ums.InsertLoanTypeInformation 'SYSLON001', 'Patawa Loan', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO
--EXECUTE ums.InsertLoanTypeInformation 'SYSLON002', 'Cash Loan', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO
--
--
----CREATE PROCEDURE ums.InsertLoanRemittance
----
----	@sysid_remittance varchar (50) = '',
----	@sysid_employee varchar (50) = '',
----	@sysid_loan varchar (50) = '',
----	@reference_no varchar (100) = '',
----	@release_date datetime,
----	@maturity_date datetime,
----	@principal_interest decimal (12, 2) = 0,
----	@monthly_pay decimal (12, 2) = 0,
----
----	@network_information varchar (MAX) = '',
----	@created_by varchar (50) = ''	CONVERT(datetime, '01/01/2007', 101)
--
--DECLARE @release_date datetime
--DECLARE @maturity_date datetime
--SET @release_date = CONVERT(datetime, '01/15/2007', 101)
--SET @maturity_date = CONVERT(datetime, '05/15/2007', 101)
--EXECUTE ums.InsertLoanRemittance 'SYSLNR000001', 'SYSEMP001', 'SYSLON001', 'PTW-0001', @release_date, @maturity_date, 
--								10500.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO
--
----CREATE PROCEDURE ums.UpdateLoanRemittance
----
----	@sysid_remittance varchar (50) = '',
----	@sysid_loan varchar (50) = '',
----	@reference_no varchar (100) = '',
----	@release_date datetime,
----	@maturity_date datetime,
----	@principal_interest decimal (12, 2) = 0,
----
----	@network_information varchar (MAX) = '',
----	@edited_by varchar (50) = ''	
----		
----AS
--
--DECLARE @release_date datetime
--DECLARE @maturity_date datetime
--SET @release_date = CONVERT(datetime, '06/30/2007', 101)
--SET @maturity_date = CONVERT(datetime, '11/30/2007', 101)
--EXECUTE ums.UpdateLoanRemittance 'SYSLNR000001', 'SYSLON002', 'PTW-0002', @release_date, @maturity_date, 
--								10000.00, 0.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO
--
----CREATE PROCEDURE ums.InsertEmployeeRemittance
----
----	@sysid_remittance varchar (50) = '',
----	@remittance_date datetime,
----	@pay_month smallint,
----	@pay_balance smallint,
----	@amount_paid decimal,
----	@amount_balance decimal,
----
----	@network_information varchar (MAX) = '',
----	@created_by varchar (50) = ''	
--
--DECLARE @remittance_date datetime
--SET @remittance_date = CONVERT(datetime, '07/30/2007', 101)
--EXECUTE ums.InsertEmployeeRemittance 'SYSLNR000001', @remittance_date, 1, 4, 5000, 5000, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO
--
----CREATE PROCEDURE ums.UpdateEmployeeRemittance
----
----	@remittance_id bigint = 0,
----	@remittance_date datetime,
----	@pay_month smallint,
----	@pay_balance smallint,
----	@amount_paid decimal,
----	@amount_balance decimal,
----
----	@network_information varchar (MAX) = '',
----	@edited_by varchar (50) = ''	
--
--DECLARE @remittance_date datetime
--SET @remittance_date = CONVERT(datetime, '07/15/2007', 101)
--EXECUTE ums.UpdateEmployeeRemittance 1, @remittance_date, 1, 5, 1000, 9000, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO
--
----CREATE PROCEDURE ums.DeleteLoanRemittance
----
----	@sysid_remittance varchar (50) = '',
----
----	@network_information varchar (MAX) = '',
----	@deleted_by varchar (50) = ''	
----		
----AS
--
----EXECUTE ums.DeleteLoanRemittance 'SYSLNR000001', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--
--
----EXECUTE ums.UpdateEmployeeInformation 'SYSEMP001', 'M2333', NULL, '034FSDF', NULL, NULL, NULL, 'Eparwa', 'Krysia', 'Palad', NULL, NULL, 
----		'ET06', 3, 'RL008', 'RC00039', 'RD00104', 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
----GO
----EXECUTE ums.UpdateEmployeeInformation 'SYSEMP001', 'M2333', NULL, '034FSDF', NULL, NULL, NULL, 'Eparwa', 'Krysia', 'Palad', NULL, NULL, 
----		'ET06', 3, 'RL008', 'RC00039', 'RD00104', 200.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
----GO
----EXECUTE ums.UpdateEmployeeInformation 'SYSEMP001', 'Masdfdf', NULL, '034FSDF', NULL, NULL, NULL, 'Eparwa', 'Krysia', 'Palad', NULL, NULL, 
----		'ET07', 4, 'RL008', 'RC00039', 'RD00104', 300.00, '8:00 AM', '12:00 PM', '1:00 AM', '5:00 PM', 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
----GO
--
----CREATE PROCEDURE ums.InsertDeductionInformation
----
----	@sysid_deduction varchar (50) = '',
----	@deduction_description varchar (50) = '',
----
----	@network_information varchar (MAX) = '',
----	@created_by varchar (50) = ''	
--
----EXECUTE ums.InsertDeductionInformation 'SYSDEC001', 'Union Due', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
----
----EXECUTE ums.UpdateDeductionInformation 'SYSDEC001', 'Union Dues', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--
---- ########################################END FOR CODE DEBUGGING####################################################################
