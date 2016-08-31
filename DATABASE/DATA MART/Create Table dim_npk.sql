USE [db_kertas_dm]
GO

/****** Object:  Table [dbo].[dim_npk]    Script Date: 8/26/2016 5:19:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[dim_npk](
	[no_npk] [varchar](10) NOT NULL,
	[no_kendaraan] [varchar](20) NULL,
 CONSTRAINT [PK_dim_npk] PRIMARY KEY CLUSTERED 
(
	[no_npk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


