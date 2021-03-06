USE [DSD_AUTOSVC]
GO
/****** Object:  Table [dbo].[UsuarioPerfil]    Script Date: 01/24/2016 22:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioPerfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Perfil] [varchar](50) NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_UsuarioPerfil_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[UsuarioPerfil] ADD  CONSTRAINT [DF_UsuarioPerfil_activo]  DEFAULT ((1)) FOR [Activo]
GO
