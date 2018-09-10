/********************************************************/
/* This SQL Statements is used for the St. Paul			*/
/* 		University UMS									*/
/*Programmed by: Judyll Mark T. Agan					*/
/*Date created: March 30, 2007							*/
/********************************************************/


-- ###################################################DATABASE SCHEMA, LOGINS, USERS, ROLES#############################################################

-- Drop a login
IF EXISTS (SELECT * FROM sys.server_principals WHERE TYPE IN ('S', 'U', 'G') AND NAME = 'Um$D3vL06in0408C4ak47@x')
BEGIN
	DROP LOGIN Um$D3vL06in0408C4ak47@x
END
GO
----------------------------------------------------

USE db_umsdev_03_30_2007
GO

-- Create a login
CREATE LOGIN Um$D3vL06in0408C4ak47@x
	WITH PASSWORD = '8RjM#s_qW6XiU&^xz4',
	DEFAULT_DATABASE = db_umsdev_03_30_2007
GO
--------------------------------

-- Alter a user exclusive for the current login
ALTER USER x$wIsQ@Um$r073U$er WITH LOGIN = Um$D3vL06in0408C4ak47@x
GO
----------------------------------------------

-- ###################################################END DATABASE SCHEMA, LOGINS, USERS, ROLES#######################################################