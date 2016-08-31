USE [db_kertas_dm]
GO

/****** Object:  Table [dbo].[fact_npk]    Script Date: 8/26/2016 5:19:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[fact_npk](
	[no_npk] [varchar](10) NOT NULL,
	[id_waktu] [int] NOT NULL,
	[quantum] [float] NOT NULL,
	[no_faktur] [varchar](10) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[fact_npk]  WITH CHECK ADD  CONSTRAINT [FK_fact_npk_dim_npk] FOREIGN KEY([no_npk])
REFERENCES [dbo].[dim_npk] ([no_npk])
GO

ALTER TABLE [dbo].[fact_npk] CHECK CONSTRAINT [FK_fact_npk_dim_npk]
GO

ALTER TABLE [dbo].[fact_npk]  WITH CHECK ADD  CONSTRAINT [FK_fact_npk_dim_penjualan] FOREIGN KEY([no_faktur])
REFERENCES [dbo].[dim_penjualan] ([no_faktur])
GO

ALTER TABLE [dbo].[fact_npk] CHECK CONSTRAINT [FK_fact_npk_dim_penjualan]
GO

ALTER TABLE [dbo].[fact_npk]  WITH CHECK ADD  CONSTRAINT [FK_fact_npk_dim_waktu] FOREIGN KEY([id_waktu])
REFERENCES [dbo].[dim_waktu] ([id_waktu])
GO

ALTER TABLE [dbo].[fact_npk] CHECK CONSTRAINT [FK_fact_npk_dim_waktu]
GO


