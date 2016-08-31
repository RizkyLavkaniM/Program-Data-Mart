USE [db_kertas_dm]
GO

/****** Object:  Table [dbo].[fact_retur]    Script Date: 8/26/2016 5:20:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[fact_retur](
	[no_faktur] [varchar](10) NOT NULL,
	[id_waktu] [int] NOT NULL,
	[id_kertas] [int] NOT NULL,
	[quantum] [float] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[fact_retur]  WITH CHECK ADD  CONSTRAINT [FK_fact_retur_dim_kertas] FOREIGN KEY([id_kertas])
REFERENCES [dbo].[dim_kertas] ([id_kertas])
GO

ALTER TABLE [dbo].[fact_retur] CHECK CONSTRAINT [FK_fact_retur_dim_kertas]
GO

ALTER TABLE [dbo].[fact_retur]  WITH CHECK ADD  CONSTRAINT [FK_fact_retur_dim_penjualan] FOREIGN KEY([no_faktur])
REFERENCES [dbo].[dim_penjualan] ([no_faktur])
GO

ALTER TABLE [dbo].[fact_retur] CHECK CONSTRAINT [FK_fact_retur_dim_penjualan]
GO

ALTER TABLE [dbo].[fact_retur]  WITH CHECK ADD  CONSTRAINT [FK_fact_retur_dim_waktu] FOREIGN KEY([id_waktu])
REFERENCES [dbo].[dim_waktu] ([id_waktu])
GO

ALTER TABLE [dbo].[fact_retur] CHECK CONSTRAINT [FK_fact_retur_dim_waktu]
GO


