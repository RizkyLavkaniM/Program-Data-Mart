USE [db_kertas_oltp]
GO

/****** Object:  Table [dbo].[tbl_konsumen]    Script Date: 8/26/2016 5:16:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_konsumen](
	[id_konsumen] [int] IDENTITY(1,1) NOT NULL,
	[nama_konsumen] [varchar](50) NOT NULL,
	[alamat_konsumen] [varchar](100) NULL,
	[no_telepon] [varchar](15) NULL,
 CONSTRAINT [PK_tbl_konsumen] PRIMARY KEY CLUSTERED 
(
	[id_konsumen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


