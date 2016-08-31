USE [db_kertas_dm]
GO

/****** Object:  Table [dbo].[dim_penjualan]    Script Date: 8/26/2016 5:19:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dim_penjualan](
	[no_faktur] [varchar](10) NOT NULL,
	[id_konsumen] [int] NOT NULL,
 CONSTRAINT [PK_dim_penjualan] PRIMARY KEY CLUSTERED 
(
	[no_faktur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[dim_penjualan]  WITH CHECK ADD  CONSTRAINT [FK_dim_penjualan_dim_konsumen] FOREIGN KEY([id_konsumen])
REFERENCES [dbo].[dim_konsumen] ([id_konsumen])
GO

ALTER TABLE [dbo].[dim_penjualan] CHECK CONSTRAINT [FK_dim_penjualan_dim_konsumen]
GO


