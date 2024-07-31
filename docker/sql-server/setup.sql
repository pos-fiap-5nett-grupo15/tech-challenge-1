/*

Enter custom T-SQL here that would run after SQL Server has started up. 

*/



CREATE DATABASE tech_1;
GO

USE tech_1;
GO

CREATE LOGIN svc_con_mngt
WITH PASSWORD = '${SVC_PASS}';
GO

CREATE USER svc_con_mngt
FOR LOGIN svc_con_mngt;
GO

USE tech_1;
GO

EXEC sp_addrolemember 'db_datareader', 'svc_con_mngt';
GO
EXEC sp_addrolemember 'db_datawriter', 'svc_con_mngt';
GO

CREATE SCHEMA ContactsManagement;
GO

CREATE TABLE ContactsManagement.Contacts
(
	Id INT
);
