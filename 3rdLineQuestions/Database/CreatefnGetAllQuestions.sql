
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION GetAllQuestions()
RETURNS TABLE 
AS
RETURN 
(
	Select	q.QuestionTime
	,	ed.[Name] as Duration
	,	ek.[Name] as [Department]
	From Questions q
	Inner Join Enums ed
	On q.Duration = ed.[Value] and ed.Kind = 'Duration'
	Inner Join Enums ek
	On q.Kind = ek.[Value] and ek.Kind = 'Kind'
)
GO
