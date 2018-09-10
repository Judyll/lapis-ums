/********************************************************/
/* This SQL Statements is used for the St. Paul			*/
/* 		University UMS									*/
/*Programmed by: Judyll Mark T. Agan					*/
/*Date created: March 30, 2007							*/
/********************************************************/

USE db_umsdev_03_30_2007
GO

-- ###################################################DATABASE SCHEMA, LOGINS, USERS, ROLES#############################################################
-- Drop a schema
IF EXISTS (SELECT * FROM sys.schemas WHERE NAME = 'ums')
BEGIN
	DROP SCHEMA ums
END
GO
---------------------------------------------

-- Drop a role
IF EXISTS (SELECT * FROM sys.database_principals WHERE TYPE IN ('R') AND NAME = 'db_umsusers')
BEGIN
--	ALTER AUTHORIZATION ON SCHEMA::db_denydatareader TO db_denydatareader
--	ALTER AUTHORIZATION ON SCHEMA::db_denydatawriter TO db_denydatawriter
	EXEC sp_droprolemember db_umsusers, x$wIsQ@Um$r073U$er
	DROP ROLE db_umsusers
END
GO
--------------------------------------------

-- Drop a user
IF EXISTS (SELECT * FROM sys.database_principals WHERE TYPE IN ('S') AND NAME = 'x$wIsQ@Um$r073U$er') 
BEGIN
	DROP USER x$wIsQ@Um$r073U$er
END
GO
---------------------------------------------------

-- Drop a login
IF EXISTS (SELECT * FROM sys.server_principals WHERE TYPE IN ('S', 'U', 'G') AND NAME = 'Um$D3vL06in0408C4ak47@x')
BEGIN
	DROP LOGIN Um$D3vL06in0408C4ak47@x
END
GO
----------------------------------------------------

-- Create a login
CREATE LOGIN Um$D3vL06in0408C4ak47@x
	WITH PASSWORD = '8RjM#s_qW6XiU&^xz4',
	DEFAULT_DATABASE = db_umsdev_03_30_2007
GO
--------------------------------

-- Create a user exclusive for the current login
CREATE USER x$wIsQ@Um$r073U$er FOR LOGIN Um$D3vL06in0408C4ak47@x WITH DEFAULT_SCHEMA = ums
GO
----------------------------------------------

-- Create a schema assigning it to a user
CREATE SCHEMA ums AUTHORIZATION x$wIsQ@Um$r073U$er
GO
------------------------------------------------

-- Create a role for the authorized user
CREATE ROLE db_umsusers AUTHORIZATION x$wIsQ@Um$r073U$er
GO
------------------------------------------------

-- Adds a role member for the created role
EXEC sp_addrolemember db_denydatareader, db_umsusers
EXEC sp_addrolemember db_denydatawriter, db_umsusers
EXEC sp_addrolemember db_umsusers, x$wIsQ@Um$r073U$er
GO

-- system views
SELECT * FROM sys.server_principals WHERE TYPE IN ('S', 'U', 'G') AND NAME = 'Um$D3vL06in0408C4ak47@x'
SELECT * FROM sys.database_principals WHERE TYPE IN ('S', 'U', 'G') AND NAME = 'x$wIsQ@Um$r073U$er'
SELECT * FROM sys.database_principals WHERE TYPE IN ('R') AND NAME = 'db_umsusers'
SELECT * FROM sys.schemas
GO

SELECT * FROM sys.master_files
SELECT * FROM sys.servers
SELECT * FROM tempdb..sysobjects
GO
-- ###################################################END DATABASE SCHEMA, LOGINS, USERS, ROLES#######################################################