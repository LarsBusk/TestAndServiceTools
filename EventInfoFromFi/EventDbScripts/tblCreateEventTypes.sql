/****** Script for SelectTopNRows command from SSMS  ******/
Create Table EventTypes
(		EventTypeId int Primary Key
	,	DeviceId int
	,	ShortModuleName varchar(16)
	,	ErrorCode int
	,	ErrorText nvarchar(255)
	,	HintText nvarchar(255)
) 