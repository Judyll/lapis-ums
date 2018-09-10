--SOURCES:
--			http://social.msdn.microsoft.com/forums/en-US/sqldatabaseengine/thread/c03c143c-c2f9-455c-baed-15c4e77309fd/
--			http://social.msdn.microsoft.com/Forums/en-US/sqlgetstarted/thread/7925902b-9d6f-445a-8432-e58e7580d65d
--			http://social.msdn.microsoft.com/Forums/en-US/sqldatabaseengine/thread/b1c57e15-5e82-4747-a7cd-3ff3f6bb29a0

	--check the database
	DBCC CHECKDB

	--to restore a database into a recovery state from standby/recovering
	RESTORE DATABASE db_umsdev_03_30_2007 WITH RECOVERY   -- <db_umsdev_03_30_2007> is the database name
	
	--drop and add server
	USE MASTER
	GO
	sp_dropserver '<old computer name>'
	GO
	sp_addserver '<new computer name>', local
	GO
	 
	sp_helpserver
	
	--check the sessions
	SELECT * FROM sys.dm_exec_sessions

	EXECUTE sp_who2 'active'

	--determine duplicates
	SELECT 
		last_name, 
		first_name, 
		COUNT(*) total_count
	FROM
		ums.person_information
	GROUP BY
		last_name, first_name
	HAVING 
		COUNT(*) > 1
	ORDER BY
		COUNT(*) DESC


	--display all the foreign keys in the database
	SELECT 
		f.name AS ForeignKey,
		OBJECT_NAME(f.parent_object_id) AS TableName,
		COL_NAME(fc.parent_object_id, fc.parent_column_id) AS ColumnName,
		OBJECT_NAME (f.referenced_object_id) AS ReferenceTableName,
		COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS ReferenceColumnName
	FROM 
		sys.foreign_keys AS f
	INNER JOIN sys.foreign_key_columns AS fc ON f.OBJECT_ID = fc.constraint_object_id
	ORDER BY
		TableName ASC, ReferenceTableName ASC


	--drop a default constraint	
	DECLARE @default_name varchar (256)

	SELECT 
		@default_name = [name] 
	FROM 
		sys.default_constraints
	WHERE
		parent_object_id = OBJECT_ID('ums.table_name', 'U') AND
		COL_NAME(parent_object_id, parent_column_id) = 'column_name'

	IF (OBJECT_ID('ums.table_name', 'U') IS NOT NULL) AND 
		(EXISTS (SELECT * FROM information_schema.columns WHERE column_name = 'column_name' AND table_name = 'table_name'))
	BEGIN
		EXECUTE ('ALTER TABLE ums.table_name DROP CONSTRAINT ' + @default_name)	
	END
	GO


	--rename the column name manual_rate to masteral_rate of the table ums.salary_information
	IF (OBJECT_ID('ums.salary_information', 'U') IS NOT NULL) AND 
		(EXISTS (SELECT * FROM information_schema.columns WHERE column_name = 'manual_rate' AND table_name = 'salary_information'))
	BEGIN
		EXECUTE sp_RENAME @objname = 'ums.salary_information.manual_rate', @newname = 'masteral_rate', @objtype = 'COLUMN'
	END
	GO


	--RECOMPILE A STORED PROCEDURE
	sp_recompile SelectByDateStartEndCashReceiptsDetailedStudentPaymentMiscellaneousIncome


	--DROP A CONSTRAINT BUT DETERMINING FIRST IF THAT CONSTRAINT EXISTS

	--verifies if the Subject_Information_Category_ID_FK constraint exists
	IF (OBJECT_ID('ums.subject_information', 'U') IS NOT NULL) AND 
			(EXISTS (SELECT * FROM information_schema.table_constraints WHERE constraint_catalog = (SELECT db_name())
							AND table_name = 'subject_information' AND constraint_name = 'Subject_Information_Category_ID_FK')) AND
				(EXISTS (SELECT * FROM information_schema.columns WHERE column_name = 'category_id' AND table_name = 'subject_information'))
	BEGIN
		ALTER TABLE ums.subject_information
		DROP CONSTRAINT Subject_Information_Category_ID_FK
	END
	GO
	-----------------------------------------------------


	--verifies if the Cancelled_Receipt_No_Receipt_Date_CK constraint exists
	IF (OBJECT_ID('ums.cancelled_receipt_no', 'U') IS NOT NULL) AND 
		(NOT EXISTS (SELECT * FROM information_schema.columns WHERE column_name = 'receipt_date' AND table_name = 'cancelled_receipt_no'))
	BEGIN
		ALTER TABLE ums.cancelled_receipt_no
		ADD receipt_date datetime NOT NULL DEFAULT (GETDATE())
	END
	GO

	IF OBJECT_ID('ums.cancelled_receipt_no', 'U') IS NOT NULL AND
		(NOT EXISTS (SELECT * FROM information_schema.table_constraints WHERE constraint_catalog = (SELECT db_name())
					AND table_name = 'cancelled_receipt_no' AND constraint_name = 'Cancelled_Receipt_No_Receipt_Date_CK')) AND
		(EXISTS (SELECT * FROM information_schema.columns WHERE column_name = 'receipt_date' AND table_name = 'cancelled_receipt_no'))
	BEGIN
		ALTER TABLE ums.cancelled_receipt_no WITH NOCHECK
		ADD CONSTRAINT Cancelled_Receipt_No_Receipt_Date_CK CHECK (CONVERT(varchar, receipt_date, 109) LIKE '%12:00:00:000AM')
	END
	GO
	------------------------------------------------------------------
	
	--verifies if the Student_Payments_SysID_Account_Credit_FK constraint exists
	IF (OBJECT_ID('ums.student_payments', 'U') IS NOT NULL) AND 
		(NOT EXISTS (SELECT * FROM information_schema.columns WHERE column_name = 'sysid_account_credit' AND table_name = 'student_payments'))
	BEGIN
		ALTER TABLE ums.student_payments
		ADD sysid_account_credit varchar (50) NOT NULL DEFAULT ('')
	END
	GO

	IF (OBJECT_ID('ums.student_payments', 'U') IS NOT NULL) AND 
		(NOT EXISTS (SELECT * FROM information_schema.table_constraints WHERE constraint_catalog = (SELECT db_name())
						AND table_name = 'student_payments' AND constraint_name = 'Student_Payments_SysID_Account_Credit_FK')) AND
			(EXISTS (SELECT * FROM information_schema.columns WHERE column_name = 'sysid_account_credit' AND table_name = 'student_payments'))
	BEGIN
		ALTER TABLE ums.student_payments WITH NOCHECK
		ADD CONSTRAINT Student_Payments_SysID_Account_Credit_FK FOREIGN KEY (sysid_account_credit) REFERENCES ums.chart_of_accounts(sysid_account) ON UPDATE NO ACTION
	END
	GO
	------------------------------------------------------------------

	
	--rename table school_fee_level_temporary to school_fee_level
	EXECUTE sp_rename 'ums.school_fee_level_temporary', 'school_fee_level'


	--determine if the index already exists
	IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'Student_Payments_Created_By_Index')
	-- create an index of the student_payments table 
	CREATE INDEX Student_Payments_Created_By_Index
		ON ums.student_payments (created_by DESC)
	GO
	------------------------------------------------------------------
	
	--alter the column degree_id_level_points and change it from NOT NULL to NULL
	IF (OBJECT_ID('ums.salary_information', 'U') IS NOT NULL) AND 
		(EXISTS (SELECT * FROM information_schema.columns WHERE column_name = 'degree_id_level_points' AND table_name = 'salary_information'))
	BEGIN
		ALTER TABLE ums.salary_information
		ALTER COLUMN degree_id_level_points varchar (50) NULL
	END
	GO


	--HOW TO GET THE NTH RECORD
	CREATE PROC nth 
	(
		@table_name sysname,
		@column_name sysname,
		@nth int
	)
	AS
	BEGIN

	--Written by: Narayana Vyas Kondreddi
	--Date written: December 23rd 2000
	--Purpose: To find out the nth highest number in a column. Eg: Second highest salary from the salaries table
	--Input parameters: Table name, Column name, and the nth position
	--Tested on: SQL Server Version 7.0
	--Email: answer_me@hotmail.com

	SET @table_name = RTRIM(@table_name)
	SET @column_name = RTRIM(@column_name)

	DECLARE @exec_str CHAR(400)
	IF (SELECT OBJECT_ID(@table_name,'U')) IS NULL
	BEGIN
		RAISERROR('Invalid table name',18,1)
		RETURN -1
	END

	IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @table_name AND COLUMN_NAME = @column_name)
	BEGIN
		RAISERROR('Invalid column name',18,1)
		RETURN -1
	END

	IF @nth <= 0
	BEGIN
		RAISERROR('nth highest number should be greater than Zero',18,1)
		RETURN -1
	END

	SET @exec_str = 'SELECT MAX(' + @column_name + ') from ' + @table_name + ' WHERE ' + @column_name + ' NOT IN ( SELECT TOP ' + LTRIM(STR(@nth - 1)) + ' ' + @column_name + ' FROM ' + @table_name + ' ORDER BY ' + @column_name + ' DESC )'
	EXEC (@exec_str)

	END

	------------------------------------------------------------------------------------------------



	--UPDATE AND DELETE WITH JOIN
	UPDATE ums.subject_schedule SET
		edited_by = @edited_by
	FROM
		ums.subject_schedule AS ss
	INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = ss.sysid_scheddetails
	WHERE
		(scd.sysid_schedule = @sysid_schedule)

	DELETE ss FROM ums.subject_schedule AS ss
	INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = ss.sysid_scheddetails
	WHERE
		(scd.sysid_schedule = @sysid_schedule)
	---------------------------------------------------------------------------------------------------


	--AGGREGATE FUNCTION INSIDE A SELECT STATEMENT
	SELECT 
		rli.sysid_regular, 
		(SELECT MAX(payment_amount) FROM lms.regular_loan_payments  AS rlp WHERE rlp.sysid_regular = rli.sysid_regular) 
	FROM 
		lms.regular_loan_information AS rli
	-----------------------------------------------------------------------------------------------------
	
	
	
	--#########################TRANSCRIPT DETAILS#################################################
	-- verifies that the trigger "Transcript_Details_Trigger_Instead_Update" already exist
	IF OBJECT_ID ('ums.Transcript_Details_Trigger_Instead_Update','TR') IS NOT NULL
	   DISABLE TRIGGER ums.Transcript_Details_Trigger_Instead_Update ON ums.transcript_details
	GO

	--update existing records to have a category_id where sysid_schedule not equal to NULL
	UPDATE ums.transcript_details SET
		category_id = sc.category_id
	FROM
		ums.transcript_details AS trd
	LEFT JOIN ums.schedule_information AS sci ON sci.sysid_schedule = trd.sysid_schedule
	INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
	INNER JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
	WHERE
		(NOT trd.sysid_schedule IS NULL AND NOT trd.sysid_schedule = '')
	--------------------------------------------

	--update existing records to have a category_id where sysid_special not equal to NULL
	UPDATE ums.transcript_details SET
		category_id = sc.category_id
	FROM
		ums.transcript_details AS trd
	LEFT JOIN ums.special_class_information AS spi ON spi.sysid_special = trd.sysid_special
	INNER JOIN ums.subject_information AS si ON si.sysid_subject = spi.sysid_subject
	INNER JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
	WHERE
		(NOT trd.sysid_special IS NULL AND NOT trd.sysid_special = '')
	--------------------------------------------

	IF OBJECT_ID ('ums.Transcript_Details_Trigger_Instead_Update','TR') IS NOT NULL
		ENABLE TRIGGER ums.Transcript_Details_Trigger_Instead_Update ON ums.transcript_details
	GO
	--#########################TRANSCRIPT DETAILS#################################################
	
	
	--#########################STUDENT ENROLMENT LEVEL#################################################
	-- verifies that the trigger "Student_Enrolment_Level_Trigger_Instead_Update" already exist
	IF OBJECT_ID ('ums.Student_Enrolment_Level_Trigger_Instead_Update','TR') IS NOT NULL
	   DISABLE TRIGGER ums.Student_Enrolment_Level_Trigger_Instead_Update ON ums.student_enrolment_level
	GO

	--updated the student enrolment level of  09105010294
	--SYSELV000000884	3rd Year	College (CAMS)	Bachelor of Science in Nursing	1	0	0	S.Y. 2011 - 2012	First Semester	SYSFLV000015
	--SYSELV000002629	3rd Year	College (CAMS)	Bachelor of Science in Nursing	0	0	0	S.Y. 2011 - 2012	Second Semester	SYSFLV000015
	--updated the student enrolment level of  091-0501-0361
	--SYSELV000001368	3rd Year	College (CAMS)	Bachelor of Science in Nursing	1	0	0	S.Y. 2011 - 2012	First Semester	SYSFLV000015
	--SYSELV000002479	3rd Year	College (CAMS)	Bachelor of Science in Nursing	0	0	0	S.Y. 2011 - 2012	Second Semester	SYSFLV000015
	UPDATE ums.student_enrolment_level SET
		sysid_feelevel = 'SYSFLV000014'
	WHERE
		sysid_enrolmentlevel IN ('SYSELV000000884', 'SYSELV000002629', 'SYSELV000001368', 'SYSELV000002479')
	GO

	IF OBJECT_ID ('ums.Student_Enrolment_Level_Trigger_Instead_Update','TR') IS NOT NULL
		ENABLE TRIGGER ums.Student_Enrolment_Level_Trigger_Instead_Update ON ums.student_enrolment_level
	GO

	--#########################END STUDENT ENROLMENT LEVEL#################################################
	
	