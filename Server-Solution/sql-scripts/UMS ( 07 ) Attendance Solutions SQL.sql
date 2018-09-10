--******************************************************--
-- This SQL Statements is used for the St. Paul			--
-- 		University UMS									--
--Programmed by: Judyll Mark T. Agan					--
--Date created: April 01, 2007							--
--ATTENDANCE SOLUTIONS [ 7 ]							--
--******************************************************--

USE db_umsdev_03_30_2007
GO

-- ###########################################TABLE CONSTRAINTS OBJECTS##############################################################
--verifies if the Campus_Access_Details_Access_Point_ID_FK constraint exists
IF OBJECT_ID('ums.campus_access_details', 'U') IS NOT NULL
BEGIN
	ALTER TABLE ums.campus_access_details
	DROP CONSTRAINT Campus_Access_Details_Access_Point_ID_FK
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
-- ########################################END TABLE CONSTRAINTS OBJECTS##############################################################




-- #########################################DROP DEPENDENT TABLE CONSTRAINTS ############################################################
-- ##########################################END DROP DEPENDENT TABLE CONSTRAINTS ############################################################




-- ################################################TABLE "access_point_information" OBJECTS######################################################
-- verifies if the access_point_information table existss
IF OBJECT_ID('ums.access_point_information', 'U') IS NOT NULL
	DROP TABLE ums.access_point_information
GO

CREATE TABLE ums.access_point_information 			
(
	access_point_id varchar (50) NOT NULL 
		CONSTRAINT Access_Point_Information_Access_Point_ID_PK PRIMARY KEY (access_point_id)
		CONSTRAINT Access_Point_Information_Access_Point_ID_CK CHECK (access_point_id LIKE 'APID%'),
	access_description varchar (100) NOT NULL
		CONSTRAINT Access_Point_Information_Access_Description_UQ UNIQUE (access_description),

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Access_Point_Information_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
--------------------------------------------------------

-- create an index of the access_point_information table 
CREATE INDEX Access_Point_Information_Access_Point_ID_Index
	ON ums.access_point_information (access_point_id ASC)
GO
------------------------------------------------------------------

-- verifies that the trigger "Access_Point_Information_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Access_Point_Information_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Access_Point_Information_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Access_Point_Information_Trigger_Instead_Update
	ON  ums.access_point_information
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update an access point information', 'Access Point Information'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Access_Point_Information_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Access_Point_Information_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Access_Point_Information_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Access_Point_Information_Trigger_Instead_Delete
	ON  ums.access_point_information
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete an access point information', 'Access Point Information'
	
GO
-------------------------------------------------------------------------

-- verifies if the procedure "SelectAccessPointInformation" exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_SCHEMA = N'ums' AND SPECIFIC_NAME = N'SelectAccessPointInformation')
   DROP PROCEDURE ums.SelectAccessPointInformation
GO

CREATE PROCEDURE ums.SelectAccessPointInformation
	
	@system_user_id varchar(50) = ''
	
AS

	IF ums.IsActiveSystemUserInfo(@system_user_id) = 1
	BEGIN
		
		SELECT
			api.access_point_id AS access_point_id,
			api.access_description AS access_description
		FROM
			ums.access_point_information AS api
		ORDER BY
			access_description ASC

	END
	ELSE
	BEGIN
		EXECUTE ums.ShowErrorMsg 'Query an access point information', 'Access Point Information'
	END
	
GO
---------------------------------------------------------

-- grant permission on the stored procedure
GRANT EXECUTE ON ums.SelectAccessPointInformation TO db_umsusers
GO
-------------------------------------------------------------

-- ##############################################END TABLE "access_point_information" OBJECTS######################################################




-- ################################################TABLE "campus_access_details" OBJECTS######################################################
-- verifies if the campus_access_details table exists
IF OBJECT_ID('ums.campus_access_details', 'U') IS NOT NULL
	DROP TABLE ums.campus_access_details
GO

CREATE TABLE ums.campus_access_details 			
(
	details_id bigint NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION
		CONSTRAINT Campus_Access_Details_Details_ID_PK PRIMARY KEY (details_id),
	access_date_time datetime NOT NULL DEFAULT (GETDATE()),
	access_point_id varchar (50) NOT NULL
		CONSTRAINT Campus_Access_Details_Access_Point_ID_FK FOREIGN KEY REFERENCES ums.access_point_information(access_point_id) ON UPDATE NO ACTION,

	created_on datetime NOT NULL DEFAULT (GETDATE()),
	created_by varchar (50) NOT NULL
		CONSTRAINT Campus_Access_Details_Created_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,
	
	edited_on datetime NULL,
	edited_by varchar (50) NULL	
		CONSTRAINT Campus_Access_Details_Edited_By_FK FOREIGN KEY REFERENCES ums.system_user_info(system_user_id) ON UPDATE NO ACTION,

	unique_id uniqueidentifier ROWGUIDCOL NOT NULL DEFAULT NEWSEQUENTIALID()
		CONSTRAINT Campus_Access_Details_Unique_ID_UQ UNIQUE (unique_id)
	
) ON [PRIMARY]
GO
------------------------------------------------------------------

-- create an index of the campus_access_details table 
CREATE INDEX Campus_Access_Details_Details_ID_Index
	ON ums.campus_access_details (details_id DESC)
GO
------------------------------------------------------------------

-- verifies that the trigger "Campus_Access_Details_Trigger_Instead_Update" already exist
IF OBJECT_ID ('ums.Campus_Access_Details_Trigger_Instead_Update','TR') IS NOT NULL
   DROP TRIGGER ums.Campus_Access_Details_Trigger_Instead_Update
GO

CREATE TRIGGER ums.Campus_Access_Details_Trigger_Instead_Update
	ON  ums.campus_access_details
	INSTEAD OF UPDATE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Update a campus access details', 'Campus Access Details'
	
GO
-------------------------------------------------------------------------

-- verifies that the trigger "Campus_Access_Details_Trigger_Instead_Delete" already exist
IF OBJECT_ID ('ums.Campus_Access_Details_Trigger_Instead_Delete','TR') IS NOT NULL
   DROP TRIGGER ums.Campus_Access_Details_Trigger_Instead_Delete
GO

CREATE TRIGGER ums.Campus_Access_Details_Trigger_Instead_Delete
	ON  ums.campus_access_details
	INSTEAD OF DELETE
	NOT FOR REPLICATION
AS 

	EXECUTE ums.ShowErrorMsg 'Delete a campus access details', 'Campus Access Details'
	
GO
-------------------------------------------------------------------------


-- ##############################################END TABLE "campus_access_details" OBJECTS######################################################





-- ######################################RESTORE DEPENDENT TABLE CONSTRAINTS#############################################################
-- ######################################END RESTORE DEPENDENT TABLE CONSTRAINTS#############################################################



-- ############################################INITIAL DATABASE INFORMATION#############################################################

--ums.access_point_information	REF: CommonExchange.AccessPoint
INSERT INTO ums.access_point_information(access_point_id, access_description)
	SELECT 'APID001', 'Gate 01'
	UNION ALL
	SELECT 'APID002', 'Gate 02'
	UNION ALL
	SELECT 'APID003', 'Gate 03'
GO
-- ##########################################END INITIAL DATABASE INFORMATION#############################################################



-- ########################################FOR CODE DEBUGGING########################################################################
-- ########################################END FOR CODE DEBUGGING####################################################################


