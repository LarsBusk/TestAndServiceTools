With s as
(
Select		SwVersion
		,	EventCode
		,	Max(EventText) as [EventText]
		,	Sum(Eventcount) as Total
		,	ROW_NUMBER() over (Partition By SwVersion Order by Sum(Eventcount) Desc) as RowN
From		dbo.GetAllEvents()
Group By	SwVersion, EventCode
)
Select	SwVersion
	,	EventCode
	,	EventText
	,	Total
	,	RowN
From	s
Where	RowN < 11
Order By	SwVersion, RowN