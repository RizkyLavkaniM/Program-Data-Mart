USE [db_kertas_oltp]
GO

/****** Object:  Table [dbo].[tbl_detail_penjualan]    Script Date: 8/26/2016 5:15:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_detail_penjualan](
	[id_detail_penjualan] [int] IDENTITY(1,1) NOT NULL,
	[no_faktur] [varchar](10) NOT NULL,
	[id_kertas] [int] NOT NULL,
	[ukuran] [varchar](20) NOT NULL,
	[gramatur] [int] NOT NULL,
	[jumlah] [int] NOT NULL,
	[satuan] [varchar](5) NOT NULL,
	[quantum] [float] NOT NULL,
	[harga] [float] NOT NULL,
 CONSTRAINT [PK_tbl_detail_penjualan] PRIMARY KEY CLUSTERED 
(
	[id_detail_penjualan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


