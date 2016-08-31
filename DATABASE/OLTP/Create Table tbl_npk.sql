USE [db_kertas_oltp]
GO

/****** Object:  Table [dbo].[tbl_npk]    Script Date: 8/26/2016 5:16:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_npk](
	[no_npk] [varchar](10) NOT NULL,
	[tgl_npk] [date] NOT NULL,
	[quantum] [float] NOT NULL,
	[no_kendaraan] [varchar](20) NULL,
 CONSTRAINT [PK_tbl_npk] PRIMARY KEY CLUSTERED 
(
	[no_npk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


