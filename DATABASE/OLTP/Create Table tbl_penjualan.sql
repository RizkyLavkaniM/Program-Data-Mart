USE [db_kertas_oltp]
GO

/****** Object:  Table [dbo].[tbl_penjualan]    Script Date: 8/26/2016 5:16:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tbl_penjualan](
	[no_faktur] [varchar](10) NOT NULL,
	[id_konsumen] [int] NOT NULL,
	[tgl_transaksi] [date] NOT NULL,
	[tgl_pengiriman] [date] NULL,
	[quantum] [float] NOT NULL,
	[subtotal] [float] NOT NULL,
	[total] [float] NOT NULL,
 CONSTRAINT [PK_tbl_penjualan] PRIMARY KEY CLUSTERED 
(
	[no_faktur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


