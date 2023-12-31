USE [master]
GO
/****** Object:  Database [prueba]    Script Date: 09/11/2023 14:13:56 ******/
CREATE DATABASE [prueba]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'prueba', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\prueba.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'prueba_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\prueba_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [prueba] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [prueba].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [prueba] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [prueba] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [prueba] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [prueba] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [prueba] SET ARITHABORT OFF 
GO
ALTER DATABASE [prueba] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [prueba] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [prueba] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [prueba] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [prueba] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [prueba] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [prueba] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [prueba] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [prueba] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [prueba] SET  DISABLE_BROKER 
GO
ALTER DATABASE [prueba] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [prueba] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [prueba] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [prueba] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [prueba] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [prueba] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [prueba] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [prueba] SET RECOVERY FULL 
GO
ALTER DATABASE [prueba] SET  MULTI_USER 
GO
ALTER DATABASE [prueba] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [prueba] SET DB_CHAINING OFF 
GO
ALTER DATABASE [prueba] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [prueba] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [prueba] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [prueba] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'prueba', N'ON'
GO
ALTER DATABASE [prueba] SET QUERY_STORE = ON
GO
ALTER DATABASE [prueba] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [prueba]
GO
/****** Object:  Table [dbo].[CIUDADES]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CIUDADES](
	[id_ciudad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[id_pais] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_ciudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GIROS]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIROS](
	[GIR_GIRO_ID] [int] IDENTITY(1,1) NOT NULL,
	[GIR_RECIBO] [varchar](50) NOT NULL,
	[GIR_CIUDAD_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GIR_GIRO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAISES]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAISES](
	[id_pais] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CIUDADES] ON 

INSERT [dbo].[CIUDADES] ([id_ciudad], [nombre], [id_pais]) VALUES (1, N'¿Buenos aires m', 5)
INSERT [dbo].[CIUDADES] ([id_ciudad], [nombre], [id_pais]) VALUES (9, N'bremen', 11)
INSERT [dbo].[CIUDADES] ([id_ciudad], [nombre], [id_pais]) VALUES (10, N'ddddd', 11)
INSERT [dbo].[CIUDADES] ([id_ciudad], [nombre], [id_pais]) VALUES (11, N'bremen', 11)
INSERT [dbo].[CIUDADES] ([id_ciudad], [nombre], [id_pais]) VALUES (13, N'tigres', 5)
INSERT [dbo].[CIUDADES] ([id_ciudad], [nombre], [id_pais]) VALUES (14, N'misiones', 5)
INSERT [dbo].[CIUDADES] ([id_ciudad], [nombre], [id_pais]) VALUES (15, N'Rosario', 5)
SET IDENTITY_INSERT [dbo].[CIUDADES] OFF
GO
SET IDENTITY_INSERT [dbo].[GIROS] ON 

INSERT [dbo].[GIROS] ([GIR_GIRO_ID], [GIR_RECIBO], [GIR_CIUDAD_ID]) VALUES (1, N'zzzzzzzz', 1)
INSERT [dbo].[GIROS] ([GIR_GIRO_ID], [GIR_RECIBO], [GIR_CIUDAD_ID]) VALUES (15, N'tucuman', 1)
INSERT [dbo].[GIROS] ([GIR_GIRO_ID], [GIR_RECIBO], [GIR_CIUDAD_ID]) VALUES (16, N'tucumans', 1)
INSERT [dbo].[GIROS] ([GIR_GIRO_ID], [GIR_RECIBO], [GIR_CIUDAD_ID]) VALUES (17, N'ggggg', 9)
INSERT [dbo].[GIROS] ([GIR_GIRO_ID], [GIR_RECIBO], [GIR_CIUDAD_ID]) VALUES (19, N'wang', 1)
INSERT [dbo].[GIROS] ([GIR_GIRO_ID], [GIR_RECIBO], [GIR_CIUDAD_ID]) VALUES (20, N'pepito', 1)
INSERT [dbo].[GIROS] ([GIR_GIRO_ID], [GIR_RECIBO], [GIR_CIUDAD_ID]) VALUES (21, N'cccccccc', 1)
INSERT [dbo].[GIROS] ([GIR_GIRO_ID], [GIR_RECIBO], [GIR_CIUDAD_ID]) VALUES (22, N'gggggkjjm', 1)
SET IDENTITY_INSERT [dbo].[GIROS] OFF
GO
SET IDENTITY_INSERT [dbo].[PAISES] ON 

INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (4, N'Croacia')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (5, N'Argentina')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (9, N'Rumania')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (10, N'India')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (11, N'Alemania')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (13, N'gggfgf')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (14, N'hhhhh')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (15, N'zzzz')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (16, N'iiiii')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (17, N'oooo')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (18, N'lalala')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (19, N'lelele')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (20, N'lelkkk')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (21, N'fred')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (22, N'ig')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (23, N'flu')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (24, N'fla')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (25, N'boca')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (26, N'FREE')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (27, N'PRE')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (28, N'FRA')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (29, N'RA')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (30, N'GUUU')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (31, N'EEEE')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (32, N'HJKHK')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (36, N'prueba')
INSERT [dbo].[PAISES] ([id_pais], [nombre]) VALUES (38, N'holanda')
SET IDENTITY_INSERT [dbo].[PAISES] OFF
GO
ALTER TABLE [dbo].[CIUDADES]  WITH CHECK ADD FOREIGN KEY([id_pais])
REFERENCES [dbo].[PAISES] ([id_pais])
GO
ALTER TABLE [dbo].[GIROS]  WITH CHECK ADD FOREIGN KEY([GIR_CIUDAD_ID])
REFERENCES [dbo].[CIUDADES] ([id_ciudad])
GO
/****** Object:  StoredProcedure [dbo].[CIUDADES_Add]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CIUDADES_Add]
@nombre VARCHAR(255),
@id_pais int
AS
INSERT INTO CIUDADES(nombre,id_pais)
values(@nombre,@id_pais)
GO
/****** Object:  StoredProcedure [dbo].[CIUDADES_All]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CIUDADES_All]
AS
SELECT id_ciudad,nombre,id_pais FROM CIUDADES
ORDER BY id_ciudad ASC
GO
/****** Object:  StoredProcedure [dbo].[CIUDADES_Delete]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CIUDADES_Delete]
@id_ciudad int
AS
DELETE FROM CIUDADES WHERE id_ciudad=@id_ciudad
GO
/****** Object:  StoredProcedure [dbo].[CIUDADES_Update]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CIUDADES_Update]
@id_ciudad int,
@nombre VARCHAR(255),
@id_pais int
AS
update CIUDADES set nombre=@nombre,id_pais=@id_pais where id_ciudad=@id_ciudad
GO
/****** Object:  StoredProcedure [dbo].[GIROS_Add]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GIROS_Add]
@GIR_RECIBO VARCHAR(255),
@GIR_CIUDAD_ID INT
AS
INSERT INTO GIROS(GIR_RECIBO,GIR_CIUDAD_ID)
values(@GIR_RECIBO,@GIR_CIUDAD_ID)
GO
/****** Object:  StoredProcedure [dbo].[GIROS_All]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GIROS_All]
AS
SELECT GIR_GIRO_ID,GIR_RECIBO,GIR_CIUDAD_ID FROM GIROS
ORDER BY GIR_GIRO_ID ASC
GO
/****** Object:  StoredProcedure [dbo].[GIROS_Delete]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GIROS_Delete]
@GIR_GIRO_ID int
AS
DELETE FROM GIROS WHERE GIR_GIRO_ID=@GIR_GIRO_ID
GO
/****** Object:  StoredProcedure [dbo].[GIROS_Update]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GIROS_Update]
@GIR_GIRO_ID int,
@GIR_RECIBO VARCHAR(255),
@GIR_CIUDAD_ID int
AS
update GIROS set GIR_RECIBO=@GIR_RECIBO, GIR_CIUDAD_ID=@GIR_CIUDAD_ID where GIR_GIRO_ID=@GIR_GIRO_ID
GO
/****** Object:  StoredProcedure [dbo].[PAISES_Add]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PAISES_Add]
@nombre VARCHAR(255)
AS
INSERT INTO PAISES (nombre)
values(@nombre)
GO
/****** Object:  StoredProcedure [dbo].[PAISES_All]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PAISES_All]
AS
SELECT id_pais,nombre FROM PAISES
ORDER BY id_pais ASC
GO
/****** Object:  StoredProcedure [dbo].[PAISES_Delete]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PAISES_Delete]
@id_pais int
AS
DELETE FROM PAISES WHERE id_pais=@id_pais
GO
/****** Object:  StoredProcedure [dbo].[PAISES_Update]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PAISES_Update]
@id_pais int,
@nombre VARCHAR(255)
AS
update PAISES set nombre=@nombre where id_pais=@id_pais
GO
/****** Object:  StoredProcedure [dbo].[usp_obtener]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_obtener](@id_pais int)
as
begin

select * from CIUDADES where id_pais = @id_pais
end
GO
/****** Object:  StoredProcedure [dbo].[usp_obtenerGiroPorCiudad]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_obtenerGiroPorCiudad](@GIR_CIUDAD_ID int


)
as
begin

select top 4 * from GIROS where GIR_CIUDAD_ID = @GIR_CIUDAD_ID
end
GO
/****** Object:  StoredProcedure [dbo].[usp_obtenerpornombre]    Script Date: 09/11/2023 14:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_obtenerpornombre](@nombre varchar(50)


)
as
begin

select * from CIUDADES where nombre = @nombre
end
GO
USE [master]
GO
ALTER DATABASE [prueba] SET  READ_WRITE 
GO
