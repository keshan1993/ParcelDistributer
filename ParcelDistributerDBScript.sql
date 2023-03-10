USE [master]
GO
/****** Object:  Database [DistributerDB]    Script Date: 2/13/2023 6:48:27 AM ******/
CREATE DATABASE [DistributerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DistributerDB', FILENAME = N'C:\Users\ESyAdmin\Desktop\MSSQL15.SQLEXPRESS\MSSQL\DATA\DistributerDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DistributerDB_log', FILENAME = N'C:\Users\ESyAdmin\Desktop\MSSQL15.SQLEXPRESS\MSSQL\DATA\DistributerDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DistributerDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DistributerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DistributerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DistributerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DistributerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DistributerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DistributerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DistributerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DistributerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DistributerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DistributerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DistributerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DistributerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DistributerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DistributerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DistributerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DistributerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DistributerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DistributerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DistributerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DistributerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DistributerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DistributerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DistributerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DistributerDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DistributerDB] SET  MULTI_USER 
GO
ALTER DATABASE [DistributerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DistributerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DistributerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DistributerDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DistributerDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DistributerDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DistributerDB] SET QUERY_STORE = OFF
GO
USE [DistributerDB]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 2/13/2023 6:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[numBookingID] [int] IDENTITY(1,1) NOT NULL,
	[varBookingNo] [varchar](50) NULL,
	[numCustomerID] [int] NULL,
	[dtDeliveryDate] [datetime] NULL,
	[varFromAddress] [varchar](100) NULL,
	[varToAddress] [varchar](100) NULL,
	[numDistance] [decimal](18, 2) NULL,
	[numGoodsTypeID] [int] NULL,
	[numWeight] [decimal](18, 2) NULL,
	[numPrice] [decimal](18, 2) NULL,
	[bitIsApproved] [bit] NULL,
	[numDriverID] [int] NULL,
	[dtApprovedDateTime] [datetime] NULL,
	[bitIsStarted] [bit] NULL,
	[dtStartedDateTime] [datetime] NULL,
	[bitIsCompleted] [bit] NULL,
	[dtCompletedDateTime] [datetime] NULL,
	[bitActive] [bit] NULL,
	[dtCreatedDate] [datetime] NULL,
	[numCreatedID] [int] NULL,
	[dtEditedDate] [datetime] NULL,
	[numEditedID] [int] NULL,
	[dtDeletedDate] [datetime] NULL,
	[numDeletedID] [int] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[numBookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/13/2023 6:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[numCustomerID] [int] IDENTITY(1,1) NOT NULL,
	[varCustomerName] [varchar](100) NULL,
	[varCustomerAddress] [varchar](100) NULL,
	[varCustomerNIC] [varchar](100) NULL,
	[varCustomerContactNo] [varchar](100) NULL,
	[bitActive] [bit] NULL,
	[dtCreatedDate] [datetime] NULL,
	[dteditedDate] [datetime] NULL,
	[dtDeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[numCustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Driver]    Script Date: 2/13/2023 6:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Driver](
	[numDriverID] [int] IDENTITY(1,1) NOT NULL,
	[varDriverName] [varchar](100) NULL,
	[varDriverAddress] [varchar](100) NULL,
	[varDriverNIC] [varchar](100) NULL,
	[varDriverContactNo] [varchar](100) NULL,
	[bitActive] [bit] NULL,
	[dtCreatedDate] [datetime] NULL,
	[dteditedDate] [datetime] NULL,
	[dtDeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED 
(
	[numDriverID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2/13/2023 6:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[numEmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[varEmployeeName] [varchar](100) NULL,
	[varEmployeeAddress] [varchar](100) NULL,
	[varEmployeeNIC] [varchar](100) NULL,
	[varEmployeeContactNo] [varchar](100) NULL,
	[bitActive] [bit] NULL,
	[dtCreatedDate] [datetime] NULL,
	[dteditedDate] [datetime] NULL,
	[dtDeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[numEmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoodsType]    Script Date: 2/13/2023 6:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoodsType](
	[numGoodsTypeID] [int] IDENTITY(1,1) NOT NULL,
	[varGoodsTypeName] [varchar](100) NULL,
	[varGoodsTypeDescription] [varchar](100) NULL,
	[bitActive] [bit] NULL,
	[dtCreatedDate] [datetime] NULL,
	[dteditedDate] [datetime] NULL,
	[dtDeletedDate] [datetime] NULL,
 CONSTRAINT [PK_GoodsType] PRIMARY KEY CLUSTERED 
(
	[numGoodsTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoodsWeightPrice]    Script Date: 2/13/2023 6:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoodsWeightPrice](
	[numGoodsWeightPriceID] [int] IDENTITY(1,1) NOT NULL,
	[numGoodsTypeID] [int] NULL,
	[numWeightFrom] [decimal](18, 2) NULL,
	[numDistanceFrom] [decimal](18, 2) NULL,
	[numDistanceTo] [decimal](18, 2) NULL,
	[numWeightTo] [decimal](18, 2) NULL,
	[numPrice] [decimal](18, 2) NULL,
	[bitActive] [bit] NULL,
	[dtCreatedDate] [datetime] NULL,
	[dteditedDate] [datetime] NULL,
	[dtDeletedDate] [datetime] NULL,
 CONSTRAINT [PK_GoodsWeightPrice] PRIMARY KEY CLUSTERED 
(
	[numGoodsWeightPriceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/13/2023 6:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[numUserID] [int] IDENTITY(1,1) NOT NULL,
	[varUserName] [varchar](50) NULL,
	[varUserPassword] [varchar](50) NULL,
	[bitIsCustomer] [bit] NULL,
	[numCustomerID] [int] NULL,
	[bitIsDriver] [bit] NULL,
	[numDriverID] [int] NULL,
	[bitIsEmployee] [bit] NULL,
	[numEmployeeID] [int] NULL,
	[bitActive] [bit] NULL,
	[dtCreatedDate] [datetime] NULL,
	[dteditedDate] [datetime] NULL,
	[dtDeletedDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[numUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customer] FOREIGN KEY([numCustomerID])
REFERENCES [dbo].[Customer] ([numCustomerID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customer]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Driver] FOREIGN KEY([numDriverID])
REFERENCES [dbo].[Driver] ([numDriverID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Driver]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_GoodsType] FOREIGN KEY([numGoodsTypeID])
REFERENCES [dbo].[GoodsType] ([numGoodsTypeID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_GoodsType]
GO
ALTER TABLE [dbo].[GoodsWeightPrice]  WITH CHECK ADD  CONSTRAINT [FK_GoodsWeightPrice_GoodsType] FOREIGN KEY([numGoodsTypeID])
REFERENCES [dbo].[GoodsType] ([numGoodsTypeID])
GO
ALTER TABLE [dbo].[GoodsWeightPrice] CHECK CONSTRAINT [FK_GoodsWeightPrice_GoodsType]
GO
/****** Object:  StoredProcedure [dbo].[spFindAvailableDriver]    Script Date: 2/13/2023 6:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[spFindAvailableDriver]
(
	@dtDeliveryDate			DATETIME
)
AS
BEGIN

	SELECT numDriverID,varDriverName,varDriverAddress,varDriverNIC,varDriverContactNo,bitActive,dtCreatedDate,dteditedDate,dtDeletedDate
	FROM dbo.Driver
	WHERE numDriverID NOT IN (SELECT numDriverID FROM dbo.Booking WHERE dtDeliveryDate = @dtDeliveryDate AND bitActive = 1)

END
GO
USE [master]
GO
ALTER DATABASE [DistributerDB] SET  READ_WRITE 
GO
