USE [master]
GO
/****** Object:  Database [WaterTruck]    Script Date: 29/11/2024 8:39:31 pm ******/
CREATE DATABASE [WaterTruck]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WaterTruck', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\WaterTruck.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WaterTruck_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\WaterTruck_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [WaterTruck] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WaterTruck].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WaterTruck] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WaterTruck] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WaterTruck] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WaterTruck] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WaterTruck] SET ARITHABORT OFF 
GO
ALTER DATABASE [WaterTruck] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WaterTruck] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WaterTruck] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WaterTruck] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WaterTruck] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WaterTruck] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WaterTruck] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WaterTruck] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WaterTruck] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WaterTruck] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WaterTruck] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WaterTruck] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WaterTruck] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WaterTruck] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WaterTruck] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WaterTruck] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WaterTruck] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WaterTruck] SET RECOVERY FULL 
GO
ALTER DATABASE [WaterTruck] SET  MULTI_USER 
GO
ALTER DATABASE [WaterTruck] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WaterTruck] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WaterTruck] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WaterTruck] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WaterTruck] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WaterTruck] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WaterTruck', N'ON'
GO
ALTER DATABASE [WaterTruck] SET QUERY_STORE = ON
GO
ALTER DATABASE [WaterTruck] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [WaterTruck]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 29/11/2024 8:39:31 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[Role] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArchivedOrders]    Script Date: 29/11/2024 8:39:31 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArchivedOrders](
	[OrderID] [int] NOT NULL,
	[CustomerID] [int] NULL,
	[Item] [nvarchar](100) NULL,
	[Price] [decimal](10, 2) NULL,
	[Quantity] [int] NULL,
	[TotalPrice] [decimal](10, 2) NULL,
	[OrderDate] [datetime] NULL,
	[DeliveryDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[ModeOfPayment] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 29/11/2024 8:39:31 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Address] [text] NOT NULL,
	[ContactNumber] [varchar](15) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[Role] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 29/11/2024 8:39:31 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Item] [varchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalPrice] [decimal](10, 2) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[ModeOfPayment] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Admins] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Admins] ADD  DEFAULT ('Admin') FOR [Role]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ('Customer') FOR [Role]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('Pending') FOR [Status]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('Cash on delivery') FOR [ModeOfPayment]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
USE [master]
GO
ALTER DATABASE [WaterTruck] SET  READ_WRITE 
GO
