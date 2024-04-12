Select		ErrorTime		
		,	ShortDeviceName
		,	ShortModuleName
		,	ErrorCode
		,	ErrorText
--		,	*
From		Error
Where		ErrorTypeID In (3,4,5)
	and		ErrorTime > DATEADD(MONTH, -3, GETDATE())