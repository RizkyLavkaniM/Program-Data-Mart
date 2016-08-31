USE [db_kertas_dm]
GO

/****** Object:  Table [dbo].[dim_waktu]    Script Date: 8/26/2016 5:19:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[dim_waktu](
	[id_waktu] [int] IDENTITY(1,1) NOT NULL,
	[tanggal] [int] NOT NULL,
	[bulan] [int] NOT NULL,
	[bulan_nama] [nvarchar](50) NOT NULL,
	[tahun] [int] NOT NULL,
	[full_date] [date] NOT NULL,
 CONSTRAINT [PK_dim_waktu] PRIMARY KEY CLUSTERED 
(
	[id_waktu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


