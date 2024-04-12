USE [FiEvents]
GO

/****** Object:  Table [dbo].[Events]    Script Date: 12-11-2020 11:02:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[EventType] [int] NOT NULL,
	[EventTextId] [int] NOT NULL,
	[ReportId] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventReport] FOREIGN KEY([ReportId])
REFERENCES [dbo].[EventReport] ([ReportId])
GO

ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventReport]
GO

ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventTexts] FOREIGN KEY([EventTextId])
REFERENCES [dbo].[EventTexts] ([EventTextId])
GO

ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventTexts]
GO

ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventTypes] FOREIGN KEY([EventType])
REFERENCES [dbo].[EventTypes] ([EventTypeID])
GO

ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventTypes]
GO


