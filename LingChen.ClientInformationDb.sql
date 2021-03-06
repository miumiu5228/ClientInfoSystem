USE [master]
GO
/****** Object:  Database [LingChenClientInformation]    Script Date: 7/28/2021 10:52:19 AM ******/
CREATE DATABASE [LingChenClientInformation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LingChenClientInformation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LingChenClientInformation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LingChenClientInformation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LingChenClientInformation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LingChenClientInformation] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LingChenClientInformation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LingChenClientInformation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET ARITHABORT OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LingChenClientInformation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LingChenClientInformation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LingChenClientInformation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LingChenClientInformation] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [LingChenClientInformation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET RECOVERY FULL 
GO
ALTER DATABASE [LingChenClientInformation] SET  MULTI_USER 
GO
ALTER DATABASE [LingChenClientInformation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LingChenClientInformation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LingChenClientInformation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LingChenClientInformation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LingChenClientInformation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LingChenClientInformation] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LingChenClientInformation', N'ON'
GO
ALTER DATABASE [LingChenClientInformation] SET QUERY_STORE = OFF
GO
USE [LingChenClientInformation]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/28/2021 10:52:19 AM ******/
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
/****** Object:  Table [dbo].[Clients]    Script Date: 7/28/2021 10:52:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phones] [varchar](30) NULL,
	[Address] [varchar](100) NULL,
	[AddedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 7/28/2021 10:52:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Password] [varchar](10) NULL,
	[Designation] [varchar](50) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interactions]    Script Date: 7/28/2021 10:52:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[EmpId] [int] NOT NULL,
	[IntType] [char](1) NOT NULL,
	[IntDate] [datetime] NOT NULL,
	[Remarks] [varchar](500) NULL,
 CONSTRAINT [PK_Interactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Interactions_ClientId]    Script Date: 7/28/2021 10:52:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Interactions_ClientId] ON [dbo].[Interactions]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Interactions_EmpId]    Script Date: 7/28/2021 10:52:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Interactions_EmpId] ON [dbo].[Interactions]
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Interactions]  WITH CHECK ADD  CONSTRAINT [FK_Interactions_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Interactions] CHECK CONSTRAINT [FK_Interactions_Clients_ClientId]
GO
ALTER TABLE [dbo].[Interactions]  WITH CHECK ADD  CONSTRAINT [FK_Interactions_Employees_EmpId] FOREIGN KEY([EmpId])
REFERENCES [dbo].[Employees] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Interactions] CHECK CONSTRAINT [FK_Interactions_Employees_EmpId]
GO
USE [master]
GO
ALTER DATABASE [LingChenClientInformation] SET  READ_WRITE 
GO
