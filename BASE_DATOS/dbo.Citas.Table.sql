USE [DSD_AUTOSVC]
GO
/****** Object:  Table [dbo].[Citas]    Script Date: 01/24/2016 22:08:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Citas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCita] [varchar](50) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Fecha] [varchar](10) NOT NULL,
	[HoraInicio] [datetime] NOT NULL,
	[HoraFinal] [datetime] NULL,
	[IdVehiculo] [int] NOT NULL,
	[IdServicio] [int] NOT NULL,
	[IdTaller] [int] NOT NULL,
	[Observacion] [varchar](250) NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Citas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Servicios] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicios] ([Id])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Servicios]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Talleres] FOREIGN KEY([IdTaller])
REFERENCES [dbo].[Talleres] ([Id])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Talleres]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Usuarios]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Vehiculo] FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[Vehiculos] ([Id])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Vehiculo]
GO
ALTER TABLE [dbo].[Citas] ADD  DEFAULT ((1)) FOR [Estado]
GO
