Select		Count(*) as Intakes
		,	ResultType
		,	Cast(ResultTime as date) as ResultDate
From		Results
Where		ResultTime > DATEADD(MONTH, -3, GETDATE())
	and		ResultSubType = 0
Group By	Cast(ResultTime as date), ResultType