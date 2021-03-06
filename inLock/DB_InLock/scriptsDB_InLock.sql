USE [DB_InLock]
GO
/****** Object:  Table [dbo].[TBL_Estudio]    Script Date: 03/03/2020 22:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Estudio](
	[IdEstudio] [int] IDENTITY(1,1) NOT NULL,
	[NomeEstudio] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstudio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Jogo]    Script Date: 03/03/2020 22:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Jogo](
	[IdJogo] [int] IDENTITY(1,1) NOT NULL,
	[NomeJogo] [varchar](200) NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
	[DataLancamento] [date] NOT NULL,
	[Valor] [real] NOT NULL,
	[FK_IdEstudio] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdJogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_TipoUsuario]    Script Date: 03/03/2020 22:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_TipoUsuario](
	[IdTipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[TituloTipoUsuario] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Usuario]    Script Date: 03/03/2020 22:32:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[Senha] [varchar](20) NOT NULL,
	[FK_IdTipoUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TBL_Jogo]  WITH CHECK ADD FOREIGN KEY([FK_IdEstudio])
REFERENCES [dbo].[TBL_Estudio] ([IdEstudio])
GO
ALTER TABLE [dbo].[TBL_Usuario]  WITH CHECK ADD FOREIGN KEY([FK_IdTipoUsuario])
REFERENCES [dbo].[TBL_TipoUsuario] ([IdTipoUsuario])
GO
