--******************************************************--
-- This SQL Statements is used for the St. Paul			--
-- 		University UMS									--
--Programmed by: Judyll Mark T. Agan					--
--Date created: April 01, 2007							--
--FINANCE SOLUTIONS STUDENT OBJECTS [ 4 ]				--
--******************************************************--

USE db_umsdev_03_30_2007
GO

-- ###########################################DROP TABLE CONSTRAINTS ##############################################################


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

--verifies if the Student_Image_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_image', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_image
	DROP CONSTRAINT Student_Image_SysID_Student_FK
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

-- ########################################END DROP TABLE CONSTRAINTS ##############################################################



-- ########################################DROP DEPENDENT TABLE CONSTRAINTS ##############################################################

--verifies if the Special_Class_Load_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.special_class_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_load
	DROP CONSTRAINT Special_Class_Load_SysID_Student_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Course_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_course', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_course
	DROP CONSTRAINT Student_Enrolment_Course_SysID_Student_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Payments_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_payments', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_payments
	DROP CONSTRAINT Student_Payments_SysID_Student_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Reimbursements_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_reimbursements', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_reimbursements
	DROP CONSTRAINT Student_Reimbursements_SysID_Student_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Credit_Memo_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_credit_memo', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_credit_memo
	DROP CONSTRAINT Student_Credit_Memo_SysID_Student_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Balance_Forwarded_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_balance_forwarded', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_balance_forwarded
	DROP CONSTRAINT Student_Balance_Forwarded_SysID_Student_FK
END
GO
-----------------------------------------------------

--verifies if the Student_Promissory_Note_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_promissory_note', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_promissory_note
	DROP CONSTRAINT Student_Promissory_Note_SysID_Student_FK
END
GO
-----------------------------------------------------

--verifies if the Miscellaneous_Income_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.miscellaneous_income', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.miscellaneous_income
	DROP CONSTRAINT Miscellaneous_Income_SysID_Student_FK
END
GO
-----------------------------------------------------

-- ########################################END DROP DEPENDENT TABLE CONSTRAINTS ##############################################################





-- ##########################################TABLE "student_information" OBJECTS########################################################

-- verifies if the student_information table exists
IF OBJECT_ID('ums.student_information', 'U') IS NOT NULL
	DROP TABLE ums.student_information
GO
---------------------------------------------------- 

-- creates the table "student_information"
CREATE TABLE ums.student_information 			
(
	sysid_student varchar (50) NOT NULL 
		CONSTRAINT Student_Information_SysID_Student_PK PRIMARY KEY (sysid_student)
		CONSTRAINT Student_Information_SysID_Student_CK CHECK (sysid_student LIKE 'SYSSTD%'),
	student_id varchar (50) NOT NULL
		CONSTRAINT Student_Information_Student_ID_UQ UNIQUE (student_id),
	card_number varchar (50) NULL DEFAULT (''),	

	scholarship varchar (50) NULL DEFAULT (''),
	is_international bit NOT NULL DEFAULT (0),
	is_no_downpayment_required bit NOT NULL DEFAULT (0),
	other_student_information varchar (MAX) NULL,	
	
	has_hs_card bit NOT NULL DEFAULT (0),
	has_hon_dismissal bit NOT NULL DEFAULT (0),
	has_tor bit NOT NULL DEFAULT (0),
	has_good_moral bit NOT NULL DEFAULT (0),
	has_birth_cert bit NOT NULL DEFAULT (0),
	has_marriage_contract bit NOT NULL DEFAULT (0),
	has_latest_photo bit NOT NULL DEFAULT (0),
	has_ncae_result bit NOT NULL DEFAULT (0),
	
	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Student_Information_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Student_Information_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Student_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the student_information table 
CREATE INDEX Student_Information_SysID_Student_Index
	ON ums.student_information (sysid_student DESC)
GO
------------------------------------------------------------------

-- #################################################END TABLE "student_information" OBJECTS########################################################



-- ######################################RESTORE DEPENDENT TABLE CONSTRAINTS#############################################################

--verifies if the Special_Class_Load_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.special_class_load', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.special_class_load WITH NOCHECK
	ADD CONSTRAINT Special_Class_Load_SysID_Student_FK FOREIGN KEY (sysid_student) REFERENCES ums.student_information(sysid_student) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Enrolment_Course_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_enrolment_course', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_enrolment_course WITH NOCHECK
	ADD CONSTRAINT Student_Enrolment_Course_SysID_Student_FK FOREIGN KEY (sysid_student) REFERENCES ums.student_information(sysid_student) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Payments_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_payments', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_payments WITH NOCHECK
	ADD CONSTRAINT Student_Payments_SysID_Student_FK FOREIGN KEY (sysid_student) REFERENCES ums.student_information(sysid_student) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Reimbursements_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_reimbursements', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_reimbursements WITH NOCHECK
	ADD CONSTRAINT Student_Reimbursements_SysID_Student_FK FOREIGN KEY (sysid_student) REFERENCES ums.student_information(sysid_student) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Credit_Memo_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_credit_memo', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_credit_memo WITH NOCHECK
	ADD CONSTRAINT Student_Credit_Memo_SysID_Student_FK FOREIGN KEY (sysid_student) REFERENCES ums.student_information(sysid_student) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Balance_Forwarded_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_balance_forwarded', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_balance_forwarded WITH NOCHECK
	ADD CONSTRAINT Student_Balance_Forwarded_SysID_Student_FK FOREIGN KEY (sysid_student) REFERENCES ums.student_information(sysid_student) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Student_Promissory_Note_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.student_promissory_note', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.student_promissory_note WITH NOCHECK
	ADD CONSTRAINT Student_Promissory_Note_SysID_Student_FK FOREIGN KEY (sysid_student) REFERENCES ums.student_information(sysid_student) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

--verifies if the Miscellaneous_Income_SysID_Student_FK constraint exists
IF OBJECT_ID('ums.miscellaneous_income', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.miscellaneous_income WITH NOCHECK
	ADD CONSTRAINT Miscellaneous_Income_SysID_Student_FK FOREIGN KEY (sysid_student) REFERENCES ums.student_information(sysid_student) ON UPDATE NO ACTION
END
GO
-----------------------------------------------------

-- ######################################END RESTORE DEPENDENT TABLE CONSTRAINTS#############################################################






-- ########################################FOR CODE DEBUGGING########################################################################


-- for student_information table

--EXECUTE ums.InsertStudentInformation 'SYSSTD000001', 'S2006-2342', '03423C23', 'CRSE001', NULL, 'Unassigned', 'Unassigned', 'Unassigned', 'PES', NULL, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertStudentInformation 'SYSSTD000002', 'S2006-2623', '923423D2', 'CRSE002', NULL, 'Public', 'Administration', 'Doctor', NULL, NULL, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertStudentInformation 'SYSSTD000003', 'M2006-0023', '26234723', 'CRSE003', NULL, 'Business', 'Administration', 'Doctor', NULL, NULL, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'
--EXECUTE ums.InsertStudentInformation 'SYSSTD000004', 'M2001-1023', '62382342', 'CRSE004', NULL, 'Education', 'Doctor', 'Doctor', NULL, NULL, NULL, 'Judyll''s Network', '#Tuy@i*2sz@kUw-2!us%WBxYzwP#'

GO

-- ########################################END FOR CODE DEBUGGING########################################################################
