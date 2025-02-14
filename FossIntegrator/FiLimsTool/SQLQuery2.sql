Declare @JobsToDelete Table (JobIndex int, ID int)

Insert Into @JobsToDelete
Select JobIndex, ID
From Jobs
Where ComponentIndex In (1446, 1452)

Delete From JobSampleFields
Where JobID In (Select ID From @JobsToDelete)

Delete From JobExtensionData 
Where JobIndex In (