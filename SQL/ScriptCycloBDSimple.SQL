USE [master]
GO
CREATE DATABASE [cyclingDB]

GO
USE [cyclingDB]

GO
CREATE TABLE [dbo].[Calendrier](
    [idcalendrier] [int] IDENTITY(1,1) NOT NULL,
    [idcat] [int] NULL,
    [idride] [int] NULL)

    GO
CREATE TABLE [dbo].[Car](
    [IdCar] [int] IDENTITY(1,1) NOT NULL,
    [IdCarClient] [int] NOT NULL,
    [CarSeat] [int] NULL,
    [CarBike] [int] NULL,
    [CarBrand] [nvarchar](50) NULL)

    GO
CREATE TABLE [dbo].[Category](
    [IdCat] [int] NOT NULL,
    [CatName] [nvarchar](50) NOT NULL,
    [IdCatResp] [int] NOT NULL)


    GO
CREATE TABLE [dbo].[Clients](
    [IdClient] [int] NOT NULL,
    [ClientLogin] [nvarchar](50) NOT NULL,
    [FirstName] [nvarchar](50) NULL,
    [LastName] [nvarchar](50) NULL,
    [Tel] [nvarchar](max) NULL,
    [Password] [nvarchar](50) NOT NULL,
    [Wallet] [int] NULL)
    GO
CREATE TABLE [dbo].[Inscription](
    [idinscription] [int] IDENTITY(1,1) NOT NULL,
    [passager] [int] NULL,
    [velo] [int] NULL,
    [idClientRef] [int] NULL,
    [idbalade] [int] NULL,
    [idvelo] [int] NULL)

    GO
CREATE TABLE [dbo].[LinkCarToRide](
    [IdLinkCarToLinkRide] [int] IDENTITY(1,1) NOT NULL,
    [IdCar] [int] NULL,
    [IdLinkRide] [int] NULL)
    GO
CREATE TABLE [dbo].[LinkCat](
    [IdLink] [int] IDENTITY(1,1) NOT NULL,
    [IdClient] [int] NOT NULL,
    [IdCategory] [int] NOT NULL)
    GO
CREATE TABLE [dbo].[LinkRide](
    [IdLink] [int] IDENTITY(1,1) NOT NULL,
    [IdCliRide] [int] NULL,
    [IdRide] [int] NULL)

    GO
CREATE TABLE [dbo].[LinkVeloInscr](
    [idVeloInscr] [int] IDENTITY(1,1) NOT NULL,
    [idvelo] [int] NULL,
    [idinscr] [int] NULL)
    GO
CREATE TABLE [dbo].[LinkVeloVehicule](
    [IdVeloVehicule] [int] IDENTITY(1,1) NOT NULL,
    [idVelo] [int] NULL,
    [idVehicule] [int] NULL)
    GO
CREATE TABLE [dbo].[Ride](
    [IdRide] [int] IDENTITY(1,1) NOT NULL,
    [DeparturePlace] [nvarchar](50) NOT NULL,
    [DepartureDate] [nvarchar](50) NULL,
    [DepartureHour] [nvarchar](50) NULL,
    [IdCatRide] [int] NULL,
    [RidePrice] [int] NULL,
    [MaxClient] [int] NULL)
    GO
CREATE TABLE [dbo].[Tresorier](
    [IdTresorier] [int] IDENTITY(1,1) NOT NULL,
    [IdCliTreso] [int] NOT NULL)
    GO
