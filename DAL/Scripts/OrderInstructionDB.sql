USE [master]
GO
/****** Object:  Database [OrderInstructionDB]    Script Date: 01/07/2025 11:05:43 PM ******/
CREATE DATABASE [OrderInstructionDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrderInstructionDB', FILENAME = N'C:\Users\Bodda\OrderInstructionDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OrderInstructionDB_log', FILENAME = N'C:\Users\Bodda\OrderInstructionDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OrderInstructionDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrderInstructionDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OrderInstructionDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OrderInstructionDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OrderInstructionDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OrderInstructionDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OrderInstructionDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OrderInstructionDB] SET  MULTI_USER 
GO
ALTER DATABASE [OrderInstructionDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OrderInstructionDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OrderInstructionDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OrderInstructionDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OrderInstructionDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OrderInstructionDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OrderInstructionDB] SET QUERY_STORE = OFF
GO
USE [OrderInstructionDB]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 01/07/2025 11:05:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instructions]    Script Date: 01/07/2025 11:05:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructions](
	[Id] [int] NOT NULL,
	[Value] [int] NOT NULL,
 CONSTRAINT [PK_Instructions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderInstructions]    Script Date: 01/07/2025 11:05:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInstructions](
	[OrderId] [nvarchar](100) NOT NULL,
	[InstructionId] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[Closed] [bit] NOT NULL,
 CONSTRAINT [PK_OrderInstructions] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[InstructionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubmitOrders]    Script Date: 01/07/2025 11:05:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubmitOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [nvarchar](100) NOT NULL,
	[InstructionValue] [int] NOT NULL,
 CONSTRAINT [PK_SubmitOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Orders] ([OrderId]) VALUES (N'O1')
INSERT [dbo].[Orders] ([OrderId]) VALUES (N'O2')
INSERT [dbo].[Orders] ([OrderId]) VALUES (N'O3')
INSERT [dbo].[Orders] ([OrderId]) VALUES (N'O4')
GO
INSERT [dbo].[Instructions] ([Id], [Value]) VALUES (1, 10)
INSERT [dbo].[Instructions] ([Id], [Value]) VALUES (2, 20)
INSERT [dbo].[Instructions] ([Id], [Value]) VALUES (3, 30)
INSERT [dbo].[Instructions] ([Id], [Value]) VALUES (4, 40)
GO
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O1', 1, 1, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O1', 2, 2, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O1', 3, 3, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O1', 4, 4, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O2', 1, 1, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O2', 2, 2, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O2', 3, 3, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O2', 4, 4, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O3', 1, 1, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O3', 2, 2, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O3', 3, 3, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O3', 4, 4, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O4', 1, 1, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O4', 2, 2, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O4', 3, 3, 0)
INSERT [dbo].[OrderInstructions] ([OrderId], [InstructionId], [Priority], [Closed]) VALUES (N'O4', 4, 4, 0)
GO
USE [master]
GO
ALTER DATABASE [OrderInstructionDB] SET  READ_WRITE 
GO
