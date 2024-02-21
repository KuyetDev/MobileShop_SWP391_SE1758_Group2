﻿{"metadata":{"kernel_spec":{"name":"SQL","language":"sql","display_name":"SQL"},"language_info":{"name":"sql","version":""}},"nbformat":4,"nbformat_minor":2,"cells":[{"cell_type":"markdown","source":["# [FStore]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']","object_type":"Database"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["USE [master]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']","object_type":"Database"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["/****** Object:  Database [FStore]    Script Date: 2/21/2024 9:28:11 PM ******/\r\nCREATE DATABASE [FStore]\r\n CONTAINMENT = NONE\r\n ON  PRIMARY \r\n( NAME = N'FStore', FILENAME = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL15.DANGSINH\\MSSQL\\DATA\\FStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )\r\n LOG ON \r\n( NAME = N'FStore_log', FILENAME = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL15.DANGSINH\\MSSQL\\DATA\\FStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )\r\n WITH CATALOG_COLLATION = DATABASE_DEFAULT\r\n","GO\r\n","ALTER DATABASE [FStore] SET COMPATIBILITY_LEVEL = 150\r\n","GO\r\n","IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))\r\nbegin\r\nEXEC [FStore].[dbo].[sp_fulltext_database] @action = 'enable'\r\nend\r\n","GO\r\n","ALTER DATABASE [FStore] SET ANSI_NULL_DEFAULT OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET ANSI_NULLS OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET ANSI_PADDING OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET ANSI_WARNINGS OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET ARITHABORT OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET AUTO_CLOSE OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET AUTO_SHRINK OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET AUTO_UPDATE_STATISTICS ON \r\n","GO\r\n","ALTER DATABASE [FStore] SET CURSOR_CLOSE_ON_COMMIT OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET CURSOR_DEFAULT  GLOBAL \r\n","GO\r\n","ALTER DATABASE [FStore] SET CONCAT_NULL_YIELDS_NULL OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET NUMERIC_ROUNDABORT OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET QUOTED_IDENTIFIER OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET RECURSIVE_TRIGGERS OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET  ENABLE_BROKER \r\n","GO\r\n","ALTER DATABASE [FStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET DATE_CORRELATION_OPTIMIZATION OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET TRUSTWORTHY OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET ALLOW_SNAPSHOT_ISOLATION OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET PARAMETERIZATION SIMPLE \r\n","GO\r\n","ALTER DATABASE [FStore] SET READ_COMMITTED_SNAPSHOT OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET HONOR_BROKER_PRIORITY OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET RECOVERY FULL \r\n","GO\r\n","ALTER DATABASE [FStore] SET  MULTI_USER \r\n","GO\r\n","ALTER DATABASE [FStore] SET PAGE_VERIFY CHECKSUM  \r\n","GO\r\n","ALTER DATABASE [FStore] SET DB_CHAINING OFF \r\n","GO\r\n","ALTER DATABASE [FStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) \r\n","GO\r\n","ALTER DATABASE [FStore] SET TARGET_RECOVERY_TIME = 60 SECONDS \r\n","GO\r\n","ALTER DATABASE [FStore] SET DELAYED_DURABILITY = DISABLED \r\n","GO\r\n","ALTER DATABASE [FStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  \r\n","GO\r\n","EXEC sys.sp_db_vardecimal_storage_format N'FStore', N'ON'\r\n","GO\r\n","ALTER DATABASE [FStore] SET QUERY_STORE = OFF\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']","object_type":"Database"}},{"cell_type":"markdown","source":["# [dbo].[Account]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Account' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["USE [FStore]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Account' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["/****** Object:  Table [dbo].[Account]    Script Date: 2/21/2024 9:28:11 PM ******/\r\nSET ANSI_NULLS ON\r\n","GO\r\n","SET QUOTED_IDENTIFIER ON\r\n","GO\r\n","CREATE TABLE [dbo].[Account](\r\n\t[account_id] [int] IDENTITY(1,1) NOT NULL,\r\n\t[full_name] [varchar](100) NOT NULL,\r\n\t[mail] [varchar](100) NOT NULL,\r\n\t[address] [varchar](100) NOT NULL,\r\n\t[dob] [date] NULL,\r\n\t[gender] [bit] NULL,\r\n\t[phone] [varchar](10) NULL,\r\n\t[password] [varchar](100) NULL,\r\n\t[active] [bit] NOT NULL,\r\n\t[role_id] [int] NOT NULL,\r\n\t[is_deleted] [bit] NULL,\r\nPRIMARY KEY CLUSTERED \r\n(\r\n\t[account_id] ASC\r\n)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]\r\n) ON [PRIMARY]\r\nGO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Account' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Category]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Category' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["/****** Object:  Table [dbo].[Category]    Script Date: 2/21/2024 9:28:11 PM ******/\r\nSET ANSI_NULLS ON\r\n","GO\r\n","SET QUOTED_IDENTIFIER ON\r\n","GO\r\n","CREATE TABLE [dbo].[Category](\r\n\t[category_id] [int] IDENTITY(1,1) NOT NULL,\r\n\t[category_name] [varchar](100) NOT NULL,\r\n\t[is_deleted] [bit] NULL,\r\nPRIMARY KEY CLUSTERED \r\n(\r\n\t[category_id] ASC\r\n)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]\r\n) ON [PRIMARY]\r\nGO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Category' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Coupons]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Coupons' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["/****** Object:  Table [dbo].[Coupons]    Script Date: 2/21/2024 9:28:11 PM ******/\r\nSET ANSI_NULLS ON\r\n","GO\r\n","SET QUOTED_IDENTIFIER ON\r\n","GO\r\n","CREATE TABLE [dbo].[Coupons](\r\n\t[coupon_id] [int] IDENTITY(1,1) NOT NULL,\r\n\t[code] [varchar](100) NOT NULL,\r\n\t[discount_percent] [int] NOT NULL,\r\n\t[expiration_date] [date] NULL,\r\n\t[is_deleted] [bit] NULL,\r\n CONSTRAINT [PK__Coupons__58CF6389DA94C769] PRIMARY KEY CLUSTERED \r\n(\r\n\t[coupon_id] ASC\r\n)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]\r\n) ON [PRIMARY]\r\nGO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Coupons' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Image]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Image' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["/****** Object:  Table [dbo].[Image]    Script Date: 2/21/2024 9:28:11 PM ******/\r\nSET ANSI_NULLS ON\r\n","GO\r\n","SET QUOTED_IDENTIFIER ON\r\n","GO\r\n","CREATE TABLE [dbo].[Image](\r\n\t[image_id] [int] IDENTITY(1,1) NOT NULL,\r\n\t[image_link] [varchar](100) NULL,\r\n\t[create_date] [date] NULL,\r\n\t[is_deleted] [bit] NULL,\r\nPRIMARY KEY CLUSTERED \r\n(\r\n\t[image_id] ASC\r\n)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]\r\n) ON [PRIMARY]\r\nGO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Image' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Order_details]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Order_details' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["/****** Object:  Table [dbo].[Order_details]    Script Date: 2/21/2024 9:28:11 PM ******/\r\nSET ANSI_NULLS ON\r\n","GO\r\n","SET QUOTED_IDENTIFIER ON\r\n","GO\r\n","CREATE TABLE [dbo].[Order_details](\r\n\t[order_id] [int] NOT NULL,\r\n\t[product_id] [int] NOT NULL,\r\n\t[quantity] [int] NOT NULL,\r\n\t[is_deleted] [bit] NULL,\r\nPRIMARY KEY CLUSTERED \r\n(\r\n\t[order_id] ASC,\r\n\t[product_id] ASC\r\n)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]\r\n) ON [PRIMARY]\r\nGO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Order_details' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Orders]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Orders' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["/****** Object:  Table [dbo].[Orders]    Script Date: 2/21/2024 9:28:11 PM ******/\r\nSET ANSI_NULLS ON\r\n","GO\r\n","SET QUOTED_IDENTIFIER ON\r\n","GO\r\n","CREATE TABLE [dbo].[Orders](\r\n\t[order_id] [int] IDENTITY(1,1) NOT NULL,\r\n\t[customer_id] [int] NOT NULL,\r\n\t[address] [varchar](100) NOT NULL,\r\n\t[create_date] [date] NULL,\r\n\t[shipping_date] [date] NULL,\r\n\t[required_date] [date] NULL,\r\n\t[status] [int] NULL,\r\n\t[payment_id] [int] NULL,\r\n\t[coupon_id] [int] NULL,\r\n\t[is_deleted] [bit] NULL,\r\nPRIMARY KEY CLUSTERED \r\n(\r\n\t[order_id] ASC\r\n)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]\r\n) ON [PRIMARY]\r\nGO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Orders' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Payment]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Payment' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["/****** Object:  Table [dbo].[Payment]    Script Date: 2/21/2024 9:28:11 PM ******/\r\nSET ANSI_NULLS ON\r\n","GO\r\n","SET QUOTED_IDENTIFIER ON\r\n","GO\r\n","CREATE TABLE [dbo].[Payment](\r\n\t[payment_id] [int] IDENTITY(1,1) NOT NULL,\r\n\t[payment_name] [varchar](100) NOT NULL,\r\n\t[is_deleted] [bit] NULL,\r\nPRIMARY KEY CLUSTERED \r\n(\r\n\t[payment_id] ASC\r\n)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]\r\n) ON [PRIMARY]\r\nGO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Payment' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Product]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Product' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["/****** Object:  Table [dbo].[Product]    Script Date: 2/21/2024 9:28:11 PM ******/\r\nSET ANSI_NULLS ON\r\n","GO\r\n","SET QUOTED_IDENTIFIER ON\r\n","GO\r\n","CREATE TABLE [dbo].[Product](\r\n\t[product_id] [int] IDENTITY(1,1) NOT NULL,\r\n\t[product_name] [varchar](100) NOT NULL,\r\n\t[price] [float] NOT NULL,\r\n\t[quantity] [int] NOT NULL,\r\n\t[description] [varchar](max) NULL,\r\n\t[category_id] [int] NOT NULL,\r\n\t[image_id] [int] NOT NULL,\r\n\t[create_date] [date] NULL,\r\n\t[create_by] [int] NOT NULL,\r\n\t[is_deleted] [bit] NULL,\r\nPRIMARY KEY CLUSTERED \r\n(\r\n\t[product_id] ASC\r\n)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]\r\n) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]\r\nGO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Product' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Reviews]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Reviews' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["/****** Object:  Table [dbo].[Reviews]    Script Date: 2/21/2024 9:28:11 PM ******/\r\nSET ANSI_NULLS ON\r\n","GO\r\n","SET QUOTED_IDENTIFIER ON\r\n","GO\r\n","CREATE TABLE [dbo].[Reviews](\r\n\t[review_id] [int] IDENTITY(1,1) NOT NULL,\r\n\t[product_id] [int] NOT NULL,\r\n\t[customer_id] [int] NOT NULL,\r\n\t[rating] [int] NOT NULL,\r\n\t[comment] [varchar](max) NOT NULL,\r\n\t[create_date] [date] NOT NULL,\r\n\t[is_deleted] [bit] NULL,\r\nPRIMARY KEY CLUSTERED \r\n(\r\n\t[review_id] ASC\r\n)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]\r\n) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]\r\nGO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Reviews' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Role]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Role' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["/****** Object:  Table [dbo].[Role]    Script Date: 2/21/2024 9:28:11 PM ******/\r\nSET ANSI_NULLS ON\r\n","GO\r\n","SET QUOTED_IDENTIFIER ON\r\n","GO\r\n","CREATE TABLE [dbo].[Role](\r\n\t[role_id] [int] IDENTITY(1,1) NOT NULL,\r\n\t[role_name] [varchar](100) NOT NULL,\r\n\t[is_deleted] [bit] NULL,\r\nPRIMARY KEY CLUSTERED \r\n(\r\n\t[role_id] ASC\r\n)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]\r\n) ON [PRIMARY]\r\nGO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Role' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Account]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Account' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["SET IDENTITY_INSERT [dbo].[Account] ON \r\n","INSERT [dbo].[Account] ([account_id], [full_name], [mail], [address], [dob], [gender], [phone], [password], [active], [role_id], [is_deleted]) VALUES (4, N'Admin', N'sinhdqhe150849@fpt.edu.vn', N'Hung Yen', CAST(N'2001-03-14' AS Date), 1, N'0917076864', N'45310317335BD2615A915FC23D781BA7', 1, 1, 0)\r\n","INSERT [dbo].[Account] ([account_id], [full_name], [mail], [address], [dob], [gender], [phone], [password], [active], [role_id], [is_deleted]) VALUES (6, N'Staff 1', N'sinhdq@fpt.com', N'Ha Noi', CAST(N'2001-03-14' AS Date), 1, N'0917076864', N'1C694CFFD4999AFBA13E752D35DA0090', 1, 2, 0)\r\n","INSERT [dbo].[Account] ([account_id], [full_name], [mail], [address], [dob], [gender], [phone], [password], [active], [role_id], [is_deleted]) VALUES (7, N'Nguyen Van B', N'nguyenvanb@gmail.com', N'Ha Nam', CAST(N'2024-01-01' AS Date), 1, N'0985054398', N'62A2EFC2962A3BB876555A73212DA122', 1, 3, 0)\r\n","INSERT [dbo].[Account] ([account_id], [full_name], [mail], [address], [dob], [gender], [phone], [password], [active], [role_id], [is_deleted]) VALUES (8, N'Pham Van K', N'phamvank@gmail.com', N'Ha Noi', CAST(N'2024-01-04' AS Date), 1, N'0917076864', N'CF814721358D09942B255746542AD2A4', 1, 2, 1)\r\n","INSERT [dbo].[Account] ([account_id], [full_name], [mail], [address], [dob], [gender], [phone], [password], [active], [role_id], [is_deleted]) VALUES (1003, N'Dang Quoc Sinh', N'sinhphuung2001@gmail.com', N'Hung Yen', CAST(N'2001-03-14' AS Date), 1, N'0917076864', N'45310317335BD2615A915FC23D781BA7', 1, 3, 0)\r\n","SET IDENTITY_INSERT [dbo].[Account] OFF\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Account' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Category]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Category' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["SET IDENTITY_INSERT [dbo].[Category] ON \r\n","INSERT [dbo].[Category] ([category_id], [category_name], [is_deleted]) VALUES (1, N'Samsung', 0)\r\n","INSERT [dbo].[Category] ([category_id], [category_name], [is_deleted]) VALUES (2, N'Apple', 0)\r\n","INSERT [dbo].[Category] ([category_id], [category_name], [is_deleted]) VALUES (3, N'Xiaomi', 0)\r\n","SET IDENTITY_INSERT [dbo].[Category] OFF\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Category' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Coupons]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Coupons' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["SET IDENTITY_INSERT [dbo].[Coupons] ON \r\n","INSERT [dbo].[Coupons] ([coupon_id], [code], [discount_percent], [expiration_date], [is_deleted]) VALUES (5, N'NORMAL', 0, NULL, 0)\r\n","SET IDENTITY_INSERT [dbo].[Coupons] OFF\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Coupons' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Image]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Image' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["SET IDENTITY_INSERT [dbo].[Image] ON \r\n","INSERT [dbo].[Image] ([image_id], [image_link], [create_date], [is_deleted]) VALUES (1, N'samsungs24.jpg', CAST(N'2024-01-18' AS Date), 0)\r\n","INSERT [dbo].[Image] ([image_id], [image_link], [create_date], [is_deleted]) VALUES (2, N'samsungs22.jpg', CAST(N'2024-01-18' AS Date), 0)\r\n","INSERT [dbo].[Image] ([image_id], [image_link], [create_date], [is_deleted]) VALUES (3, N'samsungzfold5.jpg', CAST(N'2024-01-18' AS Date), 0)\r\n","INSERT [dbo].[Image] ([image_id], [image_link], [create_date], [is_deleted]) VALUES (4, N'Iphone15prm.png', CAST(N'2024-01-18' AS Date), 0)\r\n","INSERT [dbo].[Image] ([image_id], [image_link], [create_date], [is_deleted]) VALUES (7, N'432532.png', CAST(N'2024-01-19' AS Date), 0)\r\n","INSERT [dbo].[Image] ([image_id], [image_link], [create_date], [is_deleted]) VALUES (8, N'Presentation1.png', CAST(N'2024-01-19' AS Date), 0)\r\n","SET IDENTITY_INSERT [dbo].[Image] OFF\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Image' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Order_details]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Order_details' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity], [is_deleted]) VALUES (1, 2, 1, 0)\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Order_details' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Orders]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Orders' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["SET IDENTITY_INSERT [dbo].[Orders] ON \r\n","INSERT [dbo].[Orders] ([order_id], [customer_id], [address], [create_date], [shipping_date], [required_date], [status], [payment_id], [coupon_id], [is_deleted]) VALUES (1, 1003, N'Hung Yen', CAST(N'2024-02-14' AS Date), NULL, NULL, 1, 2, 5, 0)\r\n","SET IDENTITY_INSERT [dbo].[Orders] OFF\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Orders' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Payment]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Payment' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["SET IDENTITY_INSERT [dbo].[Payment] ON \r\n","INSERT [dbo].[Payment] ([payment_id], [payment_name], [is_deleted]) VALUES (1, N'PAYMENT ONLINE', 0)\r\n","INSERT [dbo].[Payment] ([payment_id], [payment_name], [is_deleted]) VALUES (2, N'COD', 0)\r\n","SET IDENTITY_INSERT [dbo].[Payment] OFF\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Payment' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Product]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Product' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["SET IDENTITY_INSERT [dbo].[Product] ON \r\n","INSERT [dbo].[Product] ([product_id], [product_name], [price], [quantity], [description], [category_id], [image_id], [create_date], [create_by], [is_deleted]) VALUES (2, N'Galaxy S24 Ultra', 33990000, 200, N'With the connectivity power of the Samsung Galaxy S24 Ultra, you can connect with the world easier than ever, overcoming all language barriers when communicating. Not only normal translation, S24 Ultra also has the ability to directly translate two-way calls in real time. You don''t even need to be connected to the Internet to understand what the other person is saying and vice versa. This feature makes it possible to communicate across borders. Whether it''s a voice or text message, S24 Ultra will quickly translate into Vietnamese and send back the message in the language of the other side.', 1, 1, CAST(N'2024-01-24' AS Date), 4, 0)\r\n","INSERT [dbo].[Product] ([product_id], [product_name], [price], [quantity], [description], [category_id], [image_id], [create_date], [create_by], [is_deleted]) VALUES (3, N'Samsung Galaxy S22 5G 128GB', 12490000, 200, N'Samsung Galaxy S22 is a leap forward in video technology in the mobile generation. At the same time, the phone also opens up a series of today''s leading breakthrough innovations, from the \"flattering\" flat beveled screen to the first advanced 4nm processor on the Samsung smartphone generation.', 1, 2, CAST(N'2024-01-30' AS Date), 4, 0)\r\n","INSERT [dbo].[Product] ([product_id], [product_name], [price], [quantity], [description], [category_id], [image_id], [create_date], [create_by], [is_deleted]) VALUES (4, N'Samsung Galaxy Z Fold5 5G', 31790000, 200, N'Samsung Galaxy Z Fold5 affirms its position as a pioneering folding phone, boldly breaking through old boundaries, leading with advanced Flex hinge technology. The device also opens up the most comprehensive range of smart experiences through a large screen, outstanding performance, S-Pen compatibility, allowing optimal multitasking, speeding up work effectively, giving users confidence. Connect flexibly with Galaxy Z Fold 5.', 1, 3, CAST(N'2024-01-18' AS Date), 4, 0)\r\n","INSERT [dbo].[Product] ([product_id], [product_name], [price], [quantity], [description], [category_id], [image_id], [create_date], [create_by], [is_deleted]) VALUES (5, N'iPhone 15 Pro Max 256GB', 32690000, 200, N'iPhone 15 Pro Max is the most advanced iPhone with the largest screen, best battery life, strongest configuration and super durable, super light aerospace-standard Titanium frame design. iPhone 15 Pro Max possesses Apple''s most outstanding features. Accordingly, users will experience a high-end iPhone with \"huge\" performance with A17 Pro chip, titanium frame, upgraded zoom capabilities, new action buttons,...', 2, 4, CAST(N'2024-01-30' AS Date), 4, 0)\r\n","INSERT [dbo].[Product] ([product_id], [product_name], [price], [quantity], [description], [category_id], [image_id], [create_date], [create_by], [is_deleted]) VALUES (6, N'MacBook Air 13 inch M1 2020', 18000000, 200, N'The MacBook Air with the most groundbreaking performance ever is here. The all-new Apple M1 processor brings the power of the 2020 13-inch MacBook Air M1 beyond user expectations, able to run heavy tasks and amazing battery life.', 2, 7, CAST(N'2024-01-19' AS Date), 4, 1)\r\n","INSERT [dbo].[Product] ([product_id], [product_name], [price], [quantity], [description], [category_id], [image_id], [create_date], [create_by], [is_deleted]) VALUES (1002, N'ss15', 20000, 20000, N'ádfgnm', 1, 7, CAST(N'2024-01-23' AS Date), 4, 1)\r\n","SET IDENTITY_INSERT [dbo].[Product] OFF\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Product' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [dbo].[Role]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Role' and @Schema='dbo']","object_type":"Table"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["SET IDENTITY_INSERT [dbo].[Role] ON \r\n","INSERT [dbo].[Role] ([role_id], [role_name], [is_deleted]) VALUES (1, N'Admin', 0)\r\n","INSERT [dbo].[Role] ([role_id], [role_name], [is_deleted]) VALUES (2, N'Staff', 0)\r\n","INSERT [dbo].[Role] ([role_id], [role_name], [is_deleted]) VALUES (3, N'User', 0)\r\n","SET IDENTITY_INSERT [dbo].[Role] OFF\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Role' and @Schema='dbo']","object_type":"Table"}},{"cell_type":"markdown","source":["# [fk_account_role]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Account' and @Schema='dbo']/ForeignKey[@Name='fk_account_role']","object_type":"ForeignKey"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [fk_account_role] FOREIGN KEY([role_id])\r\nREFERENCES [dbo].[Role] ([role_id])\r\n","GO\r\n","ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [fk_account_role]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Account' and @Schema='dbo']/ForeignKey[@Name='fk_account_role']","object_type":"ForeignKey"}},{"cell_type":"markdown","source":["# [fk_item_product]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Order_details' and @Schema='dbo']/ForeignKey[@Name='fk_item_product']","object_type":"ForeignKey"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["ALTER TABLE [dbo].[Order_details]  WITH CHECK ADD  CONSTRAINT [fk_item_product] FOREIGN KEY([product_id])\r\nREFERENCES [dbo].[Product] ([product_id])\r\n","GO\r\n","ALTER TABLE [dbo].[Order_details] CHECK CONSTRAINT [fk_item_product]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Order_details' and @Schema='dbo']/ForeignKey[@Name='fk_item_product']","object_type":"ForeignKey"}},{"cell_type":"markdown","source":["# [fk_oder_items]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Order_details' and @Schema='dbo']/ForeignKey[@Name='fk_oder_items']","object_type":"ForeignKey"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["ALTER TABLE [dbo].[Order_details]  WITH CHECK ADD  CONSTRAINT [fk_oder_items] FOREIGN KEY([order_id])\r\nREFERENCES [dbo].[Orders] ([order_id])\r\n","GO\r\n","ALTER TABLE [dbo].[Order_details] CHECK CONSTRAINT [fk_oder_items]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Order_details' and @Schema='dbo']/ForeignKey[@Name='fk_oder_items']","object_type":"ForeignKey"}},{"cell_type":"markdown","source":["# [fk_order_coupon]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Orders' and @Schema='dbo']/ForeignKey[@Name='fk_order_coupon']","object_type":"ForeignKey"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [fk_order_coupon] FOREIGN KEY([coupon_id])\r\nREFERENCES [dbo].[Coupons] ([coupon_id])\r\n","GO\r\n","ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [fk_order_coupon]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Orders' and @Schema='dbo']/ForeignKey[@Name='fk_order_coupon']","object_type":"ForeignKey"}},{"cell_type":"markdown","source":["# [fk_order_customer]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Orders' and @Schema='dbo']/ForeignKey[@Name='fk_order_customer']","object_type":"ForeignKey"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [fk_order_customer] FOREIGN KEY([customer_id])\r\nREFERENCES [dbo].[Account] ([account_id])\r\n","GO\r\n","ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [fk_order_customer]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Orders' and @Schema='dbo']/ForeignKey[@Name='fk_order_customer']","object_type":"ForeignKey"}},{"cell_type":"markdown","source":["# [fk_order_payment]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Orders' and @Schema='dbo']/ForeignKey[@Name='fk_order_payment']","object_type":"ForeignKey"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [fk_order_payment] FOREIGN KEY([payment_id])\r\nREFERENCES [dbo].[Payment] ([payment_id])\r\n","GO\r\n","ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [fk_order_payment]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Orders' and @Schema='dbo']/ForeignKey[@Name='fk_order_payment']","object_type":"ForeignKey"}},{"cell_type":"markdown","source":["# [fk_product_account]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Product' and @Schema='dbo']/ForeignKey[@Name='fk_product_account']","object_type":"ForeignKey"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [fk_product_account] FOREIGN KEY([create_by])\r\nREFERENCES [dbo].[Account] ([account_id])\r\n","GO\r\n","ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [fk_product_account]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Product' and @Schema='dbo']/ForeignKey[@Name='fk_product_account']","object_type":"ForeignKey"}},{"cell_type":"markdown","source":["# [fk_product_category]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Product' and @Schema='dbo']/ForeignKey[@Name='fk_product_category']","object_type":"ForeignKey"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [fk_product_category] FOREIGN KEY([category_id])\r\nREFERENCES [dbo].[Category] ([category_id])\r\n","GO\r\n","ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [fk_product_category]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Product' and @Schema='dbo']/ForeignKey[@Name='fk_product_category']","object_type":"ForeignKey"}},{"cell_type":"markdown","source":["# [fk_product_image]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Product' and @Schema='dbo']/ForeignKey[@Name='fk_product_image']","object_type":"ForeignKey"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [fk_product_image] FOREIGN KEY([image_id])\r\nREFERENCES [dbo].[Image] ([image_id])\r\n","GO\r\n","ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [fk_product_image]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Product' and @Schema='dbo']/ForeignKey[@Name='fk_product_image']","object_type":"ForeignKey"}},{"cell_type":"markdown","source":["# [fk_review_customer]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Reviews' and @Schema='dbo']/ForeignKey[@Name='fk_review_customer']","object_type":"ForeignKey"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [fk_review_customer] FOREIGN KEY([customer_id])\r\nREFERENCES [dbo].[Account] ([account_id])\r\n","GO\r\n","ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [fk_review_customer]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Reviews' and @Schema='dbo']/ForeignKey[@Name='fk_review_customer']","object_type":"ForeignKey"}},{"cell_type":"markdown","source":["# [fk_review_product]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Reviews' and @Schema='dbo']/ForeignKey[@Name='fk_review_product']","object_type":"ForeignKey"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [fk_review_product] FOREIGN KEY([product_id])\r\nREFERENCES [dbo].[Product] ([product_id])\r\n","GO\r\n","ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [fk_review_product]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']/Table[@Name='Reviews' and @Schema='dbo']/ForeignKey[@Name='fk_review_product']","object_type":"ForeignKey"}},{"cell_type":"markdown","source":["# [FStore]"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']","object_type":"Database"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["USE [master]\r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']","object_type":"Database"}},{"outputs":[],"execution_count":0,"cell_type":"code","source":["ALTER DATABASE [FStore] SET  READ_WRITE \r\n","GO\r\n"],"metadata":{"urn":"Server[@Name='LAPTOP-EGA5VO08\\DANGSINH']/Database[@Name='FStore']","object_type":"Database"}}]} r o d u c t ]   C H E C K   C O N S T R A I N T   [ f k _ p r o d u c t _ i m a g e ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ R e v i e w s ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ f k _ r e v i e w _ c u s t o m e r ]   F O R E I G N   K E Y ( [ c u s t o m e r _ i d ] )  
 R E F E R E N C E S   [ d b o ] . [ A c c o u n t ]   ( [ a c c o u n t _ i d ] )  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ R e v i e w s ]   C H E C K   C O N S T R A I N T   [ f k _ r e v i e w _ c u s t o m e r ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ R e v i e w s ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ f k _ r e v i e w _ p r o d u c t ]   F O R E I G N   K E Y ( [ p r o d u c t _ i d ] )  
 R E F E R E N C E S   [ d b o ] . [ P r o d u c t ]   ( [ p r o d u c t _ i d ] )  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ R e v i e w s ]   C H E C K   C O N S T R A I N T   [ f k _ r e v i e w _ p r o d u c t ]  
 G O  
 U S E   [ m a s t e r ]  
 G O  
 A L T E R   D A T A B A S E   [ F S t o r e ]   S E T     R E A D _ W R I T E    
 G O  
 