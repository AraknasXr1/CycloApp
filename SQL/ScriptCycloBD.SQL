USE [master]
GO
CREATE DATABASE [cyclingDB]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'cyclingDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\cyclingDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON
( NAME = N'cyclingDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\cyclingDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [cyclingDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cyclingDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cyclingDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [cyclingDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [cyclingDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [cyclingDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [cyclingDB] SET ARITHABORT OFF
GO
ALTER DATABASE [cyclingDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [cyclingDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [cyclingDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [cyclingDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [cyclingDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [cyclingDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [cyclingDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [cyclingDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [cyclingDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [cyclingDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [cyclingDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [cyclingDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [cyclingDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [cyclingDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [cyclingDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [cyclingDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [cyclingDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [cyclingDB] SET RECOVERY FULL
GO
ALTER DATABASE [cyclingDB] SET  MULTI_USER
GO
ALTER DATABASE [cyclingDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [cyclingDB] SET DB_CHAINING OFF
GO
ALTER DATABASE [cyclingDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO
ALTER DATABASE [cyclingDB] SET TARGET_RECOVERY_TIME = 60 SECONDS
GO
ALTER DATABASE [cyclingDB] SET DELAYED_DURABILITY = DISABLED
GO
ALTER DATABASE [cyclingDB] SET ACCELERATED_DATABASE_RECOVERY = OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'cyclingDB', N'ON'
GO
ALTER DATABASE [cyclingDB] SET QUERY_STORE = OFF
GO
USE [cyclingDB]

GO
/****** Object:  Table [dbo].[Calendrier]    Script Date: 14-08-22 15:11:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendrier](
    [idcalendrier] [int] IDENTITY(1,1) NOT NULL,
    [idcat] [int] NULL,
    [idride] [int] NULL,
    CONSTRAINT [uniqueconstr] UNIQUE NONCLUSTERED /*possible erreur*/
(
[idride] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]

    GO
/****** Object:  Table [dbo].[Car]    Script Date: 09-01-22 13:57:54 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Car](
    [IdCar] [int] IDENTITY(1,1) NOT NULL,
    [IdCarClient] [int] NOT NULL,
    [CarSeat] [int] NULL,
    [CarBike] [int] NULL,
    [CarBrand] [nvarchar](50) NULL,
    CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED
(
[IdCar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]


    GO
/****** Object:  Table [dbo].[Category]    Script Date: 09-01-22 13:57:54 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Category](
    [IdCat] [int] NOT NULL,
    [CatName] [nvarchar](50) NOT NULL,
    [IdCatResp] [int] NOT NULL
    ) ON [PRIMARY]


    GO
/****** Object:  Table [dbo].[Clients]    Script Date: 09-01-22 13:57:54 ******/
    SET ANSI_NULLS ON


    GO
    SET QUOTED_IDENTIFIER ON


    GO
CREATE TABLE [dbo].[Clients](
    [IdClient] [int] NOT NULL,
    [ClientLogin] [nvarchar](50) NOT NULL,
    [FirstName] [nvarchar](50) NULL,
    [LastName] [nvarchar](50) NULL,
    [Tel] [nvarchar](max) NULL,
    [Password] [nvarchar](50) NOT NULL,
    [Wallet] [int] NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED
(
[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Inscription]    Script Date: 14-08-22 15:11:04 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Inscription](
    [idinscription] [int] IDENTITY(1,1) NOT NULL,
    [passager] [int] NULL,
    [velo] [int] NULL,
    [idClientRef] [int] NULL,
    [idbalade] [int] NULL,
    [idvelo] [int] NULL
    ) ON [PRIMARY]

    GO
/****** Object:  Table [dbo].[LinkCarToRide]    Script Date: 09-01-22 13:57:54 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[LinkCarToRide](
    [IdLinkCarToLinkRide] [int] IDENTITY(1,1) NOT NULL,
    [IdCar] [int] NULL,
    [IdLinkRide] [int] NULL,
    CONSTRAINT [PK_LinkCarToRide] PRIMARY KEY CLUSTERED
(
[IdLinkCarToLinkRide] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]


    GO
/****** Object:  Table [dbo].[LinkCat]    Script Date: 09-01-22 13:57:54 ******/
    SET ANSI_NULLS ON


    GO
    SET QUOTED_IDENTIFIER ON


    GO
CREATE TABLE [dbo].[LinkCat](
    [IdLink] [int] IDENTITY(1,1) NOT NULL,
    [IdCliCat] [int] NOT NULL,
    [IdCatLink] [int] NOT NULL,
    CONSTRAINT [PK_LinkCat] PRIMARY KEY CLUSTERED
(
[IdLink] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]


    GO
/****** Object:  Table [dbo].[LinkRide]    Script Date: 09-01-22 13:57:54 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[LinkRide](
    [IdLink] [int] IDENTITY(1,1) NOT NULL,
    [IdCliRide] [int] NULL,
    [IdRide] [int] NULL,
    CONSTRAINT [PK_LinkRide] PRIMARY KEY CLUSTERED
(
[IdLink] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[LinkVeloInscr]    Script Date: 14-08-22 15:11:04 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[LinkVeloInscr](
    [idVeloInscr] [int] IDENTITY(1,1) NOT NULL,
    [idvelo] [int] NULL,
    [idinscr] [int] NULL
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[LinkVeloVehicule]    Script Date: 14-08-22 15:11:04 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[LinkVeloVehicule](
    [IdVeloVehicule] [int] IDENTITY(1,1) NOT NULL,
    [idVelo] [int] NULL,
    [idVehicule] [int] NULL
    ) ON [PRIMARY]

    GO
/****** Object:  Table [dbo].[Ride]    Script Date: 09-01-22 13:57:54 ******/
    SET ANSI_NULLS ON


    GO
    SET QUOTED_IDENTIFIER ON


    GO
CREATE TABLE [dbo].[Ride](
    [IdRide] [int] IDENTITY(1,1) NOT NULL,
    [DeparturePlace] [nvarchar](50) NOT NULL,
    [DepartureDate] [nvarchar](50) NULL,
    [DepartureHour] [nvarchar](50) NULL,
    [RidePrice] [int] NULL,
    [MaxClient] [int] NULL,
/**current bike et clients supprimé***/
    CONSTRAINT [PK_Ride] PRIMARY KEY CLUSTERED
(
[IdRide] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]


    GO
/****** Object:  Table [dbo].[Tresorier]    Script Date: 09-01-22 13:57:54 ******/
    SET ANSI_NULLS ON


    GO
    SET QUOTED_IDENTIFIER ON


    GO
CREATE TABLE [dbo].[Tresorier](
    [IdTresorier] [int] IDENTITY(1,1) NOT NULL,
    [IdCliTreso] [int] NOT NULL,
    CONSTRAINT [PK_Tresorier] PRIMARY KEY CLUSTERED
(
[IdTresorier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Velo]    Script Date: 14-08-22 15:11:04 ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Velo](
    [idvelo] [int] IDENTITY(1,1) NOT NULL,
    [poids] [float] NULL,
    [type] [varchar](50) NULL,
    [longueur] [float] NULL,
    [idclientref] [int] NULL
    ) ON [PRIMARY]

    GO
    SET IDENTITY_INSERT [dbo].[Car] ON

    INSERT [dbo].[Car] ([IdCar], [IdCarClient], [CarSeat], [CarBike], [CarBrand]) VALUES (1, 1, 5, 1, N'Volvo')
    INSERT [dbo].[Car] ([IdCar], [IdCarClient], [CarSeat], [CarBike], [CarBrand]) VALUES (3, 3, 4, 2, N'Smart')
    INSERT [dbo].[Car] ([IdCar], [IdCarClient], [CarSeat], [CarBike], [CarBrand]) VALUES (6, 2, 3, 2, N'Volvo')
    INSERT [dbo].[Car] ([IdCar], [IdCarClient], [CarSeat], [CarBike], [CarBrand]) VALUES (9, 2, 1, 1, N'Peugot')
    SET IDENTITY_INSERT [dbo].[Car] OFF


    GO
    SET IDENTITY_INSERT [dbo].[Calendrier] ON
    INSERT [dbo].[Calendrier] ([idcalendrier], [idcat], [idride]) VALUES (1, 1, 1)
    SET IDENTITY_INSERT [dbo].[Calendrier] OFF

    GO
    INSERT [dbo].[Category] ([IdCat], [CatName], [IdCatResp]) VALUES (1, N'Cyclo', 1)
    INSERT [dbo].[Category] ([IdCat], [CatName], [IdCatResp]) VALUES (2, N'Trialiste', 2)
    INSERT [dbo].[Category] ([IdCat], [CatName], [IdCatResp]) VALUES (3, N'Descente', 3)
    INSERT [dbo].[Category] ([IdCat], [CatName], [IdCatResp]) VALUES (4, N'Randonneur', 4)
    GO
    SET IDENTITY_INSERT [dbo].[Inscription] ON
    INSERT [dbo].[Inscription] ([idinscription], [passager], [velo], [idClientRef], [idbalade], [idvelo]) VALUES (1, 1, 1, 1, 1, 1)
    SET IDENTITY_INSERT [dbo].[Inscription] OFF
    GO
    INSERT [dbo].[Clients] ([IdClient], [ClientLogin], [FirstName], [LastName], [Tel], [Password], [Wallet]) VALUES (1, N'Admin', N'Armin', N'Ferai', N'0478495668', N'Admin', 13)
    INSERT [dbo].[Clients] ([IdClient], [ClientLogin], [FirstName], [LastName], [Tel], [Password], [Wallet]) VALUES (2, N'Jan', N'Jensen', N'Ackles', N'0458765898', N'Jan', 18)
    INSERT [dbo].[Clients] ([IdClient], [ClientLogin], [FirstName], [LastName], [Tel], [Password], [Wallet]) VALUES (3, N'Cristy', N'Cristy', N'Smeers', N'024798549', N'Cristy', 20)

    GO
    SET IDENTITY_INSERT [dbo].[LinkCarToRide] ON

    INSERT [dbo].[LinkCarToRide] ([IdLinkCarToLinkRide], [IdCar], [IdLinkRide]) VALUES (1, 1, 1)
    INSERT [dbo].[LinkCarToRide] ([IdLinkCarToLinkRide], [IdCar], [IdLinkRide]) VALUES (2, 1, 7)
    INSERT [dbo].[LinkCarToRide] ([IdLinkCarToLinkRide], [IdCar], [IdLinkRide]) VALUES (3, 6, 7)
    SET IDENTITY_INSERT [dbo].[LinkCarToRide] OFF


    GO
    SET IDENTITY_INSERT [dbo].[LinkCat] ON

    INSERT [dbo].[LinkCat] ([IdLink], [IdCliCat], [IdCatLink]) VALUES (18, 2, 1)
    INSERT [dbo].[LinkCat] ([IdLink], [IdCliCat], [IdCatLink]) VALUES (22, 1, 1)
    INSERT [dbo].[LinkCat] ([IdLink], [IdCliCat], [IdCatLink]) VALUES (23, 3, 1)
    INSERT [dbo].[LinkCat] ([IdLink], [IdCliCat], [IdCatLink]) VALUES (25, 1, 2)
    SET IDENTITY_INSERT [dbo].[LinkCat] OFF


    GO
    SET IDENTITY_INSERT [dbo].[LinkRide] ON

    INSERT [dbo].[LinkRide] ([IdLink], [IdCliRide], [IdRide]) VALUES (1, 1, 7)
    INSERT [dbo].[LinkRide] ([IdLink], [IdCliRide], [IdRide]) VALUES (6, 2, 7)
    INSERT [dbo].[LinkRide] ([IdLink], [IdCliRide], [IdRide]) VALUES (7, 1, 3)
    INSERT [dbo].[LinkRide] ([IdLink], [IdCliRide], [IdRide]) VALUES (8, 1, 1)
    SET IDENTITY_INSERT [dbo].[LinkRide] OFF

    GO
    SET IDENTITY_INSERT [dbo].[LinkVeloInscr] ON
    INSERT [dbo].[LinkVeloInscr] ([idVeloInscr], [idvelo], [idinscr]) VALUES (1, 1, 1)
    SET IDENTITY_INSERT [dbo].[LinkVeloInscr] OFF
    GO
    SET IDENTITY_INSERT [dbo].[LinkVeloVehicule] ON
    INSERT [dbo].[LinkVeloVehicule] ([idVeloVehicule], [idVelo], [idVehicule]) VALUES (1, 1, 1)
    SET IDENTITY_INSERT [dbo].[LinkVeloVehicule] OFF

    GO
    SET IDENTITY_INSERT [dbo].[Ride] ON

    INSERT [dbo].[Ride] ([IdRide], [DeparturePlace], [DepartureDate], [DepartureHour], [RidePrice], [MaxClient]) VALUES (1, N'Cycling Club', N'20/04/2022', N'12:00', 2, 5)
    INSERT [dbo].[Ride] ([IdRide], [DeparturePlace], [DepartureDate], [DepartureHour], [RidePrice], [MaxClient]) VALUES (2, N'Cycling Club', N'21/04/2022', N'14:00', 3, 3)
    INSERT [dbo].[Ride] ([IdRide], [DeparturePlace], [DepartureDate], [DepartureHour], [RidePrice], [MaxClient]) VALUES (3, N'Blackwood Shop', N'22/04/2022', N'13:00', 2, 2)
    INSERT [dbo].[Ride] ([IdRide], [DeparturePlace], [DepartureDate], [DepartureHour], [RidePrice], [MaxClient]) VALUES (7, N'Everfall', N'24/04/2022', N'16:00', 1, 1)
    SET IDENTITY_INSERT [dbo].[Ride] OFF


    GO
    SET IDENTITY_INSERT [dbo].[Tresorier] ON

    INSERT [dbo].[Tresorier] ([IdTresorier], [IdCliTreso]) VALUES (1, 3)
    SET IDENTITY_INSERT [dbo].[Tresorier] OFF

    GO
    SET IDENTITY_INSERT [dbo].[Velo] ON
    INSERT [dbo].[Velo] ([idvelo], [poids], [type],[longueur], [idclientref]) VALUES (1, 25.9, N'Cyclo', 20, 1)
    SET IDENTITY_INSERT [dbo].[Velo] OFF

    GO


    GO
    USE [master]


    GO
ALTER DATABASE [cyclingDB] SET  READ_WRITE
GO
