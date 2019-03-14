USE [master]
GO
/****** Object:  Database [fb_trade]    Script Date: 2019/3/14 23:01:11 ******/
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
/****** Object:  Table [dbo].[tb_admins]    Script Date: 2019/3/14 23:01:11 ******/
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
/****** Object:  Table [dbo].[tb_fbCustomerContacts]    Script Date: 2019/3/14 23:01:11 ******/
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
/****** Object:  Table [dbo].[tb_fbCustomers]    Script Date: 2019/3/14 23:01:11 ******/
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
/****** Object:  Table [dbo].[tb_fbCustomerShips]    Script Date: 2019/3/14 23:01:11 ******/
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
	[traceDate] [datetime] NULL,
	[createTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tb_fbFriendShips] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbGroupLogs]    Script Date: 2019/3/14 23:01:11 ******/
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
/****** Object:  Table [dbo].[tb_fbGroups]    Script Date: 2019/3/14 23:01:11 ******/
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
/****** Object:  Table [dbo].[tb_fbGroupShips]    Script Date: 2019/3/14 23:01:11 ******/
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
 CONSTRAINT [PK_tb_fbGroupShips] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fbMarketAccounts]    Script Date: 2019/3/14 23:01:11 ******/
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
/****** Object:  Table [dbo].[tb_fbOrderGoods]    Script Date: 2019/3/14 23:01:11 ******/
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
/****** Object:  Table [dbo].[tb_fbOrders]    Script Date: 2019/3/14 23:01:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fbOrders](
	[orderId] [nvarchar](30) NOT NULL,
	[custermerFbId] [nvarchar](30) NOT NULL,
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
/****** Object:  Table [dbo].[tb_users]    Script Date: 2019/3/14 23:01:11 ******/
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
INSERT [dbo].[tb_fbMarketAccounts] ([fbId], [name], [fbAccount], [fbPwd], [fbUrl], [note], [userId], [createTime]) VALUES (N'43243242152143', N'许成龙', N'xuchenglong2000@126.com', N'love2000a', N'fdsafdssafdsfasfdsafdsafdsafasfdsafdsfdsafdsfsafds', N'fdsafdsafsfdsafdsafdsafdsafsafdsafdsafsafdsafdsafdsafdsafdssfdsfaaaafddd', 3, CAST(N'2019-03-14T21:36:40.000' AS DateTime))
INSERT [dbo].[tb_fbMarketAccounts] ([fbId], [name], [fbAccount], [fbPwd], [fbUrl], [note], [userId], [createTime]) VALUES (N'fdafds', N'fdsa', N'fdsa', N'dfsa', N'sfdsa', N'fdsa', 3, CAST(N'2019-03-14T22:30:14.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tb_users] ON 

INSERT [dbo].[tb_users] ([id], [name], [pwd], [adminId], [note], [createTime]) VALUES (1, N'user1', N'user1', 1, N'', CAST(N'2019-03-14T20:43:05.000' AS DateTime))
INSERT [dbo].[tb_users] ([id], [name], [pwd], [adminId], [note], [createTime]) VALUES (3, N'user3', N'user3', 1, N'user3', CAST(N'2019-03-14T20:53:03.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tb_users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tb_admins_name]    Script Date: 2019/3/14 23:01:11 ******/
ALTER TABLE [dbo].[tb_admins] ADD  CONSTRAINT [UK_tb_admins_name] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tb_fbCustomers_url]    Script Date: 2019/3/14 23:01:11 ******/
ALTER TABLE [dbo].[tb_fbCustomers] ADD  CONSTRAINT [UK_tb_fbCustomers_url] UNIQUE NONCLUSTERED 
(
	[fbUrl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tb_fbGroups_fbUrl]    Script Date: 2019/3/14 23:01:11 ******/
ALTER TABLE [dbo].[tb_fbGroups] ADD  CONSTRAINT [UK_tb_fbGroups_fbUrl] UNIQUE NONCLUSTERED 
(
	[fbUrl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tb_marketFbs_fbAccount]    Script Date: 2019/3/14 23:01:11 ******/
ALTER TABLE [dbo].[tb_fbMarketAccounts] ADD  CONSTRAINT [UK_tb_marketFbs_fbAccount] UNIQUE NONCLUSTERED 
(
	[fbAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tb_marketFbs_name]    Script Date: 2019/3/14 23:01:11 ******/
ALTER TABLE [dbo].[tb_fbMarketAccounts] ADD  CONSTRAINT [UK_tb_marketFbs_name] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_tb_users_name]    Script Date: 2019/3/14 23:01:11 ******/
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
ALTER TABLE [dbo].[tb_fbOrders]  WITH CHECK ADD  CONSTRAINT [FK_tb_fbOrders_tb_fbCustomers_customerFbId] FOREIGN KEY([custermerFbId])
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
