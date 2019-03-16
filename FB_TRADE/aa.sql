USE [master]
GO
/****** Object:  Database [fb_trade]    Script Date: 2019/3/16 22:30:32 ******/
CREATE DATABASE [fb_trade]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'fb_trade', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\fb_trade.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'fb_trade_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\fb_trade_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[tb_admins]    Script Date: 2019/3/16 22:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_admins](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[pwd] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_tb_admins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbCustomerContacts]    Script Date: 2019/3/16 22:30:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbCustomerContacts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[marketFbId] [nvarchar](30) NOT NULL,
	[marketFbAccount] [nvarchar](50) NOT NULL,
	[customerFbId] [nvarchar](30) NOT NULL,
	[time] [datetime] NOT NULL,
	[content] [text] NOT NULL,
 CONSTRAINT [PK_tb_contacts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbCustomers]    Script Date: 2019/3/16 22:30:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbCustomers](
	[fbId] [nvarchar](30) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[fbUrl] [nvarchar](50) NOT NULL,
	[friendsNum] [nvarchar](30) NULL,
	[country] [nvarchar](30) NULL,
	[state] [nvarchar](30) NULL,
	[city] [nvarchar](30) NULL,
	[email] [nvarchar](30) NULL,
	[introduction] [text] NULL,
	[friendShips] [text] NULL,
	[shipName] [text] NULL,
	[shipPhone] [text] NULL,
	[shipAddress] [text] NULL,
 CONSTRAINT [PK_tb_fbCustomers_1] PRIMARY KEY CLUSTERED 
(
	[fbId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbCustomerShips]    Script Date: 2019/3/16 22:30:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbCustomerShips](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerFbId] [nvarchar](30) NOT NULL,
	[marketFbId] [nvarchar](30) NOT NULL,
	[shipType] [nvarchar](30) NOT NULL,
	[customerType] [nvarchar](30) NOT NULL,
	[interestedGoods] [text] NULL,
	[note] [text] NULL,
	[traceDate] [date] NULL,
	[lastEditTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tb_fbFriendShips] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbGroupLogs]    Script Date: 2019/3/16 22:30:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbGroupLogs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[groupFbId] [nvarchar](30) NOT NULL,
	[marketFbId] [nvarchar](30) NOT NULL,
	[marketFbAccount] [nvarchar](50) NOT NULL,
	[time] [datetime] NOT NULL,
	[logs] [text] NOT NULL,
 CONSTRAINT [PK_tb_fbGroupLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbGroups]    Script Date: 2019/3/16 22:30:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbGroups](
	[fbId] [nvarchar](30) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[fbUrl] [nvarchar](50) NOT NULL,
	[membersNum] [nvarchar](30) NULL,
	[introduction] [text] NULL,
	[gpSource] [nvarchar](30) NULL,
	[gpType] [nvarchar](30) NULL,
	[needVerify] [nvarchar](30) NULL,
 CONSTRAINT [PK_tb_fbGroups] PRIMARY KEY CLUSTERED 
(
	[fbId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbGroupShips]    Script Date: 2019/3/16 22:30:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbGroupShips](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[groupFbId] [nvarchar](30) NOT NULL,
	[marketFbId] [nvarchar](30) NOT NULL,
	[status] [text] NULL,
	[customersNum] [nvarchar](30) NULL,
	[contactCustomersNum] [nvarchar](30) NULL,
	[tradeCustomersNum] [nvarchar](30) NULL,
	[ordersNum] [nvarchar](30) NULL,
	[tweetsNum] [nvarchar](30) NULL,
	[tweetFeedback] [nvarchar](30) NULL,
	[mark] [text] NULL,
	[note] [text] NULL,
	[lastEditTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tb_fbGroupShips] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbMarketAccounts]    Script Date: 2019/3/16 22:30:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbMarketAccounts](
	[fbId] [nvarchar](30) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[fbAccount] [nvarchar](50) NOT NULL,
	[fbPwd] [nvarchar](30) NOT NULL,
	[fbUrl] [nvarchar](50) NULL,
	[note] [text] NULL,
	[userId] [int] NULL,
	[createTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tb_marketFbs] PRIMARY KEY CLUSTERED 
(
	[fbId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbOrderGoods]    Script Date: 2019/3/16 22:30:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbOrderGoods](
	[id] [int] NOT NULL,
	[orderId] [nvarchar](30) NOT NULL,
	[photo] [image] NOT NULL,
	[color] [nvarchar](30) NULL,
	[size] [nvarchar](30) NULL,
	[price] [nvarchar](30) NULL,
	[amount] [nvarchar](30) NULL,
 CONSTRAINT [PK_tb_fbOrderGoods_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbOrders]    Script Date: 2019/3/16 22:30:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbOrders](
	[orderId] [nvarchar](30) NOT NULL,
	[customerFbId] [nvarchar](30) NOT NULL,
	[marketFbId] [nvarchar](30) NOT NULL,
	[orderType] [nvarchar](30) NOT NULL,
	[oriOrderId] [nvarchar](30) NULL,
	[createTime] [datetime] NOT NULL,
	[lastEditTime] [datetime] NOT NULL,
	[status] [nvarchar](30) NOT NULL,
	[shippingAddress] [text] NULL,
	[shippingName] [text] NULL,
	[shippingPhone] [text] NULL,
	[shippingType] [nvarchar](30) NULL,
	[shippingFee] [nvarchar](30) NULL,
	[shippingNo] [nvarchar](30) NULL,
	[currency] [nvarchar](30) NULL,
	[totalPrice] [nvarchar](30) NULL,
	[paymentType] [nvarchar](30) NULL,
	[paymentNo] [nvarchar](30) NULL,
	[note] [text] NULL,
 CONSTRAINT [PK_tb_orders] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_users]    Script Date: 2019/3/16 22:30:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[pwd] [nvarchar](30) NOT NULL,
	[adminId] [int] NOT NULL,
	[note] [text] NULL,
	[createTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tb_users_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tb_admins] ON 

INSERT [dbo].[tb_admins] ([id], [name], [pwd]) VALUES (1, N'admin', N'admin')
INSERT [dbo].[tb_admins] ([id], [name], [pwd]) VALUES (2, N'admin2', N'admin2')
INSERT [dbo].[tb_admins] ([id], [name], [pwd]) VALUES (3, N'admin3', N'admin3')
SET IDENTITY_INSERT [dbo].[tb_admins] OFF
SET IDENTITY_INSERT [dbo].[tb_fbCustomerContacts] ON 

INSERT [dbo].[tb_fbCustomerContacts] ([id], [marketFbId], [marketFbAccount], [customerFbId], [time], [content]) VALUES (1, N'43243242152143', N'许成龙', N'23424323', CAST(N'2019-03-15T23:28:49.000' AS DateTime), N'System.Windows.Forms.TextBox, Text: contacts')
INSERT [dbo].[tb_fbCustomerContacts] ([id], [marketFbId], [marketFbAccount], [customerFbId], [time], [content]) VALUES (2, N'43243242152143', N'许成龙', N'1324', CAST(N'2019-03-15T23:41:50.000' AS DateTime), N'fdsafdsa')
INSERT [dbo].[tb_fbCustomerContacts] ([id], [marketFbId], [marketFbAccount], [customerFbId], [time], [content]) VALUES (3, N'43243242152143', N'许成龙', N'234243', CAST(N'2019-03-15T23:44:10.000' AS DateTime), N'fdafsaa')
INSERT [dbo].[tb_fbCustomerContacts] ([id], [marketFbId], [marketFbAccount], [customerFbId], [time], [content]) VALUES (4, N'43243242152143', N'许成龙', N'234112', CAST(N'2019-03-15T23:47:32.000' AS DateTime), N'aafd')
INSERT [dbo].[tb_fbCustomerContacts] ([id], [marketFbId], [marketFbAccount], [customerFbId], [time], [content]) VALUES (5, N'43243242152143', N'许成龙', N'32414314322', CAST(N'2019-03-15T23:56:52.000' AS DateTime), N'fdsa')
INSERT [dbo].[tb_fbCustomerContacts] ([id], [marketFbId], [marketFbAccount], [customerFbId], [time], [content]) VALUES (9, N'43243242152143', N'许成龙', N'234243', CAST(N'2019-03-16T00:16:04.000' AS DateTime), N'')
INSERT [dbo].[tb_fbCustomerContacts] ([id], [marketFbId], [marketFbAccount], [customerFbId], [time], [content]) VALUES (10, N'43243242152143', N'许成龙', N'234243', CAST(N'2019-03-16T00:17:13.000' AS DateTime), N'')
INSERT [dbo].[tb_fbCustomerContacts] ([id], [marketFbId], [marketFbAccount], [customerFbId], [time], [content]) VALUES (11, N'43243242152143', N'许成龙', N'1324', CAST(N'2019-03-16T00:27:59.000' AS DateTime), N'')
INSERT [dbo].[tb_fbCustomerContacts] ([id], [marketFbId], [marketFbAccount], [customerFbId], [time], [content]) VALUES (13, N'43243242152143', N'许成龙', N'23424323', CAST(N'2019-03-16T00:40:21.000' AS DateTime), N'')
INSERT [dbo].[tb_fbCustomerContacts] ([id], [marketFbId], [marketFbAccount], [customerFbId], [time], [content]) VALUES (14, N'43243242152143', N'许成龙', N'32414314322', CAST(N'2019-03-16T00:45:05.000' AS DateTime), N'')
SET IDENTITY_INSERT [dbo].[tb_fbCustomerContacts] OFF
INSERT [dbo].[tb_fbCustomers] ([fbId], [name], [fbUrl], [friendsNum], [country], [state], [city], [email], [introduction], [friendShips], [shipName], [shipPhone], [shipAddress]) VALUES (N'1324', N'fdsa', N'fdsafds@id=1324', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'', N'', N'', N'')
INSERT [dbo].[tb_fbCustomers] ([fbId], [name], [fbUrl], [friendsNum], [country], [state], [city], [email], [introduction], [friendShips], [shipName], [shipPhone], [shipAddress]) VALUES (N'1324324', N'fd', N'fdsafdsafsid=1324324', N'111', N'fdsfdsa', N'fdsf', N'fds', N'fdsa', N'fdsa', N'', N'', N'', N'')
INSERT [dbo].[tb_fbCustomers] ([fbId], [name], [fbUrl], [friendsNum], [country], [state], [city], [email], [introduction], [friendShips], [shipName], [shipPhone], [shipAddress]) VALUES (N'132434234', N'name', N'fdsfasafdsfdsfid=132434234', N'11111', N'country', N'state', N'city', N'email@qq.com', N'introductions', N'', N'', N'', N'')
INSERT [dbo].[tb_fbCustomers] ([fbId], [name], [fbUrl], [friendsNum], [country], [state], [city], [email], [introduction], [friendShips], [shipName], [shipPhone], [shipAddress]) VALUES (N'1432234342', N'name', N'fdsfdsafdsaid=1432234342', N'111', N'country', N'state', N'city', N'enmail', N'intro', N'', N'', N'', N'')
INSERT [dbo].[tb_fbCustomers] ([fbId], [name], [fbUrl], [friendsNum], [country], [state], [city], [email], [introduction], [friendShips], [shipName], [shipPhone], [shipAddress]) VALUES (N'22222', N'fdsa', N'fdsfsadsid=22222', N'fdsa', N'dsa', N'fdssa', N'fdsa', N'fdsa', N'sa', N'许成龙;', N'', N'', N'')
INSERT [dbo].[tb_fbCustomers] ([fbId], [name], [fbUrl], [friendsNum], [country], [state], [city], [email], [introduction], [friendShips], [shipName], [shipPhone], [shipAddress]) VALUES (N'233444', N'fdsaaaaaa', N'fdsafdsaid=233444', N'sss', N'sss', N'sssss', N'sss', N'aaa', N'sssss', N'', N'', N'', N'')
INSERT [dbo].[tb_fbCustomers] ([fbId], [name], [fbUrl], [friendsNum], [country], [state], [city], [email], [introduction], [friendShips], [shipName], [shipPhone], [shipAddress]) VALUES (N'234112', N'fdfdaa', N'dsafdsdfsfid=234112', N'aa', N'a', N'a', N'a', N'fdsa', N'a', N'', N'', N'', N'')
INSERT [dbo].[tb_fbCustomers] ([fbId], [name], [fbUrl], [friendsNum], [country], [state], [city], [email], [introduction], [friendShips], [shipName], [shipPhone], [shipAddress]) VALUES (N'234243', N'fdsfa', N'fdsafdsafid=234243', N'fds', N'afd', N'fdsa', N's', N'sfa', N'fds', N'', N'', N'', N'')
INSERT [dbo].[tb_fbCustomers] ([fbId], [name], [fbUrl], [friendsNum], [country], [state], [city], [email], [introduction], [friendShips], [shipName], [shipPhone], [shipAddress]) VALUES (N'23424323', N'name222', N'fdsafdsafdsf@dfsaid=23424323', N'frenum', N'country', N'state', N'city', N'email', N'introductions', N'', N'', N'', N'')
INSERT [dbo].[tb_fbCustomers] ([fbId], [name], [fbUrl], [friendsNum], [country], [state], [city], [email], [introduction], [friendShips], [shipName], [shipPhone], [shipAddress]) VALUES (N'2342432322', N'aaa', N'fdsafdsfid=2342432322', N'', N'', N'', N'', N'fdsa', N'', N'许成龙;', N'', N'', N'')
INSERT [dbo].[tb_fbCustomers] ([fbId], [name], [fbUrl], [friendsNum], [country], [state], [city], [email], [introduction], [friendShips], [shipName], [shipPhone], [shipAddress]) VALUES (N'2431324', N'fds', N'fdsafdsid=2431324', N'', N'', N'', N'', N'sfa', N'', N'许成龙;', N'', N'', N'')
INSERT [dbo].[tb_fbCustomers] ([fbId], [name], [fbUrl], [friendsNum], [country], [state], [city], [email], [introduction], [friendShips], [shipName], [shipPhone], [shipAddress]) VALUES (N'32414314322', N'fdsa', N'fdsaid=32414314322', N'fdsafdsa', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[tb_fbCustomerShips] ON 

INSERT [dbo].[tb_fbCustomerShips] ([id], [customerFbId], [marketFbId], [shipType], [customerType], [interestedGoods], [note], [traceDate], [lastEditTime]) VALUES (2, N'23424323', N'43243242152143', N'非好友', N'意向客户', N'intresting', N'note', CAST(N'2019-03-16' AS Date), CAST(N'2019-03-16T00:40:19.000' AS DateTime))
INSERT [dbo].[tb_fbCustomerShips] ([id], [customerFbId], [marketFbId], [shipType], [customerType], [interestedGoods], [note], [traceDate], [lastEditTime]) VALUES (3, N'1324', N'43243242152143', N'非好友', N'意向客户', N'fdsa', N'fdsa', CAST(N'1900-01-01' AS Date), CAST(N'2019-03-16T00:27:56.000' AS DateTime))
INSERT [dbo].[tb_fbCustomerShips] ([id], [customerFbId], [marketFbId], [shipType], [customerType], [interestedGoods], [note], [traceDate], [lastEditTime]) VALUES (4, N'234243', N'43243242152143', N'屏蔽', N'意向客户', N'fdsaafds', N'fdsafssaa', CAST(N'1900-01-01' AS Date), CAST(N'2019-03-16T00:17:13.000' AS DateTime))
INSERT [dbo].[tb_fbCustomerShips] ([id], [customerFbId], [marketFbId], [shipType], [customerType], [interestedGoods], [note], [traceDate], [lastEditTime]) VALUES (5, N'234112', N'43243242152143', N'好友', N'意向客户', N'a', N'aa', CAST(N'1900-01-01' AS Date), CAST(N'2019-03-16T00:49:48.000' AS DateTime))
INSERT [dbo].[tb_fbCustomerShips] ([id], [customerFbId], [marketFbId], [shipType], [customerType], [interestedGoods], [note], [traceDate], [lastEditTime]) VALUES (6, N'32414314322', N'43243242152143', N'非好友', N'意向客户', N'fdsa', N'dsa', CAST(N'1900-01-01' AS Date), CAST(N'2019-03-16T00:45:04.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tb_fbCustomerShips] OFF
SET IDENTITY_INSERT [dbo].[tb_fbGroupLogs] ON 

INSERT [dbo].[tb_fbGroupLogs] ([id], [groupFbId], [marketFbId], [marketFbAccount], [time], [logs]) VALUES (2, N'134523543', N'43243242152143', N'许成龙', CAST(N'2019-03-16T21:31:44.000' AS DateTime), N'notecontacts')
INSERT [dbo].[tb_fbGroupLogs] ([id], [groupFbId], [marketFbId], [marketFbAccount], [time], [logs]) VALUES (3, N'134134121', N'43243242152143', N'许成龙', CAST(N'2019-03-16T21:41:09.000' AS DateTime), N'newcon')
SET IDENTITY_INSERT [dbo].[tb_fbGroupLogs] OFF
INSERT [dbo].[tb_fbGroups] ([fbId], [name], [fbUrl], [membersNum], [introduction], [gpSource], [gpType], [needVerify]) VALUES (N'112233', N'groupnname', N'urlgroups/112233', N'111', N'introductons', NULL, NULL, N'需要')
INSERT [dbo].[tb_fbGroups] ([fbId], [name], [fbUrl], [membersNum], [introduction], [gpSource], [gpType], [needVerify]) VALUES (N'1123', N'name', N'urlgroups/1123', N'2234', N'instro', NULL, NULL, N'不需要')
INSERT [dbo].[tb_fbGroups] ([fbId], [name], [fbUrl], [membersNum], [introduction], [gpSource], [gpType], [needVerify]) VALUES (N'1134221', N'nameaa', N'urldsagroups/1134221', N'111', N'introucxts', NULL, NULL, N'不需要')
INSERT [dbo].[tb_fbGroups] ([fbId], [name], [fbUrl], [membersNum], [introduction], [gpSource], [gpType], [needVerify]) VALUES (N'1134234222', N'nanewrerw', N'urlsdfsdfgroups/1134234222', N'1234', N'itro', NULL, NULL, N'不需要')
INSERT [dbo].[tb_fbGroups] ([fbId], [name], [fbUrl], [membersNum], [introduction], [gpSource], [gpType], [needVerify]) VALUES (N'132424322443', N'naaaaaa', N'urlllllllgroups/132424322443', N'1134', N'introuctdss', NULL, NULL, N'不需要')
INSERT [dbo].[tb_fbGroups] ([fbId], [name], [fbUrl], [membersNum], [introduction], [gpSource], [gpType], [needVerify]) VALUES (N'134134121', N'nammmmmmmmmmmmmmnnnnnnnn', N'urllllllllllllllgroups/134134121', N'1343', N'intors', NULL, NULL, N'不需要')
INSERT [dbo].[tb_fbGroups] ([fbId], [name], [fbUrl], [membersNum], [introduction], [gpSource], [gpType], [needVerify]) VALUES (N'134523543', N'naaaaaaaaaaaaame', N'ulllllllllllllllllllrlgroups/134523543', N'1234', N'intoructss', NULL, NULL, N'需要')
INSERT [dbo].[tb_fbGroups] ([fbId], [name], [fbUrl], [membersNum], [introduction], [gpSource], [gpType], [needVerify]) VALUES (N'154', N'nmame', N'ruregroups/154', N'1', N'introductons', NULL, NULL, N'不需要')
SET IDENTITY_INSERT [dbo].[tb_fbGroupShips] ON 

INSERT [dbo].[tb_fbGroupShips] ([id], [groupFbId], [marketFbId], [status], [customersNum], [contactCustomersNum], [tradeCustomersNum], [ordersNum], [tweetsNum], [tweetFeedback], [mark], [note], [lastEditTime]) VALUES (2, N'132424322443', N'fdafds', N'重要;一般;认为是骗子;不信任;想当地交易;被攻击;做活动;', N'1', N'4', N'3', N'2', N'5', N'一般', N'申请加入;申请通过;申请被拒;发贴状态;退出群组;不要;', N'10', CAST(N'2019-03-16T21:27:58.000' AS DateTime))
INSERT [dbo].[tb_fbGroupShips] ([id], [groupFbId], [marketFbId], [status], [customersNum], [contactCustomersNum], [tradeCustomersNum], [ordersNum], [tweetsNum], [tweetFeedback], [mark], [note], [lastEditTime]) VALUES (3, N'134523543', N'43243242152143', N'重要;一般;认为是骗子;不信任;想当地交易;被攻击;做活动;', N'1', N'4', N'3', N'2', N'5', N'一般', N'申请加入;申请通过;申请被拒;发贴状态;退出群组;不要;', N'10', CAST(N'2019-03-16T21:31:44.000' AS DateTime))
INSERT [dbo].[tb_fbGroupShips] ([id], [groupFbId], [marketFbId], [status], [customersNum], [contactCustomersNum], [tradeCustomersNum], [ordersNum], [tweetsNum], [tweetFeedback], [mark], [note], [lastEditTime]) VALUES (4, N'134134121', N'43243242152143', N'申请加入;申请通过;发贴状态;退出群组;不要;', N'1', N'4', N'3', N'2', N'5', N'一般', N'重要;认为是骗子;不信任;想当地交易;被攻击;做活动;', N'note', CAST(N'2019-03-16T21:47:27.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tb_fbGroupShips] OFF
INSERT [dbo].[tb_fbMarketAccounts] ([fbId], [name], [fbAccount], [fbPwd], [fbUrl], [note], [userId], [createTime]) VALUES (N'43243242152143', N'许成龙', N'xuchenglong2000@126.com', N'love2000a', N'fdsafdssafdsfasfdsafdsafdsafasfdsafdsfdsafdsfsafds', N'fdsafdsafsfdsafdsafdsafdsafsafdsafdsafsafdsafdsafdsafdsafdssfdsfaaaafddd', 3, CAST(N'2019-03-14T21:36:40.000' AS DateTime))
INSERT [dbo].[tb_fbMarketAccounts] ([fbId], [name], [fbAccount], [fbPwd], [fbUrl], [note], [userId], [createTime]) VALUES (N'fdafds', N'fdsa', N'fdsa', N'dfsa', N'sfdsa', N'fdsa', 3, CAST(N'2019-03-14T22:30:14.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tb_users] ON 

INSERT [dbo].[tb_users] ([id], [name], [pwd], [adminId], [note], [createTime]) VALUES (1, N'user1', N'user1', 1, N'', CAST(N'2019-03-14T20:43:05.000' AS DateTime))
INSERT [dbo].[tb_users] ([id], [name], [pwd], [adminId], [note], [createTime]) VALUES (3, N'user3', N'user3', 1, N'user3', CAST(N'2019-03-14T20:53:03.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tb_users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tb_admins_name]    Script Date: 2019/3/16 22:30:33 ******/
ALTER TABLE [dbo].[tb_admins] ADD  CONSTRAINT [UK_tb_admins_name] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tb_fbCustomers_url]    Script Date: 2019/3/16 22:30:33 ******/
ALTER TABLE [dbo].[tb_fbCustomers] ADD  CONSTRAINT [UK_tb_fbCustomers_url] UNIQUE NONCLUSTERED 
(
	[fbUrl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tb_fbGroups_fbUrl]    Script Date: 2019/3/16 22:30:33 ******/
ALTER TABLE [dbo].[tb_fbGroups] ADD  CONSTRAINT [UK_tb_fbGroups_fbUrl] UNIQUE NONCLUSTERED 
(
	[fbUrl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tb_marketFbs_fbAccount]    Script Date: 2019/3/16 22:30:33 ******/
ALTER TABLE [dbo].[tb_fbMarketAccounts] ADD  CONSTRAINT [UK_tb_marketFbs_fbAccount] UNIQUE NONCLUSTERED 
(
	[fbAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tb_marketFbs_name]    Script Date: 2019/3/16 22:30:33 ******/
ALTER TABLE [dbo].[tb_fbMarketAccounts] ADD  CONSTRAINT [UK_tb_marketFbs_name] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tb_users_name]    Script Date: 2019/3/16 22:30:33 ******/
ALTER TABLE [dbo].[tb_users] ADD  CONSTRAINT [UK_tb_users_name] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_fbCustomerContacts]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbCustomerContacts_tb_fbCustomers_customerFbId] FOREIGN KEY([customerFbId])
REFERENCES [dbo].[tb_fbCustomers] ([fbId])
GO
ALTER TABLE [dbo].[tb_fbCustomerContacts] CHECK CONSTRAINT [FK_tb_fbCustomerContacts_tb_fbCustomers_customerFbId]
GO
ALTER TABLE [dbo].[tb_fbCustomerContacts]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbCustomerContacts_tb_fbMarketAccounts_marketFbId] FOREIGN KEY([marketFbId])
REFERENCES [dbo].[tb_fbMarketAccounts] ([fbId])
GO
ALTER TABLE [dbo].[tb_fbCustomerContacts] CHECK CONSTRAINT [FK_tb_fbCustomerContacts_tb_fbMarketAccounts_marketFbId]
GO
ALTER TABLE [dbo].[tb_fbCustomerShips]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbCustomerShips_tb_fbCustomers_customerFbId] FOREIGN KEY([customerFbId])
REFERENCES [dbo].[tb_fbCustomers] ([fbId])
GO
ALTER TABLE [dbo].[tb_fbCustomerShips] CHECK CONSTRAINT [FK_tb_fbCustomerShips_tb_fbCustomers_customerFbId]
GO
ALTER TABLE [dbo].[tb_fbCustomerShips]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbCustomerShips_tb_fbMarketAccounts_marketFbId] FOREIGN KEY([marketFbId])
REFERENCES [dbo].[tb_fbMarketAccounts] ([fbId])
GO
ALTER TABLE [dbo].[tb_fbCustomerShips] CHECK CONSTRAINT [FK_tb_fbCustomerShips_tb_fbMarketAccounts_marketFbId]
GO
ALTER TABLE [dbo].[tb_fbGroupLogs]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbGroupLogs_tb_fbGroups_groupFbId] FOREIGN KEY([groupFbId])
REFERENCES [dbo].[tb_fbGroups] ([fbId])
GO
ALTER TABLE [dbo].[tb_fbGroupLogs] CHECK CONSTRAINT [FK_tb_fbGroupLogs_tb_fbGroups_groupFbId]
GO
ALTER TABLE [dbo].[tb_fbGroupLogs]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbGroupLogs_tb_fbMarketAccounts_marketFbId] FOREIGN KEY([marketFbId])
REFERENCES [dbo].[tb_fbMarketAccounts] ([fbId])
GO
ALTER TABLE [dbo].[tb_fbGroupLogs] CHECK CONSTRAINT [FK_tb_fbGroupLogs_tb_fbMarketAccounts_marketFbId]
GO
ALTER TABLE [dbo].[tb_fbGroupShips]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbGroupShips_tb_fbGroups_groupFbId] FOREIGN KEY([groupFbId])
REFERENCES [dbo].[tb_fbGroups] ([fbId])
GO
ALTER TABLE [dbo].[tb_fbGroupShips] CHECK CONSTRAINT [FK_tb_fbGroupShips_tb_fbGroups_groupFbId]
GO
ALTER TABLE [dbo].[tb_fbGroupShips]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbGroupShips_tb_fbMarketAccounts_marketFbId] FOREIGN KEY([marketFbId])
REFERENCES [dbo].[tb_fbMarketAccounts] ([fbId])
GO
ALTER TABLE [dbo].[tb_fbGroupShips] CHECK CONSTRAINT [FK_tb_fbGroupShips_tb_fbMarketAccounts_marketFbId]
GO
ALTER TABLE [dbo].[tb_fbMarketAccounts]  WITH CHECK ADD  CONSTRAINT [FK_tb_marketFbs_tb_users_userId] FOREIGN KEY([userId])
REFERENCES [dbo].[tb_users] ([id])
GO
ALTER TABLE [dbo].[tb_fbMarketAccounts] CHECK CONSTRAINT [FK_tb_marketFbs_tb_users_userId]
GO
ALTER TABLE [dbo].[tb_fbOrderGoods]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbOrderGoods_tb_fbOrders_orderId] FOREIGN KEY([orderId])
REFERENCES [dbo].[tb_fbOrders] ([orderId])
GO
ALTER TABLE [dbo].[tb_fbOrderGoods] CHECK CONSTRAINT [FK_tb_fbOrderGoods_tb_fbOrders_orderId]
GO
ALTER TABLE [dbo].[tb_fbOrders]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbOrders_tb_fbCustomers_customerFbId] FOREIGN KEY([customerFbId])
REFERENCES [dbo].[tb_fbCustomers] ([fbId])
GO
ALTER TABLE [dbo].[tb_fbOrders] CHECK CONSTRAINT [FK_tb_fbOrders_tb_fbCustomers_customerFbId]
GO
ALTER TABLE [dbo].[tb_fbOrders]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbOrders_tb_fbMarketAccounts_marketFbId] FOREIGN KEY([marketFbId])
REFERENCES [dbo].[tb_fbMarketAccounts] ([fbId])
GO
ALTER TABLE [dbo].[tb_fbOrders] CHECK CONSTRAINT [FK_tb_fbOrders_tb_fbMarketAccounts_marketFbId]
GO
ALTER TABLE [dbo].[tb_users]  WITH CHECK ADD  CONSTRAINT [FK_tb_users_tb_admins_adminId] FOREIGN KEY([adminId])
REFERENCES [dbo].[tb_admins] ([id])
GO
ALTER TABLE [dbo].[tb_users] CHECK CONSTRAINT [FK_tb_users_tb_admins_adminId]
GO
USE [master]
GO
ALTER DATABASE [fb_trade] SET  READ_WRITE 
GO
