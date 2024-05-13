USE [master]
GO
/****** Object:  Database [KP]    Script Date: 13.05.2024 12:46:00 ******/
CREATE DATABASE [KP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KP', FILENAME = N'C:\SQL\MSSQL15.SQLEXPRESS\MSSQL\DATA\KP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KP_log', FILENAME = N'C:\SQL\MSSQL15.SQLEXPRESS\MSSQL\DATA\KP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KP] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KP] SET ARITHABORT OFF 
GO
ALTER DATABASE [KP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KP] SET  MULTI_USER 
GO
ALTER DATABASE [KP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KP] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KP] SET QUERY_STORE = OFF
GO
USE [KP]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 13.05.2024 12:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Client_ID] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [nvarchar](50) NOT NULL,
	[Last_Name] [nvarchar](100) NOT NULL,
	[Patronomic] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Client_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 13.05.2024 12:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Employee_ID] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [nvarchar](50) NOT NULL,
	[Last_Name] [nvarchar](100) NOT NULL,
	[Patronymic] [nvarchar](100) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Emial] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Post] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Employee_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 13.05.2024 12:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Order_number] [int] IDENTITY(1,1) NOT NULL,
	[Client_ID] [int] NOT NULL,
	[Product_ID] [int] NOT NULL,
	[Employee_ID] [int] NOT NULL,
	[Product_Name] [nvarchar](100) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[Data] [date] NOT NULL,
	[Cost] [money] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Order_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 13.05.2024 12:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Product_ID] [int] IDENTITY(1,1) NOT NULL,
	[Provider_ID] [int] NOT NULL,
	[Product_Name] [nvarchar](100) NOT NULL,
	[Manufacturer] [nvarchar](100) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Quantity] [int] NOT NULL,
	[Cost] [money] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 13.05.2024 12:46:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[Provider_ID] [int] IDENTITY(1,1) NOT NULL,
	[Company] [nvarchar](100) NOT NULL,
	[Payment_Account] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED 
(
	[Provider_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Client_ID], [First_Name], [Last_Name], [Patronomic], [Email], [Phone], [BirthDate]) VALUES (1, N'Юра', N'Олийнык', N'Дмитриевич', N'yura.olijnyck@yandex.ru', N'79121473828', CAST(N'2005-04-29' AS Date))
INSERT [dbo].[Client] ([Client_ID], [First_Name], [Last_Name], [Patronomic], [Email], [Phone], [BirthDate]) VALUES (2, N'Николай', N'Тельтевский', N'Владимирович', N'nikolai.tel@ya.ru', N'79125279861', CAST(N'2005-09-25' AS Date))
INSERT [dbo].[Client] ([Client_ID], [First_Name], [Last_Name], [Patronomic], [Email], [Phone], [BirthDate]) VALUES (3, N'Владислав', N'Штрак', N'Игнатьевич', N'shtrak.vlad@mail.ru', N'79126123871', CAST(N'2005-03-07' AS Date))
INSERT [dbo].[Client] ([Client_ID], [First_Name], [Last_Name], [Patronomic], [Email], [Phone], [BirthDate]) VALUES (4, N'Иван', N'Иванов', N'Степанович', N'ivanov.ig@yandex.ru', N'79121678592', CAST(N'1998-05-03' AS Date))
INSERT [dbo].[Client] ([Client_ID], [First_Name], [Last_Name], [Patronomic], [Email], [Phone], [BirthDate]) VALUES (13, N'Андрей', N'Уфимский', N'Васильевич', N'fim.andrei@ya.ru', N'79121589678', CAST(N'0001-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Employee_ID], [First_Name], [Last_Name], [Patronymic], [BirthDate], [Phone], [Emial], [Address], [Post]) VALUES (1, N'Владислов', N'Гришин', N'Иванович', CAST(N'2005-02-23' AS Date), N'79121486473', N'vlad.gr@ya.ru', N'Бульвар Пищевиков 7А, кв. 31', N'Продавец')
INSERT [dbo].[Employee] ([Employee_ID], [First_Name], [Last_Name], [Patronymic], [BirthDate], [Phone], [Emial], [Address], [Post]) VALUES (2, N'Семенов', N'Ларин', N'Анатольевич', CAST(N'2002-01-17' AS Date), N'79043579125', N'lapin.sem@ya.ru', N'ул. Чернова, кв. 2Б', N'Работник склада')
INSERT [dbo].[Employee] ([Employee_ID], [First_Name], [Last_Name], [Patronymic], [BirthDate], [Phone], [Emial], [Address], [Post]) VALUES (3, N'Андрей', N'Кольцкий', N'Романович', CAST(N'2000-05-21' AS Date), N'79126859435', N'anrdew@mai.ru', N'ул. Пирогова 8А, кв. 72', N'Администратор')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Order_number], [Client_ID], [Product_ID], [Employee_ID], [Product_Name], [Comment], [Data], [Cost]) VALUES (2, 1, 1, 1, N'Мышка Ardor Fury', N'Проверить', CAST(N'2023-08-16' AS Date), 1699.0000)
INSERT [dbo].[Order] ([Order_number], [Client_ID], [Product_ID], [Employee_ID], [Product_Name], [Comment], [Data], [Cost]) VALUES (3, 2, 3, 1, N'Мышка Ardor Prime Pro', NULL, CAST(N'2023-08-17' AS Date), 1850.0000)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Product_ID], [Provider_ID], [Product_Name], [Manufacturer], [Type], [Model], [Description], [Quantity], [Cost]) VALUES (1, 1, N'Мышка', N'Ardor', N'проводная/беспроводная', N'Fury', N'12400 dpi, USB Type-A, кнопки - 7', 2, 1699.0000)
INSERT [dbo].[Product] ([Product_ID], [Provider_ID], [Product_Name], [Manufacturer], [Type], [Model], [Description], [Quantity], [Cost]) VALUES (3, 1, N'Мышка', N'Ardor', N'проводная', N'Prime Pro', N'12000 dpi, USB Type-A, кнопки - 7', 1, 1850.0000)
INSERT [dbo].[Product] ([Product_ID], [Provider_ID], [Product_Name], [Manufacturer], [Type], [Model], [Description], [Quantity], [Cost]) VALUES (5, 3, N'Клавиатура', N'Xyper', N'проводная', N'Alloy Core', N'мембранная, клавиш - 105, USB, Черная', 2, 4999.0000)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Provider] ON 

INSERT [dbo].[Provider] ([Provider_ID], [Company], [Payment_Account], [Address], [Phone], [Email]) VALUES (1, N'Ardor', 110257963, N'г. Москва, ул. Тверская, оф. 203', N'78289168927', N'ardor-gaming@gm.ru')
INSERT [dbo].[Provider] ([Provider_ID], [Company], [Payment_Account], [Address], [Phone], [Email]) VALUES (3, N'Xyper', 111786321, N'г. Киров, ул. Владимирская, оф. 32', N'76248531578', N'xyper_cloud@ya.ru')
SET IDENTITY_INSERT [dbo].[Provider] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client] FOREIGN KEY([Client_ID])
REFERENCES [dbo].[Client] ([Client_ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Client]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee] FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employee] ([Employee_ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Employee]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([Product_ID])
REFERENCES [dbo].[Product] ([Product_ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Provider] FOREIGN KEY([Provider_ID])
REFERENCES [dbo].[Provider] ([Provider_ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Provider]
GO
USE [master]
GO
ALTER DATABASE [KP] SET  READ_WRITE 
GO
