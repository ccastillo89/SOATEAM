USE [DSD_AUTOSVC]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 01/18/2016 01:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Usuario] [varchar](30) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Activo] [bit] NOT NULL,
	[PerfilID] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_UsuarioPerfil] FOREIGN KEY([PerfilID])
REFERENCES [dbo].[UsuarioPerfil] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_UsuarioPerfil]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuarios_Activo]  DEFAULT ((1)) FOR [Activo]
GO
