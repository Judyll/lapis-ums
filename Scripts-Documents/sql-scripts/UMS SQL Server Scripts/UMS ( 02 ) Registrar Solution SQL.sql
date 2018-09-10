--******************************************************--
-- This SQL Statements is used for the St. Paul			--
-- 		University UMS									--
--Programmed by: Judyll Mark T. Agan					--
--Date created: April 01, 2007							--
--REGISTRAR SOLUTIONS [ 2 ]								--
--******************************************************--

USE db_umsdev_03_30_2007
GO

-- ###########################################TABLE CONSTRAINTS OBJECTS##############################################################

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

--verifies if the Semester_Information_Year_ID_FK constraint exists
IF OBJECT_ID('ums.semester_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.semester_information
	DROP CONSTRAINT Semester_Information_Year_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Semester_Information_Semester_ID_FK constraint exists
IF OBJECT_ID('ums.semester_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.semester_information
	DROP CONSTRAINT Semester_Information_Semester_ID_FK
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

--verifies if the Subject_Information_Course_Group_ID_FK constraint exists
IF OBJECT_ID('ums.subject_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_information
	DROP CONSTRAINT Subject_Information_Course_Group_ID_FK
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

--verifies if the Subject_Information_Category_ID_FK constraint exists
IF OBJECT_ID('ums.subject_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_information
	DROP CONSTRAINT Subject_Information_Category_ID_FK
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

--verifies if the Subject_Prerequisite_SysID_Subject_FK constraint exists
IF OBJECT_ID('ums.subject_prerequisite', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_prerequisite
	DROP CONSTRAINT Subject_Prerequisite_SysID_Subject_FK
END
GO
-----------------------------------------------------

--verifies if the Subject_Prerequisite_Prerequisite_Subject_FK constraint exists
IF OBJECT_ID('ums.subject_prerequisite', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.subject_prerequisite
	DROP CONSTRAINT Subject_Prerequisite_Prerequisite_Subject_FK
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

--verifies if the Year_Level_Information_Course_Group_ID_FK constraint exists
IF OBJECT_ID('ums.year_level_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.year_level_information
	DROP CONSTRAINT Year_Level_Information_Course_Group_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Course_Information_Course_Group_ID_FK constraint exists
IF OBJECT_ID('ums.course_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_information
	DROP CONSTRAINT Course_Information_Course_Group_ID_FK
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

--verifies if the Course_Major_Information_Course_ID_FK constraint exists
IF OBJECT_ID('ums.course_major_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_major_information
	DROP CONSTRAINT Course_Major_Information_Course_ID_FK
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

--verifies if the Course_Year_Level_Course_ID_FK constraint exists
IF OBJECT_ID('ums.course_year_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_year_level
	DROP CONSTRAINT Course_Year_Level_Course_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Course_Year_Level_Year_Level_ID_FK constraint exists
IF OBJECT_ID('ums.course_year_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.course_year_level
	DROP CONSTRAINT Course_Year_Level_Year_Level_ID_FK
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

--verifies if the Special_Class_Information_SysID_Subject_FK constraint exists
IF OBJECT_ID('ums.special_class_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_information
	DROP CONSTRAINT Special_Class_Information_SysID_Subject_FK
END
GO
-----------------------------------------------------

--verifies if the Special_Class_Information_SysID_Employee_FK constraint exists
IF OBJECT_ID('ums.special_class_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_information
	DROP CONSTRAINT Special_Class_Information_SysID_Employee_FK
END
GO
-----------------------------------------------------

--verifies if the Special_Class_Information_Year_ID_FK constraint exists
IF OBJECT_ID('ums.special_class_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_information
	DROP CONSTRAINT Special_Class_Information_Year_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Special_Class_Information_SysID_Semester_FK constraint exists
IF OBJECT_ID('ums.special_class_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_information
	DROP CONSTRAINT Special_Class_Information_SysID_Semester_FK
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

--verifies if the Special_Class_Load_SysID_Special_FK constraint exists
IF OBJECT_ID('ums.special_class_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_load
	DROP CONSTRAINT Special_Class_Load_SysID_Special_FK
END
GO
-----------------------------------------------------

--verifies if the Special_Class_Load_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.special_class_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_load
	DROP CONSTRAINT Special_Class_Load_SysID_Student_FK
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

--verifies if the Major_Exam_Information_Course_Group_ID_FK constraint exists
IF OBJECT_ID('ums.major_exam_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.major_exam_information
	DROP CONSTRAINT Major_Exam_Information_Course_Group_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Major_Exam_Schedule_Year_ID_FK constraint exists
IF OBJECT_ID('ums.major_exam_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.major_exam_schedule
	DROP CONSTRAINT Major_Exam_Schedule_Year_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Major_Exam_Schedule_SysID_Semester_FK constraint exists
IF OBJECT_ID('ums.major_exam_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.major_exam_schedule
	DROP CONSTRAINT Major_Exam_Schedule_SysID_Semester_FK
END
GO
-----------------------------------------------------

--verifies if the Major_Exam_Schedule_Exam_Information_ID_FK constraint exists
IF OBJECT_ID('ums.major_exam_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.major_exam_schedule
	DROP CONSTRAINT Major_Exam_Schedule_Exam_Information_ID_FK
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

--verifies if the Transcript_Image_SysID_Transcript_FK constraint exists
IF OBJECT_ID('ums.transcript_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_image
	DROP CONSTRAINT Transcript_Image_SysID_Transcript_FK
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


-- ###########################################END TABLE CONSTRAINTS OBJECTS##############################################################



-- ########################################DROP DEPENDENT TABLE CONSTRAINTS ##############################################################

--verifies if the Schedule_Information_SysID_Subject_FK constraint exists
IF OBJECT_ID('ums.schedule_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information
	DROP CONSTRAINT Schedule_Information_SysID_Subject_FK
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

--verifies if the Auxiliary_Service_Information_Course_Group_ID_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_information
	DROP CONSTRAINT Auxiliary_Service_Information_Course_Group_ID_FK
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

--verifies if the School_Fee_Information_Year_ID_FK constraint exists
IF OBJECT_ID('ums.school_fee_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_information
	DROP CONSTRAINT School_Fee_Information_Year_ID_FK
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Level_Year_Level_ID_FK constraint exists
IF OBJECT_ID('ums.school_fee_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_level
	DROP CONSTRAINT School_Fee_Level_Year_Level_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Course_Course_ID_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_course', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_course
	DROP CONSTRAINT Student_Enrolment_Course_Course_ID_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Course_SysID_Semester_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_course', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_course
	DROP CONSTRAINT Student_Enrolment_Course_SysID_Semester_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Level_SysID_Semester_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_level
	DROP CONSTRAINT Student_Enrolment_Level_SysID_Semester_FK
END
GO
-----------------------------------------------------

--verifies if the Scholarship_Information_Course_Group_ID_FK constraint exists
IF OBJECT_ID('ums.scholarship_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.scholarship_information
	DROP CONSTRAINT Scholarship_Information_Course_Group_ID_FK
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

--verifies if the Transcript_Details_SysID_Transcript_FK constraint exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_details
	DROP CONSTRAINT Transcript_Details_SysID_Transcript_FK
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

-- ########################################END DROP DEPENDENT TABLE CONSTRAINTS ##############################################################




-- #########################################################GENERAL PROCEDURES AND FUNCTIONS##################################################


-- verifies if the "GetPayrollLoadEffectivityDate" function already exist
IF OBJECT_ID (N'ums.GetPayrollLoadEffectivityDate') IS NOT NULL
   DROP FUNCTION ums.GetPayrollLoadEffectivityDate
GO

CREATE FUNCTION ums.GetPayrollLoadEffectivityDate
(
	@year_semester_id varchar (50) = ''
)
RETURNS datetime
AS
BEGIN

	DECLARE @date_start datetime
	DECLARE @load_date datetime
	
	IF EXISTS (SELECT year_id FROM ums.school_year WHERE year_id = @year_semester_id)
	BEGIN
		SELECT @date_start = date_start FROM ums.school_year WHERE year_id = @year_semester_id
	END
	ELSE IF EXISTS (SELECT sysid_semester FROM ums.semester_information WHERE sysid_semester = @year_semester_id)
	BEGIN
		SELECT @date_start = date_start FROM ums.semester_information WHERE sysid_semester = @year_semester_id
	END
	
	SET @load_date = CONVERT(datetime, CONVERT(varchar, GETDATE(), 101) + ' 12:00:00 AM')

	IF @load_date < @date_start
	BEGIN
		SET @load_date = @date_start
	END
	
	RETURN ums.GetPayrollEffectivityDate(@load_date)

END
GO
------------------------------------------------------

-- verifies if the "GetEnrolmentLoadEffectivityDate" function already exist
IF OBJECT_ID (N'ums.GetEnrolmentLoadEffectivityDate') IS NOT NULL
   DROP FUNCTION ums.GetEnrolmentLoadEffectivityDate
GO

CREATE FUNCTION ums.GetEnrolmentLoadEffectivityDate
(
	@year_semester_id varchar (50) = ''
)
RETURNS datetime
AS
BEGIN

	DECLARE @date_start datetime
	DECLARE @load_date datetime
	
	IF EXISTS (SELECT year_id FROM ums.school_year WHERE year_id = @year_semester_id)
	BEGIN
		SELECT @date_start = date_start FROM ums.school_year WHERE year_id = @year_semester_id
	END
	ELSE IF EXISTS (SELECT sysid_semester FROM ums.semester_information WHERE sysid_semester = @year_semester_id)
	BEGIN
		SELECT @date_start = date_start FROM ums.semester_information WHERE sysid_semester = @year_semester_id
	END
	
	SET @load_date = CONVERT(datetime, CONVERT(varchar, GETDATE(), 101) + ' 12:00:00 AM')

	IF @load_date < @date_start
	BEGIN
		SET @load_date = @date_start
	END
	
	RETURN ums.GetEnrolmentEffectivityDate(@load_date)

END
GO
------------------------------------------------------

-- verifies if the "GetDeLoadEffectivityDate" function already exist
IF OBJECT_ID (N'ums.GetDeLoadEffectivityDate') IS NOT NULL
   DROP FUNCTION ums.GetDeLoadEffectivityDate
GO

CREATE FUNCTION ums.GetDeLoadEffectivityDate
(
	@year_semester_id varchar (50) = ''
)
RETURNS datetime
AS
BEGIN

	DECLARE @deload_date datetime
	
	IF EXISTS (SELECT year_id FROM ums.school_year WHERE year_id = @year_semester_id)
	BEGIN
		SELECT @deload_date = date_end FROM ums.school_year WHERE year_id = @year_semester_id
	END
	ELSE IF EXISTS (SELECT sysid_semester FROM ums.semester_information WHERE sysid_semester = @year_semester_id)
	BEGIN
		SELECT @deload_date = date_end FROM ums.semester_information WHERE sysid_semester = @year_semester_id
	END	
	
	RETURN @deload_date

END
GO
------------------------------------------------------

-- verifies if the "GetPayrollPreTerminatedLoadDate" function already exist
IF OBJECT_ID (N'ums.GetPayrollPreTerminatedLoadDate') IS NOT NULL
   DROP FUNCTION ums.GetPayrollPreTerminatedLoadDate
GO

CREATE FUNCTION ums.GetPayrollPreTerminatedLoadDate
(	
)
RETURNS datetime
AS
BEGIN

	DECLARE @deload_date datetime
	DECLARE @payroll_cutoff_day tinyint
	DECLARE @total_days tinyint

	SELECT @payroll_cutoff_day = payroll_cutoff_day FROM ums.payroll_standard WHERE effectivity_date = (SELECT MAX(effectivity_date) FROM ums.payroll_standard)

	IF DAY(GETDATE()) > @payroll_cutoff_day
	BEGIN
	
		SET @deload_date = GETDATE()

	END
	ELSE
	BEGIN

		SET @deload_date = DATEADD(mm, -1, GETDATE())

	END
	
	--get the number of days in the given month
	SET @total_days = DATEPART(dd, DATEADD(dd, -1, DATEADD(mm, 1, CONVERT(datetime, CONVERT(varchar, YEAR(@deload_date)) + '-' + 
						CONVERT(varchar, MONTH(@deload_date)) + '-01'))))
	
	RETURN CONVERT(datetime, (CONVERT(varchar, MONTH(@deload_date)) + '/' + CONVERT(varchar, @total_days) + '/' + 
				CONVERT(varchar, YEAR(@deload_date))) + ' 11:59:59 PM', 101)

END
GO
------------------------------------------------------

-- verifies if the "GetEnrolmentPreTerminatedLoadDate" function already exist
IF OBJECT_ID (N'ums.GetEnrolmentPreTerminatedLoadDate') IS NOT NULL
   DROP FUNCTION ums.GetEnrolmentPreTerminatedLoadDate
GO

CREATE FUNCTION ums.GetEnrolmentPreTerminatedLoadDate
(	
)
RETURNS datetime
AS
BEGIN

	DECLARE @deload_date datetime
	DECLARE @enrolment_cutoff_day tinyint
	DECLARE @total_days tinyint

	SELECT @enrolment_cutoff_day = enrolment_cutoff_day FROM ums.finance_standard WHERE effectivity_date = (SELECT MAX(effectivity_date) FROM ums.finance_standard)

	IF DAY(GETDATE()) > @enrolment_cutoff_day
	BEGIN
	
		SET @deload_date = GETDATE()

	END
	ELSE
	BEGIN

		SET @deload_date = DATEADD(mm, -1, GETDATE())

	END
	
	--get the number of days in the given month
	SET @total_days = DATEPART(dd, DATEADD(dd, -1, DATEADD(mm, 1, CONVERT(datetime, CONVERT(varchar, YEAR(@deload_date)) + '-' + 
						CONVERT(varchar, MONTH(@deload_date)) + '-01'))))
	
	RETURN CONVERT(datetime, (CONVERT(varchar, MONTH(@deload_date)) + '/' + CONVERT(varchar, @total_days) + '/' + 
				CONVERT(varchar, YEAR(@deload_date))) + ' 11:59:59 PM', 101)

END
GO
------------------------------------------------------


-- ######################################################END GENERAL PROCEDURES AND FUNCTIONS###################################################




-- ################################################TABLE "school_semester" OBJECTS######################################################
-- verifies if the school_semester table exists
IF OBJECT_ID('ums.school_semester', 'U') IS NOT NULL
	DROP TABLE ums.school_semester
GO

CREATE TABLE ums.school_semester 			
(
	semester_id tinyint NOT NULL 
		CONSTRAINT School_Semester_Semester_ID_PK PRIMARY KEY (semester_id),		
	semester_description varchar (100) NOT NULL
		CONSTRAINT School_Semester_Semester_Description_UQ UNIQUE (semester_description),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT School_Semester_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- verifies that the trigger "School_Semester_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.School_Semester_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.School_Semester_Trigger_Instead_Update
GO

CREATE TRIGGER ums.School_Semester_Trigger_Instead_Update
	ON  ums.school_semester
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a school semester', 'School Semester'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "School_Semester_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.School_Semester_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.School_Semester_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.School_Semester_Trigger_Instead_Delete
	ON  ums.school_semester
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a school semester', 'School Semester'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectSchoolSemester" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectSchoolSemester')
   DROP PROCEDURE ums.SelectSchoolSemester
GO

CREATE PROCEDURE ums.SelectSchoolSemester
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT 
			ss.semester_id AS semester_id,
			ss.semester_description AS semester_description
		FROM
			ums.school_semester AS ss
		ORDER BY ss.semester_id ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query School Semester', 'School Semester'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectSchoolSemester TO db_umsusers
GO
-------------------------------------------------------------

-- ################################################END TABLE "school_semester" OBJECTS###################################################




-- ################################################TABLE "school_year" OBJECTS######################################################
-- verifies if the school_year table exists
IF OBJECT_ID('ums.school_year', 'U') IS NOT NULL
	DROP TABLE ums.school_year
GO

CREATE TABLE ums.school_year 			
(
	year_id varchar (50) NOT NULL 
		CONSTRAINT School_Year_Year_ID_PK PRIMARY KEY (year_id)
		CONSTRAINT School_Year_Year_ID_CK CHECK (year_id LIKE 'SY%'),		
	year_description varchar (100) NOT NULL
		CONSTRAINT School_Year_Year_Description_UQ UNIQUE (year_description),
	date_start datetime NOT NULL
		CONSTRAINT School_Year_Date_Start_UQ UNIQUE (date_start)
		CONSTRAINT School_Year_Date_Start_CK CHECK (CONVERT(varchar, date_start, 109) LIKE '%12:00:00:000AM'), 
	date_end datetime NOT NULL
		CONSTRAINT School_Year_Date_End_UQ UNIQUE (date_end)
		CONSTRAINT School_Year_Date_End_CK CHECK (CONVERT(varchar, date_end, 109) LIKE '%11:59:59:000PM'),

	is_summer bit NOT NULL DEFAULT (1),

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT School_Year_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT School_Year_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT School_Year_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the school_year table 
CREATE INDEX School_Year_Year_ID_Index
	ON ums.school_year (year_id DESC)
GO
------------------------------------------------------------------

-- create an index of the school_year table 
CREATE INDEX School_Year_Date_Start_Index
	ON ums.school_year (date_start DESC)
GO
------------------------------------------------------------------

-- create an index of the school_year table 
CREATE INDEX School_Year_Date_End_Index
	ON ums.school_year (date_end DESC)
GO
------------------------------------------------------------------

/*verifies that the trigger "School_Year_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.School_Year_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.School_Year_Trigger_Insert
GO

CREATE TRIGGER ums.School_Year_Trigger_Insert
	ON  ums.school_year
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @year_id varchar (50) 	
	DECLARE @year_description varchar (100)
	DECLARE @date_start datetime
	DECLARE @date_end datetime
	DECLARE @is_summer bit
	DECLARE @created_by varchar (50)

	DECLARE @summer varchar (50)
	
	SELECT 
		@year_id = i.year_id,
		@year_description = i.year_description,
		@date_start = i.date_start,
		@date_end = i.date_end,
		@is_summer = i.is_summer,
		@created_by = i.created_by
	FROM INSERTED AS i

	IF (@is_summer = 1)
	BEGIN
		SET @summer = 'YES'
	END
	ELSE
	BEGIN
		SET @summer = 'NO'
	END

	SET @transaction_done = 'OPENED a school year information ' + 
							'[School Year ID: ' + ISNULL(@year_id, '') +							
							'][Description: ' + ISNULL(@year_description, '') +
							'][School Year Start: ' + ISNULL(CONVERT(varchar, @date_start, 101), '') +
							'][School Year End: ' + ISNULL(CONVERT(varchar, @date_end, 101), '') +
							'][Is Summer: ' + ISNULL(@summer, '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "School_Year_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.School_Year_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.School_Year_Trigger_Instead_Update
GO

CREATE TRIGGER ums.School_Year_Trigger_Instead_Update
	ON  ums.school_year
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a school year', 'School Year'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "School_Year_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.School_Year_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.School_Year_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.School_Year_Trigger_Instead_Delete
	ON  ums.school_year
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a school year', 'School Year'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "InsertSchoolYear" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertSchoolYear')
   DROP PROCEDURE ums.InsertSchoolYear
GO

CREATE PROCEDURE ums.InsertSchoolYear

	@year_id varchar (50) = '',		
	@year_description varchar (100) = '',
	@date_start datetime,
	@date_end datetime,
	@is_summer bit = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@created_by) = 1)
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		SET @date_start = CONVERT(datetime, CONVERT(varchar, @date_start, 101) + ' 12:00:00 AM')
		SET @date_end = CONVERT(datetime, CONVERT(varchar, @date_end, 101) + ' 11:59:59 PM')

		INSERT INTO ums.school_year
		(
			year_id,
			year_description,
			date_start,
			date_end,
			is_summer,
			created_by
		)
		VALUES
		(
			@year_id,
			@year_description,
			@date_start,
			@date_end,
			@is_summer,
			@created_by
		)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert a school year', 'School Year'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertSchoolYear TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectSchoolYear" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectSchoolYear')
   DROP PROCEDURE ums.SelectSchoolYear
GO

CREATE PROCEDURE ums.SelectSchoolYear

	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsActiveSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT 
			year_id, 
			year_description, 
			date_start, 
			date_end,
			is_summer
		FROM
			ums.school_year
		ORDER BY
			date_start DESC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a school year', 'School Year'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectSchoolYear TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByYearDescriptionSchoolYear" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByYearDescriptionSchoolYear')
   DROP PROCEDURE ums.SelectByYearDescriptionSchoolYear
GO

CREATE PROCEDURE ums.SelectByYearDescriptionSchoolYear

	@query_string varchar (100) = '',
	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsActiveSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT @query_string = '%' + RTRIM(LTRIM(@query_string)) + '%'

		SELECT 
			year_id, 
			year_description, 
			date_start, 
			date_end,
			is_summer
		FROM
			ums.school_year
		WHERE
			year_description LIKE @query_string
		ORDER BY
			date_start DESC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a school year', 'School Year'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByYearDescriptionSchoolYear TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetMaxDateEndSchoolYear" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetMaxDateEndSchoolYear')
   DROP PROCEDURE ums.GetMaxDateEndSchoolYear
GO

CREATE PROCEDURE ums.GetMaxDateEndSchoolYear

	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT MAX(date_end) FROM ums.school_year
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a school year', 'School Year'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetMaxDateEndSchoolYear TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistYearIDSchoolYear" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistYearIDSchoolYear')
   DROP PROCEDURE ums.IsExistYearIDSchoolYear
GO

CREATE PROCEDURE ums.IsExistYearIDSchoolYear

	@year_id varchar (50) = '',
	@system_user_id varchar (50) = ''
		
AS
	
	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN
	
		SELECT ums.IsExistYearIDSY(@year_id)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a school year information', 'School Year'
	END
	
GO
------------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistYearIDSchoolYear TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistYearIDSY" function already exist
IF OBJECT_ID (N'ums.IsExistYearIDSY') IS NOT NULL
   DROP FUNCTION ums.IsExistYearIDSY
GO

CREATE FUNCTION ums.IsExistYearIDSY
(	
	@year_id varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT year_id FROM ums.school_year WHERE year_id = @year_id)
	BEGIN
		SET @result = 1
	END
		
	RETURN @result
END
GO
------------------------------------------------------


-- ################################################END TABLE "school_year" OBJECTS######################################################




-- ################################################TABLE "semester_information" OBJECTS######################################################
-- verifies if the semester_information table exists
IF OBJECT_ID('ums.semester_information', 'U') IS NOT NULL
	DROP TABLE ums.semester_information
GO

CREATE TABLE ums.semester_information 			
(
	sysid_semester varchar (50) NOT NULL 
		CONSTRAINT Semester_Information_SysID_Semester_PK PRIMARY KEY (sysid_semester)
		CONSTRAINT Semester_Information_SysID_Semester_CK CHECK (sysid_semester LIKE 'SYSSEM%'),	
	year_id varchar (50) NOT NULL 
		CONSTRAINT Semester_Information_Year_ID_FK FOREIGN KEY REFERENCES ums.school_year(year_id) ON UPDATE NO ACTION,
	semester_id tinyint NOT NULL
		CONSTRAINT Semester_Information_Semester_ID_FK FOREIGN KEY REFERENCES ums.school_semester(semester_id) ON UPDATE NO ACTION,
	date_start datetime NOT NULL
		CONSTRAINT Semester_Information_Date_Start_UQ UNIQUE (date_start)
		CONSTRAINT Semester_Information_Date_Start_CK CHECK (CONVERT(varchar, date_start, 109) LIKE '%12:00:00:000AM'), 
	date_end datetime NOT NULL
		CONSTRAINT Semester_Information_Date_End_UQ UNIQUE (date_end)
		CONSTRAINT Semester_Information_Date_End_CK CHECK (CONVERT(varchar, date_end, 109) LIKE '%11:59:59:000PM'),

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Semester_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Semester_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Semester_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the semester_information table 
CREATE INDEX Semester_Information_SysID_Semester_Index
	ON ums.semester_information (sysid_semester DESC)
GO
------------------------------------------------------------------

-- create an index of the semester_information table 
CREATE INDEX Semester_Information_Date_Start_Index
	ON ums.semester_information (date_start DESC)
GO
------------------------------------------------------------------

-- create an index of the semester_information table 
CREATE INDEX Semester_Information_Date_End_Index
	ON ums.semester_information (date_end DESC)
GO
------------------------------------------------------------------


/*verifies that the trigger "Semester_Information_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.Semester_Information_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Semester_Information_Trigger_Insert
GO

CREATE TRIGGER ums.Semester_Information_Trigger_Insert
	ON  ums.semester_information
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_semester varchar (50)	
	DECLARE @year_id varchar (50) 
	DECLARE @semester_id tinyint
	DECLARE @date_start datetime
	DECLARE @date_end datetime
	DECLARE @created_by varchar (50)
	
	SELECT 
		@sysid_semester = i.sysid_semester,
		@year_id = i.year_id,
		@semester_id = i.semester_id,
		@date_start = i.date_start,
		@date_end = i.date_end,
		@created_by = i.created_by
	FROM INSERTED AS i

	SET @transaction_done = 'OPENED a semester information ' + 
							'[Semester ID: ' + ISNULL(@sysid_semester, '') +							
							'][School Year: ' + ISNULL((SELECT year_description FROM ums.school_year WHERE year_id = @year_id), '') +
							'][Semester: ' + ISNULL((SELECT semester_description FROM ums.school_semester WHERE semester_id = @semester_id), '') +
							'][Semester Start: ' + ISNULL(CONVERT(varchar, @date_start, 101), '') +
							'][Semester End: ' + ISNULL(CONVERT(varchar, @date_end, 101), '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Semester_Information_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Semester_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Semester_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Semester_Information_Trigger_Instead_Update
	ON  ums.semester_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a semester information', 'Semester Information'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Semester_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Semester_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Semester_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Semester_Information_Trigger_Instead_Delete
	ON  ums.semester_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a semester information', 'Semester Information'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "InsertSemesterInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertSemesterInformation')
   DROP PROCEDURE ums.InsertSemesterInformation
GO

CREATE PROCEDURE ums.InsertSemesterInformation

	@sysid_semester varchar (50) = '',
	@year_id varchar (50) = '',
	@semester_id tinyint = 0,
	@date_start datetime,
	@date_end datetime,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@created_by) = 1)
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		SET @date_start = CONVERT(datetime, CONVERT(varchar, @date_start, 101) + ' 12:00:00 AM')
		SET @date_end = CONVERT(datetime, CONVERT(varchar, @date_end, 101) + ' 11:59:59 PM')

		INSERT INTO ums.semester_information
		(
			sysid_semester,
			year_id,
			semester_id,
			date_start,
			date_end,
			created_by
		)
		VALUES
		(
			@sysid_semester,
			@year_id,
			@semester_id,
			@date_start,
			@date_end,
			@created_by
		)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert a semester information', 'Semester Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertSemesterInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectSemesterInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectSemesterInformation')
   DROP PROCEDURE ums.SelectSemesterInformation
GO

CREATE PROCEDURE ums.SelectSemesterInformation

	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsActiveSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT 
			si.sysid_semester AS sysid_semester,
			si.year_id AS year_id,			
			si.semester_id AS semester_id,
			si.date_start AS date_start, 
			si.date_end AS date_end,
			sy.year_description AS year_description,
			sy.is_summer AS is_summer,
			ss.semester_description AS semester_description
		FROM
			ums.semester_information AS si
		INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
		INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
		ORDER BY
			si.date_start DESC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a semester information', 'Semester Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectSemesterInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectYearSemesterDescriptionSemesterInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectYearSemesterDescriptionSemesterInformation')
   DROP PROCEDURE ums.SelectYearSemesterDescriptionSemesterInformation
GO

CREATE PROCEDURE ums.SelectYearSemesterDescriptionSemesterInformation

	@query_string varchar (100) = '',
	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsActiveSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT @query_string = '%' + RTRIM(LTRIM(@query_string)) + '%'

		SELECT 
			si.sysid_semester AS sysid_semester,
			si.year_id AS year_id,			
			si.semester_id AS semester_id,
			si.date_start AS date_start, 
			si.date_end AS date_end,
			sy.year_description AS year_description,
			ss.semester_description AS semester_description
		FROM
			ums.semester_information AS si
		INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
		INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
		WHERE
			(sy.year_description LIKE @query_string) OR (ss.semester_description LIKE @query_string)
		ORDER BY
			si.date_start DESC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a semester information', 'Semester Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectYearSemesterDescriptionSemesterInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountSemesterInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountSemesterInformation')
   DROP PROCEDURE ums.GetCountSemesterInformation
GO

CREATE PROCEDURE ums.GetCountSemesterInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_semester) FROM ums.semester_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a semester information', 'Semester Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountSemesterInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetMaxDateEndSemesterInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetMaxDateEndSemesterInformation')
   DROP PROCEDURE ums.GetMaxDateEndSemesterInformation
GO

CREATE PROCEDURE ums.GetMaxDateEndSemesterInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT MAX(date_end) FROM ums.semester_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a semester information', 'Semester Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetMaxDateEndSemesterInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistSysIDSemesterInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistSysIDSemesterInformation')
   DROP PROCEDURE ums.IsExistSysIDSemesterInformation
GO

CREATE PROCEDURE ums.IsExistSysIDSemesterInformation

	@sysid_semester varchar (50) = '',
	@system_user_id varchar (50) = ''
		
AS
	
	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN
	
		SELECT ums.IsExistSysIDSemesterInfo(@sysid_semester)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a semester information', 'Semester Information'
	END
	
GO
------------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistSysIDSemesterInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistSysIDSemesterInfo" function already exist
IF OBJECT_ID (N'ums.IsExistSysIDSemesterInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistSysIDSemesterInfo
GO

CREATE FUNCTION ums.IsExistSysIDSemesterInfo
(	
	@sysid_semester varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_semester FROM ums.semester_information WHERE sysid_semester = @sysid_semester)
	BEGIN
		SET @result = 1
	END
		
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsRecordLockByYearSemesterID" function already exist
IF OBJECT_ID (N'ums.IsRecordLockByYearSemesterID') IS NOT NULL
   DROP FUNCTION ums.IsRecordLockByYearSemesterID
GO

CREATE FUNCTION ums.IsRecordLockByYearSemesterID
(	
	@year_semester_id varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	DECLARE @add_months tinyint

	SET @result = 0	
	SET @add_months = 1
	
	IF (NOT @year_semester_id IS NULL AND NOT @year_semester_id = '') AND 
		(NOT EXISTS (SELECT
							sy.year_id AS year_semester_id
						FROM
							ums.school_year AS sy
						WHERE
							(sy.year_id = @year_semester_id) AND
							(DATEADD(mm, @add_months, GETDATE()) >= sy.date_start) AND
							(DATEADD(mm, @add_months, GETDATE()) <= sy.date_end)
						UNION
						SELECT 
							sri.sysid_semester AS year_semester_id
						FROM
							ums.semester_information AS sri
						WHERE
							(sri.sysid_semester = @year_semester_id) AND
							(DATEADD(mm, @add_months, GETDATE()) >= sri.date_start) AND
							(DATEADD(mm, @add_months, GETDATE()) <= sri.date_end)))
	BEGIN
		SET @result = 1
	END	
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsRecordLockByYearSemesterIDNoAdvance" function already exist
IF OBJECT_ID (N'ums.IsRecordLockByYearSemesterIDNoAdvance') IS NOT NULL
   DROP FUNCTION ums.IsRecordLockByYearSemesterIDNoAdvance
GO

CREATE FUNCTION ums.IsRecordLockByYearSemesterIDNoAdvance
(	
	@year_semester_id varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	DECLARE @add_months tinyint

	SET @result = 0	
	SET @add_months = 1
	
	IF (NOT @year_semester_id IS NULL AND NOT @year_semester_id = '') AND 
		(NOT EXISTS (SELECT
							sy.year_id AS year_semester_id
						FROM
							ums.school_year AS sy
						WHERE
							(sy.year_id = @year_semester_id) AND
							(DATEADD(mm, @add_months, GETDATE()) <= sy.date_end)
						UNION
						SELECT 
							sri.sysid_semester AS year_semester_id
						FROM
							ums.semester_information AS sri
						WHERE
							(sri.sysid_semester = @year_semester_id) AND
							(DATEADD(mm, @add_months, GETDATE()) <= sri.date_end)))
	BEGIN
		SET @result = 1
	END	
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsRecordLockByYearSemesterIDNoAddMonths" function already exist
IF OBJECT_ID (N'ums.IsRecordLockByYearSemesterIDNoAddMonths') IS NOT NULL
   DROP FUNCTION ums.IsRecordLockByYearSemesterIDNoAddMonths
GO

CREATE FUNCTION ums.IsRecordLockByYearSemesterIDNoAddMonths
(	
	@year_semester_id varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0	
	
	IF (NOT @year_semester_id IS NULL AND NOT @year_semester_id = '') AND 
		(NOT EXISTS (SELECT
							sy.year_id AS year_semester_id
						FROM
							ums.school_year AS sy
						WHERE
							(sy.year_id = @year_semester_id) AND
							(GETDATE() >= sy.date_start) AND
							(GETDATE() <= sy.date_end)
						UNION
						SELECT 
							sri.sysid_semester AS year_semester_id
						FROM
							ums.semester_information AS sri
						WHERE
							(sri.sysid_semester = @year_semester_id) AND
							(GETDATE() >= sri.date_start) AND
							(GETDATE() <= sri.date_end)))
	BEGIN
		SET @result = 1
	END	
	
	RETURN @result
END
GO
------------------------------------------------------

---- verifies if the "IsRecordLockByYearSemesterIDNoAdvanceAddMonths" function already exist
--IF OBJECT_ID (N'ums.IsRecordLockByYearSemesterIDNoAdvanceAddMonths') IS NOT NULL
--   DROP FUNCTION ums.IsRecordLockByYearSemesterIDNoAdvanceAddMonths
--GO
--
--CREATE FUNCTION ums.IsRecordLockByYearSemesterIDNoAdvanceAddMonths
--(	
--	@year_semester_id varchar (50) = ''
--)
--RETURNS bit
--AS
--BEGIN
--	
--	DECLARE @result bit
--
--	SET @result = 0	
--	
--	IF (NOT @year_semester_id IS NULL AND NOT @year_semester_id = '') AND 
--		(NOT EXISTS (SELECT
--							sy.year_id AS year_semester_id
--						FROM
--							ums.school_year AS sy
--						WHERE
--							(sy.year_id = @year_semester_id) AND
--							(GETDATE() <= sy.date_end)
--						UNION
--						SELECT 
--							sri.sysid_semester AS year_semester_id
--						FROM
--							ums.semester_information AS sri
--						WHERE
--							(sri.sysid_semester = @year_semester_id) AND
--							(GETDATE() <= sri.date_end)))
--	BEGIN
--		SET @result = 1
--	END	
--	
--	RETURN @result
--END
--GO
--------------------------------------------------------

-- verifies if the "IsRecordLockByReflectedCreatedDate" function already exist
IF OBJECT_ID (N'ums.IsRecordLockByReflectedCreatedDate') IS NOT NULL
   DROP FUNCTION ums.IsRecordLockByReflectedCreatedDate
GO

CREATE FUNCTION ums.IsRecordLockByReflectedCreatedDate
(	
	@reflected_date datetime,
	@created_date datetime
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	DECLARE @add_months tinyint

	SET @result = 0	
	SET @add_months = 4
	
	IF (@reflected_date > (DATEADD(mm, @add_months, @created_date))) OR
		(@reflected_date < (DATEADD(mm, (@add_months - (@add_months * 2)), @created_date))) OR
		(GETDATE() > (DATEADD(mm, @add_months, @created_date)))
	BEGIN
		SET @result = 1
	END	
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsSemesterBelongToSchoolYearSemesterID" function already exist
IF OBJECT_ID (N'ums.IsSemesterBelongToSchoolYearSemesterID') IS NOT NULL
   DROP FUNCTION ums.IsSemesterBelongToSchoolYearSemesterID
GO

CREATE FUNCTION ums.IsSemesterBelongToSchoolYearSemesterID
(	
	@year_id varchar (50) = '',
	@sysid_semester varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF ((@sysid_semester IS NULL) OR (NOT EXISTS (SELECT sysid_semester FROM ums.semester_information WHERE sysid_semester = @sysid_semester))) OR
		(EXISTS (SELECT sysid_semester FROM ums.semester_information WHERE (sysid_semester = @sysid_semester) AND (year_id = @year_id)))
	BEGIN
		SET @result = 1
	END	
	
	RETURN @result
END
GO
------------------------------------------------------



-- ################################################END TABLE "semester_information" OBJECTS###################################################





-- ################################################TABLE "classroom_information" OBJECTS######################################################
-- verifies if the classroom_information table exists
IF OBJECT_ID('ums.classroom_information', 'U') IS NOT NULL
	DROP TABLE ums.classroom_information
GO

CREATE TABLE ums.classroom_information 			
(
	sysid_classroom varchar (50) NOT NULL 
		CONSTRAINT Classroom_Information_SysID_Classroom_PK PRIMARY KEY (sysid_classroom)
		CONSTRAINT Classroom_Information_SysID_Classroom_CK CHECK (sysid_classroom LIKE 'SYSCRM%'),	
	classroom_code varchar (50) NOT NULL
		CONSTRAINT Classroom_Information_Classroom_Code_UQ UNIQUE (classroom_code),
	classroom_description varchar (100) NULL,
	maximum_capacity tinyint NOT NULL,
	other_information varchar (MAX) NULL,

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Classroom_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Classroom_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Classroom_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the classroom_information table 
CREATE INDEX Classroom_Information_SysID_Classroom_Index
	ON ums.classroom_information (sysid_classroom ASC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Classroom_Information_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.Classroom_Information_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Classroom_Information_Trigger_Insert
GO

CREATE TRIGGER ums.Classroom_Information_Trigger_Insert
	ON  ums.classroom_information
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_classroom varchar (50)
	DECLARE @classroom_code varchar (50)
	DECLARE @classroom_description varchar (100)
	DECLARE @maximum_capacity tinyint
	DECLARE @other_information varchar (MAX)
	DECLARE @created_by varchar (50)
	
	SELECT 
		@sysid_classroom = i.sysid_classroom,
		@classroom_code = i.classroom_code,
		@classroom_description = i.classroom_description,
		@maximum_capacity = i.maximum_capacity,
		@other_information = i.other_information,
		@created_by = i.created_by
	FROM INSERTED AS i

	SET @transaction_done = 'CREATED a classroom information ' + 
							'[Classroom ID: ' + ISNULL(@sysid_classroom, '') +							
							'][Classroom Code: ' + ISNULL(@classroom_code, '') +
							'][Description: ' + ISNULL(@classroom_description, '') +
							'][Maximum Capacity: ' + ISNULL(CONVERT(varchar, @maximum_capacity), '') +
							'][Other Information: ' + ISNULL(@other_information, '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Classroom_Information_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Classroom_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Classroom_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Classroom_Information_Trigger_Instead_Update
	ON  ums.classroom_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_classroom varchar (50)
	DECLARE @classroom_code varchar (50)
	DECLARE @classroom_description varchar (100)
	DECLARE @maximum_capacity tinyint
	DECLARE @other_information varchar (MAX)
	DECLARE @edited_by varchar (50)

	DECLARE @classroom_code_b varchar (50)
	DECLARE @classroom_description_b varchar (100)
	DECLARE @maximum_capacity_b tinyint
	DECLARE @other_information_b varchar (MAX)

	DECLARE @has_update bit
	
	SELECT 
		@sysid_classroom = i.sysid_classroom,
		@classroom_code = i.classroom_code,
		@classroom_description = i.classroom_description,
		@maximum_capacity = i.maximum_capacity,
		@other_information = i.other_information,
		@edited_by = i.edited_by
	FROM INSERTED AS i

	SELECT
		@classroom_code_b = classroom_code,
		@classroom_description_b = classroom_description,
		@maximum_capacity_b = maximum_capacity,
		@other_information_b = other_information
	FROM 
		ums.classroom_information		
	WHERE
		sysid_classroom = @sysid_classroom

	SET @transaction_done = ''
	SET @has_update = 0

	IF NOT ISNULL(@classroom_code COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@classroom_code_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Classroom Code Before: ' + ISNULL(@classroom_code_b, '') + ']' +
													'[Classroom Code After: ' + ISNULL(@classroom_code, '') + ']' 
		SET @has_update = 1
	END
	ELSE
	BEGIN
		SET @transaction_done = @transaction_done + '[Classroom Code: ' + ISNULL(@classroom_code, '') + ']'
	END

	IF NOT ISNULL(@classroom_description COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@classroom_description_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Description Before: ' + ISNULL(@classroom_description_b, '') + ']' +
													'[Description After: ' + ISNULL(@classroom_description, '') + ']' 
		SET @has_update = 1
	END
	ELSE
	BEGIN
		SET @transaction_done = @transaction_done + '[Description: ' + ISNULL(@classroom_description, '') + ']'
	END

	IF NOT ISNULL(CONVERT(varchar, @maximum_capacity), '') = ISNULL(CONVERT(varchar, @maximum_capacity_b), '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Maximum Capacity Before: ' + ISNULL(CONVERT(varchar, @maximum_capacity_b), '') + ']' +
													'[Maximum Capacity After: ' + ISNULL(CONVERT(varchar, @maximum_capacity), '') + ']' 
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

		UPDATE ums.classroom_information SET
			classroom_code = @classroom_code,
			classroom_description = @classroom_description,
			maximum_capacity = @maximum_capacity,
			other_information = @other_information,
			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			sysid_classroom = @sysid_classroom

		SET @transaction_done = 'UPDATED a classroom information ' + 
								'[Classroom ID: ' + ISNULL(@sysid_classroom, '') + ']' + @transaction_done

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
		END
				
		EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done	

	END	

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Classroom_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Classroom_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Classroom_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Classroom_Information_Trigger_Instead_Delete
	ON  ums.classroom_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a classroom information', 'Classroom Information'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "InsertClassroomInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertClassroomInformation')
   DROP PROCEDURE ums.InsertClassroomInformation
GO

CREATE PROCEDURE ums.InsertClassroomInformation

	@sysid_classroom varchar (50) = '',
	@classroom_code varchar (50) = '',
	@classroom_description varchar (100) = '',
	@maximum_capacity tinyint = 0,
	@other_information varchar (MAX) = '',

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@created_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@created_by) = 1)
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.classroom_information
		(
			sysid_classroom,
			classroom_code,
			classroom_description,
			maximum_capacity,
			other_information,
			created_by
		)
		VALUES
		(
			@sysid_classroom,
			@classroom_code,
			@classroom_description,
			@maximum_capacity,
			@other_information,
			@created_by
		)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert a classroom information', 'Classroom Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertClassroomInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateClassroomInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateClassroomInformation')
   DROP PROCEDURE ums.UpdateClassroomInformation
GO

CREATE PROCEDURE ums.UpdateClassroomInformation

	@sysid_classroom varchar (50) = '',
	@classroom_code varchar (50) = '',
	@classroom_description varchar (100) = '',
	@maximum_capacity tinyint = 0,
	@other_information varchar (MAX) = '',

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@edited_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@edited_by) = 1)
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.classroom_information SET
			classroom_code = @classroom_code,
			classroom_description = @classroom_description,
			maximum_capacity = @maximum_capacity,
			other_information = @other_information,
			edited_by = @edited_by
		WHERE
			sysid_classroom = @sysid_classroom		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update a classroom information', 'Classroom Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateClassroomInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectClassroomInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectClassroomInformation')
   DROP PROCEDURE ums.SelectClassroomInformation
GO

CREATE PROCEDURE ums.SelectClassroomInformation

	@query_string varchar (50) = '',
	
	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT @query_string = '%' + RTRIM(LTRIM(@query_string)) + '%'
		
		IF (NOT ISNULL(@query_string, '') = '%*%')
		BEGIN
		
			SELECT 
				sysid_classroom,
				classroom_code,
				classroom_description,
				maximum_capacity,
				other_information
			FROM
				ums.classroom_information
			WHERE
				(classroom_code LIKE @query_string) OR 
				((REPLACE(classroom_code, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
				(classroom_description LIKE @query_string) OR 
				((REPLACE(classroom_description, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
				(CONVERT(varchar, maximum_capacity) LIKE @query_string)
			ORDER BY
				classroom_code ASC
		
		END
		ELSE
		BEGIN
		
			SELECT 
				sysid_classroom,
				classroom_code,
				classroom_description,
				maximum_capacity,
				other_information
			FROM
				ums.classroom_information
			ORDER BY
				classroom_code ASC
				
		END
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a classroom information', 'Classroom Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectClassroomInformation TO db_umsusers
GO
-------------------------------------------------------------

---- verifies if the procedure "SelectByCodeDescriptionCapacityClassroomInformation" exist
--IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByCodeDescriptionCapacityClassroomInformation')
--   DROP PROCEDURE ums.SelectByCodeDescriptionCapacityClassroomInformation
--GO

--CREATE PROCEDURE ums.SelectByCodeDescriptionCapacityClassroomInformation

--	@query_string varchar (100) = '',
--	@system_user_id varchar (50) = ''
		
--AS

--	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
--				(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
--				(ums.IsOfficeUserSystemUserInfo(@system_user_id) = 1)
--	BEGIN

--		SELECT @query_string = '%' + RTRIM(LTRIM(@query_string)) + '%'

--		SELECT 
--			sysid_classroom,
--			classroom_code,
--			classroom_description,
--			maximum_capacity,
--			other_information
--		FROM
--			ums.classroom_information
--		WHERE
--			(classroom_code LIKE @query_string) OR 
--			((REPLACE(classroom_code, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
--			(classroom_description LIKE @query_string) OR 
--			((REPLACE(classroom_description, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
--			(maximum_capacity LIKE @query_string)
--		ORDER BY
--			classroom_code ASC
		
--	END
--	ELSE
--	BEGIN
--		EXECUTE ums.ShowErrorMsg 'Query a classroom information', 'Classroom Information'
--	END
	
--GO
-----------------------------------------------------------

---- grant permission on the stored procedure
--GRANT EXECUTE ON ums.SelectByCodeDescriptionCapacityClassroomInformation TO db_umsusers
--GO
---------------------------------------------------------------

-- verifies if the procedure "GetCountClassroomInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountClassroomInformation')
   DROP PROCEDURE ums.GetCountClassroomInformation
GO

CREATE PROCEDURE ums.GetCountClassroomInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_classroom) FROM ums.classroom_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a classroom information', 'Classroom Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountClassroomInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistSysIDClassroomInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistSysIDClassroomInformation')
   DROP PROCEDURE ums.IsExistSysIDClassroomInformation
GO

CREATE PROCEDURE ums.IsExistSysIDClassroomInformation

	@sysid_classroom varchar (50) = '',
	@system_user_id varchar (50) = ''
		
AS
	
	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistSysIDClassroomInfo(@sysid_classroom)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a classroom information', 'Classroom Information'
	END	
	
GO
------------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistSysIDClassroomInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistCodeClassroomInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistCodeClassroomInformation')
   DROP PROCEDURE ums.IsExistCodeClassroomInformation
GO

CREATE PROCEDURE ums.IsExistCodeClassroomInformation

	@sysid_classroom varchar (50) = '',
	@classroom_code varchar (50) = '',
	@system_user_id varchar (50) = ''
		
AS
	
	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN
		
		SELECT ums.IsExistCodeClassroomInfo(@sysid_classroom, @classroom_code)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a classroom information', 'Classroom Information'
	END	
	
GO
------------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistCodeClassroomInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistSysIDClassroomInfo" function already exist
IF OBJECT_ID (N'ums.IsExistSysIDClassroomInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistSysIDClassroomInfo
GO

CREATE FUNCTION ums.IsExistSysIDClassroomInfo
(	
	@sysid_classroom varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT sysid_classroom FROM ums.classroom_information WHERE sysid_classroom = @sysid_classroom)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------


-- verifies if the "IsExistCodeClassroomInfo" function already exist
IF OBJECT_ID (N'ums.IsExistCodeClassroomInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistCodeClassroomInfo
GO

CREATE FUNCTION ums.IsExistCodeClassroomInfo
(	
	@sysid_classroom varchar (50) = '',
	@classroom_code varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_classroom FROM ums.classroom_information WHERE ((REPLACE(classroom_code, ' ', '')) LIKE REPLACE(@classroom_code, ' ', '')) AND 
								NOT sysid_classroom = @sysid_classroom)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------


-- ################################################END TABLE "classroom_information" OBJECTS###################################################




-- ################################################TABLE "course_group" OBJECTS######################################################
-- verifies if the course_group table exists
IF OBJECT_ID('ums.course_group', 'U') IS NOT NULL
	DROP TABLE ums.course_group
GO

CREATE TABLE ums.course_group 			
(
	course_group_id varchar (50) NOT NULL 
		CONSTRAINT Course_Group_Course_Group_ID_PK PRIMARY KEY (course_group_id)
		CONSTRAINT Course_Group_Course_Group_ID_CK CHECK (course_group_id LIKE 'CG%'),
	group_no tinyint NOT NULL
		CONSTRAINT Course_Group_Group_No_UQ UNIQUE (group_no),		
	group_description varchar (100) NOT NULL
		CONSTRAINT Course_Group_Group_Description_UQ UNIQUE (group_description),
	is_semestral bit NOT NULL DEFAULT (1),
	is_per_unit bit NOT NULL DEFAULT (1),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Course_Group_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- verifies that the trigger "Course_Group_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Course_Group_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Course_Group_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Course_Group_Trigger_Instead_Update
	ON  ums.course_group
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a course group', 'Course Group'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Course_Group_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Course_Group_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Course_Group_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Course_Group_Trigger_Instead_Delete
	ON  ums.course_group
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a course group', 'Course Group'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectCourseGroup" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectCourseGroup')
   DROP PROCEDURE ums.SelectCourseGroup
GO

CREATE PROCEDURE ums.SelectCourseGroup
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			cg.course_group_id AS course_group_id,
			cg.group_no AS group_no,
			cg.group_description AS group_description,
			cg.is_semestral AS is_semestral,
			cg.is_per_unit AS is_per_unit
		FROM
			ums.course_group AS cg
		ORDER BY cg.group_no ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query course group', 'Course Group'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectCourseGroup TO db_umsusers
GO
-------------------------------------------------------------


-- ################################################END TABLE "course_group" OBJECTS###################################################




-- ################################################TABLE "subject_category" OBJECTS######################################################
-- verifies if the subject_category table exists
IF OBJECT_ID('ums.subject_category', 'U') IS NOT NULL
	DROP TABLE ums.subject_category
GO

CREATE TABLE ums.subject_category 			
(
	category_id varchar (50) NOT NULL 
		CONSTRAINT Subject_Category_Category_ID_PK PRIMARY KEY (category_id)
		CONSTRAINT Subject_Category_Category_ID_CK CHECK (category_id LIKE 'CAT%'),
	category_name varchar (100) NOT NULL
		CONSTRAINT Subject_Category_Category_Name_UQ UNIQUE (category_name),
	acronym varchar (10) NULL
		CONSTRAINT Subject_Category_Acronym_UQ UNIQUE (acronym),
	category_no tinyint NOT NULL
		CONSTRAINT Subject_Category_Category_No_UQ UNIQUE (category_no),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Subject_Category_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- verifies that the trigger "Subject_Category_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Subject_Category_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Subject_Category_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Subject_Category_Trigger_Instead_Update
	ON  ums.subject_category
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a subject category', 'Subject Category'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Subject_Category_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Subject_Category_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Subject_Category_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Subject_Category_Trigger_Instead_Delete
	ON  ums.subject_category
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a subject category', 'Subject Category'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectSubjectCategory" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectSubjectCategory')
   DROP PROCEDURE ums.SelectSubjectCategory
GO

CREATE PROCEDURE ums.SelectSubjectCategory
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			sbg.category_id AS category_id,
			sbg.category_name AS category_name, 
			sbg.acronym AS acronym,
			sbg.category_no AS category_no
		FROM
			ums.subject_category AS sbg
		ORDER BY sbg.category_no ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query subject category', 'Subject Category'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectSubjectCategory TO db_umsusers
GO
-------------------------------------------------------------

-- ##############################################END TABLE "subject_category" OBJECTS######################################################





-- ################################################TABLE "subject_information" OBJECTS######################################################
-- verifies if the subject_information table exists
IF OBJECT_ID('ums.subject_information', 'U') IS NOT NULL
	DROP TABLE ums.subject_information
GO

CREATE TABLE ums.subject_information 			
(
	sysid_subject varchar (50) NOT NULL 
		CONSTRAINT Subject_Information_SysID_Subject_PK PRIMARY KEY (sysid_subject)
		CONSTRAINT Subject_Information_SysID_Subject_CK CHECK (sysid_subject LIKE 'SYSSBJ%'),	
	course_group_id varchar (50) NOT NULL
		CONSTRAINT Subject_Information_Course_Group_ID_FK FOREIGN KEY REFERENCES ums.course_group(course_group_id) ON UPDATE NO ACTION,
	department_id varchar (50) NOT NULL
		CONSTRAINT Subject_Information_Department_ID_FK FOREIGN KEY REFERENCES ums.department_information(department_id) ON UPDATE NO ACTION
		CONSTRAINT Subject_Information_Department_ID_UQ UNIQUE (department_id, subject_code, descriptive_title),
	category_id varchar (50) NULL
		CONSTRAINT Subject_Information_Category_ID_FK FOREIGN KEY REFERENCES ums.subject_category(category_id) ON UPDATE NO ACTION,
	subject_code varchar (50) NOT NULL
		CONSTRAINT Subject_Information_Subject_Code_UQ UNIQUE (subject_code, department_id, descriptive_title),
	descriptive_title varchar (500) NOT NULL
		CONSTRAINT Subject_Information_Descriptive_Title_UQ UNIQUE (descriptive_title, subject_code, department_id),

	lecture_units tinyint NOT NULL DEFAULT (0),
	lab_units tinyint NOT NULL DEFAULT (0),
	no_hours varchar (12) NOT NULL DEFAULT ('00:00') 
		CONSTRAINT Subject_Information_No_Hours_CK CHECK (no_hours LIKE '[0-9][0-9]:[0-5][0-9]'),
	other_information varchar (MAX) NULL,

	is_non_academic bit NOT NULL DEFAULT (0),
	is_open_access bit NOT NULL DEFAULT (0),

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Subject_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Subject_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Subject_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the subject_information table 
CREATE INDEX Subject_Information_SysID_Subject_Index
	ON ums.subject_information (sysid_subject ASC)
GO
------------------------------------------------------------------

--verifies that the trigger "Subject_Information_Trigger_Insert" already exist
IF OBJECT_ID ('ums.Subject_Information_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Subject_Information_Trigger_Insert
GO

CREATE TRIGGER ums.Subject_Information_Trigger_Insert
	ON  ums.subject_information
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_subject varchar (50)
	DECLARE @course_group_id varchar (50)
	DECLARE @department_id varchar (50)
	DECLARE @category_id varchar (50)
	DECLARE @subject_code varchar (50)
	DECLARE @descriptive_title varchar (500)
	DECLARE @lecture_units tinyint
	DECLARE @lab_units tinyint
	DECLARE @no_hours varchar (12)
	DECLARE @other_information varchar (MAX)
	DECLARE @is_non_academic bit 
	DECLARE @is_open_access bit
	DECLARE @created_by varchar (50)

	DECLARE @non_academic varchar (50)
	DECLARE @open_access varchar (50)
	
	SELECT 
		@sysid_subject = i.sysid_subject,
		@course_group_id = i.course_group_id,
		@department_id = i.department_id,
		@category_id = i.category_id,
		@subject_code = i.subject_code,
		@descriptive_title = i.descriptive_title,
		@lecture_units = i.lecture_units,
		@lab_units = i.lab_units,
		@no_hours = i.no_hours,
		@other_information = i.other_information,
		@is_non_academic = i.is_non_academic,
		@is_open_access = i.is_open_access,
		
		@created_by = i.created_by
	FROM INSERTED AS i

	IF @is_non_academic = 1
	BEGIN
		SET @non_academic = 'YES'
	END
	ELSE
	BEGIN
		SET @non_academic = 'NO'
	END
	
	IF @is_open_access = 1
	BEGIN
		SET @open_access = 'YES'
	END
	ELSE
	BEGIN
		SET @open_access = 'NO'
	END

	SET @transaction_done = 'CREATED a subject information ' + 
							'[System ID: ' + ISNULL(@sysid_subject, '') +							
							'][Course Group: ' + ISNULL((SELECT group_description FROM ums.course_group WHERE course_group_id = @course_group_id), '') +
							'][Department: ' + ISNULL((SELECT department_name FROM ums.department_information WHERE department_id = @department_id), '') +
							'][Category: ' + ISNULL((SELECT acronym + '. ' + category_name FROM ums.subject_category WHERE category_id = @category_id), '') +
							'][Subject Code: ' + ISNULL(@subject_code, '') +
							'][Descriptive Title: ' + ISNULL(@descriptive_title, '') +
							'][Lecture Units: ' + ISNULL(CONVERT(varchar, @lecture_units), '') +
							'][Lab Units: ' + ISNULL(CONVERT(varchar, @lab_units), '') +
							'][Number of Hours: ' + ISNULL(@no_hours, '') +
							'][Other Information: ' + ISNULL(@other_information, '') +
							'][Is Non-academic: ' + ISNULL(@non_academic, '') +
							'][Is Open Access: ' + ISNULL(@open_access, '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
-----------------------------------------------------------------------

--verifies that the trigger "Subject_Information_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Subject_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Subject_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Subject_Information_Trigger_Instead_Update
	ON  ums.subject_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_subject varchar (50)
	DECLARE @course_group_id varchar (50)
	DECLARE @department_id varchar (50)
	DECLARE @category_id varchar (50)
	DECLARE @subject_code varchar (50)
	DECLARE @descriptive_title varchar (500)
	DECLARE @lecture_units tinyint
	DECLARE @lab_units tinyint
	DECLARE @no_hours varchar (12)
	DECLARE @other_information varchar (MAX)
	DECLARE @is_non_academic bit 
	DECLARE @is_open_access bit 
	DECLARE @edited_by varchar (50)

	DECLARE @department_id_b varchar (50)
	DECLARE @category_id_b varchar (50)
	DECLARE @subject_code_b varchar (50)
	DECLARE @descriptive_title_b varchar (500)
	DECLARE @lecture_units_b tinyint
	DECLARE @lab_units_b tinyint
	DECLARE @no_hours_b varchar (12)
	DECLARE @other_information_b varchar (MAX)
	DECLARE @is_non_academic_b bit 
	DECLARE @is_open_access_b bit

	DECLARE @non_academic varchar (50)
	DECLARE @non_academic_b varchar (50)
	DECLARE @open_access varchar (50)
	DECLARE @open_access_b varchar (50)

	DECLARE @has_update bit
	
	SELECT 
		@sysid_subject = i.sysid_subject,
		@course_group_id = i.course_group_id,
		@department_id = i.department_id,
		@category_id = i.category_id,
		@subject_code = i.subject_code,
		@descriptive_title = i.descriptive_title,
		@lecture_units = i.lecture_units,
		@lab_units = i.lab_units,
		@no_hours = i.no_hours,
		@other_information = i.other_information,
		@is_non_academic = i.is_non_academic,
		@is_open_access = i.is_open_access,
		
		@edited_by = i.edited_by
	FROM INSERTED AS i

	SELECT
		@department_id_b = si.department_id,
		@category_id_b = si.category_id,
		@subject_code_b = si.subject_code,
		@descriptive_title_b = si.descriptive_title,
		@lecture_units_b = si.lecture_units,
		@lab_units_b = si.lab_units,
		@no_hours_b = si.no_hours,
		@other_information_b = si.other_information,
		@is_non_academic_b = si.is_non_academic,
		@is_open_access_b = si.is_open_access
	FROM
		ums.subject_information AS si
	WHERE
		sysid_subject = @sysid_subject

	SET @transaction_done = ''
	SET @has_update = 0

	IF NOT ISNULL(@department_id, '') = ISNULL(@department_id_b, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Department Before: ' + ISNULL((SELECT department_name FROM ums.department_information WHERE department_id = @department_id_b), '') + ']' +
													'[Department After: ' + ISNULL((SELECT department_name FROM ums.department_information WHERE department_id = @department_id), '') + ']'
		SET @has_update = 1
	END
	
	IF NOT ISNULL(@category_id, '') = ISNULL(@category_id_b, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Category Before: ' + ISNULL((SELECT acronym + '. ' + category_name FROM ums.subject_category WHERE category_id = @category_id_b), '') + ']' +
													'[Category After: ' + ISNULL((SELECT acronym + '. ' + category_name FROM ums.subject_category WHERE category_id = @category_id), '') + ']'
		SET @has_update = 1
	END

	IF NOT ISNULL(@subject_code COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@subject_code_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Subject Code Before: ' + ISNULL(@subject_code_b, '') + ']' +
													'[Subject Code After: ' + ISNULL(@subject_code, '') + ']'
		SET @has_update = 1
	END
	ELSE
	BEGIN
		SET @transaction_done = @transaction_done + '[Subject Code: ' + ISNULL(@subject_code, '') + ']'
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

	IF NOT @is_non_academic = @is_non_academic_b
	BEGIN

		IF @is_non_academic = 1
		BEGIN
			SET @non_academic = 'YES'
		END
		ELSE
		BEGIN
			SET @non_academic = 'NO'
		END

		IF @is_non_academic_b = 1
		BEGIN
			SET @non_academic_b = 'YES'
		END
		ELSE
		BEGIN
			SET @non_academic_b = 'NO'
		END

		SET @transaction_done = @transaction_done + '[Is Non-academic Before: ' + ISNULL(@non_academic_b, '') + ']' +
													'[Is Non-academic After: ' + ISNULL(@non_academic, '') + ']'
		SET @has_update = 1

	END	
	
	IF NOT @is_open_access = @is_open_access_b
	BEGIN

		IF @is_open_access = 1
		BEGIN
			SET @open_access = 'YES'
		END
		ELSE
		BEGIN
			SET @open_access = 'NO'
		END

		IF @is_open_access_b = 1
		BEGIN
			SET @open_access_b = 'YES'
		END
		ELSE
		BEGIN
			SET @open_access_b = 'NO'
		END

		SET @transaction_done = @transaction_done + '[Is Open Access Before: ' + ISNULL(@open_access_b, '') + ']' +
													'[Is Open Access After: ' + ISNULL(@open_access, '') + ']'
		SET @has_update = 1

	END	

	IF @has_update = 1
	BEGIN

		UPDATE ums.subject_information SET
			department_id = @department_id,
			category_id = @category_id,
			subject_code = @subject_code,
			descriptive_title = @descriptive_title,
			lecture_units = @lecture_units,
			lab_units = @lab_units,
			no_hours = @no_hours,
			other_information = @other_information,
			is_non_academic = @is_non_academic,
			is_open_access = @is_open_access,
			
			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			sysid_subject = @sysid_subject
		

		SET @transaction_done = 'UPDATED a subject information ' + 
								'[System ID: ' + ISNULL(@sysid_subject, '') + 
								'][Course Group: ' + ISNULL((SELECT group_description FROM ums.course_group WHERE course_group_id = @course_group_id), '') +
								']' + @transaction_done

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
		END
				
		EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done

	END		

GO
-------------------------------------------------------------------

-- verifies that the trigger "Subject_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Subject_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Subject_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Subject_Information_Trigger_Instead_Delete
	ON  ums.subject_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a subject information', 'Subject Information'
	
GO
-------------------------------------------------------------------------


-- verifies if the procedure "InsertSubjectInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertSubjectInformation')
   DROP PROCEDURE ums.InsertSubjectInformation
GO

CREATE PROCEDURE ums.InsertSubjectInformation

	@sysid_subject varchar (50) = '',
	@course_group_id varchar (50) = '',
	@department_id varchar (50) = '',
	@category_id varchar (50) = '',
	@subject_code varchar (50) = '',
	@descriptive_title varchar (500) = '',
	@lecture_units tinyint = 0,
	@lab_units tinyint = 0,
	@no_hours varchar (12) = '',
	@other_information varchar (MAX) = '',
	@is_non_academic bit = 0,
	@is_open_access bit = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@created_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@created_by) = 1)) AND
			(ums.IsExistCodeDescriptionSubjectInfo(@sysid_subject, @subject_code, @descriptive_title, @department_id) = 0)
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.subject_information
		(
			sysid_subject,
			course_group_id,
			department_id,
			category_id,
			subject_code,
			descriptive_title,
			lecture_units,
			lab_units,
			no_hours,
			other_information,
			is_non_academic,
			is_open_access,
			
			created_by
		)
		VALUES
		(
			@sysid_subject,
			@course_group_id,
			@department_id,
			@category_id,
			@subject_code,
			@descriptive_title,
			@lecture_units,
			@lab_units,
			@no_hours,
			@other_information,
			@is_non_academic,
			@is_open_access,
			
			@created_by
		)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert a subject information', 'Subject Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertSubjectInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateSubjectInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateSubjectInformation')
   DROP PROCEDURE ums.UpdateSubjectInformation
GO

CREATE PROCEDURE ums.UpdateSubjectInformation

	@sysid_subject varchar (50) = '',
	@department_id varchar (50) = '',
	@category_id varchar (50) = '',
	@subject_code varchar (50) = '',
	@descriptive_title varchar (500) = '',
	@lecture_units tinyint = 0,
	@lab_units tinyint = 0,
	@no_hours varchar (12) = '',
	@other_information varchar (MAX) = '',
	@is_non_academic bit = 0,
	@is_open_access bit = 0,

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@edited_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@edited_by) = 1)) AND
			(ums.IsExistCodeDescriptionSubjectInfo(@sysid_subject, @subject_code, @descriptive_title, @department_id) = 0)
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.subject_information SET
			department_id = @department_id,
			category_id = @category_id,
			subject_code = @subject_code,
			descriptive_title = @descriptive_title,
			lecture_units = @lecture_units,
			lab_units = @lab_units,
			no_hours = @no_hours,
			other_information = @other_information,
			is_non_academic = @is_non_academic,
			is_open_access = @is_open_access,
			
			edited_by = @edited_by
		WHERE
			sysid_subject = @sysid_subject
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update a subject information', 'Subject Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateSubjectInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectSubjectInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectSubjectInformation')
   DROP PROCEDURE ums.SelectSubjectInformation
GO

CREATE PROCEDURE ums.SelectSubjectInformation

	@query_string varchar (50) = '',
	
	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR 
		(ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
		(ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT @query_string = '%' + RTRIM(LTRIM(@query_string)) + '%'
		
		IF (NOT ISNULL(@query_string, '') = '%*%')
		BEGIN
		
			SELECT 
				si.sysid_subject AS sysid_subject,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS lecture_units,
				si.lab_units AS lab_units,
				si.no_hours AS no_hours,
				si.other_information AS other_information,
				si.is_non_academic AS is_non_academic,
				si.is_open_access AS is_open_access,
				
				--si.course_group_id
				cg.course_group_id AS course_group_id,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral,
				
				--si.department_id
				di.department_id AS department_id,
				di.department_name AS department_name,
				
				--si.category_id
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym
				
			FROM
				ums.subject_information AS si
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			WHERE
				(si.subject_code LIKE @query_string) OR
				((REPLACE(si.subject_code, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
				(si.descriptive_title LIKE @query_string) OR
				((REPLACE(si.descriptive_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
				(di.department_name LIKE @query_string) OR
				((REPLACE(di.department_name, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
				((si.subject_code + ' - ' + si.descriptive_title) LIKE @query_string) OR
				((si.subject_code + ' ' + si.descriptive_title) LIKE @query_string) OR
				((si.descriptive_title + ' ' + si.subject_code) LIKE @query_string) OR
				((si.subject_code + '-' + si.descriptive_title) LIKE REPLACE(@query_string, ' ', '')) OR
				((si.subject_code + si.descriptive_title) LIKE REPLACE(@query_string, ' ', '')) OR
				((si.descriptive_title + si.subject_code) LIKE REPLACE(@query_string, ' ', '')) OR
				((REPLACE(si.subject_code, ' ', '') + '-' + REPLACE(si.descriptive_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
				((REPLACE(si.subject_code, ' ', '') + REPLACE(si.descriptive_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
				((REPLACE(si.descriptive_title, ' ', '') + REPLACE(si.subject_code, ' ', '')) LIKE REPLACE(@query_string, ' ', ''))
			ORDER BY
				si.subject_code ASC
				
		END
		ELSE
		BEGIN
		
			SELECT 
				si.sysid_subject AS sysid_subject,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS lecture_units,
				si.lab_units AS lab_units,
				si.no_hours AS no_hours,
				si.other_information AS other_information,
				si.is_non_academic AS is_non_academic,
				si.is_open_access AS is_open_access,
				
				--si.course_group_id
				cg.course_group_id AS course_group_id,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral,
				
				--si.department_id
				di.department_id AS department_id,
				di.department_name AS department_name,
				
				--si.category_id
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym
				
			FROM
				ums.subject_information AS si
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			ORDER BY
				si.subject_code ASC
				
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
			
		SELECT @query_string = '%' + RTRIM(LTRIM(@query_string)) + '%'
		
		IF (NOT ISNULL(@query_string, '') = '%*%')
		BEGIN
		
			SELECT 
				si.sysid_subject AS sysid_subject,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS lecture_units,
				si.lab_units AS lab_units,
				si.no_hours AS no_hours,
				si.other_information AS other_information,
				si.is_non_academic AS is_non_academic,
				si.is_open_access AS is_open_access,
				
				--si.course_group_id
				cg.course_group_id AS course_group_id,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral,
				
				--si.department_id
				di.department_id AS department_id,
				di.department_name AS department_name,
				
				--si.category_id
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym
				
			FROM
				ums.subject_information AS si
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			WHERE
				((si.subject_code LIKE @query_string) OR
				((REPLACE(si.subject_code, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
				(si.descriptive_title LIKE @query_string) OR
				((REPLACE(si.descriptive_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
				(di.department_name LIKE @query_string) OR
				((REPLACE(di.department_name, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
				((si.subject_code + ' - ' + si.descriptive_title) LIKE @query_string) OR
				((si.subject_code + ' ' + si.descriptive_title) LIKE @query_string) OR
				((si.descriptive_title + ' ' + si.subject_code) LIKE @query_string) OR
				((si.subject_code + '-' + si.descriptive_title) LIKE REPLACE(@query_string, ' ', '')) OR
				((si.subject_code + si.descriptive_title) LIKE REPLACE(@query_string, ' ', '')) OR
				((si.descriptive_title + si.subject_code) LIKE REPLACE(@query_string, ' ', '')) OR
				((REPLACE(si.subject_code, ' ', '') + '-' + REPLACE(si.descriptive_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
				((REPLACE(si.subject_code, ' ', '') + REPLACE(si.descriptive_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
				((REPLACE(si.descriptive_title, ' ', '') + REPLACE(si.subject_code, ' ', '')) LIKE REPLACE(@query_string, ' ', ''))) AND 
				(si.department_id = @department_id)
			ORDER BY
				si.subject_code ASC		
		
		END
		ELSE
		BEGIN

			SELECT 
				si.sysid_subject AS sysid_subject,
				si.subject_code AS subject_code,
				si.descriptive_title AS descriptive_title,
				si.lecture_units AS lecture_units,
				si.lab_units AS lab_units,
				si.no_hours AS no_hours,
				si.other_information AS other_information,
				si.is_non_academic AS is_non_academic,
				si.is_open_access AS is_open_access,
				
				--si.course_group_id
				cg.course_group_id AS course_group_id,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral,
				
				--si.department_id
				di.department_id AS department_id,
				di.department_name AS department_name,
				
				--si.category_id
				sc.category_id AS category_id,
				sc.category_name AS category_name,
				sc.acronym AS category_acronym
				
			FROM
				ums.subject_information AS si
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
			INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
			LEFT JOIN ums.subject_category AS sc ON sc.category_id = si.category_id
			WHERE
				si.department_id = @department_id
			ORDER BY
				si.subject_code ASC
			
		END
	END
	ELSE
	BEGIN

		EXECUTE ums.ShowErrorMsg 'Query a subject information', 'Subject Information'

	END
	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectSubjectInformation TO db_umsusers
GO
-------------------------------------------------------------

---- verifies if the procedure "SelectBySubjectCodeTitleSubjectInformation" exist
--IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySubjectCodeTitleSubjectInformation')
--   DROP PROCEDURE ums.SelectBySubjectCodeTitleSubjectInformation
--GO

--CREATE PROCEDURE ums.SelectBySubjectCodeTitleSubjectInformation

--	@query_string varchar (100) = '',
--	@system_user_id varchar (50) = ''
		
--AS

--	SELECT @query_string = '%' + RTRIM(LTRIM(@query_string)) + '%'

--	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
--				(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1) OR
--				(ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1)
--	BEGIN

--		SELECT 
--			si.sysid_subject AS sysid_subject,
--			si.course_group_id AS course_group_id,
--			si.department_id AS department_id,
--			si.subject_code AS subject_code,
--			si.descriptive_title AS descriptive_title,
--			si.lecture_units AS lecture_units,
--			si.lab_units AS lab_units,
--			si.no_hours AS no_hours,
--			si.other_information AS other_information,
--			si.is_non_academic AS is_non_academic,
--			cg.group_no AS group_no,
--			cg.is_semestral AS is_semestral,
--			di.department_name AS department_name
--		FROM
--			ums.subject_information AS si
--		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--		WHERE
--			(si.subject_code LIKE @query_string) OR
--			((REPLACE(si.subject_code, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
--			(si.descriptive_title LIKE @query_string) OR
--			((REPLACE(si.descriptive_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
--			(di.department_name LIKE @query_string) OR
--			((REPLACE(di.department_name, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
--			((si.subject_code + ' - ' + si.descriptive_title) LIKE @query_string) OR
--			((si.subject_code + ' ' + si.descriptive_title) LIKE @query_string) OR
--			((si.descriptive_title + ' ' + si.subject_code) LIKE @query_string) OR
--			((si.subject_code + '-' + si.descriptive_title) LIKE REPLACE(@query_string, ' ', '')) OR
--			((si.subject_code + si.descriptive_title) LIKE REPLACE(@query_string, ' ', '')) OR
--			((si.descriptive_title + si.subject_code) LIKE REPLACE(@query_string, ' ', '')) OR
--			((REPLACE(si.subject_code, ' ', '') + '-' + REPLACE(si.descriptive_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
--			((REPLACE(si.subject_code, ' ', '') + REPLACE(si.descriptive_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
--			((REPLACE(si.descriptive_title, ' ', '') + REPLACE(si.subject_code, ' ', '')) LIKE REPLACE(@query_string, ' ', ''))
--		ORDER BY
--			si.subject_code ASC
		
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

--		SELECT 
--			si.sysid_subject AS sysid_subject,
--			si.course_group_id AS course_group_id,
--			si.department_id AS department_id,
--			si.subject_code AS subject_code,
--			si.descriptive_title AS descriptive_title,
--			si.lecture_units AS lecture_units,
--			si.lab_units AS lab_units,
--			si.no_hours AS no_hours,
--			si.other_information AS other_information,
--			si.is_non_academic AS is_non_academic,
--			cg.group_no AS group_no,
--			cg.is_semestral AS is_semestral,
--			di.department_name AS department_name
--		FROM
--			ums.subject_information AS si
--		INNER JOIN ums.course_group AS cg ON cg.course_group_id = si.course_group_id
--		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
--		WHERE
--			((si.subject_code LIKE @query_string) OR
--			((REPLACE(si.subject_code, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
--			(si.descriptive_title LIKE @query_string) OR
--			((REPLACE(si.descriptive_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
--			(di.department_name LIKE @query_string) OR
--			((REPLACE(di.department_name, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
--			((si.subject_code + ' - ' + si.descriptive_title) LIKE @query_string) OR
--			((si.subject_code + ' ' + si.descriptive_title) LIKE @query_string) OR
--			((si.descriptive_title + ' ' + si.subject_code) LIKE @query_string) OR
--			((si.subject_code + '-' + si.descriptive_title) LIKE REPLACE(@query_string, ' ', '')) OR
--			((si.subject_code + si.descriptive_title) LIKE REPLACE(@query_string, ' ', '')) OR
--			((si.descriptive_title + si.subject_code) LIKE REPLACE(@query_string, ' ', '')) OR
--			((REPLACE(si.subject_code, ' ', '') + '-' + REPLACE(si.descriptive_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
--			((REPLACE(si.subject_code, ' ', '') + REPLACE(si.descriptive_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
--			((REPLACE(si.descriptive_title, ' ', '') + REPLACE(si.subject_code, ' ', '')) LIKE REPLACE(@query_string, ' ', ''))) AND 
--			(si.department_id = @department_id)
--		ORDER BY
--			si.subject_code ASC
--	END
--	ELSE
--	BEGIN

--		EXECUTE ums.ShowErrorMsg 'Query a subject information', 'Subject Information'

--	END
	
	
--GO
-----------------------------------------------------------

---- grant permission on the stored procedure
--GRANT EXECUTE ON ums.SelectBySubjectCodeTitleSubjectInformation TO db_umsusers
--GO
---------------------------------------------------------------

-- verifies if the procedure "GetCountSubjectInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountSubjectInformation')
   DROP PROCEDURE ums.GetCountSubjectInformation
GO

CREATE PROCEDURE ums.GetCountSubjectInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_subject) FROM ums.subject_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a subject information', 'Subject Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountSubjectInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistSysIDSubjectInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistSysIDSubjectInformation')
   DROP PROCEDURE ums.IsExistSysIDSubjectInformation
GO

CREATE PROCEDURE ums.IsExistSysIDSubjectInformation

	@sysid_subject varchar (50) = '',
	@system_user_id varchar (50) = ''
		
AS
	
	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistSysIDSubjectInfo(@sysid_subject)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a subject information', 'Subject Information'
	END
	
GO
------------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistSysIDSubjectInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistCodeDescriptionSubjectInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistCodeDescriptionSubjectInformation')
   DROP PROCEDURE ums.IsExistCodeDescriptionSubjectInformation
GO

CREATE PROCEDURE ums.IsExistCodeDescriptionSubjectInformation

	@sysid_subject varchar (50) = '',
	@subject_code varchar (50) = '',
	@descriptive_title varchar (500) = '',
	@department_id varchar (50) = '',
	@system_user_id varchar (50) = ''
		
AS
	
	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistCodeDescriptionSubjectInfo(@sysid_subject, @subject_code, @descriptive_title, @department_id)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a subject information', 'Subject Information'
	END
	
GO
------------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistCodeDescriptionSubjectInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistSysIDSubjectInfo" function already exist
IF OBJECT_ID (N'ums.IsExistSysIDSubjectInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistSysIDSubjectInfo
GO

CREATE FUNCTION ums.IsExistSysIDSubjectInfo
(	
	@sysid_subject varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT sysid_subject FROM ums.subject_information WHERE sysid_subject = @sysid_subject)
	BEGIN
		SET @result = 1
	END		
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsExistCodeDescriptionSubjectInfo" function already exist
IF OBJECT_ID (N'ums.IsExistCodeDescriptionSubjectInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistCodeDescriptionSubjectInfo
GO

CREATE FUNCTION ums.IsExistCodeDescriptionSubjectInfo
(	
	@sysid_subject varchar (50) = '',
	@subject_code varchar (50) = '',
	@descriptive_title varchar (500) = '',
	@department_id varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT sysid_subject FROM ums.subject_information WHERE NOT sysid_subject = @sysid_subject AND 
							(((REPLACE(subject_code, ' ', '')) LIKE REPLACE(@subject_code, ' ', '')) AND 
							((REPLACE(descriptive_title, ' ', '')) LIKE REPLACE(@descriptive_title, ' ', '')) AND department_id = @department_id))
	BEGIN
		SET @result = 1
	END		
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsUserSameDepartmentSubjectInfo" function already exist
IF OBJECT_ID (N'ums.IsUserSameDepartmentSubjectInfo') IS NOT NULL
   DROP FUNCTION ums.IsUserSameDepartmentSubjectInfo
GO

CREATE FUNCTION ums.IsUserSameDepartmentSubjectInfo
(	
	@sysid_subject varchar (50) = '',
	@system_user_id varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT rights_granted_id FROM ums.access_rights_granted WHERE system_user_id = @system_user_id AND 
						department_id = (SELECT department_id FROM ums.subject_information WHERE sysid_subject = @sysid_subject))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsOpenAccessSubjectInfo" function already exist
IF OBJECT_ID (N'ums.IsOpenAccessSubjectInfo') IS NOT NULL
   DROP FUNCTION ums.IsOpenAccessSubjectInfo
GO

CREATE FUNCTION ums.IsOpenAccessSubjectInfo
(	
	@sysid_subject varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT sysid_subject FROM ums.subject_information WHERE sysid_subject = @sysid_subject AND is_open_access = 1)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------



-- ################################################END TABLE "subject_information" OBJECTS######################################################







-- ################################################TABLE "subject_prerequisite" OBJECTS######################################################
-- verifies if the subject_prerequisite table exists
IF OBJECT_ID('ums.subject_prerequisite', 'U') IS NOT NULL
	DROP TABLE ums.subject_prerequisite
GO

CREATE TABLE ums.subject_prerequisite 			
(
	prerequisite_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Subject_Prerequisite_Prerequisite_ID_PK PRIMARY KEY (prerequisite_id),	
	sysid_subject varchar (50) NOT NULL 
		CONSTRAINT Subject_Prerequisite_SysID_Subject_FK FOREIGN KEY REFERENCES ums.subject_information(sysid_subject) ON UPDATE NO ACTION,
	prerequisite_subject varchar (50) NOT NULL
		CONSTRAINT Subject_Prerequisite_Prerequisite_Subject_FK FOREIGN KEY REFERENCES ums.subject_information(sysid_subject) ON UPDATE NO ACTION,

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Subject_Prerequisite_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Subject_Prerequisite_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Subject_Prerequisite_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the subject_prerequisite table 
CREATE INDEX Subject_Prerequisite_Prerequisite_ID_Index
	ON ums.subject_prerequisite (prerequisite_id ASC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Subject_Prerequisite_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.Subject_Prerequisite_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Subject_Prerequisite_Trigger_Insert
GO

CREATE TRIGGER ums.Subject_Prerequisite_Trigger_Insert
	ON  ums.subject_prerequisite
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @prerequisite_id bigint
	DECLARE @sysid_subject varchar (50)
	DECLARE @prerequisite_subject varchar (50)
	DECLARE @created_by varchar (50)
	
	SELECT 
		@prerequisite_id = i.prerequisite_id,
		@sysid_subject = i.sysid_subject,
		@prerequisite_subject = i.prerequisite_subject,
		@created_by = i.created_by
	FROM INSERTED AS i

	SET @transaction_done = 'CREATED a pre-requisite subject ' + 
							'[Pre-requisite ID: ' + ISNULL(CONVERT(varchar, @prerequisite_id), '') +
							'][Base Subject Code: ' + ISNULL((SELECT subject_code FROM ums.subject_information WHERE sysid_subject = @sysid_subject), '') +
							'][Base Subject Descriptive Title: ' + ISNULL((SELECT descriptive_title FROM ums.subject_information WHERE sysid_subject = @sysid_subject), '') +
							'][Pre-requisite Subject Code: ' + ISNULL((SELECT subject_code FROM ums.subject_information WHERE sysid_subject = @prerequisite_subject), '') +
							'][Pre-requisite Subject Descriptive Title: ' + ISNULL((SELECT descriptive_title FROM ums.subject_information WHERE sysid_subject = @prerequisite_subject), '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Subject_Prerequisite_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Subject_Prerequisite_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Subject_Prerequisite_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Subject_Prerequisite_Trigger_Instead_Update
	ON  ums.subject_prerequisite
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @prerequisite_id bigint

	DECLARE @edited_by varchar (50)

	DECLARE subject_prerequisite_update_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
		FOR SELECT i.prerequisite_id, i.edited_by
				FROM INSERTED AS i

	OPEN subject_prerequisite_update_cursor

	FETCH NEXT FROM subject_prerequisite_update_cursor
		INTO @prerequisite_id, @edited_by

	WHILE @@FETCH_STATUS = 0
	BEGIN	

		--used for the delete trigger
		IF NOT @edited_by IS NULL
		BEGIN

			UPDATE ums.subject_prerequisite SET
				edited_on = GETDATE(),
				edited_by = @edited_by
			WHERE
				prerequisite_id = @prerequisite_id
		END		

		FETCH NEXT FROM subject_prerequisite_update_cursor
			INTO @prerequisite_id, @edited_by

	END
	
	CLOSE subject_prerequisite_update_cursor
	DEALLOCATE subject_prerequisite_update_cursor	
	
GO
-------------------------------------------------------------------------

/*verifies that the trigger "Subject_Prerequisite_Trigger_Delete" already exist*/
IF OBJECT_ID ('ums.Subject_Prerequisite_Trigger_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Subject_Prerequisite_Trigger_Delete
GO

CREATE TRIGGER ums.Subject_Prerequisite_Trigger_Delete
	ON  ums.subject_prerequisite
	FOR DELETE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @prerequisite_id bigint
	DECLARE @sysid_subject varchar (50)
	DECLARE @prerequisite_subject varchar (50)
	DECLARE @deleted_by varchar (50)

	DECLARE subject_prerequisite_delete_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
		FOR SELECT d.prerequisite_id, d.sysid_subject, d.prerequisite_subject, d.edited_by
			FROM 
				DELETED AS d

	OPEN subject_prerequisite_delete_cursor

	FETCH NEXT FROM subject_prerequisite_delete_cursor
		INTO @prerequisite_id, @sysid_subject, @prerequisite_subject, @deleted_by

	WHILE @@FETCH_STATUS = 0
	BEGIN		

		SET @transaction_done = 'DELETED a pre-requisite subject ' + 
								'[Pre-requisite ID: ' + ISNULL(CONVERT(varchar, @prerequisite_id), '') +
								'][Base Subject Code: ' + ISNULL((SELECT subject_code FROM ums.subject_information WHERE sysid_subject = @sysid_subject), '') +
								'][Base Subject Descriptive Title: ' + ISNULL((SELECT descriptive_title FROM ums.subject_information WHERE sysid_subject = @sysid_subject), '') +
								'][Pre-requisite Subject Code: ' + ISNULL((SELECT subject_code FROM ums.subject_information WHERE sysid_subject = @prerequisite_subject), '') +
								'][Pre-requisite Subject Descriptive Title: ' + ISNULL((SELECT descriptive_title FROM ums.subject_information WHERE sysid_subject = @prerequisite_subject), '') +
								']'

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @deleted_by
		END
				
		EXECUTE ums.InsertTransactionLog @deleted_by, @network_information, @transaction_done	

		FETCH NEXT FROM subject_prerequisite_delete_cursor
			INTO @prerequisite_id, @sysid_subject, @prerequisite_subject, @deleted_by

	END
	
	CLOSE subject_prerequisite_delete_cursor
	DEALLOCATE subject_prerequisite_delete_cursor

GO
/*-----------------------------------------------------------------*/

-- verifies if the procedure "InsertSubjectPrerequisite" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertSubjectPrerequisite')
   DROP PROCEDURE ums.InsertSubjectPrerequisite
GO

CREATE PROCEDURE ums.InsertSubjectPrerequisite

	@sysid_subject varchar (50) = '',
	@prerequisite_subject varchar (50) = '',

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@created_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@created_by) = 1)
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.subject_prerequisite
		(
			sysid_subject,
			prerequisite_subject,
			created_by
		)
		VALUES
		(
			@sysid_subject,
			@prerequisite_subject,
			@created_by
		)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert a subject pre-requisite', 'Subject Pre-requisite'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertSubjectPrerequisite TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteSubjectPrerequisite" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteSubjectPrerequisite')
   DROP PROCEDURE ums.DeleteSubjectPrerequisite
GO

CREATE PROCEDURE ums.DeleteSubjectPrerequisite

	@prerequisite_id bigint = 0,

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@deleted_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@deleted_by) = 1)
	BEGIN

		IF EXISTS (SELECT prerequisite_id FROM ums.subject_prerequisite WHERE prerequisite_id = @prerequisite_id)
		BEGIN
		
			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.subject_prerequisite SET
				edited_by = @deleted_by
			WHERE
				prerequisite_id = @prerequisite_id

			DELETE FROM ums.subject_prerequisite WHERE prerequisite_id = @prerequisite_id

		END
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete a subject pre-requisite', 'Subject Pre-requisite'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteSubjectPrerequisite TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectBySubjectIDSubjectPrerequisite" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectBySubjectIDSubjectPrerequisite')
   DROP PROCEDURE ums.SelectBySubjectIDSubjectPrerequisite
GO

CREATE PROCEDURE ums.SelectBySubjectIDSubjectPrerequisite

	@sysid_subject varchar (50) = '',
	@system_user_id varchar (50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT 
			sp.prerequisite_id AS prerequisite_id,
			sp.prerequisite_subject AS prerequisite_subject,
			si.subject_code AS subject_code,
			si.descriptive_title AS descriptive_title,
			si.lecture_units AS lecture_units,
			si.lab_units AS lab_units,
			si.no_hours AS no_hours,
			di.department_name AS department_name
		FROM
			ums.subject_prerequisite AS sp
		INNER JOIN ums.subject_information AS si ON si.sysid_subject = sp.prerequisite_subject
		INNER JOIN ums.department_information AS di ON di.department_id = si.department_id
		WHERE
			sp.sysid_subject = @sysid_subject
		ORDER BY
			si.subject_code ASC
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a subject pre-requisite', 'Subject Pre-requisite'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectBySubjectIDSubjectPrerequisite TO db_umsusers
GO
-------------------------------------------------------------

-- ################################################END TABLE "subject_prerequisite" OBJECTS######################################################







-- ################################################TABLE "year_level_information" OBJECTS######################################################
-- verifies if the year_level_information table exists
IF OBJECT_ID('ums.year_level_information', 'U') IS NOT NULL
	DROP TABLE ums.year_level_information
GO

CREATE TABLE ums.year_level_information 			
(
	year_level_id varchar (50) NOT NULL 
		CONSTRAINT Year_Level_Information_Year_Level_ID_PK PRIMARY KEY (year_level_id)
		CONSTRAINT Year_Level_Information_Year_Level_ID_CK CHECK (year_level_id LIKE 'YRLV%'),
	course_group_id varchar (50) NOT NULL 
		CONSTRAINT Year_Level_Information_Course_Group_ID_FK FOREIGN KEY REFERENCES ums.course_group(course_group_id) ON UPDATE NO ACTION
		CONSTRAINT Year_Level_Information_Course_Group_ID_UQ UNIQUE (course_group_id, year_level_description),
	year_level_description varchar (100) NOT NULL
		CONSTRAINT Year_Level_Information_Year_Level_Description_UQ UNIQUE (year_level_description, course_group_id),

	acronym varchar (20) NOT NULL,
	id_prefix varchar (20) NOT NULL,
	year_level_no smallint NOT NULL,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Year_Level_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- verifies that the trigger "Year_Level_Information_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Year_Level_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Year_Level_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Year_Level_Information_Trigger_Instead_Update
	ON  ums.year_level_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a year level information', 'Year Level Information'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Year_Level_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Year_Level_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Year_Level_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Year_Level_Information_Trigger_Instead_Delete
	ON  ums.year_level_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a year level information', 'Year Level Information'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectYearLevelInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectYearLevelInformation')
   DROP PROCEDURE ums.SelectYearLevelInformation
GO

CREATE PROCEDURE ums.SelectYearLevelInformation
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			yli.year_level_id AS year_level_id,
			yli.course_group_id AS course_group_id,
			yli.year_level_description AS year_level_description,
			yli.acronym AS acronym,
			yli.id_prefix AS id_prefix,
			yli.year_level_no AS year_level_no,			
			cg.group_no AS group_no,
			cg.group_description AS group_description,
			cg.is_semestral AS is_semestral,
			cg.is_per_unit AS is_per_unit
		FROM
			ums.year_level_information AS yli
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
		ORDER BY 
			cg.group_no, yli.year_level_no ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a year level information', 'Year Level Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectYearLevelInformation TO db_umsusers
GO
-------------------------------------------------------------

-- ################################################END TABLE "year_level_information" OBJECTS###################################################






-- ################################################TABLE "course_information" OBJECTS######################################################
-- verifies if the course_information table existss
IF OBJECT_ID('ums.course_information', 'U') IS NOT NULL
	DROP TABLE ums.course_information
GO

CREATE TABLE ums.course_information 			
(
	course_id varchar (50) NOT NULL 
		CONSTRAINT Course_Information_Course_ID_PK PRIMARY KEY (course_id)
		CONSTRAINT Course_Information_Course_ID_CK CHECK (course_id LIKE 'CRSE%'),
	course_group_id varchar (50) NOT NULL
		CONSTRAINT Course_Information_Course_Group_ID_FK FOREIGN KEY REFERENCES ums.course_group(course_group_id) ON UPDATE NO ACTION,
	department_id varchar (50) NOT NULL
		CONSTRAINT Course_Information_Department_ID_FK FOREIGN KEY REFERENCES ums.department_information(department_id) ON UPDATE NO ACTION,
	course_title varchar (100) NOT NULL
		CONSTRAINT Course_Information_Course_Title_UQ UNIQUE (course_title),
	acronym varchar (20) NOT NULL
		CONSTRAINT Course_Information_Acronym_UQ UNIQUE (acronym),

	is_still_offered bit NOT NULL DEFAULT (0),

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Course_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Course_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Course_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the course_information table 
CREATE INDEX Course_Information_Course_ID_Index
	ON ums.course_information (course_id ASC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Course_Information_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.Course_Information_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Course_Information_Trigger_Insert
GO

CREATE TRIGGER ums.Course_Information_Trigger_Insert
	ON  ums.course_information
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @course_id varchar (50)
	DECLARE @course_group_id varchar (50)
	DECLARE @department_id varchar (50)
	DECLARE @course_title varchar (100)
	DECLARE @acronym varchar (20) 
	DECLARE @created_by varchar (50)
	
	SELECT 
		@course_id = i.course_id,
		@course_group_id = i.course_group_id,
		@department_id = i.department_id,
		@course_title = i.course_title,
		@acronym = i.acronym,
		@created_by = i.created_by
	FROM INSERTED AS i

	SET @transaction_done = 'CREATED a new course information ' + 
							'[Course ID: ' + ISNULL(@course_id, '') +
							'][Course Title: ' + ISNULL(@course_title, '') +
							'][Department: ' + ISNULL((SELECT 
															department_name + ' (' + acronym + ')' 
														FROM 
															ums.department_information 
														WHERE 
															department_id = @department_id), '') +
							'][Acronym: ' + ISNULL(@acronym, '') +
							'][Course Group: ' + ISNULL((SELECT group_description FROM ums.course_group WHERE course_group_id = @course_group_id), '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Course_Information_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Course_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Course_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Course_Information_Trigger_Instead_Update
	ON  ums.course_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a course information', 'Course Information'

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Course_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Course_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Course_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Course_Information_Trigger_Instead_Delete
	ON  ums.course_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a course information', 'Course Information'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectCourseInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectCourseInformation')
   DROP PROCEDURE ums.SelectCourseInformation
GO

CREATE PROCEDURE ums.SelectCourseInformation

	@query_string varchar (50) = '',
	
	@system_user_id varchar (50) = ''	
		
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN

		SELECT @query_string = '%' + RTRIM(LTRIM(@query_string)) + '%'
		
		IF (NOT ISNULL(@query_string, '') = '%*%')
		BEGIN
		
			SELECT
				ci.course_id AS course_id,
				ci.course_group_id AS course_group_id,
				ci.department_id AS department_id,
				ci.course_title AS course_title,
				ci.acronym AS course_acronym,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral,
				cg.is_per_unit AS is_per_unit,
				di.department_name AS department_name,
				di.acronym AS department_acronym,
				di.id_prefix AS id_prefix
			FROM
				ums.course_information AS ci
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
			INNER JOIN ums.department_information AS di ON di.department_id = ci.department_id
			WHERE
				((ci.course_title LIKE @query_string) OR 
				((REPLACE(ci.course_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
				(ci.acronym LIKE @query_string) OR 
				((REPLACE(ci.acronym, ' ', '')) LIKE REPLACE(@query_string, ' ', ''))) AND
				(ci.is_still_offered = 1)
			ORDER BY
				ci.course_title ASC
		
		END
		ELSE
		BEGIN
		
			SELECT
				ci.course_id AS course_id,
				ci.course_group_id AS course_group_id,
				ci.department_id AS department_id,
				ci.course_title AS course_title,
				ci.acronym AS course_acronym,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral,
				cg.is_per_unit AS is_per_unit,
				di.department_name AS department_name,
				di.acronym AS department_acronym,
				di.id_prefix AS id_prefix
			FROM
				ums.course_information AS ci
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
			INNER JOIN ums.department_information AS di ON di.department_id = ci.department_id
			WHERE
				(ci.is_still_offered = 1)
			ORDER BY
				ci.course_title ASC
				
		END
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a course information', 'Course Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectCourseInformation TO db_umsusers
GO
-------------------------------------------------------------

---- verifies if the procedure "SelectByTitleAcronymCourseInformation" exist
--IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByTitleAcronymCourseInformation')
--   DROP PROCEDURE ums.SelectByTitleAcronymCourseInformation
--GO

--CREATE PROCEDURE ums.SelectByTitleAcronymCourseInformation

--	@query_string varchar (100) = '',
--	@system_user_id varchar (50) = ''	
		
--AS

--	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
--	BEGIN

--		SELECT @query_string = '%' + RTRIM(LTRIM(@query_string)) + '%'

--		SELECT
--			ci.course_id AS course_id,
--			ci.course_group_id AS course_group_id,
--			ci.department_id AS department_id,
--			ci.course_title AS course_title,
--			ci.acronym AS course_acronym,
--			cg.group_no AS group_no,
--			cg.is_semestral AS is_semestral,
--			cg.is_per_unit AS is_per_unit,
--			di.department_name AS department_name,
--			di.acronym AS department_acronym,
--			di.id_prefix AS id_prefix
--		FROM
--			ums.course_information AS ci
--		INNER JOIN ums.course_group AS cg ON cg.course_group_id = ci.course_group_id
--		INNER JOIN ums.department_information AS di ON di.department_id = ci.department_id
--		WHERE
--			((ci.course_title LIKE @query_string) OR (ci.acronym LIKE @query_string)) AND
--			(ci.is_still_offered = 1)
--		ORDER BY
--			ci.course_title ASC
		
--	END
--	ELSE
--	BEGIN
--		EXECUTE ums.ShowErrorMsg 'Query a course information', 'Course Information'
--	END
	
--GO
-----------------------------------------------------------

---- grant permission on the stored procedure
--GRANT EXECUTE ON ums.SelectByTitleAcronymCourseInformation TO db_umsusers
--GO
---------------------------------------------------------------

-- verifies if the "IsUserSameDepartmentCourseInfo" function already exist
IF OBJECT_ID (N'ums.IsUserSameDepartmentCourseInfo') IS NOT NULL
   DROP FUNCTION ums.IsUserSameDepartmentCourseInfo
GO

CREATE FUNCTION ums.IsUserSameDepartmentCourseInfo
(	
	@course_id varchar (50) = '',
	@system_user_id varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT rights_granted_id FROM ums.access_rights_granted WHERE system_user_id = @system_user_id AND 
						department_id = (SELECT department_id FROM ums.course_information WHERE course_id = @course_id))
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------


-- ################################################END TABLE "course_information" OBJECTS######################################################







-- ################################################TABLE "course_major_information" OBJECTS######################################################
-- verifies if the course_major_information table existss
IF OBJECT_ID('ums.course_major_information', 'U') IS NOT NULL
	DROP TABLE ums.course_major_information
GO

CREATE TABLE ums.course_major_information 			
(
	major_information_id varchar (50) NOT NULL
		CONSTRAINT Course_Major_Information_Major_Information_ID_PK PRIMARY KEY (major_information_id)
		CONSTRAINT Course_Major_Information_Major_Information_ID_CK CHECK (major_information_id LIKE 'CMID%'),
	course_id varchar (50) NOT NULL
		CONSTRAINT Course_Major_Information_Course_ID_FK FOREIGN KEY REFERENCES ums.course_information(course_id) ON UPDATE NO ACTION
		CONSTRAINT Course_Major_Information_Course_ID_UQ UNIQUE (course_id, course_major_title),
	course_major_title varchar (100) NOT NULL
		CONSTRAINT Course_Major_Information_Course_Major_Title_UQ UNIQUE (course_major_title, course_id),
	acronym varchar (20) NOT NULL,

	is_still_offered bit NOT NULL DEFAULT (0),	

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Course_Major_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Course_Major_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Course_Major_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the course_major_information table 
CREATE INDEX Course_Major_Information_Major_Information_ID_Index
	ON ums.course_major_information (major_information_id ASC)
GO
------------------------------------------------------------------

--verifies that the trigger "Course_Major_Information_Trigger_Insert" already exist
IF OBJECT_ID ('ums.Course_Major_Information_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Course_Major_Information_Trigger_Insert
GO

CREATE TRIGGER ums.Course_Major_Information_Trigger_Insert
	ON  ums.course_major_information
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @major_information_id varchar (50)
	DECLARE @course_id varchar (50)
	DECLARE @course_major_title varchar (100)
	DECLARE @acronym varchar (20) 

	DECLARE @created_by varchar (50)
	
	SELECT 
		@major_information_id = i.major_information_id,
		@course_id = i.course_id,
		@course_major_title = i.course_major_title,
		@acronym = i.acronym,
		@created_by = i.created_by
	FROM INSERTED AS i

	SET @transaction_done = 'CREATED a new course major information ' + 
							'[Major Information ID: ' + ISNULL(@major_information_id, '') +
							'][Course Title: ' + ISNULL((SELECT 
																ci.course_title + ' (' + di.department_name + ')'
															FROM
																ums.course_information AS ci
															INNER JOIN ums.department_information AS di ON di.department_id = ci.department_id
															WHERE
																ci.course_id = @course_id), '') +
							'][Course Major Title: ' + ISNULL(@course_major_title, '') +
							'][Acronym: ' + ISNULL(@acronym, '') +
							'][Course Group: ' + ISNULL((SELECT 
																group_description 
															FROM 
																ums.course_group AS cg
															INNER JOIN ums.course_information AS ci ON ci.course_group_id = cg.course_group_id
															WHERE 
																ci.course_id = @course_id), '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
---------------------------------------------------------------------------

/*verifies that the trigger "Course_Major_Information_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Course_Major_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Course_Major_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Course_Major_Information_Trigger_Instead_Update
	ON  ums.course_major_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a course major information', 'Course Major Information'

GO
-------------------------------------------------------------------------

-- verifies that the trigger "Course_Major_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Course_Major_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Course_Major_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Course_Major_Information_Trigger_Instead_Delete
	ON  ums.course_major_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a course major information', 'Course Major Information'
	
GO
-------------------------------------------------------------------------

-- ################################################TABLE "course_major_information" OBJECTS######################################################





-- ################################################TABLE "course_year_level" OBJECTS######################################################
-- verifies if the course_year_level table exists
IF OBJECT_ID('ums.course_year_level', 'U') IS NOT NULL
	DROP TABLE ums.course_year_level
GO

CREATE TABLE ums.course_year_level 			
(
	course_year_level_id varchar (50) NOT NULL 
		CONSTRAINT Course_Year_Level_Course_Year_Level_ID_PK PRIMARY KEY (course_year_level_id),		
		CONSTRAINT Course_Year_Level_Course_Year_Level_ID_CK CHECK (course_year_level_id LIKE 'CYLI%'),
	course_id varchar (50) NOT NULL 
		CONSTRAINT Course_Year_Level_Course_ID_FK FOREIGN KEY REFERENCES ums.course_information(course_id) ON UPDATE NO ACTION
		CONSTRAINT Course_Year_Level_Course_ID_UQ UNIQUE (course_id, year_level_id),
	year_level_id varchar (50) NOT NULL
		CONSTRAINT Course_Year_Level_Year_Level_ID_FK FOREIGN KEY REFERENCES ums.year_level_information(year_level_id) ON UPDATE NO ACTION
		CONSTRAINT Course_Year_Level_Year_Level_ID_UQ UNIQUE (year_level_id, course_id),

	is_graduate_level bit NOT NULL DEFAULT (0),

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Course_Year_Level_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Course_Year_Level_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Course_Year_Level_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the course_year_level table 
CREATE INDEX Course_Year_Level_Course_Year_Level_ID_Index
	ON ums.course_year_level (course_year_level_id ASC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Course_Year_Level_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.Course_Year_Level_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Course_Year_Level_Trigger_Insert
GO

CREATE TRIGGER ums.Course_Year_Level_Trigger_Insert
	ON  ums.course_year_level
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @course_id varchar (50)
	DECLARE @year_level_id varchar (50)
	DECLARE @is_graduate_level bit
	DECLARE @created_by varchar (50)

	DECLARE @graduate_level varchar (50)
	
	SELECT 
		@course_id = i.course_id,
		@year_level_id = i.year_level_id,
		@is_graduate_level = i.is_graduate_level,
		@created_by = i.created_by
	FROM INSERTED AS i

	IF @is_graduate_level = 1
	BEGIN
		SET @graduate_level = 'YES'
	END
	ELSE
	BEGIN
		SET @graduate_level = 'NO'
	END

	SET @transaction_done = 'CREATED a new course year level ' + 
							'[Course Title: ' + ISNULL((SELECT course_title FROM ums.course_information WHERE course_id = @course_id), '') +
							'][Year Level: ' + ISNULL((SELECT yli.year_level_description + ' (' + cg.group_description + ')'
														FROM
															ums.year_level_information AS yli
														INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
														WHERE
															yli.year_level_id = @year_level_id), '') +
							'][Is Level Graduating: ' + ISNULL(@graduate_level, '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Course_Year_Level_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Course_Year_Level_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Course_Year_Level_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Course_Year_Level_Trigger_Instead_Update
	ON  ums.course_year_level
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a course year level', 'Course Year Level'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Course_Year_Level_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Course_Year_Level_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Course_Year_Level_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Course_Year_Level_Trigger_Instead_Delete
	ON  ums.course_year_level
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a course year level', 'Course Year Level'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectCourseYearLevel" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectCourseYearLevel')
   DROP PROCEDURE ums.SelectCourseYearLevel
GO

CREATE PROCEDURE ums.SelectCourseYearLevel
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			cyl.course_year_level_id AS course_year_level_id,
			cyl.course_id AS course_id,
			cyl.year_level_id AS year_level_id,
			cyl.is_graduate_level AS is_graduate_level,
			ci.course_title AS course_title,
			ci.acronym AS course_acronym,
			yli.year_level_description AS year_level_description,
			yli.acronym AS level_acronym,
			yli.id_prefix AS id_prefix,
			cg.group_no AS group_no,
			cg.group_description AS group_description,
			cg.is_per_unit AS is_per_unit
		FROM
			ums.course_year_level AS cyl
		INNER JOIN ums.course_information AS ci ON ci.course_id = cyl.course_id
		INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = cyl.year_level_id
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
		ORDER BY 
			ci.course_title, yli.year_level_no ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query course year level', 'Course Year Level'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectCourseYearLevel TO db_umsusers
GO
-------------------------------------------------------------

-- ################################################END TABLE "course_year_level" OBJECTS######################################################






-- ################################################TABLE "special_class_information" OBJECTS######################################################
-- verifies if the special_class_information table exists
IF OBJECT_ID('ums.special_class_information', 'U') IS NOT NULL
	DROP TABLE ums.special_class_information
GO

CREATE TABLE ums.special_class_information 			
(
	sysid_special varchar (50) NOT NULL
		CONSTRAINT Special_Class_Information_SysID_Special_PK PRIMARY KEY (sysid_special)
		CONSTRAINT Special_Class_Information_SysID_Special_CK CHECK (sysid_special LIKE 'SYSSPC%'),
	sysid_subject varchar (50) NOT NULL 
		CONSTRAINT Special_Class_Information_SysID_Subject_FK FOREIGN KEY REFERENCES ums.subject_information(sysid_subject) ON UPDATE NO ACTION,
	sysid_employee varchar (50) NOT NULL
		CONSTRAINT Special_Class_Information_SysID_Employee_FK FOREIGN KEY REFERENCES ums.employee_information(sysid_employee) ON UPDATE NO ACTION,
	year_id varchar (50) NULL
		CONSTRAINT Special_Class_Information_Year_ID_FK FOREIGN KEY REFERENCES ums.school_year(year_id) ON UPDATE NO ACTION,
	sysid_semester varchar (50) NULL 
		CONSTRAINT Special_Class_Information_SysID_Semester_FK FOREIGN KEY REFERENCES ums.semester_information(sysid_semester) ON UPDATE NO ACTION,

	amount decimal (12, 2) NOT NULL,

	is_marked_deleted bit NOT NULL DEFAULT (0),
	
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Special_Class_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Special_Class_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Special_Class_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the special_class_information table 
CREATE INDEX Special_Class_Information_SysID_Special_Index
	ON ums.special_class_information (sysid_special DESC)
GO
------------------------------------------------------------------

-- verifies if the procedure "InsertSpecialClassInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertSpecialClassInformation')
   DROP PROCEDURE ums.InsertSpecialClassInformation
GO

CREATE PROCEDURE ums.InsertSpecialClassInformation

	@sysid_special varchar (50) = '',
	@sysid_subject varchar (50) = '',
	@sysid_employee varchar (50) = '',
	@year_id varchar (50) = '',
	@sysid_semester varchar (50) = '',
	@amount decimal (12, 2) = 0,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@created_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@created_by) = 1) OR
			(ums.IsVpOfAcademicAffairsSystemUserInfo(@created_by) = 1)) AND 
			(ums.IsRecordLockByYearSemesterID(@year_id) = 0 AND ums.IsRecordLockByYearSemesterID(@sysid_semester) = 0)
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

			INSERT INTO ums.special_class_information
			(
				sysid_special,
				sysid_subject,
				sysid_employee,
				year_id,
				sysid_semester,
				amount,
				created_by
			)
			VALUES
			(
				@sysid_special,
				@sysid_subject,
				@sysid_employee,
				@year_id,
				NULL,
				@amount,
				@created_by
			)

		END
		ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL AND NOT @sysid_semester = '')	
		BEGIN

			INSERT INTO ums.special_class_information
			(
				sysid_special,
				sysid_subject,
				sysid_employee,
				year_id,
				sysid_semester,
				amount,
				created_by
			)
			VALUES
			(
				@sysid_special,
				@sysid_subject,
				@sysid_employee,
				NULL,
				@sysid_semester,
				@amount,
				@created_by
			)

		END	
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new special class information', 'Special Class Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertSpecialClassInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateSpecialClassInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateSpecialClassInformation')
   DROP PROCEDURE ums.UpdateSpecialClassInformation
GO

CREATE PROCEDURE ums.UpdateSpecialClassInformation

	@sysid_special varchar (50) = '',
	@amount decimal (12, 2) = 0,

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@edited_by) = 1) OR
		(ums.IsCashierSystemUserInfo(@edited_by) = 1) OR (ums.IsVpOfFinanceSystemUserInfo(@edited_by) = 1)) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.special_class_information AS sci
												WHERE 
													sci.sysid_special = @sysid_special AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.special_class_information AS sci
												WHERE 
													sci.sysid_special = @sysid_special AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.special_class_information SET
			amount = @amount,
			edited_by = @edited_by
		WHERE
			sysid_special = @sysid_special
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Updated a special class information', 'Special Class Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateSpecialClassInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteSpecialClassInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteSpecialClassInformation')
   DROP PROCEDURE ums.DeleteSpecialClassInformation
GO

CREATE PROCEDURE ums.DeleteSpecialClassInformation

	@sysid_special varchar (50) = '',
	
	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@deleted_by) = 1)) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.special_class_information AS sci
												WHERE 
													sci.sysid_special = @sysid_special AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.special_class_information AS sci
												WHERE 
													sci.sysid_special = @sysid_special AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0)
	BEGIN

		IF EXISTS (SELECT sysid_special FROM ums.special_class_information WHERE sysid_special = @sysid_special)
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.special_class_information SET			
				edited_by = @deleted_by
			WHERE
				sysid_special = @sysid_special			

			DELETE FROM ums.special_class_information WHERE sysid_special = @sysid_special

		END

	END	
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete a special class information', 'Special Class Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteSpecialClassInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountSpecialClassInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountSpecialClassInformation')
   DROP PROCEDURE ums.GetCountSpecialClassInformation
GO

CREATE PROCEDURE ums.GetCountSpecialClassInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT COUNT(sysid_special) FROM ums.special_class_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a special class information', 'Special Class Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountSpecialClassInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsSysIDSpecialClassInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsSysIDSpecialClassInformation')
   DROP PROCEDURE ums.IsExistsSysIDSpecialClassInformation
GO

CREATE PROCEDURE ums.IsExistsSysIDSpecialClassInformation

	@sysid_special varchar (50) = '',
	@system_user_id varchar (50) = ''	
		
AS
	
	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsSysIDSpecialClass(@sysid_special)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a special class information', 'Special Class Information'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsSysIDSpecialClassInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsInformationSpecialClassInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsInformationSpecialClassInformation')
   DROP PROCEDURE ums.IsExistsInformationSpecialClassInformation
GO

CREATE PROCEDURE ums.IsExistsInformationSpecialClassInformation

	@sysid_subject varchar (50) = '',
	@sysid_employee varchar (50) = '',
	@year_semester_id varchar (50) = '',
	@system_user_id varchar(50) = ''
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT ums.IsExistsInformationSpecialClass(@sysid_subject, @sysid_employee, @year_semester_id)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a special class information', 'Special Class Information'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsInformationSpecialClassInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistsSysIDSpecialClass" function already exist
IF OBJECT_ID (N'ums.IsExistsSysIDSpecialClass') IS NOT NULL
   DROP FUNCTION ums.IsExistsSysIDSpecialClass
GO

CREATE FUNCTION ums.IsExistsSysIDSpecialClass
(	
	@sysid_special varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_special FROM ums.special_class_information WHERE sysid_special = @sysid_special)
	BEGIN
		SET @result = 1
	END	
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsExistsInformationSpecialClass" function already exist
IF OBJECT_ID (N'ums.IsExistsInformationSpecialClass') IS NOT NULL
   DROP FUNCTION ums.IsExistsInformationSpecialClass
GO

CREATE FUNCTION ums.IsExistsInformationSpecialClass
(	
	@sysid_subject varchar (50) = '',
	@sysid_employee varchar (50) = '',
	@year_semester_id varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT 
					sci.sysid_special AS sysid_special
				FROM 
					ums.special_class_information AS sci
				WHERE 
					(sci.sysid_subject = @sysid_subject) AND 
					(sci.sysid_employee = @sysid_employee) AND
					(sci.is_marked_deleted = 0) AND
					(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
					(sci.year_id = @year_semester_id)
				UNION
				SELECT 
					sci.sysid_special AS sysid_special
				FROM 
					ums.special_class_information AS sci
				WHERE 
					(sci.sysid_subject = @sysid_subject) AND 
					(sci.sysid_employee = @sysid_employee) AND
					(sci.is_marked_deleted = 0) AND
					(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND
					(sci.sysid_semester = @year_semester_id))
	BEGIN
		SET @result = 1
	END	
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "GetYearSemesterIDSpecialClass" function already exist
IF OBJECT_ID (N'ums.GetYearSemesterIDSpecialClass') IS NOT NULL
   DROP FUNCTION ums.GetYearSemesterIDSpecialClass
GO

CREATE FUNCTION ums.GetYearSemesterIDSpecialClass
(	
	@sysid_special varchar (50) = ''
)
RETURNS varchar (50)
AS
BEGIN
	
	DECLARE @result varchar (50)

	SELECT @result = year_id FROM ums.special_class_information WHERE sysid_special = @sysid_special

	IF @result IS NULL OR @result = ''
	BEGIN
		SELECT @result = sysid_semester FROM ums.special_class_information WHERE sysid_special = @sysid_special
	END
	
	RETURN @result

END
GO
------------------------------------------------------

-- ################################################END TABLE "special_class_information" OBJECTS###################################################




-- ################################################TABLE "special_class_load" OBJECTS######################################################
-- verifies if the special_class_load table exists
IF OBJECT_ID('ums.special_class_load', 'U') IS NOT NULL
	DROP TABLE ums.special_class_load
GO

CREATE TABLE ums.special_class_load 			
(
	load_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Special_Class_Load_Load_ID_PK PRIMARY KEY (load_id),
	sysid_special varchar (50) NOT NULL
		CONSTRAINT Special_Class_Load_SysID_Special_FK FOREIGN KEY REFERENCES ums.special_class_information(sysid_special) ON UPDATE NO ACTION,
	sysid_student varchar (50) NOT NULL 
		CONSTRAINT Special_Class_Load_SysID_Student_FK FOREIGN KEY REFERENCES ums.student_information(sysid_student) ON UPDATE NO ACTION,
	load_date datetime NOT NULL
		CONSTRAINT Special_Class_Load_Date_Start_CK CHECK (CONVERT(varchar, load_date, 109) LIKE '%12:00:00:000AM'), 
	deload_date datetime NOT NULL
		CONSTRAINT Special_Class_Load_Date_End_CK CHECK (CONVERT(varchar, deload_date, 109) LIKE '%11:59:59:000PM'),

	lecture_units tinyint NOT NULL DEFAULT (0),
	lab_units tinyint NOT NULL DEFAULT (0),
	no_hours varchar (12) NOT NULL DEFAULT ('00:00')
		CONSTRAINT Special_Class_Load_No_Hours_CK CHECK (no_hours LIKE '[0][0-9]:[0-5][0-9]' OR 
													no_hours LIKE '[1][0-9]:[0-5][0-9]' OR
													no_hours LIKE '[2][0-3]:[0-5][0-9]'),

	is_premature_deloaded bit NOT NULL DEFAULT (0),

	is_for_permanent_delete bit NOT NULL DEFAULT (0),
	
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Special_Class_Load_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Special_Class_Load_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Special_Class_Load_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the special_class_load table 
CREATE INDEX Special_Class_Load_Load_ID_Index
	ON ums.special_class_load (load_id DESC)
GO
------------------------------------------------------------------

-- verifies if the procedure "InsertSpecialClassLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertSpecialClassLoad')
   DROP PROCEDURE ums.InsertSpecialClassLoad
GO

CREATE PROCEDURE ums.InsertSpecialClassLoad

	@sysid_special varchar (50) = '',
	@sysid_student varchar (50) = '',

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS
	
	DECLARE @date_start datetime
	DECLARE @date_end datetime

	SELECT @date_start = CASE WHEN ((cg.is_semestral = 0) AND (NOT sci.year_id IS NULL AND NOT sci.year_id = ''))
							THEN
								(sy.date_start)
							WHEN ((cg.is_semestral = 1) AND (NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))
							THEN
								(sri.date_start)
							ELSE
								NULL
							END
						FROM
							ums.course_group AS cg
						INNER JOIN ums.subject_information AS si ON si.course_group_id = cg.course_group_id
						INNER JOIN ums.special_class_information AS sci ON sci.sysid_subject = si.sysid_subject
						LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
						LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
						WHERE
							(sci.sysid_special = @sysid_special)

	SELECT @date_end = CASE WHEN ((cg.is_semestral = 0) AND (NOT sci.year_id IS NULL AND NOT sci.year_id = ''))
							THEN
								(sy.date_end)
							WHEN ((cg.is_semestral = 1) AND (NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))
							THEN
								(sri.date_end)
							ELSE
								NULL
							END
						FROM
							ums.course_group AS cg
						INNER JOIN ums.subject_information AS si ON si.course_group_id = cg.course_group_id
						INNER JOIN ums.special_class_information AS sci ON sci.sysid_subject = si.sysid_subject
						LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
						LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
						WHERE
							(sci.sysid_special = @sysid_special)

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@created_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@created_by) = 1) OR
			(ums.IsVpOfAcademicAffairsSystemUserInfo(@created_by) = 1)) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.special_class_information AS sci
												WHERE 
													sci.sysid_special = @sysid_special AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.special_class_information AS sci
												WHERE 
													sci.sysid_special = @sysid_special AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0) AND
			(ums.IsRecordLockByYearSemesterID((SELECT
													sfi.year_id AS year_semester_id		--WITH COURSE AND WITH YEAR LEVEL (BY YEAR)
												FROM
													ums.school_fee_information AS sfi
												INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
												INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
												INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
												INNER JOIN 
												( 
													SELECT	
														sel.sysid_enrolmentcourse AS sysid_enrolmentcourse,
														MAX(sel.enrolment_level_no)	AS enrolment_level_no	
													FROM
														ums.student_enrolment_level AS sel
													INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse	
													INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
													INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
													INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id					
													INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
													INNER JOIN ums.school_year AS sy ON sy.year_id = sfi.year_id	
													WHERE
														(sel.is_marked_deleted = 0) AND
														(NOT sel.sysid_enrolmentlevel IS NULL) AND
														(sec.sysid_student = @sysid_student) AND
														(NOT sec.course_id IS NULL) AND														
														(sec.is_current_course = 1) AND --only the current course can be inserted with a special class
														((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)) AND
														(cg.is_semestral = 0)
													GROUP BY
														sel.sysid_enrolmentcourse
												) AS sel_max ON sel_max.sysid_enrolmentcourse = sec.sysid_enrolmentcourse AND sel_max.enrolment_level_no = sel.enrolment_level_no
												UNION ALL
												SELECT
													sel.sysid_semester AS year_semester_id		--WITH COURSE AND WITH YEAR LEVEL (BY SEMESTER)
												FROM
													ums.student_enrolment_level AS sel
												INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
												INNER JOIN 
												( 
													SELECT
														sel.sysid_enrolmentcourse AS sysid_enrolmentcourse,
														MAX(sel.enrolment_level_no)	AS enrolment_level_no
													FROM
														ums.student_enrolment_level AS sel
													INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
													INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
													INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id
													INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse					
													INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sel.sysid_semester
													WHERE
														(sel.is_marked_deleted = 0) AND
														(NOT sel.sysid_enrolmentlevel IS NULL) AND
														(sec.sysid_student = @sysid_student) AND
														(NOT sec.course_id IS NULL) AND
														(sec.is_current_course = 1) AND --only the current course can be inserted with a special class
														(NOT sel.sysid_semester IS NULL AND NOT sel.sysid_semester = '') AND
														((@date_start BETWEEN sri.date_start AND sri.date_end) AND (@date_end BETWEEN sri.date_start AND sri.date_end)) AND
														(cg.is_semestral = 1)
													GROUP BY
														sel.sysid_enrolmentcourse
												) AS sel_max ON sel_max.sysid_enrolmentcourse = sec.sysid_enrolmentcourse AND sel_max.enrolment_level_no = sel.enrolment_level_no)) = 0) AND
		(ums.IsSpecialClassInformationAlreadyLoadedStudent(@sysid_special, @sysid_student) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.special_class_load
		(
			sysid_special,
			sysid_student,
			created_by
		)
		VALUES
		(
			@sysid_special,
			@sysid_student,
			@created_by
		)		
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new special class load', 'Special Class Load'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertSpecialClassLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateSpecialClassLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateSpecialClassLoad')
   DROP PROCEDURE ums.UpdateSpecialClassLoad
GO

CREATE PROCEDURE ums.UpdateSpecialClassLoad

	@load_id bigint,
	@is_premature_deloaded bit = 0,

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	DECLARE @date_start datetime
	DECLARE @date_end datetime

	SELECT @date_start = CASE WHEN ((cg.is_semestral = 0) AND (NOT sci.year_id IS NULL AND NOT sci.year_id = ''))
							THEN
								(sy.date_start)
							WHEN ((cg.is_semestral = 1) AND (NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))
							THEN
								(sri.date_start)
							ELSE
								NULL
							END
						FROM
							ums.course_group AS cg
						INNER JOIN ums.subject_information AS si ON si.course_group_id = cg.course_group_id
						INNER JOIN ums.special_class_information AS sci ON sci.sysid_subject = si.sysid_subject
						INNER JOIN ums.special_class_load AS scl ON scl.sysid_special = sci.sysid_special
						LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
						LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
						WHERE
							(scl.load_id = @load_id)

	SELECT @date_end = CASE WHEN ((cg.is_semestral = 0) AND (NOT sci.year_id IS NULL AND NOT sci.year_id = ''))
							THEN
								(sy.date_end)
							WHEN ((cg.is_semestral = 1) AND (NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))
							THEN
								(sri.date_end)
							ELSE
								NULL
							END
						FROM
							ums.course_group AS cg
						INNER JOIN ums.subject_information AS si ON si.course_group_id = cg.course_group_id
						INNER JOIN ums.special_class_information AS sci ON sci.sysid_subject = si.sysid_subject
						INNER JOIN ums.special_class_load AS scl ON scl.sysid_special = sci.sysid_special
						LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
						LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
						WHERE
							(scl.load_id = @load_id)

	IF ((ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@edited_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@edited_by) = 1) OR
			(ums.IsVpOfAcademicAffairsSystemUserInfo(@edited_by) = 1)) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.special_class_load AS scl
												INNER JOIN ums.special_class_information AS sci ON sci.sysid_special = scl.sysid_special
												WHERE 
													scl.load_id = @load_id AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.special_class_load AS scl
												INNER JOIN ums.special_class_information AS sci ON sci.sysid_special = scl.sysid_special
												WHERE 
													scl.load_id = @load_id AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0) AND
			(ums.IsRecordLockByYearSemesterID((SELECT
													sfi.year_id AS year_semester_id		--WITH COURSE AND WITH YEAR LEVEL (BY YEAR)
												FROM
													ums.school_fee_information AS sfi
												INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
												INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
												INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
												INNER JOIN 
												( 
													SELECT	
														sel.sysid_enrolmentcourse AS sysid_enrolmentcourse,
														MAX(sel.enrolment_level_no)	AS enrolment_level_no	
													FROM
														ums.student_enrolment_level AS sel
													INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
													INNER JOIN ums.special_class_load AS scl ON scl.sysid_student = sec.sysid_student	
													INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
													INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
													INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id				
													INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
													INNER JOIN ums.school_year AS sy ON sy.year_id = sfi.year_id	
													WHERE
														(scl.load_id = @load_id) AND
														(NOT sel.sysid_enrolmentlevel IS NULL) AND
														(sel.is_marked_deleted = 0) AND
														(NOT sec.course_id IS NULL) AND
														(sec.is_current_course = 1) AND --only the current course can be inserted with a special class
														((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)) AND
														(cg.is_semestral = 0)
													GROUP BY
														sel.sysid_enrolmentcourse
												) AS sel_max ON sel_max.sysid_enrolmentcourse = sec.sysid_enrolmentcourse AND sel_max.enrolment_level_no = sel.enrolment_level_no
												UNION ALL
												SELECT
													sel.sysid_semester AS year_semester_id		--WITH COURSE AND WITH YEAR LEVEL (BY SEMESTER)
												FROM
													ums.student_enrolment_level AS sel
												INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
												INNER JOIN 
												( 
													SELECT
														sel.sysid_enrolmentcourse AS sysid_enrolmentcourse,
														MAX(sel.enrolment_level_no)	AS enrolment_level_no
													FROM
														ums.student_enrolment_level AS sel
													INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse														
													INNER JOIN ums.special_class_load AS scl ON scl.sysid_student = sec.sysid_student													
													INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
													INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
													INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id				
													INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sel.sysid_semester
													WHERE
														(scl.load_id = @load_id) AND
														(sel.is_marked_deleted = 0) AND
														(NOT sel.sysid_enrolmentlevel IS NULL) AND
														(NOT sec.course_id IS NULL) AND
														(sec.is_current_course = 1) AND --only the current course can be inserted with a special class
														(NOT sel.sysid_semester IS NULL AND NOT sel.sysid_semester = '') AND
														((@date_start BETWEEN sri.date_start AND sri.date_end) AND (@date_end BETWEEN sri.date_start AND sri.date_end)) AND
														(cg.is_semestral = 1)
													GROUP BY
														sel.sysid_enrolmentcourse
												) AS sel_max ON sel_max.sysid_enrolmentcourse = sec.sysid_enrolmentcourse AND sel_max.enrolment_level_no = sel.enrolment_level_no)) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.special_class_load SET
			is_premature_deloaded = @is_premature_deloaded,

			edited_by = @edited_by
		WHERE 
			load_id = @load_id
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update a special class load', 'Special Class Load'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateSpecialClassLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteSpecialClassLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteSpecialClassLoad')
   DROP PROCEDURE ums.DeleteSpecialClassLoad
GO

CREATE PROCEDURE ums.DeleteSpecialClassLoad

	@load_id bigint,

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	DECLARE @date_start datetime
	DECLARE @date_end datetime

	SELECT @date_start = CASE WHEN ((cg.is_semestral = 0) AND (NOT sci.year_id IS NULL AND NOT sci.year_id = ''))
							THEN
								(sy.date_start)
							WHEN ((cg.is_semestral = 1) AND (NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))
							THEN
								(sri.date_start)
							ELSE
								NULL
							END
						FROM
							ums.course_group AS cg
						INNER JOIN ums.subject_information AS si ON si.course_group_id = cg.course_group_id
						INNER JOIN ums.special_class_information AS sci ON sci.sysid_subject = si.sysid_subject
						INNER JOIN ums.special_class_load AS scl ON scl.sysid_special = sci.sysid_special
						LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
						LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
						WHERE
							(scl.load_id = @load_id)

	SELECT @date_end = CASE WHEN ((cg.is_semestral = 0) AND (NOT sci.year_id IS NULL AND NOT sci.year_id = ''))
							THEN
								(sy.date_end)
							WHEN ((cg.is_semestral = 1) AND (NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))
							THEN
								(sri.date_end)
							ELSE
								NULL
							END
						FROM
							ums.course_group AS cg
						INNER JOIN ums.subject_information AS si ON si.course_group_id = cg.course_group_id
						INNER JOIN ums.special_class_information AS sci ON sci.sysid_subject = si.sysid_subject
						INNER JOIN ums.special_class_load AS scl ON scl.sysid_special = sci.sysid_special
						LEFT JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
						LEFT JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
						WHERE
							(scl.load_id = @load_id)

	IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@deleted_by) = 1)) AND 
			(ums.IsPrematureDeloadedSpecialClassLoad(@load_id) = 0) AND
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.special_class_load AS scl
												INNER JOIN ums.special_class_information AS sci ON sci.sysid_special = scl.sysid_special
												WHERE 
													scl.load_id = @load_id AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.special_class_load AS scl
												INNER JOIN ums.special_class_information AS sci ON sci.sysid_special = scl.sysid_special
												WHERE 
													scl.load_id = @load_id AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0) AND
			(ums.IsRecordLockByYearSemesterID((SELECT
													sfi.year_id AS year_semester_id		--WITH COURSE AND WITH YEAR LEVEL (BY YEAR)
												FROM
													ums.school_fee_information AS sfi
												INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
												INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
												INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
												INNER JOIN 
												( 
													SELECT	
														sel.sysid_enrolmentcourse AS sysid_enrolmentcourse,
														MAX(sel.enrolment_level_no)	AS enrolment_level_no	
													FROM
														ums.student_enrolment_level AS sel
													INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
													INNER JOIN ums.special_class_load AS scl ON scl.sysid_student = sec.sysid_student	
													INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
													INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
													INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id				
													INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
													INNER JOIN ums.school_year AS sy ON sy.year_id = sfi.year_id	
													WHERE
														(scl.load_id = @load_id) AND
														(NOT sel.sysid_enrolmentlevel IS NULL) AND
														(sel.is_marked_deleted = 0) AND
														(NOT sec.course_id IS NULL) AND
														(sec.is_current_course = 1) AND --only the current course can be inserted with a special class
														((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)) AND
														(cg.is_semestral = 0)
													GROUP BY
														sel.sysid_enrolmentcourse
												) AS sel_max ON sel_max.sysid_enrolmentcourse = sec.sysid_enrolmentcourse AND sel_max.enrolment_level_no = sel.enrolment_level_no
												UNION ALL
												SELECT
													sel.sysid_semester AS year_semester_id		--WITH COURSE AND WITH YEAR LEVEL (BY SEMESTER)
												FROM
													ums.student_enrolment_level AS sel
												INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
												INNER JOIN 
												( 
													SELECT
														sel.sysid_enrolmentcourse AS sysid_enrolmentcourse,
														MAX(sel.enrolment_level_no)	AS enrolment_level_no
													FROM
														ums.student_enrolment_level AS sel
													INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse														
													INNER JOIN ums.special_class_load AS scl ON scl.sysid_student = sec.sysid_student													
													INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
													INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
													INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id				
													INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sel.sysid_semester
													WHERE
														(scl.load_id = @load_id) AND
														(sel.is_marked_deleted = 0) AND
														(NOT sel.sysid_enrolmentlevel IS NULL) AND
														(NOT sec.course_id IS NULL) AND
														(sec.is_current_course = 1) AND --only the current course can be inserted with a special class
														(NOT sel.sysid_semester IS NULL AND NOT sel.sysid_semester = '') AND
														((@date_start BETWEEN sri.date_start AND sri.date_end) AND (@date_end BETWEEN sri.date_start AND sri.date_end)) AND
														(cg.is_semestral = 1)
													GROUP BY
														sel.sysid_enrolmentcourse
												) AS sel_max ON sel_max.sysid_enrolmentcourse = sec.sysid_enrolmentcourse AND sel_max.enrolment_level_no = sel.enrolment_level_no)) = 0)
	BEGIN

		IF EXISTS (SELECT load_id FROM ums.special_class_load WHERE load_id = @load_id)
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.special_class_load SET
				edited_by = @deleted_by
			WHERE 
				load_id = @load_id

			DELETE FROM ums.special_class_load WHERE load_id = @load_id

		END
		
	END
	ELSE IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR 
			(((ums.IsCashierSystemUserInfo(@deleted_by) = 1) OR 
			(ums.IsVpOfFinanceSystemUserInfo(@deleted_by) = 1)) AND
			(ums.IsRecordLockByYearSemesterID((SELECT 
													sci.year_id AS year_semester_id
												FROM 
													ums.special_class_load AS scl
												INNER JOIN ums.special_class_information AS sci ON sci.sysid_special = scl.sysid_special
												WHERE 
													scl.load_id = @load_id AND
													(NOT sci.year_id IS NULL AND NOT sci.year_id = '')
												UNION
												SELECT 
													sci.sysid_semester AS year_semester_id
												FROM 
													ums.special_class_load AS scl
												INNER JOIN ums.special_class_information AS sci ON sci.sysid_special = scl.sysid_special
												WHERE 
													scl.load_id = @load_id AND
													(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = ''))) = 0) AND
			(ums.IsRecordLockByYearSemesterID((SELECT
													sfi.year_id AS year_semester_id		--WITH COURSE AND WITH YEAR LEVEL (BY YEAR)
												FROM
													ums.school_fee_information AS sfi
												INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_schoolfee = sfi.sysid_schoolfee
												INNER JOIN ums.student_enrolment_level AS sel ON sel.sysid_feelevel = sfl.sysid_feelevel
												INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
												INNER JOIN 
												( 
													SELECT	
														sel.sysid_enrolmentcourse AS sysid_enrolmentcourse,
														MAX(sel.enrolment_level_no)	AS enrolment_level_no	
													FROM
														ums.student_enrolment_level AS sel
													INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
													INNER JOIN ums.special_class_load AS scl ON scl.sysid_student = sec.sysid_student	
													INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
													INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
													INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id				
													INNER JOIN ums.school_fee_information AS sfi ON sfi.sysid_schoolfee = sfl.sysid_schoolfee
													INNER JOIN ums.school_year AS sy ON sy.year_id = sfi.year_id	
													WHERE
														(scl.load_id = @load_id) AND
														(NOT sel.sysid_enrolmentlevel IS NULL) AND
														(sel.is_marked_deleted = 0) AND
														(NOT sec.course_id IS NULL) AND
														(sec.is_current_course = 1) AND --only the current course can be inserted with a special class
														((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)) AND
														(cg.is_semestral = 0)
													GROUP BY
														sel.sysid_enrolmentcourse
												) AS sel_max ON sel_max.sysid_enrolmentcourse = sec.sysid_enrolmentcourse AND sel_max.enrolment_level_no = sel.enrolment_level_no
												UNION ALL
												SELECT
													sel.sysid_semester AS year_semester_id		--WITH COURSE AND WITH YEAR LEVEL (BY SEMESTER)
												FROM
													ums.student_enrolment_level AS sel
												INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse
												INNER JOIN 
												( 
													SELECT
														sel.sysid_enrolmentcourse AS sysid_enrolmentcourse,
														MAX(sel.enrolment_level_no)	AS enrolment_level_no
													FROM
														ums.student_enrolment_level AS sel
													INNER JOIN ums.student_enrolment_course AS sec ON sec.sysid_enrolmentcourse = sel.sysid_enrolmentcourse														
													INNER JOIN ums.special_class_load AS scl ON scl.sysid_student = sec.sysid_student													
													INNER JOIN ums.school_fee_level AS sfl ON sfl.sysid_feelevel = sel.sysid_feelevel
													INNER JOIN ums.year_level_information AS yli ON yli.year_level_id = sfl.year_level_id
													INNER JOIN ums.course_group AS cg ON cg.course_group_id = yli.course_group_id				
													INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sel.sysid_semester
													WHERE
														(scl.load_id = @load_id) AND
														(sel.is_marked_deleted = 0) AND
														(NOT sel.sysid_enrolmentlevel IS NULL) AND
														(NOT sec.course_id IS NULL) AND
														(sec.is_current_course = 1) AND --only the current course can be inserted with a special class
														(NOT sel.sysid_semester IS NULL AND NOT sel.sysid_semester = '') AND
														((@date_start BETWEEN sri.date_start AND sri.date_end) AND (@date_end BETWEEN sri.date_start AND sri.date_end)) AND
														(cg.is_semestral = 1)
													GROUP BY
														sel.sysid_enrolmentcourse
												) AS sel_max ON sel_max.sysid_enrolmentcourse = sec.sysid_enrolmentcourse AND sel_max.enrolment_level_no = sel.enrolment_level_no)) = 0))) AND 
			(ums.IsPrematureDeloadedSpecialClassLoad(@load_id) = 1) 
	BEGIN

		IF EXISTS (SELECT load_id FROM ums.special_class_load WHERE load_id = @load_id)
		BEGIN

			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.special_class_load SET
				is_for_permanent_delete = 1,
				edited_by = @deleted_by
			WHERE 
				load_id = @load_id

			DELETE FROM ums.special_class_load WHERE load_id = @load_id

		END
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Deleted a special class load', 'Special Class Load'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteSpecialClassLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectByDateStartEndSpecialClassLoad" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectByDateStartEndSpecialClassLoad')
   DROP PROCEDURE ums.SelectByDateStartEndSpecialClassLoad
GO

CREATE PROCEDURE ums.SelectByDateStartEndSpecialClassLoad

	@date_start datetime,
	@date_end datetime,

	@system_user_id varchar (50) = ''	
		
AS

	IF (ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsPayrollMasterSystemUserInfo(@system_user_id) = 1)
	BEGIN

		SELECT
			scl.load_id AS load_id,
			scl.sysid_special AS sysid_special,
			scl.sysid_student AS sysid_student,
			scl.load_date AS load_date,
			scl.deload_date AS deload_date,
			sci.sysid_employee AS sysid_employee,
			sci.amount AS amount,
			sy.date_end AS date_end
		FROM 
			ums.special_class_load AS scl
		INNER JOIN ums.special_class_information AS sci ON sci.sysid_special = scl.sysid_special
		INNER JOIN ums.school_year AS sy ON sy.year_id = sci.year_id
		WHERE
			(NOT sci.year_id IS NULL AND NOT sci.year_id = '') AND
			(((@date_start BETWEEN sy.date_start AND sy.date_end) OR (@date_end BETWEEN sy.date_start AND sy.date_end)) OR
			((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end)))
		UNION ALL
		SELECT
			scl.load_id AS load_id,
			scl.sysid_special AS sysid_special,
			scl.sysid_student AS sysid_student,
			scl.load_date AS load_date,
			scl.deload_date AS deload_date,
			sci.sysid_employee AS sysid_employee,
			sci.amount AS amount,
			sri.date_end AS date_end
		FROM 
			ums.special_class_load AS scl
		INNER JOIN ums.special_class_information AS sci ON sci.sysid_special = scl.sysid_special
		INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = sci.sysid_semester
		WHERE
			(NOT sci.sysid_semester IS NULL AND NOT sci.sysid_semester = '') AND
			(((@date_start BETWEEN sri.date_start AND sri.date_end) OR (@date_end BETWEEN sri.date_start AND sri.date_end)) OR
			((sri.date_start BETWEEN @date_start AND @date_end) AND (sri.date_end BETWEEN @date_start AND @date_end)))
		
	END	
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a special class load', 'Special Class Load'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectByDateStartEndSpecialClassLoad TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsSpecialClassInformationAlreadyLoadedStudent" function already exist
IF OBJECT_ID (N'ums.IsSpecialClassInformationAlreadyLoadedStudent') IS NOT NULL
   DROP FUNCTION ums.IsSpecialClassInformationAlreadyLoadedStudent
GO

CREATE FUNCTION ums.IsSpecialClassInformationAlreadyLoadedStudent
(	
	@sysid_special varchar (50) = '',
	@sysid_student varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit
	
	SET @result = 0

	IF EXISTS (SELECT 
					scl.load_id AS load_id
				FROM
					ums.special_class_load AS scl				
				WHERE
					(scl.sysid_special = @sysid_special) AND
					(scl.sysid_student = @sysid_student))
			
				
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsPrematureDeloadedSpecialClassLoad" function already exist
IF OBJECT_ID (N'ums.IsPrematureDeloadedSpecialClassLoad') IS NOT NULL
   DROP FUNCTION ums.IsPrematureDeloadedSpecialClassLoad
GO

CREATE FUNCTION ums.IsPrematureDeloadedSpecialClassLoad
(	
	@load_id bigint = 0
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF EXISTS (SELECT load_id FROM ums.special_class_load WHERE load_id = @load_id AND is_premature_deloaded = 1)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- ################################################END TABLE "special_class_load" OBJECTS######################################################




-- ################################################TABLE "major_exam_information" OBJECTS######################################################
-- verifies if the major_exam_information table exists
IF OBJECT_ID('ums.major_exam_information', 'U') IS NOT NULL
	DROP TABLE ums.major_exam_information
GO

CREATE TABLE ums.major_exam_information 			
(
	exam_information_id varchar (50) NOT NULL 
		CONSTRAINT Major_Exam_Information_Exam_Information_ID_PK PRIMARY KEY (exam_information_id)
		CONSTRAINT Major_Exam_Information_Exam_Information_ID_CK CHECK (exam_information_id LIKE 'EXAM%'),
	course_group_id varchar (50) NOT NULL
		CONSTRAINT Major_Exam_Information_Course_Group_ID_FK FOREIGN KEY REFERENCES ums.course_group(course_group_id) ON UPDATE NO ACTION
		CONSTRAINT Major_Exam_Information_Course_Group_ID_UQ UNIQUE (course_group_id, exam_description),
	exam_description varchar (100) NOT NULL
		CONSTRAINT Major_Exam_Information_Exam_Description_UQ UNIQUE (exam_description, course_group_id),

	is_clearance_included bit NOT NULL DEFAULT (0),
	is_one_instance bit NOT NULL DEFAULT (0),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Major_Exam_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- verifies that the trigger "Major_Exam_Information_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Major_Exam_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Major_Exam_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Major_Exam_Information_Trigger_Instead_Update
	ON  ums.major_exam_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a major exam information', 'Major Exam Information'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Major_Exam_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Major_Exam_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Major_Exam_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Major_Exam_Information_Trigger_Instead_Delete
	ON  ums.major_exam_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a major exam information', 'Major Exam Information'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectMajorExamInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectMajorExamInformation')
   DROP PROCEDURE ums.SelectMajorExamInformation
GO

CREATE PROCEDURE ums.SelectMajorExamInformation
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			mei.exam_information_id AS exam_information_id,
			mei.course_group_id AS course_group_id,
			mei.exam_description AS exam_description,
			mei.is_clearance_included AS is_clearance_included,
			mei.is_one_instance AS is_one_instance,
			cg.group_no AS group_no,
			cg.group_description AS group_description,
			cg.is_semestral AS is_semestral
		FROM
			ums.major_exam_information AS mei
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
		ORDER BY 
			group_no, exam_description ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a major exam information', 'Major Exam Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectMajorExamInformation TO db_umsusers
GO
-------------------------------------------------------------

-- ################################################END TABLE "major_exam_information" OBJECTS###################################################






-- ################################################TABLE "major_exam_schedule" OBJECTS######################################################
-- verifies if the major_exam_schedule table exists
IF OBJECT_ID('ums.major_exam_schedule', 'U') IS NOT NULL
	DROP TABLE ums.major_exam_schedule
GO

CREATE TABLE ums.major_exam_schedule 			
(
	major_exam_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Major_Exam_Schedule_Major_Exam_ID_PK PRIMARY KEY (major_exam_id),
	year_id varchar (50) NULL
		CONSTRAINT Major_Exam_Schedule_Year_ID_FK FOREIGN KEY REFERENCES ums.school_year(year_id) ON UPDATE NO ACTION
		CONSTRAINT Major_Exam_Schedule_Year_ID_UQ UNIQUE (year_id, sysid_semester, exam_information_id, exam_date),
	sysid_semester varchar (50) NULL 
		CONSTRAINT Major_Exam_Schedule_SysID_Semester_FK FOREIGN KEY REFERENCES ums.semester_information(sysid_semester) ON UPDATE NO ACTION
		CONSTRAINT Major_Exam_Schedule_SysID_Semester_UQ UNIQUE (sysid_semester, year_id, exam_information_id, exam_date),
	exam_information_id varchar (50) NOT NULL
		CONSTRAINT Major_Exam_Schedule_Exam_Information_ID_FK FOREIGN KEY REFERENCES ums.major_exam_information(exam_information_id) ON UPDATE NO ACTION
		CONSTRAINT Major_Exam_Schedule_Exam_Information_ID_UQ UNIQUE (exam_information_id, year_id, sysid_semester, exam_date),

	exam_date datetime NOT NULL
		CONSTRAINT Major_Exam_Schedule_Exam_Date_CK CHECK (CONVERT(varchar, exam_date, 109) LIKE '%12:00:00:000AM')
		CONSTRAINT Major_Exam_Schedule_Exam_Date_UQ UNIQUE (exam_date, year_id, sysid_semester, exam_information_id),
	
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Major_Exam_Schedule_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Major_Exam_Schedule_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Major_Exam_Schedule_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the major_exam_schedule table 
CREATE INDEX Major_Exam_Schedule_Major_Exam_ID_Index
	ON ums.major_exam_schedule (major_exam_id DESC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Major_Exam_Schedule_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.Major_Exam_Schedule_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Major_Exam_Schedule_Trigger_Insert
GO

CREATE TRIGGER ums.Major_Exam_Schedule_Trigger_Insert
	ON  ums.major_exam_schedule
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @major_exam_id bigint
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @exam_information_id varchar (50)
	DECLARE @exam_date datetime
	DECLARE @is_semestral bit
	DECLARE @created_by varchar (50)

	DECLARE @year_semester_description varchar (100)
	
	SELECT 
		@major_exam_id = i.major_exam_id,
		@year_id = i.year_id,
		@sysid_semester = i.sysid_semester,
		@exam_information_id = i.exam_information_id,
		@exam_date = i.exam_date,
		@is_semestral = cg.is_semestral,
		@created_by = i.created_by
	FROM INSERTED AS i
	INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = i.exam_information_id
	INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id

	SET @year_semester_description = ''

	IF (@is_semestral = 0) AND (NOT @year_id IS NULL AND NOT @year_id = '')
	BEGIN
		SELECT @year_semester_description = year_description FROM ums.school_year WHERE year_id = @year_id
	END
	ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL AND NOT @sysid_semester = '')
	BEGIN
		SELECT @year_semester_description = sy.year_description + ' - ' + ss.semester_description
		FROM 
			ums.semester_information AS si
		INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
		INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
		WHERE 
			si.sysid_semester = @sysid_semester
	END

	SET @transaction_done = 'CREATED a new major exam schedule ' + 
							'[Schedule ID: ' + ISNULL(CONVERT(varchar, @major_exam_id), '') +
							'][Exam Description: ' + ISNULL((SELECT
																	mei.exam_description + ' (' + cg.group_description + ')'
																FROM
																	ums.major_exam_information AS mei
																INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
																WHERE
																	mei.exam_information_id = @exam_information_id), '') + 
							'][School Year / Semester: ' + ISNULL(@year_semester_description, '') +
							'][Exam Date: ' + ISNULL(CONVERT(varchar, @exam_date, 101), '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Major_Exam_Schedule_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Major_Exam_Schedule_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Major_Exam_Schedule_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Major_Exam_Schedule_Trigger_Instead_Update
	ON  ums.major_exam_schedule
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @major_exam_id bigint
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @exam_information_id varchar (50)
	DECLARE @exam_date datetime
	DECLARE @is_semestral bit
	DECLARE @edited_by varchar (50)

	DECLARE @year_id_b varchar (50)
	DECLARE @sysid_semester_b varchar (50)
	DECLARE @exam_information_id_b varchar (50)
	DECLARE @exam_date_b datetime
	DECLARE @is_semestral_b bit

	DECLARE @has_update bit
	
	SELECT 
		@major_exam_id = i.major_exam_id,
		@year_id = i.year_id,
		@sysid_semester = i.sysid_semester,
		@exam_information_id = i.exam_information_id,
		@exam_date = i.exam_date,
		@is_semestral = cg.is_semestral,
		@edited_by = i.edited_by
	FROM INSERTED AS i
	INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = i.exam_information_id
	INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id

	SELECT
		@year_id_b = mes.year_id,
		@sysid_semester_b = mes.sysid_semester,
		@exam_information_id_b = mes.exam_information_id,
		@exam_date_b = mes.exam_date,
		@is_semestral_b = cg.is_semestral
	FROM
		ums.major_exam_schedule AS mes
	INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = mes.exam_information_id
	INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
	WHERE
		mes.major_exam_id = @major_exam_id
	
	SET @transaction_done = ''
	SET @has_update = 0

	IF NOT ISNULL(@exam_information_id, '') = ISNULL(@exam_information_id_b, '')
	BEGIN
		SET @transaction_done = @transaction_done + '[Exam Description Before: ' + ISNULL((SELECT
																	mei.exam_description + ' (' + cg.group_description + ')'
																FROM
																	ums.major_exam_information AS mei
																INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
																WHERE
																	mei.exam_information_id = @exam_information_id_b), '') + ']' +
													'[Exam Description After: ' + ISNULL((SELECT
																	mei.exam_description + ' (' + cg.group_description + ')'
																FROM
																	ums.major_exam_information AS mei
																INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
																WHERE
																	mei.exam_information_id = @exam_information_id), '') + ']'
		SET @has_update = 1
	END
	ELSE
	BEGIN
		SET @transaction_done = @transaction_done + '[Exam Description: ' + ISNULL((SELECT
																	mei.exam_description + ' (' + cg.group_description + ')'
																FROM
																	ums.major_exam_information AS mei
																INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
																WHERE
																	mei.exam_information_id = @exam_information_id), '') + ']'
	END

	IF (NOT @is_semestral = @is_semestral_b) OR (NOT ISNULL(@year_id_b, '') = ISNULL(@year_id, '')) OR
					(NOT ISNULL(@sysid_semester_b, '') = ISNULL(@sysid_semester, ''))
	BEGIN

		DECLARE @year_semester_description varchar (100)
		DECLARE @year_semester_description_b varchar (100)

		SET @year_semester_description = ''
		SET @year_semester_description_b = ''

		IF (@is_semestral_b = 0) AND (NOT @year_id_b IS NULL AND NOT @year_id_b = '')
		BEGIN
			SELECT @year_semester_description_b = year_description FROM ums.school_year WHERE year_id = @year_id_b
		END
		ELSE IF (@is_semestral_b = 1) AND (NOT @sysid_semester_b IS NULL AND NOT @sysid_semester_b = '')
		BEGIN
			SELECT @year_semester_description_b = sy.year_description + ' - ' + ss.semester_description
			FROM 
				ums.semester_information AS si
			INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
			INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
			WHERE 
				si.sysid_semester = @sysid_semester_b
		END

		IF (@is_semestral = 0) AND (NOT @year_id IS NULL AND NOT @year_id = '')
		BEGIN
			SELECT @year_semester_description = year_description FROM ums.school_year WHERE year_id = @year_id
		END
		ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL AND NOT @sysid_semester = '')
		BEGIN
			SELECT @year_semester_description = sy.year_description + ' - ' + ss.semester_description
			FROM 
				ums.semester_information AS si
			INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
			INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
			WHERE 
				si.sysid_semester = @sysid_semester
		END

		SET @transaction_done = @transaction_done + '[School Year / Semester Before: ' + ISNULL(@year_semester_description_b, '') + ']' +
													'[School Year / Semester After: ' + ISNULL(@year_semester_description, '') + ']'
		SET @has_update = 1

	END

	IF NOT ISNULL(CONVERT(varchar, @exam_date, 101), '') = ISNULL(CONVERT(varchar, @exam_date_b, 101), '')
		BEGIN
			SET @transaction_done = @transaction_done + '[Exam Date Before: ' + ISNULL(CONVERT(varchar, @exam_date_b, 101), '') + ']' +
														'[Exam Date After: ' + ISNULL(CONVERT(varchar, @exam_date, 101), '') + ']'
			SET @has_update = 1
		END
	
	IF @has_update = 1
	BEGIN

		UPDATE ums.major_exam_schedule SET
			year_id = @year_id,
			sysid_semester = @sysid_semester,
			exam_information_id = @exam_information_id,
			exam_date = @exam_date,
			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			major_exam_id = @major_exam_id

		SET @transaction_done = 'UPDATED a major exam schedule ' + 
								'[Schedule ID: ' + ISNULL(CONVERT(varchar, @major_exam_id), '') + ']' + @transaction_done

		IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
		BEGIN
			SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
		END
				
		EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done	


	END	
	ELSE IF NOT @edited_by IS NULL
	BEGIN

		--used for the delete trigger
		UPDATE ums.major_exam_schedule SET
			edited_on = GETDATE(),
			edited_by = @edited_by
		WHERE
			major_exam_id = @major_exam_id

	END
	
GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Major_Exam_Schedule_Trigger_Delete" already exist*/
IF OBJECT_ID ('ums.Major_Exam_Schedule_Trigger_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Major_Exam_Schedule_Trigger_Delete
GO

CREATE TRIGGER ums.Major_Exam_Schedule_Trigger_Delete
	ON  ums.major_exam_schedule
	FOR DELETE 
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @major_exam_id bigint
	DECLARE @year_id varchar (50)
	DECLARE @sysid_semester varchar (50)
	DECLARE @exam_information_id varchar (50)
	DECLARE @exam_date datetime
	DECLARE @is_semestral bit
	DECLARE @deleted_by varchar (50)

	DECLARE @year_semester_description varchar (100)
	
	SELECT 
		@major_exam_id = d.major_exam_id,
		@year_id = d.year_id,
		@sysid_semester = d.sysid_semester,
		@exam_information_id = d.exam_information_id,
		@exam_date = d.exam_date,
		@is_semestral = cg.is_semestral,
		@deleted_by = d.edited_by
	FROM DELETED AS d
	INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = d.exam_information_id
	INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id

	SET @year_semester_description = ''

	IF (@is_semestral = 0) AND (NOT @year_id IS NULL AND NOT @year_id = '')
	BEGIN
		SELECT @year_semester_description = year_description FROM ums.school_year WHERE year_id = @year_id
	END
	ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL AND NOT @sysid_semester = '')
	BEGIN
		SELECT @year_semester_description = sy.year_description + ' - ' + ss.semester_description
		FROM 
			ums.semester_information AS si
		INNER JOIN ums.school_year AS sy ON sy.year_id = si.year_id
		INNER JOIN ums.school_semester AS ss ON ss.semester_id = si.semester_id
		WHERE 
			si.sysid_semester = @sysid_semester
	END

	SET @transaction_done = 'DELETED a major exam schedule ' + 
							'[Schedule ID: ' + ISNULL(CONVERT(varchar, @major_exam_id), '') +
							'][Exam Description: ' + ISNULL((SELECT
																	mei.exam_description + ' (' + cg.group_description + ')'
																FROM
																	ums.major_exam_information AS mei
																INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
																WHERE
																	mei.exam_information_id = @exam_information_id), '') + 
							'][School Year / Semester: ' + ISNULL(@year_semester_description, '') +
							'][Exam Date: ' + ISNULL(CONVERT(varchar, @exam_date, 101), '') +
							']'


	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @deleted_by
	END
			
	EXECUTE ums.InsertTransactionLog @deleted_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

-- verifies if the procedure "InsertMajorExamSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertMajorExamSchedule')
   DROP PROCEDURE ums.InsertMajorExamSchedule
GO

CREATE PROCEDURE ums.InsertMajorExamSchedule

	@year_id varchar (50) = '',
	@sysid_semester varchar (50) = '',
	@exam_information_id varchar (50) = '',
	@exam_date datetime,

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@created_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@created_by) = 1)) AND 
			(ums.IsRecordLockByYearSemesterID(@year_id) = 0 AND ums.IsRecordLockByYearSemesterID(@sysid_semester) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		DECLARE @is_semestral bit

		SET @is_semestral = 0

		SELECT 
			@is_semestral = cg.is_semestral 
		FROM 
			ums.major_exam_information AS mei
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
		WHERE
			mei.exam_information_id = @exam_information_id

		IF (@is_semestral = 0) AND (NOT @year_id IS NULL AND NOT @year_id = '') AND
			(@exam_date BETWEEN (SELECT
										date_start
									FROM
										ums.school_year
									WHERE
										year_id = @year_id) AND 
								(SELECT
										date_end
									FROM
										ums.school_year
									WHERE
										year_id = @year_id))
		BEGIN

			INSERT INTO ums.major_exam_schedule
			(
				year_id,
				sysid_semester,
				exam_information_id,
				exam_date,
				created_by
			)
			VALUES
			(
				@year_id,
				NULL,
				@exam_information_id,
				@exam_date,
				@created_by
			)

		END
		ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL AND NOT @sysid_semester = '') AND
			(@exam_date BETWEEN (SELECT
										date_start
									FROM
										ums.semester_information
									WHERE
										sysid_semester = @sysid_semester) AND 
								(SELECT
										date_end
									FROM
										ums.semester_information
									WHERE
										sysid_semester = @sysid_semester))	
		BEGIN

			INSERT INTO ums.major_exam_schedule
			(
				year_id,
				sysid_semester,
				exam_information_id,
				exam_date,
				created_by
			)
			VALUES
			(
				NULL,
				@sysid_semester,
				@exam_information_id,
				@exam_date,
				@created_by
			)

		END	
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Create a new major exam schedule', 'Major Exam Schedule'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertMajorExamSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateMajorExamSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateMajorExamSchedule')
   DROP PROCEDURE ums.UpdateMajorExamSchedule
GO

CREATE PROCEDURE ums.UpdateMajorExamSchedule

	@major_exam_id bigint = 0,
	@year_id varchar (50) = '',
	@sysid_semester varchar (50) = '',
	@exam_information_id varchar (50) = '',
	@exam_date datetime,

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@edited_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@edited_by) = 1)) AND 
			(ums.IsRecordLockByYearSemesterID(@year_id) = 0 AND ums.IsRecordLockByYearSemesterID(@sysid_semester) = 0)
	BEGIN

		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		DECLARE @is_semestral bit

		SET @is_semestral = 0

		SELECT 
			@is_semestral = cg.is_semestral 
		FROM 
			ums.major_exam_information AS mei
		INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
		WHERE
			mei.exam_information_id = @exam_information_id

		IF (@is_semestral = 0) AND (NOT @year_id IS NULL AND NOT @year_id = '') AND
			(@exam_date BETWEEN (SELECT
										date_start
									FROM
										ums.school_year
									WHERE
										year_id = @year_id) AND 
								(SELECT
										date_end
									FROM
										ums.school_year
									WHERE
										year_id = @year_id))
		BEGIN

			UPDATE ums.major_exam_schedule SET
				year_id = @year_id,
				sysid_semester = NULL,
				exam_information_id = @exam_information_id,
				exam_date = @exam_date,
				edited_by = @edited_by
			WHERE
				major_exam_id = @major_exam_id

		END
		ELSE IF (@is_semestral = 1) AND (NOT @sysid_semester IS NULL AND NOT @sysid_semester = '') AND
			(@exam_date BETWEEN (SELECT
										date_start
									FROM
										ums.semester_information
									WHERE
										sysid_semester = @sysid_semester) AND 
								(SELECT
										date_end
									FROM
										ums.semester_information
									WHERE
										sysid_semester = @sysid_semester))	
		BEGIN

			UPDATE ums.major_exam_schedule SET
				year_id = NULL,
				sysid_semester = @sysid_semester,
				exam_information_id = @exam_information_id,
				exam_date = @exam_date,
				edited_by = @edited_by
			WHERE
				major_exam_id = @major_exam_id

		END	
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update a major exam schedule', 'Major Exam Schedule'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateMajorExamSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "DeleteMajorExamSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'DeleteMajorExamSchedule')
   DROP PROCEDURE ums.DeleteMajorExamSchedule
GO

CREATE PROCEDURE ums.DeleteMajorExamSchedule

	@major_exam_id bigint = 0,

	@network_information varchar (MAX) = '',
	@deleted_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@deleted_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@deleted_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@deleted_by) = 1)) AND 
			(ums.IsRecordLockByYearSemesterID((SELECT
													mes.year_id AS year_semester_id
												FROM
													ums.major_exam_schedule AS mes
												WHERE
													(mes.major_exam_id = @major_exam_id) AND
													(NOT mes.year_id IS NULL AND NOT mes.year_id = '')
												UNION
												SELECT
													mes.sysid_semester AS year_semester_id
												FROM
													ums.major_exam_schedule AS mes
												WHERE
													(mes.major_exam_id = @major_exam_id) AND
													(NOT mes.sysid_semester IS NULL AND NOT mes.sysid_semester = ''))) = 0)
	BEGIN

		IF (EXISTS (SELECT major_exam_id FROM ums.major_exam_schedule WHERE major_exam_id = @major_exam_id))
		BEGIN
		
			EXECUTE ums.CreateTemporaryTable @deleted_by, @network_information

			UPDATE ums.major_exam_schedule SET
				edited_by = @deleted_by
			WHERE
				major_exam_id = @major_exam_id

			DELETE FROM ums.major_exam_schedule WHERE major_exam_id = @major_exam_id

		END
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Delete a major exam schedule', 'Major Exam Schedule'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.DeleteMajorExamSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectMajorExamSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectMajorExamSchedule')
   DROP PROCEDURE ums.SelectMajorExamSchedule
GO

CREATE PROCEDURE ums.SelectMajorExamSchedule

	@date_start datetime,
	@date_end datetime,
	@course_group_id_list nvarchar (MAX) = '',
	@exam_information_id_list nvarchar (MAX) = '',

	@system_user_id varchar (50) = ''
		
AS	
	

	IF (ums.IsActiveSystemUserInfo(@system_user_id) = 1)
	BEGIN

		--	A - course_group_id
		--	B - exam_information_id

		--	A	B
		--	=====
		--	0	0
		--	0	1
		--	1	0
		--	1	1

		IF ((NOT @date_start IS NULL) AND (NOT @date_end IS NULL)) AND (ISNULL(@course_group_id_list, '') = '') AND		-- (00)
			(ISNULL(@exam_information_id_list, '') = '')
		BEGIN

			SELECT
				mes.major_exam_id AS major_exam_id,
				mes.year_id AS year_id,
				mes.sysid_semester AS sysid_semester,
				mes.exam_information_id AS exam_information_id,
				mes.exam_date AS exam_date,
				mei.exam_description AS exam_description,
				mei.is_clearance_included AS is_clearance_included,
				mei.course_group_id AS course_group_id,
				cg.group_description AS group_description,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral
			FROM
				ums.major_exam_schedule AS mes
			INNER JOIN ums.school_year AS sy ON sy.year_id = mes.year_id
			INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = mes.exam_information_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
			WHERE
				(NOT mes.year_id IS NULL AND NOT mes.year_id = '') AND
				(cg.is_semestral = 0) AND
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))
			UNION ALL
			SELECT
				mes.major_exam_id AS major_exam_id,
				sy.year_id AS year_id,
				mes.sysid_semester AS sysid_semester,
				mes.exam_information_id AS exam_information_id,
				mes.exam_date AS exam_date,
				mei.exam_description AS exam_description,
				mei.is_clearance_included AS is_clearance_included,
				mei.course_group_id AS course_group_id,
				cg.group_description AS group_description,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral
			FROM
				ums.major_exam_schedule AS mes
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = mes.sysid_semester
			INNER JOIN ums.school_year AS sy ON sy.year_id = sri.year_id			
			INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = mes.exam_information_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
			WHERE
				(NOT mes.sysid_semester IS NULL AND NOT mes.sysid_semester = '') AND
				(cg.is_semestral = 1) AND
				((@date_start BETWEEN sri.date_start AND sri.date_end) AND (@date_end BETWEEN sri.date_start AND sri.date_end))
			ORDER BY
				exam_date, group_no ASC

		END
		ELSE IF ((NOT @date_start IS NULL) AND (NOT @date_end IS NULL)) AND (ISNULL(@course_group_id_list, '') = '') AND		-- (01)
			(NOT ISNULL(@exam_information_id_list, '') = '')
		BEGIN

			SELECT
				mes.major_exam_id AS major_exam_id,
				mes.year_id AS year_id,
				mes.sysid_semester AS sysid_semester,
				mes.exam_information_id AS exam_information_id,
				mes.exam_date AS exam_date,
				mei.exam_description AS exam_description,
				mei.is_clearance_included AS is_clearance_included,
				mei.course_group_id AS course_group_id,
				cg.group_description AS group_description,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral
			FROM
				ums.major_exam_schedule AS mes
			INNER JOIN ums.school_year AS sy ON sy.year_id = mes.year_id
			INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = mes.exam_information_id
			INNER JOIN ums.IterateListToTable (@exam_information_id_list, ',') AS eiil_list ON eiil_list.var_str = mei.exam_information_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
			WHERE
				(NOT mes.year_id IS NULL AND NOT mes.year_id = '') AND
				(cg.is_semestral = 0) AND
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))
			UNION ALL
			SELECT
				mes.major_exam_id AS major_exam_id,
				sy.year_id AS year_id,
				mes.sysid_semester AS sysid_semester,
				mes.exam_information_id AS exam_information_id,
				mes.exam_date AS exam_date,
				mei.exam_description AS exam_description,
				mei.is_clearance_included AS is_clearance_included,
				mei.course_group_id AS course_group_id,
				cg.group_description AS group_description,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral
			FROM
				ums.major_exam_schedule AS mes
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = mes.sysid_semester
			INNER JOIN ums.school_year AS sy ON sy.year_id = sri.year_id						
			INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = mes.exam_information_id
			INNER JOIN ums.IterateListToTable (@exam_information_id_list, ',') AS eiil_list ON eiil_list.var_str = mei.exam_information_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
			WHERE
				(NOT mes.sysid_semester IS NULL AND NOT mes.sysid_semester = '') AND
				(cg.is_semestral = 1) AND
				((@date_start BETWEEN sri.date_start AND sri.date_end) AND (@date_end BETWEEN sri.date_start AND sri.date_end))
			ORDER BY
				exam_date, group_no ASC

		END
		ELSE IF ((NOT @date_start IS NULL) AND (NOT @date_end IS NULL)) AND (NOT ISNULL(@course_group_id_list, '') = '') AND		-- (10)
			(ISNULL(@exam_information_id_list, '') = '')
		BEGIN

			SELECT
				mes.major_exam_id AS major_exam_id,
				mes.year_id AS year_id,
				mes.sysid_semester AS sysid_semester,
				mes.exam_information_id AS exam_information_id,
				mes.exam_date AS exam_date,
				mei.exam_description AS exam_description,
				mei.is_clearance_included AS is_clearance_included,
				mei.course_group_id AS course_group_id,
				cg.group_description AS group_description,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral
			FROM
				ums.major_exam_schedule AS mes
			INNER JOIN ums.school_year AS sy ON sy.year_id = mes.year_id
			INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = mes.exam_information_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
			INNER JOIN ums.IterateListToTable (@course_group_id_list, ',') AS cgil_list ON cgil_list.var_str = cg.course_group_id
			WHERE
				(NOT mes.year_id IS NULL AND NOT mes.year_id = '') AND
				(cg.is_semestral = 0) AND
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))
			UNION ALL
			SELECT
				mes.major_exam_id AS major_exam_id,
				sy.year_id AS year_id,
				mes.sysid_semester AS sysid_semester,
				mes.exam_information_id AS exam_information_id,
				mes.exam_date AS exam_date,
				mei.exam_description AS exam_description,
				mei.is_clearance_included AS is_clearance_included,
				mei.course_group_id AS course_group_id,
				cg.group_description AS group_description,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral
			FROM
				ums.major_exam_schedule AS mes
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = mes.sysid_semester	
			INNER JOIN ums.school_year AS sy ON sy.year_id = sri.year_id					
			INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = mes.exam_information_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
			INNER JOIN ums.IterateListToTable (@course_group_id_list, ',') AS cgil_list ON cgil_list.var_str = cg.course_group_id
			WHERE
				(NOT mes.sysid_semester IS NULL AND NOT mes.sysid_semester = '') AND
				(cg.is_semestral = 1) AND
				((@date_start BETWEEN sri.date_start AND sri.date_end) AND (@date_end BETWEEN sri.date_start AND sri.date_end))
			ORDER BY
				exam_date, group_no ASC

		END
		ELSE IF ((NOT @date_start IS NULL) AND (NOT @date_end IS NULL)) AND (NOT ISNULL(@course_group_id_list, '') = '') AND		-- (11)
			(NOT ISNULL(@exam_information_id_list, '') = '')
		BEGIN

			SELECT
				mes.major_exam_id AS major_exam_id,
				mes.year_id AS year_id,
				mes.sysid_semester AS sysid_semester,
				mes.exam_information_id AS exam_information_id,
				mes.exam_date AS exam_date,
				mei.exam_description AS exam_description,
				mei.is_clearance_included AS is_clearance_included,
				mei.course_group_id AS course_group_id,
				cg.group_description AS group_description,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral
			FROM
				ums.major_exam_schedule AS mes
			INNER JOIN ums.school_year AS sy ON sy.year_id = mes.year_id
			INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = mes.exam_information_id
			INNER JOIN ums.IterateListToTable (@exam_information_id_list, ',') AS eiil_list ON eiil_list.var_str = mei.exam_information_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
			INNER JOIN ums.IterateListToTable (@course_group_id_list, ',') AS cgil_list ON cgil_list.var_str = cg.course_group_id
			WHERE
				(NOT mes.year_id IS NULL AND NOT mes.year_id = '') AND
				(cg.is_semestral = 0) AND
				((sy.date_start BETWEEN @date_start AND @date_end) AND (sy.date_end BETWEEN @date_start AND @date_end))
			UNION ALL
			SELECT
				mes.major_exam_id AS major_exam_id,
				sy.year_id AS year_id,
				mes.sysid_semester AS sysid_semester,
				mes.exam_information_id AS exam_information_id,
				mes.exam_date AS exam_date,
				mei.exam_description AS exam_description,
				mei.is_clearance_included AS is_clearance_included,
				mei.course_group_id AS course_group_id,
				cg.group_description AS group_description,
				cg.group_no AS group_no,
				cg.is_semestral AS is_semestral
			FROM
				ums.major_exam_schedule AS mes
			INNER JOIN ums.semester_information AS sri ON sri.sysid_semester = mes.sysid_semester	
			INNER JOIN ums.school_year AS sy ON sy.year_id = sri.year_id					
			INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = mes.exam_information_id
			INNER JOIN ums.IterateListToTable (@exam_information_id_list, ',') AS eiil_list ON eiil_list.var_str = mei.exam_information_id
			INNER JOIN ums.course_group AS cg ON cg.course_group_id = mei.course_group_id
			INNER JOIN ums.IterateListToTable (@course_group_id_list, ',') AS cgil_list ON cgil_list.var_str = cg.course_group_id
			WHERE
				(NOT mes.sysid_semester IS NULL AND NOT mes.sysid_semester = '') AND
				(cg.is_semestral = 1) AND
				((@date_start BETWEEN sri.date_start AND sri.date_end) AND (@date_end BETWEEN sri.date_start AND sri.date_end))
			ORDER BY
				exam_date, group_no ASC

		END
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a major exam schedule', 'Major Exam Schedule'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectMajorExamSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistsYearSemesterIDExamDateInformationIDExamSchedule" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistsYearSemesterIDExamDateInformationIDExamSchedule')
   DROP PROCEDURE ums.IsExistsYearSemesterIDExamDateInformationIDExamSchedule
GO

CREATE PROCEDURE ums.IsExistsYearSemesterIDExamDateInformationIDExamSchedule

	@major_exam_id bigint,
	@year_id varchar (50) = '',
	@sysid_semester varchar (50) = '',
	@exam_information_id varchar (50) = '',
	@exam_date datetime,

	@system_user_id varchar (50) = ''	
		
AS
	
	IF ((ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1))
	BEGIN

		SELECT ums.IsExistsYearSemesterIDExamDateInformationIDExamSched(@major_exam_id, @year_id, @sysid_semester, @exam_information_id, @exam_date)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a major exam schedule', 'Major Exam Schedule'
	END	
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistsYearSemesterIDExamDateInformationIDExamSchedule TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistsYearSemesterIDExamDateInformationIDExamSched" function already exist
IF OBJECT_ID (N'ums.IsExistsYearSemesterIDExamDateInformationIDExamSched') IS NOT NULL
   DROP FUNCTION ums.IsExistsYearSemesterIDExamDateInformationIDExamSched
GO

CREATE FUNCTION ums.IsExistsYearSemesterIDExamDateInformationIDExamSched
(	
	@major_exam_id bigint,
	@year_id varchar (50) = '',
	@sysid_semester varchar (50) = '',
	@exam_information_id varchar (50) = '',
	@exam_date datetime
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0

	IF (EXISTS (SELECT 
					mes.major_exam_id 
				FROM 
					ums.major_exam_schedule AS mes
				INNER JOIN ums.major_exam_information AS mei ON mei.exam_information_id = mes.exam_information_id
				WHERE 
					(NOT mes.major_exam_id = @major_exam_id) AND

					((((mes.year_id = @year_id) OR
					(mes.sysid_semester = @sysid_semester)) AND					
					(mes.exam_date = @exam_date) AND
					(mei.course_group_id = (SELECT course_group_id FROM ums.major_exam_information WHERE exam_information_id = @exam_information_id))) OR

					(((mes.year_id = @year_id) OR
					(mes.sysid_semester = @sysid_semester)) AND
					(mes.exam_information_id = @exam_information_id) AND
					(mei.is_one_instance = 1)))))

	BEGIN
		SET @result = 1
	END
	
	RETURN @result

END
GO
------------------------------------------------------


-- ################################################END TABLE "major_exam_schedule" OBJECTS######################################################




-- ################################################TABLE "transcript_information" OBJECTS######################################################
-- verifies if the transcript_information table exists
IF OBJECT_ID('ums.transcript_information', 'U') IS NOT NULL
	DROP TABLE ums.transcript_information
GO

CREATE TABLE ums.transcript_information 			
(
	sysid_transcript varchar (50) NOT NULL 
		CONSTRAINT Transcript_Information_SysID_Transcript_PK PRIMARY KEY (sysid_transcript)
		CONSTRAINT Transcript_Information_SysID_Transcript_CK CHECK (sysid_transcript LIKE 'SYSTOR%'),
	student_id varchar (50) NOT NULL
		CONSTRAINT Transcript_Information_Student_ID_UQ UNIQUE (student_id),
	last_name varchar (50) NOT NULL,
	first_name varchar (50) NOT NULL,
	middle_name varchar (50) NULL DEFAULT (''),
	department_name varchar (100) NULL,
	course_title varchar (100) NULL,
	entrance_data varchar (200) NULL,
	records_of_graduation varchar (MAX) NULL,
	purpose_of_request varchar (200) NULL,

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Transcript_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Transcript_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Transcript_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the transcript_information table 
CREATE INDEX Transcript_Information_SysID_Transcript_Index
	ON ums.transcript_information (sysid_transcript DESC)
GO
------------------------------------------------------------------

/*verifies that the trigger "Transcript_Information_Trigger_Insert" already exist*/
IF OBJECT_ID ('ums.Transcript_Information_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Transcript_Information_Trigger_Insert
GO

CREATE TRIGGER ums.Transcript_Information_Trigger_Insert
	ON  ums.transcript_information
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_transcript varchar (50)
	DECLARE @student_id varchar (50)
	DECLARE @last_name varchar (50)
	DECLARE @first_name varchar (50)
	DECLARE @middle_name varchar (50)
	DECLARE @department_name varchar (100)
	DECLARE @course_title varchar (100)
	DECLARE @entrance_data varchar (200)
	DECLARE @records_of_graduation varchar (MAX)
	DECLARE @purpose_of_request varchar (200)
	
	DECLARE @created_by varchar (50)

	SELECT 
		@sysid_transcript = i.sysid_transcript,
		@student_id = i.student_id,
		@last_name = i.last_name,
		@first_name = i.first_name,
		@middle_name = i.middle_name,
		@department_name = i.department_name,
		@course_title = i.course_title,
		@entrance_data = i.entrance_data,
		@records_of_graduation = i.records_of_graduation,
		@purpose_of_request = i.purpose_of_request,

		@created_by = i.created_by
	FROM INSERTED AS i

	SET @transaction_done = 'CREATED a student transcript information ' + 
							'[Transcript System ID: ' + ISNULL(@sysid_transcript, '') +	
							'][Student ID: ' + ISNULL(@student_id, '') +
							'][Name: ' + @last_name + ', ' + @first_name + ' ' + ISNULL(@middle_name, '') +
							'][Department Name: ' + ISNULL(@department_name, '') +
							'][Course Title: ' + ISNULL(@course_title, '') +
							'][Entrance Data: ' + ISNULL(@entrance_data, '') +
							'][Records of Graduation: ' + ISNULL(@records_of_graduation, '') +
							'][Purpose of Request: ' + ISNULL(@purpose_of_request, '') +
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done	

GO
/*-----------------------------------------------------------------*/

/*verifies that the trigger "Transcript_Information_Trigger_Instead_Update" already exist*/
IF OBJECT_ID ('ums.Transcript_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Transcript_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Transcript_Information_Trigger_Instead_Update
	ON  ums.transcript_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @sysid_transcript varchar (50)
	DECLARE @student_id varchar (50)
	DECLARE @last_name varchar (50)
	DECLARE @first_name varchar (50)
	DECLARE @middle_name varchar (50)
	DECLARE @department_name varchar (100)
	DECLARE @course_title varchar (100)
	DECLARE @entrance_data varchar (200)
	DECLARE @records_of_graduation varchar (MAX)
	DECLARE @purpose_of_request varchar (200)

	DECLARE @edited_by varchar (50)

	DECLARE @student_id_b varchar (50)
	DECLARE @last_name_b varchar (50)
	DECLARE @first_name_b varchar (50)
	DECLARE @middle_name_b varchar (50)
	DECLARE @department_name_b varchar (100)
	DECLARE @course_title_b varchar (100)
	DECLARE @entrance_data_b varchar (200)
	DECLARE @records_of_graduation_b varchar (MAX)
	DECLARE @purpose_of_request_b varchar (200)

	DECLARE @has_update bit

	DECLARE transcript_information_update_cursor CURSOR LOCAL FORWARD_ONLY STATIC READ_ONLY 
		FOR SELECT i.sysid_transcript, i.student_id, i.last_name, i.first_name, i.middle_name, i.department_name,
				i.course_title, i.entrance_data, i.records_of_graduation, i.purpose_of_request, i.edited_by
			FROM 
				INSERTED AS i

	OPEN transcript_information_update_cursor

	FETCH NEXT FROM transcript_information_update_cursor
		INTO @sysid_transcript, @student_id, @last_name, @first_name, @middle_name, @department_name,
				@course_title, @entrance_data, @records_of_graduation, @purpose_of_request, @edited_by

	WHILE @@FETCH_STATUS = 0
	BEGIN

		SELECT 
			@student_id_b = tri.student_id,
			@last_name_b = tri.last_name,
			@first_name_b = tri.first_name,
			@middle_name_b = tri.middle_name,
			@department_name_b = tri.department_name,
			@course_title_b = tri.course_title,
			@entrance_data_b = tri.entrance_data,
			@records_of_graduation_b = tri.records_of_graduation,
			@purpose_of_request_b = tri.purpose_of_request
		FROM 
			ums.transcript_information AS tri
		WHERE
			tri.sysid_transcript = @sysid_transcript

		SET @transaction_done = ''
		SET @has_update = 0

		IF (NOT ISNULL(@student_id COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@student_id_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Student ID Before: ' + ISNULL(@student_id_b, '') + ']' +
														'[Student ID After: ' + ISNULL(@student_id, '') + ']'
			SET @has_update = 1
		END
		ELSE
		BEGIN
			SET @transaction_done = @transaction_done + '[Student ID: ' + ISNULL(@student_id, '') + ']'
		END
		
		IF (NOT ISNULL(@first_name COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@first_name_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')) OR
			(NOT ISNULL(@middle_name COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@middle_name_b COLLATE SQL_Latin1_General_CP1_CS_AS, '')) OR
			(NOT ISNULL(@last_name COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@last_name_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Name Before: ' + @last_name_b + ', ' + @first_name_b + ' ' + ISNULL(@middle_name_b, '') + ']' +
														'[Name After: ' + @last_name + ', ' + @first_name + ' ' + ISNULL(@middle_name, '') + ']'
			SET @has_update = 1
		END
		ELSE
		BEGIN
			SET @transaction_done = @transaction_done + '[Name: ' + @last_name + ', ' + @first_name + ' ' + ISNULL(@middle_name, '') + ']'
		END

		IF (NOT ISNULL(@department_name COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@department_name_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Department Name Before: ' + ISNULL(@department_name_b, '') + ']' +
														'[Department Name After: ' + ISNULL(@department_name, '') + ']'
			SET @has_update = 1
		END

		IF (NOT ISNULL(@course_title COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@course_title_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Course Title Before: ' + ISNULL(@course_title_b, '') + ']' +
														'[Course Title After: ' + ISNULL(@course_title, '') + ']'
			SET @has_update = 1
		END

		IF (NOT ISNULL(@entrance_data COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@entrance_data_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Entrance Data Before: ' + ISNULL(@entrance_data_b, '') + ']' +
														'[Entrance Data After: ' + ISNULL(@entrance_data, '') + ']'
			SET @has_update = 1
		END

		IF (NOT ISNULL(@records_of_graduation COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@records_of_graduation_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Records of Graduation Before: ' + ISNULL(@records_of_graduation_b, '') + ']' +
														'[Records of Graduation After: ' + ISNULL(@records_of_graduation, '') + ']'
			SET @has_update = 1
		END

		IF (NOT ISNULL(@purpose_of_request COLLATE SQL_Latin1_General_CP1_CS_AS, '') = ISNULL(@purpose_of_request_b COLLATE SQL_Latin1_General_CP1_CS_AS, ''))
		BEGIN
			SET @transaction_done = @transaction_done + '[Purpose of Request Before: ' + ISNULL(@purpose_of_request_b, '') + ']' +
														'[Purpose of Request After: ' + ISNULL(@purpose_of_request, '') + ']'
			SET @has_update = 1
		END

		IF (@has_update = 1)
		BEGIN

			UPDATE ums.transcript_information SET
				student_id = @student_id,
				last_name = @last_name,
				first_name = @first_name,
				middle_name = @middle_name,
				department_name = @department_name,
				course_title = @course_title,
				entrance_data = @entrance_data,
				records_of_graduation = @records_of_graduation,
				purpose_of_request = @purpose_of_request,

				edited_on = GETDATE(),
				edited_by = @edited_by
			WHERE
				sysid_transcript = @sysid_transcript
	
			SET @transaction_done = 'UPDATED a student transcript information ' + 
									'[Transcript System ID: ' + ISNULL(@sysid_transcript, '') +						
									']' + @transaction_done

			IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
			BEGIN
				SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @edited_by
			END
					
			EXECUTE ums.InsertTransactionLog @edited_by, @network_information, @transaction_done			

		END
		
		FETCH NEXT FROM transcript_information_update_cursor
			INTO @sysid_transcript, @student_id, @last_name, @first_name, @middle_name, @department_name,
					@course_title, @entrance_data, @records_of_graduation, @purpose_of_request, @edited_by

	END

	CLOSE transcript_information_update_cursor
	DEALLOCATE transcript_information_update_cursor

GO
/*-----------------------------------------------------------------*/

-- verifies that the trigger "Transcript_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Transcript_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Transcript_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Transcript_Information_Trigger_Instead_Delete
	ON  ums.transcript_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a transcript information', 'Transcript Information'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "InsertTranscriptInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertTranscriptInformation')
   DROP PROCEDURE ums.InsertTranscriptInformation
GO

CREATE PROCEDURE ums.InsertTranscriptInformation

	@sysid_transcript varchar (50),
	@student_id varchar (50),
	@last_name varchar (50),
	@first_name varchar (50),
	@middle_name varchar (50),
	@department_name varchar (100),
	@course_title varchar (100),
	@entrance_data varchar (200),
	@records_of_graduation varchar (MAX),
	@purpose_of_request varchar (200),

	@network_information varchar (MAX) = '',
	@created_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@created_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@created_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@created_by) = 1))
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @created_by, @network_information

		INSERT INTO ums.transcript_information
		(
			sysid_transcript,
			student_id,
			last_name,
			first_name,
			middle_name,
			department_name,
			course_title,
			entrance_data,
			records_of_graduation,
			purpose_of_request,

			created_by
		)
		VALUES
		(
			@sysid_transcript,
			@student_id,
			@last_name,
			@first_name,
			@middle_name,
			@department_name,
			@course_title,
			@entrance_data,
			@records_of_graduation,
			@purpose_of_request,

			@created_by
		)
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert a transcript information', 'Transcript Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertTranscriptInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "UpdateTranscriptInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'UpdateTranscriptInformation')
   DROP PROCEDURE ums.UpdateTranscriptInformation
GO

CREATE PROCEDURE ums.UpdateTranscriptInformation

	@sysid_transcript varchar (50),
	@student_id varchar (50),
	@last_name varchar (50),
	@first_name varchar (50),
	@middle_name varchar (50),
	@department_name varchar (100),
	@course_title varchar (100),
	@entrance_data varchar (200),
	@records_of_graduation varchar (MAX),
	@purpose_of_request varchar (200),

	@network_information varchar (MAX) = '',
	@edited_by varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@edited_by) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@edited_by) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@edited_by) = 1))
	BEGIN
		
		EXECUTE ums.CreateTemporaryTable @edited_by, @network_information

		UPDATE ums.transcript_information SET
			student_id = @student_id,
			last_name = @last_name,
			first_name = @first_name,
			middle_name = @middle_name,
			department_name = @department_name,
			course_title = @course_title,
			entrance_data = @entrance_data,
			records_of_graduation = @records_of_graduation,
			purpose_of_request = @purpose_of_request,

			edited_by = @edited_by
		WHERE
			sysid_transcript = @sysid_transcript
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Update a transcript information', 'Transcript Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.UpdateTranscriptInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectTranscriptInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectTranscriptInformation')
   DROP PROCEDURE ums.SelectTranscriptInformation
GO

CREATE PROCEDURE ums.SelectTranscriptInformation
	
	@query_string varchar (50) = '',

	@system_user_id varchar (50) = ''

AS

	IF ((ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1))
	BEGIN
		
		SELECT @query_string = '%' + RTRIM(LTRIM(ISNULL(@query_string, ''))) + '%'

		IF (NOT ISNULL(@query_string, '') = '%*%')
		BEGIN
			
			SELECT
				tri.sysid_transcript AS sysid_transcript,
				tri.student_id AS student_id,
				tri.last_name AS last_name,
				tri.first_name AS first_name,
				tri.middle_name AS middle_name,
				tri.department_name AS department_name,
				tri.course_title AS course_title,
				tri.entrance_data AS entrance_data,
				tri.records_of_graduation AS records_of_graduation,
				tri.purpose_of_request AS purpose_of_request
			FROM
				ums.transcript_information AS tri
			WHERE
				((tri.last_name + ', ' + tri.first_name + ' ' + tri.middle_name) LIKE @query_string) OR
				((tri.last_name + ' ' + tri.first_name + ' ' + tri.middle_name) LIKE @query_string) OR
				((tri.first_name + ' ' + tri.middle_name + ' ' + tri.last_name) LIKE @query_string) OR
				((tri.first_name + ' ' + tri.last_name) LIKE @query_string) OR
				((tri.last_name + ',' + tri.first_name + tri.middle_name) LIKE REPLACE(@query_string, ' ', '')) OR
				((tri.last_name + tri.first_name + tri.middle_name) LIKE REPLACE(@query_string, ' ', '')) OR
				((tri.first_name + tri.middle_name + tri.last_name) LIKE REPLACE(@query_string, ' ', '')) OR
				((tri.first_name + tri.last_name) LIKE REPLACE(@query_string, ' ', '')) OR
				((REPLACE(tri.last_name, ' ', '') + ',' + REPLACE(tri.first_name, ' ', '') + REPLACE(tri.middle_name, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
				((REPLACE(tri.last_name, ' ', '') + REPLACE(tri.first_name, ' ', '') + REPLACE(tri.middle_name, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
				((REPLACE(tri.first_name, ' ', '') + REPLACE(tri.middle_name, ' ', '') + REPLACE(tri.last_name, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR
				((REPLACE(tri.first_name, ' ', '') + REPLACE(tri.last_name, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
				(tri.student_id LIKE @query_string) OR
				((REPLACE(tri.student_id, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
				(tri.department_name LIKE @query_string) OR
				((REPLACE(tri.department_name, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
				(tri.course_title LIKE @query_string) OR
				((REPLACE(tri.course_title, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
				(tri.entrance_data LIKE @query_string) OR
				((REPLACE(tri.entrance_data, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
				(tri.records_of_graduation LIKE @query_string) OR
				((REPLACE(tri.records_of_graduation, ' ', '')) LIKE REPLACE(@query_string, ' ', '')) OR 
				(tri.purpose_of_request LIKE @query_string) OR
				((REPLACE(tri.purpose_of_request, ' ', '')) LIKE REPLACE(@query_string, ' ', ''))
			ORDER BY
				last_name, first_name, middle_name ASC

		END		
		ELSE
		BEGIN

			SELECT
				tri.sysid_transcript AS sysid_transcript,
				tri.student_id AS student_id,
				tri.last_name AS last_name,
				tri.first_name AS first_name,
				tri.middle_name AS middle_name,
				tri.department_name AS department_name,
				tri.course_title AS course_title,
				tri.entrance_data AS entrance_data,
				tri.records_of_graduation AS records_of_graduation,
				tri.purpose_of_request AS purpose_of_request
			FROM
				ums.transcript_information AS tri
			ORDER BY
				last_name, first_name, middle_name ASC

		END		

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a transcript information', 'Transcript Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectTranscriptInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "GetCountTranscriptInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'GetCountTranscriptInformation')
   DROP PROCEDURE ums.GetCountTranscriptInformation
GO

CREATE PROCEDURE ums.GetCountTranscriptInformation

	@system_user_id varchar (50) = ''	
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1))
	BEGIN

		SELECT COUNT(sysid_transcript) FROM ums.transcript_information
		
	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a transcript information', 'Transcript Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.GetCountTranscriptInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistSysIDTranscriptInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistSysIDTranscriptInformation')
   DROP PROCEDURE ums.IsExistSysIDTranscriptInformation
GO

CREATE PROCEDURE ums.IsExistSysIDTranscriptInformation

	@sysid_transcript varchar (50) = '',
	@system_user_id varchar (50) = ''
		
AS

	IF ((ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1))
	BEGIN
	
		SELECT ums.IsExistSysIDTranscriptInfo(@sysid_transcript)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a transcript information', 'Transcript Information'
	END	
	
GO
------------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistSysIDTranscriptInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "IsExistStudentIDTranscriptInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'IsExistStudentIDTranscriptInformation')
   DROP PROCEDURE ums.IsExistStudentIDTranscriptInformation
GO

CREATE PROCEDURE ums.IsExistStudentIDTranscriptInformation

	@sysid_transcript varchar (50) = '',
	@student_id varchar (50) = '',
	@system_user_id varchar (50) = ''
		
AS
	
	IF ((ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1))
	BEGIN
	
		SELECT ums.IsExistStudentIDTranscriptInfo(@sysid_transcript, @student_id)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a transcript information', 'Transcript Information'
	END	
	
GO
------------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.IsExistStudentIDTranscriptInformation TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the "IsExistSysIDTranscriptInfo" function already exist
IF OBJECT_ID (N'ums.IsExistSysIDTranscriptInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistSysIDTranscriptInfo
GO

CREATE FUNCTION ums.IsExistSysIDTranscriptInfo
(	
	@sysid_transcript varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_transcript FROM ums.transcript_information WHERE sysid_transcript = @sysid_transcript)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- verifies if the "IsExistStudentIDTranscriptInfo" function already exist
IF OBJECT_ID (N'ums.IsExistStudentIDTranscriptInfo') IS NOT NULL
   DROP FUNCTION ums.IsExistStudentIDTranscriptInfo
GO

CREATE FUNCTION ums.IsExistStudentIDTranscriptInfo
(	
	@sysid_transcript varchar (50) = '',
	@student_id varchar (50) = ''
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result bit

	SET @result = 0
	
	IF EXISTS (SELECT sysid_transcript FROM ums.transcript_information WHERE ((REPLACE(student_id, ' ', '')) LIKE REPLACE(@student_id, ' ', '')) AND NOT sysid_transcript = @sysid_transcript)
	BEGIN
		SET @result = 1
	END
	
	RETURN @result
END
GO
------------------------------------------------------

-- ################################################END TABLE "transcript_information" OBJECTS######################################################



-- ##########################################TABLE "transcript_image" OBJECTS########################################################

-- verifies if the transcript_image table exists
IF OBJECT_ID('ums.transcript_image', 'U') IS NOT NULL
	DROP TABLE ums.transcript_image
GO

CREATE TABLE ums.transcript_image 			
(
	image_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Transcript_Image_Image_ID_PK PRIMARY KEY (image_id),
	sysid_transcript varchar (50) NOT NULL 
		CONSTRAINT Transcript_Image_SysID_Transcript_FK FOREIGN KEY REFERENCES ums.transcript_information(sysid_transcript) ON UPDATE NO ACTION
		CONSTRAINT Transcript_Image_SysID_Transcript_UQ UNIQUE (sysid_transcript),
	
	file_data varbinary (MAX) NULL,
	original_name varchar (255) NULL
		CONSTRAINT Transcript_Image_Original_Name_UQ UNIQUE (original_name),

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Transcript_Image_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Transcript_Image_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Transcript_Image_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the transcript_image table 
CREATE INDEX Transcript_Image_Image_ID_Index
	ON ums.transcript_image (image_id ASC)
GO
------------------------------------------------------------------

--verifies that the trigger "Transcript_Image_Trigger_Insert" already exist
IF OBJECT_ID ('ums.Transcript_Image_Trigger_Insert','TR') IS NOT NULL
   DROP TRIGGER ums.Transcript_Image_Trigger_Insert
GO

CREATE TRIGGER ums.Transcript_Image_Trigger_Insert
	ON  ums.transcript_image
	FOR INSERT
	NOT FOR REPLICATION
AS 

	DECLARE @network_information varchar (MAX)
	DECLARE @transaction_done varchar(MAX)

	DECLARE @image_id bigint
	DECLARE @sysid_transcript varchar (50)
	DECLARE @original_name varchar (255)

	DECLARE @created_on datetime
	DECLARE @created_by varchar (50)
	
	SELECT 
		@image_id = i.image_id,
		@sysid_transcript = i.sysid_transcript,
		@original_name = i.original_name,

		@created_on = i.created_on,
		@created_by = i.created_by
	FROM INSERTED AS i

	SET @transaction_done = 'CREATED a transcript image ' + 
							'[Transcript Information ID: ' + ISNULL(@sysid_transcript, '') + 
							'][Image ID: ' + ISNULL(CONVERT(varchar, @image_id), '') +
							'][Student ID: ' + ISNULL((SELECT student_id FROM ums.transcript_information WHERE sysid_transcript = @sysid_transcript), '') +
							'][Name: ' + ISNULL((SELECT
														tri.last_name + ', ' + tri.first_name + ' ' + ISNULL(tri.middle_name, '')
													FROM
														ums.transcript_information AS tri
													WHERE 
														sysid_transcript = @sysid_transcript), '') +
							'][Image Original FileName: ' + ISNULL(@original_name, '') + 
							']'

	IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
	BEGIN
		SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @created_by
	END
			
	EXECUTE ums.InsertTransactionLog @created_by, @network_information, @transaction_done

GO
-----------------------------------------------------------------

-- verifies if the procedure "InsertUpdateTranscriptImage" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'InsertUpdateTranscriptImage')
   DROP PROCEDURE ums.InsertUpdateTranscriptImage
GO

CREATE PROCEDURE ums.InsertUpdateTranscriptImage
	
	@sysid_transcript varchar (50) = '',

	@file_data varbinary (MAX),
	@original_name varchar (255) = '',

	@network_information varchar (MAX) = '',
	@system_user_id varchar (50) = ''

AS

	DECLARE @transaction_done varchar(MAX)

	DECLARE @image_id bigint

	IF ((ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1))
	BEGIN

		EXECUTE ums.CreateTemporaryTable @system_user_id, @network_information

		IF (NOT EXISTS (SELECT image_id FROM ums.transcript_image WHERE (sysid_transcript = @sysid_transcript)))
		BEGIN

			INSERT INTO ums.transcript_image
			(
				sysid_transcript,

				file_data,
				original_name,

				created_by
			)
			VALUES
			(
				@sysid_transcript,

				@file_data,
				@original_name,

				@system_user_id
			)

		END
		ELSE
		BEGIN

			IF (NOT @file_data = (SELECT file_data FROM ums.transcript_image WHERE sysid_transcript = @sysid_transcript))
			BEGIN

				UPDATE ums.transcript_image SET
					file_data = @file_data,
					original_name = @original_name,

					edited_on = GETDATE(),
					edited_by = @system_user_id
				WHERE
					(sysid_transcript = @sysid_transcript)

				SET @transaction_done = 'UPDATED a transcript image ' + 
										'[Transcript Information ID: ' + ISNULL(@sysid_transcript, '') + 
										'][Student ID: ' + ISNULL((SELECT student_id FROM ums.transcript_information WHERE sysid_transcript = @sysid_transcript), '') +
										'][Name: ' + ISNULL((SELECT
																	tri.last_name + ', ' + tri.first_name + ' ' + ISNULL(tri.middle_name, '')
																FROM
																	ums.transcript_information AS tri
																WHERE 
																	sysid_transcript = @sysid_transcript), '') +					
										']'

				IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE NAME = '##ums_network_information_table')
				BEGIN
					SELECT @network_information = network_information FROM ##ums_network_information_table WHERE system_user_id = @system_user_id
				END
						
				EXECUTE ums.InsertTransactionLog @system_user_id, @network_information, @transaction_done

			END

		END

	END	
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Insert/Update a transcript image', 'Transcript Image'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.InsertUpdateTranscriptImage TO db_umsusers
GO
-------------------------------------------------------------

-- verifies if the procedure "SelectTranscriptImagesTranscriptInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectTranscriptImagesTranscriptInformation')
   DROP PROCEDURE ums.SelectTranscriptImagesTranscriptInformation
GO

CREATE PROCEDURE ums.SelectTranscriptImagesTranscriptInformation

	@sysid_transcript_list nvarchar (MAX) = '',

	@system_user_id varchar (50) = ''

AS

	IF ((ums.IsSystemAdminSystemUserInfo(@system_user_id) = 1) OR (ums.IsCollegeRegistrarSystemUserInfo(@system_user_id) = 1) OR
			(ums.IsHighSchoolGradeSchoolRegistrarSystemUserInfo(@system_user_id) = 1))
	BEGIN
		
		SELECT 
			tri.sysid_transcript AS sysid_transcript,
			tri.file_data AS file_data,
			tri.original_name AS original_name
		FROM 
			ums.transcript_image AS tri
		INNER JOIN ums.IterateListToTable (@sysid_transcript_list, ',') AS str_list ON str_list.var_str = tri.sysid_transcript
		WHERE
			(NOT tri.file_data IS NULL) AND
			(NOT tri.original_name IS NULL)

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query a transcript information', 'Transcript Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectTranscriptImagesTranscriptInformation TO db_umsusers
GO
-------------------------------------------------------------

-- ##########################################END TABLE "transcript_image" OBJECTS########################################################



-- ################################################TABLE "transcript_details" OBJECTS######################################################
--WAS MOVED TO UMS ( 06 ) Office Solutions SQL.sql BECAUSE OF THE SYSID_SCHEDULE COLUMN
-- ##############################################END TABLE "transcript_details" OBJECTS######################################################




-- ######################################RESTORE DEPENDENT TABLE CONSTRAINTS#############################################################

--verifies if the Schedule_Information_SysID_Subject_FK constraint exists
IF OBJECT_ID('ums.schedule_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information WITH NOCHECK
	ADD CONSTRAINT Schedule_Information_SysID_Subject_FK FOREIGN KEY (sysid_subject) REFERENCES ums.subject_information(sysid_subject) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_Details_SysID_Classroom_FK constraint exists
IF OBJECT_ID('ums.schedule_information_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information_details WITH NOCHECK
	ADD CONSTRAINT Schedule_Information_Details_SysID_Classroom_FK FOREIGN KEY (sysid_classroom) REFERENCES ums.classroom_information(sysid_classroom) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_Year_ID_FK constraint exists
IF OBJECT_ID('ums.schedule_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information WITH NOCHECK
	ADD CONSTRAINT Schedule_Information_Year_ID_FK FOREIGN KEY (year_id) REFERENCES ums.school_year(year_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Schedule_Information_SysID_Semester_FK constraint exists
IF OBJECT_ID('ums.schedule_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.schedule_information WITH NOCHECK
	ADD CONSTRAINT Schedule_Information_SysID_Semester_FK FOREIGN KEY (sysid_semester) REFERENCES ums.semester_information(sysid_semester) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Information_Course_Group_ID_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_information WITH NOCHECK
	ADD CONSTRAINT Auxiliary_Service_Information_Course_Group_ID_FK FOREIGN KEY (course_group_id) REFERENCES ums.course_group(course_group_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Schedule_Year_ID_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_schedule WITH NOCHECK
	ADD CONSTRAINT Auxiliary_Service_Schedule_Year_ID_FK FOREIGN KEY (year_id) REFERENCES ums.school_year(year_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Auxiliary_Service_Schedule_SysID_Semester_FK constraint exists
IF OBJECT_ID('ums.auxiliary_service_schedule', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.auxiliary_service_schedule WITH NOCHECK
	ADD CONSTRAINT Auxiliary_Service_Schedule_SysID_Semester_FK FOREIGN KEY (sysid_semester) REFERENCES ums.semester_information(sysid_semester) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Information_Year_ID_FK constraint exists
IF OBJECT_ID('ums.school_fee_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_information WITH NOCHECK
	ADD CONSTRAINT School_Fee_Information_Year_ID_FK FOREIGN KEY (year_id) REFERENCES ums.school_year(year_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the School_Fee_Level_Year_Level_ID_FK constraint exists
IF OBJECT_ID('ums.school_fee_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.school_fee_level WITH NOCHECK
	ADD CONSTRAINT School_Fee_Level_Year_Level_ID_FK FOREIGN KEY (year_level_id) REFERENCES ums.year_level_information (year_level_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Course_Course_ID_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_course', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_course WITH NOCHECK
	ADD CONSTRAINT Student_Enrolment_Course_Course_ID_FK FOREIGN KEY (course_id) REFERENCES ums.course_information (course_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Course_SysID_Semester_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_course', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_course WITH NOCHECK
	ADD CONSTRAINT Student_Enrolment_Course_SysID_Semester_FK FOREIGN KEY (sysid_semester) REFERENCES ums.semester_information(sysid_semester) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Level_SysID_Semester_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_level', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_level WITH NOCHECK
	ADD CONSTRAINT Student_Enrolment_Level_SysID_Semester_FK FOREIGN KEY (sysid_semester) REFERENCES ums.semester_information(sysid_semester) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Scholarship_Information_Course_Group_ID_FK constraint exists
IF OBJECT_ID('ums.scholarship_information', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.scholarship_information WITH NOCHECK
	ADD CONSTRAINT Scholarship_Information_Course_Group_ID_FK FOREIGN KEY (course_group_id) REFERENCES ums.course_group(course_group_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Enrolment_Course_Major_Major_Information_ID_FK constraint exists
IF OBJECT_ID('ums.enrolment_course_major', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.enrolment_course_major WITH NOCHECK
	ADD CONSTRAINT Enrolment_Course_Major_Major_Information_ID_FK FOREIGN KEY (major_information_id) REFERENCES ums.course_major_information(major_information_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Transcript_Details_SysID_Transcript_FK constraint exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_details WITH NOCHECK
	ADD CONSTRAINT Transcript_Details_SysID_Transcript_FK FOREIGN KEY (sysid_transcript) REFERENCES ums.transcript_information(sysid_transcript) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Transcript_Details_SysID_Special_FK constraint exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_details WITH NOCHECK
	ADD CONSTRAINT Transcript_Details_SysID_Special_FK FOREIGN KEY (sysid_special) REFERENCES ums.special_class_information(sysid_special) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Transcript_Details_Category_ID_FK constraint exists
IF OBJECT_ID('ums.transcript_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.transcript_details WITH NOCHECK
	ADD CONSTRAINT Transcript_Details_Category_ID_FK FOREIGN KEY (category_id) REFERENCES ums.subject_category(category_id) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

-- ######################################END RESTORE DEPENDENT TABLE CONSTRAINTS#############################################################



-- ############################################INITIAL DATABASE INFORMATION#############################################################

-- ums.school_semester
-- is used for the school semester (IS REFERENCES BY THE ENUM SchoolSemester)
INSERT INTO ums.school_semester(semester_id, semester_description) VALUES (1, 'First Semester')
INSERT INTO ums.school_semester(semester_id, semester_description) VALUES (2, 'Second Semester')
INSERT INTO ums.school_semester(semester_id, semester_description) VALUES (3, 'Summer')
GO

-- for school_year and semester_information table
DECLARE @date_start datetime
DECLARE @date_end datetime

SET @date_start = CONVERT(datetime, '06/01/2000 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2001 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20002001', 'S.Y. 2000 - 2001', @date_start, @date_end , 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '06/01/2000 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '10/31/2000 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0001', 'SY20002001', 1, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '11/01/2000 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2001 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0002', 'SY20002001', 2, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2001 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2001 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20002001SUMMER', 'S.Y. 2000 - 2001 (SUMMER)', @date_start, @date_end , 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2001 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2001 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0003', 'SY20002001SUMMER', 3, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'


SET @date_start = CONVERT(datetime, '06/01/2001 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2002 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20012002', 'S.Y. 2001 - 2002', @date_start, @date_end , 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '06/01/2001 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '10/31/2001 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0004', 'SY20012002', 1, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '11/01/2001 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2002 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0005', 'SY20012002', 2, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2002 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2002 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20012002SUMMER', 'S.Y. 2001 - 2002 (SUMMER)', @date_start, @date_end , 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2002 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2002 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0006', 'SY20012002SUMMER', 3, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

SET @date_start = CONVERT(datetime, '06/01/2002 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2003 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20022003', 'S.Y. 2002 - 2003', @date_start, @date_end , 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '06/01/2002 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '10/31/2002 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0007', 'SY20022003', 1, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '11/01/2002 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2003 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0008', 'SY20022003', 2, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2003 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2003 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20022003SUMMER', 'S.Y. 2002 - 2003 (SUMMER)', @date_start, @date_end , 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2003 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2003 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0009', 'SY20022003SUMMER', 3, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

SET @date_start = CONVERT(datetime, '06/01/2003 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2004 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20032004', 'S.Y. 2003 - 2004', @date_start, @date_end , 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '06/01/2003 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '10/31/2003 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0010', 'SY20032004', 1, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '11/01/2003 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2004 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0011', 'SY20032004', 2, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2004 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2004 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20032004SUMMER', 'S.Y. 2003 - 2004 (SUMMER)', @date_start, @date_end , 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2004 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2004 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0012', 'SY20032004SUMMER', 3, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

SET @date_start = CONVERT(datetime, '06/01/2004 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2005 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20042005', 'S.Y. 2004 - 2005', @date_start, @date_end , 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '06/01/2004 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '10/31/2004 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0013', 'SY20042005', 1, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '11/01/2004 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2005 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0014', 'SY20042005', 2, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2005 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2005 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20042005SUMMER', 'S.Y. 2004 - 2005 (SUMMER)', @date_start, @date_end , 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2005 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2005 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0015', 'SY20042005SUMMER', 3, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

SET @date_start = CONVERT(datetime, '06/01/2005 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2006 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20052006', 'S.Y. 2005 - 2006', @date_start, @date_end , 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '06/01/2005 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '10/31/2005 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0016', 'SY20052006', 1, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '11/01/2005 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2006 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0017', 'SY20052006', 2, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2006 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2006 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20052006SUMMER', 'S.Y. 2005 - 2006 (SUMMER)', @date_start, @date_end , 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2006 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2006 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0018', 'SY20052006SUMMER', 3, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

SET @date_start = CONVERT(datetime, '06/01/2006 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2007 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20062007', 'S.Y. 2006 - 2007', @date_start, @date_end , 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '06/01/2006 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '10/31/2006 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0019', 'SY20062007', 1, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '11/01/2006 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2007 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0020', 'SY20062007', 2, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2007 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2007 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20062007SUMMER', 'S.Y. 2006 - 2007 (SUMMER)', @date_start, @date_end , 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2007 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2007 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0021', 'SY20062007SUMMER', 3, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

SET @date_start = CONVERT(datetime, '06/01/2007 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2008 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20072008', 'S.Y. 2007 - 2008', @date_start, @date_end , 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '06/01/2007 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '10/31/2007 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0022', 'SY20072008', 1, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '11/01/2007 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2008 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0023', 'SY20072008', 2, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2008 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2008 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20072008SUMMER', 'S.Y. 2007 - 2008 (SUMMER)', @date_start, @date_end , 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2008 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2008 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0024', 'SY20072008SUMMER', 3, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

SET @date_start = CONVERT(datetime, '06/01/2008 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2009 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20082009', 'S.Y. 2008 - 2009', @date_start, @date_end , 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '06/01/2008 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '10/31/2008 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0025', 'SY20082009', 1, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '11/01/2008 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '03/31/2009 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0026', 'SY20082009', 2, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2009 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2009 11:59:59 PM', 101)
EXECUTE ums.InsertSchoolYear 'SY20082009SUMMER', 'S.Y. 2008 - 2009 (SUMMER)', @date_start, @date_end , 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
SET @date_start = CONVERT(datetime, '04/01/2009 12:00:00 AM', 101)
SET @date_end = CONVERT(datetime, '05/31/2009 11:59:59 PM', 101)
EXECUTE ums.InsertSemesterInformation 'SYSSEM0027', 'SY20082009SUMMER', 3, @date_start, @date_end, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

GO


-- ums.course_group
-- is used to determine the course group of the course (IS REFERENCE BY THE STRUCT CourseGroupId AND ENUM CourseGroupNo)
INSERT INTO ums.course_group(course_group_id, group_no, group_description, is_semestral, is_per_unit) VALUES ('CG01', 1, 'Grade School / Kinder', 0, 0)
INSERT INTO ums.course_group(course_group_id, group_no, group_description, is_semestral, is_per_unit) VALUES ('CG02', 2, 'High School', 0, 0)
INSERT INTO ums.course_group(course_group_id, group_no, group_description, is_semestral, is_per_unit) VALUES ('CG03', 3, 'College', 1, 1)
INSERT INTO ums.course_group(course_group_id, group_no, group_description, is_semestral, is_per_unit) VALUES ('CG04', 4, 'Graduate School', 1, 1)
INSERT INTO ums.course_group(course_group_id, group_no, group_description, is_semestral, is_per_unit) VALUES ('CG05', 5, 'Crash Course', 1, 1)
GO

-- ums.year_level_information
-- is used for the grade and year level information (IS REFERENCES BY THE STRUCT YearLevelId)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV01', 'CG01', 'Nursery', 'I', 'A', 1)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV02', 'CG01', 'Kinder 1', 'I', 'A', 2)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV03', 'CG01', 'Kinder 2', 'II', 'B', 3)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV04', 'CG01', 'Grade 1', 'I', 'C', 4)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV05', 'CG01', 'Grade 2', 'II', 'D', 5)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV06', 'CG01', 'Grade 3', 'III', 'E', 6)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV07', 'CG01', 'Grade 4', 'IV', 'F', 7)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV08', 'CG01', 'Grade 5', 'V', 'G', 8)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV09', 'CG01', 'Grade 6', 'VI', 'H', 9)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV10', 'CG02', '1st Year', '1', 'I', 10)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV11', 'CG02', '2nd Year', '2', 'J', 11)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV12', 'CG02', '3rd Year', '3', 'K', 12)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV13', 'CG02', '4th Year', '4', 'L', 13)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV14', 'CG03', '1st Year', '1', 'M', 14)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV15', 'CG03', '2nd Year', '2', 'N', 15)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV16', 'CG03', '3rd Year', '3', 'O', 16)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV17', 'CG03', '4th Year', '4', 'P', 17)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV18', 'CG03', '5th Year', '5', 'U', 18)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV19', 'CG04', 'Masteral', 'MS', 'Q', 19)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV20', 'CG04', 'Doctorate', 'DOC', 'Q', 20)
INSERT INTO ums.year_level_information(year_level_id, course_group_id, year_level_description, acronym, id_prefix, year_level_no) 
		VALUES ('YRLV21', 'CG05', 'Crash Course', 'CC', 'S', 21)
GO


-- for course_infomation table
INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE001', 'CG04', 'DEPT016', 'Doctor in Public Administration', 'DPA', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI001', 'CRSE001', 'YRLV20', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE002', 'CG04', 'DEPT016', 'Doctor in Business Administration', 'DBA', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI002', 'CRSE002', 'YRLV20', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE003', 'CG04', 'DEPT016', 'Doctor of Education', 'Ed.D', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI003', 'CRSE003', 'YRLV20', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE004', 'CG04', 'DEPT016', 'Master of Arts in Education', 'MA', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI004', 'CRSE004', 'YRLV19', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE005', 'CG04', 'DEPT016', 'Master in Business Administration', 'MBA', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI005', 'CRSE005', 'YRLV19', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE006', 'CG04', 'DEPT016', 'Master in Information Technology', 'MIT', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI006', 'CRSE006', 'YRLV19', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE007', 'CG04', 'DEPT016', 'Master in Public Administration', 'MPA', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI007', 'CRSE007', 'YRLV19', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE008', 'CG04', 'DEPT016', 'Master in Religious Education', 'MARED', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI008', 'CRSE008', 'YRLV19', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE009', 'CG04', 'DEPT016', 'Master of Science in Nursing', 'MSN', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI009', 'CRSE009', 'YRLV19', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE010', 'CG04', 'DEPT016', 'Diploma in Public Management', 'DPM', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI010', 'CRSE010', 'YRLV19', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE011', 'CG03', 'DEPT003', 'Bachelor of Science in Computer Science', 'BSCS', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI011', 'CRSE011', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI012', 'CRSE011', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI013', 'CRSE011', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI014', 'CRSE011', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE012', 'CG03', 'DEPT003', 'Bachelor of Science in Information Technology', 'BSIT', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI015', 'CRSE012', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI016', 'CRSE012', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI017', 'CRSE012', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI018', 'CRSE012', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE013', 'CG03', 'DEPT003', 'Bachelor of Science in Accountancy', 'BSA', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI019', 'CRSE013', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI020', 'CRSE013', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI021', 'CRSE013', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI022', 'CRSE013', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE014', 'CG03', 'DEPT015', 'Bachelor of Science in Nursing', 'BSN', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI023', 'CRSE014', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI024', 'CRSE014', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI025', 'CRSE014', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI026', 'CRSE014', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE015', 'CG03', 'DEPT003', 'Bachelor of Science in Entrepreneurial Management', 'BSEM', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI027', 'CRSE015', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI028', 'CRSE015', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI029', 'CRSE015', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI030', 'CRSE015', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE016', 'CG03', 'DEPT003', 'Bachelor of Science in Tourism', 'BST', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI031', 'CRSE016', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI032', 'CRSE016', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI033', 'CRSE016', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI034', 'CRSE016', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE017', 'CG03', 'DEPT003', 'Bachelor of Science in Hotel and Restaurant Management', 'BSHRM', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI035', 'CRSE017', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI036', 'CRSE017', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI037', 'CRSE017', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI038', 'CRSE017', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE018', 'CG03', 'DEPT003', 'Bachelor of Science in Business Administration', 'BBA', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI039', 'CRSE018', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI040', 'CRSE018', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI041', 'CRSE018', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI042', 'CRSE018', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID001', 'CRSE018', 'Marketing Management', 'MANMAR', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID002', 'CRSE018', 'Human Resource Development Management', 'HRD', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE019', 'CG03', 'DEPT002', 'Bachelor of Arts', 'AB', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI043', 'CRSE019', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI044', 'CRSE019', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI045', 'CRSE019', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI046', 'CRSE019', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID003', 'CRSE019', 'English', 'ENG', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID004', 'CRSE019', 'Filipino', 'FIL', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID005', 'CRSE019', 'Mathematics', 'MATH', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID006', 'CRSE019', 'General Science', 'GEN. SCI.', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID007', 'CRSE019', 'History', 'H', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID008', 'CRSE019', 'Religious Education', 'REL. ED.', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID009', 'CRSE019', 'Physical Education', 'P.E.', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID010', 'CRSE019', 'Psychology', 'PSYCH', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID011', 'CRSE019', 'Mass Communication', 'MASSCOM', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')


INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE020', 'CG03', 'DEPT002', 'Bachelor of Science in Secondary Education', 'BSSED', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI047', 'CRSE020', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI048', 'CRSE020', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI049', 'CRSE020', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI050', 'CRSE020', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID012', 'CRSE020', 'English', 'ENG', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID013', 'CRSE020', 'Filipino', 'FIL', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID014', 'CRSE020', 'Mathematics', 'MATH', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID015', 'CRSE020', 'Biological Science', 'BIO', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID016', 'CRSE020', 'Physical Sciences', 'PHY. SCI.', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID017', 'CRSE020', 'Social Studies', 'SOC. SCI.', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID018', 'CRSE020', 'Values Education', 'VALUES EDU.', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID019', 'CRSE020', 'Music, Arts, P.E., and Health', 'MAPEH', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')


INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE021', 'CG03', 'DEPT002', 'Bachelor of Science in Elementary Education', 'BSEED', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI051', 'CRSE021', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI052', 'CRSE021', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI053', 'CRSE021', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI054', 'CRSE021', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID020', 'CRSE021', 'Special Education', 'SPED', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID021', 'CRSE021', 'General Education', 'GEN. ED.', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_major_information(major_information_id, course_id, course_major_title, acronym, is_still_offered, created_by)
	VALUES ('CMID022', 'CRSE021', 'Pre-School Education', 'PRE-SCH. ED.', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')


INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE022', 'CG03', 'DEPT003', 'Associate in Computer Secretarial', 'ACS', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI055', 'CRSE022', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI056', 'CRSE022', 'YRLV15', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE023', 'CG02', 'DEPT009', 'High School', 'HS', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI057', 'CRSE023', 'YRLV10', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI058', 'CRSE023', 'YRLV11', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI059', 'CRSE023', 'YRLV12', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI060', 'CRSE023', 'YRLV13', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE024', 'CG01', 'DEPT008', 'Grade School', 'GS', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI061', 'CRSE024', 'YRLV04', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI062', 'CRSE024', 'YRLV05', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI063', 'CRSE024', 'YRLV06', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI064', 'CRSE024', 'YRLV07', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI065', 'CRSE024', 'YRLV08', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI066', 'CRSE024', 'YRLV09', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE025', 'CG01', 'DEPT008', 'Kindergarten/Nursery', 'KN', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI067', 'CRSE025', 'YRLV01', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI068', 'CRSE025', 'YRLV02', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI069', 'CRSE025', 'YRLV03', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE026', 'CG03', 'DEPT003', 'Bachelor of Science in Legal Management', 'BSLM', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI070', 'CRSE026', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI071', 'CRSE026', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI072', 'CRSE026', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI073', 'CRSE026', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE027', 'CG03', 'DEPT003', 'Bachelor of Science in Accounting Technology', 'BSAT', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI074', 'CRSE027', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI075', 'CRSE027', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI076', 'CRSE027', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI077', 'CRSE027', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE028', 'CG03', 'DEPT003', 'Bachelor of Science in Management Accounting', 'BSMA', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI078', 'CRSE028', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI079', 'CRSE028', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI080', 'CRSE028', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI081', 'CRSE028', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')

INSERT INTO ums.course_information (course_id, course_group_id, department_id, course_title, acronym, is_still_offered, created_by)
	VALUES ('CRSE029', 'CG03', 'DEPT003', 'Bachelor of Science in Office Administration', 'BSOA', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI082', 'CRSE029', 'YRLV14', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI083', 'CRSE029', 'YRLV15', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI084', 'CRSE029', 'YRLV16', 0, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
INSERT INTO ums.course_year_level (course_year_level_id, course_id, year_level_id, is_graduate_level, created_by)
	VALUES ('CYLI085', 'CRSE029', 'YRLV17', 1, '#Tuy@i*2sz@kUw-2!us%WBxYzwP#')
GO

--major_exam_information
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM001', 'CG03', 'Prelim', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM002', 'CG03', 'Midterm', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM003', 'CG03', 'Pre-Finals', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM004', 'CG03', 'Finals', 1, 1)

INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM005', 'CG01', 'First Grading', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM006', 'CG01', 'Second Grading', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM007', 'CG01', 'Third Grading', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM008', 'CG01', 'Fourth Grading', 1, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM009', 'CG01', 'Monthly Examination', 0, 0)

INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM010', 'CG02', 'First Grading', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM011', 'CG02', 'Second Grading', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM012', 'CG02', 'Third Grading', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM013', 'CG02', 'Fourth Grading', 1, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM014', 'CG02', 'Monthly Examination', 0, 0)

INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM015', 'CG04', 'Prelim', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM016', 'CG04', 'Midterm', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM017', 'CG04', 'Pre-Finals', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM018', 'CG04', 'Finals', 1, 1)

INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM019', 'CG05', 'Prelim', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM020', 'CG05', 'Midterm', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM021', 'CG05', 'Pre-Finals', 0, 1)
INSERT INTO ums.major_exam_information (exam_information_id, course_group_id, exam_description, is_clearance_included, is_one_instance) 
	VALUES ('EXAM022', 'CG05', 'Finals', 1, 1)
GO

--ums.subject_category
INSERT INTO ums.subject_category(category_id, category_name, acronym, category_no)
	SELECT 'CAT001', 'Language and Humanities', 'I', 1
	UNION ALL
	SELECT 'CAT002', 'Comp., Mathematics and Natural Sciences', 'II', 2
	UNION ALL
	SELECT 'CAT003', 'Mandated Courses', 'III', 3
	UNION ALL
	SELECT 'CAT004', 'Social Sciences', 'IV', 4
	UNION ALL
	SELECT 'CAT005', 'Business Education Subjects', 'V', 5
	UNION ALL
	SELECT 'CAT006', 'Professional', 'VI', 6
	UNION ALL
	SELECT 'CAT007', 'Physical Education', 'VII', 7
-- ##########################################END INITIAL DATABASE INFORMATION#############################################################




-- ########################################FOR CODE DEBUGGING########################################################################

-- for classroom_information table
EXECUTE ums.InsertClassroomInformation 'SYSCRM0001', 'CCLA', 'Computer Laboratory A', 40, 'Whiteboard, Aircondition', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertClassroomInformation 'SYSCRM0002', 'CCLB', 'Computer Laboratory B', 30, 'Whiteboard, Aircondition', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertClassroomInformation 'SYSCRM0003', 'CCLC', 'Computer Laboratory C', 26, 'Whiteboard, Aircondition', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
GO

-- for subject_information table
--- GRADESCHOOL AND HIGH SCHOOL
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000001', 'CG02', 'DEPT008', 'English', 'English for Grade 1', 0, 0, '01:20', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000002', 'CG01', 'DEPT008', 'Religion', 'Religion for Grade 1', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000003', 'CG01', 'DEPT008', 'Filipino', 'Filipino for Grade 1', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000004', 'CG01', 'DEPT008', 'Sibika at Kultura', 'Sibika at Kultura for Grade 1', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000005', 'CG01', 'DEPT008', 'Math', 'Math for Grade 1', 0, 0, '01:20', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000006', 'CG01', 'DEPT008', 'Science and Health', 'Science and Health for Grade 1', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000007', 'CG01', 'DEPT008', 'Computer/MAPE', 'Computer/MAPE for Grade 1', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000008', 'CG01', 'DEPT008', 'English', 'English for Grade 2', 0, 0, '01:20', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000009', 'CG01', 'DEPT008', 'Religion', 'Religion for Grade 2', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000010', 'CG01', 'DEPT008', 'Filipino', 'Filipino for Grade 2', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000011', 'CG01', 'DEPT008', 'Sibika at Kultura', 'Sibika at Kultura for Grade 2', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000012', 'CG01', 'DEPT008', 'Math', 'Math for Grade 2', 0, 0, '01:20', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000013', 'CG01', 'DEPT008', 'Science and Health', 'Science and Health for Grade 2', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000014', 'CG01', 'DEPT008', 'Computer/MAPE', 'Computer/MAPE for Grade 2', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000015', 'CG01', 'DEPT008', 'English', 'English for Grade 3', 0, 0, '01:20', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000016', 'CG01', 'DEPT008', 'Religion', 'Religion for Grade 3', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000017', 'CG01', 'DEPT008', 'Filipino', 'Filipino for Grade 3', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000018', 'CG01', 'DEPT008', 'Sibika at Kultura', 'Sibika at Kultura for Grade 3', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000019', 'CG01', 'DEPT008', 'Math', 'Math for Grade 3', 0, 0, '01:20', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000020', 'CG01', 'DEPT008', 'Science and Health', 'Science and Health for Grade 3', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000021', 'CG01', 'DEPT008', 'Computer', 'Computer for Grade 3', 0, 0, '00:30', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000022', 'CG01', 'DEPT008', 'MAPE', 'MAPE for Grade 3', 0, 0, '00:30', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000023', 'CG01', 'DEPT008', 'English', 'English for Grade 4', 0, 0, '01:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000024', 'CG01', 'DEPT008', 'Religion', 'Religion for Grade 4', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000025', 'CG01', 'DEPT008', 'Filipino', 'Filipino for Grade 4', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000026', 'CG01', 'DEPT008', 'Sibika at Kultura', 'Sibika at Kultura for Grade 4', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000027', 'CG01', 'DEPT008', 'Math', 'Math for Grade 4', 0, 0, '01:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000028', 'CG01', 'DEPT008', 'Science and Health', 'Science and Health for Grade 4', 0, 0, '01:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000029', 'CG01', 'DEPT008', 'Computer', 'Computer for Grade 4', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000030', 'CG01', 'DEPT008', 'MAPE', 'MAPE for Grade 4', 0, 0, '00:30', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000031', 'CG01', 'DEPT008', 'HELE', 'HELE for Grade 4', 0, 0, '00:30', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000032', 'CG01', 'DEPT008', 'English', 'English for Grade 5', 0, 0, '01:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000033', 'CG01', 'DEPT008', 'Religion', 'Religion for Grade 5', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000034', 'CG01', 'DEPT008', 'Filipino', 'Filipino for Grade 5', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000035', 'CG01', 'DEPT008', 'Sibika at Kultura', 'Sibika at Kultura for Grade 5', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000036', 'CG01', 'DEPT008', 'Math', 'Math for Grade 5', 0, 0, '01:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000037', 'CG01', 'DEPT008', 'Science and Health', 'Science and Health for Grade 5', 0, 0, '01:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000038', 'CG01', 'DEPT008', 'Computer', 'Computer for Grade 5', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000039', 'CG01', 'DEPT008', 'MAPE', 'MAPE for Grade 5', 0, 0, '00:30', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000040', 'CG01', 'DEPT008', 'HELE', 'HELE for Grade 5', 0, 0, '00:30', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000041', 'CG01', 'DEPT008', 'English', 'English for Grade 6', 0, 0, '01:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000042', 'CG01', 'DEPT008', 'Religion', 'Religion for Grade 6', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000043', 'CG01', 'DEPT008', 'Filipino', 'Filipino for Grade 6', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000044', 'CG01', 'DEPT008', 'Sibika at Kultura', 'Sibika at Kultura for Grade 6', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000045', 'CG01', 'DEPT008', 'Math', 'Math for Grade 6', 0, 0, '01:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000046', 'CG01', 'DEPT008', 'Science and Health', 'Science and Health for Grade 6', 0, 0, '01:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000047', 'CG01', 'DEPT008', 'Computer', 'Computer for Grade 6', 0, 0, '00:40', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000048', 'CG01', 'DEPT008', 'MAPE', 'MAPE for Grade 6', 0, 0, '00:30', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000049', 'CG01', 'DEPT008', 'HELE', 'HELE for Grade 6', 0, 0, '00:30', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000050', 'CG02', 'DEPT009', 'Christian Living I / Values', 'Journey of Faith: Old Testament', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000051', 'CG02', 'DEPT009', 'Filipino I', 'Wika at Panitikan: Ibong Adarna', 0, 0, '04:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000052', 'CG02', 'DEPT009', 'Araling Panlipunan I', 'Philippine History', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000053', 'CG02', 'DEPT009', 'MAPEH I', 'Fundamental of Music, Arts, Physical Educ. and Health', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000054', 'CG02', 'DEPT009', 'English I with SRA', 'The Basic Sentence Patterns and Filipino Literature', 0, 0, '04:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000055', 'CG02', 'DEPT009', 'Science and Technology I', 'General Science', 0, 0, '06:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000056', 'CG02', 'DEPT009', 'Mathematics I', 'Elementary Algebra', 0, 0, '05:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000057', 'CG02', 'DEPT009', 'Technology and Livelihood Education I', 'Technology and Livelihood Educ. Exploratory', 0, 0, '04:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000058', 'CG02', 'DEPT009', 'Christian Living II / Values', 'Encountering Christ', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000059', 'CG02', 'DEPT009', 'Filipino II', 'Wika at Panitikan: Florante at Laura', 0, 0, '04:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000060', 'CG02', 'DEPT009', 'Araling Panlipunan II', 'Asian History', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000061', 'CG02', 'DEPT009', 'MAPEH II', 'Colonial Influences of Philippine Music Fitness and Folk Dancing, Physical & Mental Health', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000062', 'CG02', 'DEPT009', 'English II with SRA', 'Expanded Sentence Patterns and Afro-Asian Literature', 0, 0, '04:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000063', 'CG02', 'DEPT009', 'Science and Technology II', 'Biology', 0, 0, '06:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000064', 'CG02', 'DEPT009', 'Mathematics II', 'Intermediate Algebra', 0, 0, '05:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000065', 'CG02', 'DEPT009', 'Technology and Livelihood Education II', 'Exploratory Home Econ., Entrepreneurship and Computers', 0, 0, '04:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000066', 'CG02', 'DEPT009', 'Christian Living III / Values', 'Christian Morality', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000067', 'CG02', 'DEPT009', 'Filipino III', 'Panitikang Filipino: Noli Me Tangere', 0, 0, '04:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000068', 'CG02', 'DEPT009', 'Araling Panlipunan III', 'World History', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000069', 'CG02', 'DEPT009', 'MAPEH III', 'Asian Music, Arts and Periods in Other Countries Exploring World Dances and Physical Personal Responsibility for Lifelong Health', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000070', 'CG02', 'DEPT009', 'English III with Research', 'Speech and Anglo-American Literature', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000071', 'CG02', 'DEPT009', 'Science and Technology III', 'Chemistry', 0, 0, '06:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000072', 'CG02', 'DEPT009', 'Mathematics III', 'Geometry', 0, 0, '05:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000073', 'CG02', 'DEPT009', 'Technology and Livelihood Education III', 'Basic Computer Programming and Web-Page Designing', 0, 0, '04:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000074', 'CG02', 'DEPT009', 'Christian Living IV / Values', 'The Origin and History of the Church and Discipleship', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000075', 'CG02', 'DEPT009', 'Filipino IV', 'El Filibusteresmo and Wika at Literature', 0, 0, '04:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000076', 'CG02', 'DEPT009', 'Araling Panlipunan IV', 'Economics', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000077', 'CG02', 'DEPT009', 'MAPEH IV / CAT', 'Renaissance-Contemporary Music, Twentieth Century Arts, Lifetime Fitness-Sports and Recreational Activities Family Health', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000078', 'CG02', 'DEPT009', 'English IV with Research', 'Formal Writing and World Classics', 0, 0, '03:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000079', 'CG02', 'DEPT009', 'Science and Technology IV', 'Physics', 0, 0, '06:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000080', 'CG02', 'DEPT009', 'Mathematics IV', 'Advanced Algebra with Statistics and Trigometry', 0, 0, '05:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000081', 'CG02', 'DEPT009', 'Technology and Livelihood Education IV', 'MS Word, MS Powerpoint, and MS Excel', 0, 0, '04:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

-- COLLEGE (CBED)
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000082', 'CG03', 'DEPT003', 'ITE 001', 'IT Fundamentals with Lab', 3, 2, '00:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000083', 'CG03', 'DEPT003', 'ITE 002', 'Program Logic Formulation and Flowcharting with Lab', 3, 2, '00:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

-- COLLEGE (CAED)
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000084', 'CG03', 'DEPT002', 'Soc. Sci. 101', 'General Psychology', 3, 0, '00:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000085', 'CG03', 'DEPT002', 'Philo 102', 'Philo of Man', 3, 0, '00:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000086', 'CG03', 'DEPT002', 'Eng 106', 'World Literature', 3, 0, '00:00', '', 0, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

-- CHRISTIAN FORMATION OFFICE (CFO)
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000087', 'CG03', 'DEPT011', 'Rel. Ed. 1a', 'Faith and Revelation', 3, 0, '00:00', '', 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000088', 'CG03', 'DEPT011', 'Rel. Ed. 1b', 'Christology', 3, 0, '00:00', '', 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000089', 'CG03', 'DEPT011', 'Rel. Ed. 2a', 'The Church', 3, 0, '00:00', '', 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
EXECUTE ums.InsertSubjectInformation 'SYSSBJ000090', 'CG03', 'DEPT011', 'Rel. Ed. 2b', 'Sacraments', 3, 0, '00:00', '', 1, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

GO

--CREATE PROCEDURE ums.InsertSpecialClassInformation
--
--	@sysid_special varchar (50) = '',
--	@sysid_subject varchar (50) = '',
--	@sysid_employee varchar (50) = '',
--	@year_id varchar (50) = '',
--	@sysid_semester varchar (50) = '',
--	@is_semestral bit = 0,
--	@amount decimal (12, 2) = 0,
--
--	@network_information varchar (MAX) = '',
--	@created_by varchar (50) = ''	

--EXECUTE ums.InsertSpecialClassInformation 'SYSSPC000001', 'SYSSBJ000001', 'SYSEMP005', 'SY20082009', NULL, 5000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertSpecialClassInformation 'SYSSPC000002', 'SYSSBJ000002', 'SYSEMP003', NULL, 'SYSSEM0025', 5000.00, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO

--CREATE PROCEDURE ums.InsertSpecialClassLoad
--
--	@sysid_special varchar (50) = '',
--	@sysid_student varchar (50) = '',
--
--	@network_information varchar (MAX) = '',
--	@created_by varchar (50) = ''	

--EXECUTE ums.InsertSpecialClassLoad 'SYSSPC000001', 'SYSSTD000001', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertSpecialClassLoad 'SYSSPC000001', 'SYSSTD000002', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO

--CREATE PROCEDURE ums.DeleteSpecialClassInformation
--
--	@sysid_special varchar (50) = '',
--	
--	@network_information varchar (MAX) = '',
--	@deleted_by varchar (50) = ''	

--EXECUTE ums.DeleteSpecialClassInformation 'SYSSPC000001', 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--GO

-- ########################################END FOR CODE DEBUGGING########################################################################



