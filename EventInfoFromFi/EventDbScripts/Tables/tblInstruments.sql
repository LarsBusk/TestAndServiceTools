USE [FiEvents]
GO

/****** Object:  Table [dbo].[Instruments]    Script Date: 12-11-2020 11:04:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Instruments](
	[InstrumentId] [int] IDENTITY(1,1) NOT NULL,
	[WorkstationName] [nvarchar](50) NOT NULL,
	[InstrumentTypeId] [int] NOT NULL,
	[ChassisID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Instruments] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Instruments]  WITH CHECK ADD  CONSTRAINT [FK_Instruments_InstrumentTypes] FOREIGN KEY([InstrumentTypeId])
REFERENCES [dbo].[InstrumentTypes] ([InstrumentTypeID])
GO

ALTER TABLE [dbo].[Instruments] CHECK CONSTRAINT [FK_Instruments_InstrumentTypes]
GO


