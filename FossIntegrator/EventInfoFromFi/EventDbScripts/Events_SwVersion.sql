/****** Script for SelectTopNRows command from SSMS  ******/
With e as
(
	Select		SwVersion
			--,	ev.EventTextId
			,	Max(ety.EventTypeName) [EventType]
			,	Max(et.EventCode) [EventCode]
			,	Sum(ev.Count) [NumberOfEvents]
			,	Max(et.EventText) [EventText]		
	From		Events ev
	Inner Join	EventReport er
		on		er.ReportId = ev.ReportId
	Inner Join	EventTexts et
		on		et.EventTextId = ev.EventTextId
	Inner Join	EventTypes ety 
		on		ety.EventTypeID = ev.EventType
	Group By	ev.EventTextId, er.SwVersion
)
Select		*
		,	ROW_NUMBER()  Over (Partition By SwVersion, EventType Order By NumberOfEvents Desc) [Row]
From e

Order By SwVersion, EventType, NumberOfEvents Desc


