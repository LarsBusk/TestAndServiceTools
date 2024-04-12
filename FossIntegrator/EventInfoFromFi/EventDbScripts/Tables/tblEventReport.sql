USE [FiEvents]
GO

/****** Object:  Table [dbo].[EventReport]    Script Date: 12-11-2020 11:02:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventReport](
	[ReportId] [int] IDENTITY(1,1) NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[SwVersion] [nchar](20) NOT NULL,
	[SamplesInPeriod] [int] NOT NULL,
	[SamplesTotal] [int] NOT NULL,
	[CountryId] [int] NULL,
	[CompanyId] [int] NULL,
 CONSTRAINT [PK_EventReport] PRIMARY KEY CLUSTERED 
(
	[ReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EventReport]  WITH CHECK ADD  CONSTRAINT [FK_EventReport_Instruments] FOREIGN KEY([InstrumentId])
REFERENCES [dbo].[Instruments] ([InstrumentId])
GO

ALTER TABLE [dbo].[EventReport] CHECK CONSTRAINT [FK_EventReport_Instruments]
GO


