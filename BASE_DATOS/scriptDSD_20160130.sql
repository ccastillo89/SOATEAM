USE [DSD_AUTOSVC]
GO
/****** Object:  Table [dbo].[UsuarioPerfil]    Script Date: 01/30/2016 02:29:40 ******/
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
SET IDENTITY_INSERT [dbo].[UsuarioPerfil] ON
INSERT [dbo].[UsuarioPerfil] ([Id], [Perfil], [Activo]) VALUES (1, N'ADMINISTRADOR', 1)
INSERT [dbo].[UsuarioPerfil] ([Id], [Perfil], [Activo]) VALUES (2, N'CLIENTE', 1)
SET IDENTITY_INSERT [dbo].[UsuarioPerfil] OFF
/****** Object:  Table [dbo].[Talleres]    Script Date: 01/30/2016 02:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Talleres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TallerNro] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Taller] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Talleres] ON
INSERT [dbo].[Talleres] ([Id], [TallerNro]) VALUES (1, N'TALLER NRO 1')
INSERT [dbo].[Talleres] ([Id], [TallerNro]) VALUES (2, N'TALLER NRO 2')
INSERT [dbo].[Talleres] ([Id], [TallerNro]) VALUES (3, N'TALLER NRO 3')
SET IDENTITY_INSERT [dbo].[Talleres] OFF
/****** Object:  Table [dbo].[Servicios]    Script Date: 01/30/2016 02:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Servicios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Valor] [numeric](18, 2) NOT NULL,
	[Duracion] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Servicios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Servicios] ON
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (3, N'AFINAMIENTO MOTOR COMP.CAT.', CAST(270.00 AS Numeric(18, 2)), 7, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (4, N'AFINAMIENTO MOTOR COMP.CONV.', CAST(204.00 AS Numeric(18, 2)), 4, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (5, N'CHEQUEO AFINAMIENTO', CAST(315.00 AS Numeric(18, 2)), 16, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (6, N'BAJAR GASES', CAST(297.00 AS Numeric(18, 2)), 13, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (7, N'REPARACION DISTRIB-COMP', CAST(306.00 AS Numeric(18, 2)), 5, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (8, N'AJUSTE MOTOR', CAST(133.00 AS Numeric(18, 2)), 22, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (9, N'CAMBIO ANILLO Y EMPAQ, COMP.', CAST(339.00 AS Numeric(18, 2)), 10, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (10, N'CAMBIO ANILLOS MOTOR PUESTO', CAST(207.00 AS Numeric(18, 2)), 1, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (11, N'DESCARBONIZADO MOTOR', CAST(313.00 AS Numeric(18, 2)), 22, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (12, N'ALINEACION', CAST(297.00 AS Numeric(18, 2)), 18, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (13, N'REPARACION COMP.TREN DELANTERO', CAST(325.00 AS Numeric(18, 2)), 0, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (14, N'CUADRATURA TREN DELANTERO', CAST(153.00 AS Numeric(18, 2)), 17, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (15, N'REPARACION CAJA CAMBIOS', CAST(246.00 AS Numeric(18, 2)), 17, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (16, N'CAMBIO CONJ.EMBRAGUE COMPLETO', CAST(213.00 AS Numeric(18, 2)), 23, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (17, N'REPARAR DIFERENCIAL', CAST(355.00 AS Numeric(18, 2)), 22, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (18, N'REPARACION FRENOS COMP.', CAST(256.00 AS Numeric(18, 2)), 17, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (19, N'REV-LIMP-REGULACION FRENOS', CAST(324.00 AS Numeric(18, 2)), 22, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (20, N'CAMBIO PASTILLAS DE FRENO', CAST(167.00 AS Numeric(18, 2)), 0, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (21, N'CAMBIO FUELLES HOMOCINETICOS', CAST(227.00 AS Numeric(18, 2)), 1, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (22, N'CAMBIO RODAMIENTO DEL.DOBLE', CAST(138.00 AS Numeric(18, 2)), 19, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (23, N'CAMBIO RODAMIENTO DEL.MUÑON', CAST(189.00 AS Numeric(18, 2)), 9, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (24, N'CAMBIO RODAMIENTO TRAS.EJE', CAST(225.00 AS Numeric(18, 2)), 9, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (25, N'CAMBIO RODAMIENTO TRAS.MUÑON', CAST(214.00 AS Numeric(18, 2)), 14, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (26, N'CAMBIO ACEITE CAJA O DIFERENCIAL', CAST(203.00 AS Numeric(18, 2)), 5, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (27, N'CAMBIO ACEITE Y FILTRO', CAST(247.00 AS Numeric(18, 2)), 9, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (28, N'REPARAR ALTERNADOR', CAST(266.00 AS Numeric(18, 2)), 23, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (29, N'REPARAR MOTOR PARTIDA', CAST(316.00 AS Numeric(18, 2)), 15, 1)
INSERT [dbo].[Servicios] ([Id], [Descripcion], [Valor], [Duracion], [Estado]) VALUES (30, N'REPARACIONES ELECTRICAS EN GENER', CAST(303.00 AS Numeric(18, 2)), 19, 1)
SET IDENTITY_INSERT [dbo].[Servicios] OFF
/****** Object:  Table [dbo].[Modelos]    Script Date: 01/30/2016 02:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Modelos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Modelo] [varchar](50) NULL,
	[IdMarca] [int] NULL,
 CONSTRAINT [PK_Modelo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Modelos] ON
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (1, N'Acura ILX', 1)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (2, N'Alfa Romeo Giulietta', 1)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (3, N'Audi A3', 2)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (4, N'BMW Serie 1', 14)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (5, N'BMW Serie 2', 14)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (6, N'Buick Verano', 3)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (7, N'BYD F3', 4)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (8, N'Chevrolet Cobalt', 3)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (9, N'Chevrolet Optra', 3)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (10, N'Chevrolet Cruze', 3)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (11, N'Chevrolet Volt (Híbrido)', 3)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (12, N'Citroën C4', 9)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (13, N'Citroën C-Elysée', 11)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (14, N'Citroën DS4', 21)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (15, N'Citroën DS5', 21)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (16, N'Dodge Dart', 21)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (17, N'Fiat Linea', 5)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (18, N'Ford Focus S', 6)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (19, N'Honda Civic', 7)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (20, N'Honda FIT EXL', 7)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (21, N'Honda Insight (Híbrido)', 7)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (22, N'Hyundai Elantra', 8)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (23, N'Hyundai i30', 8)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (24, N'Kia Cee''d', 10)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (25, N'Kia Cerato/Forte/K3', 10)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (26, N'Lada Priora', 5)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (27, N'Lancia Delta', 6)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (28, N'Lexus CT', 12)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (29, N'Mazda 3', 13)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (30, N'Mercedes-Benz Clase A', 14)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (31, N'Mercedes-Benz Clase CLA', 14)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (32, N'Mitsubishi Lancer', 15)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (33, N'Nissan Leaf (Eléctrico)', 16)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (34, N'Nissan Sentra', 16)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (35, N'Nissan Tiida/Pulsar', 16)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (36, N'Nissan Versa', 16)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (37, N'Opel Ampera (Híbrido)', 17)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (38, N'Opel Astra', 17)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (39, N'Peugeot 301', 18)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (40, N'Peugeot 308', 18)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (41, N'Peugeot 408', 18)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (42, N'Qoros 3', 19)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (43, N'Renault Fluence', 20)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (44, N'Renault Mégane', 20)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (45, N'SEAT León', 22)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (46, N'SEAT Toledo', 22)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (47, N'Škoda Octavia', 23)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (48, N'Škoda Rapid', 23)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (49, N'Subaru Impreza', 24)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (50, N'Suzuki SX4', 25)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (51, N'Tebo Skobodi', 26)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (52, N'Toyota Auris', 26)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (53, N'Toyota Corolla', 26)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (54, N'Volkswagen Eos', 27)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (55, N'Volkswagen Golf', 27)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (56, N'Volkswagen Jetta', 27)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (57, N'Volkswagen New Beetle', 27)
INSERT [dbo].[Modelos] ([Id], [Modelo], [IdMarca]) VALUES (58, N'Volvo V40', 28)
SET IDENTITY_INSERT [dbo].[Modelos] OFF
/****** Object:  Table [dbo].[Marcas]    Script Date: 01/30/2016 02:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marcas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [varchar](50) NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (1, N'ASTON MARTIN')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (2, N'AUDI')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (3, N'CHEVROLET')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (4, N'FERRARI')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (5, N'FIAT')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (6, N'FORD')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (7, N'HONDA')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (8, N'HYUNDAI')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (9, N'JEEP')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (10, N'KIA')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (11, N'LAMBORGHINI')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (12, N'LEXUS')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (13, N'MAZDA')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (14, N'MERCEDES')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (15, N'MITSUBISHI')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (16, N'NISSAN')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (17, N'OPEL')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (18, N'PEUGEOT')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (19, N'PORSCHE')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (20, N'RENAULT')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (21, N'ROLLS-ROYCE')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (22, N'SEAT')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (23, N'SSANGYONG')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (24, N'SUBARU')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (25, N'SUZUKI')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (26, N'TOYOTA')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (27, N'VOLKSWAGEN')
INSERT [dbo].[Marcas] ([Id], [Marca]) VALUES (28, N'VOLVO')
SET IDENTITY_INSERT [dbo].[Marcas] OFF
/****** Object:  Table [dbo].[Colores]    Script Date: 01/30/2016 02:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Colores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Color] [varchar](50) NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Colores] ON
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (1, N'Beige verdoso')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (2, N'Beige')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (3, N'Amarillo arena')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (4, N'Amarillo señales')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (5, N'Amarillo oro')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (6, N'Amarillo miel')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (7, N'Amarillo maiz')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (8, N'Amarillo narciso')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (9, N'Beige pardo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (10, N'Amarillo limón')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (11, N'Blanco perla')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (12, N'Marfil')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (13, N'Marfil claro')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (14, N'Amarillo azufre')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (15, N'Amarillo azafrán')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (16, N'Amarillo de zinc')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (17, N'Beige agrisado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (18, N'Amarillo oliva')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (19, N'Amarillo colza')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (20, N'Amarillo tráfico')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (21, N'Amarillo ocre')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (22, N'Amarillo brillante')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (23, N'Amarillo curry')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (24, N'Amarillo melón')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (25, N'Amarillo retama')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (26, N'Amarillo dalia')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (27, N'Amarillo pastel')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (28, N'Beige perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (29, N'Oro perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (30, N'Amarillo sol')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (31, N'Amarillo naranja')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (32, N'Rojo anaranjado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (33, N'Naranja sanguineo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (34, N'Naranja pálido')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (35, N'Naranja puro')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (36, N'Naranja brillante')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (37, N'Naranja claro brillante')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (38, N'Rojo claro anaranjado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (39, N'Naranja tráfico')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (40, N'Naranja señales')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (41, N'Naranja intenso')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (42, N'Naranja salmón')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (43, N'Naranja perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (44, N'Rojo vivo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (45, N'Rojo señales')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (46, N'Rojo carmin')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (47, N'Rojo rubí')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (48, N'Rojo purpura')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (49, N'Rojo vino')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (50, N'Rojo negruzco')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (51, N'Rojo óxido')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (52, N'Rojo pardo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (53, N'Rojo beige')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (54, N'Rojo tomate')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (55, N'Rojo viejo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (56, N'Rosa claro')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (57, N'Rojo coral')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (58, N'Rosa')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (59, N'Rojo fresa')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (60, N'Rojo tráfico')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (61, N'Rojo salmón')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (62, N'Rojo brillante')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (63, N'Rojo claro brillante')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (64, N'Rojo frambuesa')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (65, N'Rojo puro')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (66, N'Rojo oriente')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (67, N'Rojo rubí perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (68, N'Rosa perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (69, N'Rojo lila')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (70, N'Rojo violeta')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (71, N'Violeta érica')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (72, N'Burdeos')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (73, N'Lila azulado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (74, N'Púrpurá tráfico')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (75, N'Violeta púrpura')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (76, N'Violeta señales')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (77, N'Violeta pastel')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (78, N'Magenta tele')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (79, N'Violeta perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (80, N'Morado perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (81, N'Azul violeta')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (82, N'Azul verdoso')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (83, N'Azul ultramar')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (84, N'Azul zafiro')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (85, N'Azul negruzco')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (86, N'Azul señales')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (87, N'Azul brillante')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (88, N'Azul grisáceo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (89, N'Azul azur')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (90, N'Azul genciana')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (91, N'Azul acero')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (92, N'Azul luminoso')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (93, N'Azul cobalto')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (94, N'Azul olombino')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (95, N'Azul celeste')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (96, N'Azul tráfico')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (97, N'Azul turquesa')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (98, N'Azul capri')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (99, N'Azul oceano')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (100, N'Azul agua')
GO
print 'Processed 100 total records'
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (101, N'Azul noche')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (102, N'Azul lejanía')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (103, N'Azul pastel')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (104, N'Gencian perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (105, N'Azul noche perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (106, N'Verde patina')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (107, N'Verde esmeralda')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (108, N'Verde hoja')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (109, N'Verde oliva')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (110, N'Verde azulado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (111, N'Verde musgo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (112, N'Oliva grisáceo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (113, N'Verde botella')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (114, N'Verde parduzco')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (115, N'Verde abeto')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (116, N'Verde hierba')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (117, N'Verde reseda')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (118, N'Verde negruzco')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (119, N'Verde caña')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (120, N'Amarillo oliva')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (121, N'Oliva negruzco')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (122, N'Verde turquesa')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (123, N'Verde mayo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (124, N'Verde amarillento')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (125, N'Verde lanquecino')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (126, N'Verde cromo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (127, N'Verde pálido')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (128, N'Oliva parduzco')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (129, N'Verde tráfico')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (130, N'Verde helecho')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (131, N'Verde opalo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (132, N'Verde luminoso')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (133, N'Verde pino')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (134, N'Verde menta')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (135, N'Verde señales')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (136, N'Turquesa menta')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (137, N'Turquesa pastel')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (138, N'Verde perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (139, N'Verde ópalo perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (140, N'Verde puro')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (141, N'Verde brillante')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (142, N'Gris ardilla')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (143, N'Gris plata')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (144, N'Gris oliva')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (145, N'Gris musgo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (146, N'Gris señales')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (147, N'Gris ratón')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (148, N'Gris beige')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (149, N'Gris caqui')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (150, N'Gris verdoso')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (151, N'Gris lona')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (152, N'Gris hierro')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (153, N'Gris basalto')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (154, N'Gris parduzco')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (155, N'Gris pizarra')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (156, N'Gris antracita')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (157, N'Gris negruzco')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (158, N'Gris sombra')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (159, N'Gris hormigón')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (160, N'Gris grafita')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (161, N'Gris granito')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (162, N'Gris piedra')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (163, N'Gris azulado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (164, N'Gris guijarro')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (165, N'Gris cemento')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (166, N'Gris amarillento')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (167, N'Gris luminoso')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (168, N'Gris platino')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (169, N'Gris polvo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (170, N'Gris ágata')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (171, N'Gris cuarzo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (172, N'Gris ventana')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (173, N'Gris tráfico A')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (174, N'Gris tráfico B')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (175, N'Gris seda')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (176, N'Gris tele 1')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (177, N'Gris tele 2')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (178, N'Gris tele 4')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (179, N'Gris musgo perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (180, N'Pardo verdoso')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (181, N'Pardo ocre')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (182, N'Marrón señales')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (183, N'Pardo arcilla')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (184, N'Pardo cobre')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (185, N'Pardo corzo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (186, N'Pardo oliva')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (187, N'Pardo nuez')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (188, N'Pardo rojo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (189, N'Sepia')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (190, N'Castaño')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (191, N'Caoba')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (192, N'Chocolate')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (193, N'Pardo grisáceo')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (194, N'Pardo negruzco')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (195, N'Pardo anaranjado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (196, N'Pardo beige')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (197, N'Pardo pálido')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (198, N'Marrón tierra')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (199, N'Cobre perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (200, N'Blanco crema')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (201, N'Blanco grisáceo')
GO
print 'Processed 200 total records'
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (202, N'Blanco señales')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (203, N'Negro señales')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (204, N'Negro intenso')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (205, N'Aluminio blanco')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (206, N'Aluminio gris')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (207, N'Blanco puro')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (208, N'Negro grafito')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (209, N'Blanco tráfico')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (210, N'Negro tráfico')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (211, N'Blanco papiro')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (212, N'Gris claro perlado')
INSERT [dbo].[Colores] ([Id], [Color]) VALUES (213, N'Gris oscuro perlado')
SET IDENTITY_INSERT [dbo].[Colores] OFF
/****** Object:  Table [dbo].[Vehiculos]    Script Date: 01/30/2016 02:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vehiculos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Placa] [char](7) NULL,
	[IdMarca] [int] NOT NULL,
	[IdModelo] [int] NOT NULL,
	[KM] [int] NULL,
	[IdColor] [int] NULL,
	[Anio] [int] NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 01/30/2016 02:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Usuario] [varchar](30) NOT NULL,
	[Dni] [char](8) NOT NULL,
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
SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [Telefono], [Correo], [Usuario], [Dni], [Password], [Activo], [PerfilID]) VALUES (1, N'Carlos', N'Castillo', N'91440830', N'carlos@gmail.com', N'CCASTILLO', N'45792116', N'123', 1, 1)
INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [Telefono], [Correo], [Usuario], [Dni], [Password], [Activo], [PerfilID]) VALUES (2, N'Miguel', N'Matos', N'991440830', N'miguel@gmail.com', N'mmastos', N'46859674', N'123', 1, 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  Table [dbo].[Citas]    Script Date: 01/30/2016 02:29:40 ******/
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
/****** Object:  Default [DF__Citas__Estado__40C49C62]    Script Date: 01/30/2016 02:29:40 ******/
ALTER TABLE [dbo].[Citas] ADD  DEFAULT ((1)) FOR [Estado]
GO
/****** Object:  Default [DF_UsuarioPerfil_activo]    Script Date: 01/30/2016 02:29:40 ******/
ALTER TABLE [dbo].[UsuarioPerfil] ADD  CONSTRAINT [DF_UsuarioPerfil_activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Usuarios_Activo]    Script Date: 01/30/2016 02:29:40 ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  ForeignKey [FK_Citas_Servicios]    Script Date: 01/30/2016 02:29:40 ******/
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Servicios] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicios] ([Id])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Servicios]
GO
/****** Object:  ForeignKey [FK_Citas_Talleres]    Script Date: 01/30/2016 02:29:40 ******/
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Talleres] FOREIGN KEY([IdTaller])
REFERENCES [dbo].[Talleres] ([Id])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Talleres]
GO
/****** Object:  ForeignKey [FK_Citas_Usuarios]    Script Date: 01/30/2016 02:29:40 ******/
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Usuarios]
GO
/****** Object:  ForeignKey [FK_Citas_Vehiculo]    Script Date: 01/30/2016 02:29:40 ******/
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Vehiculo] FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[Vehiculos] ([Id])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Vehiculo]
GO
/****** Object:  ForeignKey [FK_Usuario_UsuarioPerfil]    Script Date: 01/30/2016 02:29:40 ******/
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_UsuarioPerfil] FOREIGN KEY([PerfilID])
REFERENCES [dbo].[UsuarioPerfil] ([Id])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuario_UsuarioPerfil]
GO
/****** Object:  ForeignKey [FK_Vehiculos_Colores]    Script Date: 01/30/2016 02:29:40 ******/
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_Colores] FOREIGN KEY([IdColor])
REFERENCES [dbo].[Colores] ([Id])
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_Colores]
GO
/****** Object:  ForeignKey [FK_Vehiculos_Marcas]    Script Date: 01/30/2016 02:29:40 ******/
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_Marcas] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marcas] ([Id])
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_Marcas]
GO
/****** Object:  ForeignKey [FK_Vehiculos_Modelos]    Script Date: 01/30/2016 02:29:40 ******/
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_Modelos] FOREIGN KEY([IdModelo])
REFERENCES [dbo].[Modelos] ([Id])
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_Modelos]
GO
