USE [DexterJitterData]
GO

/****** Object:  Table [dbo].[TestSetup]    Script Date: 12-02-2024 11:40:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TestSetup](
	[TestSetupId] [int] IDENTITY(1,1) NOT NULL,
	[NoraVersion] [nvarchar](max) NOT NULL,
	[TestTime] [datetime2](7) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[CsvFileName] [nvarchar](max) NULL,
	[ExcludeFromSummary] [bit] NOT NULL,
	[PlatformVersion] [nvarchar](50) NOT NULL,
	[TestSystemId] [int] NOT NULL,
	[PhysicalPC] [bit] NOT NULL,
	[TimeCorrection] [int] NULL,
 CONSTRAINT [PK_dbo.TestSetup] PRIMARY KEY CLUSTERED 
(
	[TestSetupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [dbo].[TestSetup] ADD  DEFAULT ((0)) FOR [PhysicalPC]
GO

ALTER TABLE [dbo].[TestSetup]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TestSetup_dbo.TestSystem_TestSystemId] FOREIGN KEY([TestSystemId])
REFERENCES [dbo].[TestSystem] ([TestSystemId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[TestSetup] CHECK CONSTRAINT [FK_dbo.TestSetup_dbo.TestSystem_TestSystemId]
GO


