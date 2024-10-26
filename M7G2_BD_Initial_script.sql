USE [master]
GO
/****** Object:  Database [M7G2]    Script Date: 10/26/2024 12:05:51 AM ******/
CREATE DATABASE [M7G2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'M7G2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\M7G2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'M7G2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\M7G2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [M7G2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [M7G2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [M7G2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [M7G2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [M7G2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [M7G2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [M7G2] SET ARITHABORT OFF 
GO
ALTER DATABASE [M7G2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [M7G2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [M7G2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [M7G2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [M7G2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [M7G2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [M7G2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [M7G2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [M7G2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [M7G2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [M7G2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [M7G2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [M7G2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [M7G2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [M7G2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [M7G2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [M7G2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [M7G2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [M7G2] SET  MULTI_USER 
GO
ALTER DATABASE [M7G2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [M7G2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [M7G2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [M7G2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [M7G2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [M7G2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [M7G2] SET QUERY_STORE = ON
GO
ALTER DATABASE [M7G2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [M7G2]
GO
USE [M7G2]
GO
/****** Object:  Sequence [dbo].[ClienteSequence]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE SEQUENCE [dbo].[ClienteSequence] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE 
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Almacenes]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacenes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](25) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](250) NULL,
 CONSTRAINT [PK_Almacenes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlmacenProducto]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlmacenProducto](
	[AlmacenesId] [int] NOT NULL,
	[ProductosId] [int] NOT NULL,
 CONSTRAINT [PK_AlmacenProducto] PRIMARY KEY CLUSTERED 
(
	[AlmacenesId] ASC,
	[ProductosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Descuentos]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Descuentos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PorcentajeDescuento] [decimal](4, 2) NOT NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaFin] [date] NOT NULL,
	[ProductoId] [int] NULL,
	[GrupoClienteId] [int] NULL,
 CONSTRAINT [PK_Descuentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresas](
	[Id] [int] NOT NULL,
	[Codigo] [nvarchar](25) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[GrupoClienteId] [int] NOT NULL,
	[RazonSocial] [nvarchar](100) NOT NULL,
	[Nit] [int] NOT NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fabricantes]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fabricantes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cNmbFabricante] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Fabricantes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrupoCliente]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoCliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Codigo] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_GrupoCliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrupoProductos]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoProductos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cCodGrupoProducto] [nvarchar](10) NOT NULL,
	[cNombreGrupoProducto] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_GrupoProductos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Id] [int] NOT NULL,
	[Codigo] [nvarchar](25) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[GrupoClienteId] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[Ci] [int] NOT NULL,
	[TipoDocumento] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cSku] [nvarchar](25) NOT NULL,
	[cNombre] [nvarchar](100) NOT NULL,
	[cNombreExtrangero] [nvarchar](100) NOT NULL,
	[nPeso] [decimal](8, 2) NOT NULL,
	[cUM] [nvarchar](50) NOT NULL,
	[nPrecioLista] [decimal](8, 2) NOT NULL,
	[nPrecioBase] [decimal](8, 2) NOT NULL,
	[cCodBarra] [nvarchar](50) NOT NULL,
	[cSkuFabricante] [nvarchar](25) NOT NULL,
	[cSkuAlternante] [nvarchar](25) NOT NULL,
	[GrupoProductoId] [int] NOT NULL,
	[FabricanteId] [int] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cNmbProveedor] [nvarchar](100) NOT NULL,
	[ProductoId] [int] NOT NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](25) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Precio] [decimal](8, 2) NOT NULL,
	[UnidadVenta] [nvarchar](50) NOT NULL,
	[DescuentoId] [int] NULL,
 CONSTRAINT [PK_Servicios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaDetalle]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaDetalle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[UnidadMedida] [nvarchar](50) NOT NULL,
	[Precio] [decimal](8, 2) NOT NULL,
	[DescuentoItem] [decimal](4, 2) NOT NULL,
	[PrecioDescuento] [decimal](8, 2) NOT NULL,
	[VentaId] [int] NOT NULL,
	[ProductoId] [int] NULL,
	[ServicioId] [int] NULL,
 CONSTRAINT [PK_VentaDetalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 10/26/2024 12:05:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](25) NOT NULL,
	[Fecha] [date] NOT NULL,
	[NitFacturacion] [int] NOT NULL,
	[NombreFacturacion] [nvarchar](100) NOT NULL,
	[ConIva] [bit] NOT NULL,
	[DescuentoGlobal] [decimal](4, 2) NULL,
	[PrecioTotal] [decimal](8, 2) NULL,
	[PrecioTotalDescuento] [decimal](8, 2) NULL,
	[PersonaId] [int] NULL,
	[EmpresaId] [int] NULL,
	[PrecioIva] [decimal](8, 2) NULL,
	[PrecioTotalIva] [decimal](8, 2) NULL,
	[FormaPago] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240921205144_Initial', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240923010406_Api2', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240923011305_Api3', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240923160945_Api4', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240924180134_Api5', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240925042133_Api6', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240925044056_Api7', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240925225128_Api8', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240929214139_Api9', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241001032535_Api10', N'8.0.8')
GO
SET IDENTITY_INSERT [dbo].[Descuentos] ON 

INSERT [dbo].[Descuentos] ([Id], [PorcentajeDescuento], [FechaInicio], [FechaFin], [ProductoId], [GrupoClienteId]) VALUES (1, CAST(2.50 AS Decimal(4, 2)), CAST(N'2024-09-01' AS Date), CAST(N'2024-10-10' AS Date), 1, NULL)
INSERT [dbo].[Descuentos] ([Id], [PorcentajeDescuento], [FechaInicio], [FechaFin], [ProductoId], [GrupoClienteId]) VALUES (2, CAST(3.70 AS Decimal(4, 2)), CAST(N'2024-09-01' AS Date), CAST(N'2024-10-10' AS Date), 2, NULL)
INSERT [dbo].[Descuentos] ([Id], [PorcentajeDescuento], [FechaInicio], [FechaFin], [ProductoId], [GrupoClienteId]) VALUES (3, CAST(1.40 AS Decimal(4, 2)), CAST(N'2024-09-01' AS Date), CAST(N'2024-10-10' AS Date), 3, NULL)
INSERT [dbo].[Descuentos] ([Id], [PorcentajeDescuento], [FechaInicio], [FechaFin], [ProductoId], [GrupoClienteId]) VALUES (4, CAST(2.55 AS Decimal(4, 2)), CAST(N'2024-09-01' AS Date), CAST(N'2024-10-10' AS Date), 4, NULL)
INSERT [dbo].[Descuentos] ([Id], [PorcentajeDescuento], [FechaInicio], [FechaFin], [ProductoId], [GrupoClienteId]) VALUES (5, CAST(1.25 AS Decimal(4, 2)), CAST(N'2024-09-01' AS Date), CAST(N'2024-10-10' AS Date), NULL, 1)
SET IDENTITY_INSERT [dbo].[Descuentos] OFF
GO
SET IDENTITY_INSERT [dbo].[Fabricantes] ON 

INSERT [dbo].[Fabricantes] ([Id], [cNmbFabricante]) VALUES (1, N'DELL')
INSERT [dbo].[Fabricantes] ([Id], [cNmbFabricante]) VALUES (2, N'HP')
INSERT [dbo].[Fabricantes] ([Id], [cNmbFabricante]) VALUES (3, N'MSI')
SET IDENTITY_INSERT [dbo].[Fabricantes] OFF
GO
SET IDENTITY_INSERT [dbo].[GrupoCliente] ON 

INSERT [dbo].[GrupoCliente] ([Id], [Nombre], [Codigo]) VALUES (1, N'Grupo - Personas', N'GP-P10001')
INSERT [dbo].[GrupoCliente] ([Id], [Nombre], [Codigo]) VALUES (2, N'Grupo - Empresas', N'GP-E10001')
INSERT [dbo].[GrupoCliente] ([Id], [Nombre], [Codigo]) VALUES (3, N'Personas Socios Almacen', N'PS100123')
SET IDENTITY_INSERT [dbo].[GrupoCliente] OFF
GO
SET IDENTITY_INSERT [dbo].[GrupoProductos] ON 

INSERT [dbo].[GrupoProductos] ([Id], [cCodGrupoProducto], [cNombreGrupoProducto]) VALUES (1, N'1001', N'Computadoras')
INSERT [dbo].[GrupoProductos] ([Id], [cCodGrupoProducto], [cNombreGrupoProducto]) VALUES (2, N'1002', N'Accesorios')
SET IDENTITY_INSERT [dbo].[GrupoProductos] OFF
GO
INSERT [dbo].[Personas] ([Id], [Codigo], [Email], [GrupoClienteId], [Nombre], [Apellidos], [Ci], [TipoDocumento]) VALUES (1, N'1020133', N'comprador11@gmail.com', 1, N'Jhon', N'Smith', 252654, N'')
INSERT [dbo].[Personas] ([Id], [Codigo], [Email], [GrupoClienteId], [Nombre], [Apellidos], [Ci], [TipoDocumento]) VALUES (2, N'1020855', N'comprador21@gmail.com', 1, N'Mariela', N'Torrez', 5498512, N'')
INSERT [dbo].[Personas] ([Id], [Codigo], [Email], [GrupoClienteId], [Nombre], [Apellidos], [Ci], [TipoDocumento]) VALUES (3, N'1020951', N'comprador31@gmail.com', 3, N'Pedro', N'Salazar', 9816845, N'')
INSERT [dbo].[Personas] ([Id], [Codigo], [Email], [GrupoClienteId], [Nombre], [Apellidos], [Ci], [TipoDocumento]) VALUES (4, N'P123123', N'rob@gmail.com', 1, N'Roberto', N'Fernandez', 147852, N'Documento Identidad')
INSERT [dbo].[Personas] ([Id], [Codigo], [Email], [GrupoClienteId], [Nombre], [Apellidos], [Ci], [TipoDocumento]) VALUES (5, N'P1234523', N'darth@gmail.com', 1, N'Darth', N'Toto', 101452, N'Documento Identidad')
INSERT [dbo].[Personas] ([Id], [Codigo], [Email], [GrupoClienteId], [Nombre], [Apellidos], [Ci], [TipoDocumento]) VALUES (6, N'101021', N'consumidor13@email.com', 1, N'Jorge', N'Rodriguez', 233442, N'1')
INSERT [dbo].[Personas] ([Id], [Codigo], [Email], [GrupoClienteId], [Nombre], [Apellidos], [Ci], [TipoDocumento]) VALUES (7, N'101022', N'consumidor14@email.com', 1, N'Will', N'Smith', 4233421, N'1')
INSERT [dbo].[Personas] ([Id], [Codigo], [Email], [GrupoClienteId], [Nombre], [Apellidos], [Ci], [TipoDocumento]) VALUES (8, N'a12341', N'cliente12@gmail.com', 1, N'Rene', N'Fernandez', 1234523, N'1')
INSERT [dbo].[Personas] ([Id], [Codigo], [Email], [GrupoClienteId], [Nombre], [Apellidos], [Ci], [TipoDocumento]) VALUES (9, N'a123412', N'cliente15@gmail.com', 1, N'Daniel', N'Suarez', 12345239, N'1')
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([Id], [cSku], [cNombre], [cNombreExtrangero], [nPeso], [cUM], [nPrecioLista], [nPrecioBase], [cCodBarra], [cSkuFabricante], [cSkuAlternante], [GrupoProductoId], [FabricanteId]) VALUES (1, N'D100001', N'Portatil 15" A15', N'Laptop 15 A15"', CAST(1.55 AS Decimal(8, 2)), N'Kg', CAST(935.00 AS Decimal(8, 2)), CAST(850.00 AS Decimal(8, 2)), N'1020304050', N'D10A150001', N'D10A151001', 1, 1)
INSERT [dbo].[Productos] ([Id], [cSku], [cNombre], [cNombreExtrangero], [nPeso], [cUM], [nPrecioLista], [nPrecioBase], [cCodBarra], [cSkuFabricante], [cSkuAlternante], [GrupoProductoId], [FabricanteId]) VALUES (2, N'D100002', N'Portatil 15" L35', N'Laptop 15 L355"', CAST(1.46 AS Decimal(8, 2)), N'Kg', CAST(550.00 AS Decimal(8, 2)), CAST(450.00 AS Decimal(8, 2)), N'1030487050', N'D10L350001', N'D10L351001', 1, 1)
INSERT [dbo].[Productos] ([Id], [cSku], [cNombre], [cNombreExtrangero], [nPeso], [cUM], [nPrecioLista], [nPrecioBase], [cCodBarra], [cSkuFabricante], [cSkuAlternante], [GrupoProductoId], [FabricanteId]) VALUES (3, N'HP100001', N'Portatil 15" H15', N'Laptop 15 H15"', CAST(1.06 AS Decimal(8, 2)), N'Kg', CAST(985.00 AS Decimal(8, 2)), CAST(950.00 AS Decimal(8, 2)), N'1020304050', N'HP55H150001', N'HP56H151001', 1, 2)
INSERT [dbo].[Productos] ([Id], [cSku], [cNombre], [cNombreExtrangero], [nPeso], [cUM], [nPrecioLista], [nPrecioBase], [cCodBarra], [cSkuFabricante], [cSkuAlternante], [GrupoProductoId], [FabricanteId]) VALUES (4, N'HP1HD001', N'Disco 1TB', N'HD 1TB"', CAST(400.00 AS Decimal(8, 2)), N'gr', CAST(165.00 AS Decimal(8, 2)), CAST(150.00 AS Decimal(8, 2)), N'8320304050', N'HP1HD1TB001', N'HP1HD1TB1001', 2, 2)
INSERT [dbo].[Productos] ([Id], [cSku], [cNombre], [cNombreExtrangero], [nPeso], [cUM], [nPrecioLista], [nPrecioBase], [cCodBarra], [cSkuFabricante], [cSkuAlternante], [GrupoProductoId], [FabricanteId]) VALUES (5, N'HP1HD002', N'Disco 1.5TB', N'HD 1.5TB"', CAST(480.00 AS Decimal(8, 2)), N'gr', CAST(203.00 AS Decimal(8, 2)), CAST(185.00 AS Decimal(8, 2)), N'8320304650', N'HP1HD15TB01', N'HP1HD15TB101', 2, 2)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([Id], [cNmbProveedor], [ProductoId]) VALUES (1, N'Infobest', 1)
INSERT [dbo].[Proveedores] ([Id], [cNmbProveedor], [ProductoId]) VALUES (2, N'Importadora PC', 2)
INSERT [dbo].[Proveedores] ([Id], [cNmbProveedor], [ProductoId]) VALUES (3, N'Dismac', 3)
INSERT [dbo].[Proveedores] ([Id], [cNmbProveedor], [ProductoId]) VALUES (4, N'M&M', 4)
INSERT [dbo].[Proveedores] ([Id], [cNmbProveedor], [ProductoId]) VALUES (5, N'Alienware', 5)
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[VentaDetalle] ON 

INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (1, 1, N'unidad', CAST(935.00 AS Decimal(8, 2)), CAST(2.50 AS Decimal(4, 2)), CAST(911.63 AS Decimal(8, 2)), 1, 1, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (2, 1, N'unidad', CAST(550.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(4, 2)), CAST(550.00 AS Decimal(8, 2)), 2, 2, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (3, 1, N'unidad', CAST(985.00 AS Decimal(8, 2)), CAST(1.40 AS Decimal(4, 2)), CAST(971.21 AS Decimal(8, 2)), 3, 3, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (4, 1, N'unidad', CAST(550.00 AS Decimal(8, 2)), CAST(3.70 AS Decimal(4, 2)), CAST(529.65 AS Decimal(8, 2)), 3, 2, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (5, 1, N'unidad', CAST(165.00 AS Decimal(8, 2)), CAST(2.55 AS Decimal(4, 2)), CAST(160.79 AS Decimal(8, 2)), 3, 4, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (6, 1, N'unidad', CAST(165.00 AS Decimal(8, 2)), CAST(2.55 AS Decimal(4, 2)), CAST(160.79 AS Decimal(8, 2)), 4, 4, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (7, 1, N'unidad', CAST(935.00 AS Decimal(8, 2)), CAST(2.50 AS Decimal(4, 2)), CAST(911.63 AS Decimal(8, 2)), 4, 1, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (8, 1, N'unidad', CAST(550.00 AS Decimal(8, 2)), CAST(3.70 AS Decimal(4, 2)), CAST(529.65 AS Decimal(8, 2)), 4, 2, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (9, 1, N'unidad', CAST(165.00 AS Decimal(8, 2)), CAST(2.55 AS Decimal(4, 2)), CAST(160.79 AS Decimal(8, 2)), 5, 4, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (10, 1, N'unidad', CAST(550.00 AS Decimal(8, 2)), CAST(3.70 AS Decimal(4, 2)), CAST(529.65 AS Decimal(8, 2)), 7, 2, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (11, 3, N'unidad', CAST(2955.00 AS Decimal(8, 2)), CAST(1.40 AS Decimal(4, 2)), CAST(2913.63 AS Decimal(8, 2)), 7, 3, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (12, 1, N'unidad', CAST(165.00 AS Decimal(8, 2)), CAST(2.55 AS Decimal(4, 2)), CAST(160.79 AS Decimal(8, 2)), 7, 4, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (13, 2, N'unidad', CAST(406.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(4, 2)), CAST(406.00 AS Decimal(8, 2)), 6, 5, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (14, 1, N'unidad', CAST(985.00 AS Decimal(8, 2)), CAST(1.40 AS Decimal(4, 2)), CAST(971.21 AS Decimal(8, 2)), 8, 3, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (15, 1, N'unidad', CAST(203.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(4, 2)), CAST(203.00 AS Decimal(8, 2)), 8, 5, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (16, 2, N'unidad', CAST(330.00 AS Decimal(8, 2)), CAST(2.55 AS Decimal(4, 2)), CAST(321.59 AS Decimal(8, 2)), 8, 4, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (17, 1, N'unidad', CAST(935.00 AS Decimal(8, 2)), CAST(2.50 AS Decimal(4, 2)), CAST(911.63 AS Decimal(8, 2)), 8, 1, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (18, 1, N'1', CAST(935.00 AS Decimal(8, 2)), CAST(2.50 AS Decimal(4, 2)), CAST(911.63 AS Decimal(8, 2)), 10, 1, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (19, 2, N'1', CAST(330.00 AS Decimal(8, 2)), CAST(2.55 AS Decimal(4, 2)), CAST(321.59 AS Decimal(8, 2)), 10, 4, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (20, 2, N'1', CAST(406.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(4, 2)), CAST(406.00 AS Decimal(8, 2)), 9, 5, NULL)
INSERT [dbo].[VentaDetalle] ([Id], [Cantidad], [UnidadMedida], [Precio], [DescuentoItem], [PrecioDescuento], [VentaId], [ProductoId], [ServicioId]) VALUES (21, 2, N'unidad', CAST(330.00 AS Decimal(8, 2)), CAST(2.55 AS Decimal(4, 2)), CAST(321.59 AS Decimal(8, 2)), 8, 4, NULL)
SET IDENTITY_INSERT [dbo].[VentaDetalle] OFF
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([Id], [Codigo], [Fecha], [NitFacturacion], [NombreFacturacion], [ConIva], [DescuentoGlobal], [PrecioTotal], [PrecioTotalDescuento], [PersonaId], [EmpresaId], [PrecioIva], [PrecioTotalIva], [FormaPago]) VALUES (1, N'100010', CAST(N'2024-09-25' AS Date), 252654, N'Smith', 0, CAST(1.25 AS Decimal(4, 2)), CAST(911.63 AS Decimal(8, 2)), CAST(900.23 AS Decimal(8, 2)), 1, NULL, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), N'')
INSERT [dbo].[Ventas] ([Id], [Codigo], [Fecha], [NitFacturacion], [NombreFacturacion], [ConIva], [DescuentoGlobal], [PrecioTotal], [PrecioTotalDescuento], [PersonaId], [EmpresaId], [PrecioIva], [PrecioTotalIva], [FormaPago]) VALUES (2, N'100011', CAST(N'2024-09-25' AS Date), 9816845, N'Salazar', 0, CAST(0.00 AS Decimal(4, 2)), CAST(550.00 AS Decimal(8, 2)), CAST(550.00 AS Decimal(8, 2)), 3, NULL, CAST(0.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(8, 2)), N'')
INSERT [dbo].[Ventas] ([Id], [Codigo], [Fecha], [NitFacturacion], [NombreFacturacion], [ConIva], [DescuentoGlobal], [PrecioTotal], [PrecioTotalDescuento], [PersonaId], [EmpresaId], [PrecioIva], [PrecioTotalIva], [FormaPago]) VALUES (3, N'100044', CAST(N'2024-09-24' AS Date), 9816845, N'smith', 0, CAST(1.25 AS Decimal(4, 2)), CAST(1661.65 AS Decimal(8, 2)), CAST(1640.88 AS Decimal(8, 2)), 1, NULL, CAST(0.00 AS Decimal(8, 2)), CAST(1640.88 AS Decimal(8, 2)), N'')
INSERT [dbo].[Ventas] ([Id], [Codigo], [Fecha], [NitFacturacion], [NombreFacturacion], [ConIva], [DescuentoGlobal], [PrecioTotal], [PrecioTotalDescuento], [PersonaId], [EmpresaId], [PrecioIva], [PrecioTotalIva], [FormaPago]) VALUES (4, N'100048', CAST(N'2024-09-24' AS Date), 9816845, N'smith', 1, CAST(1.25 AS Decimal(4, 2)), CAST(1602.07 AS Decimal(8, 2)), CAST(1582.04 AS Decimal(8, 2)), 1, NULL, CAST(205.67 AS Decimal(8, 2)), CAST(1787.71 AS Decimal(8, 2)), N'')
INSERT [dbo].[Ventas] ([Id], [Codigo], [Fecha], [NitFacturacion], [NombreFacturacion], [ConIva], [DescuentoGlobal], [PrecioTotal], [PrecioTotalDescuento], [PersonaId], [EmpresaId], [PrecioIva], [PrecioTotalIva], [FormaPago]) VALUES (5, N'100049', CAST(N'2024-09-24' AS Date), 9816845, N'Salazar', 0, CAST(0.00 AS Decimal(4, 2)), CAST(160.79 AS Decimal(8, 2)), CAST(160.79 AS Decimal(8, 2)), 3, NULL, CAST(0.00 AS Decimal(8, 2)), CAST(160.79 AS Decimal(8, 2)), N'')
INSERT [dbo].[Ventas] ([Id], [Codigo], [Fecha], [NitFacturacion], [NombreFacturacion], [ConIva], [DescuentoGlobal], [PrecioTotal], [PrecioTotalDescuento], [PersonaId], [EmpresaId], [PrecioIva], [PrecioTotalIva], [FormaPago]) VALUES (6, N'1010054', CAST(N'2024-09-26' AS Date), 12345687, N'SMITH', 1, CAST(1.25 AS Decimal(4, 2)), CAST(406.00 AS Decimal(8, 2)), CAST(400.93 AS Decimal(8, 2)), 1, NULL, CAST(52.12 AS Decimal(8, 2)), CAST(453.05 AS Decimal(8, 2)), N'')
INSERT [dbo].[Ventas] ([Id], [Codigo], [Fecha], [NitFacturacion], [NombreFacturacion], [ConIva], [DescuentoGlobal], [PrecioTotal], [PrecioTotalDescuento], [PersonaId], [EmpresaId], [PrecioIva], [PrecioTotalIva], [FormaPago]) VALUES (7, N'1010055', CAST(N'2024-09-26' AS Date), 12345687, N'SMITH', 1, CAST(1.25 AS Decimal(4, 2)), CAST(3604.07 AS Decimal(8, 2)), CAST(3559.02 AS Decimal(8, 2)), 1, NULL, CAST(462.67 AS Decimal(8, 2)), CAST(4021.69 AS Decimal(8, 2)), N'')
INSERT [dbo].[Ventas] ([Id], [Codigo], [Fecha], [NitFacturacion], [NombreFacturacion], [ConIva], [DescuentoGlobal], [PrecioTotal], [PrecioTotalDescuento], [PersonaId], [EmpresaId], [PrecioIva], [PrecioTotalIva], [FormaPago]) VALUES (8, N'1010056', CAST(N'2024-09-26' AS Date), 12345687, N'SMITH', 1, CAST(1.25 AS Decimal(4, 2)), CAST(2729.02 AS Decimal(8, 2)), CAST(2694.90 AS Decimal(8, 2)), 2, NULL, CAST(350.34 AS Decimal(8, 2)), CAST(3045.24 AS Decimal(8, 2)), N'')
INSERT [dbo].[Ventas] ([Id], [Codigo], [Fecha], [NitFacturacion], [NombreFacturacion], [ConIva], [DescuentoGlobal], [PrecioTotal], [PrecioTotalDescuento], [PersonaId], [EmpresaId], [PrecioIva], [PrecioTotalIva], [FormaPago]) VALUES (9, N'101024', CAST(N'2024-09-30' AS Date), 12341, N'Rosas', 0, CAST(1.25 AS Decimal(4, 2)), CAST(406.00 AS Decimal(8, 2)), CAST(400.93 AS Decimal(8, 2)), 2, NULL, CAST(0.00 AS Decimal(8, 2)), CAST(400.93 AS Decimal(8, 2)), N'1')
INSERT [dbo].[Ventas] ([Id], [Codigo], [Fecha], [NitFacturacion], [NombreFacturacion], [ConIva], [DescuentoGlobal], [PrecioTotal], [PrecioTotalDescuento], [PersonaId], [EmpresaId], [PrecioIva], [PrecioTotalIva], [FormaPago]) VALUES (10, N'10112', CAST(N'2024-10-01' AS Date), 12315, N'Perez', 0, CAST(1.25 AS Decimal(4, 2)), CAST(1233.22 AS Decimal(8, 2)), CAST(1217.80 AS Decimal(8, 2)), 1, NULL, CAST(0.00 AS Decimal(8, 2)), CAST(1217.80 AS Decimal(8, 2)), N'1')
SET IDENTITY_INSERT [dbo].[Ventas] OFF
GO
/****** Object:  Index [IX_AlmacenProducto_ProductosId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_AlmacenProducto_ProductosId] ON [dbo].[AlmacenProducto]
(
	[ProductosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Descuentos_GrupoClienteId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_Descuentos_GrupoClienteId] ON [dbo].[Descuentos]
(
	[GrupoClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Descuentos_ProductoId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_Descuentos_ProductoId] ON [dbo].[Descuentos]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Empresas_GrupoClienteId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_Empresas_GrupoClienteId] ON [dbo].[Empresas]
(
	[GrupoClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Personas_GrupoClienteId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_Personas_GrupoClienteId] ON [dbo].[Personas]
(
	[GrupoClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Productos_FabricanteId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_Productos_FabricanteId] ON [dbo].[Productos]
(
	[FabricanteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Productos_GrupoProductoId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_Productos_GrupoProductoId] ON [dbo].[Productos]
(
	[GrupoProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Proveedores_ProductoId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_Proveedores_ProductoId] ON [dbo].[Proveedores]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Servicios_DescuentoId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_Servicios_DescuentoId] ON [dbo].[Servicios]
(
	[DescuentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_VentaDetalle_ProductoId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_VentaDetalle_ProductoId] ON [dbo].[VentaDetalle]
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_VentaDetalle_ServicioId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_VentaDetalle_ServicioId] ON [dbo].[VentaDetalle]
(
	[ServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_VentaDetalle_VentaId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_VentaDetalle_VentaId] ON [dbo].[VentaDetalle]
(
	[VentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ventas_EmpresaId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_Ventas_EmpresaId] ON [dbo].[Ventas]
(
	[EmpresaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ventas_PersonaId]    Script Date: 10/26/2024 12:05:52 AM ******/
CREATE NONCLUSTERED INDEX [IX_Ventas_PersonaId] ON [dbo].[Ventas]
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empresas] ADD  DEFAULT (NEXT VALUE FOR [ClienteSequence]) FOR [Id]
GO
ALTER TABLE [dbo].[Personas] ADD  DEFAULT (NEXT VALUE FOR [ClienteSequence]) FOR [Id]
GO
ALTER TABLE [dbo].[Personas] ADD  DEFAULT (N'') FOR [TipoDocumento]
GO
ALTER TABLE [dbo].[Ventas] ADD  DEFAULT (N'') FOR [FormaPago]
GO
ALTER TABLE [dbo].[AlmacenProducto]  WITH CHECK ADD  CONSTRAINT [FK_AlmacenProducto_Almacenes_AlmacenesId] FOREIGN KEY([AlmacenesId])
REFERENCES [dbo].[Almacenes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlmacenProducto] CHECK CONSTRAINT [FK_AlmacenProducto_Almacenes_AlmacenesId]
GO
ALTER TABLE [dbo].[AlmacenProducto]  WITH CHECK ADD  CONSTRAINT [FK_AlmacenProducto_Productos_ProductosId] FOREIGN KEY([ProductosId])
REFERENCES [dbo].[Productos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlmacenProducto] CHECK CONSTRAINT [FK_AlmacenProducto_Productos_ProductosId]
GO
ALTER TABLE [dbo].[Descuentos]  WITH CHECK ADD  CONSTRAINT [FK_Descuentos_GrupoCliente_GrupoClienteId] FOREIGN KEY([GrupoClienteId])
REFERENCES [dbo].[GrupoCliente] ([Id])
GO
ALTER TABLE [dbo].[Descuentos] CHECK CONSTRAINT [FK_Descuentos_GrupoCliente_GrupoClienteId]
GO
ALTER TABLE [dbo].[Descuentos]  WITH CHECK ADD  CONSTRAINT [FK_Descuentos_Productos_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([Id])
GO
ALTER TABLE [dbo].[Descuentos] CHECK CONSTRAINT [FK_Descuentos_Productos_ProductoId]
GO
ALTER TABLE [dbo].[Empresas]  WITH CHECK ADD  CONSTRAINT [FK_Empresas_GrupoCliente_GrupoClienteId] FOREIGN KEY([GrupoClienteId])
REFERENCES [dbo].[GrupoCliente] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Empresas] CHECK CONSTRAINT [FK_Empresas_GrupoCliente_GrupoClienteId]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_GrupoCliente_GrupoClienteId] FOREIGN KEY([GrupoClienteId])
REFERENCES [dbo].[GrupoCliente] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_GrupoCliente_GrupoClienteId]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Fabricantes_FabricanteId] FOREIGN KEY([FabricanteId])
REFERENCES [dbo].[Fabricantes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Fabricantes_FabricanteId]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_GrupoProductos_GrupoProductoId] FOREIGN KEY([GrupoProductoId])
REFERENCES [dbo].[GrupoProductos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_GrupoProductos_GrupoProductoId]
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Productos_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Productos_ProductoId]
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD  CONSTRAINT [FK_Servicios_Descuentos_DescuentoId] FOREIGN KEY([DescuentoId])
REFERENCES [dbo].[Descuentos] ([Id])
GO
ALTER TABLE [dbo].[Servicios] CHECK CONSTRAINT [FK_Servicios_Descuentos_DescuentoId]
GO
ALTER TABLE [dbo].[VentaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_VentaDetalle_Productos_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([Id])
GO
ALTER TABLE [dbo].[VentaDetalle] CHECK CONSTRAINT [FK_VentaDetalle_Productos_ProductoId]
GO
ALTER TABLE [dbo].[VentaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_VentaDetalle_Servicios_ServicioId] FOREIGN KEY([ServicioId])
REFERENCES [dbo].[Servicios] ([Id])
GO
ALTER TABLE [dbo].[VentaDetalle] CHECK CONSTRAINT [FK_VentaDetalle_Servicios_ServicioId]
GO
ALTER TABLE [dbo].[VentaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_VentaDetalle_Ventas_VentaId] FOREIGN KEY([VentaId])
REFERENCES [dbo].[Ventas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VentaDetalle] CHECK CONSTRAINT [FK_VentaDetalle_Ventas_VentaId]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Empresas_EmpresaId] FOREIGN KEY([EmpresaId])
REFERENCES [dbo].[Empresas] ([Id])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Empresas_EmpresaId]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Personas_PersonaId] FOREIGN KEY([PersonaId])
REFERENCES [dbo].[Personas] ([Id])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Personas_PersonaId]
GO
USE [master]
GO
ALTER DATABASE [M7G2] SET  READ_WRITE 
GO
