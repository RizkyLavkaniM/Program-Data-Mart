USE [db_kertas_oltp]
GO

/****** Object:  Table [dbo].[tbl_retur]    Script Date: 8/26/2016 5:17:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_retur](
	[id_retur] [int] IDENTITY(1,1) NOT NULL,
	[no_faktur] [varchar](10) NOT NULL,
	[tgl_retur] [date] NOT NULL,
	[quantum] [float] NOT NULL,
 CONSTRAINT [PK_tbl_retur] PRIMARY KEY CLUSTERED 
(
	[id_retur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


