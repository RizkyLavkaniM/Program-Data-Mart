USE [db_kertas_dm]
GO

/****** Object:  Table [dbo].[dim_konsumen]    Script Date: 8/26/2016 5:19:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dim_konsumen](
	[id_konsumen] [int] NOT NULL,
	[nama_konsumen] [varchar](50) NOT NULL,
 CONSTRAINT [PK_dim_konsumen] PRIMARY KEY CLUSTERED 
(
	[id_konsumen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


