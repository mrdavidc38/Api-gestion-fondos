--ejecutar esta linea sola
USE [master]


--ejecutar esta linea sola
CREATE DATABASE [ELCLIENTE]


--ejecutar esta linea sola
use  [ELCLIENTE]


--ejecutar las tablas juntas
CREATE TABLE [dbo].[cliente](
	[cli_id] [int] IDENTITY(1,1) NOT NULL,
	[cli_nombre] [varchar](100) NOT NULL,
	[cli_apellidos] [varchar](100) NOT NULL,
	[cli_ciudad] [varchar](100) NOT NULL,
	[cli_monto] [money] NULL
) ON [PRIMARY]


CREATE TABLE [dbo].[disponibilidad](
	[dis_idsucursal] [int] NOT NULL,
	[dis_idproducto] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[dis_idsucursal] ASC,
	[dis_idproducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[inscripcion](
	[ins_idproducto] [int] NOT NULL,
	[ins_idcliente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ins_idproducto] ASC,
	[ins_idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[producto](
	[prod_id] [int] NOT NULL,
	[prod_nombre] [varchar](100) NOT NULL,
	[prod_tipoproducto] [varchar](100) NOT NULL,
	[prod_monto_minimo] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[prod_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[sucursal](
	[suc_id] [int] NOT NULL,
	[suc_nombre] [varchar](100) NOT NULL,
	[suc_ciudad] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[suc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[transacciones_inscripcion](
	[tr_id] [int] IDENTITY(1,1) NOT NULL,
	[tr_idcliente] [int] NOT NULL,
	[tr_idproducto] [int] NOT NULL,
	[tr_accion] [varchar](20) NOT NULL,
	[tr_fechatransaccion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[visitan](
	[vis_idsucursal] [int] NOT NULL,
	[vis_idcliente] [int] NOT NULL,
	[vis_fechavisita] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[vis_idsucursal] ASC,
	[vis_idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
----------------------

--ejecutar los insert juntos---------------
INSERT [dbo].[cliente] ( [cli_nombre], [cli_apellidos], [cli_ciudad], [cli_monto]) VALUES ( N'prueba administrador', N'admin', N'Pereira', 425000.0000)
INSERT [dbo].[cliente] ( [cli_nombre], [cli_apellidos], [cli_ciudad], [cli_monto]) VALUES ( N'prueba', N'prueba', N'string', 500000.0000)


INSERT [dbo].[disponibilidad] ([dis_idsucursal], [dis_idproducto]) VALUES (1, 1)

INSERT [dbo].[inscripcion] ([ins_idproducto], [ins_idcliente]) VALUES (1, 1)

INSERT [dbo].[producto] ([prod_id], [prod_nombre], [prod_tipoproducto], [prod_monto_minimo]) VALUES (1, N'FPV_EL CLIENTE_RECAUDADORA', N'FPV', 75000.0000)
INSERT [dbo].[producto] ([prod_id], [prod_nombre], [prod_tipoproducto], [prod_monto_minimo]) VALUES (2, N'FPV_EL CLIENTE_ECOPETROL', N'FPV', 125000.0000)
INSERT [dbo].[producto] ([prod_id], [prod_nombre], [prod_tipoproducto], [prod_monto_minimo]) VALUES (3, N'DEUDAPRIVADA', N'FIC', 50000.0000)
INSERT [dbo].[producto] ([prod_id], [prod_nombre], [prod_tipoproducto], [prod_monto_minimo]) VALUES (4, N'FDO-ACCIONES', N'FIC', 250000.0000)
INSERT [dbo].[producto] ([prod_id], [prod_nombre], [prod_tipoproducto], [prod_monto_minimo]) VALUES (5, N'FPV_EL CLIENTE_DINAMICA', N'FPV', 100000.0000)

INSERT [dbo].[sucursal] ([suc_id], [suc_nombre], [suc_ciudad]) VALUES (1, N'prueba', N'prueba')



INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES (3, 1, N'INSERT', CAST(N'2025-04-22T09:24:38.870' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES (3, 1, N'Delete', CAST(N'2025-04-22T09:59:25.977' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES (3, 1, N'Delete', CAST(N'2025-04-22T10:50:33.857' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES (3, 1, N'Delete', CAST(N'2025-04-22T10:58:51.220' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES (3, 1, N'Delete', CAST(N'2025-04-22T11:03:34.737' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES (3, 1, N'Delete', CAST(N'2025-04-22T11:27:26.003' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 1, N'Delete', CAST(N'2025-04-22T11:30:06.067' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 1, N'Delete', CAST(N'2025-04-22T11:31:26.520' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 1, N'Delete', CAST(N'2025-04-22T11:35:53.483' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 1, N'Delete', CAST(N'2025-04-22T11:37:37.843' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 1, N'Delete', CAST(N'2025-04-22T11:42:18.843' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 1, N'Delete', CAST(N'2025-04-22T11:46:31.783' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 1, N'Delete', CAST(N'2025-04-22T12:02:18.487' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 2, N'Insertar', CAST(N'2025-04-22T12:33:03.097' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 1, N'Delete', CAST(N'2025-04-22T12:41:05.053' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 2, N'Delete', CAST(N'2025-04-22T12:47:45.577' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 2, N'Insertar', CAST(N'2025-04-22T12:48:51.830' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 2, N'Delete', CAST(N'2025-04-22T12:49:25.953' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 3, N'Insertar', CAST(N'2025-04-23T08:47:05.593' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 4, N'Insertar', CAST(N'2025-04-23T08:54:51.727' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 5, N'Insertar', CAST(N'2025-04-23T08:56:14.293' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 4, N'Insertar', CAST(N'2025-04-23T09:09:02.137' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 5, N'Insertar', CAST(N'2025-04-23T09:10:44.867' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 3, N'Insertar', CAST(N'2025-04-23T09:12:12.107' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 3, N'Insertar', CAST(N'2025-04-23T09:14:19.933' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 4, N'Insertar', CAST(N'2025-04-23T09:42:53.773' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 5, N'Insertar', CAST(N'2025-04-23T09:44:29.547' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 3, N'Insertar', CAST(N'2025-04-23T09:50:54.957' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 5, N'Insertar', CAST(N'2025-04-23T09:52:15.467' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 1, N'Delete', CAST(N'2025-04-23T10:10:55.807' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 3, N'Delete', CAST(N'2025-04-23T10:11:30.517' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 5, N'Delete', CAST(N'2025-04-23T10:11:41.580' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 2, 2, N'Delete', CAST(N'2025-04-23T10:11:42.870' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 1, N'Desvinculado', CAST(N'2025-04-23T10:37:47.383' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 1, N'Vinculado', CAST(N'2025-04-23T10:58:19.487' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 2, N'Vinculado', CAST(N'2025-04-23T10:58:37.713' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 3, N'Vinculado', CAST(N'2025-04-23T10:58:40.520' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 4, N'Vinculado', CAST(N'2025-04-23T10:58:44.660' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 1, N'Desvinculado', CAST(N'2025-04-23T11:02:16.523' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 2, N'Desvinculado', CAST(N'2025-04-23T11:02:17.957' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 3, N'Desvinculado', CAST(N'2025-04-23T11:02:18.963' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 4, N'Desvinculado', CAST(N'2025-04-23T11:02:20.237' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 1, N'Vinculado', CAST(N'2025-04-23T11:02:29.393' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 2, N'Vinculado', CAST(N'2025-04-24T20:52:56.837' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 3, 2, N'Desvinculado', CAST(N'2025-04-24T20:53:05.450' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 2, N'Vinculado', CAST(N'2025-04-24T21:00:08.460' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 2, N'Desvinculado', CAST(N'2025-04-24T21:00:11.533' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 1, N'Desvinculado', CAST(N'2025-04-24T21:00:12.720' AS DateTime))
INSERT [dbo].[transacciones_inscripcion] ([tr_idcliente], [tr_idproducto], [tr_accion], [tr_fechatransaccion]) VALUES ( 1, 1, N'Vinculado', CAST(N'2025-04-24T21:24:52.473' AS DateTime))
-----------------------
