USE [db_kertas_oltp]
GO

/****** Object:  Table [dbo].[tbl_detail_npk]    Script Date: 8/26/2016 5:14:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_detail_npk](
	[id_detail_npk] [int] IDENTITY(1,1) NOT NULL,
	[no_sppk] [varchar](10) NOT NULL,
	[no_npk] [varchar](10) NOT NULL,
	[no_faktur] [varchar](10) NOT NULL,
	[no_pabrikasi] [varchar](20) NULL,
 CONSTRAINT [PK_tbl_detail_npk] PRIMARY KEY CLUSTERED 
(
	[id_detail_npk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