CREATE TABLE [dbo].[Velo](
    [idvelo] [int] IDENTITY(1,1) NOT NULL,
    [poids] [int] NULL,
    [type] [varchar](50) NULL,
    [longueur] [int] NULL,
    [idclientref] [int] NULL)
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
    INSERT [dbo].[Clients] ([IdClient], [ClientLogin], [FirstName], [LastName], [Tel], [Password], [Wallet]) VALUES (4, N'Troy', N'Bolton', N'Troy', N'0478495667', N'Troy', 0)
    INSERT [dbo].[Clients] ([IdClient], [ClientLogin], [FirstName], [LastName], [Tel], [Password], [Wallet]) VALUES (5, N'Paul', N'Snow', N'Paul', N'0458765896', N'Paul', 0)
    INSERT [dbo].[Clients] ([IdClient], [ClientLogin], [FirstName], [LastName], [Tel], [Password], [Wallet]) VALUES (6, N'Marc', N'Pieters', N'Marc', N'024798542', N'Marc', 0)
    GO
    SET IDENTITY_INSERT [dbo].[LinkCarToRide] ON

    INSERT [dbo].[LinkCarToRide] ([IdLinkCarToLinkRide], [IdCar], [IdLinkRide]) VALUES (1, 1, 1)
    INSERT [dbo].[LinkCarToRide] ([IdLinkCarToLinkRide], [IdCar], [IdLinkRide]) VALUES (2, 1, 7)
    INSERT [dbo].[LinkCarToRide] ([IdLinkCarToLinkRide], [IdCar], [IdLinkRide]) VALUES (3, 6, 7)
    SET IDENTITY_INSERT [dbo].[LinkCarToRide] OFF


    GO
    SET IDENTITY_INSERT [dbo].[LinkCat] ON

    INSERT [dbo].[LinkCat] ([IdLink], [IdClient], [IdCategory]) VALUES (18, 2, 1)
    INSERT [dbo].[LinkCat] ([IdLink], [IdClient], [IdCategory]) VALUES (22, 6, 3)
    INSERT [dbo].[LinkCat] ([IdLink], [IdClient], [IdCategory]) VALUES (23, 6, 1)
    INSERT [dbo].[LinkCat] ([IdLink], [IdClient], [IdCategory]) VALUES (25, 6, 2)
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

    INSERT [dbo].[Ride] ([IdRide], [DeparturePlace], [DepartureDate], [DepartureHour],[IdCatRide], [RidePrice], [MaxClient]) VALUES (1, N'Cycling Club', N'20/04/2022', N'12:00',1, 2, 5)
    INSERT [dbo].[Ride] ([IdRide], [DeparturePlace], [DepartureDate], [DepartureHour],[IdCatRide], [RidePrice], [MaxClient]) VALUES (2, N'Cycling Club', N'21/04/2022', N'14:00',2, 3, 3)
    INSERT [dbo].[Ride] ([IdRide], [DeparturePlace], [DepartureDate], [DepartureHour],[IdCatRide], [RidePrice], [MaxClient]) VALUES (3, N'Blackwood Shop', N'22/04/2022', N'13:00',3, 2, 2)
    INSERT [dbo].[Ride] ([IdRide], [DeparturePlace], [DepartureDate], [DepartureHour],[IdCatRide], [RidePrice], [MaxClient]) VALUES (4, N'Cycling Club', N'21/04/2022', N'12:00',1, 2, 5)
    INSERT [dbo].[Ride] ([IdRide], [DeparturePlace], [DepartureDate], [DepartureHour],[IdCatRide], [RidePrice], [MaxClient]) VALUES (5, N'Cycling Club', N'22/04/2022', N'12:00',1, 2, 5)
    INSERT [dbo].[Ride] ([IdRide], [DeparturePlace], [DepartureDate], [DepartureHour],[IdCatRide], [RidePrice], [MaxClient]) VALUES (6, N'Cycling Shop', N'22/12/2022', N'12:00',1, 2, 5)
    INSERT [dbo].[Ride] ([IdRide], [DeparturePlace], [DepartureDate], [DepartureHour],[IdCatRide], [RidePrice], [MaxClient]) VALUES (7, N'Everfall', N'24/04/2022', N'16:00',4, 1, 1)
    SET IDENTITY_INSERT [dbo].[Ride] OFF


    GO
    SET IDENTITY_INSERT [dbo].[Tresorier] ON

    INSERT [dbo].[Tresorier] ([IdTresorier], [IdCliTreso]) VALUES (1, 5)
    SET IDENTITY_INSERT [dbo].[Tresorier] OFF

    GO
    SET IDENTITY_INSERT [dbo].[Velo] ON
    INSERT [dbo].[Velo] ([idvelo], [poids], [type],[longueur], [idclientref]) VALUES (1, 25, N'Cyclo', 20, 1)
    INSERT [dbo].[Velo] ([idvelo], [poids], [type],[longueur], [idclientref]) VALUES (2, 30, N'Cyclo', 25, 1)
    INSERT [dbo].[Velo] ([idvelo], [poids], [type],[longueur], [idclientref]) VALUES (3, 15, N'VTT', 15, 1)
    INSERT [dbo].[Velo] ([idvelo], [poids], [type],[longueur], [idclientref]) VALUES (4, 30, N'Trialiste', 25, 2)
    SET IDENTITY_INSERT [dbo].[Velo] OFF

    GO


    GO
    USE [master]


    GO
ALTER DATABASE [cyclingDB] SET  READ_WRITE
GO
