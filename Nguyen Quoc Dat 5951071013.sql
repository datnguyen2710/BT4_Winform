USE [NguyenQuocDat_5951071013]
GO
/****** Object:  Table [dbo].[StudentsTb]    Script Date: 3/22/2021 3:29:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentsTb](
	[StudentsID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[FatherName] [varchar](50) NULL,
	[RollNumber] [varchar](50) NULL,
	[ADDRESS] [varchar](50) NULL,
	[Mobile] [varchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
