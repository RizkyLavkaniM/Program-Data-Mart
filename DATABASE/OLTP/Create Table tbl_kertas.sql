USE [db_kertas_oltp]
GO

/****** Object:  Table [dbo].[tbl_kertas]    Script Date: 8/26/2016 5:15:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_kertas](
	[id_kertas] [int] IDENTITY(1,1) NOT NULL,
	[jenis_kertas] [varchar](50) NOT NULL,
	[harga_kertas] [int] NOT NULL,
 CONSTRAINT [PK_tbl_barang] PRIMARY KEY CLUSTERED 
(
	[id_kertas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


