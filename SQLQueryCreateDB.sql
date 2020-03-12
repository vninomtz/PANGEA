USE [master]
GO
/****** Object:  Database [Pangea]    Script Date: 11/03/2020 09:50:47 p. m. ******/
CREATE DATABASE [Pangea]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pangea', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Pangea.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pangea_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Pangea_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Pangea] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pangea].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pangea] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pangea] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pangea] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pangea] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pangea] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pangea] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Pangea] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pangea] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pangea] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pangea] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pangea] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pangea] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pangea] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pangea] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pangea] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Pangea] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pangea] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pangea] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pangea] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pangea] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pangea] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Pangea] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pangea] SET RECOVERY FULL 
GO
ALTER DATABASE [Pangea] SET  MULTI_USER 
GO
ALTER DATABASE [Pangea] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pangea] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pangea] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pangea] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pangea] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Pangea', N'ON'
GO
ALTER DATABASE [Pangea] SET QUERY_STORE = OFF
GO
USE [Pangea]
GO
/****** Object:  User [usrPangeaOW]    Script Date: 11/03/2020 09:50:48 p. m. ******/
CREATE USER [usrPangeaOW] FOR LOGIN [usrPangeaOW] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [usrPangeaOW]
GO
/****** Object:  Table [dbo].[Actividades]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[Gratuito] [bit] NOT NULL,
	[Costo] [float] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
	[UltimaModificacion] [datetime] NULL,
	[IdArticulo] [int] NULL,
 CONSTRAINT [PK_Actividades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[id] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
	[fecha_creacion] [date] NOT NULL,
	[ultima_actualizacion] [date] NOT NULL,
	[autor] [nvarchar](50) NOT NULL,
	[archivo] [text] NOT NULL,
	[idTrack] [int] NOT NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asistentes]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistentes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Asistentes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsistentesEvento]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsistentesEvento](
	[Asistencia] [bit] NOT NULL,
	[Pago] [bit] NOT NULL,
	[Cantidad] [float] NOT NULL,
	[IdAsistente] [int] NOT NULL,
	[IdEvento] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comites]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comites](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UltimaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Comites] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConceptosFinancieros]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConceptosFinancieros](
	[Id] [int] NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
	[Monto] [float] NOT NULL,
	[Concepto] [nvarchar](50) NOT NULL,
	[Fecha_creacion] [date] NOT NULL,
	[IdActividad] [int] NOT NULL,
	[IdPresupuesto] [int] NULL,
 CONSTRAINT [PK_ConceptosFinancieros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](510) NOT NULL,
	[Contrasenia] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](10) NULL,
	[Token] [nvarchar](250) NULL,
	[UltimoAcceso] [datetime] NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eventos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodigoEvento] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[Eliminado] [bit] NOT NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaFin] [date] NOT NULL,
	[Lugar] [nvarchar](150) NOT NULL,
	[Gratuito] [bit] NOT NULL,
	[Costo] [float] NULL,
 CONSTRAINT [PK_Eventos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horarios]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [nvarchar](150) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[Lugar] [nvarchar](150) NOT NULL,
	[IdActividad] [int] NOT NULL,
 CONSTRAINT [PK_Horarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IncripcionActividades]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncripcionActividades](
	[id] [int] NOT NULL,
	[asistencia] [bit] NOT NULL,
	[pago] [bit] NOT NULL,
	[fecha_inscripcion] [date] NOT NULL,
	[idActividad] [int] NOT NULL,
	[idAsistente] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materiales]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materiales](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[IdActividad] [int] NOT NULL,
	[IdEvento] [int] NULL,
 CONSTRAINT [PK_Materiales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Asignado] [bit] NOT NULL,
	[Cargo] [nvarchar](50) NULL,
	[IdEvento] [int] NOT NULL,
	[IdCuenta] [int] NOT NULL,
	[IdComite] [int] NULL,
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presupuestos]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presupuestos](
	[Id] [int] NOT NULL,
	[Gasto_tentativo] [float] NOT NULL,
	[Gasto_real] [float] NULL,
	[IdEvento] [int] NULL,
 CONSTRAINT [PK_Presupuestos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tareas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Finalizada] [bit] NOT NULL,
	[Responsable] [nvarchar](50) NOT NULL,
	[UltimaModificacion] [datetime] NULL,
	[FechaFinalizacion] [datetime] NULL,
	[IdActividad] [int] NOT NULL,
 CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tracks]    Script Date: 11/03/2020 09:50:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tracks](
	[Id] [int] NOT NULL,
	[Codigo] [int] NOT NULL,
	[Descripcion] [text] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[IdEvento] [int] NULL,
 CONSTRAINT [PK_Tracks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Actividades]  WITH CHECK ADD  CONSTRAINT [FK_Actividades_Articulos] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[Articulos] ([id])
GO
ALTER TABLE [dbo].[Actividades] CHECK CONSTRAINT [FK_Actividades_Articulos]
GO
ALTER TABLE [dbo].[Articulos]  WITH CHECK ADD  CONSTRAINT [FK_Articulos_Tracks] FOREIGN KEY([idTrack])
REFERENCES [dbo].[Tracks] ([Id])
GO
ALTER TABLE [dbo].[Articulos] CHECK CONSTRAINT [FK_Articulos_Tracks]
GO
ALTER TABLE [dbo].[AsistentesEvento]  WITH CHECK ADD  CONSTRAINT [FK_AsistentesEvento_Asistentes] FOREIGN KEY([IdAsistente])
REFERENCES [dbo].[Asistentes] ([Id])
GO
ALTER TABLE [dbo].[AsistentesEvento] CHECK CONSTRAINT [FK_AsistentesEvento_Asistentes]
GO
ALTER TABLE [dbo].[AsistentesEvento]  WITH CHECK ADD  CONSTRAINT [FK_AsistentesEvento_Eventos] FOREIGN KEY([IdEvento])
REFERENCES [dbo].[Eventos] ([Id])
GO
ALTER TABLE [dbo].[AsistentesEvento] CHECK CONSTRAINT [FK_AsistentesEvento_Eventos]
GO
ALTER TABLE [dbo].[ConceptosFinancieros]  WITH CHECK ADD  CONSTRAINT [FK_ConceptosFinancieros_Actividades] FOREIGN KEY([IdActividad])
REFERENCES [dbo].[Actividades] ([Id])
GO
ALTER TABLE [dbo].[ConceptosFinancieros] CHECK CONSTRAINT [FK_ConceptosFinancieros_Actividades]
GO
ALTER TABLE [dbo].[ConceptosFinancieros]  WITH CHECK ADD  CONSTRAINT [FK_ConceptosFinancieros_Presupuestos] FOREIGN KEY([IdPresupuesto])
REFERENCES [dbo].[Presupuestos] ([Id])
GO
ALTER TABLE [dbo].[ConceptosFinancieros] CHECK CONSTRAINT [FK_ConceptosFinancieros_Presupuestos]
GO
ALTER TABLE [dbo].[Horarios]  WITH CHECK ADD  CONSTRAINT [FK_Horarios_Actividades] FOREIGN KEY([IdActividad])
REFERENCES [dbo].[Actividades] ([Id])
GO
ALTER TABLE [dbo].[Horarios] CHECK CONSTRAINT [FK_Horarios_Actividades]
GO
ALTER TABLE [dbo].[IncripcionActividades]  WITH CHECK ADD  CONSTRAINT [FK_IncripcionActividades_Actividades] FOREIGN KEY([idActividad])
REFERENCES [dbo].[Actividades] ([Id])
GO
ALTER TABLE [dbo].[IncripcionActividades] CHECK CONSTRAINT [FK_IncripcionActividades_Actividades]
GO
ALTER TABLE [dbo].[IncripcionActividades]  WITH CHECK ADD  CONSTRAINT [FK_IncripcionActividades_Asistentes] FOREIGN KEY([idAsistente])
REFERENCES [dbo].[Asistentes] ([Id])
GO
ALTER TABLE [dbo].[IncripcionActividades] CHECK CONSTRAINT [FK_IncripcionActividades_Asistentes]
GO
ALTER TABLE [dbo].[Materiales]  WITH CHECK ADD  CONSTRAINT [FK_Materiales_Actividades] FOREIGN KEY([IdActividad])
REFERENCES [dbo].[Actividades] ([Id])
GO
ALTER TABLE [dbo].[Materiales] CHECK CONSTRAINT [FK_Materiales_Actividades]
GO
ALTER TABLE [dbo].[Materiales]  WITH CHECK ADD  CONSTRAINT [FK_Materiales_Eventos] FOREIGN KEY([IdEvento])
REFERENCES [dbo].[Eventos] ([Id])
GO
ALTER TABLE [dbo].[Materiales] CHECK CONSTRAINT [FK_Materiales_Eventos]
GO
ALTER TABLE [dbo].[Personal]  WITH CHECK ADD  CONSTRAINT [FK_Personal_Comites] FOREIGN KEY([IdComite])
REFERENCES [dbo].[Comites] ([Id])
GO
ALTER TABLE [dbo].[Personal] CHECK CONSTRAINT [FK_Personal_Comites]
GO
ALTER TABLE [dbo].[Personal]  WITH CHECK ADD  CONSTRAINT [FK_Personal_Cuentas] FOREIGN KEY([IdCuenta])
REFERENCES [dbo].[Cuentas] ([Id])
GO
ALTER TABLE [dbo].[Personal] CHECK CONSTRAINT [FK_Personal_Cuentas]
GO
ALTER TABLE [dbo].[Personal]  WITH CHECK ADD  CONSTRAINT [FK_Personal_Eventos] FOREIGN KEY([IdEvento])
REFERENCES [dbo].[Eventos] ([Id])
GO
ALTER TABLE [dbo].[Personal] CHECK CONSTRAINT [FK_Personal_Eventos]
GO
ALTER TABLE [dbo].[Presupuestos]  WITH CHECK ADD  CONSTRAINT [FK_Presupuestos_Eventos] FOREIGN KEY([IdEvento])
REFERENCES [dbo].[Eventos] ([Id])
GO
ALTER TABLE [dbo].[Presupuestos] CHECK CONSTRAINT [FK_Presupuestos_Eventos]
GO
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_Tareas_Actividades] FOREIGN KEY([IdActividad])
REFERENCES [dbo].[Actividades] ([Id])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_Tareas_Actividades]
GO
ALTER TABLE [dbo].[Tracks]  WITH CHECK ADD  CONSTRAINT [FK_Tracks_Eventos1] FOREIGN KEY([IdEvento])
REFERENCES [dbo].[Eventos] ([Id])
GO
ALTER TABLE [dbo].[Tracks] CHECK CONSTRAINT [FK_Tracks_Eventos1]
GO
USE [master]
GO
ALTER DATABASE [Pangea] SET  READ_WRITE 
GO
