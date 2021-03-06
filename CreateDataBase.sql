USE [master]
GO
/****** Object:  Database [dbDataWareHouse]    Script Date: 20/1/2020 00:44:45 ******/
CREATE DATABASE [dbDataWareHouse]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbDataWareHouse', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\dbDataWareHouse.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbDataWareHouse_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\dbDataWareHouse_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbDataWareHouse] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbDataWareHouse].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbDataWareHouse] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbDataWareHouse] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbDataWareHouse] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbDataWareHouse] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbDataWareHouse] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET RECOVERY FULL 
GO
ALTER DATABASE [dbDataWareHouse] SET  MULTI_USER 
GO
ALTER DATABASE [dbDataWareHouse] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbDataWareHouse] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbDataWareHouse] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbDataWareHouse] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbDataWareHouse] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbDataWareHouse', N'ON'
GO
ALTER DATABASE [dbDataWareHouse] SET QUERY_STORE = OFF
GO
USE [dbDataWareHouse]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [dbDataWareHouse]
GO
/****** Object:  User [admin]    Script Date: 20/1/2020 00:44:45 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 20/1/2020 00:44:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[sku] [int] IDENTITY(1,1) NOT NULL,
	[qty] [int] NOT NULL,
	[description] [varchar](500) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[sku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 20/1/2020 00:44:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[orderId] [int] IDENTITY(1,1) NOT NULL,
	[userId] [varchar](50) NOT NULL,
	[sku] [int] NOT NULL,
	[shippingAddress] [varchar](500) NOT NULL,
	[qty] [int] NOT NULL,
	[statusId] [varchar](3) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersHistory]    Script Date: 20/1/2020 00:44:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersHistory](
	[idHistory] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
	[creationDate] [date] NOT NULL,
	[statusId] [varchar](3) NOT NULL,
 CONSTRAINT [PK_OrdersHistory] PRIMARY KEY CLUSTERED 
(
	[idHistory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 20/1/2020 00:44:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[rolId] [varchar](50) NOT NULL,
	[description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[rolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusOrders]    Script Date: 20/1/2020 00:44:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusOrders](
	[statusId] [varchar](3) NOT NULL,
	[description] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Status_Orders] PRIMARY KEY CLUSTERED 
(
	[statusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20/1/2020 00:44:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userId] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[rolId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([sku], [qty], [description], [price]) VALUES (1, 10, N'Decription test update firts item', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([sku], [qty], [description], [price]) VALUES (2, 10, N'Graphic card Nvidia', CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([sku], [qty], [description], [price]) VALUES (3, 10, N'Graphic card AMD', CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([sku], [qty], [description], [price]) VALUES (4, 5, N'Decription Test new item', CAST(58.61 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Items] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([orderId], [userId], [sku], [shippingAddress], [qty], [statusId], [price]) VALUES (2, N'admin', 1, N'Bulevar Sergio Viera De Mello 243, San Salvador', 5, N'OPN', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([orderId], [userId], [sku], [shippingAddress], [qty], [statusId], [price]) VALUES (3, N'admin', 1, N'Bulevar Sergio Viera De Mello 243, San Salvador', 5, N'CAN', CAST(50.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[OrdersHistory] ON 

INSERT [dbo].[OrdersHistory] ([idHistory], [orderId], [creationDate], [statusId]) VALUES (1, 3, CAST(N'2020-01-19' AS Date), N'OPN')
INSERT [dbo].[OrdersHistory] ([idHistory], [orderId], [creationDate], [statusId]) VALUES (2, 3, CAST(N'2020-01-19' AS Date), N'CAN')
SET IDENTITY_INSERT [dbo].[OrdersHistory] OFF
INSERT [dbo].[Roles] ([rolId], [description]) VALUES (N'ADM', N'Administrator')
INSERT [dbo].[Roles] ([rolId], [description]) VALUES (N'CTM', N'Customer')
INSERT [dbo].[StatusOrders] ([statusId], [description]) VALUES (N'CAN', N'Cancelada')
INSERT [dbo].[StatusOrders] ([statusId], [description]) VALUES (N'OPN', N'Abierta')
INSERT [dbo].[Users] ([userId], [password], [rolId]) VALUES (N'admin', N'123456', N'ADM')
INSERT [dbo].[Users] ([userId], [password], [rolId]) VALUES (N'customer', N'123456', N'CTM')
INSERT [dbo].[Users] ([userId], [password], [rolId]) VALUES (N'pgs360', N'123456', N'CTM')
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Items] FOREIGN KEY([sku])
REFERENCES [dbo].[Items] ([sku])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Items]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_StatusOrders] FOREIGN KEY([statusId])
REFERENCES [dbo].[StatusOrders] ([statusId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_StatusOrders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([userId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[OrdersHistory]  WITH CHECK ADD  CONSTRAINT [FK_OrdersHistory_Orders] FOREIGN KEY([orderId])
REFERENCES [dbo].[Orders] ([orderId])
GO
ALTER TABLE [dbo].[OrdersHistory] CHECK CONSTRAINT [FK_OrdersHistory_Orders]
GO
ALTER TABLE [dbo].[OrdersHistory]  WITH CHECK ADD  CONSTRAINT [FK_OrdersHistory_Status_Orders] FOREIGN KEY([statusId])
REFERENCES [dbo].[StatusOrders] ([statusId])
GO
ALTER TABLE [dbo].[OrdersHistory] CHECK CONSTRAINT [FK_OrdersHistory_Status_Orders]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([rolId])
REFERENCES [dbo].[Roles] ([rolId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [dbDataWareHouse] SET  READ_WRITE 
GO
