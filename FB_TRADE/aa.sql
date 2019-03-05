USE [master]
GO
/****** Object:  Database [fb_trade]    Script Date: 2019/3/5 21:08:23 ******/
CREATE DATABASE [fb_trade]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'fb_trade', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\fb_trade.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'fb_trade_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\fb_trade_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [fb_trade] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [fb_trade].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [fb_trade] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [fb_trade] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [fb_trade] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [fb_trade] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [fb_trade] SET ARITHABORT OFF 
GO
ALTER DATABASE [fb_trade] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [fb_trade] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [fb_trade] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [fb_trade] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [fb_trade] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [fb_trade] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [fb_trade] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [fb_trade] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [fb_trade] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [fb_trade] SET  DISABLE_BROKER 
GO
ALTER DATABASE [fb_trade] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [fb_trade] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [fb_trade] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [fb_trade] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [fb_trade] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [fb_trade] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [fb_trade] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [fb_trade] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [fb_trade] SET  MULTI_USER 
GO
ALTER DATABASE [fb_trade] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [fb_trade] SET DB_CHAINING OFF 
GO
ALTER DATABASE [fb_trade] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [fb_trade] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [fb_trade] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [fb_trade] SET QUERY_STORE = OFF
GO
USE [fb_trade]
GO
/****** Object:  Table [dbo].[tb_admins]    Script Date: 2019/3/5 21:08:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_admins](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[pwd] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_tb_admins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_tb_admins_name] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_contacts]    Script Date: 2019/3/5 21:08:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_contacts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fbAccountId] [int] NOT NULL,
	[customerId] [nvarchar](20) NOT NULL,
	[time] [datetime] NOT NULL,
	[content] [text] NOT NULL,
 CONSTRAINT [PK_tb_contacts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbAccounts]    Script Date: 2019/3/5 21:08:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbAccounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[fbAccount] [nvarchar](50) NOT NULL,
	[fbPwd] [nvarchar](20) NULL,
	[fbId] [nvarchar](20) NULL,
	[fbUrl] [nvarchar](50) NULL,
	[note] [text] NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_tb_fbAccounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_tb_fbAccounts_account] UNIQUE NONCLUSTERED 
(
	[fbAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_tb_fbAccounts_name] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbCustomers]    Script Date: 2019/3/5 21:08:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbCustomers](
	[fbId] [nvarchar](20) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[fbUrl] [nvarchar](50) NOT NULL,
	[friendsNum] [int] NULL,
	[country] [nvarchar](20) NULL,
	[state] [nvarchar](20) NULL,
	[city] [nvarchar](20) NULL,
	[introduction] [text] NULL,
	[friendShips] [text] NULL,
	[relationType] [int] NULL,
	[customerType] [int] NULL,
	[ordersNum] [int] NULL,
	[interestedGoods] [text] NULL,
	[note] [text] NULL,
	[traceDate] [date] NULL,
	[lastContactId] [int] NULL,
	[createDate] [date] NULL,
	[createFbId] [int] NULL,
 CONSTRAINT [PK_tb_fbCustomers_1] PRIMARY KEY CLUSTERED 
(
	[fbId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_tb_fbCustomers_url] UNIQUE NONCLUSTERED 
(
	[fbUrl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbGroups]    Script Date: 2019/3/5 21:08:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbGroups](
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_orders]    Script Date: 2019/3/5 21:08:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_orders](
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_users]    Script Date: 2019/3/5 21:08:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[pwd] [nvarchar](20) NOT NULL,
	[adminId] [int] NOT NULL,
 CONSTRAINT [PK_tb_users_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_tb_users_name] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_contacts]  WITH CHECK ADD  CONSTRAINT [FK_tb_contacts_tb_fbAccounts_fbAccountId] FOREIGN KEY([fbAccountId])
REFERENCES [dbo].[tb_fbAccounts] ([id])
GO
ALTER TABLE [dbo].[tb_contacts] CHECK CONSTRAINT [FK_tb_contacts_tb_fbAccounts_fbAccountId]
GO
ALTER TABLE [dbo].[tb_contacts]  WITH CHECK ADD  CONSTRAINT [FK_tb_contacts_tb_fbCustomers_customerId] FOREIGN KEY([customerId])
REFERENCES [dbo].[tb_fbCustomers] ([fbId])
GO
ALTER TABLE [dbo].[tb_contacts] CHECK CONSTRAINT [FK_tb_contacts_tb_fbCustomers_customerId]
GO
ALTER TABLE [dbo].[tb_fbAccounts]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbAccounts_userId_tb_users] FOREIGN KEY([userId])
REFERENCES [dbo].[tb_users] ([id])
GO
ALTER TABLE [dbo].[tb_fbAccounts] CHECK CONSTRAINT [FK_tb_fbAccounts_userId_tb_users]
GO
USE [master]
GO
ALTER DATABASE [fb_trade] SET  READ_WRITE 
GO
