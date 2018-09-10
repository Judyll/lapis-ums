
 --******************************************************--
-- This SQL Statements is used for the St. Paul			--
-- 		University UMS									--
--Programmed by: Judyll Mark T. Agan					--
--Date created: April 01, 2007							--
--OFFICE SOLUTIONS OBJECTS [ 6 ]						-- 
--******************************************************--

USE db_umsdev_03_30_2007
GO

-- ###########################################TABLE CONSTRAINTS OBJECTS##############################################################

--verifies if the Schedule_Information_SysID_Subject_FK constraint exists
IF OBJECT_ID('ums.schedule_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information
	DROP CONSTRAINT Schedule_Information_SysID_Subject_FK
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_Year_ID_FK constraint exists
IF OBJECT_ID('ums.schedule_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information
	DROP CONSTRAINT Schedule_Information_Year_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_SysID_Semester_FK constraint exists
IF OBJECT_ID('ums.schedule_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information
	DROP CONSTRAINT Schedule_Information_SysID_Semester_FK
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

--verifies if the Schedule_Information_Details_SysID_Schedule_FK constraint exists
IF OBJECT_ID('ums.schedule_information_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information_details
	DROP CONSTRAINT Schedule_Information_Details_SysID_Schedule_FK
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_Details_SysID_Classroom_FK constraint exists
IF OBJECT_ID('ums.schedule_information_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information_details
	DROP CONSTRAINT Schedule_Information_Details_SysID_Classroom_FK
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

--verifies if the Subject_Schedule_SysID_SchedDetails_FK constraint exists
IF OBJECT_ID('ums.subject_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_schedule
	DROP CONSTRAINT Subject_Schedule_SysID_SchedDetails_FK
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

--verifies if the Subject_Schedule_Time_ID_FK constraint exists
IF OBJECT_ID('ums.subject_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_schedule
	DROP CONSTRAINT Subject_Schedule_Time_ID_FK
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

--verifies if the Auxiliary_Service_Information_Course_Group_ID_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_information
	DROP CONSTRAINT Auxiliary_Service_Information_Course_Group_ID_FK
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

--verifies if the Auxiliary_Service_Schedule_SysID_AuxService_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_schedule
	DROP CONSTRAINT Auxiliary_Service_Schedule_SysID_AuxService_FK
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Schedule_Year_ID_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_schedule
	DROP CONSTRAINT Auxiliary_Service_Schedule_Year_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Schedule_SysID_Semester_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_schedule
	DROP CONSTRAINT Auxiliary_Service_Schedule_SysID_Semester_FK
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

--verifies if the Auxiliary_Service_Details_SysID_AuxServiceSchedule_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_details
	DROP CONSTRAINT Auxiliary_Service_Details_SysID_AuxServiceSchedule_FK
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

--verifies if the Teacher_Load_SysID_SchedDetails_FK constraint exists
IF OBJECT_ID('ums.teacher_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.teacher_load
	DROP CONSTRAINT Teacher_Load_SysID_SchedDetails_FK
END
GO
-----------------------------------------------------

--verifies if the Teacher_Load_SysID_AuxDetails_FK constraint exists
IF OBJECT_ID('ums.teacher_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.teacher_load
	DROP CONSTRAINT Teacher_Load_SysID_AuxDetails_FK
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

--verifies if the Student_Load_SysID_EnrolmentLevel_FK constraint exists
IF OBJECT_ID('ums.student_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_load
	DROP CONSTRAINT Student_Load_SysID_EnrolmentLevel_FK
END
GO
-----------------------------------------------------	

--verifies if the Student_Load_SysID_Schedule_FK constraint exists
IF OBJECT_ID('ums.student_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_load
	DROP CONSTRAINT Student_Load_SysID_Schedule_FK
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

--verifies if the Enrolment_Course_Major_SysID_EnrolmentLevel_FK constraint exists
IF OBJECT_ID('ums.enrolment_course_major', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.enrolment_course_major
	DROP CONSTRAINT Enrolment_Course_Major_SysID_EnrolmentLevel_FK
END
GO
-----------------------------------------------------	

--verifies if the Enrolment_Course_Major_Major_Information_ID_FK constraint exists
IF OBJECT_ID('ums.enrolment_course_major', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.enrolment_course_major
	DROP CONSTRAINT Enrolment_Course_Major_Major_Information_ID_FK
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

--verifies if the Transcript_Details_SysID_Transcript_FK constraint exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_details
	DROP CONSTRAINT Transcript_Details_SysID_Transcript_FK
END
GO
-----------------------------------------------------

--verifies if the Transcript_Details_SysID_Schedule_FK constraint exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_details
	DROP CONSTRAINT Transcript_Details_SysID_Schedule_FK
END
GO
-----------------------------------------------------

--verifies if the Transcript_Details_SysID_Special_FK constraint exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_details
	DROP CONSTRAINT Transcript_Details_SysID_Special_FK
END
GO
-----------------------------------------------------

--verifies if the Transcript_Details_Category_ID_FK constraint exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_details
	DROP CONSTRAINT Transcript_Details_Category_ID_FK
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


-- ###########################################END TABLE CONSTRAINTS OBJECTS##############################################################



-- ########################################DROP DEPENDENT TABLE CONSTRAINTS ##############################################################
-- ########################################END DROP DEPENDENT TABLE CONSTRAINTS ##############################################################



-- #########################################################GENERAL PROCEDURES AND FUNCTIONS##################################################
-- ######################################################END GENERAL PROCEDURES AND FUNCTIONS###################################################


-- ################################################TABLE "week_time" OBJECTS######################################################
-- verifies if the week_time table exists
IF OBJECT_ID('ums.week_time', 'U') IS NOT NULL
	DROP TABLE ums.week_time
GO

CREATE TABLE ums.week_time 			
(
	time_id tinyint NOT NULL IDENTITY (0, 1) NOT FOR REPLICATION
		CONSTRAINT Week_Time_Time_ID_PK PRIMARY KEY (time_id),		
	time_description varchar (100) NOT NULL
		CONSTRAINT Week_Time_Time_Description_CK CHECK (time_description LIKE '[0-2][0-3]:[0-5][0-9]' OR 
														time_description LIKE '[0-1][0-9]:[0-5][0-9]'),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Week_Time_Unique_ID_UQ UNIQUE (unique_id)

) ON [PRIMARY]
GO
--------------------------------------------------------

-- verifies that the trigger "Week_Time_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Week_Time_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Week_Time_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Week_Time_Trigger_Instead_Update
	ON  ums.week_time
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a week time', 'Week Time'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Week_Time_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Week_Time_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Week_Time_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Week_Time_Trigger_Instead_Delete
	ON  ums.week_time
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a week time', 'Week Time'
	
GO
-------------------------------------------------------------------------


-- verifies if the procedure "SelectWeekTime" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectWeekTime')
   DROP PROCEDURE ums.SelectWeekTime
GO

CREATE PROCEDURE ums.SelectWeekTime
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT 
			wt.time_id AS time_id,
			wt.time_description AS time_description
		FROM
			ums.week_time AS wt
		ORDER BY wt.time_id ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query week time', 'Week Time'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectWeekTime TO db_umsusers
GO
-------------------------------------------------------------

-- ################################################END TABLE "week_time" OBJECTS######################################################




-- ################################################TABLE "schedule_information" OBJECTS######################################################
-- verifies if the schedule_information table exists
IF OBJECT_ID('ums.schedule_information', 'U') IS NOT NULL
	DROP TABLE ums.schedule_information
GO

CREATE TABLE ums.schedule_information 			
(
	sysid_schedule varchar (50) NOT NULL
		CONSTRAINT Schedule_Information_SysID_Schedule_PK PRIMARY KEY (sysid_schedule)
		CONSTRAINT Schedule_Information_SysID_Schedule_CK CHECK (sysid_schedule LIKE 'SYSSCH%'),
	sysid_subject varchar (50) NOT NULL 
		CONSTRAINT Schedule_Information_SysID_Subject_FK FOREIGN KEY REFERENCES ums.subject_information(sysid_subject) ON UPDATE NO ACTION,
	year_id varchar (50) NULL
		CONSTRAINT Schedule_Information_Year_ID_FK FOREIGN KEY REFERENCES ums.school_year(year_id) ON UPDATE NO ACTION,
	sysid_semester varchar (50) NULL 
		CONSTRAINT Schedule_Information_SysID_Semester_FK FOREIGN KEY REFERENCES ums.semester_information(sysid_semester) ON UPDATE NO ACTION,

	is_marked_deleted bit NOT NULL DEFAULT (0),

	is_irregular_modular bit NOT NULL DEFAULT (0),

	is_team_teaching bit NOT NULL DEFAULT (0),

	is_fixed_amount bit NOT NULL DEFAULT (0),
	amount decimal (12, 2) NULL,

	additional_slots smallint NOT NULL DEFAULT (0),

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Schedule_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Schedule_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Schedule_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the schedule_information table 
CREATE INDEX Schedule_Information_SysID_Schedule_Index
	ON ums.schedule_information (sysid_schedule DESC)
GO
------------------------------------------------------------------


/*verifies that the trigger "Schedule_Information_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Schedule_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Schedule_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Schedule_Information_Trigger_Instead_Update
	ON  ums.schedule_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_schedule varchar (50)
	DECLARE @sysid_subject varchar (50)
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @is_team_teaching bit	
	DECLARE @is_irregular_modular bit	
	DECLARE @is_fixed_amount bit
	DECLARE @amount decimal (12, 2)
	DECLARE @additional_slots smallint
	DECLARE @is_semestral bit
	DECLARE @edited_by varchar (50)

	DECLARE @is_team_teaching_b bit	
	DECLARE @is_irregular_modular_b bit
	DECLARE @is_fixed_amount_b bit
	DECLARE @amount_b decimal (12, 2)	
	DECLARE @additional_slots_b smallint

	DECLARE @year_semester_description varchar (100)
	DECLARE @team_teaching varchar (100)
	DECLARE @team_teaching_b varchar (100)	
	DECLARE @irregular_modular varchar (100)
	DECLARE @irregular_modular_b varchar (100)
	DECLARE @fixed_amount varchar (50)
	DECLARE @fixed_amount_b varchar (50)

	DECLARE @has_update bit
	DECLARE @sysid_scheddetails varchar (50)
	
	SELECT 
		@sysid_schedule = i.sysid_schedule,
		@sysid_subject = i.sysid_subject,
		@year_id = i.year_id,
		@sysid_semester = i.sysid_semester,
		@is_team_teaching = i.is_team_teaching,	
		@is_irregular_modular = i.is_irregular_modular,	
		@is_fixed_amount = i.is_fixed_amount,
		@amount = i.amount,
		@additional_slots = i.additional_slots,
		@is_semestral = cg.is_semestral,
		@edited_by = i.edited_by
	FROM INSERTED AS i
	INNER JOIN ums.subject_information AS si ON si.sysid_subject = i.sysid_subject
	INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id

	SELECT
		@is_team_teaching_b = is_team_teaching,		
		@is_irregular_modular_b = is_irregular_modular,
		@is_fixed_amount_b = is_fixed_amount,
		@amount_b = amount,
		@additional_slots_b = additional_slots
	FROM
		ums.schedule_information
	WHERE
		sysid_schedule = @sysid_schedule

	SET @transaction_done = ''
	SET @has_update = 0	

	IF (NOT @is_team_teaching = @is_team_teaching_b)
	BEGIN

		IF (@is_team_teaching = 1)
		BEGIN
			SET @team_teaching = 'YES'
		END
		ELSE
		BEGIN
			SET @team_teaching = 'NO'
		END

		IF (@is_team_teaching_b = 1)
		BEGIN
			SET @team_teaching_b = 'YES'
		END
		ELSE
		BEGIN
			SET @team_teaching_b = 'NO'
		END

		SET @transaction_done = @transaction_done + '[Is Team Teaching Before: ' + ISNULL(@team_teaching_b, '') + ']' +
													'[Is Team Teaching After: ' + ISNULL(@team_teaching, '') + ']'
		SET @has_update = 1
	END

	IF (NOT @is_irregular_modular = @is_irregular_modular_b)
	BEGIN

		IF (@is_irregular_modular = 1)
		BEGIN

			SET @irregular_modular = 'YES'

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

		END
		ELSE
		BEGIN

			SET @irregular_modular = 'NO'

			UPDATE ums.schedule_information_details SET manual_schedule = NULL, edited_by = @edited_by WHERE sysid_schedule = @sysid_schedule

		END

		IF (@is_irregular_modular_b = 1)
		BEGIN
			SET @irregular_modular_b = 'YES'
		END
		ELSE
		BEGIN
			SET @irregular_modular_b = 'NO'
		END

		SET @transaction_done = @transaction_done + '[Is Irregular / Modular Before: ' + ISNULL(@irregular_modular_b, '') + ']' +
													'[Is Irregular / Modular After: ' + ISNULL(@irregular_modular, '') + ']'
		SET @has_update = 1
	END

	IF (NOT @is_fixed_amount = @is_fixed_amount_b) OR
		(NOT ISNULL(CONVERT(varchar, CONVERT(money, @amount), 1), '0.00') = ISNULL(CONVERT(varchar, CONVERT(money, @amount_b), 1), '0.00'))
	BEGIN

		IF @is_fixed_amount = 1
		BEGIN
			SET @fixed_amount = 'YES with an amount ' + ISNULL(CONVERT(varchar, CONVERT(money, @amount), 1), '0.00')
		END
		ELSE
		BEGIN
			SET @fixed_amount = 'NO'
		END

		IF @is_fixed_amount_b = 1
		BEGIN
			SET @fixed_amount_b = 'YES with an amount ' + ISNULL(CONVERT(varchar, CONVERT(money, @amount_b), 1), '0.00')
		END
		ELSE
		BEGIN
			SET @fixed_amount_b = 'NO'
		END

		SET @transaction_done = @transaction_done + '[Is Fixed Amount Before: ' + ISNULL(@fixed_amount_b, '') + ']' +
													'[Is Fixed Amount After: ' + ISNULL(@fixed_amount, '') + ']'
		SET @has_update = 1

	END

	IF (NOT @additional_slots = @additional_slots_b)
	BEGIN

		SET @transaction_done = @transaction_done + '[Additional Slots Before: ' + ISNULL(CONVERT(varchar, @additional_slots_b), '0') + ']' +
													'[Additional Slots After: ' + ISNULL(CONVERT(varchar, @additional_slots), '0') + ']'
		SET @has_update = 1
	END

	IF @has_update = 1
	BEGIN

		UPDATE ums.schedule_information SET			
			is_team_teaching = @is_team_teaching,
			is_irregular_modular = @is_irregular_modular,
			is_fixed_amount = @is_fixed_amount,
			amount = @amount,
			additional_slots = @additional_slots,

			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			sysid_schedule = @sysid_schedule

		SET @year_semester_description = ''

		IF (@is_semestral = 0) AND (NOT @year_id IS NULL)
		BEGIN
			SELECT @year_semester_description = year_description FROM ums.school_year WHERE year_id = @year_id
		END
		ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL)
		BEGIN
			SELECT @year_semester_description = sy.year_description + ' - ' + ss.semester_description
			FROM 
				ums.semester_information AS si
			INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
			INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
			WHERE 
				si.sysid_semester = @sysid_semester
		END

		SET @transaction_done = 'UPDATED a schedule information ' + 
								'[Schedule ID: ' + ISNULL(@sysid_schedule, '') +
								'][Subject Title: ' + (SELECT ISNULL(subject_code, '') + ' - ' + ISNULL(descriptive_title, '') FROM ums.subject_information WHERE sysid_subject = @sysid_subject) + 												  
								'][School Year / Semester: ' + ISNULL(@year_semester_description, '') + ']' +
								@transaction_done
								

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
		END
				
		EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done	

	END
	ELSE IF NOT @edited_by IS NULL
	BEGIN

		--used for the delete trigger
		UPDATE ums.schedule_information SET
			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			sysid_schedule = @sysid_schedule

	END	

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Schedule_Information_Trigger_Instead_Delete" already exist*/
IF OBJECT_ID ('ums.Schedule_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Schedule_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Schedule_Information_Trigger_Instead_Delete
	ON  ums.schedule_information
	INSTEAD OF DELETE 
	NOT FOR REPLICATION
AS 

	DECLARE @sysid_schedule varchar (50)
	DECLARE @deleted_by varchar (50)

	SELECT 
		@sysid_schedule = d.sysid_schedule,
		@deleted_by = d.edited_by
	FROM DELETED AS d

	UPDATE ums.schedule_information_details SET edited_by = @deleted_by WHERE sysid_schedule = @sysid_schedule
	DELETE FROM ums.schedule_information_details WHERE sysid_schedule = @sysid_schedule

	UPDATE ums.student_load SET edited_by = @deleted_by WHERE sysid_schedule = @sysid_schedule
	DELETE FROM ums.student_load WHERE sysid_schedule = @sysid_schedule

	UPDATE ums.schedule_information SET is_marked_deleted = 1, edited_by = @deleted_by WHERE sysid_schedule = @sysid_schedule		

GO
/*-----------------------------------------------------------------*/


-- verifies if the procedure "InsertScheduleInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertScheduleInformation')
   DROP PROCEDURE ums.InsertScheduleInformation
GO

CREATE PROCEDURE ums.InsertScheduleInformation

	@sysid_schedule varchar (50) = '',
	@sysid_subject varchar (50) = '',
	@year_id varchar (50) = '',
	@sysid_semester varchar (50) = '',
	@is_team_teaching bit = 0,
	@is_irregular_modular bit = 0,
	@is_fixed_amount bit = 0,
	@amount decimal (12, 2) = 0,
	@additional_slots smallint = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@created_by) = 1) OR
		((ums.IsOfficeUserSystemUserInfo(@created_by) = 1) AND (ums.IsUserSameDepartmentSubjectInfo(@sysid_subject, @created_by) = 1))) AND 
			((ums.IsRecordLockByYearSemesterID(@year_id) = 0) AND (ums.IsRecordLockByYearSemesterID(@sysid_semester) = 0))
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		DECLARE @is_semestral bit

		SET @is_semestral = 0

		SELECT 
			@is_semestral = cg.is_semestral 
		FROM 
			ums.subject_information AS si
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		WHERE
			si.sysid_subject = @sysid_subject

		IF (@is_semestral = 0) AND (NOT @year_id IS NULL AND NOT @year_id = '')
		BEGIN

			INSERT INTO ums.schedule_information
			(
				sysid_schedule,
				sysid_subject,
				year_id,
				sysid_semester,
				is_team_teaching,
				is_irregular_modular,
				is_fixed_amount,
				amount,
				additional_slots,
				created_by
			)
			VALUES
			(
				@sysid_schedule,
				@sysid_subject,
				@year_id,
				NULL,
				@is_team_teaching,
				@is_irregular_modular,
				@is_fixed_amount,
				@amount,
				@additional_slots,
				@created_by
			)	

		END
		ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL AND NOT @sysid_semester = '')	
		BEGIN

			INSERT INTO ums.schedule_information
			(
				sysid_schedule,
				sysid_subject,
				year_id,
				sysid_semester,
				is_team_teaching,
				is_irregular_modular,
				is_fixed_amount,
				amount,
				additional_slots,
				created_by
			)
			VALUES
			(
				@sysid_schedule,
				@sysid_subject,
				NULL,
				@sysid_semester,
				@is_team_teaching,
				@is_irregular_modular,
				@is_fixed_amount,
				@amount,
				@additional_slots,
				@created_by
			)

		END	
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new schedule information', 'Schedule Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertScheduleInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateScheduleInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateScheduleInformation')
   DROP PROCEDURE ums.UpdateScheduleInformation
GO

CREATE PROCEDURE ums.UpdateScheduleInformation

	@sysid_schedule varchar (50) = '',
	@is_team_teaching bit = 0,		
	@is_irregular_modular bit = 0,
	@is_fixed_amount bit = 0,
	@amount decimal (12, 2) = 0,
	@additional_slots smallint = 0,

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@edited_by) = 1) OR
		((ums.IsOfficeUserSystemUserInfo(@edited_by) = 1) AND (ums.IsUserSameDepartmentSubjectInfo((SELECT
																										sysid_subject
																									FROM
																										ums.schedule_information
																									WHERE
																										sysid_schedule = @sysid_schedule), @edited_by) = 1))) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.schedule_information AS sci
												WHERE 
													sci.sysid_schedule = @sysid_schedule AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.schedule_information AS sci
												WHERE 
													sci.sysid_schedule = @sysid_schedule AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.schedule_information SET
			is_team_teaching = @is_team_teaching,
			is_irregular_modular = @is_irregular_modular,
			is_fixed_amount = @is_fixed_amount,
			amount = @amount,
			additional_slots = @additional_slots,
			edited_by = @edited_by
		WHERE
			sysid_schedule = @sysid_schedule
		
	END
	ELSE IF ((ums.IsCashierSystemUserInfo(@edited_by) = 1) OR (ums.IsVpOfFinanceSystemUserInfo(@edited_by) = 1)) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.schedule_information AS sci
												WHERE 
													sci.sysid_schedule = @sysid_schedule AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.schedule_information AS sci
												WHERE 
													sci.sysid_schedule = @sysid_schedule AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.schedule_information SET
			is_fixed_amount = @is_fixed_amount,
			amount = @amount,
			edited_by = @edited_by
		WHERE
			sysid_schedule = @sysid_schedule
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Updated a schedule information', 'Schedule Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateScheduleInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteScheduleInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteScheduleInformation')
   DROP PROCEDURE ums.DeleteScheduleInformation
GO

CREATE PROCEDURE ums.DeleteScheduleInformation

	@sysid_schedule varchar (50) = '',
	
	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@deleted_by) = 1) OR
		((ums.IsOfficeUserSystemUserInfo(@deleted_by) = 1) AND (ums.IsUserSameDepartmentSubjectInfo((SELECT
																										sysid_subject
																									FROM
																										ums.schedule_information
																									WHERE
																										sysid_schedule = @sysid_schedule), @deleted_by) = 1))) AND 
		(ums.IsScheduleHasScheduleDetailsLoadedTeacher(@sysid_schedule) = 0) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.schedule_information AS sci
												WHERE 
													sci.sysid_schedule = @sysid_schedule AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.schedule_information AS sci
												WHERE 
													sci.sysid_schedule = @sysid_schedule AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0)
	BEGIN

		IF EXISTS (SELECT sysid_schedule FROM ums.schedule_information WHERE sysid_schedule = @sysid_schedule)
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.schedule_information SET			
				edited_by = @deleted_by
			WHERE
				sysid_schedule = @sysid_schedule			

			DELETE FROM ums.schedule_information WHERE sysid_schedule = @sysid_schedule

		END

	END	
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete a schedule information', 'Schedule Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteScheduleInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByDateStartEndScheduleInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByDateStartEndScheduleInformation')
   DROP PROCEDURE ums.SelectByDateStartEndScheduleInformation
GO

CREATE PROCEDURE ums.SelectByDateStartEndScheduleInformation

	@date_start datetime,
	@date_end datetime,
	@is_marked_deleted bit = 0,

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1) OR (ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.year_id AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,				
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			ci.classroom_code AS classroom_code,
			ci.maximum_capacity AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule,					
					sysid_classroom,
					field_room,
					manual_schedule,
					is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(sci.is_team_teaching = 0)
		UNION ALL
		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.sysid_semester AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,							
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			ci.classroom_code AS classroom_code,
			ci.maximum_capacity AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule,					
					sysid_classroom,
					field_room,
					manual_schedule,
					is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id	
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(sci.is_team_teaching = 0)
		UNION ALL
		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.year_id AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,							
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			NULL AS classroom_code,
			NULL AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule,					
					sysid_classroom,
					field_room,
					manual_schedule,
					is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(scd.sysid_classroom IS NULL) AND
			(sci.is_team_teaching = 0)
		UNION ALL
		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.sysid_semester AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,						
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			NULL AS classroom_code,
			NULL AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule,					
					sysid_classroom,
					field_room,
					manual_schedule,
					is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(scd.sysid_classroom IS NULL) AND
			(sci.is_team_teaching = 0)  
		UNION ALL	------------------------------------------------------------ for team teaching ------------------------------------------------
		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.year_id AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,							
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			NULL AS classroom_code,
			NULL AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule AS sysid_schedule,					
					NULL AS sysid_classroom,
					NULL AS field_room,
					NULL AS manual_schedule,
					'false' AS is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(sci.is_team_teaching = 1)
		UNION ALL
		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.sysid_semester AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,							
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			NULL AS classroom_code,
			NULL AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule,					
					NULL AS sysid_classroom,
					NULL AS field_room,
					NULL AS manual_schedule,
					'false' AS is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(sci.is_team_teaching = 1)		
		ORDER BY
			subject_code
		
	END	
	ELSE IF (ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1)	
	BEGIN

		DECLARE @department_id varchar (50)

		SELECT 
			@department_id = arg.department_id 
		FROM
			ums.access_rights_granted AS arg
		INNER JOIN ums.system_user_info AS sui ON sui.system_user_id = arg.system_user_id
		WHERE
			(arg.access_rights = '@7W_*xAuIz%qTm^rYmq!a38&z#s{>zX2*pUw[#Z@') AND
			(sui.system_user_id = @system_user_id);

		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.year_id AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,					
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			ci.classroom_code AS classroom_code,
			ci.maximum_capacity AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule,					
					sysid_classroom,
					field_room,
					manual_schedule,
					is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(sci.is_team_teaching = 0) AND
			(si.department_id = @department_id)
		UNION ALL
		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.sysid_semester AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,							
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			ci.classroom_code AS classroom_code,
			ci.maximum_capacity AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule,					
					sysid_classroom,
					field_room,
					manual_schedule,
					is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(sci.is_team_teaching = 0) AND
			(si.department_id = @department_id)
		UNION ALL
		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.year_id AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,							
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			NULL AS classroom_code,
			NULL AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule,					
					sysid_classroom,
					field_room,
					manual_schedule,
					is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(scd.sysid_classroom IS NULL) AND
			(sci.is_team_teaching = 0) AND
			(si.department_id = @department_id)
		UNION ALL
		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.sysid_semester AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,							
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			NULL AS classroom_code,
			NULL AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule,					
					sysid_classroom,
					field_room,
					manual_schedule,
					is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(scd.sysid_classroom IS NULL) AND
			(sci.is_team_teaching = 0) AND
			(si.department_id = @department_id)  
		UNION ALL	------------------------------------------------------------ for team teaching ------------------------------------------------
		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.year_id AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,							
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			NULL AS classroom_code,
			NULL AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule AS sysid_schedule,					
					NULL AS sysid_classroom,
					NULL AS field_room,
					NULL AS manual_schedule,
					'false' AS is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(sci.is_team_teaching = 1) AND
			(si.department_id = @department_id)
		UNION ALL
		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.sysid_semester AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,							
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			NULL AS classroom_code,
			NULL AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule,					
					NULL AS sysid_classroom,
					NULL AS field_room,
					NULL AS manual_schedule,
					'false' AS is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(sci.is_team_teaching = 1) AND
			(si.department_id = @department_id)
		UNION ALL
		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.year_id AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,							
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			NULL AS classroom_code,
			NULL AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule,					
					NULL AS sysid_classroom,
					NULL AS field_room,
					NULL AS manual_schedule,
					'false' AS is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(sci.is_team_teaching = 1) AND
			(si.department_id = @department_id)
		UNION ALL
		SELECT
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.sysid_semester AS year_semester_id,		
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,							
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			si.department_id AS department_id,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			cg.is_semestral AS is_semestral,
			NULL AS classroom_code,
			NULL AS maximum_capacity,
			di.department_name AS department_name
		FROM
			ums.schedule_information AS sci
		INNER JOIN 
			(
				SELECT
					DISTINCT sysid_schedule,					
					NULL AS sysid_classroom,
					NULL AS field_room,
					NULL AS manual_schedule,
					'false' AS is_classroom
				FROM ums.schedule_information_details 
				WHERE
					is_marked_deleted = @is_marked_deleted
			) AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(sci.is_marked_deleted = @is_marked_deleted) AND
			(sci.is_team_teaching = 1) AND
			(si.department_id = @department_id)		
		ORDER BY
			subject_code
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a schedule information', 'Schedule Information'		
	END	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByDateStartEndScheduleInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountScheduleInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountScheduleInformation')
   DROP PROCEDURE ums.GetCountScheduleInformation
GO

CREATE PROCEDURE ums.GetCountScheduleInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_schedule) FROM ums.schedule_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a schedule information', 'Schedule Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountScheduleInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsSysIDScheduleInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsSysIDScheduleInformation')
   DROP PROCEDURE ums.IsExistsSysIDScheduleInformation
GO

CREATE PROCEDURE ums.IsExistsSysIDScheduleInformation

	@sysid_schedule varchar (50) = '',
	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsSysIDScheduleInfo(@sysid_schedule)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a schedule information', 'Schedule Information'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsSysIDScheduleInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistsSysIDScheduleInfo" function already exist
IF OBJECT_ID (N'ums.IsExistsSysIDScheduleInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistsSysIDScheduleInfo
GO

CREATE FUNCTION ums.IsExistsSysIDScheduleInfo
(	
	@sysid_schedule varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_schedule FROM ums.schedule_information WHERE sysid_schedule = @sysid_schedule)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "GetYearSemesterIDSchedule" function already exist
IF OBJECT_ID (N'ums.GetYearSemesterIDSchedule') IS NOT NULL
   DROP FUNCTION ums.GetYearSemesterIDSchedule
GO

CREATE FUNCTION ums.GetYearSemesterIDSchedule
(	
	@sysid_schedule varchar (50) = ''
)
RETURNS varchar (50)
AS
BEGIN
	
	DECLARE @result varchar (50)

	SELECT @result = year_id FROM ums.schedule_information WHERE sysid_schedule = @sysid_schedule

	IF @result IS NULL OR @result = ''
	BEGIN
		SELECT @result = sysid_semester FROM ums.schedule_information WHERE sysid_schedule = @sysid_schedule
	END
	
	RETURN @result

END
GO
------------------------------------------------------

-- verifies if the "IsIrregularModularSysIDScheduleInfo" function already exist
IF OBJECT_ID (N'ums.IsIrregularModularSysIDScheduleInfo') IS NOT NULL
   DROP FUNCTION ums.IsIrregularModularSysIDScheduleInfo
GO

CREATE FUNCTION ums.IsIrregularModularSysIDScheduleInfo
(	
	@sysid_schedule varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_schedule FROM ums.schedule_information WHERE sysid_schedule = @sysid_schedule AND
															is_irregular_modular = 1)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------


-- ############################################END TABLE "schedule_information" OBJECTS######################################################




-- ################################################TABLE "schedule_information_details" OBJECTS######################################################
-- verifies if the schedule_information_details table exists
IF OBJECT_ID('ums.schedule_information_details', 'U') IS NOT NULL
	DROP TABLE ums.schedule_information_details
GO

CREATE TABLE ums.schedule_information_details 			
(
	sysid_scheddetails varchar (50) NOT NULL
		CONSTRAINT Schedule_Information_Details_SysID_SchedDetails_PK PRIMARY KEY (sysid_scheddetails)
		CONSTRAINT Schedule_Information_Details_SysID_SchedDetails_CK CHECK (sysid_scheddetails LIKE 'SYSSDL%'),
	sysid_schedule varchar (50) NOT NULL 
		CONSTRAINT Schedule_Information_Details_SysID_Schedule_FK FOREIGN KEY REFERENCES ums.schedule_information(sysid_schedule) ON UPDATE NO ACTION,
	sysid_classroom varchar (50) NULL
		CONSTRAINT Schedule_Information_Details_SysID_Classroom_FK FOREIGN KEY REFERENCES ums.classroom_information(sysid_classroom) ON UPDATE NO ACTION,
	
	field_room varchar (50) NULL,

	manual_schedule varchar (200) NULL,

	is_classroom bit NOT NULL DEFAULT (1),
	
	is_marked_deleted bit NOT NULL DEFAULT (0),

	lecture_units float (3) NOT NULL DEFAULT (0),
	lab_units float (3) NOT NULL DEFAULT (0),
	no_hours varchar (12) NOT NULL DEFAULT ('00:00')
		CONSTRAINT Schedule_Information_Details_No_Hours_CK CHECK (no_hours LIKE '[0-9][0-9]:[0-5][0-9]'),

	section varchar (150) NULL,

	day_time varchar (200) NULL,
	
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Schedule_Information_Details_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Schedule_Information_Details_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Schedule_Information_Details_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the schedule_information_details table 
CREATE INDEX Schedule_Information_Details_SysID_SchedDetails_Index
	ON ums.schedule_information_details (sysid_scheddetails DESC)
GO
------------------------------------------------------------------

--verifies that the trigger "Schedule_Information_Details_Trigger_Insert" already exist
IF OBJECT_ID ('ums.Schedule_Information_Details_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Schedule_Information_Details_Trigger_Insert
GO

CREATE TRIGGER ums.Schedule_Information_Details_Trigger_Insert
	ON  ums.schedule_information_details
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_scheddetails varchar (50)
	DECLARE @sysid_schedule varchar (50)		
	DECLARE @sysid_classroom varchar (50)	
	DECLARE @field_room varchar (50)	
	DECLARE @manual_schedule varchar (200)
	DECLARE @lecture_units float (3)
	DECLARE @lab_units float (3)
	DECLARE @no_hours varchar (12)
	DECLARE @section varchar (150)
	DECLARE @day_time varchar (200)
	DECLARE @sysid_subject varchar (50)
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @is_team_teaching bit		
	DECLARE @is_irregular_modular bit	
	DECLARE @is_fixed_amount bit
	DECLARE @amount decimal (12, 2)
	DECLARE @additional_slots smallint
	DECLARE @is_semestral bit	
	DECLARE @created_by varchar (50)

	DECLARE @year_semester_description varchar (100)
	DECLARE @team_teaching varchar (100)
	DECLARE @irregular_modular varchar (100)
	DECLARE @fixed_amount varchar (50)
	
	SELECT 
		@sysid_scheddetails = i.sysid_scheddetails,
		@sysid_schedule = i.sysid_schedule,		
		@sysid_classroom = i.sysid_classroom,		
		@field_room = i.field_room,		
		@manual_schedule = i.manual_schedule,
		@lecture_units = i.lecture_units,
		@lab_units = i.lab_units,
		@no_hours = i.no_hours,
		@section = i.section,
		@day_time = i.day_time,
		@sysid_subject = sci.sysid_subject,
		@year_id = sci.year_id,
		@sysid_semester = sci.sysid_semester,
		@is_team_teaching = sci.is_team_teaching,
		@is_irregular_modular = sci.is_irregular_modular,
		@is_fixed_amount = sci.is_fixed_amount,
		@amount = sci.amount,
		@additional_slots = sci.additional_slots,
		@is_semestral = cg.is_semestral,
		@created_by = i.created_by
	FROM INSERTED AS i
	INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = i.sysid_schedule
	INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
	INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id

	SET @year_semester_description = ''

	IF (@is_semestral = 0) AND (NOT @year_id IS NULL)
	BEGIN
		SELECT @year_semester_description = year_description FROM ums.school_year WHERE year_id = @year_id
	END
	ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL)
	BEGIN
		SELECT @year_semester_description = sy.year_description + ' - ' + ss.semester_description
		FROM 
			ums.semester_information AS si
		INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
		INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
		WHERE 
			si.sysid_semester = @sysid_semester
	END

	IF (@is_team_teaching = 1)
	BEGIN

		IF (NOT @lecture_units = 0 OR NOT @lab_units = 0)
		BEGIN
			SET @team_teaching = 'YES : Lecture Units: ' + CONVERT(varchar, @lecture_units) + ' Lab Units: ' + CONVERT(varchar, @lab_units)
		END
		ELSE
		BEGIN
			SET @team_teaching = 'YES : No. of Hours: ' + @no_hours
		END

	END
	ELSE
	BEGIN

		IF (NOT @lecture_units = 0 OR NOT @lab_units = 0)
		BEGIN
			SET @team_teaching = 'NO : Lecture Units: ' + CONVERT(varchar, @lecture_units) + ' Lab Units: ' + CONVERT(varchar, @lab_units)
		END
		ELSE
		BEGIN
			SET @team_teaching = 'NO : No. of Hours: ' + @no_hours
		END

	END

	IF (@is_irregular_modular = 1)
	BEGIN

		SET @irregular_modular = 'YES : Manual Schedule: ' + ISNULL(@manual_schedule, '')

	END
	ELSE
	BEGIN

		SET @irregular_modular = 'NO : Day Time: ' + ISNULL(@day_time, '')

	END

	IF (@is_fixed_amount = 1)
	BEGIN
		SET @fixed_amount = 'YES with an amount ' + ISNULL(CONVERT(varchar, CONVERT(money, @amount), 1), '0.00')
	END
	ELSE
	BEGIN
		SET @fixed_amount = 'NO'
	END

	SET @transaction_done = 'CREATED a new schedule information details ' + 
							'[Schedule ID: ' + ISNULL(@sysid_schedule, '') +
							'][Schedule Details ID: ' + ISNULL(@sysid_scheddetails, '') +							
							'][Subject Title: ' + (SELECT ISNULL(subject_code, '') + ' - ' + ISNULL(descriptive_title, '') FROM ums.subject_information WHERE sysid_subject = @sysid_subject) + 
							'][School Year / Semester: ' + ISNULL(@year_semester_description, '') +
							'][Is Team Teaching: ' + ISNULL(@team_teaching, '') +
							'][Is Irregular / Modular: ' + ISNULL(@irregular_modular, '') +
							'][Is Fixed Amount: ' + ISNULL(@fixed_amount, '') + 
							'][Additional Slots: ' + ISNULL(CONVERT(varchar, @additional_slots), '0') +
							'][Section: ' + ISNULL(@section, '') +
							'][Classroom: ' + ISNULL((SELECT classroom_code FROM ums.classroom_information WHERE sysid_classroom = @sysid_classroom), ISNULL(@field_room, 'TBA')) +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
-----------------------------------------------------------------

--verifies that the trigger "Schedule_Information_Details_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Schedule_Information_Details_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Schedule_Information_Details_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Schedule_Information_Details_Trigger_Instead_Update
	ON  ums.schedule_information_details
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_scheddetails varchar (50)
	DECLARE @sysid_schedule varchar (50)		
	DECLARE @sysid_classroom varchar (50)	
	DECLARE @field_room varchar (50)	
	DECLARE @manual_schedule varchar (200)
	DECLARE @is_classroom bit	
	DECLARE @is_marked_deleted bit
	DECLARE @lecture_units float (3)
	DECLARE @lab_units float (3)
	DECLARE @no_hours varchar (12)
	DECLARE @section varchar (150)
	DECLARE @day_time varchar (200)
	DECLARE @sysid_subject varchar (50)
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @is_semestral bit	
	DECLARE @edited_by varchar (50)

	DECLARE @sysid_classroom_b varchar (50)
	DECLARE @field_room_b varchar (50)	
	DECLARE @manual_schedule_b varchar (200)
	DECLARE @is_classroom_b bit
	DECLARE @lecture_units_b float (3)
	DECLARE @lab_units_b float (3)
	DECLARE @no_hours_b varchar (12)
	DECLARE @section_b varchar (150)
	DECLARE @day_time_b varchar (200)

	DECLARE @year_semester_description varchar (100)
	DECLARE @team_teaching varchar (100)
	DECLARE @team_teaching_b varchar (100)

	DECLARE @has_update bit

	DECLARE schedule_information_details_update_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
		FOR SELECT i.sysid_scheddetails, i.sysid_schedule, i.sysid_classroom, i.field_room,	i.manual_schedule, i.is_classroom, i.is_marked_deleted,
					i.lecture_units, i.lab_units, i.no_hours, i.section, i.day_time, sci.sysid_subject,
					sci.year_id, sci.sysid_semester, cg.is_semestral, i.edited_by
				FROM INSERTED AS i
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = i.sysid_schedule
				INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id

	OPEN schedule_information_details_update_cursor

	FETCH NEXT FROM schedule_information_details_update_cursor
		INTO @sysid_scheddetails, @sysid_schedule, @sysid_classroom, @field_room, @manual_schedule, @is_classroom, @is_marked_deleted,
				@lecture_units, @lab_units, @no_hours, @section, @day_time, @sysid_subject,
				@year_id, @sysid_semester, @is_semestral, @edited_by

	WHILE @@FETCH_STATUS = 0
	BEGIN

		IF @is_marked_deleted = 0
		BEGIN

			SELECT
				@sysid_classroom_b = scd.sysid_classroom,
				@field_room_b = scd.field_room,
				@manual_schedule_b = scd.manual_schedule,
				@is_classroom_b = scd.is_classroom,
				@lecture_units_b = scd.lecture_units,
				@lab_units_b = scd.lab_units,
				@no_hours_b = scd.no_hours,
				@section_b = scd.section,
				@day_time_b = scd.day_time
			FROM
				ums.schedule_information_details AS scd
			WHERE
				sysid_scheddetails = @sysid_scheddetails

			SET @transaction_done = ''
			SET @has_update = 0
			
			IF 	NOT ISNULL(CONVERT(varchar, @lecture_units), '') = ISNULL(CONVERT(varchar, @lecture_units_b), '') OR
				NOT ISNULL(CONVERT(varchar, @lab_units), '') = ISNULL(CONVERT(varchar, @lab_units_b), '') OR
				NOT ISNULL(@no_hours, '') = ISNULL(@no_hours_b, '')
			BEGIN

				IF (NOT @lecture_units = 0 OR NOT @lab_units = 0)
				BEGIN
					SET @team_teaching = 'Lecture Units: ' + CONVERT(varchar, @lecture_units) + ' Lab Units: ' + CONVERT(varchar, @lab_units)
				END
				ELSE
				BEGIN
					SET @team_teaching = 'No. of Hours: ' + @no_hours
				END

				IF (NOT @lecture_units_b = 0 OR NOT @lab_units_b = 0)
				BEGIN
					SET @team_teaching_b = 'Lecture Units: ' + CONVERT(varchar, @lecture_units_b) + ' Lab Units: ' + CONVERT(varchar, @lab_units_b)
				END
				ELSE
				BEGIN
					SET @team_teaching_b = 'No. of Hours: ' + @no_hours_b
				END

				SET @transaction_done = '[No. of Units / Hours Before: ' + @team_teaching_b + ']' +
										'[No. of Units / Hours After: ' + @team_teaching + ']'
				SET @has_update = 1
			END

			IF NOT ISNULL(@section COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@section_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')
			BEGIN
				SET @transaction_done = @transaction_done + '[Section Before: ' + ISNULL(@section_b, '') + ']' +
															'[Section After: ' + ISNULL(@section, '') + ']'
				SET @has_update = 1
			END

			IF NOT ISNULL(@sysid_classroom_b, '') = ISNULL(@sysid_classroom, '') OR
				NOT @is_classroom_b = @is_classroom 
			BEGIN

				UPDATE ums.subject_schedule SET edited_by = @edited_by WHERE sysid_scheddetails = @sysid_scheddetails
				DELETE FROM ums.subject_schedule WHERE sysid_scheddetails = @sysid_scheddetails

				SET @transaction_done = @transaction_done + '[Classroom Before: ' + ISNULL((SELECT classroom_code FROM ums.classroom_information WHERE sysid_classroom = @sysid_classroom_b), ISNULL(@field_room_b, 'TBA')) + ']' +
															'[Classroom After: ' + ISNULL((SELECT classroom_code FROM ums.classroom_information WHERE sysid_classroom = @sysid_classroom), ISNULL(@field_room, 'TBA')) + ']'
				
				SET @has_update = 1
			END
			ELSE IF NOT ISNULL(@field_room_b COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@field_room COLLATE SQL_Latin1_General_CP1_CS_AS, '')
			BEGIN
				
				SET @transaction_done = @transaction_done + '[Classroom Before: ' + ISNULL(@field_room_b, 'TBA') + ']' +
															'[Classroom After: ' + ISNULL(@field_room, 'TBA') + ']'
				
				SET @has_update = 1

			END

			IF NOT ISNULL(@manual_schedule COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@manual_schedule_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')
			BEGIN

				SET @transaction_done = @transaction_done + '[Manual Schedule Before: ' + ISNULL(@manual_schedule_b, '') + ']' +
															'[Manual Schedule After: ' + ISNULL(@manual_schedule, '') + ']'
				
				SET @has_update = 1

			END

			IF NOT ISNULL(@day_time COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@day_time_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')
			BEGIN

				SET @transaction_done = @transaction_done + '[Day Time Before: ' + ISNULL(@day_time_b, '') + ']' +
															'[Day Time After: ' + ISNULL(@day_time, '') + ']'
				
				SET @has_update = 1

			END


			IF @has_update = 1
			BEGIN

				UPDATE ums.schedule_information_details SET
					sysid_classroom = @sysid_classroom,
					field_room = @field_room,
					manual_schedule = @manual_schedule,
					is_classroom = @is_classroom,
					lecture_units = @lecture_units,
					lab_units = @lab_units,
					no_hours = @no_hours,
					section = @section,
					day_time = @day_time,

					edited_on = GETDATE(),
					edited_by = @edited_by
				WHERE
					sysid_scheddetails = @sysid_scheddetails

				SET @year_semester_description = ''

				IF (@is_semestral = 0) AND (NOT @year_id IS NULL)
				BEGIN
					SELECT @year_semester_description = year_description FROM ums.school_year WHERE year_id = @year_id
				END
				ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL)
				BEGIN
					SELECT @year_semester_description = sy.year_description + ' - ' + ss.semester_description
					FROM 
						ums.semester_information AS si
					INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
					INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
					WHERE 
						si.sysid_semester = @sysid_semester
				END

				SET @transaction_done = 'UPDATED a schedule information details ' + 
										'[Schedule ID: ' + ISNULL(@sysid_schedule, '') +								
										'][Schedule Details ID: ' + ISNULL(@sysid_scheddetails, '') +
										'][Subject Title: ' + (SELECT ISNULL(subject_code, '') + ' - ' + ISNULL(descriptive_title, '') FROM ums.subject_information WHERE sysid_subject = @sysid_subject) + 
										'][School Year / Semester: ' + ISNULL(@year_semester_description, '') +								
										']' + @transaction_done

				IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
				BEGIN
					SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
				END
						
				EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done	
			END
			ELSE IF NOT @edited_by IS NULL
			BEGIN

				--used for the delete trigger
				UPDATE ums.schedule_information_details SET
					edited_on = GETDATE(),
					edited_by = @edited_by
				WHERE
					sysid_scheddetails = @sysid_scheddetails

			END	

		END

		FETCH NEXT FROM schedule_information_details_update_cursor
			INTO @sysid_scheddetails, @sysid_schedule, @sysid_classroom, @field_room, @manual_schedule, @is_classroom, @is_marked_deleted,
					@lecture_units, @lab_units, @no_hours, @section, @day_time, @sysid_subject,
					@year_id, @sysid_semester, @is_semestral, @edited_by

	END

	CLOSE schedule_information_details_update_cursor
	DEALLOCATE schedule_information_details_update_cursor

GO
-----------------------------------------------------------------

--verifies that the trigger "Schedule_Information_Details_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Schedule_Information_Details_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Schedule_Information_Details_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Schedule_Information_Details_Trigger_Instead_Delete
	ON  ums.schedule_information_details
	INSTEAD OF DELETE 
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_scheddetails varchar (50)
	DECLARE @sysid_schedule varchar (50)		
	DECLARE @sysid_classroom varchar (50)	
	DECLARE @field_room varchar (50)
	DECLARE @manual_schedule varchar (200)
	DECLARE @is_marked_deleted bit	
	DECLARE @lecture_units tinyint
	DECLARE @lab_units tinyint
	DECLARE @no_hours varchar (12)
	DECLARE @section varchar (150)
	DECLARE @day_time varchar (200)
	DECLARE @sysid_subject varchar (50)
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @is_team_teaching bit
	DECLARE @is_semestral bit
	DECLARE @deleted_by varchar (50)

	DECLARE @year_semester_description varchar (100)
	DECLARE @team_teaching varchar (100)

	DECLARE schedule_information_details_delete_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
		FOR SELECT d.sysid_scheddetails, d.sysid_schedule, d.sysid_classroom, d.field_room, d.manual_schedule, d.is_marked_deleted,
					d.lecture_units, d.lab_units, d.no_hours, d.section, d.day_time, sci.sysid_subject,
					sci.year_id, sci.sysid_semester, sci.is_team_teaching, cg.is_semestral, d.edited_by
				FROM DELETED AS d
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = d.sysid_schedule
				INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id

	OPEN schedule_information_details_delete_cursor

	FETCH NEXT FROM schedule_information_details_delete_cursor
		INTO @sysid_scheddetails, @sysid_schedule, @sysid_classroom, @field_room, @manual_schedule, @is_marked_deleted,
				@lecture_units, @lab_units, @no_hours, @section, @day_time, @sysid_subject,
				@year_id, @sysid_semester, @is_team_teaching, @is_semestral, @deleted_by

	WHILE @@FETCH_STATUS = 0
	BEGIN

		IF @is_marked_deleted = 0
		BEGIN

--			DECLARE @details_count tinyint
--
--			SELECT @details_count = COUNT(sysid_scheddetails) FROM ums.schedule_information_details WHERE sysid_schedule = @sysid_schedule AND
--																							is_marked_deleted = 0
--
--			IF @details_count = 1
--			BEGIN
--
--				UPDATE ums.student_load SET edited_by = @deleted_by WHERE sysid_schedule = @sysid_schedule
--				DELETE FROM ums.student_load WHERE sysid_schedule = @sysid_schedule
--
--			END

			--delete of teacher load is been disabled because a schedule details cannot be deleted if there is still an instructor
			--assigned to that certain schedule details and only the payroll master can deload/delete a teacher load.
--			UPDATE ums.teacher_load SET edited_by = @deleted_by WHERE sysid_scheddetails = @sysid_scheddetails
--			DELETE FROM ums.teacher_load WHERE sysid_scheddetails = @sysid_scheddetails

			--delete of a subject schedule is been enabled because displaying the day and time schedule of the deleted schedule details is not necessary
			UPDATE ums.subject_schedule SET edited_by = @deleted_by WHERE sysid_scheddetails = @sysid_scheddetails
			DELETE FROM ums.subject_schedule WHERE sysid_scheddetails = @sysid_scheddetails

			UPDATE ums.schedule_information_details SET is_marked_deleted = 1, edited_by = @deleted_by WHERE sysid_scheddetails = @sysid_scheddetails

			SET @year_semester_description = ''

			IF (@is_semestral = 0) AND (NOT @year_id IS NULL)
			BEGIN
				SELECT @year_semester_description = year_description FROM ums.school_year WHERE year_id = @year_id
			END
			ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL)
			BEGIN
				SELECT @year_semester_description = sy.year_description + ' - ' + ss.semester_description
				FROM 
					ums.semester_information AS si
				INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
				INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
				WHERE 
					si.sysid_semester = @sysid_semester
			END

			IF (@is_team_teaching = 1)
			BEGIN

				IF (NOT @lecture_units = 0 OR NOT @lab_units = 0)
				BEGIN
					SET @team_teaching = 'YES : Lecture Units: ' + CONVERT(varchar, @lecture_units) + ' Lab Units: ' + CONVERT(varchar, @lab_units)
				END
				ELSE
				BEGIN
					SET @team_teaching = 'YES : No. of Hours: ' + @no_hours
				END

			END
			ELSE
			BEGIN

				IF (NOT @lecture_units = 0 OR NOT @lab_units = 0)
				BEGIN
					SET @team_teaching = 'NO : Lecture Units: ' + CONVERT(varchar, @lecture_units) + ' Lab Units: ' + CONVERT(varchar, @lab_units)
				END
				ELSE
				BEGIN
					SET @team_teaching = 'NO : No. of Hours: ' + @no_hours
				END

			END

			SET @transaction_done = 'MARK AS DELETED a schedule information details ' + 
									'[Schedule ID: ' + ISNULL(@sysid_schedule, '') +
									'][Schedule Details ID: ' + ISNULL(@sysid_scheddetails, '') +
									'][Subject Title: ' + (SELECT ISNULL(subject_code, '') + ' - ' + ISNULL(descriptive_title, '') FROM ums.subject_information WHERE sysid_subject = @sysid_subject) + 												  
									'][Classroom: ' + ISNULL((SELECT classroom_code FROM ums.classroom_information WHERE sysid_classroom = @sysid_classroom), ISNULL(@field_room, 'Field')) +
									'][Manual Schedule: ' + ISNULL(@manual_schedule, '') +
									'][School Year / Semester: ' + ISNULL(@year_semester_description, '') +
									'][Is Team Teaching: ' + ISNULL(@team_teaching, '') +
									'][Section: ' + ISNULL(@section, '') +
									'][Day Time: ' + ISNULL(@day_time, '') +
									']'


			IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
			BEGIN
				SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @deleted_by
			END
					
			EXECUTE ums.InsertTransactionLog @deleted_by, @network_information, @transaction_done	

		END

		FETCH NEXT FROM schedule_information_details_delete_cursor
			INTO @sysid_scheddetails, @sysid_schedule, @sysid_classroom, @field_room, @manual_schedule, @is_marked_deleted,
					@lecture_units, @lab_units, @no_hours, @section, @day_time, @sysid_subject,
					@year_id, @sysid_semester, @is_team_teaching, @is_semestral, @deleted_by

	END

	CLOSE schedule_information_details_delete_cursor
	DEALLOCATE schedule_information_details_delete_cursor


GO
-----------------------------------------------------------------

-- verifies if the procedure "InsertScheduleInformationDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertScheduleInformationDetails')
   DROP PROCEDURE ums.InsertScheduleInformationDetails
GO

CREATE PROCEDURE ums.InsertScheduleInformationDetails

	@sysid_scheddetails varchar (50) = '',
	@sysid_schedule varchar (50) = '',
	@sysid_classroom varchar (50) = '',
	@field_room varchar (50) = '',
	@manual_schedule varchar (200) = '',
	@is_classroom bit = 0,
	@lecture_units float (3) = 0,
	@lab_units float (3) = 0,
	@no_hours varchar (12) = '',
	@section varchar (150) = '',
	@day_time varchar (200) = '',

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@created_by) = 1) OR
		((ums.IsOfficeUserSystemUserInfo(@created_by) = 1) AND 
		(ums.IsUserSameDepartmentSubjectInfo((SELECT sysid_subject FROM ums.schedule_information WHERE sysid_schedule = @sysid_schedule), @created_by) = 1))) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.schedule_information AS sci
												WHERE 
													sci.sysid_schedule = @sysid_schedule AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION ALL
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.schedule_information AS sci
												WHERE 
													sci.sysid_schedule = @sysid_schedule AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		IF ((@is_classroom = 1) AND (NOT ISNULL(@sysid_classroom, '') = ''))
		BEGIN

			INSERT INTO ums.schedule_information_details
			(
				sysid_scheddetails,
				sysid_schedule,
				sysid_classroom,
				field_room,
				manual_schedule,
				is_classroom,
				lecture_units,
				lab_units,
				no_hours,
				section,
				day_time,

				created_by
			)
			VALUES
			(
				@sysid_scheddetails,
				@sysid_schedule,
				@sysid_classroom,
				NULL,
				@manual_schedule,
				@is_classroom,
				@lecture_units,
				@lab_units,
				@no_hours,
				@section,
				@day_time,

				@created_by
			)

		END	
		ELSE
		BEGIN

			INSERT INTO ums.schedule_information_details
			(
				sysid_scheddetails,
				sysid_schedule,
				sysid_classroom,
				field_room,
				manual_schedule,
				is_classroom,
				lecture_units,
				lab_units,
				no_hours,
				section,
				day_time,

				created_by
			)
			VALUES
			(
				@sysid_scheddetails,
				@sysid_schedule,
				NULL,
				@field_room,
				@manual_schedule,
				0,
				@lecture_units,
				@lab_units,
				@no_hours,
				@section,				
				@day_time,

				@created_by
			)

		END
		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new schedule information details', 'Schedule Information Details'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertScheduleInformationDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateScheduleInformationDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateScheduleInformationDetails')
   DROP PROCEDURE ums.UpdateScheduleInformationDetails
GO

CREATE PROCEDURE ums.UpdateScheduleInformationDetails

	@sysid_scheddetails varchar (50) = '',
	@sysid_classroom varchar (50) = '',
	@field_room varchar (50) = '',
	@manual_schedule varchar (200) = '',
	@is_classroom bit = 0,
	@lecture_units float (3) = 0,
	@lab_units float (3) = 0,
	@no_hours varchar (12) = '',
	@section varchar (150) = '',
	@day_time varchar (200) = '',

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@edited_by) = 1) OR
		((ums.IsOfficeUserSystemUserInfo(@edited_by) = 1) AND 
		(ums.IsUserSameDepartmentSubjectInfo((SELECT 
													sci.sysid_subject 
												FROM 
													ums.schedule_information_details AS scd
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
												WHERE 
													scd.sysid_scheddetails = @sysid_scheddetails), @edited_by) = 1))) AND
		(ums.IsScheduleDetailsLoadedTeacher(@sysid_scheddetails) = 0) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.schedule_information_details AS scd
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
												WHERE 
													scd.sysid_scheddetails = @sysid_scheddetails AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION ALL
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.schedule_information_details AS scd
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
												WHERE 
													scd.sysid_scheddetails = @sysid_scheddetails AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0)
		
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		IF ((@is_classroom = 1) AND (NOT ISNULL(@sysid_classroom, '') = ''))
		BEGIN

			UPDATE ums.schedule_information_details SET
				sysid_classroom = @sysid_classroom,
				field_room = NULL,
				manual_schedule = @manual_schedule,
				is_classroom = @is_classroom,
				lecture_units = @lecture_units,
				lab_units = @lab_units,
				no_hours = @no_hours,
				section = @section,
				day_time = @day_time,

				edited_by = @edited_by
			WHERE
				sysid_scheddetails = @sysid_scheddetails

		END
		ELSE
		BEGIN

			UPDATE ums.schedule_information_details SET
				sysid_classroom = NULL,
				field_room = @field_room,
				manual_schedule = @manual_schedule,
				is_classroom = 0,
				lecture_units = @lecture_units,
				lab_units = @lab_units,
				no_hours = @no_hours,
				section = @section,
				day_time = @day_time,

				edited_by = @edited_by
			WHERE
				sysid_scheddetails = @sysid_scheddetails

		END
		
	END
	ELSE
	BEGIN
	
		EXECUTE ums.ShowErrorMsg 'Updated a schedule information details', 'Schedule Information Details'

	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateScheduleInformationDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteScheduleInformationDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteScheduleInformationDetails')
   DROP PROCEDURE ums.DeleteScheduleInformationDetails
GO

CREATE PROCEDURE ums.DeleteScheduleInformationDetails

	@sysid_scheddetails varchar (50) = '',
	
	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@deleted_by) = 1) OR
		((ums.IsOfficeUserSystemUserInfo(@deleted_by) = 1) AND 
		(ums.IsUserSameDepartmentSubjectInfo((SELECT 
													sci.sysid_subject 
												FROM 
													ums.schedule_information_details AS scd
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
												WHERE 
													scd.sysid_scheddetails = @sysid_scheddetails), @deleted_by) = 1))) AND
		(ums.IsScheduleDetailsLoadedTeacher(@sysid_scheddetails) = 0) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.schedule_information_details AS scd
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
												WHERE 
													scd.sysid_scheddetails = @sysid_scheddetails AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION ALL
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.schedule_information_details AS scd
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
												WHERE 
													scd.sysid_scheddetails = @sysid_scheddetails AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0)
	BEGIN

		IF EXISTS (SELECT sysid_scheddetails FROM ums.schedule_information_details WHERE sysid_scheddetails = @sysid_scheddetails)
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.schedule_information_details SET			
				edited_by = @deleted_by
			WHERE
				sysid_scheddetails = @sysid_scheddetails			

			DELETE FROM ums.schedule_information_details WHERE sysid_scheddetails = @sysid_scheddetails

		END

	END	
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete a schedule information details', 'Schedule Information Details'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteScheduleInformationDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectBySysIDScheduleScheduleInformationDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDScheduleScheduleInformationDetails')
   DROP PROCEDURE ums.SelectBySysIDScheduleScheduleInformationDetails
GO

CREATE PROCEDURE ums.SelectBySysIDScheduleScheduleInformationDetails

	@sysid_schedule varchar (50) = '',

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)  OR
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT
			scd.sysid_scheddetails AS sysid_scheddetails,
			scd.sysid_schedule AS sysid_schedule,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.lecture_units AS lecture_units,
			scd.lab_units AS lab_units,
			scd.no_hours AS no_hours,	
			scd.section AS section,
			scd.day_time AS day_time,
			scd.is_marked_deleted AS is_marked_deleted,		
			ci.classroom_code AS classroom_code,
			ci.maximum_capacity AS maximum_capacity
		FROM
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		WHERE
			(NOT scd.sysid_classroom IS NULL) AND
			(scd.sysid_schedule = @sysid_schedule)
		UNION ALL
		SELECT
			scd.sysid_scheddetails AS sysid_scheddetails,
			scd.sysid_schedule AS sysid_schedule,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.lecture_units AS lecture_units,
			scd.lab_units AS lab_units,
			scd.no_hours AS no_hours,
			scd.section AS section,
			scd.day_time AS day_time,
			scd.is_marked_deleted AS is_marked_deleted,			
			NULL AS classroom_code,
			NULL AS maximum_capacity
		FROM
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		WHERE
			(scd.sysid_classroom IS NULL) AND
			(scd.sysid_schedule = @sysid_schedule)
		ORDER BY
			scd.sysid_scheddetails DESC
		
	END	
	ELSE IF  (ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1)	
	BEGIN

		DECLARE @department_id varchar (50)

		SELECT 
			@department_id = arg.department_id 
		FROM
			ums.access_rights_granted AS arg
		INNER JOIN ums.system_user_info AS sui ON sui.system_user_id = arg.system_user_id
		WHERE
			(arg.access_rights = '@7W_*xAuIz%qTm^rYmq!a38&z#s{>zX2*pUw[#Z@') AND
			(sui.system_user_id = @system_user_id);

		SELECT
			scd.sysid_scheddetails AS sysid_scheddetails,
			scd.sysid_schedule AS sysid_schedule,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.lecture_units AS lecture_units,
			scd.lab_units AS lab_units,
			scd.no_hours AS no_hours,
			scd.section AS section,
			scd.day_time AS day_time,
			scd.is_marked_deleted AS is_marked_deleted,			
			ci.classroom_code AS classroom_code,
			ci.maximum_capacity AS maximum_capacity
		FROM
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		WHERE
			(NOT scd.sysid_classroom IS NULL) AND
			(scd.sysid_schedule = @sysid_schedule) AND
			(si.department_id = @department_id)
		UNION ALL
		SELECT
			scd.sysid_scheddetails AS sysid_scheddetails,
			scd.sysid_schedule AS sysid_schedule,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.lecture_units AS lecture_units,
			scd.lab_units AS lab_units,
			scd.no_hours AS no_hours,
			scd.section AS section,
			scd.day_time AS day_time,
			scd.is_marked_deleted AS is_marked_deleted,			
			NULL AS classroom_code,
			NULL AS maximum_capacity
		FROM
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		WHERE
			(scd.sysid_classroom IS NULL) AND
			(scd.sysid_schedule = @sysid_schedule) AND
			(si.department_id = @department_id)
		ORDER BY
			scd.sysid_scheddetails DESC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a schedule information details', 'Schedule Information Details'		
	END
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySysIDScheduleScheduleInformationDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountScheduleInformationDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountScheduleInformationDetails')
   DROP PROCEDURE ums.GetCountScheduleInformationDetails
GO

CREATE PROCEDURE ums.GetCountScheduleInformationDetails

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_scheddetails) FROM ums.schedule_information_details
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a schedule information details', 'Schedule Information Details'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountScheduleInformationDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsSysIDScheduleInformationDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsSysIDScheduleInformationDetails')
   DROP PROCEDURE ums.IsExistsSysIDScheduleInformationDetails
GO

CREATE PROCEDURE ums.IsExistsSysIDScheduleInformationDetails

	@sysid_scheddetails varchar (50) = '',
	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsSysIDScheduleInfoDetails(@sysid_scheddetails)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a schedule information', 'Schedule Information'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsSysIDScheduleInformationDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistsSysIDScheduleInfoDetails" function already exist
IF OBJECT_ID (N'ums.IsExistsSysIDScheduleInfoDetails') IS NOT NULL
   DROP FUNCTION ums.IsExistsSysIDScheduleInfoDetails
GO

CREATE FUNCTION ums.IsExistsSysIDScheduleInfoDetails
(	
	@sysid_scheddetails varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_scheddetails FROM ums.schedule_information_details WHERE sysid_scheddetails = @sysid_scheddetails)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- ################################################END TABLE "schedule_information_details" OBJECTS######################################################




-- ################################################TABLE "subject_schedule" OBJECTS######################################################
-- verifies if the subject_schedule table exists
IF OBJECT_ID('ums.subject_schedule', 'U') IS NOT NULL
	DROP TABLE ums.subject_schedule
GO

CREATE TABLE ums.subject_schedule 			
(
	schedule_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Subject_Schedule_Schedule_ID_PK PRIMARY KEY (schedule_id),
	sysid_scheddetails varchar (50) NOT NULL
		CONSTRAINT Subject_Schedule_SysID_SchedDetails_FK FOREIGN KEY REFERENCES ums.schedule_information_details(sysid_scheddetails) ON UPDATE NO ACTION
		CONSTRAINT Subject_Schedule_SysID_SchedDetails_UQ UNIQUE (sysid_scheddetails, week_id, time_id),
	week_id tinyint NOT NULL
		CONSTRAINT Subject_Schedule_Week_ID_FK FOREIGN KEY REFERENCES ums.week_day(week_id) ON UPDATE NO ACTION
		CONSTRAINT Subject_Schedule_Week_ID_UQ UNIQUE (week_id, sysid_scheddetails, time_id),
	time_id tinyint NOT NULL
		CONSTRAINT Subject_Schedule_Time_ID_FK FOREIGN KEY REFERENCES ums.week_time(time_id) ON UPDATE NO ACTION
		CONSTRAINT Subject_Schedule_Time_ID_UQ UNIQUE (time_id, week_id, sysid_scheddetails),
	
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Subject_Schedule_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Subject_Schedule_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Subject_Schedule_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the subject_schedule table 
CREATE INDEX Subject_Schedule_Schedule_ID_Index
	ON ums.subject_schedule (schedule_id DESC)
GO
------------------------------------------------------------------

--/*verifies that the trigger "Subject_Schedule_Trigger_Insert" already exist*/
--IF OBJECT_ID ('ums.Subject_Schedule_Trigger_Insert','TR') IS NOT NULL
--   DROP TRIGGER ums.Subject_Schedule_Trigger_Insert
--GO
--
--CREATE TRIGGER ums.Subject_Schedule_Trigger_Insert
--	ON  ums.subject_schedule
--	FOR INSERT
--	NOT FOR REPLICATION
--AS 
--
--	DECLARE @network_information varchar (MAX)
--	DECLARE @transaction_done varchar(MAX)
--
--	DECLARE @schedule_id bigint
--	DECLARE @sysid_scheddetails varchar (50)
--	DECLARE @week_id tinyint
--	DECLARE @time_id tinyint
--	DECLARE @created_by varchar (50)
--	
--	SELECT 
--		@schedule_id = i.schedule_id,
--		@sysid_scheddetails = i.sysid_scheddetails,
--		@week_id = i.week_id,
--		@time_id = i.time_id,
--		@created_by = i.created_by
--	FROM INSERTED AS i
--
--	SET @transaction_done = 'CREATED a new subject schedule ' + 
--							'[Schedule ID: ' + ISNULL(CONVERT(varchar, @schedule_id), '') +
--							'][Subject Title: ' + (SELECT ISNULL(si.subject_code, '') + ' - ' + ISNULL(si.descriptive_title, '')
--														FROM
--															schedule_information_details AS scd
--														INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
--														INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--														WHERE
--															scd.sysid_scheddetails = @sysid_scheddetails) +											  
--							'][Week Day and Time: ' + ISNULL((SELECT week_description FROM ums.week_day WHERE week_id = @week_id), '') +
--													' - ' + ISNULL((SELECT time_description FROM ums.week_time WHERE time_id = @time_id), '') +
--							']'
--
--	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
--	BEGIN
--		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
--	END
--			
--	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	
--
--GO
--/*-----------------------------------------------------------------*/

---- verifies that the trigger "Subject_Schedule_Trigger_Instead_Update" already exist
--IF OBJECT_ID ('ums.Subject_Schedule_Trigger_Instead_Update','TR') IS NOT NULL
--   DROP TRIGGER ums.Subject_Schedule_Trigger_Instead_Update
--GO
--
--CREATE TRIGGER ums.Subject_Schedule_Trigger_Instead_Update
--	ON  ums.subject_schedule
--	INSTEAD OF UPDATE
--	NOT FOR REPLICATION
--AS 
--
--	DECLARE @schedule_id bigint
--
--	DECLARE @edited_by varchar (50)
--
--	DECLARE subject_schedule_update_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
--		FOR SELECT i.schedule_id, i.edited_by
--				FROM INSERTED AS i
--
--	OPEN subject_schedule_update_cursor
--
--	FETCH NEXT FROM subject_schedule_update_cursor
--		INTO @schedule_id, @edited_by
--
--	WHILE @@FETCH_STATUS = 0
--	BEGIN
--
--		--used for the delete trigger
--		IF NOT @edited_by IS NULL
--		BEGIN
--
--			UPDATE ums.subject_schedule SET
--				edited_on = GETDATE(),
--				edited_by = @edited_by
--			WHERE
--				schedule_id = @schedule_id
--		END
--
--		FETCH NEXT FROM subject_schedule_update_cursor
--			INTO @schedule_id, @edited_by
--	END
--
--	CLOSE subject_schedule_update_cursor
--	DEALLOCATE subject_schedule_update_cursor	
--	
--GO
---------------------------------------------------------------------------


--/*verifies that the trigger "Subject_Schedule_Trigger_Instead_Delete" already exist*/
--IF OBJECT_ID ('ums.Subject_Schedule_Trigger_Instead_Delete','TR') IS NOT NULL
--   DROP TRIGGER ums.Subject_Schedule_Trigger_Instead_Delete
--GO
--
--CREATE TRIGGER ums.Subject_Schedule_Trigger_Instead_Delete
--	ON  ums.subject_schedule
--	INSTEAD OF DELETE
--	NOT FOR REPLICATION
--AS 
--
--	DECLARE @network_information varchar (MAX)
--	DECLARE @transaction_done varchar(MAX)
--
--	DECLARE @schedule_id bigint
--	DECLARE @sysid_scheddetails varchar (50)
--	DECLARE @week_id tinyint
--	DECLARE @time_id tinyint
--	DECLARE @deleted_by varchar (50)
--	
--	DECLARE subject_schedule_delete_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
--		FOR SELECT d.schedule_id, d.sysid_scheddetails, d.week_id, d.time_id, d.edited_by
--				FROM DELETED AS d
--
--	OPEN subject_schedule_delete_cursor
--
--	FETCH NEXT FROM subject_schedule_delete_cursor
--		INTO @schedule_id, @sysid_scheddetails, @week_id, @time_id, @deleted_by
--
--	WHILE @@FETCH_STATUS = 0
--	BEGIN
--
--		DELETE FROM ums.subject_schedule WHERE schedule_id = @schedule_id
-- 
--		SET @transaction_done = 'DELETED a subject schedule ' + 
--								'[Schedule ID: ' + ISNULL(CONVERT(varchar, @schedule_id), '') +
--								'][Subject Title: ' + (SELECT ISNULL(si.subject_code, '') + ' - ' + ISNULL(si.descriptive_title, '')
--														FROM
--															schedule_information_details AS scd
--														INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
--														INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--														WHERE
--															scd.sysid_scheddetails = @sysid_scheddetails) +											  
--								'][Week Day and Time: ' + ISNULL((SELECT week_description FROM ums.week_day WHERE week_id = @week_id), '') +
--														' - ' + ISNULL((SELECT time_description FROM ums.week_time WHERE time_id = @time_id), '') +
--								']'
--
--		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
--		BEGIN
--			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @deleted_by
--		END
--				
--		EXECUTE ums.InsertTransactionLog @deleted_by, @network_information, @transaction_done	
--
--		FETCH NEXT FROM subject_schedule_delete_cursor
--			INTO @schedule_id, @sysid_scheddetails, @week_id, @time_id, @deleted_by
--	END
--
--	CLOSE subject_schedule_delete_cursor
--	DEALLOCATE subject_schedule_delete_cursor
--	
--GO
--/*-----------------------------------------------------------------*/

-- verifies if the procedure "InsertSubjectSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertSubjectSchedule')
   DROP PROCEDURE ums.InsertSubjectSchedule
GO

CREATE PROCEDURE ums.InsertSubjectSchedule

	@sysid_scheddetails varchar (50) = '',
	@week_id tinyint = 0,
	@time_id tinyint = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@created_by) = 1) OR
		((ums.IsOfficeUserSystemUserInfo(@created_by) = 1) AND 
		(ums.IsUserSameDepartmentSubjectInfo((SELECT 
													sci.sysid_subject
												FROM
													ums.schedule_information AS sci
												INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_schedule = sci.sysid_schedule
												WHERE
													scd.sysid_scheddetails = @sysid_scheddetails), @created_by) = 1))) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.schedule_information AS sci
												INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_schedule = sci.sysid_schedule
												WHERE 
													scd.sysid_scheddetails = @sysid_scheddetails AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.schedule_information AS sci
												INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_schedule = sci.sysid_schedule
												WHERE 
													scd.sysid_scheddetails = @sysid_scheddetails AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0) AND
		(ums.IsIrregularModularSysIDScheduleInfo((SELECT
														sysid_schedule
													FROM
														ums.schedule_information_details
													WHERE
														sysid_scheddetails = @sysid_scheddetails)) = 0) AND
		(ums.IsExistWeekDayTimeSchedule(@sysid_scheddetails, @week_id, @time_id) = 0) AND
		(ums.IsScheduleDetailsLoadedTeacher(@sysid_scheddetails) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.subject_schedule
		(
			sysid_scheddetails,
			week_id,
			time_id,
			created_by
		)
		VALUES
		(
			@sysid_scheddetails,
			@week_id,
			@time_id,
			@created_by
		)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new subject schedule', 'Subject Schedule'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertSubjectSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteSubjectSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteSubjectSchedule')
   DROP PROCEDURE ums.DeleteSubjectSchedule
GO

CREATE PROCEDURE ums.DeleteSubjectSchedule

	@sysid_scheddetails varchar (50) = '',
	@schedule_id bigint = 0,

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@deleted_by) = 1) OR
		((ums.IsOfficeUserSystemUserInfo(@deleted_by) = 1) AND
		(ums.IsUserSameDepartmentSubjectInfo((SELECT 
													sci.sysid_subject
												FROM
													ums.schedule_information AS sci
												INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_schedule = sci.sysid_schedule
												WHERE
													scd.sysid_scheddetails = @sysid_scheddetails), @deleted_by) = 1))) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.schedule_information AS sci
												INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_schedule = sci.sysid_schedule
												WHERE 
													scd.sysid_scheddetails = @sysid_scheddetails AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.schedule_information AS sci
												INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_schedule = sci.sysid_schedule
												WHERE 
													scd.sysid_scheddetails = @sysid_scheddetails AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0) AND
		(ums.IsScheduleDetailsLoadedTeacher(@sysid_scheddetails) = 0)
		
	BEGIN

		IF EXISTS (SELECT schedule_id FROM ums.subject_schedule WHERE schedule_id = @schedule_id)			
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.subject_schedule SET
				edited_by = @deleted_by
			WHERE
				schedule_id = @schedule_id

			DELETE FROM ums.subject_schedule WHERE schedule_id = @schedule_id

		END		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Deleted a subject schedule', 'Subject Schedule'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteSubjectSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByClassroomCodeSubjectSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByClassroomCodeSubjectSchedule')
   DROP PROCEDURE ums.SelectByClassroomCodeSubjectSchedule
GO

CREATE PROCEDURE ums.SelectByClassroomCodeSubjectSchedule

	@date_start datetime,
	@date_end datetime,
	@sysid_classroom varchar (50) = '',
	@sysid_scheddetails varchar (50) = '',

	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1)  OR
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		IF (NOT ISNULL(@sysid_classroom, '') = '')
		BEGIN
			
			SELECT				--YEARLY SCHEDULE WITH CLASSROOM
				ss.schedule_id AS schedule_id,
				ss.sysid_scheddetails AS sysid_scheddetails,
				ss.week_id AS week_id,
				ss.time_id AS time_id,
				si.subject_code AS subject_code,
				ums.IsReadOnlySubjectSchedule(ss.schedule_id, @sysid_scheddetails) AS is_read_only
			FROM
				ums.subject_schedule AS ss
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = ss.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(scd.is_marked_deleted = 0) AND
				(scd.sysid_classroom = @sysid_classroom) AND
				(scd.is_classroom = 1)
			UNION ALL
			SELECT				--SEMESTRAL SCHEDULE WITH CLASSROOM
				ss.schedule_id AS schedule_id,
				ss.sysid_scheddetails AS sysid_scheddetails,
				ss.week_id AS week_id,
				ss.time_id AS time_id,
				si.subject_code AS subject_code,
				ums.IsReadOnlySubjectSchedule(ss.schedule_id, @sysid_scheddetails) AS is_read_only
			FROM
				ums.subject_schedule AS ss
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = ss.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
				(scd.is_marked_deleted = 0) AND
				(scd.sysid_classroom = @sysid_classroom) AND
				(scd.is_classroom = 1)
			ORDER BY
				week_id ASC

		END
		ELSE
		BEGIN
		
			SELECT				--YEARLY SCHEDULE WITHOUT CLASSROOM AND IS A FIELD ROOM
				ss.schedule_id AS schedule_id,
				ss.sysid_scheddetails AS sysid_scheddetails,
				ss.week_id AS week_id,
				ss.time_id AS time_id,
				si.subject_code AS subject_code,
				'false' AS is_read_only
			FROM
				ums.subject_schedule AS ss
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = ss.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(scd.is_marked_deleted = 0) AND
				(scd.sysid_scheddetails = @sysid_scheddetails) AND
				(scd.is_classroom = 0)
			UNION ALL
			SELECT				--SEMESTRAL SCHEDULE WITHOUT CLASSROOM AND IS A FIELD ROOM
				ss.schedule_id AS schedule_id,
				ss.sysid_scheddetails AS sysid_scheddetails,
				ss.week_id AS week_id,
				ss.time_id AS time_id,
				si.subject_code AS subject_code,
				'false' AS is_read_only
			FROM
				ums.subject_schedule AS ss
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = ss.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
				(scd.is_marked_deleted = 0) AND
				(scd.sysid_scheddetails = @sysid_scheddetails) AND
				(scd.is_classroom = 0)
			ORDER BY
				week_id ASC

		END
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a subject schedule', 'Subject Schedule'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByClassroomCodeSubjectSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectBySysIDScheduleDetailsListSubjectSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDScheduleDetailsListSubjectSchedule')
   DROP PROCEDURE ums.SelectBySysIDScheduleDetailsListSubjectSchedule
GO

CREATE PROCEDURE ums.SelectBySysIDScheduleDetailsListSubjectSchedule

	@sysid_scheddetails_list nvarchar (MAX) = '',

	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsStudentDataControllerSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT
			ss.sysid_scheddetails AS sysid_scheddetails, 
			ss.week_id AS week_id,
			ss.time_id AS time_id
		FROM 
			ums.subject_schedule AS ss
		INNER JOIN ums.IterateListToTable (@sysid_scheddetails_list, ',') AS ssl_list ON ssl_list.var_str = ss.sysid_scheddetails
		ORDER BY
			ss.week_id ASC		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a subject schedule', 'Subject Schedule'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySysIDScheduleDetailsListSubjectSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsReadOnlySubjectSchedule" function already exist
IF OBJECT_ID (N'ums.IsReadOnlySubjectSchedule') IS NOT NULL
   DROP FUNCTION ums.IsReadOnlySubjectSchedule
GO

CREATE FUNCTION ums.IsReadOnlySubjectSchedule
(	
	@schedule_id bigint = 0,
	@sysid_scheddetails varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	
	SET @result = 0

	IF EXISTS (SELECT 
					ss.schedule_id AS schedule_id 
				FROM 
					ums.subject_schedule AS ss
				INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = ss.sysid_scheddetails
				WHERE 
					(ss.schedule_id = @schedule_id) AND
					(NOT scd.sysid_scheddetails = @sysid_scheddetails) AND
					(scd.is_marked_deleted = 0))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result

END
GO
------------------------------------------------------

-- verifies if the "IsExistWeekDayTimeSchedule" function already exist
IF OBJECT_ID (N'ums.IsExistWeekDayTimeSchedule') IS NOT NULL
   DROP FUNCTION ums.IsExistWeekDayTimeSchedule
GO

CREATE FUNCTION ums.IsExistWeekDayTimeSchedule
(	
	@sysid_scheddetails varchar (50) = '',
	@week_id tinyint = 0,
	@time_id tinyint = 0
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @sysid_classroom varchar (50)

	SET @result = 0

	SELECT 
		@year_id = sci.year_id, 
		@sysid_semester = sci.sysid_semester,		
		@sysid_classroom = scd.sysid_classroom
	FROM 
		ums.schedule_information_details AS scd
	INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
	WHERE 
		scd.sysid_scheddetails = @sysid_scheddetails

	--@sysid_classroom should NOT be checked as NULL so that schedule details with FIELD ROOM with DAY and TIME could be recorded

	IF (NOT @year_id IS NULL AND NOT @year_id = '') AND
		EXISTS (SELECT 
					scd.sysid_scheddetails AS sysid_scheddetails 
				FROM 
					ums.schedule_information_details AS scd
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
				INNER JOIN ums.subject_schedule AS ss ON ss.sysid_scheddetails = scd.sysid_scheddetails
				INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
				WHERE 
					(NOT scd.sysid_scheddetails = @sysid_scheddetails) AND	--only the schedule_information_details must be checked if it is 
					(scd.is_marked_deleted = 0) AND							--marked deleted because the subject_schedule is directly related to it.
					(sci.year_id = @year_id) AND 
					(ss.week_id = @week_id) AND 
					(ss.time_id = @time_id) AND
					(ci.sysid_classroom = @sysid_classroom))
	BEGIN
		SET @result = 1
	END
	ELSE IF (NOT @sysid_semester IS NULL AND NOT @sysid_semester = '') AND
		EXISTS (SELECT 
					scd.sysid_scheddetails AS sysid_scheddetails
				FROM 
					ums.schedule_information_details AS scd
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
				INNER JOIN ums.subject_schedule AS ss ON ss.sysid_scheddetails = scd.sysid_scheddetails
				INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
				WHERE 
					(NOT scd.sysid_scheddetails = @sysid_scheddetails) AND	--only the schedule_information_details must be checked if it is 
					(scd.is_marked_deleted = 0) AND							--marked deleted because the subject_schedule is directly related to it.
					(sci.sysid_semester = @sysid_semester) AND 
					(ss.week_id = @week_id) AND 
					(ss.time_id = @time_id) AND
					(ci.sysid_classroom = @sysid_classroom))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result

END
GO
------------------------------------------------------

-- ################################################TABLE "subject_schedule" OBJECTS######################################################




-- ################################################TABLE "auxiliary_service_information" OBJECTS######################################################
-- verifies if the auxiliary_service_information table exists
IF OBJECT_ID('ums.auxiliary_service_information', 'U') IS NOT NULL
	DROP TABLE ums.auxiliary_service_information
GO

CREATE TABLE ums.auxiliary_service_information 			
(
	sysid_auxservice varchar (50) NOT NULL 
		CONSTRAINT Auxiliary_Service_Information_SysID_AuxService_PK PRIMARY KEY (sysid_auxservice)
		CONSTRAINT Auxiliary_Service_Information_SysID_AuxService_CK CHECK (sysid_auxservice LIKE 'SYSSRV%'),	
	course_group_id varchar (50) NOT NULL
		CONSTRAINT Auxiliary_Service_Information_Course_Group_ID_FK FOREIGN KEY REFERENCES ums.course_group(course_group_id) ON UPDATE NO ACTION,
	department_id varchar (50) NOT NULL
		CONSTRAINT Auxiliary_Service_Information_Department_ID_FK FOREIGN KEY REFERENCES ums.department_information(department_id) ON UPDATE NO ACTION
		CONSTRAINT Auxiliary_Service_Information_Department_ID_UQ UNIQUE (department_id, service_code, descriptive_title),
	service_code varchar (50) NOT NULL
		CONSTRAINT Auxiliary_Service_Information_Service_Code_UQ UNIQUE (service_code, department_id, descriptive_title),
	descriptive_title varchar (100) NOT NULL
		CONSTRAINT Auxiliary_Service_Information_Descriptive_Title_UQ UNIQUE (descriptive_title, service_code, department_id),

	lecture_units tinyint NOT NULL DEFAULT (0),
	lab_units tinyint NOT NULL DEFAULT (0),
	no_hours varchar (12) NOT NULL DEFAULT ('00:00') 
		CONSTRAINT Auxiliary_Service_Information_No_Hours_CK CHECK (no_hours LIKE '[0-9][0-9]:[0-5][0-9]'),
	other_information varchar (MAX) NULL,

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Auxiliary_Service_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Auxiliary_Service_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Auxiliary_Service_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the auxiliary_service_information table 
CREATE INDEX Auxiliary_Service_Information_SysID_Subject_Index
	ON ums.auxiliary_service_information (sysid_auxservice ASC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Auxiliary_Service_Information_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.Auxiliary_Service_Information_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Auxiliary_Service_Information_Trigger_Insert
GO

CREATE TRIGGER ums.Auxiliary_Service_Information_Trigger_Insert
	ON  ums.auxiliary_service_information
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_auxservice varchar (50)
	DECLARE @course_group_id varchar (50)
	DECLARE @department_id varchar (50)
	DECLARE @service_code varchar (50)
	DECLARE @descriptive_title varchar (100)
	DECLARE @lecture_units tinyint
	DECLARE @lab_units tinyint
	DECLARE @no_hours varchar (12)
	DECLARE @other_information varchar (MAX)
	DECLARE @created_by varchar (50)
	
	SELECT 
		@sysid_auxservice = i.sysid_auxservice,
		@course_group_id = i.course_group_id,
		@department_id = i.department_id,
		@service_code = i.service_code,
		@descriptive_title = i.descriptive_title,
		@lecture_units = i.lecture_units,
		@lab_units = i.lab_units,
		@no_hours = i.no_hours,
		@other_information = i.other_information,
		@created_by = i.created_by
	FROM INSERTED AS i

	SET @transaction_done = 'CREATED an auxiliary service information ' + 
							'[System ID: ' + ISNULL(@sysid_auxservice, '') +							
							'][Course Group: ' + ISNULL((SELECT group_description FROM ums.course_group WHERE course_group_id = @course_group_id), '') +
							'][Department: ' + ISNULL((SELECT department_name FROM ums.department_information WHERE department_id = @department_id), '') +
							'][Service Code: ' + ISNULL(@service_code, '') +
							'][Descriptive Title: ' + ISNULL(@descriptive_title, '') +
							'][Lecture Units: ' + ISNULL(CONVERT(varchar, @lecture_units), '') +
							'][Lab Units: ' + ISNULL(CONVERT(varchar, @lab_units), '') +
							'][Number of Hours: ' + ISNULL(@no_hours, '') +
							'][Other Information: ' + ISNULL(@other_information, '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Auxiliary_Service_Information_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Auxiliary_Service_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Auxiliary_Service_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Auxiliary_Service_Information_Trigger_Instead_Update
	ON  ums.auxiliary_service_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_auxservice varchar (50)
	DECLARE @course_group_id varchar (50)
	DECLARE @department_id varchar (50)
	DECLARE @service_code varchar (50)
	DECLARE @descriptive_title varchar (100)
	DECLARE @lecture_units tinyint
	DECLARE @lab_units tinyint
	DECLARE @no_hours varchar (12)
	DECLARE @other_information varchar (MAX)
	DECLARE @edited_by varchar (50)

	DECLARE @department_id_b varchar (50)
	DECLARE @service_code_b varchar (50)
	DECLARE @descriptive_title_b varchar (100)
	DECLARE @lecture_units_b tinyint
	DECLARE @lab_units_b tinyint
	DECLARE @no_hours_b varchar (12)
	DECLARE @other_information_b varchar (MAX)

	DECLARE @has_update bit
	
	SELECT 
		@sysid_auxservice = i.sysid_auxservice,
		@course_group_id = i.course_group_id,
		@department_id = i.department_id,
		@service_code = i.service_code,
		@descriptive_title = i.descriptive_title,
		@lecture_units = i.lecture_units,
		@lab_units = i.lab_units,
		@no_hours = i.no_hours,
		@other_information = i.other_information,
		@edited_by = i.edited_by
	FROM INSERTED AS i

	SELECT
		@department_id_b = department_id,
		@service_code_b = service_code,
		@descriptive_title_b = descriptive_title,
		@lecture_units_b = lecture_units,
		@lab_units_b = lab_units,
		@no_hours_b = no_hours,
		@other_information_b = other_information
	FROM
		ums.auxiliary_service_information
	WHERE
		sysid_auxservice = @sysid_auxservice

	SET @transaction_done = ''
	SET @has_update = 0

	IF NOT ISNULL(@department_id, '') = ISNULL(@department_id_b, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Department Before: ' + ISNULL((SELECT department_name FROM ums.department_information WHERE department_id = @department_id_b), '') + ']' +
													'[Department After: ' + ISNULL((SELECT department_name FROM ums.department_information WHERE department_id = @department_id), '') + ']'
		SET @has_update = 1
	END

	IF NOT ISNULL(@service_code COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@service_code_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Service Code Before: ' + ISNULL(@service_code_b, '') + ']' +
													'[Service Code After: ' + ISNULL(@service_code, '') + ']'
		SET @has_update = 1
	END
	ELSE
	BEGIN
		SET @transaction_done = @transaction_done + '[Service Code: ' + ISNULL(@service_code, '') + ']'
	END

	IF NOT ISNULL(@descriptive_title COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@descriptive_title_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Descriptive Title Before: ' + ISNULL(@descriptive_title_b, '') + ']' +
													'[Descriptive Title After: ' + ISNULL(@descriptive_title, '') + ']'
		SET @has_update = 1
	END
	ELSE
	BEGIN
		SET @transaction_done = @transaction_done + '[Descriptive Title: ' + ISNULL(@descriptive_title, '') + ']'
	END

	IF NOT ISNULL(CONVERT(varchar, @lecture_units), '') = ISNULL(CONVERT(varchar, @lecture_units_b), '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Lecture Units Before: ' + ISNULL(CONVERT(varchar, @lecture_units_b), '') + ']' +
													'[Lecture Units After: ' + ISNULL(CONVERT(varchar, @lecture_units), '') + ']'
		SET @has_update = 1
	END

	IF NOT ISNULL(CONVERT(varchar, @lab_units), '') = ISNULL(CONVERT(varchar, @lab_units_b), '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Lab Units Before: ' + ISNULL(CONVERT(varchar, @lab_units_b), '') + ']' +
													'[Lab Units After: ' + ISNULL(CONVERT(varchar, @lab_units), '') + ']'
		SET @has_update = 1
	END

	IF NOT ISNULL(@no_hours, '') = ISNULL(@no_hours_b, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Number of Hours Before: ' + ISNULL(@no_hours_b, '') + ']' +
													'[Number of Hours After: ' + ISNULL(@no_hours, '') + ']'
		SET @has_update = 1
	END

	IF NOT ISNULL(@other_information COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@other_information_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Other Information Before: ' + ISNULL(@other_information_b, '') + ']' +
													'[Other Information After: ' + ISNULL(@other_information, '') + ']'
		SET @has_update = 1
	END

	IF @has_update = 1
	BEGIN

		UPDATE ums.auxiliary_service_information SET
			department_id = @department_id,
			service_code = @service_code,
			descriptive_title = @descriptive_title,
			lecture_units = @lecture_units,
			lab_units = @lab_units,
			no_hours = @no_hours,
			other_information = @other_information,
			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			sysid_auxservice = @sysid_auxservice

		SET @transaction_done = 'UPDATED an auxiliary service information ' + 
								'[System ID: ' + ISNULL(@sysid_auxservice, '') + 
								'][Course Group: ' + ISNULL((SELECT group_description FROM ums.course_group WHERE course_group_id = @course_group_id), '') +
								']' + @transaction_done

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
		END
				
		EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done

	END		

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Auxiliary_Service_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Auxiliary_Service_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Auxiliary_Service_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Auxiliary_Service_Information_Trigger_Instead_Delete
	ON  ums.auxiliary_service_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete an auxiliary service information', 'Auxiliary Service Information'
	
GO
-------------------------------------------------------------------------


-- verifies if the procedure "InsertAuxiliaryServiceInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertAuxiliaryServiceInformation')
   DROP PROCEDURE ums.InsertAuxiliaryServiceInformation
GO

CREATE PROCEDURE ums.InsertAuxiliaryServiceInformation

	@sysid_auxservice varchar (50) = '',
	@course_group_id varchar (50) = '',
	@department_id varchar (50) = '',
	@service_code varchar (50) = '',
	@descriptive_title varchar (100) = '',
	@lecture_units tinyint = 0,
	@lab_units tinyint = 0,
	@no_hours varchar (12) = '',
	@other_information varchar (MAX) = '',

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@created_by) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@created_by) = 1)) AND
		(ums.IsExistCodeDescriptionAuxiliaryServiceInfo(@sysid_auxservice, @service_code, @descriptive_title) = 0)
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.auxiliary_service_information
		(
			sysid_auxservice,
			course_group_id,
			department_id,
			service_code,
			descriptive_title,
			lecture_units,
			lab_units,
			no_hours,
			other_information,
			created_by
		)
		VALUES
		(
			@sysid_auxservice,
			@course_group_id,
			@department_id,
			@service_code,
			@descriptive_title,
			@lecture_units,
			@lab_units,
			@no_hours,
			@other_information,
			@created_by
		)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert an auxiliary service information', 'Service Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertAuxiliaryServiceInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateAuxiliaryServiceInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateAuxiliaryServiceInformation')
   DROP PROCEDURE ums.UpdateAuxiliaryServiceInformation
GO

CREATE PROCEDURE ums.UpdateAuxiliaryServiceInformation

	@sysid_auxservice varchar (50) = '',
	@department_id varchar (50) = '',
	@service_code varchar (50) = '',
	@descriptive_title varchar (100) = '',
	@lecture_units tinyint = 0,
	@lab_units tinyint = 0,
	@no_hours varchar (12) = '',
	@other_information varchar (MAX) = '',

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@edited_by) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@edited_by) = 1)) AND
		(ums.IsExistCodeDescriptionAuxiliaryServiceInfo(@sysid_auxservice, @service_code, @descriptive_title) = 0)
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.auxiliary_service_information SET
			department_id = @department_id,
			service_code = @service_code,
			descriptive_title = @descriptive_title,
			lecture_units = @lecture_units,
			lab_units = @lab_units,
			no_hours = @no_hours,
			other_information = @other_information,
			edited_by = @edited_by
		WHERE
			sysid_auxservice = @sysid_auxservice
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update an auxiliary service information', 'Service Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateAuxiliaryServiceInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectAuxiliaryServiceInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectAuxiliaryServiceInformation')
   DROP PROCEDURE ums.SelectAuxiliaryServiceInformation
GO

CREATE PROCEDURE ums.SelectAuxiliaryServiceInformation

	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT 
			asi.sysid_auxservice AS sysid_auxservice,
			asi.course_group_id AS course_group_id,
			asi.department_id AS department_id,
			asi.service_code AS service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units,
			asi.lab_units AS lab_units,
			asi.no_hours AS no_hours,
			asi.other_information AS other_information,
			cg.group_no AS group_no,
			cg.is_semestral AS is_semestral,
			di.department_name AS department_name
		FROM
			ums.auxiliary_service_information AS asi
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		ORDER BY
			asi.service_code ASC
		
	END
	ELSE
	BEGIN		
		EXECUTE ums.ShowErrorMsg 'Query an auxiliary service information', 'Service Information'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectAuxiliaryServiceInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByServiceCodeTitleAuxiliaryServiceInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByServiceCodeTitleAuxiliaryServiceInformation')
   DROP PROCEDURE ums.SelectByServiceCodeTitleAuxiliaryServiceInformation
GO

CREATE PROCEDURE ums.SelectByServiceCodeTitleAuxiliaryServiceInformation

	@query_string varchar (100) = '',
	@system_user_id varchar (50) = ''
		
AS

	SELECT @query_string = '%' + RTRIM(LTRIM(@query_string)) + '%'

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT 
			asi.sysid_auxservice AS sysid_auxservice,
			asi.course_group_id AS course_group_id,
			asi.department_id AS department_id,
			asi.service_code AS service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units,
			asi.lab_units AS lab_units,
			asi.no_hours AS no_hours,
			asi.other_information AS other_information,
			cg.group_no AS group_no,
			cg.is_semestral AS is_semestral,
			di.department_name AS department_name
		FROM
			ums.auxiliary_service_information AS asi
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		WHERE
			(asi.service_code LIKE @query_string) OR (asi.descriptive_title LIKE @query_string) OR
			(di.department_name LIKE @query_string)
		ORDER BY
			asi.service_code ASC
		
	END
	ELSE
	BEGIN		
		EXECUTE ums.ShowErrorMsg 'Query an auxiliary service information', 'Service Information'
	END		
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByServiceCodeTitleAuxiliaryServiceInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountAuxiliaryServiceInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountAuxiliaryServiceInformation')
   DROP PROCEDURE ums.GetCountAuxiliaryServiceInformation
GO

CREATE PROCEDURE ums.GetCountAuxiliaryServiceInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_auxservice) FROM ums.auxiliary_service_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an auxiliary service information', 'Service Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountAuxiliaryServiceInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistSysIDAuxiliaryServiceInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistSysIDAuxiliaryServiceInformation')
   DROP PROCEDURE ums.IsExistSysIDAuxiliaryServiceInformation
GO

CREATE PROCEDURE ums.IsExistSysIDAuxiliaryServiceInformation

	@sysid_auxservice varchar (50) = '',
	@system_user_id varchar (50) = ''
		
AS
	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN
	
		SELECT ums.IsExistSysIDAuxiliaryServiceInfo(@sysid_auxservice)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an auxiliary service information', 'Service Information'
	END
	
GO
------------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistSysIDAuxiliaryServiceInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistCodeDescriptionAuxiliaryServiceInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistCodeDescriptionAuxiliaryServiceInformation')
   DROP PROCEDURE ums.IsExistCodeDescriptionAuxiliaryServiceInformation
GO

CREATE PROCEDURE ums.IsExistCodeDescriptionAuxiliaryServiceInformation

	@sysid_auxservice varchar (50) = '',
	@service_code varchar (50) = '',
	@descriptive_title varchar (100) = '',
	@system_user_id varchar (50) = ''
		
AS
	
	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN
		
		SELECT ums.IsExistCodeDescriptionAuxiliaryServiceInfo(@sysid_auxservice, @service_code, @descriptive_title)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an auxiliary service information', 'Service Information'
	END
	
GO
------------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistCodeDescriptionAuxiliaryServiceInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistSysIDAuxiliaryServiceInfo" function already exist
IF OBJECT_ID (N'ums.IsExistSysIDAuxiliaryServiceInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistSysIDAuxiliaryServiceInfo
GO

CREATE FUNCTION ums.IsExistSysIDAuxiliaryServiceInfo
(	
	@sysid_auxservice varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT sysid_auxservice FROM ums.auxiliary_service_information WHERE sysid_auxservice = @sysid_auxservice)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsExistCodeDescriptionAuxiliaryServiceInfo" function already exist
IF OBJECT_ID (N'ums.IsExistCodeDescriptionAuxiliaryServiceInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistCodeDescriptionAuxiliaryServiceInfo
GO

CREATE FUNCTION ums.IsExistCodeDescriptionAuxiliaryServiceInfo
(	
	@sysid_auxservice varchar (50) = '',
	@service_code varchar (50) = '',
	@descriptive_title varchar (100) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT sysid_auxservice FROM ums.auxiliary_service_information WHERE NOT sysid_auxservice = @sysid_auxservice AND 
							(((REPLACE(service_code, ' ', '')) LIKE REPLACE(@service_code, ' ', '')) AND 
							((REPLACE(descriptive_title, ' ', '')) LIKE REPLACE(@descriptive_title, ' ', ''))))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsUserSameDepartmentAuxiliaryServiceInfo" function already exist
IF OBJECT_ID (N'ums.IsUserSameDepartmentAuxiliaryServiceInfo') IS NOT NULL
   DROP FUNCTION ums.IsUserSameDepartmentAuxiliaryServiceInfo
GO

CREATE FUNCTION ums.IsUserSameDepartmentAuxiliaryServiceInfo
(	
	@sysid_auxservice varchar (50) = '',
	@system_user_id varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT rights_granted_id FROM ums.access_rights_granted WHERE system_user_id = @system_user_id AND 
						department_id = (SELECT department_id FROM ums.auxiliary_service_information WHERE sysid_auxservice = @sysid_auxservice))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------


-- ################################################END TABLE "auxiliary_service_information" OBJECTS######################################################




-- ################################################TABLE "auxiliary_service_schedule" OBJECTS######################################################
-- verifies if the auxiliary_service_schedule table exists
IF OBJECT_ID('ums.auxiliary_service_schedule', 'U') IS NOT NULL
	DROP TABLE ums.auxiliary_service_schedule
GO

CREATE TABLE ums.auxiliary_service_schedule 			
(
	sysid_auxserviceschedule varchar (50) NOT NULL
		CONSTRAINT Auxiliary_Service_Schedule_SysID_AuxServiceSchedule_PK PRIMARY KEY (sysid_auxserviceschedule)
		CONSTRAINT Auxiliary_Service_Schedule_SysID_AuxServiceSchedule_CK CHECK (sysid_auxserviceschedule LIKE 'SYSASC%'),
	sysid_auxservice varchar (50) NOT NULL 
		CONSTRAINT Auxiliary_Service_Schedule_SysID_AuxService_FK FOREIGN KEY REFERENCES ums.auxiliary_service_information(sysid_auxservice) ON UPDATE NO ACTION,
	year_id varchar (50) NULL
		CONSTRAINT Auxiliary_Service_Schedule_Year_ID_FK FOREIGN KEY REFERENCES ums.school_year(year_id) ON UPDATE NO ACTION,
	sysid_semester varchar (50) NULL 
		CONSTRAINT Auxiliary_Service_Schedule_SysID_Semester_FK FOREIGN KEY REFERENCES ums.semester_information(sysid_semester) ON UPDATE NO ACTION,

	is_marked_deleted bit NOT NULL DEFAULT (0),

	is_fixed_amount bit NOT NULL DEFAULT (0),
	amount decimal (12, 2) NULL,

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Auxiliary_Service_Schedule_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Auxiliary_Service_Schedule_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Auxiliary_Service_Schedule_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the auxiliary_service_schedule table 
CREATE INDEX Auxiliary_Service_Schedule_SysID_AuxServiceSchedule_Index
	ON ums.auxiliary_service_schedule (sysid_auxserviceschedule DESC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Auxiliary_Service_Schedule_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Auxiliary_Service_Schedule_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Auxiliary_Service_Schedule_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Auxiliary_Service_Schedule_Trigger_Instead_Update
	ON  ums.auxiliary_service_schedule
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar (MAX)

	DECLARE @sysid_auxserviceschedule varchar (50)
	DECLARE @sysid_auxservice varchar (50)
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @is_fixed_amount bit
	DECLARE @amount decimal (12, 2)
	DECLARE @is_semestral bit
	DECLARE @edited_by varchar (50)

	DECLARE @is_fixed_amount_b bit
	DECLARE @amount_b decimal (12, 2)

	DECLARE @year_semester_description varchar (100)
	DECLARE @fixed_amount varchar (50)
	DECLARE @fixed_amount_b varchar (50)

	DECLARE @has_update bit
	
	SELECT 
		@sysid_auxserviceschedule = i.sysid_auxserviceschedule,
		@sysid_auxservice = i.sysid_auxservice,
		@year_id = i.year_id,
		@sysid_semester = i.sysid_semester,
		@is_fixed_amount = i.is_fixed_amount,
		@amount = i.amount,
		@edited_by = i.edited_by,
		@is_semestral = cg.is_semestral
	FROM INSERTED AS i
	INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = i.sysid_auxservice
	INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id

	SELECT
		@is_fixed_amount_b = is_fixed_amount,
		@amount_b = amount
	FROM
		ums.auxiliary_service_schedule
	WHERE
		sysid_auxserviceschedule = @sysid_auxserviceschedule

	SET @transaction_done = ''
	SET @has_update = 0	

	IF NOT @is_fixed_amount = @is_fixed_amount_b
	BEGIN

		IF @is_fixed_amount = 1
		BEGIN
			SET @fixed_amount = 'YES with an amount ' + ISNULL(CONVERT(varchar, CONVERT(money, @amount), 1), '0.00')
		END
		ELSE
		BEGIN
			SET @fixed_amount = 'NO'
		END

		IF @is_fixed_amount_b = 1
		BEGIN
			SET @fixed_amount_b = 'YES with an amount ' + ISNULL(CONVERT(varchar, CONVERT(money, @amount_b), 1), '0.00')
		END
		ELSE
		BEGIN
			SET @fixed_amount_b = 'NO'
		END

		SET @transaction_done = @transaction_done + '[Is Fixed Amount Before: ' + ISNULL(@fixed_amount_b, '') + ']' +
													'[Is Fixed Amount After: ' + ISNULL(@fixed_amount, '') + ']'
		SET @has_update = 1

	END
	
	IF @has_update = 1
	BEGIN

		UPDATE ums.auxiliary_service_schedule SET
			is_fixed_amount = @is_fixed_amount,
			amount = @amount,
			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			sysid_auxserviceschedule = @sysid_auxserviceschedule

		SET @year_semester_description = ''

		IF (@is_semestral = 0) AND (NOT @year_id IS NULL)
		BEGIN
			SELECT @year_semester_description = year_description FROM ums.school_year WHERE year_id = @year_id
		END
		ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL)
		BEGIN
			SELECT @year_semester_description = sy.year_description + ' - ' + ss.semester_description
			FROM 
				ums.semester_information AS si
			INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
			INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
			WHERE 
				si.sysid_semester = @sysid_semester
		END

		SET @transaction_done = 'UPDATED an auxiliary service schedule ' + 
								'[Schedule ID: ' + ISNULL(@sysid_auxserviceschedule, '') +
								'][Descriptive Title: ' + (SELECT ISNULL(service_code, '') + ' - ' + ISNULL(descriptive_title, '') FROM ums.auxiliary_service_information WHERE sysid_auxservice = @sysid_auxservice) + 												  
								'][School Year / Semester: ' + ISNULL(@year_semester_description, '') +
								@transaction_done
								

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
		END
				
		EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done	

	END
	ELSE IF NOT @edited_by IS NULL
	BEGIN

		--used for the delete trigger
		UPDATE ums.auxiliary_service_schedule SET
			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			sysid_auxserviceschedule = @sysid_auxserviceschedule
	END

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Auxiliary_Service_Schedule_Trigger_Instead_Delete" already exist*/
IF OBJECT_ID ('ums.Auxiliary_Service_Schedule_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Auxiliary_Service_Schedule_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Auxiliary_Service_Schedule_Trigger_Instead_Delete
	ON  ums.auxiliary_service_schedule
	INSTEAD OF DELETE 
	NOT FOR REPLICATION
AS 

	DECLARE @sysid_auxserviceschedule varchar (50)
	DECLARE @deleted_by varchar (50)

	SELECT 
		@sysid_auxserviceschedule = d.sysid_auxserviceschedule,
		@deleted_by = d.edited_by
	FROM DELETED AS d

	UPDATE ums.auxiliary_service_details SET edited_by = @deleted_by WHERE sysid_auxserviceschedule = @sysid_auxserviceschedule
	DELETE FROM ums.auxiliary_service_details WHERE sysid_auxserviceschedule = @sysid_auxserviceschedule

	UPDATE ums.auxiliary_service_schedule SET is_marked_deleted = 1, edited_by = @deleted_by WHERE sysid_auxserviceschedule = @sysid_auxserviceschedule		

GO
/*-----------------------------------------------------------------*/

-- verifies if the procedure "InsertAuxiliaryServiceSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertAuxiliaryServiceSchedule')
   DROP PROCEDURE ums.InsertAuxiliaryServiceSchedule
GO

CREATE PROCEDURE ums.InsertAuxiliaryServiceSchedule

	@sysid_auxserviceschedule varchar (50) = '',
	@sysid_auxservice varchar (50) = '',
	@year_id varchar (50) = '',
	@sysid_semester varchar (50) = '',
	@is_fixed_amount bit = 0,
	@amount decimal (12, 2) = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@created_by) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@created_by) = 1)) AND 
			((ums.IsRecordLockByYearSemesterID(@year_id) = 0) AND (ums.IsRecordLockByYearSemesterID(@sysid_semester) = 0))
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		DECLARE @is_semestral bit

		SET @is_semestral = 0

		SELECT 
			@is_semestral = cg.is_semestral 
		FROM 
			ums.auxiliary_service_information AS asi
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		WHERE
			asi.sysid_auxservice = @sysid_auxservice

		IF (@is_semestral = 0) AND (NOT @year_id IS NULL AND NOT @year_id = '')
		BEGIN

			INSERT INTO ums.auxiliary_service_schedule
			(
				sysid_auxserviceschedule,
				sysid_auxservice,
				year_id,
				sysid_semester,
				is_fixed_amount,
				amount,
				created_by
			)
			VALUES
			(
				@sysid_auxserviceschedule,
				@sysid_auxservice,
				@year_id,
				NULL,
				@is_fixed_amount,
				@amount,
				@created_by
			)	

		END
		ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL AND NOT @sysid_semester = '')	
		BEGIN

			INSERT INTO ums.auxiliary_service_schedule
			(
				sysid_auxserviceschedule,
				sysid_auxservice,
				year_id,
				sysid_semester,
				is_fixed_amount,
				amount,
				created_by
			)
			VALUES
			(
				@sysid_auxserviceschedule,
				@sysid_auxservice,
				NULL,
				@sysid_semester,
				@is_fixed_amount,
				@amount,
				@created_by
			)

		END	
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new auxiliary service schedule', 'Auxiliary Service Schedule'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertAuxiliaryServiceSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateAuxiliaryServiceSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateAuxiliaryServiceSchedule')
   DROP PROCEDURE ums.UpdateAuxiliaryServiceSchedule
GO

CREATE PROCEDURE ums.UpdateAuxiliaryServiceSchedule

	@sysid_auxserviceschedule varchar (50) = '',
	@is_fixed_amount bit = 0,
	@amount decimal (12, 2) = 0,

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR 
		(ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@edited_by) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@edited_by) = 1)) AND
			(ums.IsRecordLockByYearSemesterID((SELECT 
													ass.year_id AS year_semester_id
												FROM 
													ums.auxiliary_service_schedule AS ass 
												WHERE 
													ass.sysid_auxserviceschedule = @sysid_auxserviceschedule AND
													(NOT ass.year_id IS NULL AND NOT ass.year_id = '')
												UNION
												SELECT 
													ass.sysid_semester AS year_semester_id
												FROM 
													ums.auxiliary_service_schedule AS ass 
												WHERE 
													ass.sysid_auxserviceschedule = @sysid_auxserviceschedule AND
													(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = ''))) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.auxiliary_service_schedule SET			
			is_fixed_amount = @is_fixed_amount,
			amount = @amount,

			edited_by = @edited_by
		WHERE
			sysid_auxserviceschedule = @sysid_auxserviceschedule	
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update an auxiliary service schedule', 'Auxiliary Service Schedule'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateAuxiliaryServiceSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteAuxiliaryServiceSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteAuxiliaryServiceSchedule')
   DROP PROCEDURE ums.DeleteAuxiliaryServiceSchedule
GO

CREATE PROCEDURE ums.DeleteAuxiliaryServiceSchedule

	@sysid_auxserviceschedule varchar (50) = '',
	
	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@deleted_by) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@deleted_by) = 1)) AND 
		(ums.IsScheduleHasAuxiliaryDetailsLoadedTeacher(@sysid_auxserviceschedule) = 0) AND
			(ums.IsRecordLockByYearSemesterID((SELECT 
													ass.year_id AS year_semester_id
												FROM 
													ums.auxiliary_service_schedule AS ass 
												WHERE 
													ass.sysid_auxserviceschedule = @sysid_auxserviceschedule AND
													(NOT ass.year_id IS NULL AND NOT ass.year_id = '')
												UNION
												SELECT 
													ass.sysid_semester AS year_semester_id
												FROM 
													ums.auxiliary_service_schedule AS ass 
												WHERE 
													ass.sysid_auxserviceschedule = @sysid_auxserviceschedule AND
													(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = ''))) = 0)
	BEGIN

		IF EXISTS (SELECT sysid_auxserviceschedule FROM ums.auxiliary_service_schedule WHERE sysid_auxserviceschedule = @sysid_auxserviceschedule)
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.auxiliary_service_schedule SET			
				edited_by = @deleted_by
			WHERE
				sysid_auxserviceschedule = @sysid_auxserviceschedule	

			DELETE FROM ums.auxiliary_service_schedule WHERE sysid_auxserviceschedule = @sysid_auxserviceschedule

		END

	END	
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete an auxiliary service schedule', 'Auxiliary Service Schedule'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteAuxiliaryServiceSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountAuxiliaryServiceSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountAuxiliaryServiceSchedule')
   DROP PROCEDURE ums.GetCountAuxiliaryServiceSchedule
GO

CREATE PROCEDURE ums.GetCountAuxiliaryServiceSchedule

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_auxserviceschedule) FROM ums.auxiliary_service_schedule
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an auxiliary service schedule', 'Auxiliary Service Schedule'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountAuxiliaryServiceSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsSysIDAuxiliaryServiceSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsSysIDAuxiliaryServiceSchedule')
   DROP PROCEDURE ums.IsExistsSysIDAuxiliaryServiceSchedule
GO

CREATE PROCEDURE ums.IsExistsSysIDAuxiliaryServiceSchedule

	@sysid_auxserviceschedule varchar (50) = '',
	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsSysIDAuxiliaryServiceSched(@sysid_auxserviceschedule)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an auxiliary service schedule', 'Auxiliary Service Schedule'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsSysIDAuxiliaryServiceSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistsSysIDAuxiliaryServiceSched" function already exist
IF OBJECT_ID (N'ums.IsExistsSysIDAuxiliaryServiceSched') IS NOT NULL
   DROP FUNCTION ums.IsExistsSysIDAuxiliaryServiceSched
GO

CREATE FUNCTION ums.IsExistsSysIDAuxiliaryServiceSched
(	
	@sysid_auxserviceschedule varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_auxserviceschedule FROM ums.auxiliary_service_schedule WHERE sysid_auxserviceschedule = @sysid_auxserviceschedule)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "GetYearSemesterIDAuxiliaryServiceSchedule" function already exist
IF OBJECT_ID (N'ums.GetYearSemesterIDAuxiliaryServiceSchedule') IS NOT NULL
   DROP FUNCTION ums.GetYearSemesterIDAuxiliaryServiceSchedule
GO

CREATE FUNCTION ums.GetYearSemesterIDAuxiliaryServiceSchedule
(	
	@sysid_auxserviceschedule varchar (50) = ''
)
RETURNS varchar (50)
AS
BEGIN
	
	DECLARE @result varchar (50)

	SELECT @result = year_id FROM ums.auxiliary_service_schedule WHERE sysid_auxserviceschedule = @sysid_auxserviceschedule

	IF @result IS NULL OR @result = ''
	BEGIN
		SELECT @result = sysid_semester FROM ums.auxiliary_service_schedule WHERE sysid_auxserviceschedule = @sysid_auxserviceschedule
	END
	
	RETURN @result

END
GO
------------------------------------------------------

-- ################################################END TABLE "auxiliary_service_schedule" OBJECTS######################################################




-- ################################################TABLE "auxiliary_service_details" OBJECTS######################################################
-- verifies if the auxiliary_service_details table exists
IF OBJECT_ID('ums.auxiliary_service_details', 'U') IS NOT NULL
	DROP TABLE ums.auxiliary_service_details
GO

CREATE TABLE ums.auxiliary_service_details 			
(
	sysid_auxdetails varchar (50) NOT NULL
		CONSTRAINT Auxiliary_Service_Details_SysID_AuxDetails_PK PRIMARY KEY (sysid_auxdetails)
		CONSTRAINT Auxiliary_Service_Details_SysID_AuxDetails_CK CHECK (sysid_auxdetails LIKE 'SYSADL%'),
	sysid_auxserviceschedule varchar (50) NOT NULL 
		CONSTRAINT Auxiliary_Service_Details_SysID_AuxServiceSchedule_FK FOREIGN KEY REFERENCES 
						ums.auxiliary_service_schedule(sysid_auxserviceschedule) ON UPDATE NO ACTION,
	
	is_marked_deleted bit NOT NULL DEFAULT (0),

	lecture_units float (3) NOT NULL DEFAULT (0),
	lab_units float (3) NOT NULL DEFAULT (0),
	no_hours varchar (12) NOT NULL DEFAULT ('00:00')
		CONSTRAINT Auxiliary_Service_Details_No_Hours_CK CHECK (no_hours LIKE '[0-9][0-9]:[0-5][0-9]'),
		
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Auxiliary_Service_Details_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Auxiliary_Service_Details_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Auxiliary_Service_Details_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the auxiliary_service_details table 
CREATE INDEX Auxiliary_Service_Details_SysID_AuxDetails_Index
	ON ums.auxiliary_service_details (sysid_auxdetails DESC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Auxiliary_Service_Details_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.Auxiliary_Service_Details_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Auxiliary_Service_Details_Trigger_Insert
GO

CREATE TRIGGER ums.Auxiliary_Service_Details_Trigger_Insert
	ON  ums.auxiliary_service_details
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_auxdetails varchar (50)
	DECLARE @sysid_auxserviceschedule varchar (50)
	DECLARE @lecture_units float (3)
	DECLARE @lab_units float (3)
	DECLARE @no_hours varchar (12)
	DECLARE @sysid_auxservice varchar (50)
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @is_semestral bit	
	DECLARE @created_by varchar (50)

	DECLARE @year_semester_description varchar (100)

	SELECT 
		@sysid_auxdetails = i.sysid_auxdetails,
		@sysid_auxserviceschedule = i.sysid_auxserviceschedule,
		@lecture_units = i.lecture_units,
		@lab_units = i.lab_units,
		@no_hours = i.no_hours,
		@sysid_auxservice = ass.sysid_auxservice,
		@year_id = ass.year_id,
		@sysid_semester = ass.sysid_semester,
		@is_semestral = cg.is_semestral,
		@created_by = i.created_by
	FROM INSERTED AS i
	INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = i.sysid_auxserviceschedule
	INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
	INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id

	SET @year_semester_description = ''

	IF (@is_semestral = 0) AND (NOT @year_id IS NULL)
	BEGIN
		SELECT @year_semester_description = year_description FROM ums.school_year WHERE year_id = @year_id
	END
	ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL)
	BEGIN
		SELECT @year_semester_description = sy.year_description + ' - ' + ss.semester_description
		FROM 
			ums.semester_information AS si
		INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
		INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
		WHERE 
			si.sysid_semester = @sysid_semester
	END
	

	SET @transaction_done = 'CREATED a new auxiliary service schedule details ' + 
							'[Schedule ID: ' + ISNULL(@sysid_auxserviceschedule, '') +
							'][Schedule Details ID: ' + ISNULL(@sysid_auxdetails, '') +							
							'][Auxiliary Title: ' + (SELECT ISNULL(service_code, '') + ' - ' + ISNULL(descriptive_title, '') 
															FROM 
																ums.auxiliary_service_information 
															WHERE 
																sysid_auxservice = @sysid_auxservice) + 
							'][School Year / Semester: ' + ISNULL(@year_semester_description, '') +
							'][Lecture Units: ' + ISNULL(CONVERT(varchar, @lecture_units), '') +
							'][Lab Units: ' + ISNULL(CONVERT(varchar, @lab_units), '') +
							'][Number of Hours: ' + ISNULL(@no_hours, '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Auxiliary_Service_Details_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Auxiliary_Service_Details_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Auxiliary_Service_Details_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Auxiliary_Service_Details_Trigger_Instead_Update
	ON  ums.auxiliary_service_details
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_auxdetails varchar (50)
	DECLARE @sysid_auxserviceschedule varchar (50)
	DECLARE @is_marked_deleted bit
	DECLARE @lecture_units float (3)
	DECLARE @lab_units float (3)
	DECLARE @no_hours varchar (12)
	DECLARE @sysid_auxservice varchar (50)
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @is_semestral bit	
	DECLARE @edited_by varchar (50)

	DECLARE @lecture_units_b float (3)
	DECLARE @lab_units_b float (3)
	DECLARE @no_hours_b varchar (12)

	DECLARE @year_semester_description varchar (100)
	DECLARE @has_update bit

	DECLARE auxiliary_service_details_update_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
		FOR SELECT i.sysid_auxdetails, i.sysid_auxserviceschedule, i.is_marked_deleted, i.lecture_units, i.lab_units, i.no_hours, 
					ass.sysid_auxservice, ass.year_id, ass.sysid_semester, cg.is_semestral, i.edited_by
				FROM INSERTED AS i
				INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = i.sysid_auxserviceschedule
				INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id

	OPEN auxiliary_service_details_update_cursor

	FETCH NEXT FROM auxiliary_service_details_update_cursor
		INTO @sysid_auxdetails, @sysid_auxserviceschedule, @is_marked_deleted, @lecture_units, @lab_units, @no_hours, 
				@sysid_auxservice, @year_id, @sysid_semester, @is_semestral, @edited_by

	WHILE @@FETCH_STATUS = 0
	BEGIN

		IF @is_marked_deleted = 0
		BEGIN

			SELECT
				@lecture_units_b = asd.lecture_units,
				@lab_units_b = asd.lab_units,
				@no_hours_b = asd.no_hours
			FROM
				ums.auxiliary_service_details AS asd
			WHERE
				sysid_auxdetails = @sysid_auxdetails

			SET @transaction_done = ''
			SET @has_update = 0
			
			IF NOT ISNULL(CONVERT(varchar, @lecture_units), '') = ISNULL(CONVERT(varchar, @lecture_units_b), '')
			BEGIN
				SET @transaction_done = @transaction_done + '[Lecture Units Before: ' + ISNULL(CONVERT(varchar, @lecture_units_b), '') + ']' +
															'[Lecture Units After: ' + ISNULL(CONVERT(varchar, @lecture_units), '') + ']'
				SET @has_update = 1
			END

			IF NOT ISNULL(CONVERT(varchar, @lab_units), '') = ISNULL(CONVERT(varchar, @lab_units_b), '')
			BEGIN
				SET @transaction_done = @transaction_done + '[Lab Units Before: ' + ISNULL(CONVERT(varchar, @lab_units_b), '') + ']' +
															'[Lab Units After: ' + ISNULL(CONVERT(varchar, @lab_units), '') + ']'
				SET @has_update = 1
			END

			IF NOT ISNULL(@no_hours, '') = ISNULL(@no_hours_b, '')
			BEGIN
				SET @transaction_done = @transaction_done + '[Number of Hours Before: ' + ISNULL(@no_hours_b, '') + ']' +
															'[Number of Hours After: ' + ISNULL(@no_hours, '') + ']'
				SET @has_update = 1
			END

			IF @has_update = 1
			BEGIN

				UPDATE ums.auxiliary_service_details SET
					lecture_units = @lecture_units,
					lab_units = @lab_units,
					no_hours = @no_hours,
					edited_on = GETDATE(),
					edited_by = @edited_by
				WHERE
					sysid_auxdetails = @sysid_auxdetails

				SET @year_semester_description = ''

				IF (@is_semestral = 0) AND (NOT @year_id IS NULL)
				BEGIN
					SELECT @year_semester_description = year_description FROM ums.school_year WHERE year_id = @year_id
				END
				ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL)
				BEGIN
					SELECT @year_semester_description = sy.year_description + ' - ' + ss.semester_description
					FROM 
						ums.semester_information AS si
					INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
					INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
					WHERE 
						si.sysid_semester = @sysid_semester
				END

				SET @transaction_done = 'UPDATED a auxiliary service schedule details ' + 
										'[Schedule ID: ' + ISNULL(@sysid_auxserviceschedule, '') +
										'][Schedule Details ID: ' + ISNULL(@sysid_auxdetails, '') +							
										'][Auxiliary Title: ' + (SELECT ISNULL(service_code, '') + ' - ' + ISNULL(descriptive_title, '') 
																		FROM 
																			ums.auxiliary_service_information 
																		WHERE 
																			sysid_auxservice = @sysid_auxservice) + 
										'][School Year / Semester: ' + ISNULL(@year_semester_description, '') +							
										']' + @transaction_done

				IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
				BEGIN
					SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
				END
						
				EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done	
			END
			ELSE IF NOT @edited_by IS NULL
			BEGIN

				--used for the delete trigger
				UPDATE ums.auxiliary_service_details SET
					edited_on = GETDATE(),
					edited_by = @edited_by
				WHERE
					sysid_auxdetails = @sysid_auxdetails

			END	

		END

		FETCH NEXT FROM auxiliary_service_details_update_cursor
			INTO @sysid_auxdetails, @sysid_auxserviceschedule, @is_marked_deleted, @lecture_units, @lab_units, @no_hours, 
					@sysid_auxservice, @year_id, @sysid_semester, @is_semestral, @edited_by

	END

	CLOSE auxiliary_service_details_update_cursor
	DEALLOCATE auxiliary_service_details_update_cursor

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Auxiliary_Service_Details_Trigger_Instead_Delete" already exist*/
IF OBJECT_ID ('ums.Auxiliary_Service_Details_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Auxiliary_Service_Details_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Auxiliary_Service_Details_Trigger_Instead_Delete
	ON  ums.auxiliary_service_details
	INSTEAD OF DELETE 
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_auxdetails varchar (50)
	DECLARE @sysid_auxserviceschedule varchar (50)
	DECLARE @is_marked_deleted bit
	DECLARE @lecture_units float (3)
	DECLARE @lab_units float (3)
	DECLARE @no_hours varchar (12)
	DECLARE @sysid_auxservice varchar (50)
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @is_semestral bit	
	DECLARE @deleted_by varchar (50)

	DECLARE @year_semester_description varchar (100)

	DECLARE auxiliary_service_details_delete_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
		FOR SELECT d.sysid_auxdetails, d.sysid_auxserviceschedule, d.is_marked_deleted, d.lecture_units, d.lab_units, d.no_hours, 
					ass.sysid_auxservice, ass.year_id, ass.sysid_semester, cg.is_semestral, d.edited_by
				FROM DELETED AS d
				INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = d.sysid_auxserviceschedule
				INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id

	OPEN auxiliary_service_details_delete_cursor

	FETCH NEXT FROM auxiliary_service_details_delete_cursor
		INTO @sysid_auxdetails, @sysid_auxserviceschedule, @is_marked_deleted, @lecture_units, @lab_units, @no_hours, 
				@sysid_auxservice, @year_id, @sysid_semester, @is_semestral, @deleted_by

	WHILE @@FETCH_STATUS = 0
	BEGIN

		IF @is_marked_deleted = 0
		BEGIN

			UPDATE ums.teacher_load SET edited_by = @deleted_by WHERE sysid_auxdetails = @sysid_auxdetails
			DELETE FROM ums.teacher_load WHERE sysid_auxdetails = @sysid_auxdetails		

			UPDATE ums.auxiliary_service_details SET is_marked_deleted = 1, edited_by = @deleted_by WHERE sysid_auxdetails = @sysid_auxdetails

			SET @year_semester_description = ''

			IF (@is_semestral = 0) AND (NOT @year_id IS NULL)
			BEGIN
				SELECT @year_semester_description = year_description FROM ums.school_year WHERE year_id = @year_id
			END
			ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL)
			BEGIN
				SELECT @year_semester_description = sy.year_description + ' - ' + ss.semester_description
				FROM 
					ums.semester_information AS si
				INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
				INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
				WHERE 
					si.sysid_semester = @sysid_semester
			END
			

			SET @transaction_done = 'MARK AS DELETED an auxiliary service schedule details ' + 
									'[Schedule ID: ' + ISNULL(@sysid_auxserviceschedule, '') +
									'][Schedule Details ID: ' + ISNULL(@sysid_auxdetails, '') +							
									'][Auxiliary Title: ' + (SELECT ISNULL(service_code, '') + ' - ' + ISNULL(descriptive_title, '') 
																	FROM 
																		ums.auxiliary_service_information 
																	WHERE 
																		sysid_auxservice = @sysid_auxservice) + 
									'][School Year / Semester: ' + ISNULL(@year_semester_description, '') +
									'][Lecture Units: ' + ISNULL(CONVERT(varchar, @lecture_units), '') +
									'][Lab Units: ' + ISNULL(CONVERT(varchar, @lab_units), '') +
									'][Number of Hours: ' + ISNULL(@no_hours, '') +
									']'


			IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
			BEGIN
				SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @deleted_by
			END
					
			EXECUTE ums.InsertTransactionLog @deleted_by, @network_information, @transaction_done	

		END

		FETCH NEXT FROM auxiliary_service_details_delete_cursor
			INTO @sysid_auxdetails, @sysid_auxserviceschedule, @is_marked_deleted, @lecture_units, @lab_units, @no_hours, 
					@sysid_auxservice, @year_id, @sysid_semester, @is_semestral, @deleted_by

	END

	CLOSE auxiliary_service_details_delete_cursor
	DEALLOCATE auxiliary_service_details_delete_cursor


GO
/*-----------------------------------------------------------------*/

-- verifies if the procedure "InsertAuxiliaryServiceDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertAuxiliaryServiceDetails')
   DROP PROCEDURE ums.InsertAuxiliaryServiceDetails
GO

CREATE PROCEDURE ums.InsertAuxiliaryServiceDetails

	@sysid_auxdetails varchar (50) = '',
	@sysid_auxserviceschedule varchar (50) = '',
	@lecture_units float (3) = 0,
	@lab_units float (3) = 0,
	@no_hours varchar (12) = '',

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR 
		(ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@created_by) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@created_by) = 1)) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													ass.year_id AS year_semester_id
												FROM 
													ums.auxiliary_service_schedule AS ass
												WHERE 
													ass.sysid_auxserviceschedule = @sysid_auxserviceschedule AND
													(NOT ass.year_id IS NULL AND NOT ass.year_id = '')
												UNION
												SELECT 
													ass.sysid_semester AS year_semester_id
												FROM 
													ums.auxiliary_service_schedule AS ass
												WHERE 
													ass.sysid_auxserviceschedule = @sysid_auxserviceschedule AND
													(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = ''))) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.auxiliary_service_details
		(
			sysid_auxdetails,
			sysid_auxserviceschedule,
			lecture_units,
			lab_units,
			no_hours,
			created_by
		)
		VALUES
		(
			@sysid_auxdetails,
			@sysid_auxserviceschedule,
			@lecture_units,
			@lab_units,
			@no_hours,
			@created_by
		)		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new auxiliary service details', 'Auxiliar Service Details'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertAuxiliaryServiceDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateAuxiliaryServiceDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateAuxiliaryServiceDetails')
   DROP PROCEDURE ums.UpdateAuxiliaryServiceDetails
GO

CREATE PROCEDURE ums.UpdateAuxiliaryServiceDetails

	@sysid_auxdetails varchar (50) = '',
	@lecture_units float (3) = 0,
	@lab_units float (3) = 0,
	@no_hours varchar (12) = '',

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR 
		(ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@edited_by) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@edited_by) = 1)) AND
		(ums.IsAuxiliaryDetailsLoadedTeacher(@sysid_auxdetails) = 0) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													ass.year_id AS year_semester_id
												FROM 
													ums.auxiliary_service_details AS asd
												INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
												WHERE 
													asd.sysid_auxdetails = @sysid_auxdetails AND
													(NOT ass.year_id IS NULL AND NOT ass.year_id = '')
												UNION
												SELECT 
													ass.sysid_semester AS year_semester_id
												FROM 
													ums.auxiliary_service_details AS asd
												INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
												WHERE 
													asd.sysid_auxdetails = @sysid_auxdetails AND
													(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = ''))) = 0)
		
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.auxiliary_service_details SET
			lecture_units = @lecture_units,
			lab_units = @lab_units,
			no_hours = @no_hours,
			edited_by = @edited_by
		WHERE
			sysid_auxdetails = @sysid_auxdetails
		
	END
	ELSE
	BEGIN
	
		EXECUTE ums.ShowErrorMsg 'Updated an auxiliary service details', 'Auxiliar Service Details'

	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateAuxiliaryServiceDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteAuxiliaryServiceDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteAuxiliaryServiceDetails')
   DROP PROCEDURE ums.DeleteAuxiliaryServiceDetails
GO

CREATE PROCEDURE ums.DeleteAuxiliaryServiceDetails

	@sysid_auxdetails varchar (50) = '',
	
	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR 
		(ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@deleted_by) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@deleted_by) = 1)) AND
		(ums.IsAuxiliaryDetailsLoadedTeacher(@sysid_auxdetails) = 0) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													ass.year_id AS year_semester_id
												FROM 
													ums.auxiliary_service_details AS asd
												INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
												WHERE 
													asd.sysid_auxdetails = @sysid_auxdetails AND
													(NOT ass.year_id IS NULL AND NOT ass.year_id = '')
												UNION
												SELECT 
													ass.sysid_semester AS year_semester_id
												FROM 
													ums.auxiliary_service_details AS asd
												INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
												WHERE 
													asd.sysid_auxdetails = @sysid_auxdetails AND
													(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = ''))) = 0)
	BEGIN

		IF EXISTS (SELECT sysid_auxdetails FROM ums.auxiliary_service_details WHERE sysid_auxdetails = @sysid_auxdetails)
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.auxiliary_service_details SET			
				edited_by = @deleted_by
			WHERE
				sysid_auxdetails = @sysid_auxdetails			

			DELETE FROM ums.auxiliary_service_details WHERE sysid_auxdetails = @sysid_auxdetails

		END

	END	
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete an auxiliary service details', 'Auxiliar Service Details'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteAuxiliaryServiceDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountAuxiliaryServiceDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountAuxiliaryServiceDetails')
   DROP PROCEDURE ums.GetCountAuxiliaryServiceDetails
GO

CREATE PROCEDURE ums.GetCountAuxiliaryServiceDetails

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_auxdetails) FROM ums.auxiliary_service_details
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an auxiliary service details', 'Auxiliar Service Details'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountAuxiliaryServiceDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsSysIDAuxiliaryServiceDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsSysIDAuxiliaryServiceDetails')
   DROP PROCEDURE ums.IsExistsSysIDAuxiliaryServiceDetails
GO

CREATE PROCEDURE ums.IsExistsSysIDAuxiliaryServiceDetails

	@sysid_auxdetails varchar (50) = '',
	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsSysIDAuxServiceDetails(@sysid_auxdetails)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an auxiliary service details', 'Auxiliar Service Details'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsSysIDAuxiliaryServiceDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistsSysIDAuxServiceDetails" function already exist
IF OBJECT_ID (N'ums.IsExistsSysIDAuxServiceDetails') IS NOT NULL
   DROP FUNCTION ums.IsExistsSysIDAuxServiceDetails
GO

CREATE FUNCTION ums.IsExistsSysIDAuxServiceDetails
(	
	@sysid_auxdetails varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_auxdetails FROM ums.auxiliary_service_details WHERE sysid_auxdetails = @sysid_auxdetails)
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



-- ################################################END TABLE "auxiliary_service_details" OBJECTS######################################################





-- ################################################TABLE "teacher_load" OBJECTS######################################################
-- verifies if the teacher_load table exists
IF OBJECT_ID('ums.teacher_load', 'U') IS NOT NULL
	DROP TABLE ums.teacher_load
GO

CREATE TABLE ums.teacher_load 			
(
	load_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Teacher_Load_Load_ID_PK PRIMARY KEY (load_id),
	sysid_scheddetails varchar (50) NULL
		CONSTRAINT Teacher_Load_SysID_SchedDetails_FK FOREIGN KEY REFERENCES ums.schedule_information_details(sysid_scheddetails) ON UPDATE NO ACTION,
	sysid_auxdetails varchar (50) NULL
		CONSTRAINT Teacher_Load_SysID_AuxDetails_FK FOREIGN KEY REFERENCES ums.auxiliary_service_details(sysid_auxdetails) ON UPDATE NO ACTION,
	sysid_employee varchar (50) NOT NULL 
		CONSTRAINT Teacher_Load_SysID_Employee_FK FOREIGN KEY REFERENCES ums.employee_information(sysid_employee) ON UPDATE NO ACTION,
	load_date datetime NOT NULL
		CONSTRAINT Teacher_Load_Load_Date_Start_CK CHECK (CONVERT(varchar, load_date, 109) LIKE '%12:00:00:000AM'), 
	deload_date datetime NOT NULL
		CONSTRAINT Teacher_Load_Load_Date_End_CK CHECK (CONVERT(varchar, deload_date, 109) LIKE '%11:59:59:000PM'),

	lecture_units float (3) NOT NULL DEFAULT (0),
	lab_units float (3) NOT NULL DEFAULT (0),
	no_hours varchar (12) NOT NULL DEFAULT ('00:00')
		CONSTRAINT Teacher_Load_No_Hours_CK CHECK (no_hours LIKE '[0-9][0-9]:[0-5][0-9]'),

	is_auxiliary bit NOT NULL DEFAULT (0),

	is_premature_deloaded bit NOT NULL DEFAULT (0),
	
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Teacher_Load_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Teacher_Load_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Teacher_Load_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the teacher_load table 
CREATE INDEX Teacher_Load_Load_ID_Index
	ON ums.teacher_load (load_id DESC)
GO
------------------------------------------------------------------

-- verifies if the procedure "InsertTeacherLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertTeacherLoad')
   DROP PROCEDURE ums.InsertTeacherLoad
GO

CREATE PROCEDURE ums.InsertTeacherLoad

	@sysid_scheddetails varchar (50) = '',
	@sysid_auxdetails varchar (50) = '',
	@sysid_employee varchar (50) = '',
	@is_auxiliary bit = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR 
		(((ums.IsVpOfAcademicAffairsSystemUserInfo(@created_by) = 1) OR (ums.IsOfficeUserSystemUserInfo(@created_by) = 1)) AND 
		((ums.IsUserSameDepartmentSubjectInfo((SELECT 
													sci.sysid_subject
												FROM
													schedule_information_details AS scd
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
												INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
												WHERE
													scd.sysid_scheddetails = @sysid_scheddetails), @created_by) = 1) OR
			(ums.IsUserSameDepartmentAuxiliaryServiceInfo((SELECT
													asi.sysid_auxservice
												FROM
													auxiliary_service_details AS asd
												INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
												INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
												WHERE
													asd.sysid_auxdetails = @sysid_auxdetails), @created_by) = 1))) OR
		((ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@created_by) = 1) AND
			(ums.IsUserSameDepartmentAuxiliaryServiceInfo((SELECT
													asi.sysid_auxservice
												FROM
													auxiliary_service_details AS asd
												INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
												INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
												WHERE
													asd.sysid_auxdetails = @sysid_auxdetails), @created_by) = 1))) AND
		(ums.IsScheduleAuxiliaryDetailsAlreadyLoadedTeacher(@sysid_scheddetails, @sysid_auxdetails, @sysid_employee) = 0) AND 
		(ums.IsScheduleConflictsWithAnotherEmployeeLoadedSchedule(@sysid_scheddetails, @sysid_employee) = 0) AND
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.schedule_information_details AS scd
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
												WHERE 
													scd.sysid_scheddetails = @sysid_scheddetails AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.schedule_information_details AS scd
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
												WHERE 
													scd.sysid_scheddetails = @sysid_scheddetails AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '')
												UNION
												SELECT 
													ass.year_id AS year_semester_id
												FROM 
													ums.auxiliary_service_details AS asd
												INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
												WHERE 
													asd.sysid_auxdetails = @sysid_auxdetails AND
													(NOT ass.year_id IS NULL AND NOT ass.year_id = '')
												UNION
												SELECT 
													ass.sysid_semester AS year_semester_id
												FROM 
													ums.auxiliary_service_details AS asd
												INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
												WHERE 
													asd.sysid_auxdetails = @sysid_auxdetails AND
													(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = ''))) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		IF (@is_auxiliary = 0) AND (NOT @sysid_scheddetails IS NULL)
		BEGIN

			INSERT INTO ums.teacher_load
			(
				sysid_scheddetails,
				sysid_auxdetails,
				sysid_employee,
				is_auxiliary,
				created_by
			)
			VALUES
			(
				@sysid_scheddetails,
				NULL,
				@sysid_employee,
				@is_auxiliary,
				@created_by
			)

		END
		ELSE IF (@is_auxiliary = 1) AND (NOT @sysid_auxdetails IS NULL)
		BEGIN

			INSERT INTO ums.teacher_load
			(
				sysid_scheddetails,
				sysid_auxdetails,
				sysid_employee,
				is_auxiliary,
				created_by
			)
			VALUES
			(
				NULL,
				@sysid_auxdetails,
				@sysid_employee,
				@is_auxiliary,
				@created_by
			)

		END
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new teacher load', 'Teacher Load'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertTeacherLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteTeacherLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteTeacherLoad')
   DROP PROCEDURE ums.DeleteTeacherLoad
GO

CREATE PROCEDURE ums.DeleteTeacherLoad

	@load_id bigint = 0,

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@deleted_by) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@deleted_by) = 1)) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.teacher_load AS tl
												INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
												WHERE 
													tl.load_id = @load_id AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.teacher_load AS tl
												INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
												WHERE 
													tl.load_id = @load_id AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '')
												UNION
												SELECT 
													ass.year_id AS year_semester_id
												FROM 
													ums.teacher_load AS tl
												INNER JOIN ums.auxiliary_service_details AS asd ON asd.sysid_auxdetails = tl.sysid_auxdetails
												INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
												WHERE 
													tl.load_id = @load_id AND
													(NOT ass.year_id IS NULL AND NOT ass.year_id = '')
												UNION
												SELECT 
													ass.sysid_semester AS year_semester_id
												FROM 
													ums.teacher_load AS tl
												INNER JOIN ums.auxiliary_service_details AS asd ON asd.sysid_auxdetails = tl.sysid_auxdetails
												INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
												WHERE 
													tl.load_id = @load_id AND
													(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = ''))) = 0)
	BEGIN

		IF EXISTS (SELECT load_id FROM ums.teacher_load WHERE load_id = @load_id)
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.teacher_load SET
				edited_by = @deleted_by
			WHERE 
				load_id = @load_id

			DELETE FROM ums.teacher_load WHERE load_id = @load_id

		END		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Deleted a teacher load', 'Teacher Load'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteTeacherLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByDateStartEndSysIDEmployeeTeacherLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByDateStartEndSysIDEmployeeTeacherLoad')
   DROP PROCEDURE ums.SelectByDateStartEndSysIDEmployeeTeacherLoad
GO

CREATE PROCEDURE ums.SelectByDateStartEndSysIDEmployeeTeacherLoad

	@sysid_employee varchar (50) = '',
	@date_start datetime,
	@date_end datetime,

	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT
			tl.load_id AS load_id,
			tl.sysid_scheddetails AS sysid_scheddetails,
			tl.sysid_employee AS sysid_employee,
			tl.load_date AS load_date,
			tl.deload_date AS deload_date
		FROM 
			ums.teacher_load AS tl
		INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(tl.sysid_employee = @sysid_employee)
		UNION ALL
		SELECT
			tl.load_id AS load_id,
			tl.sysid_scheddetails AS sysid_scheddetails,
			tl.sysid_employee AS sysid_employee,
			tl.load_date AS load_date,
			tl.deload_date AS deload_date
		FROM 
			ums.teacher_load AS tl
		INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(tl.sysid_employee = @sysid_employee)
		
	END	
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a teacher load', 'Teacher Load'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByDateStartEndSysIDEmployeeTeacherLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByDateStartEndForTeacherLoadingTeacherLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByDateStartEndForTeacherLoadingTeacherLoad')
   DROP PROCEDURE ums.SelectByDateStartEndForTeacherLoadingTeacherLoad
GO

CREATE PROCEDURE ums.SelectByDateStartEndForTeacherLoadingTeacherLoad

	@date_start datetime,
	@date_end datetime,

	@system_user_id varchar (50) = ''
		
AS

	DECLARE @department_id varchar (50)

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1)
	BEGIN

		WITH cte_loaded_schedule_details (load_id, sysid_scheddetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 0)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 0)
		),
		cte_deloaded_schedule_details (load_id, sysid_scheddetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(NOT tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 1)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(NOT tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 1)
		),
		cte_loaded_auxiliary_details (load_id, sysid_auxdetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
			WHERE
				(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 0)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
			WHERE
				(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 0)
		),
		cte_deloaded_auxiliary_details (load_id, sysid_auxdetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
			WHERE
				(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(NOT tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 1)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
			WHERE
				(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(NOT tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 1)
		)

		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,			
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,			
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,	
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,	
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,	
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time	
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL						------------------------------------ clsd.sysid_employee IS NULL ---------------------------------------------------
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,			
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			scd.lecture_units AS lecture_units,
			scd.lab_units AS lab_units,
			scd.no_hours AS no_hours,			
			'false' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		LEFT JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			scd.lecture_units AS lecture_units,
			scd.lab_units AS lab_units,
			scd.no_hours AS no_hours,	
			'false' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		LEFT JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			scd.lecture_units AS lecture_units,
			scd.lab_units AS lab_units,
			scd.no_hours AS no_hours,	
			'false' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		LEFT JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND
			(clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			scd.lecture_units AS lecture_units,
			scd.lab_units AS lab_units,
			scd.no_hours AS no_hours,	
			'false' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		LEFT JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND
			(clsd.sysid_employee IS NULL)
		UNION ALL						-------------------------pre-maturely deloaded subject schedule details ---------------------------------
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,			
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,	
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(NOT scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(NOT scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.sysid_classroom IS NULL)
		UNION ALL					---------------------------------- auxiliary services --------------------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			clad.lecture_units AS lecture_units,
			clad.lab_units AS lab_units,
			clad.no_hours AS no_hours,			
			clad.is_auxiliary AS is_auxiliary,
			clad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(NOT clad.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			clad.lecture_units AS lecture_units,
			clad.lab_units AS lab_units,
			clad.no_hours AS no_hours,			
			clad.is_auxiliary AS is_auxiliary,
			clad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(NOT clad.sysid_employee IS NULL)
		UNION ALL						----------------------------- clad.sysid_employee IS NULL -------------------------------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			asd.lecture_units AS lecture_units,
			asd.lab_units AS lab_units,
			asd.no_hours AS no_hours,			
			'true' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		LEFT JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(clad.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			asd.lecture_units AS lecture_units,
			asd.lab_units AS lab_units,
			asd.no_hours AS no_hours,			
			'true' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		LEFT JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(clad.sysid_employee IS NULL)
		UNION ALL						-------------------------pre-maturely deloaded auxiliary service schedule details ---------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			cdad.load_id AS load_id,
			cdad.sysid_employee AS sysid_employee,
			cdad.load_date AS load_date,
			cdad.deload_date AS deload_date,
			cdad.lecture_units AS lecture_units,
			cdad.lab_units AS lab_units,
			cdad.no_hours AS no_hours,			
			cdad.is_auxiliary AS is_auxiliary,
			cdad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_deloaded_auxiliary_details AS cdad ON cdad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			cdad.load_id AS load_id,
			cdad.sysid_employee AS sysid_employee,
			cdad.load_date AS load_date,
			cdad.deload_date AS deload_date,
			cdad.lecture_units AS lecture_units,
			cdad.lab_units AS lab_units,
			cdad.no_hours AS no_hours,			
			cdad.is_auxiliary AS is_auxiliary,
			cdad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_deloaded_auxiliary_details AS cdad ON cdad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
		ORDER BY 
			subject_service_code ASC
		
	END	
	--==============================================VP OF ACADEMIC AFFAIRS=====================================================================
	ELSE IF (ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT 
			@department_id = arg.department_id 
		FROM
			ums.access_rights_granted AS arg
		INNER JOIN ums.system_user_info AS sui ON sui.system_user_id = arg.system_user_id
		WHERE
			(arg.access_rights = '@oRwPc_+=tY/~\#zQ58!*$cPa:+Zy829xz;%^aG@') AND
			(sui.system_user_id = @system_user_id);

		WITH cte_loaded_schedule_details (load_id, sysid_scheddetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 0)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 0)
		),
		cte_deloaded_schedule_details (load_id, sysid_scheddetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(NOT tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 1)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(NOT tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 1)
		),
		cte_loaded_auxiliary_details (load_id, sysid_auxdetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
			WHERE
				(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 0)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
			WHERE
				(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 0)
		),
		cte_deloaded_auxiliary_details (load_id, sysid_auxdetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
			WHERE
				(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(NOT tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 1)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
			WHERE
				(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(NOT tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 1)
		)

		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,			
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,			
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,	
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,	
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,	
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)				
		UNION ALL						-------------------------pre-maturely deloaded subject schedule details ---------------------------------
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,			
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(NOT scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(NOT scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.sysid_classroom IS NULL)
		UNION ALL					---------------------------------- auxiliary services --------------------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			clad.lecture_units AS lecture_units,
			clad.lab_units AS lab_units,
			clad.no_hours AS no_hours,			
			clad.is_auxiliary AS is_auxiliary,
			clad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(NOT clad.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			clad.lecture_units AS lecture_units,
			clad.lab_units AS lab_units,
			clad.no_hours AS no_hours,			
			clad.is_auxiliary AS is_auxiliary,
			clad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(NOT clad.sysid_employee IS NULL)		
		UNION ALL						----------------------------- clad.sysid_employee IS NULL -------------------------------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			asd.lecture_units AS lecture_units,
			asd.lab_units AS lab_units,
			asd.no_hours AS no_hours,			
			'true' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		LEFT JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(clad.sysid_employee IS NULL) AND	
			(asi.department_id = @department_id)
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			asd.lecture_units AS lecture_units,
			asd.lab_units AS lab_units,
			asd.no_hours AS no_hours,			
			'true' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		LEFT JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(clad.sysid_employee IS NULL) AND	
			(asi.department_id = @department_id)	
		UNION ALL						-------------------------pre-maturely deloaded auxiliary service schedule details ---------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			cdad.load_id AS load_id,
			cdad.sysid_employee AS sysid_employee,
			cdad.load_date AS load_date,
			cdad.deload_date AS deload_date,
			cdad.lecture_units AS lecture_units,
			cdad.lab_units AS lab_units,
			cdad.no_hours AS no_hours,			
			cdad.is_auxiliary AS is_auxiliary,
			cdad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_deloaded_auxiliary_details AS cdad ON cdad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			cdad.load_id AS load_id,
			cdad.sysid_employee AS sysid_employee,
			cdad.load_date AS load_date,
			cdad.deload_date AS deload_date,
			cdad.lecture_units AS lecture_units,
			cdad.lab_units AS lab_units,
			cdad.no_hours AS no_hours,			
			cdad.is_auxiliary AS is_auxiliary,
			cdad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_deloaded_auxiliary_details AS cdad ON cdad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
		ORDER BY 
			subject_service_code ASC

	END
	--==============================================PAYROLL MASTER, VP OF FINANCE AFFAIRS, REGISTRAR====================================================
	ELSE IF (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1) OR (ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR 
			(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR (ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)	
	BEGIN

		WITH cte_loaded_schedule_details (load_id, sysid_scheddetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 0)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 0)
		),
		cte_deloaded_schedule_details (load_id, sysid_scheddetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(NOT tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 1)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(NOT tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 1)
		),
		cte_loaded_auxiliary_details (load_id, sysid_auxdetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
			WHERE
				(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 0)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
			WHERE
				(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 0)
		),
		cte_deloaded_auxiliary_details (load_id, sysid_auxdetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
			WHERE
				(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(NOT tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 1)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
			WHERE
				(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(NOT tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 1)
		)

		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,			
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,			
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,	
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,	
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,	
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)		
		UNION ALL						-------------------------pre-maturely deloaded subject schedule details ---------------------------------
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,			
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(NOT scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(NOT scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.sysid_classroom IS NULL)
		UNION ALL					---------------------------------- auxiliary services --------------------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			clad.lecture_units AS lecture_units,
			clad.lab_units AS lab_units,
			clad.no_hours AS no_hours,			
			clad.is_auxiliary AS is_auxiliary,
			clad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(NOT clad.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			clad.lecture_units AS lecture_units,
			clad.lab_units AS lab_units,
			clad.no_hours AS no_hours,			
			clad.is_auxiliary AS is_auxiliary,
			clad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(NOT clad.sysid_employee IS NULL)		
		UNION ALL						-------------------------pre-maturely deloaded auxiliary service schedule details ---------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			cdad.load_id AS load_id,
			cdad.sysid_employee AS sysid_employee,
			cdad.load_date AS load_date,
			cdad.deload_date AS deload_date,
			cdad.lecture_units AS lecture_units,
			cdad.lab_units AS lab_units,
			cdad.no_hours AS no_hours,			
			cdad.is_auxiliary AS is_auxiliary,
			cdad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_deloaded_auxiliary_details AS cdad ON cdad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			cdad.load_id AS load_id,
			cdad.sysid_employee AS sysid_employee,
			cdad.load_date AS load_date,
			cdad.deload_date AS deload_date,
			cdad.lecture_units AS lecture_units,
			cdad.lab_units AS lab_units,
			cdad.no_hours AS no_hours,			
			cdad.is_auxiliary AS is_auxiliary,
			cdad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_deloaded_auxiliary_details AS cdad ON cdad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
		ORDER BY 
			subject_service_code ASC

	END
	--==================================================SECRETARY OF THE VP OF ACADEMIC AFFAIRS=============================================================
	ELSE IF (ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT 
			@department_id = arg.department_id 
		FROM
			ums.access_rights_granted AS arg
		INNER JOIN ums.system_user_info AS sui ON sui.system_user_id = arg.system_user_id
		WHERE
			(arg.access_rights = '@h74E*,:!#aE43Bm|~*gHaQp,Z*_=$^`;gcZm&9@') AND
			(sui.system_user_id = @system_user_id);

		WITH cte_loaded_schedule_details (load_id, sysid_scheddetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 0)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 0)
		),
		cte_deloaded_schedule_details (load_id, sysid_scheddetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(NOT tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 1)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(NOT tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 1)
		),
		cte_loaded_auxiliary_details (load_id, sysid_auxdetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
			WHERE
				(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 0)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
			WHERE
				(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 0)
		),
		cte_deloaded_auxiliary_details (load_id, sysid_auxdetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
			WHERE
				(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(NOT tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 1)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
			WHERE
				(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(NOT tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 1)
		)	

		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,			
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,			
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,	
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,	
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,	
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND
			(NOT clsd.sysid_employee IS NULL)		
		UNION ALL						-------------------------pre-maturely deloaded subject schedule details ---------------------------------
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,			
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(NOT scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(NOT scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.sysid_classroom IS NULL)
		UNION ALL					---------------------------------- auxiliary services --------------------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			clad.lecture_units AS lecture_units,
			clad.lab_units AS lab_units,
			clad.no_hours AS no_hours,			
			clad.is_auxiliary AS is_auxiliary,
			clad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(NOT clad.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			clad.lecture_units AS lecture_units,
			clad.lab_units AS lab_units,
			clad.no_hours AS no_hours,			
			clad.is_auxiliary AS is_auxiliary,
			clad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(NOT clad.sysid_employee IS NULL)
		UNION ALL						----------------------------- clad.sysid_employee IS NULL -------------------------------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			asd.lecture_units AS lecture_units,
			asd.lab_units AS lab_units,
			asd.no_hours AS no_hours,			
			'true' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		LEFT JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(clad.sysid_employee IS NULL) AND	
			(asi.department_id = @department_id)
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			asd.lecture_units AS lecture_units,
			asd.lab_units AS lab_units,
			asd.no_hours AS no_hours,			
			'true' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		LEFT JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(clad.sysid_employee IS NULL) AND	
			(asi.department_id = @department_id)
		UNION ALL						-------------------------pre-maturely deloaded auxiliary service schedule details ---------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			cdad.load_id AS load_id,
			cdad.sysid_employee AS sysid_employee,
			cdad.load_date AS load_date,
			cdad.deload_date AS deload_date,
			cdad.lecture_units AS lecture_units,
			cdad.lab_units AS lab_units,
			cdad.no_hours AS no_hours,			
			cdad.is_auxiliary AS is_auxiliary,
			cdad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_deloaded_auxiliary_details AS cdad ON cdad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			cdad.load_id AS load_id,
			cdad.sysid_employee AS sysid_employee,
			cdad.load_date AS load_date,
			cdad.deload_date AS deload_date,
			cdad.lecture_units AS lecture_units,
			cdad.lab_units AS lab_units,
			cdad.no_hours AS no_hours,			
			cdad.is_auxiliary AS is_auxiliary,
			cdad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_deloaded_auxiliary_details AS cdad ON cdad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
		ORDER BY 
			subject_service_code ASC

	END
	--======================================================= OFFICE USER =====================================================================
	ELSE IF (ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1)
	BEGIN		

		SELECT 
			@department_id = arg.department_id 
		FROM
			ums.access_rights_granted AS arg
		INNER JOIN ums.system_user_info AS sui ON sui.system_user_id = arg.system_user_id
		WHERE
			(arg.access_rights = '@7W_*xAuIz%qTm^rYmq!a38&z#s{>zX2*pUw[#Z@') AND
			(sui.system_user_id = @system_user_id);

		WITH cte_loaded_schedule_details (load_id, sysid_scheddetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(	

			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 0) AND
				(((SELECT TOP 1
						department_id 
					FROM 
						ums.salary_information
					WHERE
						sysid_employee = tl.sysid_employee AND
						effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = tl.sysid_employee AND
							effectivity_date <= @date_end)) = @department_id) OR
					si.department_id = @department_id)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 0) AND
				(((SELECT TOP 1
						department_id 
					FROM 
						ums.salary_information
					WHERE
						sysid_employee = tl.sysid_employee AND
						effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = tl.sysid_employee AND
							effectivity_date <= @date_end)) = @department_id) OR
					si.department_id = @department_id)
		),
		cte_deloaded_schedule_details (load_id, sysid_scheddetails, sysid_employee, load_date, deload_date,
				lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(	

			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(NOT tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 1) AND
				(((SELECT TOP 1
						department_id 
					FROM 
						ums.salary_information
					WHERE
						sysid_employee = tl.sysid_employee AND
						effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = tl.sysid_employee AND
							effectivity_date <= @date_end)) = @department_id) OR
					si.department_id = @department_id)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_scheddetails AS sysid_scheddetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(NOT tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 1) AND
				(((SELECT TOP 1
						department_id 
					FROM 
						ums.salary_information
					WHERE
						sysid_employee = tl.sysid_employee AND
						effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = tl.sysid_employee AND
							effectivity_date <= @date_end)) = @department_id) OR
					si.department_id = @department_id)
		),
		cte_loaded_auxiliary_details (load_id, sysid_auxdetails, sysid_employee, load_date, deload_date,
			lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
			INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
			WHERE
				(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 0) AND
				(((SELECT TOP 1
						department_id 
					FROM 
						ums.salary_information
					WHERE
						sysid_employee = tl.sysid_employee AND
						effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = tl.sysid_employee AND
							effectivity_date <= @date_end)) = @department_id) OR
					asi.department_id = @department_id)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
			WHERE
				(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 0) AND
				(((SELECT TOP 1
						department_id 
					FROM 
						ums.salary_information
					WHERE
						sysid_employee = tl.sysid_employee AND
						effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = tl.sysid_employee AND
							effectivity_date <= @date_end)) = @department_id) OR
					asi.department_id = @department_id)
		),
		cte_deloaded_auxiliary_details (load_id, sysid_auxdetails, sysid_employee, load_date, deload_date,
			lecture_units, lab_units, no_hours, is_auxiliary, is_premature_deloaded) AS
		(
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
			INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
			WHERE
				(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(NOT tl.deload_date = sy.date_end) AND
				(tl.is_premature_deloaded = 1) AND
				(((SELECT TOP 1
						department_id 
					FROM 
						ums.salary_information
					WHERE
						sysid_employee = tl.sysid_employee AND
						effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = tl.sysid_employee AND
							effectivity_date <= @date_end)) = @department_id) OR
					asi.department_id = @department_id)
			UNION ALL
			SELECT
				tl.load_id AS load_id,
				tl.sysid_auxdetails AS sysid_auxdetails,
				tl.sysid_employee AS sysid_employee,
				tl.load_date AS load_date,
				tl.deload_date AS deload_date,
				tl.lecture_units AS lecture_units,
				tl.lab_units AS lab_units,
				tl.no_hours AS no_hours,
				tl.is_auxiliary AS is_auxiliary,
				tl.is_premature_deloaded AS is_premature_deloaded
			FROM
				ums.teacher_load AS tl
			INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
			INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
			INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
			WHERE
				(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
				(NOT tl.deload_date = sri.date_end) AND
				(tl.is_premature_deloaded = 1) AND
				(((SELECT TOP 1
						department_id 
					FROM 
						ums.salary_information
					WHERE
						sysid_employee = tl.sysid_employee AND
						effectivity_date = (SELECT MAX(effectivity_date) FROM ums.salary_information WHERE sysid_employee = tl.sysid_employee AND
							effectivity_date <= @date_end)) = @department_id) OR
					asi.department_id = @department_id)
		)

		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,				
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,
			clsd.is_auxiliary AS is_auxiliary,	
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND	
			(NOT clsd.sysid_employee IS NULL) 	
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,				
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND	
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,				
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND	
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,				
			cg.group_no AS group_no,
			NULL AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			clsd.lecture_units AS lecture_units,
			clsd.lab_units AS lab_units,
			clsd.no_hours AS no_hours,
			clsd.is_auxiliary AS is_auxiliary,
			clsd.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND	
			(NOT clsd.sysid_employee IS NULL)
		UNION ALL				------------------------------------ clsd.sysid_employee IS NULL ---------------------------------------------------
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,				
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			scd.lecture_units AS lecture_units,
			scd.lab_units AS lab_units,
			scd.no_hours AS no_hours,
			'false' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		LEFT JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND	
			(clsd.sysid_employee IS NULL) AND	
			(si.department_id = @department_id)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,				
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			scd.lecture_units AS lecture_units,
			scd.lab_units AS lab_units,
			scd.no_hours AS no_hours,
			'false' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		LEFT JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(NOT scd.sysid_classroom IS NULL) AND	
			(clsd.sysid_employee IS NULL) AND	
			(si.department_id = @department_id)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,				
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			scd.lecture_units AS lecture_units,
			scd.lab_units AS lab_units,
			scd.no_hours AS no_hours,
			'false' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		LEFT JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND	
			(clsd.sysid_employee IS NULL) AND	
			(si.department_id = @department_id)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,				
			cg.group_no AS group_no,
			NULL AS classroom_code,
			clsd.load_id AS load_id,
			clsd.sysid_employee AS sysid_employee,
			clsd.load_date AS load_date,
			clsd.deload_date AS deload_date,
			scd.lecture_units AS lecture_units,
			scd.lab_units AS lab_units,
			scd.no_hours AS no_hours,
			'false' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		LEFT JOIN cte_loaded_schedule_details AS clsd ON clsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.is_marked_deleted = 0) AND
			(scd.sysid_classroom IS NULL) AND	
			(clsd.sysid_employee IS NULL) AND	
			(si.department_id = @department_id)
		UNION ALL					-------------------------pre-maturely deloaded subject schedule details ---------------------------------
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,				
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,	
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,	
			cdsd.is_premature_deloaded AS is_premature_deloaded,		
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(NOT scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,				
			cg.group_no AS group_no,
			ci.classroom_code AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,				
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(NOT scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.year_id AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,				
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,	
			cdsd.is_premature_deloaded AS is_premature_deloaded,			
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.sysid_classroom IS NULL)
		UNION ALL
		SELECT 
			scd.sysid_scheddetails AS sysid_scheddetails_auxdetails,
			scd.sysid_classroom AS sysid_classroom,
			scd.field_room AS field_room,
			scd.manual_schedule AS manual_schedule,
			scd.is_classroom AS is_classroom,
			scd.section AS section,
			sci.sysid_schedule AS sysid_schedule_auxserviceschedule,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,	
			sci.sysid_semester AS year_semester_id,
			si.sysid_subject AS sysid_subject_auxservice,
			si.department_id AS department_id,
			si.subject_code AS subject_service_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units_schedule,
			si.lab_units AS lab_units_schedule,
			si.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,				
			cg.group_no AS group_no,
			NULL AS classroom_code,
			cdsd.load_id AS load_id,
			cdsd.sysid_employee AS sysid_employee,
			cdsd.load_date AS load_date,
			cdsd.deload_date AS deload_date,
			cdsd.lecture_units AS lecture_units,
			cdsd.lab_units AS lab_units,
			cdsd.no_hours AS no_hours,
			cdsd.is_auxiliary AS is_auxiliary,
			cdsd.is_premature_deloaded AS is_premature_deloaded,			
			'' AS day_time
		FROM 
			ums.schedule_information_details AS scd
		INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_deloaded_schedule_details AS cdsd ON cdsd.sysid_scheddetails = scd.sysid_scheddetails
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(scd.sysid_classroom IS NULL)	
		UNION ALL					---------------------------------- auxiliary services --------------------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			clad.lecture_units AS lecture_units,
			clad.lab_units AS lab_units,
			clad.no_hours AS no_hours,			
			clad.is_auxiliary AS is_auxiliary,
			clad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(NOT clad.sysid_employee IS NULL)
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			clad.lecture_units AS lecture_units,
			clad.lab_units AS lab_units,
			clad.no_hours AS no_hours,			
			clad.is_auxiliary AS is_auxiliary,
			clad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0)	 AND
			(NOT clad.sysid_employee IS NULL)		
		UNION ALL						----------------------------- clad.sysid_employee IS NULL -------------------------------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			asd.lecture_units AS lecture_units,
			asd.lab_units AS lab_units,
			asd.no_hours AS no_hours,			
			'true' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		LEFT JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(clad.sysid_employee IS NULL) AND	
			(asi.department_id = @department_id)
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			clad.load_id AS load_id,
			clad.sysid_employee AS sysid_employee,
			clad.load_date AS load_date,
			clad.deload_date AS deload_date,
			asd.lecture_units AS lecture_units,
			asd.lab_units AS lab_units,
			asd.no_hours AS no_hours,			
			'true' AS is_auxiliary,
			'false' AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		LEFT JOIN cte_loaded_auxiliary_details AS clad ON clad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
			(asd.is_marked_deleted = 0) AND
			(clad.sysid_employee IS NULL) AND	
			(asi.department_id = @department_id)	
		UNION ALL						-------------------------pre-maturely deloaded auxiliary service schedule details ---------------------------------
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.year_id AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			cdad.load_id AS load_id,
			cdad.sysid_employee AS sysid_employee,
			cdad.load_date AS load_date,
			cdad.deload_date AS deload_date,
			cdad.lecture_units AS lecture_units,
			cdad.lab_units AS lab_units,
			cdad.no_hours AS no_hours,			
			cdad.is_auxiliary AS is_auxiliary,
			cdad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_deloaded_auxiliary_details AS cdad ON cdad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
		UNION ALL
		SELECT 
			asd.sysid_auxdetails AS sysid_scheddetails_auxdetails,
			NULL AS sysid_classroom,
			NULL AS field_room,
			NULL AS manual_schedule,
			NULL AS is_classroom,			
			NULL AS section,
			ass.sysid_auxserviceschedule AS sysid_schedule_auxserviceschedule,
			NULL AS is_team_teaching,
			NULL AS is_irregular_modular,
			ass.is_fixed_amount AS is_fixed_amount,
			ass.amount AS amount,
			ass.sysid_semester AS year_semester_id,
			asi.sysid_auxservice AS sysid_subject_auxservice,
			asi.department_id AS department_id,
			asi.service_code AS subject_service_code,
			asi.descriptive_title AS descriptive_title,
			asi.lecture_units AS lecture_units_schedule,
			asi.lab_units AS lab_units_schedule,
			asi.no_hours AS no_hours_schedule,
			di.department_name AS subject_auxiliary_department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			NULL AS classroom_code,	
			cdad.load_id AS load_id,
			cdad.sysid_employee AS sysid_employee,
			cdad.load_date AS load_date,
			cdad.deload_date AS deload_date,
			cdad.lecture_units AS lecture_units,
			cdad.lab_units AS lab_units,
			cdad.no_hours AS no_hours,			
			cdad.is_auxiliary AS is_auxiliary,
			cdad.is_premature_deloaded AS is_premature_deloaded,
			'' AS day_time
		FROM 
			ums.auxiliary_service_details AS asd
		INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
		INNER JOIN ums.auxiliary_service_information AS asi ON asi.sysid_auxservice = ass.sysid_auxservice
		INNER JOIN ums.department_information AS di ON di.department_id = asi.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = asi.course_group_id
		INNER JOIN cte_deloaded_auxiliary_details AS cdad ON cdad.sysid_auxdetails = asd.sysid_auxdetails
		WHERE
			(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))		
		ORDER BY 
			subject_service_code ASC
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a teacher load', 'Teacher Load'
		
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByDateStartEndForTeacherLoadingTeacherLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad')
   DROP PROCEDURE ums.SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad
GO

CREATE PROCEDURE ums.SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad

	@sysid_scheddetails_list varchar (50) = '',
	@sysid_employee varchar (50) = '',

	@system_user_id varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR (ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1))
		
	BEGIN

		SELECT 
			ssl_list.var_str AS sysid_scheddetails
		FROM
			ums.IterateListToTable (@sysid_scheddetails_list, ',') AS ssl_list 
		WHERE
			(ums.IsScheduleConflictsWithAnotherEmployeeLoadedSchedule(ssl_list.var_str, @sysid_employee) = 1)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a teacher load', 'Teacher Load'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsScheduleDetailsLoadedTeacher" function already exist
IF OBJECT_ID (N'ums.IsScheduleDetailsLoadedTeacher') IS NOT NULL
   DROP FUNCTION ums.IsScheduleDetailsLoadedTeacher
GO

CREATE FUNCTION ums.IsScheduleDetailsLoadedTeacher
(	
	@sysid_scheddetails varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	
	SET @result = 0

	IF EXISTS (SELECT 
					tl.sysid_scheddetails AS sysid_scheddetails 
				FROM 
					ums.teacher_load AS tl
				INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
				WHERE
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
					(tl.deload_date = sy.date_end) AND
					(tl.is_premature_deloaded = 0) AND
					(tl.sysid_scheddetails = @sysid_scheddetails)
				UNION
				SELECT 
					tl.sysid_scheddetails AS sysid_scheddetails 
				FROM 
					ums.teacher_load AS tl
				INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
				WHERE
					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
					(tl.deload_date = sri.date_end) AND
					(tl.is_premature_deloaded = 0) AND
					(tl.sysid_scheddetails = @sysid_scheddetails)
			  )
			
				
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsScheduleHasScheduleDetailsLoadedTeacher" function already exist
IF OBJECT_ID (N'ums.IsScheduleHasScheduleDetailsLoadedTeacher') IS NOT NULL
   DROP FUNCTION ums.IsScheduleHasScheduleDetailsLoadedTeacher
GO

CREATE FUNCTION ums.IsScheduleHasScheduleDetailsLoadedTeacher
(	
	@sysid_schedule varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	
	SET @result = 0

	IF EXISTS (SELECT 
					tl.sysid_scheddetails AS sysid_scheddetails 
				FROM 
					ums.teacher_load AS tl
				INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
				WHERE
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
					(tl.deload_date = sy.date_end) AND
					(tl.is_premature_deloaded = 0) AND
					(sci.sysid_schedule = @sysid_schedule)
				UNION
				SELECT 
					tl.sysid_scheddetails AS sysid_scheddetails 
				FROM 
					ums.teacher_load AS tl
				INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
				WHERE
					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
					(tl.deload_date = sri.date_end) AND
					(tl.is_premature_deloaded = 0) AND
					(sci.sysid_schedule = @sysid_schedule)
			  )
			
				
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsAuxiliaryDetailsLoadedTeacher" function already exist
IF OBJECT_ID (N'ums.IsAuxiliaryDetailsLoadedTeacher') IS NOT NULL
   DROP FUNCTION ums.IsAuxiliaryDetailsLoadedTeacher
GO

CREATE FUNCTION ums.IsAuxiliaryDetailsLoadedTeacher
(	
	@sysid_auxdetails varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	
	SET @result = 0

	IF EXISTS (SELECT 
					tl.sysid_auxdetails AS sysid_auxdetails 
				FROM 
					ums.teacher_load AS tl
				INNER JOIN ums.auxiliary_service_details AS asd ON asd.sysid_auxdetails = tl.sysid_auxdetails
				INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
				WHERE
					(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
					(tl.deload_date = sy.date_end) AND
					(tl.is_premature_deloaded = 0) AND
					(tl.sysid_auxdetails = @sysid_auxdetails)
				UNION
				SELECT 
					tl.sysid_auxdetails AS sysid_auxdetails 
				FROM 
					ums.teacher_load AS tl
				INNER JOIN ums.auxiliary_service_details AS asd ON asd.sysid_auxdetails = tl.sysid_auxdetails
				INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
				WHERE
					(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
					(tl.deload_date = sri.date_end) AND
					(tl.is_premature_deloaded = 0) AND
					(tl.sysid_auxdetails = @sysid_auxdetails)
			  )
			
				
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsScheduleHasAuxiliaryDetailsLoadedTeacher" function already exist
IF OBJECT_ID (N'ums.IsScheduleHasAuxiliaryDetailsLoadedTeacher') IS NOT NULL
   DROP FUNCTION ums.IsScheduleHasAuxiliaryDetailsLoadedTeacher
GO

CREATE FUNCTION ums.IsScheduleHasAuxiliaryDetailsLoadedTeacher
(	
	@sysid_auxserviceschedule varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	
	SET @result = 0

	IF EXISTS (SELECT 
					tl.sysid_auxdetails AS sysid_auxdetails 
				FROM 
					ums.teacher_load AS tl
				INNER JOIN ums.auxiliary_service_details AS asd ON asd.sysid_auxdetails = tl.sysid_auxdetails
				INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
				WHERE
					(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
					(tl.deload_date = sy.date_end) AND
					(tl.is_premature_deloaded = 0) AND
					(ass.sysid_auxserviceschedule = @sysid_auxserviceschedule)
				UNION
				SELECT 
					tl.sysid_auxdetails AS sysid_auxdetails 
				FROM 
					ums.teacher_load AS tl
				INNER JOIN ums.auxiliary_service_details AS asd ON asd.sysid_auxdetails = tl.sysid_auxdetails
				INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = asd.sysid_auxserviceschedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
				WHERE
					(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
					(tl.deload_date = sri.date_end) AND
					(tl.is_premature_deloaded = 0) AND
					(ass.sysid_auxserviceschedule = @sysid_auxserviceschedule)
			  )
			
				
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsScheduleAuxiliaryDetailsAlreadyLoadedTeacher" function already exist
IF OBJECT_ID (N'ums.IsScheduleAuxiliaryDetailsAlreadyLoadedTeacher') IS NOT NULL
   DROP FUNCTION ums.IsScheduleAuxiliaryDetailsAlreadyLoadedTeacher
GO

CREATE FUNCTION ums.IsScheduleAuxiliaryDetailsAlreadyLoadedTeacher
(	
	@sysid_scheddetails varchar (50) = '',
	@sysid_auxdetails varchar (50) = '',
	@sysid_employee varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	
	SET @result = 0

	IF EXISTS (SELECT 
					tl.sysid_scheddetails AS sysid_scheddetails_auxdetails
				FROM 
					ums.teacher_load AS tl
				INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
				WHERE
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
					(tl.deload_date = sy.date_end) AND
					(tl.is_premature_deloaded = 0) AND
					(tl.sysid_scheddetails = @sysid_scheddetails) AND
					(tl.sysid_employee = @sysid_employee)
				UNION
				SELECT 
					tl.sysid_scheddetails AS sysid_scheddetails_auxdetails 
				FROM 
					ums.teacher_load AS tl
				INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_scheddetails = tl.sysid_scheddetails
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
				WHERE
					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
					(tl.deload_date = sri.date_end) AND
					(tl.is_premature_deloaded = 0) AND
					(tl.sysid_scheddetails = @sysid_scheddetails) AND
					(tl.sysid_employee = @sysid_employee)
				UNION
				SELECT
					tl.sysid_auxdetails AS sysid_scheddetails_auxdetails
				FROM
					ums.teacher_load AS tl
				INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
				INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = ass.year_id
				WHERE
					(NOT ass.year_id IS NULL AND NOT ass.year_id = '') AND 
					(tl.deload_date = sy.date_end) AND
					(tl.is_premature_deloaded = 0) AND
					(tl.sysid_auxdetails = @sysid_auxdetails) AND
					(tl.sysid_employee = @sysid_employee)
				UNION
				SELECT
					tl.sysid_auxdetails AS sysid_scheddetails_auxdetails
				FROM
					ums.teacher_load AS tl
				INNER JOIN ums.auxiliary_service_details AS acd ON acd.sysid_auxdetails = tl.sysid_auxdetails
				INNER JOIN ums.auxiliary_service_schedule AS ass ON ass.sysid_auxserviceschedule = acd.sysid_auxserviceschedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = ass.sysid_semester
				WHERE
					(NOT ass.sysid_semester IS NULL AND NOT ass.sysid_semester = '') AND 
					(tl.deload_date = sri.date_end) AND
					(tl.is_premature_deloaded = 0) AND
					(tl.sysid_auxdetails = @sysid_auxdetails) AND
					(tl.sysid_employee = @sysid_employee)
			  )
			
				
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsScheduleConflictsWithAnotherEmployeeLoadedSchedule" function already exist
IF OBJECT_ID (N'ums.IsScheduleConflictsWithAnotherEmployeeLoadedSchedule') IS NOT NULL
   DROP FUNCTION ums.IsScheduleConflictsWithAnotherEmployeeLoadedSchedule
GO

CREATE FUNCTION ums.IsScheduleConflictsWithAnotherEmployeeLoadedSchedule
(	
	@sysid_scheddetails varchar (50) = '',
	@sysid_employee varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @add_months tinyint

	SELECT 
		@year_id = sci.year_id
	FROM
		ums.schedule_information AS sci
	INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_schedule = sci.sysid_schedule
	WHERE
		(scd.sysid_scheddetails = @sysid_scheddetails)

	IF (@year_id IS NULL)
	BEGIN

		SELECT 
			@year_id = sri.year_id,
			@sysid_semester = sci.sysid_semester
		FROM
			ums.schedule_information AS sci
		INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_schedule = sci.sysid_schedule
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		WHERE
			(scd.sysid_scheddetails = @sysid_scheddetails)

	END

	IF (@sysid_semester IS NULL)
	BEGIN
	
		SET @add_months = 1

		SELECT 
			@sysid_semester = sri.sysid_semester
		FROM
			ums.semester_information AS sri
		WHERE
			(sri.year_id = @year_id) AND
			(DATEADD(mm, @add_months, GETDATE()) >= sri.date_start) AND
			(DATEADD(mm, @add_months, GETDATE()) <= sri.date_end)
			
	END

	SET @result = 0

	IF EXISTS (SELECT TOP 1
					ss.schedule_id
				FROM
					ums.subject_schedule AS ss
				INNER JOIN
					(				--GET THE WEEK AND TIME ID OF THE YEARLY/SEMESTRAL BASED ON THE SCHEDULE DETAILS
						SELECT
							details_ss.schedule_id AS schedule_id,
							details_ss.week_id AS week_id,
							details_ss.time_id AS time_id
						FROM
							ums.subject_schedule AS details_ss
						INNER JOIN ums.schedule_information_details AS details_scd ON details_scd.sysid_scheddetails = details_ss.sysid_scheddetails
						WHERE
							(details_scd.sysid_scheddetails = @sysid_scheddetails)

					) AS ss_details ON ss_details.schedule_id = ss.schedule_id
				INNER JOIN
					(				--GET THE WEEK AND TIME ID OF THE YEARLY/SEMESTRAL LOADED SCHEDULE DETAILS OF AN INSTRUCTOR 
						SELECT
							inner_ss.week_id AS week_id,
							inner_ss.time_id AS time_id
						FROM
							ums.subject_schedule AS inner_ss
						INNER JOIN ums.schedule_information_details AS inner_scd ON inner_scd.sysid_scheddetails = inner_ss.sysid_scheddetails
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						INNER JOIN ums.teacher_load AS inner_tl ON inner_tl.sysid_scheddetails = inner_scd.sysid_scheddetails
						WHERE
							(inner_sci.year_id = @year_id) AND
							(inner_tl.sysid_employee = @sysid_employee)
						UNION ALL
						SELECT
							inner_ss.week_id AS week_id,
							inner_ss.time_id AS time_id
						FROM
							ums.subject_schedule AS inner_ss
						INNER JOIN ums.schedule_information_details AS inner_scd ON inner_scd.sysid_scheddetails = inner_ss.sysid_scheddetails
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						INNER JOIN ums.teacher_load AS inner_tl ON inner_tl.sysid_scheddetails = inner_scd.sysid_scheddetails
						WHERE
							(inner_sci.sysid_semester = @sysid_semester) AND
							(inner_tl.sysid_employee = @sysid_employee)

					) AS ss_week ON ss_week.week_id = ss_details.week_id AND ss_week.time_id = ss_details.time_id)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------


-- ################################################END TABLE "teacher_load" OBJECTS######################################################




-- ################################################TABLE "student_load" OBJECTS######################################################
-- verifies if the student_load table exists
IF OBJECT_ID('ums.student_load', 'U') IS NOT NULL
	DROP TABLE ums.student_load
GO

CREATE TABLE ums.student_load 			
(
	load_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Student_Load_Load_ID_PK PRIMARY KEY (load_id),
	sysid_enrolmentlevel varchar (50) NULL
		CONSTRAINT Student_Load_SysID_EnrolmentLevel_FK FOREIGN KEY REFERENCES ums.student_enrolment_level(sysid_enrolmentlevel) ON UPDATE NO ACTION
		CONSTRAINT Student_Load_SysID_EnrolmentLevel_UQ UNIQUE (sysid_enrolmentlevel, sysid_schedule, load_date),
	sysid_schedule varchar (50) NULL
		CONSTRAINT Student_Load_SysID_Schedule_FK FOREIGN KEY REFERENCES ums.schedule_information(sysid_schedule) ON UPDATE NO ACTION
		CONSTRAINT Student_Load_SysID_Schedule_UQ UNIQUE (sysid_schedule, sysid_enrolmentlevel, load_date),
	load_date datetime NOT NULL
		CONSTRAINT Student_Load_Load_Date_Start_CK CHECK (CONVERT(varchar, load_date, 109) LIKE '%12:00:00:000AM')
		CONSTRAINT Student_Load_Load_Date_Start_UQ UNIQUE (load_date, sysid_enrolmentlevel, sysid_schedule), 
	deload_date datetime NOT NULL
		CONSTRAINT Student_Load_Load_Date_End_CK CHECK (CONVERT(varchar, deload_date, 109) LIKE '%11:59:59:000PM'),

	lecture_units tinyint NOT NULL DEFAULT (0),
	lab_units tinyint NOT NULL DEFAULT (0),
	no_hours varchar (12) NOT NULL DEFAULT ('00:00')
		CONSTRAINT Student_Load_No_Hours_CK CHECK (no_hours LIKE '[0-9][0-9]:[0-5][0-9]'),

	is_premature_deloaded bit NOT NULL DEFAULT (0),

	is_for_permanent_delete bit NOT NULL DEFAULT (0),
	
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Student_Load_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Student_Load_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Student_Load_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the student_load table 
CREATE INDEX Student_Load_Load_ID_Index
	ON ums.student_load (load_id DESC)
GO
------------------------------------------------------------------

-- verifies if the procedure "InsertStudentLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertStudentLoad')
   DROP PROCEDURE ums.InsertStudentLoad
GO

CREATE PROCEDURE ums.InsertStudentLoad

	@sysid_enrolmentlevel varchar (50) = '',
	@sysid_schedule varchar (50) = '',

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@created_by) = 1) OR
		((ums.IsOfficeUserSystemUserInfo(@created_by) = 1) AND 
		((ums.IsUserSameDepartmentSubjectInfo((SELECT 
													si.sysid_subject
												FROM
													ums.subject_information AS si
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_subject = si.sysid_subject
												WHERE
													sci.sysid_schedule = @sysid_schedule), @created_by) = 1) OR
		 (ums.IsOpenAccessSubjectInfo((SELECT 
													si.sysid_subject
												FROM
													ums.subject_information AS si
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_subject = si.sysid_subject
												WHERE
													sci.sysid_schedule = @sysid_schedule)) = 1)))) AND
		(ums.IsScheduleInformationAlreadyLoadedStudent(@sysid_schedule, 
														(SELECT
																sec.sysid_student
															FROM
																ums.student_enrolment_course AS sec
															INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
															WHERE
																sel.sysid_enrolmentlevel = @sysid_enrolmentlevel)) = 0) AND 
		(ums.IsCurrentCourseStudentEnrolmentCo((SELECT 
													sysid_enrolmentcourse
												FROM
													ums.student_enrolment_level
												WHERE
													sysid_enrolmentlevel = @sysid_enrolmentlevel)) = 1) AND
		(((ums.IsClassroomBySysIDScheduleStudentLoad(@sysid_schedule) = 1) AND
		(ums.GetSlotsAvailableBySysIDScheduleStudentLoad(@sysid_schedule) > 0)) OR
		(ums.IsClassroomBySysIDScheduleStudentLoad(@sysid_schedule) = 0)) AND
		(ums.IsNotMarkedDeletedEnrolmentLev(@sysid_enrolmentlevel) = 1) AND
		(ums.IsScheduleConflictsWithAnotherStudentLoadedSchedule(@sysid_schedule, @sysid_enrolmentlevel) = 0) AND
		(ums.IsRecordLockByYearSemesterID((SELECT
												sfi.year_id
											FROM
												ums.school_fee_information AS sfi
											INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
											INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
											INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
											INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
											WHERE
												(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
												(cg.is_semestral = 0)
											UNION
											SELECT
												sel.sysid_semester
											FROM
												ums.student_enrolment_level AS sel
											INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
											INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
											WHERE
												(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
												(cg.is_semestral = 1))) = 0) AND
		(ums.IsRecordLockByYearSemesterID((SELECT
												sci.year_id
											FROM
												ums.schedule_information AS sci
											INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
											WHERE
												(sci.sysid_schedule = @sysid_schedule) AND
												(cg.is_semestral = 0)
											UNION
											SELECT
												sci.sysid_semester
											FROM
												ums.schedule_information AS sci
											INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
											WHERE
												(sci.sysid_schedule = @sysid_schedule) AND
												(cg.is_semestral = 1))) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.student_load
		(
			sysid_enrolmentlevel,
			sysid_schedule,
			created_by
		)
		VALUES
		(
			@sysid_enrolmentlevel,
			@sysid_schedule,
			@created_by
		)		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new student load', 'Student Load'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertStudentLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateStudentLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateStudentLoad')
   DROP PROCEDURE ums.UpdateStudentLoad
GO

CREATE PROCEDURE ums.UpdateStudentLoad

	@load_id bigint = 0,
	@is_premature_deloaded bit = 0,

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@edited_by) = 1) OR
		((ums.IsOfficeUserSystemUserInfo(@edited_by) = 1) AND 
		((ums.IsUserSameDepartmentSubjectInfo((SELECT 
													si.sysid_subject
												FROM
													ums.subject_information AS si
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_subject = si.sysid_subject
												INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
												WHERE
													sl.load_id = @load_id), @edited_by) = 1) OR
		 (ums.IsOpenAccessSubjectInfo((SELECT 
													si.sysid_subject
												FROM
													ums.subject_information AS si
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_subject = si.sysid_subject
												INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
												WHERE
													sl.load_id = @load_id)) = 1)))) AND
		(ums.IsNotMarkedDeletedEnrolmentLev((SELECT
													sysid_enrolmentlevel
												FROM
													ums.student_load
												WHERE
													load_id = @load_id)) = 1) AND
		(ums.IsScheduleConflictsWithAnotherStudentLoadedSchedule((SELECT
																		sysid_schedule
																	FROM 
																		ums.student_load
																	WHERE
																		load_id = @load_id), 
																	(SELECT
																		sysid_enrolmentlevel
																	FROM 
																		ums.student_load
																	WHERE
																		load_id = @load_id)) = 0) AND
		(ums.IsRecordLockByYearSemesterID((SELECT
												sfi.year_id
											FROM
												ums.school_fee_information AS sfi
											INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
											INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
											INNER JOIN ums.student_load AS sl ON sl.sysid_enrolmentlevel = sel.sysid_enrolmentlevel
											INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
											INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
											WHERE
												(sl.load_id = @load_id) AND
												(cg.is_semestral = 0)
											UNION
											SELECT
												sel.sysid_semester
											FROM
												ums.student_enrolment_level AS sel
											INNER JOIN ums.student_load AS sl ON sl.sysid_enrolmentlevel = sel.sysid_enrolmentlevel
											INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
											INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
											WHERE
												(sl.load_id = @load_id) AND
												(cg.is_semestral = 1))) = 0) AND
		(ums.IsRecordLockByYearSemesterID((SELECT
												sci.year_id
											FROM
												ums.schedule_information AS sci
											INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
											INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
											WHERE
												(sl.load_id = @load_id) AND
												(cg.is_semestral = 0)
											UNION
											SELECT
												sci.sysid_semester
											FROM
												ums.schedule_information AS sci
											INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
											INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
											WHERE
												(sl.load_id = @load_id) AND
												(cg.is_semestral = 1))) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.student_load SET
			is_premature_deloaded = @is_premature_deloaded,

			edited_by = @edited_by
		WHERE 
			load_id = @load_id
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update a student load', 'Student Load'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateStudentLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteStudentLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteStudentLoad')
   DROP PROCEDURE ums.DeleteStudentLoad
GO

CREATE PROCEDURE ums.DeleteStudentLoad

	@load_id bigint = 0,

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsVpOfAcademicAffairsSystemUserInfo(@deleted_by) = 1) OR
		((ums.IsOfficeUserSystemUserInfo(@deleted_by) = 1) AND 
		((ums.IsUserSameDepartmentSubjectInfo((SELECT 
													si.sysid_subject
												FROM
													ums.subject_information AS si
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_subject = si.sysid_subject
												INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
												WHERE
													sl.load_id = @load_id), @deleted_by) = 1) OR
		 (ums.IsOpenAccessSubjectInfo((SELECT 
													si.sysid_subject
												FROM
													ums.subject_information AS si
												INNER JOIN ums.schedule_information AS sci ON sci.sysid_subject = si.sysid_subject
												INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
												WHERE
													sl.load_id = @load_id)) = 1)))) AND		
		(ums.IsPrematureDeloadedStudentLoad(@load_id) = 0) AND
		(ums.IsNotMarkedDeletedEnrolmentLev((SELECT
													sysid_enrolmentlevel
												FROM
													ums.student_load
												WHERE
													load_id = @load_id)) = 1) AND
		(ums.IsRecordLockByYearSemesterID((SELECT
												sfi.year_id
											FROM
												ums.school_fee_information AS sfi
											INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
											INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
											INNER JOIN ums.student_load AS sl ON sl.sysid_enrolmentlevel = sel.sysid_enrolmentlevel
											INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
											INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
											WHERE
												(sl.load_id = @load_id) AND
												(cg.is_semestral = 0)
											UNION
											SELECT
												sel.sysid_semester
											FROM
												ums.student_enrolment_level AS sel
											INNER JOIN ums.student_load AS sl ON sl.sysid_enrolmentlevel = sel.sysid_enrolmentlevel
											INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
											INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
											WHERE
												(sl.load_id = @load_id) AND
												(cg.is_semestral = 1))) = 0) AND
		(ums.IsRecordLockByYearSemesterID((SELECT
												sci.year_id
											FROM
												ums.schedule_information AS sci
											INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
											INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
											WHERE
												(sl.load_id = @load_id) AND
												(cg.is_semestral = 0)
											UNION
											SELECT
												sci.sysid_semester
											FROM
												ums.schedule_information AS sci
											INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
											INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
											WHERE
												(sl.load_id = @load_id) AND
												(cg.is_semestral = 1))) = 0)
	BEGIN

		IF EXISTS (SELECT load_id FROM ums.student_load WHERE load_id = @load_id)
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.student_load SET
				edited_by = @deleted_by
			WHERE 
				load_id = @load_id

			DELETE FROM ums.student_load WHERE load_id = @load_id

		END		
		
	END
	ELSE IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR
		(((ums.IsCashierSystemUserInfo(@deleted_by) = 1) OR 
		(ums.IsVpOfFinanceSystemUserInfo(@deleted_by) = 1)) AND
		(ums.IsRecordLockByYearSemesterID((SELECT
												sfi.year_id
											FROM
												ums.school_fee_information AS sfi
											INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
											INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
											INNER JOIN ums.student_load AS sl ON sl.sysid_enrolmentlevel = sel.sysid_enrolmentlevel
											INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
											INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
											WHERE
												(sl.load_id = @load_id) AND
												(cg.is_semestral = 0)
											UNION
											SELECT
												sel.sysid_semester
											FROM
												ums.student_enrolment_level AS sel
											INNER JOIN ums.student_load AS sl ON sl.sysid_enrolmentlevel = sel.sysid_enrolmentlevel
											INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
											INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
											WHERE
												(sl.load_id = @load_id) AND
												(cg.is_semestral = 1))) = 0) AND
		(ums.IsRecordLockByYearSemesterID((SELECT
												sci.year_id
											FROM
												ums.schedule_information AS sci
											INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
											INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
											WHERE
												(sl.load_id = @load_id) AND
												(cg.is_semestral = 0)
											UNION
											SELECT
												sci.sysid_semester
											FROM
												ums.schedule_information AS sci
											INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
											INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
											WHERE
												(sl.load_id = @load_id) AND
												(cg.is_semestral = 1))) = 0))) AND 
		(ums.IsPrematureDeloadedStudentLoad(@load_id) = 1) 
	BEGIN

		IF EXISTS (SELECT load_id FROM ums.student_load WHERE load_id = @load_id)
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.student_load SET
				is_for_permanent_delete = 1,
				edited_by = @deleted_by
			WHERE 
				load_id = @load_id

			DELETE FROM ums.student_load WHERE load_id = @load_id

		END	

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Deleted a student load', 'Student Load'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteStudentLoad TO db_umsusers
GO
-------------------------------------------------------------

--##########################################OLD CODE########################################################################################

---- verifies if the procedure "SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad" exist
--IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad')
--   DROP PROCEDURE ums.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad
--GO

--CREATE PROCEDURE ums.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad

--	@sysid_student varchar (50) = '',
--	@sysid_enrolmentlevel varchar (50) = '',
--	@sysid_feelevel varchar (50) = '',
--	@sysid_semester varchar (50) = '',
--	@is_graduate_student bit = 0,
--	@is_international bit = 0,
--	@is_enrolled bit = 0,
--	@is_for_student_tab bit = 0,
--	@date_start datetime,
--	@date_end datetime,

--	@system_user_id varchar (50) = ''
		
--AS

--	DECLARE @tuition_amount decimal (12, 2)
--	DECLARE @is_semestral bit

--	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
--		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
--		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
--		(ums.IsCashierSystemUserInfo(@system_user_id) = 1) OR
--		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
--		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
--		(ums.IsStudentDataControllerSystemUserInfo(@system_user_id) = 1) OR 
--		(ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
--	BEGIN

--		SELECT															--this will be used to get the total subject amount as one of the parameters 
--			@is_semestral = CASE WHEN (cg.is_semestral IS NULL)			--for the subjects that has not been loaded yet.
--								THEN									
--									(0)
--								ELSE
--									(cg.is_semestral)
--								END
--		FROM
--			ums.course_group AS cg
--		INNER JOIN ums.course_information AS ci ON ci.course_group_id = cg.course_group_id
--		INNER JOIN ums.student_enrolment_course AS sec ON sec.course_id = ci.course_id
--		WHERE
--			(sec.sysid_student = @sysid_student) AND
--			(sec.is_current_course = 1);

--		SELECT
--			@tuition_amount = amount
--		FROM
--			ums.GetBySysIDStudentFeeLevelSemesterFeeDetails(@sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
--						@is_graduate_student, @is_international, @is_enrolled, 0)
--		WHERE
--			(category_no = 1)
--		ORDER BY
--			category_no, particular_description ASC;

--		IF (@is_for_student_tab = 0)
--		BEGIN

--			WITH cte_loaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
--					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
--			(
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
--					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
--					(sl.deload_date = sy.date_end) AND
--					(sl.is_premature_deloaded = 0) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--				UNION ALL
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
--					(sl.deload_date = sri.date_end) AND
--					(sl.is_premature_deloaded = 0) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--			),
--			cte_deloaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
--					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
--			(
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(sci.is_marked_deleted = 0) AND
--					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
--					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
--					(sl.is_premature_deloaded = 1) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--				UNION ALL
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(sci.is_marked_deleted = 0) AND
--					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
--					(sl.is_premature_deloaded = 1) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--			)

--			SELECT						-- LOADED YEARLY SUBJECT SCHEDULE (no marked deleted in the schedule to include pre.mature deloads on student loads)-------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.year_id AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				clsi.load_id AS load_id,
--				clsi.load_date AS load_date,
--				clsi.deload_date AS deload_date,
--				clsi.lecture_units AS load_lecture_units,
--				clsi.lab_units AS load_lab_units,
--				clsi.no_hours AS load_no_hours,
--				clsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				ums.GetSlotsAvailableBySysIDScheduleStudentLoad(sci.sysid_schedule) AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, clsi.lecture_units, 
--					clsi.lab_units, sci.is_fixed_amount, clsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
--				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						-- LOADED BY SEMESTER SUBJECT SCHEDULE -------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.sysid_semester AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				clsi.load_id AS load_id,
--				clsi.load_date AS load_date,
--				clsi.deload_date AS deload_date,
--				clsi.lecture_units AS load_lecture_units,
--				clsi.lab_units AS load_lab_units,
--				clsi.no_hours AS load_no_hours,
--				clsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				ums.GetSlotsAvailableBySysIDScheduleStudentLoad(sci.sysid_schedule) AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, clsi.lecture_units, 
--					clsi.lab_units, sci.is_fixed_amount, clsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						------------- PREMATURELY DELOADED YEARLY SUBJECT SCHEDULE --------------------------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.year_id AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				cdsi.load_id AS load_id,
--				cdsi.load_date AS load_date,
--				cdsi.deload_date AS deload_date,
--				cdsi.lecture_units AS load_lecture_units,
--				cdsi.lab_units AS load_lab_units,
--				cdsi.no_hours AS load_no_hours,
--				cdsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				ums.GetSlotsAvailableBySysIDScheduleStudentLoad(sci.sysid_schedule) AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, cdsi.lecture_units, 
--					cdsi.lab_units, sci.is_fixed_amount, cdsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
--				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						-- PREMATURELY DELOADED BY SEMESTER SUBJECT SCHEDULE -------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.sysid_semester AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				cdsi.load_id AS load_id,
--				cdsi.load_date AS load_date,
--				cdsi.deload_date AS deload_date,
--				cdsi.lecture_units AS load_lecture_units,
--				cdsi.lab_units AS load_lab_units,
--				cdsi.no_hours AS load_no_hours,
--				cdsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				ums.GetSlotsAvailableBySysIDScheduleStudentLoad(sci.sysid_schedule) AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, cdsi.lecture_units, 
--					cdsi.lab_units, sci.is_fixed_amount, cdsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						-- NOT LOADED YEARLY SUBJECT SCHEDULE -------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.year_id AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				clsi.load_id AS load_id,
--				clsi.load_date AS load_date,
--				clsi.deload_date AS deload_date,
--				clsi.lecture_units AS load_lecture_units,
--				clsi.lab_units AS load_lab_units,
--				clsi.no_hours AS load_no_hours,
--				'false' AS is_premature_deloaded,
--				'false' AS is_loaded_to_student,
--				ums.GetSlotsAvailableBySysIDScheduleStudentLoad(sci.sysid_schedule) AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, clsi.lecture_units, 
--					clsi.lab_units, sci.is_fixed_amount, clsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			LEFT JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
--			LEFT JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
--				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
--				(sci.is_marked_deleted = 0) AND
--				(clsi.load_id IS NULL) AND
--				(cdsi.load_id IS NULL)
--			UNION ALL
--			SELECT						-- NOT LOADED BY SEMESTER SUBJECT SCHEDULE -------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.sysid_semester AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				clsi.load_id AS load_id,
--				clsi.load_date AS load_date,
--				clsi.deload_date AS deload_date,
--				clsi.lecture_units AS load_lecture_units,
--				clsi.lab_units AS load_lab_units,
--				clsi.no_hours AS load_no_hours,
--				'false' AS is_premature_deloaded,
--				'false' AS is_loaded_to_student,
--				ums.GetSlotsAvailableBySysIDScheduleStudentLoad(sci.sysid_schedule) AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, clsi.lecture_units, 
--					clsi.lab_units, sci.is_fixed_amount, clsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			LEFT JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
--			LEFT JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
--				(sci.is_marked_deleted = 0) AND
--				(clsi.load_id IS NULL) AND
--				(cdsi.load_id IS NULL)				
--			ORDER BY 
--				subject_code, sysid_schedule ASC

--		END
--		ELSE
--		BEGIN

--			WITH cte_loaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
--					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
--			(
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
--					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
--					(sl.deload_date = sy.date_end) AND
--					(sl.is_premature_deloaded = 0) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--				UNION ALL
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
--					(sl.deload_date = sri.date_end) AND
--					(sl.is_premature_deloaded = 0) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--			),
--			cte_deloaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
--					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
--			(
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(sci.is_marked_deleted = 0) AND
--					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
--					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
--					(sl.is_premature_deloaded = 1) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--				UNION ALL
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(sci.is_marked_deleted = 0) AND
--					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
--					(sl.is_premature_deloaded = 1) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--			)

--			SELECT						-- LOADED YEARLY SUBJECT SCHEDULE (no marked deleted in the schedule to include pre.mature deloads on student loads)-------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.year_id AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				clsi.load_id AS load_id,
--				clsi.load_date AS load_date,
--				clsi.deload_date AS deload_date,
--				clsi.lecture_units AS load_lecture_units,
--				clsi.lab_units AS load_lab_units,
--				clsi.no_hours AS load_no_hours,
--				clsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				0 AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, clsi.lecture_units, 
--					clsi.lab_units, sci.is_fixed_amount, clsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
--				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						-- LOADED BY SEMESTER SUBJECT SCHEDULE -------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.sysid_semester AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				clsi.load_id AS load_id,
--				clsi.load_date AS load_date,
--				clsi.deload_date AS deload_date,
--				clsi.lecture_units AS load_lecture_units,
--				clsi.lab_units AS load_lab_units,
--				clsi.no_hours AS load_no_hours,
--				clsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				0 AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, clsi.lecture_units, 
--					clsi.lab_units, sci.is_fixed_amount, clsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						------------- PREMATURELY DELOADED YEARLY SUBJECT SCHEDULE --------------------------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.year_id AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				cdsi.load_id AS load_id,
--				cdsi.load_date AS load_date,
--				cdsi.deload_date AS deload_date,
--				cdsi.lecture_units AS load_lecture_units,
--				cdsi.lab_units AS load_lab_units,
--				cdsi.no_hours AS load_no_hours,
--				cdsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				0 AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, cdsi.lecture_units, 
--					cdsi.lab_units, sci.is_fixed_amount, cdsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
--				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						-- PREMATURELY DELOADED BY SEMESTER SUBJECT SCHEDULE -------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.sysid_semester AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				cdsi.load_id AS load_id,
--				cdsi.load_date AS load_date,
--				cdsi.deload_date AS deload_date,
--				cdsi.lecture_units AS load_lecture_units,
--				cdsi.lab_units AS load_lab_units,
--				cdsi.no_hours AS load_no_hours,
--				cdsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				0 AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, cdsi.lecture_units, 
--					cdsi.lab_units, sci.is_fixed_amount, cdsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))						
--			ORDER BY 
--				subject_code, sysid_schedule ASC

--		END
		
--	END	
--	ELSE IF (ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1)      
--	BEGIN

--		DECLARE @department_id varchar (50)

--		SELECT 
--			@department_id = arg.department_id 
--		FROM
--			ums.access_rights_granted AS arg
--		INNER JOIN ums.system_user_info AS sui ON sui.system_user_id = arg.system_user_id
--		WHERE
--			(arg.access_rights = '@7W_*xAuIz%qTm^rYmq!a38&z#s{>zX2*pUw[#Z@') AND
--			(sui.system_user_id = @system_user_id);

--		SELECT															--this will be used to get the total subject amount as one of the parameters 
--			@is_semestral = CASE WHEN (cg.is_semestral IS NULL)			--for the subjects that has not been loaded yet.
--								THEN									
--									(0)
--								ELSE
--									(cg.is_semestral)
--								END
--		FROM
--			ums.course_group AS cg
--		INNER JOIN ums.course_information AS ci ON ci.course_group_id = cg.course_group_id
--		INNER JOIN ums.student_enrolment_course AS sec ON sec.course_id = ci.course_id
--		WHERE
--			(sec.sysid_student = @sysid_student) AND
--			(sec.is_current_course = 1);

--		SELECT
--			@tuition_amount = amount
--		FROM
--			ums.GetBySysIDStudentFeeLevelSemesterFeeDetails(@sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
--						@is_graduate_student, @is_international, @is_enrolled, 0)
--		WHERE
--			(category_no = 1)
--		ORDER BY
--			category_no, particular_description ASC;

--		IF (@is_for_student_tab = 0)
--		BEGIN

--			WITH cte_loaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
--					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
--			(
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
--					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
--					(sl.deload_date = sy.date_end) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--				UNION ALL
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
--					(sl.deload_date = sri.date_end) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--			),
--			cte_deloaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
--					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
--			(
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(sci.is_marked_deleted = 0) AND
--					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
--					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
--					(sl.is_premature_deloaded = 1) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--				UNION ALL
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(sci.is_marked_deleted = 0) AND
--					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
--					(sl.is_premature_deloaded = 1) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--			)

--			SELECT						-- LOADED YEARLY SUBJECT SCHEDULE (no marked deleted in the schedule to include pre.mature deloads on student loads)-------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.year_id AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				clsi.load_id AS load_id,
--				clsi.load_date AS load_date,
--				clsi.deload_date AS deload_date,
--				clsi.lecture_units AS load_lecture_units,
--				clsi.lab_units AS load_lab_units,
--				clsi.no_hours AS load_no_hours,
--				clsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				ums.GetSlotsAvailableBySysIDScheduleStudentLoad(sci.sysid_schedule) AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, clsi.lecture_units, 
--					clsi.lab_units, sci.is_fixed_amount, clsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
--				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						-- LOADED BY SEMESTER SUBJECT SCHEDULE -------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.sysid_semester AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				clsi.load_id AS load_id,
--				clsi.load_date AS load_date,
--				clsi.deload_date AS deload_date,
--				clsi.lecture_units AS load_lecture_units,
--				clsi.lab_units AS load_lab_units,
--				clsi.no_hours AS load_no_hours,
--				clsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				ums.GetSlotsAvailableBySysIDScheduleStudentLoad(sci.sysid_schedule) AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, clsi.lecture_units, 
--					clsi.lab_units, sci.is_fixed_amount, clsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						------------- PREMATURELY DELOADED YEARLY SUBJECT SCHEDULE --------------------------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.year_id AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				cdsi.load_id AS load_id,
--				cdsi.load_date AS load_date,
--				cdsi.deload_date AS deload_date,
--				cdsi.lecture_units AS load_lecture_units,
--				cdsi.lab_units AS load_lab_units,
--				cdsi.no_hours AS load_no_hours,
--				cdsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				ums.GetSlotsAvailableBySysIDScheduleStudentLoad(sci.sysid_schedule) AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, cdsi.lecture_units, 
--					cdsi.lab_units, sci.is_fixed_amount, cdsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
--				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						-- PREMATURELY DELOADED BY SEMESTER SUBJECT SCHEDULE -------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.sysid_semester AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				cdsi.load_id AS load_id,
--				cdsi.load_date AS load_date,
--				cdsi.deload_date AS deload_date,
--				cdsi.lecture_units AS load_lecture_units,
--				cdsi.lab_units AS load_lab_units,
--				cdsi.no_hours AS load_no_hours,
--				cdsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				ums.GetSlotsAvailableBySysIDScheduleStudentLoad(sci.sysid_schedule) AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, cdsi.lecture_units, 
--					cdsi.lab_units, sci.is_fixed_amount, cdsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						-- NOT LOADED YEARLY SUBJECT SCHEDULE -------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.year_id AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				clsi.load_id AS load_id,
--				clsi.load_date AS load_date,
--				clsi.deload_date AS deload_date,
--				clsi.lecture_units AS load_lecture_units,
--				clsi.lab_units AS load_lab_units,
--				clsi.no_hours AS load_no_hours,
--				'false' AS is_premature_deloaded,
--				'false' AS is_loaded_to_student,
--				ums.GetSlotsAvailableBySysIDScheduleStudentLoad(sci.sysid_schedule) AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, clsi.lecture_units, 
--					clsi.lab_units, sci.is_fixed_amount, clsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			LEFT JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
--			LEFT JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
--				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
--				(sci.is_marked_deleted = 0) AND
--				(clsi.load_id IS NULL) AND
--				(cdsi.load_id IS NULL) AND
--				(si.department_id = @department_id)
--			UNION ALL
--			SELECT						-- NOT LOADED BY SEMESTER SUBJECT SCHEDULE -------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.sysid_semester AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				clsi.load_id AS load_id,
--				clsi.load_date AS load_date,
--				clsi.deload_date AS deload_date,
--				clsi.lecture_units AS load_lecture_units,
--				clsi.lab_units AS load_lab_units,
--				clsi.no_hours AS load_no_hours,
--				'false' AS is_premature_deloaded,
--				'false' AS is_loaded_to_student,
--				ums.GetSlotsAvailableBySysIDScheduleStudentLoad(sci.sysid_schedule) AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, clsi.lecture_units, 
--					clsi.lab_units, sci.is_fixed_amount, clsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			LEFT JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
--			LEFT JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
--				(sci.is_marked_deleted = 0) AND
--				(clsi.load_id IS NULL) AND
--				(cdsi.load_id IS NULL) AND
--				(si.department_id = @department_id)				
--			ORDER BY 
--				subject_code, sysid_schedule ASC

--		END
--		ELSE
--		BEGIN

--			WITH cte_loaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
--					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
--			(
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
--					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
--					(sl.deload_date = sy.date_end) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--				UNION ALL
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
--					(sl.deload_date = sri.date_end) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--			),
--			cte_deloaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
--					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
--			(
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(sci.is_marked_deleted = 0) AND
--					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
--					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
--					(sl.is_premature_deloaded = 1) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--				UNION ALL
--				SELECT
--					sl.load_id AS load_id,
--					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
--					sl.sysid_schedule AS sysid_schedule,
--					sl.load_date AS load_date,
--					sl.deload_date AS deload_date,
--					sl.lecture_units AS lecture_units,
--					sl.lab_units AS lab_units,
--					sl.no_hours AS no_hours,
--					sl.is_premature_deloaded AS is_premature_deloaded,
--					cg.is_semestral
--				FROM
--					ums.student_load AS sl
--				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
--				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
--				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
--				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
--				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--				WHERE
--					(sci.is_marked_deleted = 0) AND
--					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
--					(sl.is_premature_deloaded = 1) AND
--					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
--			)

--			SELECT						-- LOADED YEARLY SUBJECT SCHEDULE (no marked deleted in the schedule to include pre.mature deloads on student loads)-------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.year_id AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				clsi.load_id AS load_id,
--				clsi.load_date AS load_date,
--				clsi.deload_date AS deload_date,
--				clsi.lecture_units AS load_lecture_units,
--				clsi.lab_units AS load_lab_units,
--				clsi.no_hours AS load_no_hours,
--				clsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				0 AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, clsi.lecture_units, 
--					clsi.lab_units, sci.is_fixed_amount, clsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
--				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						-- LOADED BY SEMESTER SUBJECT SCHEDULE -------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.sysid_semester AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				clsi.load_id AS load_id,
--				clsi.load_date AS load_date,
--				clsi.deload_date AS deload_date,
--				clsi.lecture_units AS load_lecture_units,
--				clsi.lab_units AS load_lab_units,
--				clsi.no_hours AS load_no_hours,
--				clsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				0 AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, clsi.lecture_units, 
--					clsi.lab_units, sci.is_fixed_amount, clsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						------------- PREMATURELY DELOADED YEARLY SUBJECT SCHEDULE --------------------------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.year_id AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				cdsi.load_id AS load_id,
--				cdsi.load_date AS load_date,
--				cdsi.deload_date AS deload_date,
--				cdsi.lecture_units AS load_lecture_units,
--				cdsi.lab_units AS load_lab_units,
--				cdsi.no_hours AS load_no_hours,
--				cdsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				0 AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, cdsi.lecture_units, 
--					cdsi.lab_units, sci.is_fixed_amount, cdsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
--				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
--				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
--			UNION ALL
--			SELECT						-- PREMATURELY DELOADED BY SEMESTER SUBJECT SCHEDULE -------------------
--				sci.sysid_schedule AS sysid_schedule,
--				sci.sysid_subject AS sysid_subject,
--				sci.sysid_semester AS year_semester_id,
--				sci.is_team_teaching AS is_team_teaching,
--				sci.is_irregular_modular AS is_irregular_modular,
--				sci.is_fixed_amount AS is_fixed_amount,
--				sci.amount AS amount,
--				sci.additional_slots AS additional_slots,
--				(SELECT
--						MIN(ci.maximum_capacity)
--					FROM
--						ums.classroom_information AS ci
--					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
--					WHERE
--						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
--				si.subject_code AS subject_code,
--				si.descriptive_title AS descriptive_title,
--				si.lecture_units AS subject_lecture_units,
--				si.lab_units AS subject_lab_units,
--				si.no_hours AS subject_no_hours,
--				si.is_non_academic AS is_non_academic,
--				di.department_name AS department_name,
--				cg.is_semestral AS is_semestral,
--				cg.group_no AS group_no,
--				cdsi.load_id AS load_id,
--				cdsi.load_date AS load_date,
--				cdsi.deload_date AS deload_date,
--				cdsi.lecture_units AS load_lecture_units,
--				cdsi.lab_units AS load_lab_units,
--				cdsi.no_hours AS load_no_hours,
--				cdsi.is_premature_deloaded AS is_premature_deloaded,
--				'true' AS is_loaded_to_student,
--				0 AS slots_available,
--				ums.GetSubjectAmountByLoadUnitsStudentLoad(@tuition_amount, sci.sysid_schedule, cdsi.lecture_units, 
--					cdsi.lab_units, sci.is_fixed_amount, cdsi.is_semestral) AS subject_amount
--			FROM
--				ums.schedule_information AS sci
--			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
--			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
--			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
--			WHERE
--				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
--				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
--				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))			
--			ORDER BY 
--				subject_code, sysid_schedule ASC

--		END

--	END
--	ELSE
--	BEGIN
--		EXECUTE ums.ShowErrorMsg 'Query a student load', 'Student Load'
		
--	END
	
--GO
-----------------------------------------------------------

---- grant permission on the stored procedure
--GRANT EXECUTE ON ums.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad TO db_umsusers
--GO
---------------------------------------------------------------

--##########################################OLD CODE########################################################################################


-- verifies if the procedure "SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad')
   DROP PROCEDURE ums.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad
GO

CREATE PROCEDURE ums.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad

	@sysid_student varchar (50) = '',
	@sysid_enrolmentlevel varchar (50) = '',
	@sysid_feelevel varchar (50) = '',
	@sysid_semester varchar (50) = '',
	@is_graduate_student bit = 0,
	@is_international bit = 0,
	@is_enrolled bit = 0,
	@is_for_student_tab bit = 0,
	@date_start datetime,
	@date_end datetime,

	@system_user_id varchar (50) = ''
		
AS

	DECLARE @tuition_amount decimal (12, 2)
	DECLARE @is_semestral bit

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsStudentDataControllerSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT															--this will be used to get the total subject amount as one of the parameters 
			@is_semestral = CASE WHEN (cg.is_semestral IS NULL)			--for the subjects that has not been loaded yet.
								THEN									
									(0)
								ELSE
									(cg.is_semestral)
								END
		FROM
			ums.course_group AS cg
		INNER JOIN ums.course_information AS ci ON ci.course_group_id = cg.course_group_id
		INNER JOIN ums.student_enrolment_course AS sec ON sec.course_id = ci.course_id
		WHERE
			(sec.sysid_student = @sysid_student) AND
			(sec.is_current_course = 1);

		SELECT
			@tuition_amount = amount
		FROM
			ums.GetBySysIDStudentFeeLevelSemesterFeeDetails(@sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
						@is_graduate_student, @is_international, @is_enrolled, 0)
		WHERE
			(category_no = 1)
		ORDER BY
			category_no, particular_description ASC;

		IF (@is_for_student_tab = 0)
		BEGIN

			WITH cte_loaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
			(
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
					(sl.deload_date = sy.date_end) AND
					(sl.is_premature_deloaded = 0) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
				UNION ALL
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
					(sl.deload_date = sri.date_end) AND
					(sl.is_premature_deloaded = 0) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
			),
			cte_deloaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
			(
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(sci.is_marked_deleted = 0) AND
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
					(sl.is_premature_deloaded = 1) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
				UNION ALL
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(sci.is_marked_deleted = 0) AND
					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
					(sl.is_premature_deloaded = 1) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
			)

			SELECT						-- LOADED YEARLY SUBJECT SCHEDULE (no marked deleted in the schedule to include pre.mature deloads on student loads)-------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.year_id AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				clsi.load_id AS load_id,
				clsi.load_date AS load_date,
				clsi.deload_date AS deload_date,
				clsi.lecture_units AS load_lecture_units,
				clsi.lab_units AS load_lab_units,
				clsi.no_hours AS load_no_hours,
				clsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				
				ISNULL((SELECT
							(MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0)
						FROM
							ums.schedule_information_details AS inner_scd
						INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						LEFT JOIN 
						(
							SELECT	
								t_sl.sysid_schedule AS sysid_schedule,
								COUNT(t_sl.load_id) AS student_count
							FROM
								ums.student_load AS t_sl 
							WHERE 
								(t_sl.sysid_schedule = sci.sysid_schedule) AND
								(t_sl.is_premature_deloaded = 0)
							GROUP BY
								t_sl.sysid_schedule
								
						) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						WHERE
							(inner_sci.sysid_schedule = sci.sysid_schedule) AND
							(inner_scd.is_marked_deleted = 0)
						GROUP BY
							inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count), -32768) AS slots_available,
							
				CASE WHEN ((NOT clsi.lecture_units IS NULL) AND (NOT clsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((clsi.lecture_units + clsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						-- LOADED BY SEMESTER SUBJECT SCHEDULE -------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.sysid_semester AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				clsi.load_id AS load_id,
				clsi.load_date AS load_date,
				clsi.deload_date AS deload_date,
				clsi.lecture_units AS load_lecture_units,
				clsi.lab_units AS load_lab_units,
				clsi.no_hours AS load_no_hours,
				clsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				
				ISNULL((SELECT
							(MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0)
						FROM
							ums.schedule_information_details AS inner_scd
						INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						LEFT JOIN 
						(
							SELECT	
								t_sl.sysid_schedule AS sysid_schedule,
								COUNT(t_sl.load_id) AS student_count
							FROM
								ums.student_load AS t_sl 
							WHERE 
								(t_sl.sysid_schedule = sci.sysid_schedule) AND
								(t_sl.is_premature_deloaded = 0)
							GROUP BY
								t_sl.sysid_schedule
								
						) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						WHERE
							(inner_sci.sysid_schedule = sci.sysid_schedule) AND
							(inner_scd.is_marked_deleted = 0)
						GROUP BY
							inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count), -32768) AS slots_available,
							
				CASE WHEN ((NOT clsi.lecture_units IS NULL) AND (NOT clsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((clsi.lecture_units + clsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						------------- PREMATURELY DELOADED YEARLY SUBJECT SCHEDULE --------------------------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.year_id AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				cdsi.load_id AS load_id,
				cdsi.load_date AS load_date,
				cdsi.deload_date AS deload_date,
				cdsi.lecture_units AS load_lecture_units,
				cdsi.lab_units AS load_lab_units,
				cdsi.no_hours AS load_no_hours,
				cdsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				
				ISNULL((SELECT
							(MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0)
						FROM
							ums.schedule_information_details AS inner_scd
						INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						LEFT JOIN 
						(
							SELECT	
								t_sl.sysid_schedule AS sysid_schedule,
								COUNT(t_sl.load_id) AS student_count
							FROM
								ums.student_load AS t_sl 
							WHERE 
								(t_sl.sysid_schedule = sci.sysid_schedule) AND
								(t_sl.is_premature_deloaded = 0)
							GROUP BY
								t_sl.sysid_schedule
								
						) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						WHERE
							(inner_sci.sysid_schedule = sci.sysid_schedule) AND
							(inner_scd.is_marked_deleted = 0)
						GROUP BY
							inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count), -32768) AS slots_available,
							
				CASE WHEN ((NOT cdsi.lecture_units IS NULL) AND (NOT cdsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((cdsi.lecture_units + cdsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						-- PREMATURELY DELOADED BY SEMESTER SUBJECT SCHEDULE -------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.sysid_semester AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				cdsi.load_id AS load_id,
				cdsi.load_date AS load_date,
				cdsi.deload_date AS deload_date,
				cdsi.lecture_units AS load_lecture_units,
				cdsi.lab_units AS load_lab_units,
				cdsi.no_hours AS load_no_hours,
				cdsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				
				ISNULL((SELECT
							(MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0)
						FROM
							ums.schedule_information_details AS inner_scd
						INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						LEFT JOIN 
						(
							SELECT	
								t_sl.sysid_schedule AS sysid_schedule,
								COUNT(t_sl.load_id) AS student_count
							FROM
								ums.student_load AS t_sl 
							WHERE 
								(t_sl.sysid_schedule = sci.sysid_schedule) AND
								(t_sl.is_premature_deloaded = 0)
							GROUP BY
								t_sl.sysid_schedule
								
						) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						WHERE
							(inner_sci.sysid_schedule = sci.sysid_schedule) AND
							(inner_scd.is_marked_deleted = 0)
						GROUP BY
							inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count), -32768) AS slots_available,
							
				CASE WHEN ((NOT cdsi.lecture_units IS NULL) AND (NOT cdsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((cdsi.lecture_units + cdsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						-- NOT LOADED YEARLY SUBJECT SCHEDULE -------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.year_id AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				clsi.load_id AS load_id,
				clsi.load_date AS load_date,
				clsi.deload_date AS deload_date,
				clsi.lecture_units AS load_lecture_units,
				clsi.lab_units AS load_lab_units,
				clsi.no_hours AS load_no_hours,
				'false' AS is_premature_deloaded,
				'false' AS is_loaded_to_student,
				
				ISNULL((SELECT
							(MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0)
						FROM
							ums.schedule_information_details AS inner_scd
						INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						LEFT JOIN 
						(
							SELECT	
								t_sl.sysid_schedule AS sysid_schedule,
								COUNT(t_sl.load_id) AS student_count
							FROM
								ums.student_load AS t_sl 
							WHERE 
								(t_sl.sysid_schedule = sci.sysid_schedule) AND
								(t_sl.is_premature_deloaded = 0)
							GROUP BY
								t_sl.sysid_schedule
								
						) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						WHERE
							(inner_sci.sysid_schedule = sci.sysid_schedule) AND
							(inner_scd.is_marked_deleted = 0)
						GROUP BY
							inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count), -32768) AS slots_available,
							
				CASE WHEN ((NOT clsi.lecture_units IS NULL) AND (NOT clsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((clsi.lecture_units + clsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			LEFT JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
			LEFT JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(sci.is_marked_deleted = 0) AND
				(clsi.load_id IS NULL) AND
				(cdsi.load_id IS NULL)
			UNION ALL
			SELECT						-- NOT LOADED BY SEMESTER SUBJECT SCHEDULE -------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.sysid_semester AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				clsi.load_id AS load_id,
				clsi.load_date AS load_date,
				clsi.deload_date AS deload_date,
				clsi.lecture_units AS load_lecture_units,
				clsi.lab_units AS load_lab_units,
				clsi.no_hours AS load_no_hours,
				'false' AS is_premature_deloaded,
				'false' AS is_loaded_to_student,
				
				ISNULL((SELECT
							(MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0)
						FROM
							ums.schedule_information_details AS inner_scd
						INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						LEFT JOIN 
						(
							SELECT	
								t_sl.sysid_schedule AS sysid_schedule,
								COUNT(t_sl.load_id) AS student_count
							FROM
								ums.student_load AS t_sl 
							WHERE 
								(t_sl.sysid_schedule = sci.sysid_schedule) AND
								(t_sl.is_premature_deloaded = 0)
							GROUP BY
								t_sl.sysid_schedule
								
						) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						WHERE
							(inner_sci.sysid_schedule = sci.sysid_schedule) AND
							(inner_scd.is_marked_deleted = 0)
						GROUP BY
							inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count), -32768) AS slots_available,
							
				CASE WHEN ((NOT clsi.lecture_units IS NULL) AND (NOT clsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((clsi.lecture_units + clsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			LEFT JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
			LEFT JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
				(sci.is_marked_deleted = 0) AND
				(clsi.load_id IS NULL) AND
				(cdsi.load_id IS NULL)				
			ORDER BY 
				subject_code, sysid_schedule ASC

		END
		ELSE
		BEGIN

			WITH cte_loaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
			(
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
					(sl.deload_date = sy.date_end) AND
					(sl.is_premature_deloaded = 0) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
				UNION ALL
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
					(sl.deload_date = sri.date_end) AND
					(sl.is_premature_deloaded = 0) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
			),
			cte_deloaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
			(
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(sci.is_marked_deleted = 0) AND
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
					(sl.is_premature_deloaded = 1) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
				UNION ALL
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(sci.is_marked_deleted = 0) AND
					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
					(sl.is_premature_deloaded = 1) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
			)

			SELECT						-- LOADED YEARLY SUBJECT SCHEDULE (no marked deleted in the schedule to include pre.mature deloads on student loads)-------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.year_id AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				clsi.load_id AS load_id,
				clsi.load_date AS load_date,
				clsi.deload_date AS deload_date,
				clsi.lecture_units AS load_lecture_units,
				clsi.lab_units AS load_lab_units,
				clsi.no_hours AS load_no_hours,
				clsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				0 AS slots_available,
							
				CASE WHEN ((NOT clsi.lecture_units IS NULL) AND (NOT clsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((clsi.lecture_units + clsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						-- LOADED BY SEMESTER SUBJECT SCHEDULE -------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.sysid_semester AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				clsi.load_id AS load_id,
				clsi.load_date AS load_date,
				clsi.deload_date AS deload_date,
				clsi.lecture_units AS load_lecture_units,
				clsi.lab_units AS load_lab_units,
				clsi.no_hours AS load_no_hours,
				clsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				0 AS slots_available,
							
				CASE WHEN ((NOT clsi.lecture_units IS NULL) AND (NOT clsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((clsi.lecture_units + clsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						------------- PREMATURELY DELOADED YEARLY SUBJECT SCHEDULE --------------------------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.year_id AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				cdsi.load_id AS load_id,
				cdsi.load_date AS load_date,
				cdsi.deload_date AS deload_date,
				cdsi.lecture_units AS load_lecture_units,
				cdsi.lab_units AS load_lab_units,
				cdsi.no_hours AS load_no_hours,
				cdsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				0 AS slots_available,
							
				CASE WHEN ((NOT cdsi.lecture_units IS NULL) AND (NOT cdsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((cdsi.lecture_units + cdsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						-- PREMATURELY DELOADED BY SEMESTER SUBJECT SCHEDULE -------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.sysid_semester AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				cdsi.load_id AS load_id,
				cdsi.load_date AS load_date,
				cdsi.deload_date AS deload_date,
				cdsi.lecture_units AS load_lecture_units,
				cdsi.lab_units AS load_lab_units,
				cdsi.no_hours AS load_no_hours,
				cdsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				0 AS slots_available,
							
				CASE WHEN ((NOT cdsi.lecture_units IS NULL) AND (NOT cdsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((cdsi.lecture_units + cdsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))						
			ORDER BY 
				subject_code, sysid_schedule ASC

		END
		
	END	
	ELSE IF (ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1)      
	BEGIN

		DECLARE @department_id varchar (50)

		SELECT 
			@department_id = arg.department_id 
		FROM
			ums.access_rights_granted AS arg
		INNER JOIN ums.system_user_info AS sui ON sui.system_user_id = arg.system_user_id
		WHERE
			(arg.access_rights = '@7W_*xAuIz%qTm^rYmq!a38&z#s{>zX2*pUw[#Z@') AND
			(sui.system_user_id = @system_user_id);

		SELECT															--this will be used to get the total subject amount as one of the parameters 
			@is_semestral = CASE WHEN (cg.is_semestral IS NULL)			--for the subjects that has not been loaded yet.
								THEN									
									(0)
								ELSE
									(cg.is_semestral)
								END
		FROM
			ums.course_group AS cg
		INNER JOIN ums.course_information AS ci ON ci.course_group_id = cg.course_group_id
		INNER JOIN ums.student_enrolment_course AS sec ON sec.course_id = ci.course_id
		WHERE
			(sec.sysid_student = @sysid_student) AND
			(sec.is_current_course = 1);

		SELECT
			@tuition_amount = amount
		FROM
			ums.GetBySysIDStudentFeeLevelSemesterFeeDetails(@sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
						@is_graduate_student, @is_international, @is_enrolled, 0)
		WHERE
			(category_no = 1)
		ORDER BY
			category_no, particular_description ASC;

		IF (@is_for_student_tab = 0)
		BEGIN

			WITH cte_loaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
			(
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
					(sl.deload_date = sy.date_end) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
				UNION ALL
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
					(sl.deload_date = sri.date_end) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
			),
			cte_deloaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
			(
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(sci.is_marked_deleted = 0) AND
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
					(sl.is_premature_deloaded = 1) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
				UNION ALL
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(sci.is_marked_deleted = 0) AND
					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
					(sl.is_premature_deloaded = 1) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
			)

			SELECT						-- LOADED YEARLY SUBJECT SCHEDULE (no marked deleted in the schedule to include pre.mature deloads on student loads)-------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.year_id AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				clsi.load_id AS load_id,
				clsi.load_date AS load_date,
				clsi.deload_date AS deload_date,
				clsi.lecture_units AS load_lecture_units,
				clsi.lab_units AS load_lab_units,
				clsi.no_hours AS load_no_hours,
				clsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				
				ISNULL((SELECT
							(MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0)
						FROM
							ums.schedule_information_details AS inner_scd
						INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						LEFT JOIN 
						(
							SELECT	
								t_sl.sysid_schedule AS sysid_schedule,
								COUNT(t_sl.load_id) AS student_count
							FROM
								ums.student_load AS t_sl 
							WHERE 
								(t_sl.sysid_schedule = sci.sysid_schedule) AND
								(t_sl.is_premature_deloaded = 0)
							GROUP BY
								t_sl.sysid_schedule
								
						) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						WHERE
							(inner_sci.sysid_schedule = sci.sysid_schedule) AND
							(inner_scd.is_marked_deleted = 0)
						GROUP BY
							inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count), -32768) AS slots_available,
							
				CASE WHEN ((NOT clsi.lecture_units IS NULL) AND (NOT clsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((clsi.lecture_units + clsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						-- LOADED BY SEMESTER SUBJECT SCHEDULE -------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.sysid_semester AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				clsi.load_id AS load_id,
				clsi.load_date AS load_date,
				clsi.deload_date AS deload_date,
				clsi.lecture_units AS load_lecture_units,
				clsi.lab_units AS load_lab_units,
				clsi.no_hours AS load_no_hours,
				clsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				
				ISNULL((SELECT
							(MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0)
						FROM
							ums.schedule_information_details AS inner_scd
						INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						LEFT JOIN 
						(
							SELECT	
								t_sl.sysid_schedule AS sysid_schedule,
								COUNT(t_sl.load_id) AS student_count
							FROM
								ums.student_load AS t_sl 
							WHERE 
								(t_sl.sysid_schedule = sci.sysid_schedule) AND
								(t_sl.is_premature_deloaded = 0)
							GROUP BY
								t_sl.sysid_schedule
								
						) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						WHERE
							(inner_sci.sysid_schedule = sci.sysid_schedule) AND
							(inner_scd.is_marked_deleted = 0)
						GROUP BY
							inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count), -32768) AS slots_available,
							
				CASE WHEN ((NOT clsi.lecture_units IS NULL) AND (NOT clsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((clsi.lecture_units + clsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						------------- PREMATURELY DELOADED YEARLY SUBJECT SCHEDULE --------------------------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.year_id AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				cdsi.load_id AS load_id,
				cdsi.load_date AS load_date,
				cdsi.deload_date AS deload_date,
				cdsi.lecture_units AS load_lecture_units,
				cdsi.lab_units AS load_lab_units,
				cdsi.no_hours AS load_no_hours,
				cdsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				
				ISNULL((SELECT
							(MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0)
						FROM
							ums.schedule_information_details AS inner_scd
						INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						LEFT JOIN 
						(
							SELECT	
								t_sl.sysid_schedule AS sysid_schedule,
								COUNT(t_sl.load_id) AS student_count
							FROM
								ums.student_load AS t_sl 
							WHERE 
								(t_sl.sysid_schedule = sci.sysid_schedule) AND
								(t_sl.is_premature_deloaded = 0)
							GROUP BY
								t_sl.sysid_schedule
								
						) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						WHERE
							(inner_sci.sysid_schedule = sci.sysid_schedule) AND
							(inner_scd.is_marked_deleted = 0)
						GROUP BY
							inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count), -32768) AS slots_available,
							
				CASE WHEN ((NOT cdsi.lecture_units IS NULL) AND (NOT cdsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((cdsi.lecture_units + cdsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						-- PREMATURELY DELOADED BY SEMESTER SUBJECT SCHEDULE -------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.sysid_semester AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				cdsi.load_id AS load_id,
				cdsi.load_date AS load_date,
				cdsi.deload_date AS deload_date,
				cdsi.lecture_units AS load_lecture_units,
				cdsi.lab_units AS load_lab_units,
				cdsi.no_hours AS load_no_hours,
				cdsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				
				ISNULL((SELECT
							(MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0)
						FROM
							ums.schedule_information_details AS inner_scd
						INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						LEFT JOIN 
						(
							SELECT	
								t_sl.sysid_schedule AS sysid_schedule,
								COUNT(t_sl.load_id) AS student_count
							FROM
								ums.student_load AS t_sl 
							WHERE 
								(t_sl.sysid_schedule = sci.sysid_schedule) AND
								(t_sl.is_premature_deloaded = 0)
							GROUP BY
								t_sl.sysid_schedule
								
						) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						WHERE
							(inner_sci.sysid_schedule = sci.sysid_schedule) AND
							(inner_scd.is_marked_deleted = 0)
						GROUP BY
							inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count), -32768) AS slots_available,
							
				CASE WHEN ((NOT cdsi.lecture_units IS NULL) AND (NOT cdsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((cdsi.lecture_units + cdsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						-- NOT LOADED YEARLY SUBJECT SCHEDULE -------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.year_id AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				clsi.load_id AS load_id,
				clsi.load_date AS load_date,
				clsi.deload_date AS deload_date,
				clsi.lecture_units AS load_lecture_units,
				clsi.lab_units AS load_lab_units,
				clsi.no_hours AS load_no_hours,
				'false' AS is_premature_deloaded,
				'false' AS is_loaded_to_student,
				
				ISNULL((SELECT
							(MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0)
						FROM
							ums.schedule_information_details AS inner_scd
						INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						LEFT JOIN 
						(
							SELECT	
								t_sl.sysid_schedule AS sysid_schedule,
								COUNT(t_sl.load_id) AS student_count
							FROM
								ums.student_load AS t_sl 
							WHERE 
								(t_sl.sysid_schedule = sci.sysid_schedule) AND
								(t_sl.is_premature_deloaded = 0)
							GROUP BY
								t_sl.sysid_schedule
								
						) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						WHERE
							(inner_sci.sysid_schedule = sci.sysid_schedule) AND
							(inner_scd.is_marked_deleted = 0)
						GROUP BY
							inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count), -32768) AS slots_available,
							
				CASE WHEN ((NOT clsi.lecture_units IS NULL) AND (NOT clsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((clsi.lecture_units + clsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			LEFT JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
			LEFT JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
				(sci.is_marked_deleted = 0) AND
				(clsi.load_id IS NULL) AND
				(cdsi.load_id IS NULL) AND
				((si.department_id = @department_id) OR (si.is_open_access = 1))
			UNION ALL
			SELECT						-- NOT LOADED BY SEMESTER SUBJECT SCHEDULE -------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.sysid_semester AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				clsi.load_id AS load_id,
				clsi.load_date AS load_date,
				clsi.deload_date AS deload_date,
				clsi.lecture_units AS load_lecture_units,
				clsi.lab_units AS load_lab_units,
				clsi.no_hours AS load_no_hours,
				'false' AS is_premature_deloaded,
				'false' AS is_loaded_to_student,
				
				ISNULL((SELECT
							(MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0)
						FROM
							ums.schedule_information_details AS inner_scd
						INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						LEFT JOIN 
						(
							SELECT	
								t_sl.sysid_schedule AS sysid_schedule,
								COUNT(t_sl.load_id) AS student_count
							FROM
								ums.student_load AS t_sl 
							WHERE 
								(t_sl.sysid_schedule = sci.sysid_schedule) AND
								(t_sl.is_premature_deloaded = 0)
							GROUP BY
								t_sl.sysid_schedule
								
						) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						WHERE
							(inner_sci.sysid_schedule = sci.sysid_schedule) AND
							(inner_scd.is_marked_deleted = 0)
						GROUP BY
							inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count), -32768) AS slots_available,
							
				CASE WHEN ((NOT clsi.lecture_units IS NULL) AND (NOT clsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((clsi.lecture_units + clsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			LEFT JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
			LEFT JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND
				(sci.is_marked_deleted = 0) AND
				(clsi.load_id IS NULL) AND
				(cdsi.load_id IS NULL) AND
				((si.department_id = @department_id) OR (si.is_open_access = 1))			
			ORDER BY 
				subject_code, sysid_schedule ASC

		END
		ELSE
		BEGIN

			WITH cte_loaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
			(
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
					(sl.deload_date = sy.date_end) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
				UNION ALL
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
					(sl.deload_date = sri.date_end) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
			),
			cte_deloaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
					lecture_units, lab_units, no_hours, is_premature_deloaded, is_semestral) AS
			(
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(sci.is_marked_deleted = 0) AND
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
					(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
					((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))) AND
					(sl.is_premature_deloaded = 1) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
				UNION ALL
				SELECT
					sl.load_id AS load_id,
					sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sl.sysid_schedule AS sysid_schedule,
					sl.load_date AS load_date,
					sl.deload_date AS deload_date,
					sl.lecture_units AS lecture_units,
					sl.lab_units AS lab_units,
					sl.no_hours AS no_hours,
					sl.is_premature_deloaded AS is_premature_deloaded,
					cg.is_semestral
				FROM
					ums.student_load AS sl
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.course_information AS ci ON ci.course_id = sec.course_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
				WHERE
					(sci.is_marked_deleted = 0) AND
					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
					(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
					((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end))) AND 
					(sl.is_premature_deloaded = 1) AND
					(sl.sysid_enrolmentlevel = @sysid_enrolmentlevel)
			)

			SELECT						-- LOADED YEARLY SUBJECT SCHEDULE (no marked deleted in the schedule to include pre.mature deloads on student loads)-------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.year_id AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				clsi.load_id AS load_id,
				clsi.load_date AS load_date,
				clsi.deload_date AS deload_date,
				clsi.lecture_units AS load_lecture_units,
				clsi.lab_units AS load_lab_units,
				clsi.no_hours AS load_no_hours,
				clsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				0 AS slots_available,
							
				CASE WHEN ((NOT clsi.lecture_units IS NULL) AND (NOT clsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((clsi.lecture_units + clsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						-- LOADED BY SEMESTER SUBJECT SCHEDULE -------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.sysid_semester AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				clsi.load_id AS load_id,
				clsi.load_date AS load_date,
				clsi.deload_date AS deload_date,
				clsi.lecture_units AS load_lecture_units,
				clsi.lab_units AS load_lab_units,
				clsi.no_hours AS load_no_hours,
				clsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				0 AS slots_available,
							
				CASE WHEN ((NOT clsi.lecture_units IS NULL) AND (NOT clsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((clsi.lecture_units + clsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						------------- PREMATURELY DELOADED YEARLY SUBJECT SCHEDULE --------------------------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.year_id AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				cdsi.load_id AS load_id,
				cdsi.load_date AS load_date,
				cdsi.deload_date AS deload_date,
				cdsi.lecture_units AS load_lecture_units,
				cdsi.lab_units AS load_lab_units,
				cdsi.no_hours AS load_no_hours,
				cdsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				0 AS slots_available,
							
				CASE WHEN ((NOT cdsi.lecture_units IS NULL) AND (NOT cdsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((cdsi.lecture_units + cdsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND 
				(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
			UNION ALL
			SELECT						-- PREMATURELY DELOADED BY SEMESTER SUBJECT SCHEDULE -------------------
				sci.sysid_schedule AS sysid_schedule,
				sci.sysid_subject AS sysid_subject,
				sci.sysid_semester AS year_semester_id,
				sci.is_team_teaching AS is_team_teaching,
				sci.is_irregular_modular AS is_irregular_modular,
				sci.is_fixed_amount AS is_fixed_amount,
				sci.amount AS amount,
				sci.additional_slots AS additional_slots,
				(SELECT
						MIN(ci.maximum_capacity)
					FROM
						ums.classroom_information AS ci
					INNER JOIN ums.schedule_information_details AS scd ON scd.sysid_classroom = ci.sysid_classroom
					WHERE
						scd.sysid_schedule = sci.sysid_schedule) AS maximum_capacity,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS subject_lecture_units,
				si.lab_units AS subject_lab_units,
				si.no_hours AS subject_no_hours,
				si.is_non_academic AS is_non_academic,
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym,
				di.department_name AS department_name,
				cg.is_semestral AS is_semestral,
				cg.group_no AS group_no,
				cdsi.load_id AS load_id,
				cdsi.load_date AS load_date,
				cdsi.deload_date AS deload_date,
				cdsi.lecture_units AS load_lecture_units,
				cdsi.lab_units AS load_lab_units,
				cdsi.no_hours AS load_no_hours,
				cdsi.is_premature_deloaded AS is_premature_deloaded,
				'true' AS is_loaded_to_student,
				0 AS slots_available,
							
				CASE WHEN ((NOT cdsi.lecture_units IS NULL) AND (NOT cdsi.lab_units IS NULL) AND	--per unit subjects
								(sci.is_fixed_amount = 0) AND (cg.is_semestral = 1))
							THEN
								((cdsi.lecture_units + cdsi.lab_units) * @tuition_amount)
								
						WHEN ((NOT sci.amount IS NULL) AND (NOT sci.amount = 0) AND		--fixed amount subjects (per unit or per year)
								(sci.is_fixed_amount = 1))								--if the result is still 0, then the schedule is not per unit
							THEN														--and not fixed amount 
								(sci.amount)
						
						ELSE
							(0.00) 
						END AS subject_amount
			FROM
				ums.schedule_information AS sci
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN cte_deloaded_schedule_information AS cdsi ON cdsi.sysid_schedule = sci.sysid_schedule
			WHERE
				(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND 
				(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
				((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))			
			ORDER BY 
				subject_code, sysid_schedule ASC

		END

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a student load', 'Student Load'
		
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad')
   DROP PROCEDURE ums.SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad
GO

CREATE PROCEDURE ums.SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad

	@sysid_enrolmentlevel_list nvarchar (MAX) = '',

	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1) 
	BEGIN

		WITH cte_loaded_schedule_information (load_id, sysid_enrolmentlevel, sysid_schedule, load_date, deload_date,
				lecture_units, lab_units, no_hours) AS
		(
			SELECT
				sl.load_id AS load_id,
				sl.sysid_enrolmentlevel AS sysid_enrolmentlevel,
				sl.sysid_schedule AS sysid_schedule,
				sl.load_date AS load_date,
				sl.deload_date AS deload_date,
				sl.lecture_units AS lecture_units,
				sl.lab_units AS lab_units,
				sl.no_hours AS no_hours
			FROM
				ums.student_load AS sl
			INNER JOIN ums.IterateListToTable(@sysid_enrolmentlevel_list, ',') AS sell_list ON sell_list.var_str = sl.sysid_enrolmentlevel
			INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
			WHERE
				(sl.is_premature_deloaded = 0) AND
				(sci.is_marked_deleted = 0)
		)

		SELECT						
			sci.sysid_schedule AS sysid_schedule,
			sci.sysid_subject AS sysid_subject,
			sci.is_team_teaching AS is_team_teaching,
			sci.is_irregular_modular AS is_irregular_modular,
			sci.is_fixed_amount AS is_fixed_amount,
			sci.amount AS amount,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS subject_lecture_units,
			si.lab_units AS subject_lab_units,
			si.no_hours AS subject_no_hours,
			di.department_name AS department_name,
			cg.is_semestral AS is_semestral,
			cg.group_no AS group_no,
			clsi.load_id AS load_id,
			clsi.sysid_enrolmentlevel AS sysid_enrolmentlevel,
			clsi.load_date AS load_date,
			clsi.deload_date AS deload_date,
			clsi.lecture_units AS load_lecture_units,
			clsi.lab_units AS load_lab_units,
			clsi.no_hours AS load_no_hours
		FROM
			ums.schedule_information AS sci
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
		INNER JOIN cte_loaded_schedule_information AS clsi ON clsi.sysid_schedule = sci.sysid_schedule			
		ORDER BY 
			subject_code, sysid_schedule ASC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a student load', 'Student Load'
		
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad')
   DROP PROCEDURE ums.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad
GO

CREATE PROCEDURE ums.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad

	@sysid_student varchar (50) = '',
	@sysid_enrolmentlevel varchar (50) = '',
	@sysid_feelevel varchar (50) = '',
	@sysid_semester varchar (50) = '',
	@is_graduate_student bit = 0,
	@is_international bit = 0,
	@is_enrolled bit = 0,
	@is_marked_deleted bit = 0,
	@is_previous_charge bit = 0,
	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsStudentDataControllerSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		DECLARE @return_table TABLE (table_id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
								sysid_enrolmentlevel varchar (50) NULL,
								sysid_feedetails varchar (50) NULL,
								sysid_feeparticular varchar (50) NULL,
								is_level_increase bit NOT NULL DEFAULT (0),								
								is_added_level_fee bit NOT NULL DEFAULT (0),
								amount decimal (12, 2) NOT NULL,
								fee_category_id varchar (50) NOT NULL,
								category_description varchar (100) NOT NULL,
								particular_description varchar (100) NOT NULL,
								is_office_access bit NOT NULL DEFAULT (0),			
								category_no tinyint NOT NULL,
								additional_fee_id bigint NULL,
								optional_fee_id bigint NULL,
								is_additional_fee bit NOT NULL DEFAULT (0),
								is_optional_fee bit NOT NULL DEFAULT (0),
								is_per_year_tuition_fee bit NOT NULL DEFAULT (0),
								is_per_unit_tuition_fee bit NOT NULL DEFAULT (0),
								is_fixed_amount_tuition_fee bit NOT NULL DEFAULT (0),
								is_special_class_tuition_fee bit NOT NULL DEFAULT (0),
								international_percentage float NULL,
								remarks varchar (100) NULL)
		
		DECLARE @sysid_feedetails varchar (50)
		DECLARE @sysid_feeparticular varchar (50)
		DECLARE @is_level_increase bit
		DECLARE @is_added_level_fee bit
		DECLARE @tuition_amount decimal (12, 2)
		DECLARE @fixed_amount decimal (12, 2)
		DECLARE @special_class_amount decimal (12, 2)
		DECLARE @fee_category_id varchar (50)
		DECLARE @category_description varchar (100)
		DECLARE @particular_description varchar (100)
		DECLARE @is_office_access bit
		DECLARE @category_no tinyint
		DECLARE @international_percentage float

		-- A - is_enrolled
		-- B - sysid_enrolmentlevel
		-- C - is_marked_deleted
		-- D - is_previous_charge

		--	A	B	C	D
		--	==============
		--	0	0	0	0	used to get the charges of a level that is candidate for enrolment
		--	0	0	0	1	NOT INCLUDED
		--	0	0	1	0	NOT INCLUDED
		--	0	0	1	1	NOT INCLUDED
		--	0	1	0	0	NOT INCLUDED
		--	0	1	0	1	NOT INCLUDED
		--	0	1	1	0	NOT INCLUDED
		--	0	1	1	1	NOT INCLUDED
		--	1	0	0	0	NOT INCLUDED
		--	1	0	0	1	NOT INCLUDED
		--	1	0	1	0	NOT INCLUDED
		--	1	0	1	1	NOT INCLUDED
		--	1	1	0	0	used to get the current charges of an enrolled level
		--	1	1	0	1	used to get the previous charges of an enrolled level and deleted level
		--	1	1	1	0	used to get the current charges of a deleted level
		--	1	1	1	1	NOT INCLUDED

		--TODO: if is_enrolled is equal to 1 and is_marked_deleted is equal to 1, the is_premature_deloaded of the student load must be 1		

		IF ((@is_enrolled = 0) AND (ISNULL(@sysid_enrolmentlevel, '') = '') AND (@is_marked_deleted = 0) AND (@is_previous_charge = 0))	-- (0000)
		BEGIN

			INSERT INTO @return_table (sysid_enrolmentlevel, sysid_feedetails, sysid_feeparticular, is_level_increase, is_added_level_fee, amount, fee_category_id, category_description, 
							particular_description,  is_office_access, category_no, additional_fee_id, optional_fee_id, is_additional_fee, is_optional_fee,
							international_percentage, remarks)
				SELECT
					sysid_enrolmentlevel,
					sysid_feedetails,
					sysid_feeparticular,
					is_level_increase,
					is_added_level_fee,
					amount,
					fee_category_id,
					category_description,
					particular_description,
					is_office_access,
					category_no,
					additional_fee_id,
					optional_fee_id,
					is_additional_fee,
					is_optional_fee,
					international_percentage,
					remarks
				FROM
					ums.GetBySysIDStudentFeeLevelSemesterFeeDetails(@sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
								@is_graduate_student, @is_international, @is_enrolled, @is_marked_deleted)
				ORDER BY
					category_no, particular_description ASC		

			IF EXISTS (SELECT table_id FROM @return_table WHERE category_no = 1)	--determines if there is a TUITION FEE in the certain level
			BEGIN
			
				SELECT
					@sysid_feedetails = sysid_feedetails,
					@sysid_feeparticular = sysid_feeparticular,
					@is_level_increase = is_level_increase,
					@is_added_level_fee = is_added_level_fee,
					@tuition_amount = amount,
					@fee_category_id = fee_category_id,
					@category_description = category_description,
					@particular_description = particular_description,
					@is_office_access = is_office_access,
					@category_no = category_no,
					@international_percentage = international_percentage
				FROM
					@return_table
				WHERE
					(category_no = 1) --TUTION FEE
				ORDER BY
					category_no, particular_description ASC
			END
			ELSE
			BEGIN

				SET @sysid_feedetails = NULL
				SET	@sysid_feeparticular = NULL
				SET	@is_level_increase = 0
				SET	@is_added_level_fee = 0
				SET @tuition_amount = 0	

				SELECT
					@fee_category_id = fee_category_id, 
					@category_description = category_description
				FROM
					ums.school_fee_category
				WHERE 
					(category_no = 1)

				SET	@is_office_access = 0
				SET	@category_no = 1

				SELECT 
					@international_percentage = international_percentage 
				FROM 
					ums.finance_standard AS fsd
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_financestd = fsd.sysid_financestd
				WHERE
					(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel)

			END

			IF ((SELECT 
						cg.is_per_unit AS is_per_unit
					FROM 
						ums.course_group AS cg
					INNER JOIN ums.year_level_information AS yli ON yli.course_group_id = cg.course_group_id
					INNER JOIN ums.school_fee_level AS sfl ON sfl.year_level_id = yli.year_level_id
					WHERE 
						(sfl.sysid_feelevel = @sysid_feelevel)) = 1)
			BEGIN

				--get the computed tuition fee
				SET @tuition_amount = 0				

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase,
					is_added_level_fee, 
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_per_unit_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					@tuition_amount, 
					@fee_category_id, 
					@category_description, 					
					'Per Unit', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

				--get the total fixed amount subject
				SET @fixed_amount = 0

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase,
					is_added_level_fee, 
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_fixed_amount_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					CASE WHEN 
						((@is_international = 1) AND
						(NOT @international_percentage IS NULL) AND
						(NOT @international_percentage <= 0))
					THEN
						(@fixed_amount * 
						(1 + (@international_percentage / 100)))
					ELSE
						(@fixed_amount)
					END, 
					@fee_category_id, 
					@category_description, 			
					'Subjects with Fixed-amount', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

				--gets the special class amount
				SET @special_class_amount = (SELECT (CASE WHEN ((SUM(sci.amount) = 0) OR (SUM(sci.amount) IS NULL))
														THEN
															0
														ELSE
															(SUM(sci.amount))
														END) AS special_class_amount
												FROM
													ums.special_class_information AS sci
												INNER JOIN ums.special_class_load AS scl ON scl.sysid_special = sci.sysid_special
												WHERE
													(sci.is_marked_deleted = 0) AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND
													(sci.sysid_semester = @sysid_semester) AND
													(scl.sysid_student = @sysid_student)) --does not check for is_premature_deloaded because if the deload
																						  --is done after cut-off then it will still reflect on the tuition fee
	
				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_special_class_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					CASE WHEN 
						((@is_international = 1) AND
						(NOT @international_percentage IS NULL) AND
						(NOT @international_percentage <= 0))
					THEN
						(@special_class_amount * 
						(1 + (@international_percentage / 100)))
					ELSE
						(@special_class_amount)
					END, 
					@fee_category_id, 
					@category_description, 			
					'Special Class', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

			END
			ELSE	--yearly level
			BEGIN	

				--get the tuition fee
				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_per_year_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					@tuition_amount, 
					@fee_category_id, 
					@category_description, 			
					'Per Year', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)		

				--get the total fixed amount subject
				SET @fixed_amount = 0

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase,
					is_added_level_fee, 
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_fixed_amount_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					CASE WHEN 
						((@is_international = 1) AND
						(NOT @international_percentage IS NULL) AND
						(NOT @international_percentage <= 0))
					THEN
						(@fixed_amount * 
						(1 + (@international_percentage / 100)))
					ELSE
						(@fixed_amount)
					END, 
					@fee_category_id, 
					@category_description, 			
					'Subjects with Fixed-amount', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

				--gets the special class amount
				SET @special_class_amount = (SELECT (CASE WHEN ((SUM(sci.amount) = 0) OR (SUM(sci.amount) IS NULL))
													THEN
														0
													ELSE
														(SUM(sci.amount))
													END) AS special_class_amount
											FROM
												ums.special_class_information AS sci
											INNER JOIN ums.special_class_load AS scl ON scl.sysid_special = sci.sysid_special
											WHERE
												(sci.is_marked_deleted = 0) AND
												(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
												(sci.year_id = (SELECT
																	sfi.year_id
																FROM
																	ums.school_fee_information AS sfi
																INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
																WHERE
																	(sfl.sysid_feelevel = @sysid_feelevel))) AND
												(scl.sysid_student = @sysid_student)) --does not check for is_premature_deloaded because if the deload
																						  --is done after cut-off then it will still reflect on the tuition fee

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_special_class_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					CASE WHEN 
						((@is_international = 1) AND
						(NOT @international_percentage IS NULL) AND
						(NOT @international_percentage <= 0))
					THEN
						(@special_class_amount * 
						(1 + (@international_percentage / 100)))
					ELSE
						(@special_class_amount)
					END,  
					@fee_category_id, 
					@category_description, 			
					'Special Class', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

			END

		END
		ELSE IF ((@is_enrolled = 1) AND (NOT ISNULL(@sysid_enrolmentlevel, '') = '') AND (@is_marked_deleted = 0) AND (@is_previous_charge = 0)) --(1100)
		BEGIN

			INSERT INTO @return_table (sysid_enrolmentlevel, sysid_feedetails, sysid_feeparticular, is_level_increase, is_added_level_fee, amount, fee_category_id, category_description, 
							particular_description,  is_office_access, category_no, additional_fee_id, optional_fee_id, is_additional_fee, is_optional_fee,
							international_percentage, remarks)
				SELECT
					sysid_enrolmentlevel,
					sysid_feedetails,
					sysid_feeparticular,
					is_level_increase,
					is_added_level_fee,
					amount,
					fee_category_id,
					category_description,
					particular_description,
					is_office_access,
					category_no,
					additional_fee_id,
					optional_fee_id,
					is_additional_fee,
					is_optional_fee,
					international_percentage,
					remarks
				FROM
					ums.GetBySysIDStudentFeeLevelSemesterFeeDetails(@sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
								@is_graduate_student, @is_international, @is_enrolled, @is_marked_deleted)
				ORDER BY
					category_no, particular_description ASC	

			IF EXISTS (SELECT table_id FROM @return_table WHERE category_no = 1)	--determines if there is a TUITION FEE in the certain level
			BEGIN
			
				SELECT
					@sysid_feedetails = sysid_feedetails,
					@sysid_feeparticular = sysid_feeparticular,
					@is_level_increase = is_level_increase,
					@is_added_level_fee = is_added_level_fee,
					@tuition_amount = amount,
					@fee_category_id = fee_category_id,
					@category_description = category_description,
					@particular_description = particular_description,
					@is_office_access = is_office_access,
					@category_no = category_no,
					@international_percentage = international_percentage
				FROM
					@return_table
				WHERE
					(category_no = 1) --TUTION FEE
				ORDER BY
					category_no, particular_description ASC
			END
			ELSE
			BEGIN

				SET @sysid_feedetails = NULL
				SET	@sysid_feeparticular = NULL
				SET	@is_level_increase = 0
				SET	@is_added_level_fee = 0
				SET @tuition_amount = 0

				SELECT
					@fee_category_id = fee_category_id, 
					@category_description = category_description
				FROM
					ums.school_fee_category
				WHERE 
					(category_no = 1)

				SET	@is_office_access = 0
				SET	@category_no = 1

				SELECT 
					@international_percentage = international_percentage 
				FROM 
					ums.finance_standard AS fsd
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_financestd = fsd.sysid_financestd
				WHERE
					(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel)

			END

			IF ((SELECT 
						cg.is_per_unit AS is_per_unit
					FROM 
						ums.course_group AS cg
					INNER JOIN ums.year_level_information AS yli ON yli.course_group_id = cg.course_group_id
					INNER JOIN ums.school_fee_level AS sfl ON sfl.year_level_id = yli.year_level_id
					WHERE 
						(sfl.sysid_feelevel = @sysid_feelevel)) = 1)
			BEGIN

				--get the computed tuition fee
				SET @tuition_amount = ((SELECT (CASE WHEN ((SUM(sl.lecture_units) = 0 AND SUM(sl.lab_units) = 0) OR 
												(SUM(sl.lecture_units) IS NULL AND SUM(sl.lab_units) IS NULL)) 
											THEN  
												0
											ELSE
												(SUM(sl.lecture_units) + SUM(sl.lab_units))
											END) AS loaded_units
										FROM
											ums.student_load AS sl
										INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
										INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
										INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
										INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
										INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
										INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
										WHERE
											(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
											(sel.sysid_feelevel = @sysid_feelevel) AND
											(sel.sysid_semester = @sysid_semester) AND
											(sec.sysid_student = @sysid_student) AND
											(sci.is_fixed_amount = 0) AND
											(sci.is_marked_deleted = 0) AND
											(cg.is_semestral = 1)) * @tuition_amount) --does not check for is_premature_deloaded because if the deload
																						  --is done after cut-off then it will still reflect on the tuition fee

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_per_unit_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					@tuition_amount, 
					@fee_category_id, 
					@category_description, 					
					'Per Unit', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

				--get the total fixed amount subject
				SET @fixed_amount = (SELECT (CASE WHEN ((SUM(sci.amount) = 0) OR (SUM(sci.amount) IS NULL))
											THEN
												0
											ELSE
												(SUM(sci.amount))
											END) AS fixed_amount
									FROM
										ums.schedule_information AS sci
									INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
									INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
									INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
									INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
									INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
									INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
									WHERE
										(sci.is_fixed_amount = 1) AND
										(sci.is_marked_deleted = 0) AND
										(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
										(sel.sysid_feelevel = @sysid_feelevel) AND
										(sel.sysid_semester = @sysid_semester) AND
										(sec.sysid_student = @sysid_student) AND
										(cg.is_semestral = 1)) --does not check for is_premature_deloaded because if the deload
																--is done after cut-off then it will still reflect on the tuition fee

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_fixed_amount_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					CASE WHEN 
						((@is_international = 1) AND
						(NOT @international_percentage IS NULL) AND
						(NOT @international_percentage <= 0))
					THEN
						(@fixed_amount * 
						(1 + (@international_percentage / 100)))
					ELSE
						(@fixed_amount)
					END, 
					@fee_category_id, 
					@category_description, 			
					'Subjects with Fixed-amount', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

				--gets the special class amount
				SET @special_class_amount = (SELECT (CASE WHEN ((SUM(sci.amount) = 0) OR (SUM(sci.amount) IS NULL))
														THEN
															0
														ELSE
															(SUM(sci.amount))
														END) AS special_class_amount
												FROM
													ums.special_class_information AS sci
												INNER JOIN ums.special_class_load AS scl ON scl.sysid_special = sci.sysid_special
												WHERE
													(sci.is_marked_deleted = 0) AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND
													(sci.sysid_semester = @sysid_semester) AND
													(scl.sysid_student = @sysid_student)) --does not check for is_premature_deloaded because if the deload
																--is done after cut-off then it will still reflect on the tuition fee	

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_special_class_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					CASE WHEN 
						((@is_international = 1) AND
						(NOT @international_percentage IS NULL) AND
						(NOT @international_percentage <= 0))
					THEN
						(@special_class_amount * 
						(1 + (@international_percentage / 100)))
					ELSE
						(@special_class_amount)
					END, 
					@fee_category_id, 
					@category_description, 			
					'Special Class', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

			END
			ELSE	--yearly level
			BEGIN	

				--get the tuition fee
				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase,
					is_added_level_fee, 
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_per_year_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					@tuition_amount, 
					@fee_category_id, 
					@category_description, 			
					'Per Year', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)		

				--get the total fixed amount subject
				SET @fixed_amount = (SELECT (CASE WHEN ((SUM(sci.amount) = 0) OR (SUM(sci.amount) IS NULL))
													THEN
														0
													ELSE
														(SUM(sci.amount))
													END) AS fixed_amount
											FROM
												ums.schedule_information AS sci
											INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
											INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
											INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
											INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
											INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
											WHERE
												(sci.is_fixed_amount = 1) AND
												(sci.is_marked_deleted = 0) AND
												(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
												(sel.sysid_feelevel = @sysid_feelevel) AND
												(sec.sysid_student = @sysid_student) AND
												(cg.is_semestral = 0)) --does not check for is_premature_deloaded because if the deload
																--is done after cut-off then it will still reflect on the tuition fee

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_fixed_amount_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					CASE WHEN 
						((@is_international = 1) AND
						(NOT @international_percentage IS NULL) AND
						(NOT @international_percentage <= 0))
					THEN
						(@fixed_amount * 
						(1 + (@international_percentage / 100)))
					ELSE
						(@fixed_amount)
					END, 
					@fee_category_id, 
					@category_description, 			
					'Subjects with Fixed-amount', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

				--gets the special class amount
				SET @special_class_amount = (SELECT (CASE WHEN ((SUM(sci.amount) = 0) OR (SUM(sci.amount) IS NULL))
													THEN
														0
													ELSE
														(SUM(sci.amount))
													END) AS special_class_amount
											FROM
												ums.special_class_information AS sci
											INNER JOIN ums.special_class_load AS scl ON scl.sysid_special = sci.sysid_special
											WHERE
												(sci.is_marked_deleted = 0) AND
												(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
												(sci.year_id = (SELECT
																	sfi.year_id
																FROM
																	ums.school_fee_information AS sfi
																INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
																WHERE
																	(sfl.sysid_feelevel = @sysid_feelevel))) AND
												(scl.sysid_student = @sysid_student)) --does not check for is_premature_deloaded because if the deload
																--is done after cut-off then it will still reflect on the tuition fee

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_special_class_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					CASE WHEN 
						((@is_international = 1) AND
						(NOT @international_percentage IS NULL) AND
						(NOT @international_percentage <= 0))
					THEN
						(@special_class_amount * 
						(1 + (@international_percentage / 100)))
					ELSE
						(@special_class_amount)
					END,  
					@fee_category_id, 
					@category_description, 			
					'Special Class', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

			END

		END
		ELSE IF ((@is_enrolled = 1) AND (NOT ISNULL(@sysid_enrolmentlevel, '') = '') AND (@is_marked_deleted = 0) AND (@is_previous_charge = 1)) --(1101)
		BEGIN

			INSERT INTO @return_table (sysid_enrolmentlevel, sysid_feedetails, sysid_feeparticular, is_level_increase, is_added_level_fee, amount, fee_category_id, category_description, 
							particular_description,  is_office_access, category_no, additional_fee_id, optional_fee_id, is_additional_fee, is_optional_fee,
							international_percentage, remarks)
				SELECT
					sysid_enrolmentlevel,
					sysid_feedetails,
					sysid_feeparticular,
					is_level_increase,
					is_added_level_fee,
					amount,
					fee_category_id,
					category_description,
					particular_description,
					is_office_access,
					category_no,
					additional_fee_id,
					optional_fee_id,
					is_additional_fee,
					is_optional_fee,
					international_percentage,
					remarks
				FROM
					ums.GetBySysIDStudentFeeLevelSemesterFeeDetails(@sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
								@is_graduate_student, @is_international, @is_enrolled, @is_marked_deleted)
				ORDER BY
					category_no, particular_description ASC	

			IF EXISTS (SELECT table_id FROM @return_table WHERE category_no = 1)	--determines if there is a TUITION FEE in the certain level
			BEGIN
			
				SELECT
					@sysid_feedetails = sysid_feedetails,
					@sysid_feeparticular = sysid_feeparticular,
					@is_level_increase = is_level_increase,
					@is_added_level_fee = is_added_level_fee,
					@tuition_amount = amount,
					@fee_category_id = fee_category_id,
					@category_description = category_description,
					@particular_description = particular_description,
					@is_office_access = is_office_access,
					@category_no = category_no,
					@international_percentage = international_percentage
				FROM
					@return_table
				WHERE
					(category_no = 1) --TUTION FEE
				ORDER BY
					category_no, particular_description ASC
			END
			ELSE
			BEGIN

				SET @sysid_feedetails = NULL
				SET	@sysid_feeparticular = NULL
				SET	@is_level_increase = 0
				SET	@is_added_level_fee = 0
				SET @tuition_amount = 0	

				SELECT
					@fee_category_id = fee_category_id, 
					@category_description = category_description
				FROM
					ums.school_fee_category
				WHERE 
					(category_no = 1)

				SET	@is_office_access = 0
				SET	@category_no = 1

				SELECT 
					@international_percentage = international_percentage 
				FROM 
					ums.finance_standard AS fsd
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_financestd = fsd.sysid_financestd
				WHERE
					(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel)

			END

			IF ((SELECT 
						cg.is_per_unit AS is_per_unit
					FROM 
						ums.course_group AS cg
					INNER JOIN ums.year_level_information AS yli ON yli.course_group_id = cg.course_group_id
					INNER JOIN ums.school_fee_level AS sfl ON sfl.year_level_id = yli.year_level_id
					WHERE 
						(sfl.sysid_feelevel = @sysid_feelevel)) = 1)
			BEGIN

				--get the computed tuition fee
				SET @tuition_amount = ((SELECT (CASE WHEN ((SUM(sl.lecture_units) = 0 AND SUM(sl.lab_units) = 0) OR 
												(SUM(sl.lecture_units) IS NULL AND SUM(sl.lab_units) IS NULL)) 
											THEN  
												0
											ELSE
												(SUM(sl.lecture_units) + SUM(sl.lab_units))
											END) AS loaded_units
										FROM
											ums.student_load AS sl
										INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
										INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
										INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
										INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
										INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
										INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
										WHERE
											(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND	
											(sel.sysid_feelevel = @sysid_feelevel) AND
											(sel.sysid_semester = @sysid_semester) AND
											(sec.sysid_student = @sysid_student) AND
											(sci.is_fixed_amount = 0) AND
											(sci.is_marked_deleted = 0) AND
											(cg.is_semestral = 1)) * @tuition_amount)--does not check for is_premature_deloaded because if the deload
																--is done after cut-off then it will still reflect on the tuition fee		

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_per_unit_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					@tuition_amount, 
					@fee_category_id, 
					@category_description, 					
					'Per Unit', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

				--get the total fixed amount subject
				SET @fixed_amount = (SELECT (CASE WHEN ((SUM(sci.amount) = 0) OR (SUM(sci.amount) IS NULL))
											THEN
												0
											ELSE
												(SUM(sci.amount))
											END) AS fixed_amount
									FROM
										ums.schedule_information AS sci
									INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
									INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
									INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
									INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
									INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
									INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
									WHERE
										(sci.is_fixed_amount = 1) AND	
										(sci.is_marked_deleted = 0) AND
										(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
										(sel.sysid_feelevel = @sysid_feelevel) AND
										(sel.sysid_semester = @sysid_semester) AND
										(sec.sysid_student = @sysid_student) AND
										(cg.is_semestral = 1)) --does not check for is_premature_deloaded because if the deload
																--is done after cut-off then it will still reflect on the tuition fee

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_fixed_amount_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					CASE WHEN 
						((@is_international = 1) AND
						(NOT @international_percentage IS NULL) AND
						(NOT @international_percentage <= 0))
					THEN
						(@fixed_amount * 
						(1 + (@international_percentage / 100)))
					ELSE
						(@fixed_amount)
					END, 
					@fee_category_id, 
					@category_description, 			
					'Subjects with Fixed-amount', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

				--gets the special class amount
				SET @special_class_amount = (SELECT (CASE WHEN ((SUM(sci.amount) = 0) OR (SUM(sci.amount) IS NULL))
														THEN
															0
														ELSE
															(SUM(sci.amount))
														END) AS special_class_amount
												FROM
													ums.special_class_information AS sci
												INNER JOIN ums.special_class_load AS scl ON scl.sysid_special = sci.sysid_special
												WHERE
													(sci.is_marked_deleted = 0) AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND
													(sci.sysid_semester = @sysid_semester) AND
													(scl.sysid_student = @sysid_student))  --does not check for is_premature_deloaded because if the deload
																--is done after cut-off then it will still reflect on the tuition fee

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_special_class_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					CASE WHEN 
						((@is_international = 1) AND
						(NOT @international_percentage IS NULL) AND
						(NOT @international_percentage <= 0))
					THEN
						(@special_class_amount * 
						(1 + (@international_percentage / 100)))
					ELSE
						(@special_class_amount)
					END, 
					@fee_category_id, 
					@category_description, 			
					'Special Class', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

			END
			ELSE	--yearly level
			BEGIN	

				--get the tuition fee
				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_per_year_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					@tuition_amount, 
					@fee_category_id, 
					@category_description, 			
					'Per Year', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)		

				--get the total fixed amount subject
				SET @fixed_amount = (SELECT (CASE WHEN ((SUM(sci.amount) = 0) OR (SUM(sci.amount) IS NULL))
													THEN
														0
													ELSE
														(SUM(sci.amount))
													END) AS fixed_amount
											FROM
												ums.schedule_information AS sci
											INNER JOIN ums.student_load AS sl ON sl.sysid_schedule = sci.sysid_schedule
											INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
											INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
											INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
											INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
											INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
											WHERE
												(sci.is_fixed_amount = 1) AND	
												(sci.is_marked_deleted = 0) AND
												(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
												(sel.sysid_feelevel = @sysid_feelevel) AND
												(sec.sysid_student = @sysid_student) AND
												(cg.is_semestral = 0)) --does not check for is_premature_deloaded because if the deload
																--is done after cut-off then it will still reflect on the tuition fee

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_fixed_amount_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					CASE WHEN 
						((@is_international = 1) AND
						(NOT @international_percentage IS NULL) AND
						(NOT @international_percentage <= 0))
					THEN
						(@fixed_amount * 
						(1 + (@international_percentage / 100)))
					ELSE
						(@fixed_amount)
					END, 
					@fee_category_id, 
					@category_description, 			
					'Subjects with Fixed-amount', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

				--gets the special class amount
				SET @special_class_amount = (SELECT (CASE WHEN ((SUM(sci.amount) = 0) OR (SUM(sci.amount) IS NULL))
													THEN
														0
													ELSE
														(SUM(sci.amount))
													END) AS special_class_amount
											FROM
												ums.special_class_information AS sci
											INNER JOIN ums.special_class_load AS scl ON scl.sysid_special = sci.sysid_special
											WHERE
												(sci.is_marked_deleted = 0) AND
												(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
												(sci.year_id = (SELECT
																	sfi.year_id
																FROM
																	ums.school_fee_information AS sfi
																INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
																WHERE
																	(sfl.sysid_feelevel = @sysid_feelevel))) AND
												(scl.sysid_student = @sysid_student))	--does not check for is_premature_deloaded because if the deload
																--is done after cut-off then it will still reflect on the tuition fee

				INSERT INTO @return_table 
				(
					sysid_enrolmentlevel,
					sysid_feedetails, 
					sysid_feeparticular, 
					is_level_increase, 
					is_added_level_fee,
					amount, 
					fee_category_id, 
					category_description, 			
					particular_description, 
					is_office_access,
					category_no,
					is_special_class_tuition_fee,
					international_percentage
				)
				VALUES
				(
					@sysid_enrolmentlevel,
					@sysid_feedetails, 
					@sysid_feeparticular, 
					@is_level_increase, 
					@is_added_level_fee,
					CASE WHEN 
						((@is_international = 1) AND
						(NOT @international_percentage IS NULL) AND
						(NOT @international_percentage <= 0))
					THEN
						(@special_class_amount * 
						(1 + (@international_percentage / 100)))
					ELSE
						(@special_class_amount)
					END,  
					@fee_category_id, 
					@category_description, 			
					'Special Class', 
					@is_office_access,
					@category_no,
					1,
					@international_percentage
				)

			END

		END
		ELSE IF ((@is_enrolled = 1) AND (NOT ISNULL(@sysid_enrolmentlevel, '') = '') AND (@is_marked_deleted = 1) AND (@is_previous_charge = 0)) --(1110)
		BEGIN

			INSERT INTO @return_table (sysid_enrolmentlevel, sysid_feedetails, sysid_feeparticular, is_level_increase, is_added_level_fee, amount, fee_category_id, category_description, 
							particular_description,  is_office_access, category_no, additional_fee_id, optional_fee_id, is_additional_fee, is_optional_fee,
							international_percentage, remarks)
				SELECT
					sysid_enrolmentlevel,
					sysid_feedetails,
					sysid_feeparticular,
					is_level_increase,
					is_added_level_fee,
					amount,
					fee_category_id,
					category_description,
					particular_description,
					is_office_access,
					category_no,
					additional_fee_id,
					optional_fee_id,
					is_additional_fee,
					is_optional_fee,
					international_percentage,
					remarks
				FROM
					ums.GetBySysIDStudentFeeLevelSemesterFeeDetails(@sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
								@is_graduate_student, @is_international, @is_enrolled, @is_marked_deleted)
				ORDER BY
					category_no, particular_description ASC	

		END

		SELECT
			rt.table_id AS table_id,
			@sysid_student AS sysid_student,
			rt.sysid_enrolmentlevel AS sysid_enrolmentlevel,
			rt.sysid_feedetails AS sysid_feedetails,
			rt.sysid_feeparticular AS sysid_feeparticular,
			rt.is_level_increase AS is_level_increase,
			rt.is_added_level_fee AS is_added_level_fee,
			rt.amount AS amount,
			rt.fee_category_id AS fee_category_id,
			rt.category_description AS category_description,
			rt.particular_description AS particular_description,
			rt.is_office_access AS is_office_access,
			rt.category_no AS category_no,
			rt.additional_fee_id AS additional_fee_id,
			rt.optional_fee_id AS optional_fee_id,
			rt.is_additional_fee AS is_additional_fee,
			rt.is_optional_fee AS is_optional_fee,
			rt.is_per_year_tuition_fee AS is_per_year_tuition_fee,
			rt.is_per_unit_tuition_fee AS is_per_unit_tuition_fee,
			rt.is_fixed_amount_tuition_fee AS is_fixed_amount_tuition_fee,
			rt.is_special_class_tuition_fee AS is_special_class_tuition_fee,
			rt.international_percentage AS international_percentage,
			rt.remarks AS remarks
		FROM
			@return_table AS rt
		ORDER BY
			category_no, particular_description ASC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a student load', 'Student Load'		
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad TO db_umsusers
GO
---------------------------------------------------------

-- verifies if the procedure "SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad')
   DROP PROCEDURE ums.SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad
GO

CREATE PROCEDURE ums.SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad

	@sysid_student_list nvarchar (MAX) = '',
	@sysid_enrolmentlevel_list nvarchar (MAX) = '',
	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		DECLARE @student_level_table TABLE (table_id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
										sysid_student varchar (50) NULL,
										sysid_enrolmentlevel varchar (50) NULL,
										sysid_feelevel varchar (50) NULL,
										sysid_semester varchar (50) NULL,
										is_graduate_student bit NOT NULL DEFAULT (0),
										is_international bit NOT NULL DEFAULT (0),
										is_marked_deleted bit NOT NULL DEFAULT (0))

		DECLARE @school_fee_details_table TABLE (table_id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
										return_table_id int NOT NULL DEFAULT (0),
										sysid_student varchar (50) NOT NULL,
										sysid_enrolmentlevel varchar (50) NULL,
										sysid_feedetails varchar (50) NULL,
										sysid_feeparticular varchar (50) NULL,
										is_level_increase bit NOT NULL DEFAULT (0),
										is_added_level_fee bit NOT NULL DEFAULT (0),
										amount decimal (12, 2) NOT NULL,
										fee_category_id varchar (50) NOT NULL,
										category_description varchar (100) NOT NULL,
										particular_description varchar (100) NOT NULL,
										is_office_access bit NOT NULL DEFAULT (0),			
										category_no tinyint NOT NULL,
										additional_fee_id bigint NULL,
										optional_fee_id bigint NULL,
										is_additional_fee bit NOT NULL DEFAULT (0),
										is_optional_fee bit NOT NULL DEFAULT (0),
										is_per_year_tuition_fee bit NOT NULL DEFAULT (0),
										is_per_unit_tuition_fee bit NOT NULL DEFAULT (0),
										is_fixed_amount_tuition_fee bit NOT NULL DEFAULT (0),
										is_special_class_tuition_fee bit NOT NULL DEFAULT (0),
										international_percentage float NULL,
										remarks varchar (100) NULL)

		DECLARE @sysid_student varchar (50)
		DECLARE @sysid_enrolmentlevel varchar (50)
		DECLARE @sysid_feelevel varchar (50)
		DECLARE @sysid_semester varchar (50)
		DECLARE @is_graduate_student bit
		DECLARE @is_international bit
		DECLARE @is_marked_deleted bit

		INSERT INTO @student_level_table (sysid_student, sysid_enrolmentlevel, sysid_feelevel, sysid_semester, is_graduate_student, 
				is_international, is_marked_deleted)
			SELECT
				ssl_list.var_str AS sysid_student,
				sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
				sel.sysid_feelevel AS sysid_feelevel,
				sel.sysid_semester AS sysid_semester,
				sel.is_graduate_student AS is_graduate_student,
				sel.is_international AS is_international,
				sel.is_marked_deleted AS is_marked_deleted
			FROM
				ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
			INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
			INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
			INNER JOIN ums.IterateListToTable (@sysid_enrolmentlevel_list, ',') AS sel_list ON sel_list.var_str = sel.sysid_enrolmentlevel


		DECLARE student_level_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
			FOR SELECT slt.sysid_student, slt.sysid_enrolmentlevel, slt.sysid_feelevel, slt.sysid_semester, slt.is_graduate_student, 
					slt.is_international, slt.is_marked_deleted	
				FROM 			
					@student_level_table AS slt

		OPEN student_level_cursor

		FETCH NEXT FROM student_level_cursor
			INTO @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, @is_graduate_student, @is_international, @is_marked_deleted

		WHILE @@FETCH_STATUS = 0
		BEGIN	

			INSERT INTO @school_fee_details_table (return_table_id, sysid_student, sysid_enrolmentlevel, sysid_feedetails, sysid_feeparticular, 
					is_level_increase, is_added_level_fee, amount, fee_category_id, category_description, particular_description,  is_office_access, category_no, 
					additional_fee_id, optional_fee_id, is_additional_fee, is_optional_fee, is_per_year_tuition_fee, is_per_unit_tuition_fee, 
					is_fixed_amount_tuition_fee, is_special_class_tuition_fee, international_percentage, remarks)
			EXECUTE 
					ums.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
										@is_graduate_student, @is_international, 1, @is_marked_deleted, 0, @system_user_id
			
			
			FETCH NEXT FROM student_level_cursor
				INTO @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, @is_graduate_student, @is_international, @is_marked_deleted


		END

		CLOSE student_level_cursor
		DEALLOCATE student_level_cursor

		SELECT
			table_id,
			sysid_student,
			sysid_enrolmentlevel,
			sysid_feedetails,
			sysid_feeparticular,
			is_level_increase,
			is_added_level_fee,
			amount,
			fee_category_id,
			category_description,
			particular_description,
			is_office_access,
			category_no,
			additional_fee_id,
			optional_fee_id,
			is_additional_fee,
			is_optional_fee,
			is_per_year_tuition_fee,
			is_per_unit_tuition_fee,
			is_fixed_amount_tuition_fee,
			is_special_class_tuition_fee,
			international_percentage
		FROM
			@school_fee_details_table
		ORDER BY
			sysid_student, category_no, particular_description ASC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a student load', 'Student Load'		
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad')
   DROP PROCEDURE ums.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad
GO

CREATE PROCEDURE ums.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad

	@sysid_student_list nvarchar (MAX) = '',
	@exclude_sysid_enrolmentlevel_list nvarchar (MAX) = '',
	@date_ending datetime,
	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsStudentDataControllerSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		--NOTE: IF THIS PROCEDURE IS UPDATED, COPY THE UPDATED CODES IN THE PROCEDURE IsExistsPaymentBySysIDStudentDateStartEndStudentPayments##################
		--THIS IS DUE TO "AN INSERT EXEC statement cannot be nested." error so multiple calling of procedure cannot be done.

		DECLARE @balance_forward_table TABLE (table_id int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
										sysid_student varchar (50) NOT NULL,
										amount decimal (12, 2) NOT NULL)

		DECLARE @student_level_table TABLE (table_id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
										sysid_student varchar (50) NULL,
										sysid_enrolmentlevel varchar (50) NULL,
										sysid_feelevel varchar (50) NULL,
										sysid_semester varchar (50) NULL,
										is_graduate_student bit NOT NULL DEFAULT (0),
										is_international bit NOT NULL DEFAULT (0),
										is_marked_deleted bit NOT NULL DEFAULT (0),
										enrolment_level_no int NOT NULL DEFAULT (0))

		DECLARE @school_fee_details_table TABLE (table_id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
										return_table_id int NOT NULL DEFAULT (0),
										sysid_student varchar (50) NOT NULL,
										sysid_enrolmentlevel varchar (50) NULL,
										sysid_feedetails varchar (50) NULL,
										sysid_feeparticular varchar (50) NULL,
										is_level_increase bit NOT NULL DEFAULT (0),
										is_added_level_fee bit NOT NULL DEFAULT (0),
										amount decimal (12, 2) NOT NULL,
										fee_category_id varchar (50) NOT NULL,
										category_description varchar (100) NOT NULL,
										particular_description varchar (100) NOT NULL,
										is_office_access bit NOT NULL DEFAULT (0),			
										category_no tinyint NOT NULL,
										additional_fee_id bigint NULL,
										optional_fee_id bigint NULL,
										is_additional_fee bit NOT NULL DEFAULT (0),
										is_optional_fee bit NOT NULL DEFAULT (0),
										is_per_year_tuition_fee bit NOT NULL DEFAULT (0),
										is_per_unit_tuition_fee bit NOT NULL DEFAULT (0),
										is_fixed_amount_tuition_fee bit NOT NULL DEFAULT (0),
										is_special_class_tuition_fee bit NOT NULL DEFAULT (0),
										international_percentage float NULL,
										remarks varchar (100) NULL)

		DECLARE @sysid_student varchar (50)
		DECLARE @sysid_enrolmentlevel varchar (50)
		DECLARE @sysid_feelevel varchar (50)
		DECLARE @sysid_semester varchar (50)
		DECLARE @is_graduate_student bit
		DECLARE @is_international bit
		DECLARE @is_marked_deleted bit

		DECLARE @total_student_balance_forwarded decimal (12, 2)
		DECLARE @total_tuition decimal (12, 2)
		DECLARE @total_reimbursements decimal (12, 2)
		DECLARE @total_credit_memo decimal (12, 2)
		DECLARE @total_payments decimal (12, 2)
		DECLARE @total_discounts decimal (12, 2)

		IF (NOT ISNULL(@exclude_sysid_enrolmentlevel_list, '') = '')
		BEGIN

			INSERT INTO @student_level_table (sysid_student, sysid_enrolmentlevel, sysid_feelevel, sysid_semester, is_graduate_student, 
					is_international, is_marked_deleted, enrolment_level_no)
				SELECT
					ssl_list.var_str AS sysid_student,
					sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sel.sysid_feelevel AS sysid_feelevel,
					sel.sysid_semester AS sysid_semester,
					sel.is_graduate_student AS is_graduate_student,
					sel.is_international AS is_international,
					sel.is_marked_deleted AS is_marked_deleted,
					sel.enrolment_level_no AS enrolment_level_no
				FROM
					ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
				INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
				INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
				INNER JOIN ums.school_year AS sy ON sy.year_id = sfi.year_id
				INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
				LEFT JOIN ums.IterateListToTable (@exclude_sysid_enrolmentlevel_list, ',') AS esel_list ON esel_list.var_str = sel.sysid_enrolmentlevel
				INNER JOIN
					(

						SELECT
							inner_sec.sysid_student AS sysid_student,
							inner_sy.year_id AS year_id
						FROM
							ums.student_enrolment_course AS inner_sec
						INNER JOIN ums.student_enrolment_level AS inner_sel ON inner_sel.sysid_enrolmentcourse = inner_sec.sysid_enrolmentcourse
						INNER JOIN ums.IterateListToTable (@exclude_sysid_enrolmentlevel_list, ',') AS inner_esel_list ON 
										inner_esel_list.var_str = inner_sel.sysid_enrolmentlevel
						INNER JOIN ums.school_fee_level AS inner_sfl ON inner_sfl.sysid_feelevel = inner_sel.sysid_feelevel
						INNER JOIN ums.school_fee_information AS inner_sfi ON inner_sfi.sysid_schoolfee = inner_sfl.sysid_schoolfee
						INNER JOIN ums.school_year AS inner_sy ON inner_sy.year_id = inner_sfi.year_id

					) AS filter_sel ON filter_sel.sysid_student = ssl_list.var_str
				WHERE
					(cg.is_semestral = 0) AND			--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
					(NOT sy.date_start > @date_ending) AND
					(NOT sy.year_id = filter_sel.year_id) AND
					(esel_list.var_str IS NULL)
				UNION ALL
				SELECT
					ssl_list.var_str AS sysid_student,
					sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sel.sysid_feelevel AS sysid_feelevel,
					sel.sysid_semester AS sysid_semester,
					sel.is_graduate_student AS is_graduate_student,
					sel.is_international AS is_international,
					sel.is_marked_deleted AS is_marked_deleted,
					sel.enrolment_level_no AS enrolment_level_no
				FROM
					ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
				INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sel.sysid_semester
				INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
				LEFT JOIN ums.IterateListToTable (@exclude_sysid_enrolmentlevel_list, ',') AS esel_list ON esel_list.var_str = sel.sysid_enrolmentlevel
				INNER JOIN
					(

						SELECT
							inner_sec.sysid_student AS sysid_student,
							inner_sel.sysid_semester AS sysid_semester
						FROM
							ums.student_enrolment_course AS inner_sec
						INNER JOIN ums.student_enrolment_level AS inner_sel ON inner_sel.sysid_enrolmentcourse = inner_sec.sysid_enrolmentcourse
						INNER JOIN ums.IterateListToTable (@exclude_sysid_enrolmentlevel_list, ',') AS inner_esel_list ON 
										inner_esel_list.var_str = inner_sel.sysid_enrolmentlevel

					) AS filter_sel ON filter_sel.sysid_student = ssl_list.var_str
				WHERE
					(cg.is_semestral = 1) AND			--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
					(NOT sel.sysid_semester IS NULL AND NOT sel.sysid_semester = '') AND
					(NOT sri.date_start > @date_ending) AND
					(NOT filter_sel.sysid_semester IS NULL AND NOT filter_sel.sysid_semester = '') AND
					(NOT sri.sysid_semester = filter_sel.sysid_semester) AND
					(esel_list.var_str IS NULL)
				UNION ALL
				SELECT	--------------FOR ENROLMENT LEVELS THAT HAS BEEN ENROLLED/DELETED ON THE SAME SCHOOL YEAR/SEMESTER OF THE EXCLUDED LEVEL----------------------
					ssl_list.var_str AS sysid_student,								--this will include in the balance carried forward any additional fee
					sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,				--that has been created for the withdrawn/deleted level that is of the same
					sel.sysid_feelevel AS sysid_feelevel,							--year/semester based on the excluded levels
					sel.sysid_semester AS sysid_semester,
					sel.is_graduate_student AS is_graduate_student,
					sel.is_international AS is_international,
					sel.is_marked_deleted AS is_marked_deleted,
					sel.enrolment_level_no AS enrolment_level_no
				FROM
					ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
				INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
				INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
				INNER JOIN ums.school_year AS sy ON sy.year_id = sfi.year_id
				INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
				LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sel.sysid_semester
				LEFT JOIN ums.IterateListToTable (@exclude_sysid_enrolmentlevel_list, ',') AS esel_list ON esel_list.var_str = sel.sysid_enrolmentlevel	
				INNER JOIN
					(

						SELECT
							inner_sec.sysid_student AS sysid_student,
							inner_sel.sysid_semester AS sysid_semester,
							inner_sel.is_marked_deleted AS is_marked_deleted,
							inner_sel.enrolment_level_no AS enrolment_level_no,
							inner_sy.year_id AS year_id,
							inner_cg.is_semestral AS is_semestral
						FROM
							ums.student_enrolment_course AS inner_sec
						INNER JOIN ums.student_enrolment_level AS inner_sel ON inner_sel.sysid_enrolmentcourse = inner_sec.sysid_enrolmentcourse
						INNER JOIN ums.IterateListToTable (@exclude_sysid_enrolmentlevel_list, ',') AS inner_esel_list ON 
										inner_esel_list.var_str = inner_sel.sysid_enrolmentlevel
						INNER JOIN ums.school_fee_level AS inner_sfl ON inner_sfl.sysid_feelevel = inner_sel.sysid_feelevel
						INNER JOIN ums.school_fee_information AS inner_sfi ON inner_sfi.sysid_schoolfee = inner_sfl.sysid_schoolfee
						INNER JOIN ums.school_year AS inner_sy ON inner_sy.year_id = inner_sfi.year_id
						INNER JOIN ums.year_level_information AS inner_yli ON inner_yli.year_level_id = inner_sfl.year_level_id
						INNER JOIN ums.course_group AS inner_cg ON inner_cg.course_group_id = inner_yli.course_group_id

					) AS filter_sel ON filter_sel.sysid_student = ssl_list.var_str
				WHERE
					(esel_list.var_str IS NULL) AND		--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
					(((filter_sel.is_semestral = 0) AND	--yearly
					((sy.year_id = filter_sel.year_id) OR
					((NOT sel.sysid_semester IS NULL AND NOT sel.sysid_semester = '') AND
					(sri.year_id = filter_sel.year_id)))) OR						
					(((NOT filter_sel.sysid_semester IS NULL AND NOT filter_sel.sysid_semester = '') AND --semestral
												(filter_sel.is_semestral = 1)) AND 
					(((NOT sel.sysid_semester IS NULL AND NOT sel.sysid_semester = '') AND
					(sri.sysid_semester = filter_sel.sysid_semester)) OR
					((cg.is_semestral = 0) AND (sy.year_id = filter_sel.year_id)))))
				ORDER BY
					enrolment_level_no ASC

		END
		ELSE		--THE LEVEL IS A CANDIDATE FOR ENROLMENT
		BEGIN

			INSERT INTO @student_level_table (sysid_student, sysid_enrolmentlevel, sysid_feelevel, sysid_semester, is_graduate_student, 
					is_international, is_marked_deleted, enrolment_level_no)
				SELECT
					ssl_list.var_str AS sysid_student,
					sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sel.sysid_feelevel AS sysid_feelevel,
					sel.sysid_semester AS sysid_semester,
					sel.is_graduate_student AS is_graduate_student,
					sel.is_international AS is_international,
					sel.is_marked_deleted AS is_marked_deleted,
					sel.enrolment_level_no AS enrolment_level_no
				FROM
					ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
				INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
				INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
				INNER JOIN ums.school_year AS sy ON sy.year_id = sfi.year_id
				INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
				WHERE
					(cg.is_semestral = 0) AND			--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
					((NOT sy.date_start > @date_ending) OR									
					(DATEADD(dd, 1, @date_ending) BETWEEN sy.date_start AND sy.date_end))	
				UNION ALL
				SELECT
					ssl_list.var_str AS sysid_student,
					sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					sel.sysid_feelevel AS sysid_feelevel,
					sel.sysid_semester AS sysid_semester,
					sel.is_graduate_student AS is_graduate_student,
					sel.is_international AS is_international,
					sel.is_marked_deleted AS is_marked_deleted,
					sel.enrolment_level_no AS enrolment_level_no
				FROM
					ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
				INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sel.sysid_semester
				INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
				INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
				WHERE
					(cg.is_semestral = 1) AND			--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
					(NOT sel.sysid_semester IS NULL AND NOT sel.sysid_semester = '') AND
					((NOT sri.date_start > @date_ending) OR									
					(DATEADD(dd, 1, @date_ending) BETWEEN sri.date_start AND sri.date_end))	
				ORDER BY
					enrolment_level_no ASC

		END

		DECLARE student_level_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
			FOR SELECT slt.sysid_student, slt.sysid_enrolmentlevel, slt.sysid_feelevel, slt.sysid_semester, slt.is_graduate_student, 
					slt.is_international, slt.is_marked_deleted	
				FROM 			
					@student_level_table AS slt

		OPEN student_level_cursor

		FETCH NEXT FROM student_level_cursor
			INTO @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, @is_graduate_student, @is_international, @is_marked_deleted

		WHILE @@FETCH_STATUS = 0
		BEGIN	

			INSERT INTO @school_fee_details_table (return_table_id, sysid_student, sysid_enrolmentlevel, sysid_feedetails, sysid_feeparticular, 
					is_level_increase, is_added_level_fee, amount, fee_category_id, category_description, particular_description,  is_office_access, category_no, 
					additional_fee_id, optional_fee_id, is_additional_fee, is_optional_fee, is_per_year_tuition_fee, is_per_unit_tuition_fee, 
					is_fixed_amount_tuition_fee, is_special_class_tuition_fee, international_percentage, remarks)
			EXECUTE 
					ums.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
										@is_graduate_student, @is_international, 1, @is_marked_deleted, 0, @system_user_id
			
			
			FETCH NEXT FROM student_level_cursor
				INTO @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, @is_graduate_student, @is_international, @is_marked_deleted


		END

		CLOSE student_level_cursor
		DEALLOCATE student_level_cursor

		DECLARE student_list_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
			FOR SELECT ssl_list.var_str
				FROM 			
					ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list

		OPEN student_list_cursor

		FETCH NEXT FROM student_list_cursor
			INTO @sysid_student

		WHILE @@FETCH_STATUS = 0
		BEGIN	

			SELECT @total_tuition = CASE WHEN
											((NOT SUM(sfdt.amount) = 0) AND (NOT SUM(sfdt.amount) IS NULL))
										THEN
											(SUM(sfdt.amount))
										ELSE
											(0)
										END
									FROM
										@school_fee_details_table AS sfdt 
									WHERE
										((sfdt.sysid_feeparticular IS NULL) OR ((NOT sfdt.sysid_feeparticular IS NULL) AND (((sfdt.category_no IN (1)) AND
										(sfdt.is_per_year_tuition_fee = 1 OR sfdt.is_per_unit_tuition_fee = 1 OR
											sfdt.is_fixed_amount_tuition_fee = 1 OR sfdt.is_special_class_tuition_fee = 1)) OR
										(NOT sfdt.category_no IN (1))))) AND
										(sfdt.sysid_student = @sysid_student)

			
			SELECT @total_reimbursements = CASE WHEN
											((NOT SUM(srb.amount) = 0) AND (NOT SUM(srb.amount) IS NULL))
										THEN
											(SUM(srb.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_reimbursements AS srb
									WHERE
										((srb.reimbursement_date IS NULL) OR ((NOT srb.reimbursement_date IS NULL) AND (NOT srb.reimbursement_date > @date_ending))) AND
										(srb.sysid_student = @sysid_student)

			SELECT @total_credit_memo = CASE WHEN
											((NOT SUM(scm.amount) = 0) AND (NOT SUM(scm.amount) IS NULL))
										THEN
											(SUM(scm.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_credit_memo AS scm
									WHERE
										((scm.memo_date IS NULL) OR ((NOT scm.memo_date IS NULL) AND (NOT scm.memo_date > @date_ending))) AND
										(scm.sysid_student = @sysid_student)


			SELECT @total_payments = CASE WHEN
											((NOT SUM(stp.amount) = 0) AND (NOT SUM(stp.amount) IS NULL))
										THEN
											((SUM(stp.amount)) + (SUM(stp.discount_amount)))
										ELSE
											(0)
										END
									FROM
										ums.student_payments AS stp 
									WHERE
										((stp.payment_date IS NULL) OR ((NOT stp.payment_date IS NULL) AND (NOT stp.payment_date > @date_ending))) AND
										(stp.sysid_student = @sysid_student)

			SELECT @total_discounts = CASE WHEN
											((NOT SUM(std.amount) = 0) AND (NOT SUM(std.amount) IS NULL))
										THEN
											(SUM(std.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_discounts AS std
									INNER JOIN ums.student_scholarship AS sts ON sts.sysid_studentscholarship = std.sysid_studentscholarship
									INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sts.sysid_enrolmentlevel
									INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
									WHERE
										(((sts.is_marked_deleted IS NULL) OR ((NOT sts.is_marked_deleted IS NULL) AND (sts.is_marked_deleted = 0))) AND 
										((std.discount_date IS NULL) OR ((NOT std.discount_date IS NULL) AND (NOT std.discount_date > @date_ending)))) AND
										(sec.sysid_student = @sysid_student)

			SELECT @total_student_balance_forwarded = CASE WHEN
											((NOT SUM(sbf.amount) = 0) AND (NOT SUM(sbf.amount) IS NULL))
										THEN
											(SUM(sbf.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_balance_forwarded AS sbf
									WHERE
										(sbf.sysid_student = @sysid_student)


			INSERT INTO @balance_forward_table (sysid_student, amount) VALUES (@sysid_student, 
				((@total_tuition + @total_reimbursements + @total_student_balance_forwarded) - (@total_payments + @total_credit_memo + @total_discounts)))
			
			
			FETCH NEXT FROM student_list_cursor
				INTO @sysid_student

		END

		CLOSE student_list_cursor
		DEALLOCATE student_list_cursor

		SELECT
			table_id,
			sysid_student,
			amount
		FROM
			@balance_forward_table
		ORDER BY
			sysid_student ASC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a student load', 'Student Load'		
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad')
   DROP PROCEDURE ums.SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad
GO

CREATE PROCEDURE ums.SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad

	@sysid_student_list nvarchar (MAX) = '',
	@date_ending datetime,

	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1)
	BEGIN

		DECLARE @account_receivable_table TABLE (table_id int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
												sysid_student varchar (50) NOT NULL,
												amount decimal (12, 2) NOT NULL)

		DECLARE @student_level_table TABLE (table_id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
										sysid_student varchar (50) NULL,
										sysid_enrolmentlevel varchar (50) NULL,
										sysid_feelevel varchar (50) NULL,
										sysid_semester varchar (50) NULL,
										is_graduate_student bit NOT NULL DEFAULT (0),
										is_international bit NOT NULL DEFAULT (0),
										is_marked_deleted bit NOT NULL DEFAULT (0),
										enrolment_level_no int NOT NULL DEFAULT (0))

		DECLARE @school_fee_details_table TABLE (table_id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
										return_table_id int NOT NULL DEFAULT (0),
										sysid_student varchar (50) NOT NULL,
										sysid_enrolmentlevel varchar (50) NULL,
										sysid_feedetails varchar (50) NULL,
										sysid_feeparticular varchar (50) NULL,
										is_level_increase bit NOT NULL DEFAULT (0),
										is_added_level_fee bit NOT NULL DEFAULT (0),
										amount decimal (12, 2) NOT NULL,
										fee_category_id varchar (50) NOT NULL,
										category_description varchar (100) NOT NULL,
										particular_description varchar (100) NOT NULL,
										is_office_access bit NOT NULL DEFAULT (0),			
										category_no tinyint NOT NULL,
										additional_fee_id bigint NULL,
										optional_fee_id bigint NULL,
										is_additional_fee bit NOT NULL DEFAULT (0),
										is_optional_fee bit NOT NULL DEFAULT (0),
										is_per_year_tuition_fee bit NOT NULL DEFAULT (0),
										is_per_unit_tuition_fee bit NOT NULL DEFAULT (0),
										is_fixed_amount_tuition_fee bit NOT NULL DEFAULT (0),
										is_special_class_tuition_fee bit NOT NULL DEFAULT (0),
										international_percentage float NULL,
										remarks varchar (100) NULL)

		DECLARE @sysid_student varchar (50)
		DECLARE @sysid_enrolmentlevel varchar (50)
		DECLARE @sysid_feelevel varchar (50)
		DECLARE @sysid_semester varchar (50)
		DECLARE @is_graduate_student bit
		DECLARE @is_international bit
		DECLARE @is_marked_deleted bit

		DECLARE @total_student_balance_forwarded decimal (12, 2)
		DECLARE @total_tuition decimal (12, 2)
		DECLARE @total_reimbursements decimal (12, 2)
		DECLARE @total_credit_memo decimal (12, 2)
		DECLARE @total_payments decimal (12, 2)
		DECLARE @total_discounts decimal (12, 2)

		INSERT INTO @student_level_table (sysid_student, sysid_enrolmentlevel, sysid_feelevel, sysid_semester, is_graduate_student, 
				is_international, is_marked_deleted, enrolment_level_no)
			SELECT
				ssl_list.var_str AS sysid_student,
				sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
				sel.sysid_feelevel AS sysid_feelevel,
				sel.sysid_semester AS sysid_semester,
				sel.is_graduate_student AS is_graduate_student,
				sel.is_international AS is_international,
				sel.is_marked_deleted AS is_marked_deleted,
				sel.enrolment_level_no AS enrolment_level_no
			FROM
				ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
			INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
			INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
			INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
			INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
			INNER JOIN ums.school_year AS sy ON sy.year_id = sfi.year_id
			INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
			WHERE
				(cg.is_semestral = 0) AND			--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
				(NOT sy.date_start > @date_ending)
			UNION ALL
			SELECT
				ssl_list.var_str AS sysid_student,
				sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
				sel.sysid_feelevel AS sysid_feelevel,
				sel.sysid_semester AS sysid_semester,
				sel.is_graduate_student AS is_graduate_student,
				sel.is_international AS is_international,
				sel.is_marked_deleted AS is_marked_deleted,
				sel.enrolment_level_no AS enrolment_level_no
			FROM
				ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
			INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
			INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
			INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sel.sysid_semester
			INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
			WHERE
				(cg.is_semestral = 1) AND			--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
				(NOT sel.sysid_semester IS NULL AND NOT sel.sysid_semester = '') AND
				(NOT sri.date_start > @date_ending)
			ORDER BY
				enrolment_level_no ASC

		DECLARE student_level_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
			FOR SELECT slt.sysid_student, slt.sysid_enrolmentlevel, slt.sysid_feelevel, slt.sysid_semester, slt.is_graduate_student, 
					slt.is_international, slt.is_marked_deleted	
				FROM 			
					@student_level_table AS slt

		OPEN student_level_cursor

		FETCH NEXT FROM student_level_cursor
			INTO @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, @is_graduate_student, @is_international, @is_marked_deleted

		WHILE @@FETCH_STATUS = 0
		BEGIN	

			INSERT INTO @school_fee_details_table (return_table_id, sysid_student, sysid_enrolmentlevel, sysid_feedetails, sysid_feeparticular, 
					is_level_increase, is_added_level_fee, amount, fee_category_id, category_description, particular_description,  is_office_access, category_no, 
					additional_fee_id, optional_fee_id, is_additional_fee, is_optional_fee, is_per_year_tuition_fee, is_per_unit_tuition_fee, 
					is_fixed_amount_tuition_fee, is_special_class_tuition_fee, international_percentage, remarks)
			EXECUTE 
					ums.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
										@is_graduate_student, @is_international, 1, @is_marked_deleted, 0, @system_user_id
			
			
			FETCH NEXT FROM student_level_cursor
				INTO @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, @is_graduate_student, @is_international, @is_marked_deleted


		END

		CLOSE student_level_cursor
		DEALLOCATE student_level_cursor

		DECLARE student_list_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
			FOR SELECT ssl_list.var_str
				FROM 			
					ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list

		OPEN student_list_cursor

		FETCH NEXT FROM student_list_cursor
			INTO @sysid_student

		WHILE @@FETCH_STATUS = 0
		BEGIN	

			SELECT @total_tuition = CASE WHEN
											((NOT SUM(sfdt.amount) = 0) AND (NOT SUM(sfdt.amount) IS NULL))
										THEN
											(SUM(sfdt.amount))
										ELSE
											(0)
										END
									FROM
										@school_fee_details_table AS sfdt 
									WHERE
										((sfdt.sysid_feeparticular IS NULL) OR ((NOT sfdt.sysid_feeparticular IS NULL) AND (((sfdt.category_no IN (1)) AND
										(sfdt.is_per_year_tuition_fee = 1 OR sfdt.is_per_unit_tuition_fee = 1 OR
											sfdt.is_fixed_amount_tuition_fee = 1 OR sfdt.is_special_class_tuition_fee = 1)) OR
										(NOT sfdt.category_no IN (1))))) AND
										(sfdt.sysid_student = @sysid_student)

			
			SELECT @total_reimbursements = CASE WHEN
											((NOT SUM(srb.amount) = 0) AND (NOT SUM(srb.amount) IS NULL))
										THEN
											(SUM(srb.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_reimbursements AS srb
									WHERE
										((srb.reimbursement_date IS NULL) OR ((NOT srb.reimbursement_date IS NULL) AND (NOT srb.reimbursement_date > @date_ending))) AND
										(srb.sysid_student = @sysid_student)

			SELECT @total_credit_memo = CASE WHEN
											((NOT SUM(scm.amount) = 0) AND (NOT SUM(scm.amount) IS NULL))
										THEN
											(SUM(scm.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_credit_memo AS scm
									WHERE
										((scm.memo_date IS NULL) OR ((NOT scm.memo_date IS NULL) AND (NOT scm.memo_date > @date_ending))) AND
										(scm.sysid_student = @sysid_student)


			SELECT @total_payments = CASE WHEN
											((NOT SUM(stp.amount) = 0) AND (NOT SUM(stp.amount) IS NULL))
										THEN
											((SUM(stp.amount)) + (SUM(stp.discount_amount)))
										ELSE
											(0)
										END
									FROM
										ums.student_payments AS stp 
									WHERE
										(stp.sysid_student = @sysid_student)	--no comparison on @date_ending because student payments must be sum-up

			SELECT @total_discounts = CASE WHEN
											((NOT SUM(std.amount) = 0) AND (NOT SUM(std.amount) IS NULL))
										THEN
											(SUM(std.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_discounts AS std
									INNER JOIN ums.student_scholarship AS sts ON sts.sysid_studentscholarship = std.sysid_studentscholarship
									INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sts.sysid_enrolmentlevel
									INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
									WHERE
										(((sts.is_marked_deleted IS NULL) OR ((NOT sts.is_marked_deleted IS NULL) AND (sts.is_marked_deleted = 0))) AND 
										((std.discount_date IS NULL) OR ((NOT std.discount_date IS NULL) AND (NOT std.discount_date > @date_ending)))) AND
										(sec.sysid_student = @sysid_student)

			SELECT @total_student_balance_forwarded = CASE WHEN
											((NOT SUM(sbf.amount) = 0) AND (NOT SUM(sbf.amount) IS NULL))
										THEN
											(SUM(sbf.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_balance_forwarded AS sbf
									WHERE
										(sbf.sysid_student = @sysid_student)


			INSERT INTO @account_receivable_table (sysid_student, amount) VALUES (@sysid_student, 
				((@total_tuition + @total_reimbursements + @total_student_balance_forwarded) - (@total_payments + @total_credit_memo + @total_discounts)))
			
			
			FETCH NEXT FROM student_list_cursor
				INTO @sysid_student

		END

		CLOSE student_list_cursor
		DEALLOCATE student_list_cursor

		SELECT
			table_id,
			sysid_student,
			amount
		FROM
			@account_receivable_table
		WHERE
			(amount > 0)
		ORDER BY
			sysid_student ASC
		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a student load', 'Student Load'		
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad')
   DROP PROCEDURE ums.SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad
GO

CREATE PROCEDURE ums.SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad

	@sysid_student_list nvarchar (MAX) = '',
	@date_start datetime,
	@date_end datetime,
	@cut_off_date datetime,

	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1)
	BEGIN

		DECLARE @account_receivable_table TABLE (table_id int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
												sysid_student varchar (50) NOT NULL,
												total_beginning_balance decimal (12, 2) NULL,
												total_tuition decimal (12, 2) NULL,
												total_reimbursement decimal (12, 2) NULL,
												total_discount decimal (12, 2) NULL,
												total_payment decimal (12, 2) NULL,
												total_credit_memo decimal (12, 2) NULL,
												total_ending_balance decimal (12, 2) NULL)

		DECLARE @student_level_table TABLE (table_id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
												sysid_student varchar (50) NULL,
												sysid_enrolmentlevel varchar (50) NULL,
												sysid_feelevel varchar (50) NULL,
												sysid_semester varchar (50) NULL,
												is_graduate_student bit NOT NULL DEFAULT (0),
												is_international bit NOT NULL DEFAULT (0),
												is_marked_deleted bit NOT NULL DEFAULT (0),
												enrolment_level_no int NOT NULL DEFAULT (0))

		DECLARE @school_fee_details_table TABLE (table_id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
												return_table_id int NOT NULL DEFAULT (0),
												sysid_student varchar (50) NOT NULL,
												sysid_enrolmentlevel varchar (50) NULL,
												sysid_feedetails varchar (50) NULL,
												sysid_feeparticular varchar (50) NULL,
												is_level_increase bit NOT NULL DEFAULT (0),
												is_added_level_fee bit NOT NULL DEFAULT (0),
												amount decimal (12, 2) NOT NULL,
												fee_category_id varchar (50) NOT NULL,
												category_description varchar (100) NOT NULL,
												particular_description varchar (100) NOT NULL,
												is_office_access bit NOT NULL DEFAULT (0),			
												category_no tinyint NOT NULL,
												additional_fee_id bigint NULL,
												optional_fee_id bigint NULL,
												is_additional_fee bit NOT NULL DEFAULT (0),
												is_optional_fee bit NOT NULL DEFAULT (0),
												is_per_year_tuition_fee bit NOT NULL DEFAULT (0),
												is_per_unit_tuition_fee bit NOT NULL DEFAULT (0),
												is_fixed_amount_tuition_fee bit NOT NULL DEFAULT (0),
												is_special_class_tuition_fee bit NOT NULL DEFAULT (0),
												international_percentage float NULL,
												remarks varchar (100) NULL)

		DECLARE @beginning_date_ending datetime

		DECLARE @sysid_student varchar (50)
		DECLARE @sysid_enrolmentlevel varchar (50)
		DECLARE @sysid_feelevel varchar (50)
		DECLARE @sysid_semester varchar (50)
		DECLARE @is_graduate_student bit
		DECLARE @is_international bit
		DECLARE @is_marked_deleted bit

		DECLARE @total_student_balance_forwarded decimal (12, 2)
		DECLARE @total_tuition decimal (12, 2)
		DECLARE @total_reimbursement decimal (12, 2)
		DECLARE @total_discount decimal (12, 2)
		DECLARE @total_payment decimal (12, 2)
		DECLARE @total_credit_memo decimal (12, 2)

		--#########################################CODE FOR THE BEGINNING BALANCE FIELD##########################################################

		INSERT INTO @student_level_table (sysid_student, sysid_enrolmentlevel, sysid_feelevel, sysid_semester, is_graduate_student, 
				is_international, is_marked_deleted, enrolment_level_no)
			SELECT
				ssl_list.var_str AS sysid_student,
				sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
				sel.sysid_feelevel AS sysid_feelevel,
				sel.sysid_semester AS sysid_semester,
				sel.is_graduate_student AS is_graduate_student,
				sel.is_international AS is_international,
				sel.is_marked_deleted AS is_marked_deleted,
				sel.enrolment_level_no AS enrolment_level_no
			FROM
				ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
			INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
			INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
			INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
			INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
			INNER JOIN ums.school_year AS sy ON sy.year_id = sfi.year_id
			INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
			WHERE
				(cg.is_semestral = 0) AND			--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
				(NOT sy.date_start > DATEADD(dd, -1, @date_start))
			UNION ALL
			SELECT
				ssl_list.var_str AS sysid_student,
				sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
				sel.sysid_feelevel AS sysid_feelevel,
				sel.sysid_semester AS sysid_semester,
				sel.is_graduate_student AS is_graduate_student,
				sel.is_international AS is_international,
				sel.is_marked_deleted AS is_marked_deleted,
				sel.enrolment_level_no AS enrolment_level_no
			FROM
				ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
			INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
			INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
			INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sel.sysid_semester
			INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
			WHERE
				(cg.is_semestral = 1) AND			--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
				(NOT sel.sysid_semester IS NULL AND NOT sel.sysid_semester = '') AND
				(NOT sri.date_start > DATEADD(dd, -1, @date_start))
			ORDER BY
				enrolment_level_no ASC

		DECLARE student_level_beginning_balance_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
			FOR SELECT slt.sysid_student, slt.sysid_enrolmentlevel, slt.sysid_feelevel, slt.sysid_semester, slt.is_graduate_student, 
					slt.is_international, slt.is_marked_deleted	
				FROM 			
					@student_level_table AS slt

		OPEN student_level_beginning_balance_cursor

		FETCH NEXT FROM student_level_beginning_balance_cursor
			INTO @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, @is_graduate_student, @is_international, @is_marked_deleted

		WHILE @@FETCH_STATUS = 0
		BEGIN	

			INSERT INTO @school_fee_details_table (return_table_id, sysid_student, sysid_enrolmentlevel, sysid_feedetails, sysid_feeparticular, 
					is_level_increase, is_added_level_fee, amount, fee_category_id, category_description, particular_description,  is_office_access, category_no, 
					additional_fee_id, optional_fee_id, is_additional_fee, is_optional_fee, is_per_year_tuition_fee, is_per_unit_tuition_fee, 
					is_fixed_amount_tuition_fee, is_special_class_tuition_fee, international_percentage, remarks)
			EXECUTE 
					ums.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
										@is_graduate_student, @is_international, 1, @is_marked_deleted, 0, @system_user_id
			
			
			FETCH NEXT FROM student_level_beginning_balance_cursor
				INTO @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, @is_graduate_student, @is_international, @is_marked_deleted


		END

		CLOSE student_level_beginning_balance_cursor
		DEALLOCATE student_level_beginning_balance_cursor

		DECLARE student_list_beginning_balance_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
			FOR SELECT ssl_list.var_str
				FROM 			
					ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list

		OPEN student_list_beginning_balance_cursor

		FETCH NEXT FROM student_list_beginning_balance_cursor
			INTO @sysid_student

		WHILE @@FETCH_STATUS = 0
		BEGIN	

			SELECT @total_tuition = CASE WHEN
											((NOT SUM(sfdt.amount) = 0) AND (NOT SUM(sfdt.amount) IS NULL))
										THEN
											(SUM(sfdt.amount))
										ELSE
											(0)
										END
									FROM
										@school_fee_details_table AS sfdt 
									WHERE
										((sfdt.sysid_feeparticular IS NULL) OR ((NOT sfdt.sysid_feeparticular IS NULL) AND (((sfdt.category_no IN (1)) AND
										(sfdt.is_per_year_tuition_fee = 1 OR sfdt.is_per_unit_tuition_fee = 1 OR
											sfdt.is_fixed_amount_tuition_fee = 1 OR sfdt.is_special_class_tuition_fee = 1)) OR
										(NOT sfdt.category_no IN (1))))) AND
										(sfdt.sysid_student = @sysid_student)

			
			SELECT @total_reimbursement = CASE WHEN
											((NOT SUM(srb.amount) = 0) AND (NOT SUM(srb.amount) IS NULL))
										THEN
											(SUM(srb.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_reimbursements AS srb
									WHERE
										((srb.reimbursement_date IS NULL) OR ((NOT srb.reimbursement_date IS NULL) AND (NOT srb.reimbursement_date > DATEADD(dd, -1, @date_start)))) AND
										(srb.sysid_student = @sysid_student)

			SELECT @total_credit_memo = CASE WHEN
											((NOT SUM(scm.amount) = 0) AND (NOT SUM(scm.amount) IS NULL))
										THEN
											(SUM(scm.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_credit_memo AS scm
									WHERE
										((scm.memo_date IS NULL) OR ((NOT scm.memo_date IS NULL) AND (NOT scm.memo_date > DATEADD(dd, -1, @date_start)))) AND
										(scm.sysid_student = @sysid_student)


			SELECT @total_payment = CASE WHEN
											((NOT SUM(stp.amount) = 0) AND (NOT SUM(stp.amount) IS NULL))
										THEN
											((SUM(stp.amount)) + (SUM(stp.discount_amount)))
										ELSE
											(0)
										END
									FROM
										ums.student_payments AS stp 
									WHERE
										((stp.payment_date IS NULL) OR ((NOT stp.payment_date IS NULL) AND (NOT stp.payment_date > DATEADD(dd, -1, @date_start)))) AND
										(stp.sysid_student = @sysid_student)

			SELECT @total_discount = CASE WHEN
											((NOT SUM(std.amount) = 0) AND (NOT SUM(std.amount) IS NULL))
										THEN
											(SUM(std.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_discounts AS std
									INNER JOIN ums.student_scholarship AS sts ON sts.sysid_studentscholarship = std.sysid_studentscholarship
									INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sts.sysid_enrolmentlevel
									INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
									WHERE
										(((sts.is_marked_deleted IS NULL) OR ((NOT sts.is_marked_deleted IS NULL) AND (sts.is_marked_deleted = 0))) AND 
										((std.discount_date IS NULL) OR ((NOT std.discount_date IS NULL) AND (NOT std.discount_date > DATEADD(dd, -1, @date_start))))) AND
										(sec.sysid_student = @sysid_student)

			SELECT @total_student_balance_forwarded = CASE WHEN
											((NOT SUM(sbf.amount) = 0) AND (NOT SUM(sbf.amount) IS NULL))
										THEN
											(SUM(sbf.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_balance_forwarded AS sbf
									WHERE
										(sbf.sysid_student = @sysid_student)


			INSERT INTO @account_receivable_table (sysid_student, total_beginning_balance) VALUES (@sysid_student, 
				((@total_tuition + @total_reimbursement + @total_student_balance_forwarded) - (@total_payment + @total_credit_memo + @total_discount)))
			
			
			FETCH NEXT FROM student_list_beginning_balance_cursor
				INTO @sysid_student

		END

		CLOSE student_list_beginning_balance_cursor
		DEALLOCATE student_list_beginning_balance_cursor


		--#######################################END CODE FOR THE BEGINNING BALANCE FIELD########################################################



		
		--#####################CODE FOR THE ASSESSMENT, REIMBURSEMENT, DISCOUNTS, PAYMENTS, CREDIT MEMO, BALANCE FIELD############################
		
		--clear the student level table
		DELETE FROM @student_level_table

		--clear the school fee details table
		DELETE FROM @school_fee_details_table

		--initialized the variables
		SET @total_tuition = 0
		SET @total_reimbursement = 0
		SET @total_discount = 0
		SET @total_payment = 0
		SET @total_credit_memo = 0

		INSERT INTO @student_level_table (sysid_student, sysid_enrolmentlevel, sysid_feelevel, sysid_semester, is_graduate_student, 
				is_international, is_marked_deleted, enrolment_level_no)
			SELECT
				ssl_list.var_str AS sysid_student,
				sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
				sel.sysid_feelevel AS sysid_feelevel,
				sel.sysid_semester AS sysid_semester,
				sel.is_graduate_student AS is_graduate_student,
				sel.is_international AS is_international,
				sel.is_marked_deleted AS is_marked_deleted,
				sel.enrolment_level_no AS enrolment_level_no
			FROM
				ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
			INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
			INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
			INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
			INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
			INNER JOIN ums.school_year AS sy ON sy.year_id = sfi.year_id
			INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
			WHERE
				(cg.is_semestral = 0) AND			--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))
			UNION ALL
			SELECT
				ssl_list.var_str AS sysid_student,
				sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
				sel.sysid_feelevel AS sysid_feelevel,
				sel.sysid_semester AS sysid_semester,
				sel.is_graduate_student AS is_graduate_student,
				sel.is_international AS is_international,
				sel.is_marked_deleted AS is_marked_deleted,
				sel.enrolment_level_no AS enrolment_level_no
			FROM
				ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
			INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
			INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
			INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sel.sysid_semester
			INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
			WHERE
				(cg.is_semestral = 1) AND			--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
				(NOT sel.sysid_semester IS NULL AND NOT sel.sysid_semester = '') AND
				((@date_start BETWEEN sri.date_start AND sri.date_end) AND (@date_end BETWEEN sri.date_start AND sri.date_end))
			ORDER BY
				enrolment_level_no ASC

		DECLARE student_level_current_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
			FOR SELECT slt.sysid_student, slt.sysid_enrolmentlevel, slt.sysid_feelevel, slt.sysid_semester, slt.is_graduate_student, 
					slt.is_international, slt.is_marked_deleted	
				FROM 			
					@student_level_table AS slt

		OPEN student_level_current_cursor

		FETCH NEXT FROM student_level_current_cursor
			INTO @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, @is_graduate_student, @is_international, @is_marked_deleted

		WHILE @@FETCH_STATUS = 0
		BEGIN	

			INSERT INTO @school_fee_details_table (return_table_id, sysid_student, sysid_enrolmentlevel, sysid_feedetails, sysid_feeparticular, 
					is_level_increase, is_added_level_fee, amount, fee_category_id, category_description, particular_description,  is_office_access, category_no, 
					additional_fee_id, optional_fee_id, is_additional_fee, is_optional_fee, is_per_year_tuition_fee, is_per_unit_tuition_fee, 
					is_fixed_amount_tuition_fee, is_special_class_tuition_fee, international_percentage, remarks)
			EXECUTE 
					ums.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
										@is_graduate_student, @is_international, 1, @is_marked_deleted, 0, @system_user_id
			
			
			FETCH NEXT FROM student_level_current_cursor
				INTO @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, @is_graduate_student, @is_international, @is_marked_deleted


		END

		CLOSE student_level_current_cursor
		DEALLOCATE student_level_current_cursor

		DECLARE student_list_current_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
			FOR SELECT ssl_list.var_str
				FROM 			
					ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list

		OPEN student_list_current_cursor

		FETCH NEXT FROM student_list_current_cursor
			INTO @sysid_student

		WHILE @@FETCH_STATUS = 0
		BEGIN	

			SELECT @total_tuition = CASE WHEN
											((NOT SUM(sfdt.amount) = 0) AND (NOT SUM(sfdt.amount) IS NULL))
										THEN
											(SUM(sfdt.amount))
										ELSE
											(0)
										END
									FROM
										@school_fee_details_table AS sfdt 
									WHERE
										((sfdt.sysid_feeparticular IS NULL) OR ((NOT sfdt.sysid_feeparticular IS NULL) AND (((sfdt.category_no IN (1)) AND
										(sfdt.is_per_year_tuition_fee = 1 OR sfdt.is_per_unit_tuition_fee = 1 OR
											sfdt.is_fixed_amount_tuition_fee = 1 OR sfdt.is_special_class_tuition_fee = 1)) OR
										(NOT sfdt.category_no IN (1))))) AND
										(sfdt.sysid_student = @sysid_student)

			
			SELECT @total_reimbursement = CASE WHEN
											((NOT SUM(srb.amount) = 0) AND (NOT SUM(srb.amount) IS NULL))
										THEN
											(SUM(srb.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_reimbursements AS srb
									WHERE
										((srb.reimbursement_date IS NULL) OR ((NOT srb.reimbursement_date IS NULL) AND 
										(srb.reimbursement_date BETWEEN @date_start AND @date_end) AND
										(NOT srb.reimbursement_date > @cut_off_date))) AND
										(srb.sysid_student = @sysid_student)

			SELECT @total_credit_memo = CASE WHEN
											((NOT SUM(scm.amount) = 0) AND (NOT SUM(scm.amount) IS NULL))
										THEN
											(SUM(scm.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_credit_memo AS scm
									WHERE
										((scm.memo_date IS NULL) OR ((NOT scm.memo_date IS NULL) AND 
										(scm.memo_date BETWEEN @date_start AND @date_end) AND
										(NOT scm.memo_date > @cut_off_date))) AND
										(scm.sysid_student = @sysid_student)


			SELECT @total_payment = CASE WHEN
											((NOT SUM(stp.amount) = 0) AND (NOT SUM(stp.amount) IS NULL))
										THEN
											((SUM(stp.amount)) + (SUM(stp.discount_amount)))
										ELSE
											(0)
										END
									FROM
										ums.student_payments AS stp 
									WHERE
										((stp.payment_date IS NULL) OR ((NOT stp.payment_date IS NULL) AND 
										(stp.payment_date BETWEEN @date_start AND @date_end) AND
										(NOT stp.payment_date > @cut_off_date))) AND
										(stp.sysid_student = @sysid_student)

			SELECT @total_discount = CASE WHEN
											((NOT SUM(std.amount) = 0) AND (NOT SUM(std.amount) IS NULL))
										THEN
											(SUM(std.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_discounts AS std
									INNER JOIN ums.student_scholarship AS sts ON sts.sysid_studentscholarship = std.sysid_studentscholarship
									INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sts.sysid_enrolmentlevel
									INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
									WHERE
										(((sts.is_marked_deleted IS NULL) OR ((NOT sts.is_marked_deleted IS NULL) AND (sts.is_marked_deleted = 0))) AND 
										((std.discount_date IS NULL) OR ((NOT std.discount_date IS NULL) AND 
										(std.discount_date BETWEEN @date_start AND @date_end) AND
										(NOT std.discount_date > @cut_off_date)))) AND
										(sec.sysid_student = @sysid_student)

			--NO NEED FOR THE STUDENT BALANCE FORWARDED BECAUSE THIS HAS BEEN RETRIEVED ON THE BEGINNING BALANCE FIELD

			UPDATE @account_receivable_table SET
				total_tuition = @total_tuition,
				total_reimbursement = @total_reimbursement,
				total_discount = @total_discount,
				total_payment = @total_payment,
				total_credit_memo = @total_credit_memo,
				total_ending_balance = ((total_beginning_balance + @total_tuition + @total_reimbursement) - (@total_payment + @total_credit_memo + @total_discount))
			WHERE
				sysid_student = @sysid_student

			
			FETCH NEXT FROM student_list_current_cursor
				INTO @sysid_student

		END

		CLOSE student_list_current_cursor
		DEALLOCATE student_list_current_cursor


		--#################END CODE FOR THE ASSESSMENT, REIMBURSEMENT, DISCOUNTS, PAYMENTS, CREDIT MEMO, BALANCE FIELD############################

		SELECT
			table_id,
			sysid_student,
			total_beginning_balance,
			total_tuition,
			total_reimbursement,
			total_discount,
			total_payment,
			total_credit_memo,
			total_ending_balance
		FROM
			@account_receivable_table
		ORDER BY
			sysid_student ASC
		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a student load', 'Student Load'		
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectBySysIDStudentListForStudentRunningBalanceStudentLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDStudentListForStudentRunningBalanceStudentLoad')
   DROP PROCEDURE ums.SelectBySysIDStudentListForStudentRunningBalanceStudentLoad
GO

CREATE PROCEDURE ums.SelectBySysIDStudentListForStudentRunningBalanceStudentLoad

	@sysid_student_list nvarchar (MAX) = '',

	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1)
	BEGIN

		DECLARE @account_receivable_table TABLE (table_id int IDENTITY (1, 1) NOT NULL PRIMARY KEY,
												sysid_student varchar (50) NOT NULL,
												amount decimal (12, 2) NOT NULL)

		DECLARE @student_level_table TABLE (table_id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
										sysid_student varchar (50) NULL,
										sysid_enrolmentlevel varchar (50) NULL,
										sysid_feelevel varchar (50) NULL,
										sysid_semester varchar (50) NULL,
										is_graduate_student bit NOT NULL DEFAULT (0),
										is_international bit NOT NULL DEFAULT (0),
										is_marked_deleted bit NOT NULL DEFAULT (0),
										enrolment_level_no int NOT NULL DEFAULT (0))

		DECLARE @school_fee_details_table TABLE (table_id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
										return_table_id int NOT NULL DEFAULT (0),
										sysid_student varchar (50) NOT NULL,
										sysid_enrolmentlevel varchar (50) NULL,
										sysid_feedetails varchar (50) NULL,
										sysid_feeparticular varchar (50) NULL,
										is_level_increase bit NOT NULL DEFAULT (0),
										is_added_level_fee bit NOT NULL DEFAULT (0),
										amount decimal (12, 2) NOT NULL,
										fee_category_id varchar (50) NOT NULL,
										category_description varchar (100) NOT NULL,
										particular_description varchar (100) NOT NULL,
										is_office_access bit NOT NULL DEFAULT (0),			
										category_no tinyint NOT NULL,
										additional_fee_id bigint NULL,
										optional_fee_id bigint NULL,
										is_additional_fee bit NOT NULL DEFAULT (0),
										is_optional_fee bit NOT NULL DEFAULT (0),
										is_per_year_tuition_fee bit NOT NULL DEFAULT (0),
										is_per_unit_tuition_fee bit NOT NULL DEFAULT (0),
										is_fixed_amount_tuition_fee bit NOT NULL DEFAULT (0),
										is_special_class_tuition_fee bit NOT NULL DEFAULT (0),
										international_percentage float NULL,
										remarks varchar (100) NULL)

		DECLARE @sysid_student varchar (50)
		DECLARE @sysid_enrolmentlevel varchar (50)
		DECLARE @sysid_feelevel varchar (50)
		DECLARE @sysid_semester varchar (50)
		DECLARE @is_graduate_student bit
		DECLARE @is_international bit
		DECLARE @is_marked_deleted bit

		DECLARE @total_student_balance_forwarded decimal (12, 2)
		DECLARE @total_tuition decimal (12, 2)
		DECLARE @total_reimbursements decimal (12, 2)
		DECLARE @total_credit_memo decimal (12, 2)
		DECLARE @total_payments decimal (12, 2)
		DECLARE @total_discounts decimal (12, 2)

		INSERT INTO @student_level_table (sysid_student, sysid_enrolmentlevel, sysid_feelevel, sysid_semester, is_graduate_student, 
				is_international, is_marked_deleted, enrolment_level_no)
			SELECT
				ssl_list.var_str AS sysid_student,
				sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
				sel.sysid_feelevel AS sysid_feelevel,
				sel.sysid_semester AS sysid_semester,
				sel.is_graduate_student AS is_graduate_student,
				sel.is_international AS is_international,
				sel.is_marked_deleted AS is_marked_deleted,
				sel.enrolment_level_no AS enrolment_level_no
			FROM
				ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
			INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
			INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
			INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
			INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
			INNER JOIN ums.school_year AS sy ON sy.year_id = sfi.year_id
			INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
			WHERE
				(cg.is_semestral = 0) 			--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
			UNION ALL
			SELECT
				ssl_list.var_str AS sysid_student,
				sel.sysid_enrolmentlevel AS sysid_enrolmentlevel,
				sel.sysid_feelevel AS sysid_feelevel,
				sel.sysid_semester AS sysid_semester,
				sel.is_graduate_student AS is_graduate_student,
				sel.is_international AS is_international,
				sel.is_marked_deleted AS is_marked_deleted,
				sel.enrolment_level_no AS enrolment_level_no
			FROM
				ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list	
			INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_student = ssl_list.var_str
			INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
			INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sel.sysid_semester
			INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
			WHERE
				(cg.is_semestral = 1) AND			--no is_marked_deleted because deleted levels might have additional fees to be added in the balance
				(NOT sel.sysid_semester IS NULL AND NOT sel.sysid_semester = '')
			ORDER BY
				enrolment_level_no ASC

		DECLARE student_level_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
			FOR SELECT slt.sysid_student, slt.sysid_enrolmentlevel, slt.sysid_feelevel, slt.sysid_semester, slt.is_graduate_student, 
					slt.is_international, slt.is_marked_deleted	
				FROM 			
					@student_level_table AS slt

		OPEN student_level_cursor

		FETCH NEXT FROM student_level_cursor
			INTO @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, @is_graduate_student, @is_international, @is_marked_deleted

		WHILE @@FETCH_STATUS = 0
		BEGIN	

			INSERT INTO @school_fee_details_table (return_table_id, sysid_student, sysid_enrolmentlevel, sysid_feedetails, sysid_feeparticular, 
					is_level_increase, is_added_level_fee, amount, fee_category_id, category_description, particular_description,  is_office_access, category_no, 
					additional_fee_id, optional_fee_id, is_additional_fee, is_optional_fee, is_per_year_tuition_fee, is_per_unit_tuition_fee, 
					is_fixed_amount_tuition_fee, is_special_class_tuition_fee, international_percentage, remarks)
			EXECUTE 
					ums.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, 
										@is_graduate_student, @is_international, 1, @is_marked_deleted, 0, @system_user_id
			
			
			FETCH NEXT FROM student_level_cursor
				INTO @sysid_student, @sysid_enrolmentlevel, @sysid_feelevel, @sysid_semester, @is_graduate_student, @is_international, @is_marked_deleted


		END

		CLOSE student_level_cursor
		DEALLOCATE student_level_cursor

		DECLARE student_list_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
			FOR SELECT ssl_list.var_str
				FROM 			
					ums.IterateListToTable (@sysid_student_list, ',') AS ssl_list

		OPEN student_list_cursor

		FETCH NEXT FROM student_list_cursor
			INTO @sysid_student

		WHILE @@FETCH_STATUS = 0
		BEGIN	

			SELECT @total_tuition = CASE WHEN
											((NOT SUM(sfdt.amount) = 0) AND (NOT SUM(sfdt.amount) IS NULL))
										THEN
											(SUM(sfdt.amount))
										ELSE
											(0)
										END
									FROM
										@school_fee_details_table AS sfdt 
									WHERE
										((sfdt.sysid_feeparticular IS NULL) OR ((NOT sfdt.sysid_feeparticular IS NULL) AND (((sfdt.category_no IN (1)) AND
										(sfdt.is_per_year_tuition_fee = 1 OR sfdt.is_per_unit_tuition_fee = 1 OR
											sfdt.is_fixed_amount_tuition_fee = 1 OR sfdt.is_special_class_tuition_fee = 1)) OR
										(NOT sfdt.category_no IN (1))))) AND
										(sfdt.sysid_student = @sysid_student)

			
			SELECT @total_reimbursements = CASE WHEN
											((NOT SUM(srb.amount) = 0) AND (NOT SUM(srb.amount) IS NULL))
										THEN
											(SUM(srb.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_reimbursements AS srb
									WHERE
										(srb.sysid_student = @sysid_student)

			SELECT @total_credit_memo = CASE WHEN
											((NOT SUM(scm.amount) = 0) AND (NOT SUM(scm.amount) IS NULL))
										THEN
											(SUM(scm.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_credit_memo AS scm
									WHERE
										(scm.sysid_student = @sysid_student)


			SELECT @total_payments = CASE WHEN
											((NOT SUM(stp.amount) = 0) AND (NOT SUM(stp.amount) IS NULL))
										THEN
											((SUM(stp.amount)) + (SUM(stp.discount_amount)))
										ELSE
											(0)
										END
									FROM
										ums.student_payments AS stp 
									WHERE
										(stp.sysid_student = @sysid_student)	--no comparison on @date_ending because student payments must be sum-up

			SELECT @total_discounts = CASE WHEN
											((NOT SUM(std.amount) = 0) AND (NOT SUM(std.amount) IS NULL))
										THEN
											(SUM(std.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_discounts AS std
									INNER JOIN ums.student_scholarship AS sts ON sts.sysid_studentscholarship = std.sysid_studentscholarship
									INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sts.sysid_enrolmentlevel
									INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
									WHERE
										((sts.is_marked_deleted IS NULL) OR ((NOT sts.is_marked_deleted IS NULL) AND (sts.is_marked_deleted = 0))) AND 
										(sec.sysid_student = @sysid_student)

			SELECT @total_student_balance_forwarded = CASE WHEN
											((NOT SUM(sbf.amount) = 0) AND (NOT SUM(sbf.amount) IS NULL))
										THEN
											(SUM(sbf.amount))
										ELSE
											(0)
										END
									FROM
										ums.student_balance_forwarded AS sbf
									WHERE
										(sbf.sysid_student = @sysid_student)


			INSERT INTO @account_receivable_table (sysid_student, amount) VALUES (@sysid_student, 
				((@total_tuition + @total_reimbursements + @total_student_balance_forwarded) - (@total_payments + @total_credit_memo + @total_discounts)))
			
			
			FETCH NEXT FROM student_list_cursor
				INTO @sysid_student

		END

		CLOSE student_list_cursor
		DEALLOCATE student_list_cursor

		SELECT
			table_id,
			sysid_student,
			amount
		FROM
			@account_receivable_table
		ORDER BY
			sysid_student ASC
		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a student load', 'Student Load'		
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySysIDStudentListForStudentRunningBalanceStudentLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsScheduleInformationAlreadyLoadedStudent" function already exist
IF OBJECT_ID (N'ums.IsScheduleInformationAlreadyLoadedStudent') IS NOT NULL
   DROP FUNCTION ums.IsScheduleInformationAlreadyLoadedStudent
GO

CREATE FUNCTION ums.IsScheduleInformationAlreadyLoadedStudent
(	
	@sysid_schedule varchar (50) = '',
	@sysid_student varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	
	SET @result = 0

	IF EXISTS (SELECT 
					sl.load_id AS load_id
				FROM
					ums.student_load AS sl
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
				WHERE
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
					(sl.sysid_schedule = @sysid_schedule) AND
					(sec.sysid_student = @sysid_student)
				UNION
				SELECT 
					sl.load_id AS load_id
				FROM
					ums.student_load AS sl
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = sl.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = sl.sysid_schedule
				INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
				WHERE
					(NOT sri.sysid_semester IS NULL AND NOT sri.sysid_semester = '') AND
					(sl.sysid_schedule = @sysid_schedule) AND
					(sec.sysid_student = @sysid_student)
			  )
			
				
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsClassroomBySysIDScheduleStudentLoad" function already exist
IF OBJECT_ID (N'ums.IsClassroomBySysIDScheduleStudentLoad') IS NOT NULL
   DROP FUNCTION ums.IsClassroomBySysIDScheduleStudentLoad
GO

CREATE FUNCTION ums.IsClassroomBySysIDScheduleStudentLoad
(	
	@sysid_schedule varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result smallint

	SET @result = 0

	IF EXISTS (SELECT 
					scd.sysid_scheddetails AS sysid_scheddetails
				FROM
					ums.schedule_information_details AS scd
				INNER JOIN ums.classroom_information AS ci ON ci.sysid_classroom = scd.sysid_classroom
				INNER JOIN ums.schedule_information AS sci ON sci.sysid_schedule = scd.sysid_schedule
				WHERE
					(sci.sysid_schedule = @sysid_schedule) AND
					(NOT scd.sysid_classroom IS NULL) AND
					(scd.is_classroom = 1) AND
					(scd.is_marked_deleted = 0))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "GetSlotsAvailableBySysIDScheduleStudentLoad" function already exist
IF OBJECT_ID (N'ums.GetSlotsAvailableBySysIDScheduleStudentLoad') IS NOT NULL
   DROP FUNCTION ums.GetSlotsAvailableBySysIDScheduleStudentLoad
GO

CREATE FUNCTION ums.GetSlotsAvailableBySysIDScheduleStudentLoad
(	
	@sysid_schedule varchar (50) = ''
)
RETURNS smallint
AS
BEGIN

	--NOTE: IF THIS PROCEDURE WILL BE CHANGE, CHANGE ALSO THE LOGIC IN GETTING THE SLOTS AVAILABLE FOR THE FOLLOWING STORED PROC:
	--1.) SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad
	--2.) SelectByDateStartEndScheduleInformationDetails
	
	DECLARE @result smallint

	SELECT
		@result = ((MIN(inner_ci.maximum_capacity) + ISNULL(inner_sci.additional_slots, 0)) - ISNULL(inner_sl.student_count, 0))
	FROM
		ums.schedule_information_details AS inner_scd
	INNER JOIN ums.classroom_information AS inner_ci ON inner_ci.sysid_classroom = inner_scd.sysid_classroom
	INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
	LEFT JOIN 
	(
		SELECT	
			t_sl.sysid_schedule AS sysid_schedule,
			COUNT(t_sl.load_id) AS student_count
		FROM
			ums.student_load AS t_sl 
		WHERE 
			(t_sl.sysid_schedule = @sysid_schedule) AND
			(t_sl.is_premature_deloaded = 0)
		GROUP BY
			t_sl.sysid_schedule
			
	) AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
	WHERE
		(inner_sci.sysid_schedule = @sysid_schedule) AND
		(inner_scd.is_marked_deleted = 0)
	GROUP BY
		inner_sci.sysid_schedule, inner_sci.additional_slots, inner_sl.student_count
		
	IF (@result IS NULL)
	BEGIN
		SET @result = -32768
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "GetSubjectAmountBySysIDEnrolmentLevelScheduleStudentLoad" function already exist
IF OBJECT_ID (N'ums.GetSubjectAmountBySysIDEnrolmentLevelScheduleStudentLoad') IS NOT NULL
   DROP FUNCTION ums.GetSubjectAmountBySysIDEnrolmentLevelScheduleStudentLoad
GO

CREATE FUNCTION ums.GetSubjectAmountBySysIDEnrolmentLevelScheduleStudentLoad
(	
	@tuition_amount decimal (12, 2) = 0,
	@sysid_schedule varchar (50) = '',
	@is_semestral bit = 0
)
RETURNS decimal (12, 2)
AS
BEGIN	

	DECLARE @result decimal (12, 2)	

	SET @result = 0

	IF (NOT ISNULL(@sysid_schedule, '') = '')
	BEGIN

		IF (@is_semestral = 1)
		BEGIN
			
			SELECT @result = ((CASE WHEN ((SUM(si.lecture_units) = 0 AND SUM(si.lab_units) = 0) OR		--per unit subjects
										(SUM(si.lecture_units) IS NULL AND SUM(si.lab_units) IS NULL)) 
									THEN  
										(0)
									ELSE
										(SUM(si.lecture_units) + SUM(si.lab_units))
									END) * @tuition_amount)
								FROM
									ums.subject_information AS si
								INNER JOIN ums.schedule_information AS sci ON sci.sysid_subject = si.sysid_subject
								INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
								WHERE
									(sci.sysid_schedule = @sysid_schedule) AND
									(sci.is_fixed_amount = 0) AND
									(cg.is_per_unit = 1)

		END

		IF (@result = 0)
		BEGIN

			SELECT	@result = CASE WHEN ((sci.amount = 0) OR (sci.amount IS NULL))		--fixed amount subjects (per unit or per year)
										THEN											--if the result is still 0, then the schedule is not per unit
											(0)											--and not fixed amount 			
										ELSE
											(sci.amount)
										END
									FROM
										ums.schedule_information AS sci
									WHERE
										(sci.sysid_schedule = @sysid_schedule) AND
										(sci.is_fixed_amount = 1)

		END						

	END
	
	RETURN @result

END
GO
------------------------------------------------------

---- verifies if the "GetSubjectAmountByLoadUnitsStudentLoad" function already exist
--IF OBJECT_ID (N'ums.GetSubjectAmountByLoadUnitsStudentLoad') IS NOT NULL
--   DROP FUNCTION ums.GetSubjectAmountByLoadUnitsStudentLoad
--GO

--CREATE FUNCTION ums.GetSubjectAmountByLoadUnitsStudentLoad
--(	
--	@tuition_amount decimal (12, 2) = 0,
--	@sysid_schedule varchar (50) = '',
--	@load_lecture_units tinyint = 0,
--	@load_lab_units tinyint = 0,
--	@is_fixed_amount bit = 0,
--	@is_semestral bit = 0
--)
--RETURNS decimal (12, 2)
--AS
--BEGIN	

--	DECLARE @result decimal (12, 2)	

--	SET @result = 0

--	IF (NOT ISNULL(@sysid_schedule, '') = '')
--	BEGIN

--		IF ((@is_semestral = 1) AND (@is_fixed_amount = 0))
--		BEGIN
			
--			SET @result = ((CASE WHEN ((SUM(@load_lecture_units) = 0 AND SUM(@load_lab_units) = 0) OR		--per unit subjects
--										(SUM(@load_lecture_units) IS NULL AND SUM(@load_lab_units) IS NULL)) 
--									THEN  
--										(0)
--									ELSE
--										(SUM(@load_lecture_units) + SUM(@load_lab_units))
--									END) * @tuition_amount)

--		END

--		IF (@result = 0)
--		BEGIN

--			SELECT	@result = CASE WHEN ((sci.amount = 0) OR (sci.amount IS NULL))		--fixed amount subjects (per unit or per year)
--										THEN											--if the result is still 0, then the schedule is not per unit
--											(0)											--and not fixed amount 			
--										ELSE
--											(sci.amount)
--										END
--									FROM
--										ums.schedule_information AS sci
--									WHERE
--										(sci.sysid_schedule = @sysid_schedule) AND
--										(sci.is_fixed_amount = 1)

--		END						

--	END
	
--	RETURN @result

--END
--GO
--------------------------------------------------------

-- verifies if the "IsScheduleConflictsWithAnotherStudentLoadedSchedule" function already exist
IF OBJECT_ID (N'ums.IsScheduleConflictsWithAnotherStudentLoadedSchedule') IS NOT NULL
   DROP FUNCTION ums.IsScheduleConflictsWithAnotherStudentLoadedSchedule
GO

CREATE FUNCTION ums.IsScheduleConflictsWithAnotherStudentLoadedSchedule
(	
	@sysid_schedule varchar (50) = '',
	@sysid_enrolmentlevel varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT TOP 1
					ss.schedule_id
				FROM
					ums.subject_schedule AS ss
				INNER JOIN
					(				--GET THE WEEK AND TIME ID OF THE YEARLY/SEMESTRAL BASED ON THE SCHEDULE DETAILS
						SELECT
							details_ss.schedule_id AS schedule_id,
							details_ss.week_id AS week_id,
							details_ss.time_id AS time_id
						FROM
							ums.subject_schedule AS details_ss
						INNER JOIN ums.schedule_information_details AS details_scd ON details_scd.sysid_scheddetails = details_ss.sysid_scheddetails
						INNER JOIN ums.schedule_information AS details_sci ON details_sci.sysid_schedule = details_scd.sysid_schedule
						WHERE
							(details_sci.sysid_schedule = @sysid_schedule) AND
							(details_scd.is_marked_deleted = 0)

					) AS ss_details ON ss_details.schedule_id = ss.schedule_id
				INNER JOIN
					(				--GET THE WEEK AND TIME ID OF THE YEARLY/SEMESTRAL LOADED SCHEDULE DETAILS OF AN INSTRUCTOR 
						SELECT
							inner_ss.week_id AS week_id,
							inner_ss.time_id AS time_id
						FROM
							ums.subject_schedule AS inner_ss
						INNER JOIN ums.schedule_information_details AS inner_scd ON inner_scd.sysid_scheddetails = inner_ss.sysid_scheddetails
						INNER JOIN ums.schedule_information AS inner_sci ON inner_sci.sysid_schedule = inner_scd.sysid_schedule
						INNER JOIN ums.student_load AS inner_sl ON inner_sl.sysid_schedule = inner_sci.sysid_schedule
						INNER JOIN ums.student_enrolment_level AS inner_sel ON inner_sel.sysid_enrolmentlevel = inner_sl.sysid_enrolmentlevel
						WHERE
							(inner_sl.is_premature_deloaded = 0) AND
							(inner_sel.sysid_enrolmentlevel = @sysid_enrolmentlevel)

					) AS ss_week ON ss_week.week_id = ss_details.week_id AND ss_week.time_id = ss_details.time_id)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsPrematureDeloadedStudentLoad" function already exist
IF OBJECT_ID (N'ums.IsPrematureDeloadedStudentLoad') IS NOT NULL
   DROP FUNCTION ums.IsPrematureDeloadedStudentLoad
GO

CREATE FUNCTION ums.IsPrematureDeloadedStudentLoad
(	
	@load_id bigint = 0
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT load_id FROM ums.student_load WHERE load_id = @load_id AND is_premature_deloaded = 1)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------


-- ################################################END TABLE "student_load" OBJECTS######################################################






-- ################################################TABLE "enrolment_course_major" OBJECTS######################################################
-- verifies if the enrolment_course_major table exists
IF OBJECT_ID('ums.enrolment_course_major', 'U') IS NOT NULL
	DROP TABLE ums.enrolment_course_major
GO

CREATE TABLE ums.enrolment_course_major 			
(
	course_major_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Enrolment_Course_Major_Course_Major_ID_PK PRIMARY KEY (course_major_id),
	sysid_enrolmentlevel varchar (50) NOT NULL
		CONSTRAINT Enrolment_Course_Major_SysID_EnrolmentLevel_FK FOREIGN KEY REFERENCES ums.student_enrolment_level(sysid_enrolmentlevel) ON UPDATE NO ACTION
		CONSTRAINT Enrolment_Course_Major_SysID_EnrolmentLevel_UQ UNIQUE (sysid_enrolmentlevel),
	major_information_id varchar (50) NOT NULL
		CONSTRAINT Enrolment_Course_Major_Major_Information_ID_FK FOREIGN KEY REFERENCES ums.course_major_information(major_information_id) ON UPDATE NO ACTION,

	is_current_major bit NOT NULL DEFAULT (0),

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Enrolment_Course_Major_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Enrolment_Course_Major_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Enrolment_Course_Major_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the enrolment_course_major table 
CREATE INDEX Enrolment_Course_Major_Course_Major_ID_Index
	ON ums.enrolment_course_major (course_major_id DESC)
GO
------------------------------------------------------------------

-- verifies if the procedure "InsertEnrolmentCourseMajor" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertEnrolmentCourseMajor')
   DROP PROCEDURE ums.InsertEnrolmentCourseMajor
GO

CREATE PROCEDURE ums.InsertEnrolmentCourseMajor

	@sysid_enrolmentlevel varchar (50) = '',
	@major_information_id varchar (50) = '',
	
	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	DECLARE @is_exists_payment bit
	DECLARE @sysid_student varchar (50)
	DECLARE	@date_start datetime
	DECLARE	@date_end datetime

	SELECT 
		@sysid_student = sysid_student
	FROM 
		ums.student_enrolment_course AS sec
	INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
	WHERE
		(sysid_enrolmentlevel = @sysid_enrolmentlevel)

	SET @date_start = (SELECT TOP 1
							sy.date_start
						FROM
							ums.school_year AS sy
						INNER JOIN ums.school_fee_information AS sfi ON sfi.year_id = sy.year_id
						INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
						INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
						INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
						INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
						WHERE
							(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
							(cg.is_semestral = 0)
						UNION ALL
						SELECT TOP 1
							sri.date_start
						FROM
							ums.semester_information AS sri
						INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_semester = sri.sysid_semester
						WHERE
							(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
							((SELECT
									cg.is_semestral
								FROM
									ums.course_group AS cg
								INNER JOIN ums.year_level_information AS yli ON yli.course_group_id = cg.course_group_id
								INNER JOIN ums.school_fee_level AS sfl ON sfl.year_level_id = yli.year_level_id
								INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
								WHERE
									(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel)) = 1))

	SET @date_end = (SELECT TOP 1
							sy.date_end
						FROM
							ums.school_year AS sy
						INNER JOIN ums.school_fee_information AS sfi ON sfi.year_id = sy.year_id
						INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
						INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
						INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
						INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
						WHERE
							(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
							(cg.is_semestral = 0)
						UNION ALL
						SELECT TOP 1
							sri.date_end
						FROM
							ums.semester_information AS sri
						INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_semester = sri.sysid_semester
						WHERE
							(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
							((SELECT
									cg.is_semestral
								FROM
									ums.course_group AS cg
								INNER JOIN ums.year_level_information AS yli ON yli.course_group_id = cg.course_group_id
								INNER JOIN ums.school_fee_level AS sfl ON sfl.year_level_id = yli.year_level_id
								INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
								WHERE
									(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel)) = 1))
	
	EXECUTE @is_exists_payment = ums.IsExistsPaymentBySysIDStudentDateStartEndStudentPayments @sysid_student, @date_start, @date_end, @created_by


	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR 
		((ums.IsOfficeUserSystemUserInfo(@created_by) = 1) AND 
		(ums.IsUserSameDepartmentCourseInfo((SELECT
													sec.course_id						
												FROM
													ums.student_enrolment_course AS sec
												INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
												WHERE
													sel.sysid_enrolmentlevel = @sysid_enrolmentlevel), @created_by) = 1) AND
		(ums.IsLevelCourseGroupWithEntryLevelEnrolmentLev((SELECT
																sec.sysid_student
															FROM
																ums.student_enrolment_course AS sec
															INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
															WHERE
																sel.sysid_enrolmentlevel = @sysid_enrolmentlevel), 
															(SELECT
																	sel.sysid_feelevel
																FROM
																	ums.student_enrolment_level AS sel
																WHERE
																	sel.sysid_enrolmentlevel = @sysid_enrolmentlevel)) = 1) AND
		(@is_exists_payment = 1))) AND
		((ums.IsRecordLockByYearSemesterID((SELECT 
												sfi.year_id
											FROM
												ums.school_fee_information AS sfi
											INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
											INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
											WHERE
												(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel))) = 0) AND 
		(ums.IsRecordLockByYearSemesterID((SELECT
												sel.sysid_semester
											FROM
												ums.student_enrolment_level AS sel
											WHERE
												(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel))) = 0)) AND
		(ums.IsCurrentCourseStudentEnrolmentCo((SELECT
													sel.sysid_enrolmentcourse
												FROM
													ums.student_enrolment_level AS sel
												WHERE
													(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel))) = 1) AND
		(ums.IsValidCourseMajorEnrolmentCourseMaj(@sysid_enrolmentlevel, @major_information_id) = 1) AND
		(NOT EXISTS (SELECT course_major_id FROM ums.enrolment_course_major WHERE sysid_enrolmentlevel = @sysid_enrolmentlevel))

	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information;

		DECLARE @course_major_id bigint

		DECLARE enrolment_course_major_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
			FOR SELECT ecm.course_major_id
				FROM
					ums.enrolment_course_major AS ecm
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = ecm.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				WHERE
					(sec.sysid_student = (SELECT
												t_sec.sysid_student
											FROM
												ums.student_enrolment_course AS t_sec
											INNER JOIN ums.student_enrolment_level AS t_sel ON t_sel.sysid_enrolmentcourse = t_sec.sysid_enrolmentcourse
											WHERE
												(t_sel.sysid_enrolmentlevel = @sysid_enrolmentlevel)))

		OPEN enrolment_course_major_cursor

		FETCH NEXT FROM enrolment_course_major_cursor
			INTO @course_major_id

		WHILE @@FETCH_STATUS = 0
		BEGIN

			UPDATE mrs.enrolment_course_major SET
				is_current_major = 0,
				edited_by = @created_by
			WHERE
				course_major_id = @course_major_id

			FETCH NEXT FROM enrolment_course_major_cursor
				INTO @course_major_id

		END

		CLOSE enrolment_course_major_cursor
		DEALLOCATE enrolment_course_major_cursor

		INSERT INTO ums.enrolment_course_major
		(
			sysid_enrolmentlevel,
			major_information_id,
			is_current_major,
			
			created_by
		)
		VALUES
		(
			@sysid_enrolmentlevel,
			@major_information_id,
			1,
			
			@created_by
		)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new student enrolment course major', 'Enrolment Course Major'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertEnrolmentCourseMajor TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteEnrolmentCourseMajor" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteEnrolmentCourseMajor')
   DROP PROCEDURE ums.DeleteEnrolmentCourseMajor
GO

CREATE PROCEDURE ums.DeleteEnrolmentCourseMajor

	@course_major_id bigint = 0,

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR
		((((ums.IsOfficeUserSystemUserInfo(@deleted_by) = 1) AND 
			(ums.IsUserSameDepartmentCourseInfo((SELECT
														sec.course_id						
													FROM
														ums.student_enrolment_course AS sec
													INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
													INNER JOIN ums.enrolment_course_major AS ecm ON ecm.sysid_enrolmentlevel = sel.sysid_enrolmentlevel
													WHERE
														(ecm.course_major_id = @course_major_id)), @deleted_by) = 1))) AND
		((ums.IsRecordLockByYearSemesterID((SELECT 
												sfi.year_id
											FROM
												ums.school_fee_information AS sfi
											INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_schoolfee = sfi.sysid_schoolfee
											INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
											INNER JOIN ums.enrolment_course_major AS ecm ON ecm.sysid_enrolmentlevel = sel.sysid_enrolmentlevel
											WHERE
												(ecm.course_major_id = @course_major_id))) = 0) AND 
		(ums.IsRecordLockByYearSemesterID((SELECT 
												sel.sysid_semester
											FROM
												ums.student_enrolment_level AS sel
											INNER JOIN ums.enrolment_course_major AS ecm ON ecm.sysid_enrolmentlevel = sel.sysid_enrolmentlevel
											WHERE
												(ecm.course_major_id = @course_major_id))) = 0)))

	BEGIN
		
		IF EXISTS (SELECT course_major_id FROM ums.enrolment_course_major WHERE course_major_id = @course_major_id)
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.enrolment_course_major SET
				edited_by = @deleted_by
			WHERE
				course_major_id = @course_major_id

			DELETE FROM ums.enrolment_course_major WHERE course_major_id = @course_major_id

		END

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete a student enrolment course major', 'Enrolment Course Major'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteEnrolmentCourseMajor TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor')
   DROP PROCEDURE ums.SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor
GO

CREATE PROCEDURE ums.SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor
	
	@sysid_student varchar (50) = '',
	@course_id varchar (50) = '',
	@sysid_enrolmentlevel varchar (50) = '',

	@system_user_id varchar(50) = ''
	
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsStudentDataControllerSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT			--selected current course major that has been defined in the current selected enrolment level
			ecm.course_major_id AS course_major_id,
			ecm.sysid_enrolmentlevel AS sysid_enrolmentlevel,
			ecm.major_information_id AS major_information_id,
			ecm.is_current_major AS is_current_major,
			cmi.course_major_title AS course_major_title,
			cmi.acronym AS acronym,
			'true' AS is_enrolled
		FROM
			ums.enrolment_course_major AS ecm
		INNER JOIN ums.course_major_information AS cmi ON cmi.major_information_id = ecm.major_information_id
		WHERE
			(cmi.course_id = @course_id) AND
			(ecm.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
			(ecm.is_current_major = 1) AND
			(cmi.is_still_offered = 1)
		UNION ALL
		SELECT			--current course major and the there has no enrolment level selected
			NULL AS course_major_id,
			NULL AS sysid_enrolmentlevel,
			cmi.major_information_id AS major_information_id,
			'true' AS is_current_major,
			cmi.course_major_title AS course_major_title,
			cmi.acronym AS acronym,
			'false' AS is_enrolled
		FROM
			ums.course_major_information AS cmi
		INNER JOIN
			(
				SELECT
					ecm.major_information_id AS major_information_id,
					ecm.sysid_enrolmentlevel AS sysid_enrolmentlevel,
					ecm.is_current_major AS is_current_major
				FROM
					ums.enrolment_course_major AS ecm
				INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentlevel = ecm.sysid_enrolmentlevel
				INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
				WHERE
					(sec.sysid_student = @sysid_student)
			) AS ecm_include ON ecm_include.major_information_id = cmi.major_information_id
		WHERE
			(cmi.course_id = @course_id) AND
			(NOT ecm_include.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
			(ecm_include.is_current_major = 1) AND
			(cmi.is_still_offered = 1)
		UNION ALL
		SELECT			--not selected course majors
			NULL AS course_major_id,
			NULL AS sysid_enrolmentlevel,
			cmi.major_information_id AS major_information_id,
			'false' AS is_current_major,
			cmi.course_major_title AS course_major_title,
			cmi.acronym AS acronym,
			'false' AS is_enrolled
		FROM
			ums.course_major_information AS cmi
		LEFT JOIN
			(
				SELECT
					ecm.course_major_id AS course_major_id,
					ecm.major_information_id AS major_information_id
				FROM
					ums.enrolment_course_major AS ecm
				INNER JOIN ums.course_major_information AS cmi ON cmi.major_information_id = ecm.major_information_id
				WHERE
					(ecm.sysid_enrolmentlevel = @sysid_enrolmentlevel) AND
					(ecm.is_current_major = 1) AND
					(cmi.is_still_offered = 1)
			) AS ecm_excluded ON ecm_excluded.major_information_id = cmi.major_information_id
		WHERE
			(cmi.course_id = @course_id) AND
			(cmi.is_still_offered = 1) AND
			(ecm_excluded.course_major_id IS NULL)
		ORDER BY
			course_major_title ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a student enrolment course major', 'Enrolment Course Major'
	END
	
GO
-------------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsValidCourseMajorEnrolmentCourseMaj" function already exist
IF OBJECT_ID (N'ums.IsValidCourseMajorEnrolmentCourseMaj') IS NOT NULL
   DROP FUNCTION ums.IsValidCourseMajorEnrolmentCourseMaj
GO

CREATE FUNCTION ums.IsValidCourseMajorEnrolmentCourseMaj
(	
	@sysid_enrolmentlevel varchar (50) = '',
	@major_information_id varchar (50) = ''
) 
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT 
					cmi.major_information_id
				FROM
					ums.course_major_information AS cmi
				WHERE
					(cmi.major_information_id = @major_information_id) AND
					(cmi.course_id = (SELECT
											sec.course_id
										FROM
											ums.student_enrolment_course AS sec
										INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_enrolmentcourse = sec.sysid_enrolmentcourse
										WHERE
											(sel.sysid_enrolmentlevel = @sysid_enrolmentlevel))))
	BEGIN
		SET @result = 1
	END	
	
	RETURN @result
END
GO
------------------------------------------------------


-- ##############################################END TABLE "enrolment_course_major" OBJECTS######################################################





-- ################################################TABLE "transcript_details" OBJECTS######################################################
-- verifies if the transcript_details table exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
	DROP TABLE ums.transcript_details
GO

CREATE TABLE ums.transcript_details 			
(
	transcript_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Transcript_Details_Transcript_ID_PK PRIMARY KEY (transcript_id),
	sysid_transcript varchar (50) NOT NULL
		CONSTRAINT Transcript_Details_SysID_Transcript_FK FOREIGN KEY REFERENCES ums.transcript_information(sysid_transcript) ON UPDATE NO ACTION,
	term_session varchar (50) NULL,
	subject_code varchar (50) NULL,
	subject_no varchar (50) NULL,
	descriptive_title varchar (100) NULL,
	credit_units varchar (50) NULL,
	final_grade varchar (50) NULL,
	re_exam varchar (50) NULL,
	no_of_hours varchar (50) NULL,
	sequence_no smallint NOT NULL DEFAULT (0),

	sysid_schedule varchar (50) NULL
		CONSTRAINT Transcript_Details_SysID_Schedule_FK FOREIGN KEY REFERENCES ums.schedule_information(sysid_schedule) ON UPDATE NO ACTION,
	sysid_special varchar (50) NULL
		CONSTRAINT Transcript_Details_SysID_Special_FK FOREIGN KEY REFERENCES ums.special_class_information(sysid_special) ON UPDATE NO ACTION,
	category_id varchar (50) NULL
		CONSTRAINT Transcript_Details_Category_ID_FK FOREIGN KEY REFERENCES ums.subject_category(category_id) ON UPDATE NO ACTION,

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Transcript_Details_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Transcript_Details_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Transcript_Details_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the transcript_details table 
CREATE INDEX Transcript_Details_Transcript_ID_Index
	ON ums.transcript_details (transcript_id DESC)
GO
------------------------------------------------------------------

--verifies that the trigger "Transcript_Details_Trigger_Insert" already exist
IF OBJECT_ID ('ums.Transcript_Details_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Transcript_Details_Trigger_Insert
GO

CREATE TRIGGER ums.Transcript_Details_Trigger_Insert
	ON  ums.transcript_details
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @transcript_id bigint
	DECLARE @sysid_transcript varchar (50)
	DECLARE @term_session varchar (50)
	DECLARE @subject_code varchar (50)
	DECLARE @subject_no varchar (50)
	DECLARE @descriptive_title varchar (100)
	DECLARE @credit_units varchar (50)
	DECLARE @final_grade varchar (50)
	DECLARE @re_exam varchar (50)
	DECLARE @no_of_hours varchar (50)
	DECLARE @sequence_no smallint
	DECLARE @sysid_schedule varchar (50)
	DECLARE @sysid_special varchar (50)
	DECLARE @category_id varchar (50)
	
	DECLARE @created_by varchar (50)
	
	SELECT 
		@transcript_id = i.transcript_id,
		@sysid_transcript = i.sysid_transcript,
		@term_session = i.term_session,
		@subject_code = i.subject_code,
		@subject_no = i.subject_no,
		@descriptive_title = i.descriptive_title,
		@credit_units = i.credit_units,
		@final_grade = i.final_grade,
		@re_exam = i.re_exam,
		@no_of_hours = i.no_of_hours,
		@sequence_no = i.sequence_no,
		@sysid_schedule = i.sysid_schedule,
		@sysid_special = i.sysid_special,
		@category_id = i.category_id,

		@created_by = i.created_by
	FROM INSERTED AS i

	SET @transaction_done = 'CREATED a student transcript details ' + 
							'[Details ID: ' + ISNULL(CONVERT(varchar, @transcript_id), '') +	
							'[Transcript System ID: ' + ISNULL(@sysid_transcript, '') +	
							'][Student ID: ' + ISNULL((SELECT
															student_id
														FROM
															ums.transcript_information
														WHERE
															sysid_transcript = @sysid_transcript), '') +
							'][Name: ' + (SELECT
												last_name + ', ' + first_name + ' ' + ISNULL(middle_name, '')
											FROM
												ums.transcript_information
											WHERE
												sysid_transcript = @sysid_transcript) +
							'][Term/Session: ' + ISNULL(@term_session, '') +
							'][Subject Code: ' + ISNULL(@subject_code, '') + ' ' + ISNULL(@subject_no, '') +
							'][Descriptive Title: ' + ISNULL(@descriptive_title, '') +
							'][Credit Units: ' + ISNULL(@credit_units, '') +
							'][Final Grade: ' + ISNULL(@final_grade, '') +
							'][Re Exam: ' + ISNULL(@re_exam, '') +
							'][No. of Hours: ' + ISNULL(@no_of_hours, '') +
							'][Sequence No.: ' + ISNULL(CONVERT(varchar, @sequence_no), '') +
							'][Schedule Information: ' + ISNULL((SELECT
																		'[' + sci.sysid_schedule + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description + ')'
																	FROM
																		ums.schedule_information AS sci
																	INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																	LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
																	WHERE
																		(NOT sci.year_id IS NULL) AND
																		(sci.sysid_schedule = @sysid_schedule)
																	UNION ALL
																	SELECT
																		'[' + sci.sysid_schedule + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description +
																				' ' + ss.semester_description + ')'
																	FROM
																		ums.schedule_information AS sci
																	INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																	LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
																	LEFT JOIN ums.school_semester AS ss ON ss.semester_id = sri.semester_id
																	LEFT JOIN ums.school_year AS sy ON sy.year_id = sri.year_id
																	WHERE
																		(NOT sci.sysid_semester IS NULL) AND
																		(sci.sysid_schedule = @sysid_schedule)), 
																	ISNULL((SELECT
																				'[' + sci.sysid_special + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description + ')'
																			FROM
																				ums.special_class_information AS sci
																			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																			LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
																			WHERE
																				(NOT sci.year_id IS NULL) AND
																				(sci.sysid_special = @sysid_special)
																			UNION ALL
																			SELECT
																				'[' + sci.sysid_special + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description +
																						' ' + ss.semester_description + ')'
																			FROM
																				ums.special_class_information AS sci
																			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																			LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
																			LEFT JOIN ums.school_semester AS ss ON ss.semester_id = sri.semester_id
																			LEFT JOIN ums.school_year AS sy ON sy.year_id = sri.year_id
																			WHERE
																				(NOT sci.sysid_semester IS NULL) AND
																				(sci.sysid_special = @sysid_special)),'')) +
							'][Subject Category: ' + ISNULL((SELECT
																	'[' + category_id + ']' + category_name
																FROM
																	ums.subject_category
																WHERE
																	category_id = @category_id), '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
-----------------------------------------------------------------

--verifies that the trigger "Transcript_Details_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Transcript_Details_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Transcript_Details_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Transcript_Details_Trigger_Instead_Update
	ON  ums.transcript_details
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @transcript_id bigint
	DECLARE @sysid_transcript varchar (50)
	DECLARE @term_session varchar (50)
	DECLARE @subject_code varchar (50)
	DECLARE @subject_no varchar (50)
	DECLARE @descriptive_title varchar (100)
	DECLARE @credit_units varchar (50)
	DECLARE @final_grade varchar (50)
	DECLARE @re_exam varchar (50)
	DECLARE @no_of_hours varchar (50)
	DECLARE @sequence_no smallint
	DECLARE @sysid_schedule varchar (50)
	DECLARE @sysid_special varchar (50)
	DECLARE @category_id varchar (50)

	DECLARE @edited_by varchar (50)

	DECLARE @term_session_b varchar (50)
	DECLARE @subject_code_b varchar (50)
	DECLARE @subject_no_b varchar (50)
	DECLARE @descriptive_title_b varchar (100)
	DECLARE @credit_units_b varchar (50)
	DECLARE @final_grade_b varchar (50)
	DECLARE @re_exam_b varchar (50)
	DECLARE @no_of_hours_b varchar (50)
	DECLARE @sequence_no_b smallint
	DECLARE @sysid_schedule_b varchar (50)
	DECLARE @sysid_special_b varchar (50)
	DECLARE @category_id_b varchar (50)

	DECLARE @has_update bit

	DECLARE transcript_details_update_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
		FOR SELECT i.transcript_id, i.sysid_transcript, i.term_session, i.subject_code, i.subject_no, i.descriptive_title,
				i.credit_units, i.final_grade, i.re_exam, i.no_of_hours, i.sequence_no, i.sysid_schedule, i.sysid_special, i.category_id, i.edited_by
			FROM 
				INSERTED AS i

	OPEN transcript_details_update_cursor

	FETCH NEXT FROM transcript_details_update_cursor
		INTO @transcript_id, @sysid_transcript, @term_session, @subject_code, @subject_no, @descriptive_title,
				@credit_units, @final_grade, @re_exam, @no_of_hours, @sequence_no, @sysid_schedule, @sysid_special, @category_id, @edited_by

	WHILE @@FETCH_STATUS = 0
	BEGIN

		SELECT 
			@term_session_b = trd.term_session,
			@subject_code_b = trd.subject_code,
			@subject_no_b = trd.subject_no,
			@descriptive_title_b = trd.descriptive_title,
			@credit_units_b = trd.credit_units,
			@final_grade_b = trd.final_grade,
			@re_exam_b = trd.re_exam,
			@no_of_hours_b = trd.no_of_hours,
			@sequence_no_b = trd.sequence_no,
			@sysid_schedule_b = trd.sysid_schedule,
			@sysid_special_b = trd.sysid_special,
			@category_id_b = trd.category_id
		FROM 
			ums.transcript_details AS trd
		WHERE
			trd.transcript_id = @transcript_id

		SET @transaction_done = ''
		SET @has_update = 0

		IF (NOT ISNULL(@term_session COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@term_session_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Term/Session Before: ' + ISNULL(@term_session_b, '') + ']' +
														'[Term/Session After: ' + ISNULL(@term_session, '') + ']'
			SET @has_update = 1
		END

		IF (NOT ISNULL(@subject_code COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@subject_code_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')) OR
			(NOT ISNULL(@subject_no COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@subject_no_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Subject Code Before: ' + ISNULL(@subject_code_b, '') + ' ' + ISNULL(@subject_no_b, '') + ']' +
														'[Subject Code After: ' + ISNULL(@subject_code, '') + ' ' + ISNULL(@subject_no, '') + ']'
			SET @has_update = 1
		END

		IF (NOT ISNULL(@descriptive_title COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@descriptive_title_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Descriptive Title Before: ' + ISNULL(@descriptive_title_b, '') + ']' +
														'[Descriptive Title After: ' + ISNULL(@descriptive_title, '') + ']'
			SET @has_update = 1
		END

		IF (NOT ISNULL(@credit_units COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@credit_units_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Credit Units Before: ' + ISNULL(@credit_units_b, '') + ']' +
														'[Credit Units After: ' + ISNULL(@credit_units, '') + ']'
			SET @has_update = 1
		END

		IF (NOT ISNULL(@final_grade COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@final_grade_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Final Grade Before: ' + ISNULL(@final_grade_b, '') + ']' +
														'[Final Grade After: ' + ISNULL(@final_grade, '') + ']'
			SET @has_update = 1
		END

		IF (NOT ISNULL(@re_exam COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@re_exam_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Re Exam Before: ' + ISNULL(@re_exam_b, '') + ']' +
														'[Re Exam After: ' + ISNULL(@re_exam, '') + ']'
			SET @has_update = 1
		END

		IF (NOT ISNULL(@no_of_hours COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@no_of_hours_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[No. of Hours Before: ' + ISNULL(@no_of_hours_b, '') + ']' +
														'[No. of Hours After: ' + ISNULL(@no_of_hours, '') + ']'
			SET @has_update = 1
		END

		IF (NOT ISNULL(@sysid_schedule COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@sysid_schedule_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')) OR
			(NOT ISNULL(@sysid_special COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@sysid_special_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Schedule Information Before: ' + ISNULL((SELECT
																										'[' + sci.sysid_schedule + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description + ')'
																									FROM
																										ums.schedule_information AS sci
																									INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																									LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
																									WHERE
																										(NOT sci.year_id IS NULL) AND
																										(sci.sysid_schedule = @sysid_schedule_b)
																									UNION ALL
																									SELECT
																										'[' + sci.sysid_schedule + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description +
																												' ' + ss.semester_description + ')'
																									FROM
																										ums.schedule_information AS sci
																									INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																									LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
																									LEFT JOIN ums.school_semester AS ss ON ss.semester_id = sri.semester_id
																									LEFT JOIN ums.school_year AS sy ON sy.year_id = sri.year_id
																									WHERE
																										(NOT sci.sysid_semester IS NULL) AND
																										(sci.sysid_schedule = @sysid_schedule_b)), 
																									ISNULL((SELECT
																												'[' + sci.sysid_special + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description + ')'
																											FROM
																												ums.special_class_information AS sci
																											INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																											LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
																											WHERE
																												(NOT sci.year_id IS NULL) AND
																												(sci.sysid_special = @sysid_special_b)
																											UNION ALL
																											SELECT
																												'[' + sci.sysid_special + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description +
																														' ' + ss.semester_description + ')'
																											FROM
																												ums.special_class_information AS sci
																											INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																											LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
																											LEFT JOIN ums.school_semester AS ss ON ss.semester_id = sri.semester_id
																											LEFT JOIN ums.school_year AS sy ON sy.year_id = sri.year_id
																											WHERE
																												(NOT sci.sysid_semester IS NULL) AND
																												(sci.sysid_special = @sysid_special_b)),'')) + ']' +
														'[Schedule Information After: ' + ISNULL((SELECT
																										'[' + sci.sysid_schedule + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description + ')'
																									FROM
																										ums.schedule_information AS sci
																									INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																									LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
																									WHERE
																										(NOT sci.year_id IS NULL) AND
																										(sci.sysid_schedule = @sysid_schedule)
																									UNION ALL
																									SELECT
																										'[' + sci.sysid_schedule + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description +
																												' ' + ss.semester_description + ')'
																									FROM
																										ums.schedule_information AS sci
																									INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																									LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
																									LEFT JOIN ums.school_semester AS ss ON ss.semester_id = sri.semester_id
																									LEFT JOIN ums.school_year AS sy ON sy.year_id = sri.year_id
																									WHERE
																										(NOT sci.sysid_semester IS NULL) AND
																										(sci.sysid_schedule = @sysid_schedule)), 
																									ISNULL((SELECT
																												'[' + sci.sysid_special + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description + ')'
																											FROM
																												ums.special_class_information AS sci
																											INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																											LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
																											WHERE
																												(NOT sci.year_id IS NULL) AND
																												(sci.sysid_special = @sysid_special)
																											UNION ALL
																											SELECT
																												'[' + sci.sysid_special + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description +
																														' ' + ss.semester_description + ')'
																											FROM
																												ums.special_class_information AS sci
																											INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																											LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
																											LEFT JOIN ums.school_semester AS ss ON ss.semester_id = sri.semester_id
																											LEFT JOIN ums.school_year AS sy ON sy.year_id = sri.year_id
																											WHERE
																												(NOT sci.sysid_semester IS NULL) AND
																												(sci.sysid_special = @sysid_special)),'')) + ']'
			SET @has_update = 1
		END
		ELSE
		BEGIN
			SET @transaction_done = @transaction_done + '[Schedule Information: ' + ISNULL((SELECT
																								'[' + sci.sysid_schedule + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description + ')'
																							FROM
																								ums.schedule_information AS sci
																							INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																							LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
																							WHERE
																								(NOT sci.year_id IS NULL) AND
																								(sci.sysid_schedule = @sysid_schedule)
																							UNION ALL
																							SELECT
																								'[' + sci.sysid_schedule + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description +
																										' ' + ss.semester_description + ')'
																							FROM
																								ums.schedule_information AS sci
																							INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																							LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
																							LEFT JOIN ums.school_semester AS ss ON ss.semester_id = sri.semester_id
																							LEFT JOIN ums.school_year AS sy ON sy.year_id = sri.year_id
																							WHERE
																								(NOT sci.sysid_semester IS NULL) AND
																								(sci.sysid_schedule = @sysid_schedule)), 
																							ISNULL((SELECT
																										'[' + sci.sysid_special + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description + ')'
																									FROM
																										ums.special_class_information AS sci
																									INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																									LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
																									WHERE
																										(NOT sci.year_id IS NULL) AND
																										(sci.sysid_special = @sysid_special)
																									UNION ALL
																									SELECT
																										'[' + sci.sysid_special + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description +
																												' ' + ss.semester_description + ')'
																									FROM
																										ums.special_class_information AS sci
																									INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																									LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
																									LEFT JOIN ums.school_semester AS ss ON ss.semester_id = sri.semester_id
																									LEFT JOIN ums.school_year AS sy ON sy.year_id = sri.year_id
																									WHERE
																										(NOT sci.sysid_semester IS NULL) AND
																										(sci.sysid_special = @sysid_special)),'')) + ']'
		END
		
		IF (NOT ISNULL(@category_id COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@category_id_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Subject Category Before: ' + ISNULL((SELECT
																									'[' + category_id + ']' + category_name
																								FROM
																									ums.subject_category
																								WHERE
																									category_id = @category_id_b), '') + ']' +
														'[Subject Category After: ' + ISNULL((SELECT
																									'[' + category_id + ']' + category_name
																								FROM
																									ums.subject_category
																								WHERE
																									category_id = @category_id), '') + ']'
			SET @has_update = 1
		END

		IF (@has_update = 1)
		BEGIN

			UPDATE ums.transcript_details SET
				term_session = @term_session,
				subject_code = @subject_code,
				subject_no = @subject_no,
				descriptive_title = @descriptive_title,
				credit_units = @credit_units,
				final_grade = @final_grade,
				re_exam = @re_exam,
				no_of_hours = @no_of_hours,
				sequence_no = @sequence_no,
				sysid_schedule = @sysid_schedule,
				sysid_special = @sysid_special,
				category_id = @category_id,

				edited_on = GETDATE(),
				edited_by = @edited_by
			WHERE
				transcript_id = @transcript_id
	
			SET @transaction_done = 'UPDATED a student transcript details ' + 
									'[Details ID: ' + ISNULL(CONVERT(varchar, @transcript_id), '') +	
									'[Transcript System ID: ' + ISNULL(@sysid_transcript, '') +	
									'][Student ID: ' + ISNULL((SELECT
																	student_id
																FROM
																	ums.transcript_information
																WHERE
																	sysid_transcript = @sysid_transcript), '') +
									'][Name: ' + (SELECT
														last_name + ', ' + first_name + ' ' + ISNULL(middle_name, '')
													FROM
														ums.transcript_information
													WHERE
														sysid_transcript = @sysid_transcript) +					
									']' + @transaction_done

			IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
			BEGIN
				SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
			END
					
			EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done			

		END
		ELSE IF (NOT @sequence_no = @sequence_no_b)
		BEGIN

			UPDATE ums.transcript_details SET
				sequence_no = @sequence_no,

				edited_on = GETDATE(),
				edited_by = @edited_by
			WHERE
				transcript_id = @transcript_id
	
		END
		ELSE IF NOT @edited_by IS NULL
		BEGIN

			--used for the delete trigger
			UPDATE ums.transcript_details SET
				edited_on = GETDATE(),
				edited_by = @edited_by
			WHERE
				transcript_id = @transcript_id

		END	
		
		FETCH NEXT FROM transcript_details_update_cursor
			INTO @transcript_id, @sysid_transcript, @term_session, @subject_code, @subject_no, @descriptive_title,
					@credit_units, @final_grade, @re_exam, @no_of_hours, @sequence_no, @sysid_schedule, @sysid_special, @category_id, @edited_by

	END

	CLOSE transcript_details_update_cursor
	DEALLOCATE transcript_details_update_cursor

GO
-----------------------------------------------------------------

--verifies that the trigger "Transcript_Details_Trigger_Delete" already exist
IF OBJECT_ID ('ums.Transcript_Details_Trigger_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Transcript_Details_Trigger_Delete
GO

CREATE TRIGGER ums.Transcript_Details_Trigger_Delete
	ON  ums.transcript_details
	FOR DELETE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @transcript_id bigint
	DECLARE @sysid_transcript varchar (50)
	DECLARE @term_session varchar (50)
	DECLARE @subject_code varchar (50)
	DECLARE @subject_no varchar (50)
	DECLARE @descriptive_title varchar (100)
	DECLARE @credit_units varchar (50)
	DECLARE @final_grade varchar (50)
	DECLARE @re_exam varchar (50)
	DECLARE @no_of_hours varchar (50)
	DECLARE @sequence_no smallint
	DECLARE @sysid_schedule varchar (50)
	DECLARE @sysid_special varchar (50)
	DECLARE @category_id varchar (50)

	DECLARE @deleted_by varchar (50)

	DECLARE transcript_details_delete_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
		FOR SELECT d.transcript_id, d.sysid_transcript, d.term_session, d.subject_code, d.subject_no, d.descriptive_title,
				d.credit_units, d.final_grade, d.re_exam, d.no_of_hours, d.sequence_no, d.sysid_schedule, d.sysid_special, d.category_id, d.edited_by
			FROM 
				DELETED AS d

	OPEN transcript_details_delete_cursor

	FETCH NEXT FROM transcript_details_delete_cursor
		INTO @transcript_id, @sysid_transcript, @term_session, @subject_code, @subject_no, @descriptive_title,
				@credit_units, @final_grade, @re_exam, @no_of_hours, @sequence_no, @sysid_schedule, @sysid_special, @category_id, @deleted_by

	WHILE @@FETCH_STATUS = 0
	BEGIN		

		SET @transaction_done = 'DELETED a student transcript details ' + 
								'[Details ID: ' + ISNULL(CONVERT(varchar, @transcript_id), '') +	
								'[Transcript System ID: ' + ISNULL(@sysid_transcript, '') +	
								'][Student ID: ' + ISNULL((SELECT
																student_id
															FROM
																ums.transcript_information
															WHERE
																sysid_transcript = @sysid_transcript), '') +
								'][Name: ' + (SELECT
													last_name + ', ' + first_name + ' ' + ISNULL(middle_name, '')
												FROM
													ums.transcript_information
												WHERE
													sysid_transcript = @sysid_transcript) +
								'][Term/Session: ' + ISNULL(@term_session, '') +
								'][Subject Code: ' + ISNULL(@subject_code, '') + ' ' + ISNULL(@subject_no, '') +
								'][Descriptive Title: ' + ISNULL(@descriptive_title, '') +
								'][Credit Units: ' + ISNULL(@credit_units, '') +
								'][Final Grade: ' + ISNULL(@final_grade, '') +
								'][Re Exam: ' + ISNULL(@re_exam, '') +
								'][No. of Hours: ' + ISNULL(@no_of_hours, '') +
								'][Sequence No.: ' + ISNULL(CONVERT(varchar, @sequence_no), '') +
								'][Schedule Information: ' + ISNULL((SELECT
																		'[' + sci.sysid_schedule + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description + ')'
																	FROM
																		ums.schedule_information AS sci
																	INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																	LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
																	WHERE
																		(NOT sci.year_id IS NULL) AND
																		(sci.sysid_schedule = @sysid_schedule)
																	UNION ALL
																	SELECT
																		'[' + sci.sysid_schedule + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description +
																				' ' + ss.semester_description + ')'
																	FROM
																		ums.schedule_information AS sci
																	INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																	LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
																	LEFT JOIN ums.school_semester AS ss ON ss.semester_id = sri.semester_id
																	LEFT JOIN ums.school_year AS sy ON sy.year_id = sri.year_id
																	WHERE
																		(NOT sci.sysid_semester IS NULL) AND
																		(sci.sysid_schedule = @sysid_schedule)), 
																	ISNULL((SELECT
																				'[' + sci.sysid_special + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description + ')'
																			FROM
																				ums.special_class_information AS sci
																			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																			LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
																			WHERE
																				(NOT sci.year_id IS NULL) AND
																				(sci.sysid_special = @sysid_special)
																			UNION ALL
																			SELECT
																				'[' + sci.sysid_special + '] ' + si.subject_code + ' - ' + si.descriptive_title + ' (' + sy.year_description +
																						' ' + ss.semester_description + ')'
																			FROM
																				ums.special_class_information AS sci
																			INNER JOIN ums.subject_information AS si ON si.sysid_subject = sci.sysid_subject
																			LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
																			LEFT JOIN ums.school_semester AS ss ON ss.semester_id = sri.semester_id
																			LEFT JOIN ums.school_year AS sy ON sy.year_id = sri.year_id
																			WHERE
																				(NOT sci.sysid_semester IS NULL) AND
																				(sci.sysid_special = @sysid_special)),'')) +
								'][Subject Category: ' + ISNULL((SELECT
																	'[' + category_id + ']' + category_name
																FROM
																	ums.subject_category
																WHERE
																	category_id = @category_id), '') +
								']'

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @deleted_by
		END
				
		EXECUTE ums.InsertTransactionLog @deleted_by, @network_information, @transaction_done	

		FETCH NEXT FROM transcript_details_delete_cursor
			INTO @transcript_id, @sysid_transcript, @term_session, @subject_code, @subject_no, @descriptive_title,
					@credit_units, @final_grade, @re_exam, @no_of_hours, @sequence_no, @sysid_schedule, @sysid_special, @category_id, @deleted_by

	END
	
	CLOSE transcript_details_delete_cursor
	DEALLOCATE transcript_details_delete_cursor

GO
-----------------------------------------------------------------

-- verifies if the procedure "InsertTranscriptDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertTranscriptDetails')
   DROP PROCEDURE ums.InsertTranscriptDetails
GO

CREATE PROCEDURE ums.InsertTranscriptDetails

	@sysid_transcript varchar (50) = '',
	@term_session varchar (50) = '',
	@subject_code varchar (50) = '',
	@subject_no varchar (50) = '',
	@descriptive_title varchar (100) = '',
	@credit_units varchar (50) = '',
	@final_grade varchar (50) = '',
	@re_exam varchar (50) = '',
	@no_of_hours varchar (50) = '',
	@sequence_no smallint = 0,
	@sysid_schedule varchar (50) = '',
	@sysid_special varchar (50) = '',
	@category_id varchar (50) = '',

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@created_by) = 1))
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.transcript_details
		(
			sysid_transcript,
			term_session,
			subject_code,
			subject_no,
			descriptive_title,
			credit_units,
			final_grade,
			re_exam,
			no_of_hours,
			sequence_no,
			sysid_schedule,
			sysid_special,
			category_id,

			created_by
		)
		VALUES
		(
			@sysid_transcript,
			@term_session,
			@subject_code,
			@subject_no,
			@descriptive_title,
			@credit_units,
			@final_grade,
			@re_exam,
			@no_of_hours,
			@sequence_no,
			@sysid_schedule,
			@sysid_special,
			@category_id,

			@created_by
		)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert a transcript details', 'Transcript Details'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertTranscriptDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateTranscriptDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateTranscriptDetails')
   DROP PROCEDURE ums.UpdateTranscriptDetails
GO

CREATE PROCEDURE ums.UpdateTranscriptDetails

	@transcript_id bigint = 0,
	@term_session varchar (50) = '',
	@subject_code varchar (50) = '',
	@subject_no varchar (50) = '',
	@descriptive_title varchar (100) = '',
	@credit_units varchar (50) = '',
	@final_grade varchar (50) = '',
	@re_exam varchar (50) = '',
	@no_of_hours varchar (50) = '',
	@sequence_no smallint = 0,
	@sysid_schedule varchar (50) = '',
	@sysid_special varchar (50) = '',
	@category_id varchar (50) = '',

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@edited_by) = 1))
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.transcript_details SET
			term_session = @term_session,
			subject_code = @subject_code,
			subject_no = @subject_no,
			descriptive_title = @descriptive_title,
			credit_units = @credit_units,
			final_grade = @final_grade,
			re_exam = @re_exam,
			no_of_hours = @no_of_hours,
			sequence_no = @sequence_no,
			sysid_schedule = @sysid_schedule,
			sysid_special = @sysid_special,
			category_id = @category_id,

			edited_by = @edited_by
		WHERE
			transcript_id = @transcript_id
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update a transcript details', 'Transcript Details'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateTranscriptDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteTranscriptDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteTranscriptDetails')
   DROP PROCEDURE ums.DeleteTranscriptDetails
GO

CREATE PROCEDURE ums.DeleteTranscriptDetails

	@transcript_id bigint = 0,

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@deleted_by) = 1))
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

		UPDATE ums.transcript_details SET
			edited_by = @deleted_by
		WHERE
			transcript_id = @transcript_id

		DELETE FROM ums.transcript_details WHERE transcript_id = @transcript_id
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete a transcript details', 'Transcript Details'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteTranscriptDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectBySysIDTranscriptDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDTranscriptDetails')
   DROP PROCEDURE ums.SelectBySysIDTranscriptDetails
GO

CREATE PROCEDURE ums.SelectBySysIDTranscriptDetails
	
	@sysid_transcript varchar (50) = '',

	@system_user_id varchar (50) = ''

AS

	IF ((ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1))
	BEGIN
		
		SELECT
			trd.transcript_id AS transcript_id,
			trd.sysid_transcript AS sysid_transcript,
			trd.term_session AS term_session,
			trd.subject_code AS subject_code,
			trd.subject_no AS subject_no,
			trd.descriptive_title AS descriptive_title,
			trd.credit_units AS credit_units,
			trd.final_grade AS final_grade,
			trd.re_exam AS re_exam,
			trd.no_of_hours AS no_of_hours,
			trd.sequence_no AS sequence_no,
			trd.sysid_schedule AS sysid_schedule,
			trd.sysid_special AS sysid_special,
			
			sc.category_id AS category_id,
			sc.category_name AS category_name,
			sc.acronym AS category_acronym
		FROM
			ums.transcript_details AS trd
		LEFT JOIN ums.subject_category AS sc ON sc.category_id = trd.category_id
		WHERE
			trd.sysid_transcript = @sysid_transcript
		ORDER BY
			trd.sequence_no ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a transcript details', 'Transcript Details'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySysIDTranscriptDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByStudentIDTranscriptDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByStudentIDTranscriptDetails')
   DROP PROCEDURE ums.SelectByStudentIDTranscriptDetails
GO

CREATE PROCEDURE ums.SelectByStudentIDTranscriptDetails
	
	@student_id varchar (50) = '',

	@system_user_id varchar (50) = ''

AS

	IF ((ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsStudentDataControllerSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1))
	BEGIN
		
		SELECT
			trd.transcript_id AS transcript_id,
			trd.sysid_transcript AS sysid_transcript,
			trd.term_session AS term_session,
			trd.subject_code AS subject_code,
			trd.subject_no AS subject_no,
			trd.descriptive_title AS descriptive_title,
			trd.credit_units AS credit_units,
			trd.final_grade AS final_grade,
			trd.re_exam AS re_exam,
			trd.no_of_hours AS no_of_hours,
			trd.sequence_no AS sequence_no,
			trd.sysid_schedule AS sysid_schedule,
			trd.sysid_special AS sysid_special,
			
			sc.category_id AS category_id,
			sc.category_name AS category_name,
			sc.acronym AS category_acronym
		FROM
			ums.transcript_details AS trd
		INNER JOIN ums.transcript_information AS tri ON tri.sysid_transcript = trd.sysid_transcript
		LEFT JOIN ums.subject_category AS sc ON sc.category_id = trd.category_id
		WHERE
			tri.student_id = @student_id
		ORDER BY
			trd.sequence_no ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a transcript details', 'Transcript Details'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByStudentIDTranscriptDetails TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectBySysIDScheduleSpecialListTranscriptDetails" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySysIDScheduleSpecialListTranscriptDetails')
   DROP PROCEDURE ums.SelectBySysIDScheduleSpecialListTranscriptDetails
GO

CREATE PROCEDURE ums.SelectBySysIDScheduleSpecialListTranscriptDetails
	
	@student_id_list nvarchar (MAX) = '',	
	@sysid_semester varchar (50) = '',

	@system_user_id varchar (50) = ''

AS

	IF ((ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsVpOfFinanceSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCashierSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsStudentDataControllerSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsSecretaryVpOfAcademicAffairsSystemUserInfo(@system_user_id) = 1))
	BEGIN
		
		SELECT
			tri.student_id AS student_id,
			
			trd.transcript_id AS transcript_id,
			trd.subject_code AS subject_code,
			trd.subject_no AS subject_no,
			trd.descriptive_title AS descriptive_title,
			trd.credit_units AS credit_units,
			trd.final_grade AS final_grade,
			trd.re_exam AS re_exam,
			trd.sysid_schedule AS sysid_schedule,
			NULL AS sysid_special,
			
			sc.category_id AS category_id,
			sc.category_name AS category_name,
			sc.acronym AS category_acronym
		FROM
			ums.transcript_details AS trd
		INNER JOIN ums.transcript_information AS tri ON tri.sysid_transcript = trd.sysid_transcript
		INNER JOIN ums.IterateListToTable (@student_id_list, ',') AS sil_list ON sil_list.var_str = tri.student_id
		LEFT JOIN ums.schedule_information AS sci ON sci.sysid_schedule = trd.sysid_schedule
		LEFT JOIN ums.subject_category AS sc ON sc.category_id = trd.category_id
		WHERE
			(NOT trd.sysid_schedule IS NULL AND NOT trd.sysid_schedule = '') AND
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND
			(sci.sysid_semester = @sysid_semester)
		UNION ALL
		SELECT
			tri.student_id AS student_id,
			
			trd.transcript_id AS transcript_id,
			trd.subject_code AS subject_code,
			trd.subject_no AS subject_no,
			trd.descriptive_title AS descriptive_title,
			trd.credit_units AS credit_units,
			trd.final_grade AS final_grade,
			trd.re_exam AS re_exam,
			NULL AS sysid_schedule,
			trd.sysid_special AS sysid_special,
			
			sc.category_id AS category_id,
			sc.category_name AS category_name,
			sc.acronym AS category_acronym
		FROM
			ums.transcript_details AS trd
		INNER JOIN ums.transcript_information AS tri ON tri.sysid_transcript = trd.sysid_transcript
		INNER JOIN ums.IterateListToTable (@student_id_list, ',') AS sil_list ON sil_list.var_str = tri.student_id
		LEFT JOIN ums.special_class_information AS spi ON spi.sysid_special = trd.sysid_special
		LEFT JOIN ums.subject_category AS sc ON sc.category_id = trd.category_id
		WHERE
			(NOT trd.sysid_special IS NULL AND NOT trd.sysid_special = '') AND
			(NOT spi.sysid_semester IS NULL AND NOT spi.sysid_semester = '') AND
			(spi.sysid_semester = @sysid_semester)
		ORDER BY
			student_id ASC, subject_code ASC, subject_no ASC		

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a transcript details', 'Transcript Details'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySysIDScheduleSpecialListTranscriptDetails TO db_umsusers
GO
-------------------------------------------------------------

-- ################################################END TABLE "transcript_details" OBJECTS######################################################






-- ######################################RESTORE DEPENDENT TABLE CONSTRAINTS#############################################################
-- ######################################END RESTORE DEPENDENT TABLE CONSTRAINTS#############################################################



-- ############################################INITIAL DATABASE INFORMATION#############################################################

--for week_time table
INSERT INTO ums.week_time(time_description) VALUES ('06:00')
INSERT INTO ums.week_time(time_description) VALUES ('06:00')
INSERT INTO ums.week_time(time_description) VALUES ('06:10')
INSERT INTO ums.week_time(time_description) VALUES ('06:10')
INSERT INTO ums.week_time(time_description) VALUES ('06:20')
INSERT INTO ums.week_time(time_description) VALUES ('06:20')
INSERT INTO ums.week_time(time_description) VALUES ('06:30')
INSERT INTO ums.week_time(time_description) VALUES ('06:30')
INSERT INTO ums.week_time(time_description) VALUES ('06:40')
INSERT INTO ums.week_time(time_description) VALUES ('06:40')
INSERT INTO ums.week_time(time_description) VALUES ('06:50')
INSERT INTO ums.week_time(time_description) VALUES ('06:50')
INSERT INTO ums.week_time(time_description) VALUES ('07:00')
INSERT INTO ums.week_time(time_description) VALUES ('07:00')
INSERT INTO ums.week_time(time_description) VALUES ('07:10')
INSERT INTO ums.week_time(time_description) VALUES ('07:10')
INSERT INTO ums.week_time(time_description) VALUES ('07:20')
INSERT INTO ums.week_time(time_description) VALUES ('07:20')
INSERT INTO ums.week_time(time_description) VALUES ('07:30')
INSERT INTO ums.week_time(time_description) VALUES ('07:30')
INSERT INTO ums.week_time(time_description) VALUES ('07:40')
INSERT INTO ums.week_time(time_description) VALUES ('07:40')
INSERT INTO ums.week_time(time_description) VALUES ('07:50')
INSERT INTO ums.week_time(time_description) VALUES ('07:50')
INSERT INTO ums.week_time(time_description) VALUES ('08:00')
INSERT INTO ums.week_time(time_description) VALUES ('08:00')
INSERT INTO ums.week_time(time_description) VALUES ('08:10')
INSERT INTO ums.week_time(time_description) VALUES ('08:10')
INSERT INTO ums.week_time(time_description) VALUES ('08:20')
INSERT INTO ums.week_time(time_description) VALUES ('08:20')
INSERT INTO ums.week_time(time_description) VALUES ('08:30')
INSERT INTO ums.week_time(time_description) VALUES ('08:30')
INSERT INTO ums.week_time(time_description) VALUES ('08:40')
INSERT INTO ums.week_time(time_description) VALUES ('08:40')
INSERT INTO ums.week_time(time_description) VALUES ('08:50')
INSERT INTO ums.week_time(time_description) VALUES ('08:50')
INSERT INTO ums.week_time(time_description) VALUES ('09:00')
INSERT INTO ums.week_time(time_description) VALUES ('09:00')
INSERT INTO ums.week_time(time_description) VALUES ('09:10')
INSERT INTO ums.week_time(time_description) VALUES ('09:10')
INSERT INTO ums.week_time(time_description) VALUES ('09:20')
INSERT INTO ums.week_time(time_description) VALUES ('09:20')
INSERT INTO ums.week_time(time_description) VALUES ('09:30')
INSERT INTO ums.week_time(time_description) VALUES ('09:30')
INSERT INTO ums.week_time(time_description) VALUES ('09:40')
INSERT INTO ums.week_time(time_description) VALUES ('09:40')
INSERT INTO ums.week_time(time_description) VALUES ('09:50')
INSERT INTO ums.week_time(time_description) VALUES ('09:50')
INSERT INTO ums.week_time(time_description) VALUES ('10:00')
INSERT INTO ums.week_time(time_description) VALUES ('10:00')
INSERT INTO ums.week_time(time_description) VALUES ('10:10')
INSERT INTO ums.week_time(time_description) VALUES ('10:10')
INSERT INTO ums.week_time(time_description) VALUES ('10:20')
INSERT INTO ums.week_time(time_description) VALUES ('10:20')
INSERT INTO ums.week_time(time_description) VALUES ('10:30')
INSERT INTO ums.week_time(time_description) VALUES ('10:30')
INSERT INTO ums.week_time(time_description) VALUES ('10:40')
INSERT INTO ums.week_time(time_description) VALUES ('10:40')
INSERT INTO ums.week_time(time_description) VALUES ('10:50')
INSERT INTO ums.week_time(time_description) VALUES ('10:50')
INSERT INTO ums.week_time(time_description) VALUES ('11:00')
INSERT INTO ums.week_time(time_description) VALUES ('11:00')
INSERT INTO ums.week_time(time_description) VALUES ('11:10')
INSERT INTO ums.week_time(time_description) VALUES ('11:10')
INSERT INTO ums.week_time(time_description) VALUES ('11:20')
INSERT INTO ums.week_time(time_description) VALUES ('11:20')
INSERT INTO ums.week_time(time_description) VALUES ('11:30')
INSERT INTO ums.week_time(time_description) VALUES ('11:30')
INSERT INTO ums.week_time(time_description) VALUES ('11:40')
INSERT INTO ums.week_time(time_description) VALUES ('11:40')
INSERT INTO ums.week_time(time_description) VALUES ('11:50')
INSERT INTO ums.week_time(time_description) VALUES ('11:50')
INSERT INTO ums.week_time(time_description) VALUES ('12:00')
INSERT INTO ums.week_time(time_description) VALUES ('12:00')
INSERT INTO ums.week_time(time_description) VALUES ('12:10')
INSERT INTO ums.week_time(time_description) VALUES ('12:10')
INSERT INTO ums.week_time(time_description) VALUES ('12:20')
INSERT INTO ums.week_time(time_description) VALUES ('12:20')
INSERT INTO ums.week_time(time_description) VALUES ('12:30')
INSERT INTO ums.week_time(time_description) VALUES ('12:30')
INSERT INTO ums.week_time(time_description) VALUES ('12:40')
INSERT INTO ums.week_time(time_description) VALUES ('12:40')
INSERT INTO ums.week_time(time_description) VALUES ('12:50')
INSERT INTO ums.week_time(time_description) VALUES ('12:50')
INSERT INTO ums.week_time(time_description) VALUES ('13:00')
INSERT INTO ums.week_time(time_description) VALUES ('13:00')
INSERT INTO ums.week_time(time_description) VALUES ('13:10')
INSERT INTO ums.week_time(time_description) VALUES ('13:10')
INSERT INTO ums.week_time(time_description) VALUES ('13:20')
INSERT INTO ums.week_time(time_description) VALUES ('13:20')
INSERT INTO ums.week_time(time_description) VALUES ('13:30')
INSERT INTO ums.week_time(time_description) VALUES ('13:30')
INSERT INTO ums.week_time(time_description) VALUES ('13:40')
INSERT INTO ums.week_time(time_description) VALUES ('13:40')
INSERT INTO ums.week_time(time_description) VALUES ('13:50')
INSERT INTO ums.week_time(time_description) VALUES ('13:50')
INSERT INTO ums.week_time(time_description) VALUES ('14:00')
INSERT INTO ums.week_time(time_description) VALUES ('14:00')
INSERT INTO ums.week_time(time_description) VALUES ('14:10')
INSERT INTO ums.week_time(time_description) VALUES ('14:10')
INSERT INTO ums.week_time(time_description) VALUES ('14:20')
INSERT INTO ums.week_time(time_description) VALUES ('14:20')
INSERT INTO ums.week_time(time_description) VALUES ('14:30')
INSERT INTO ums.week_time(time_description) VALUES ('14:30')
INSERT INTO ums.week_time(time_description) VALUES ('14:40')
INSERT INTO ums.week_time(time_description) VALUES ('14:40')
INSERT INTO ums.week_time(time_description) VALUES ('14:50')
INSERT INTO ums.week_time(time_description) VALUES ('14:50')
INSERT INTO ums.week_time(time_description) VALUES ('15:00')
INSERT INTO ums.week_time(time_description) VALUES ('15:00')
INSERT INTO ums.week_time(time_description) VALUES ('15:10')
INSERT INTO ums.week_time(time_description) VALUES ('15:10')
INSERT INTO ums.week_time(time_description) VALUES ('15:20')
INSERT INTO ums.week_time(time_description) VALUES ('15:20')
INSERT INTO ums.week_time(time_description) VALUES ('15:30')
INSERT INTO ums.week_time(time_description) VALUES ('15:30')
INSERT INTO ums.week_time(time_description) VALUES ('15:40')
INSERT INTO ums.week_time(time_description) VALUES ('15:40')
INSERT INTO ums.week_time(time_description) VALUES ('15:50')
INSERT INTO ums.week_time(time_description) VALUES ('15:50')
INSERT INTO ums.week_time(time_description) VALUES ('16:00')
INSERT INTO ums.week_time(time_description) VALUES ('16:00')
INSERT INTO ums.week_time(time_description) VALUES ('16:10')
INSERT INTO ums.week_time(time_description) VALUES ('16:10')
INSERT INTO ums.week_time(time_description) VALUES ('16:20')
INSERT INTO ums.week_time(time_description) VALUES ('16:20')
INSERT INTO ums.week_time(time_description) VALUES ('16:30')
INSERT INTO ums.week_time(time_description) VALUES ('16:30')
INSERT INTO ums.week_time(time_description) VALUES ('16:40')
INSERT INTO ums.week_time(time_description) VALUES ('16:40')
INSERT INTO ums.week_time(time_description) VALUES ('16:50')
INSERT INTO ums.week_time(time_description) VALUES ('16:50')
INSERT INTO ums.week_time(time_description) VALUES ('17:00')
INSERT INTO ums.week_time(time_description) VALUES ('17:00')
INSERT INTO ums.week_time(time_description) VALUES ('17:10')
INSERT INTO ums.week_time(time_description) VALUES ('17:10')
INSERT INTO ums.week_time(time_description) VALUES ('17:20')
INSERT INTO ums.week_time(time_description) VALUES ('17:20')
INSERT INTO ums.week_time(time_description) VALUES ('17:30')
INSERT INTO ums.week_time(time_description) VALUES ('17:30')
INSERT INTO ums.week_time(time_description) VALUES ('17:40')
INSERT INTO ums.week_time(time_description) VALUES ('17:40')
INSERT INTO ums.week_time(time_description) VALUES ('17:50')
INSERT INTO ums.week_time(time_description) VALUES ('17:50')
INSERT INTO ums.week_time(time_description) VALUES ('18:00')
INSERT INTO ums.week_time(time_description) VALUES ('18:00')
INSERT INTO ums.week_time(time_description) VALUES ('18:10')
INSERT INTO ums.week_time(time_description) VALUES ('18:10')
INSERT INTO ums.week_time(time_description) VALUES ('18:20')
INSERT INTO ums.week_time(time_description) VALUES ('18:20')
INSERT INTO ums.week_time(time_description) VALUES ('18:30')
INSERT INTO ums.week_time(time_description) VALUES ('18:30')
INSERT INTO ums.week_time(time_description) VALUES ('18:40')
INSERT INTO ums.week_time(time_description) VALUES ('18:40')
INSERT INTO ums.week_time(time_description) VALUES ('18:50')
INSERT INTO ums.week_time(time_description) VALUES ('18:50')
INSERT INTO ums.week_time(time_description) VALUES ('19:00')
INSERT INTO ums.week_time(time_description) VALUES ('19:00')
INSERT INTO ums.week_time(time_description) VALUES ('19:10')
INSERT INTO ums.week_time(time_description) VALUES ('19:10')
INSERT INTO ums.week_time(time_description) VALUES ('19:20')
INSERT INTO ums.week_time(time_description) VALUES ('19:20')
INSERT INTO ums.week_time(time_description) VALUES ('19:30')
INSERT INTO ums.week_time(time_description) VALUES ('19:30')
INSERT INTO ums.week_time(time_description) VALUES ('19:40')
INSERT INTO ums.week_time(time_description) VALUES ('19:40')
INSERT INTO ums.week_time(time_description) VALUES ('19:50')
INSERT INTO ums.week_time(time_description) VALUES ('19:50')
INSERT INTO ums.week_time(time_description) VALUES ('20:00')
INSERT INTO ums.week_time(time_description) VALUES ('20:00')
INSERT INTO ums.week_time(time_description) VALUES ('20:10')
INSERT INTO ums.week_time(time_description) VALUES ('20:10')
INSERT INTO ums.week_time(time_description) VALUES ('20:20')
INSERT INTO ums.week_time(time_description) VALUES ('20:20')
INSERT INTO ums.week_time(time_description) VALUES ('20:30')
INSERT INTO ums.week_time(time_description) VALUES ('20:30')
INSERT INTO ums.week_time(time_description) VALUES ('20:40')
INSERT INTO ums.week_time(time_description) VALUES ('20:40')
INSERT INTO ums.week_time(time_description) VALUES ('20:50')
INSERT INTO ums.week_time(time_description) VALUES ('20:50')
INSERT INTO ums.week_time(time_description) VALUES ('21:00')
INSERT INTO ums.week_time(time_description) VALUES ('21:00')
INSERT INTO ums.week_time(time_description) VALUES ('21:10')
INSERT INTO ums.week_time(time_description) VALUES ('21:10')
INSERT INTO ums.week_time(time_description) VALUES ('21:20')
INSERT INTO ums.week_time(time_description) VALUES ('21:20')
INSERT INTO ums.week_time(time_description) VALUES ('21:30')
INSERT INTO ums.week_time(time_description) VALUES ('21:30')
INSERT INTO ums.week_time(time_description) VALUES ('21:40')
INSERT INTO ums.week_time(time_description) VALUES ('21:40')
INSERT INTO ums.week_time(time_description) VALUES ('21:50')
INSERT INTO ums.week_time(time_description) VALUES ('21:50')
INSERT INTO ums.week_time(time_description) VALUES ('22:00')
INSERT INTO ums.week_time(time_description) VALUES ('22:00')
GO
-- ##########################################END INITIAL DATABASE INFORMATION#############################################################




-- ########################################FOR CODE DEBUGGING########################################################################
-- ########################################END FOR CODE DEBUGGING########################################################################


