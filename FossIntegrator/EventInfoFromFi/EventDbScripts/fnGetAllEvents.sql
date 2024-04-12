USE [FiEvents]
GO

/****** Object:  UserDefinedFunction [dbo].[GetAllEvents]    Script Date: 16-11-2021 12:04:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER FUNCTION [dbo].[GetAllEvents] 
(
)
RETURNS TABLE 
AS
RETURN 
(
	Select		er.SwVersion
		,	er.StartDateTime
		,	er.EndDateTime
		,	er.SamplesInPeriod
		,	ins.ChassisID
		,	ins.WorkstationName
		,	ity.[Name] as InstrumentType
		,	cou.CountryName as Country
		,	co.CompanyName as Company
		,	et.EventCode
		,	et.EventText
		,	et.Instrument
		,	ety.EventTypeName as EventType
		,	ev.[Count] as EventCount
		--,	*
From		EventReport er
Inner Join	Countries cou
	on		cou.CountryId = er.CountryId
Inner Join	Companies co
	on		co.CompanyId = er.CompanyId
Inner Join	Events ev
	on		ev.ReportId = er.ReportId
Inner Join	EventTexts et
	on		et.EventTextId = ev.EventTextId
Inner Join	EventTypes ety
	on		ety.EventTypeID = ev.EventType
Inner Join	Instruments ins
	on		er.InstrumentId = ins.InstrumentId
Inner Join	InstrumentTypes ity
	on		ity.InstrumentTypeID = ins.InstrumentTypeId
)
GO


