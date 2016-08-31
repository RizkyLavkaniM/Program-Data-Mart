USE [db_kertas_oltp]
GO

/****** Object:  Table [dbo].[tbl_sppk]    Script Date: 8/26/2016 5:17:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_sppk](
	[no_sppk] [varchar](10) NOT NULL,
	[tgl_sppk] [date] NOT NULL,
	[quantum] [float] NOT NULL,
 CONSTRAINT [PK_tbl_sppk] PRIMARY KEY CLUSTERED 
(
	[no_sppk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


