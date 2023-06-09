USE [master]
GO
/****** Object:  Database [Assignment2]    Script Date: 6/14/2023 11:25:08 AM ******/
CREATE DATABASE [Assignment2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Assignment2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Assignment2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Assignment2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Assignment2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Assignment2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Assignment2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Assignment2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Assignment2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Assignment2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Assignment2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Assignment2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Assignment2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Assignment2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Assignment2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Assignment2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Assignment2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Assignment2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Assignment2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Assignment2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Assignment2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Assignment2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Assignment2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Assignment2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Assignment2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Assignment2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Assignment2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Assignment2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Assignment2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Assignment2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Assignment2] SET  MULTI_USER 
GO
ALTER DATABASE [Assignment2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Assignment2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Assignment2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Assignment2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Assignment2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Assignment2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Assignment2] SET QUERY_STORE = ON
GO
ALTER DATABASE [Assignment2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Assignment2]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 6/14/2023 11:25:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[author_id] [int] IDENTITY(1,1) NOT NULL,
	[last_name] [nvarchar](20) NOT NULL,
	[first_name] [nvarchar](20) NOT NULL,
	[phone] [nvarchar](20) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[city] [nvarchar](20) NOT NULL,
	[state] [nvarchar](20) NOT NULL,
	[zip] [nvarchar](20) NOT NULL,
	[email_adress] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 6/14/2023 11:25:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[type] [nvarchar](20) NOT NULL,
	[pub_id] [int] NULL,
	[price] [int] NULL,
	[advance] [nvarchar](50) NOT NULL,
	[royalty] [nvarchar](50) NOT NULL,
	[ytd_sales] [nvarchar](20) NOT NULL,
	[notes] [nvarchar](50) NOT NULL,
	[published_date] [smalldatetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthor]    Script Date: 6/14/2023 11:25:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthor](
	[author_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[author_order] [nvarchar](50) NOT NULL,
	[royality_percentage] [int] NULL,
 CONSTRAINT [PK_BookAuthor] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC,
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 6/14/2023 11:25:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[pub_id] [int] IDENTITY(1,1) NOT NULL,
	[publisher_name] [nvarchar](20) NOT NULL,
	[city] [nvarchar](20) NOT NULL,
	[state] [nvarchar](20) NOT NULL,
	[country] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pub_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/14/2023 11:25:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] NOT NULL,
	[role_desc] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/14/2023 11:25:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[email_address] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[source] [nvarchar](30) NOT NULL,
	[first_name] [nvarchar](20) NOT NULL,
	[middle_name] [nvarchar](20) NOT NULL,
	[last_name] [nvarchar](20) NOT NULL,
	[role_id] [int] NULL,
	[pub_id] [int] NULL,
	[hire_date] [smalldatetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_adress]) VALUES (18, N'them moi', N'them moi ', N'000', N'Hanoi', N'HaNoi', N'1', N'1', N'hanoi')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_adress]) VALUES (19, N'them moi', N'them moi ', N'000', N'Hanoi', N'HaNoi', N'1', N'1', N'hanoi')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_adress]) VALUES (21, N'g', N'g', N'g', N'g', N'g', N'g', N'g', N'g')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_adress]) VALUES (22, N'f', N'f', N'f', N'f', N'f', N'f', N'f', N'f')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_adress]) VALUES (23, N'h', N'h', N'h', N'h', N'j', N'j', N'j', N'j')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_adress]) VALUES (24, N'them moi 24', N'string', N'string', N'string', N'string', N'string', N'string', N'string')
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (1, N'1', N'1', 1, 1, N'1', N'1', N'1', N'1', CAST(N'2000-11-11T00:00:00' AS SmallDateTime))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (4, N'1', N'1', 1, 1, N'1', N'1', N'1', N'1', CAST(N'2000-11-11T00:00:00' AS SmallDateTime))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (12, N'2', N'1', 1, 1, N'1', N'1', N'1', N'1', CAST(N'2000-11-11T00:00:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Publisher] ON 

INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (1, N'nguyen van avvvv', N'hanoi11111', N'male', N'Vietnam')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (6, N'dattheotaiiiii', N'aaaa', N'aaaa', N'Vietnam')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (7, N'dattheotaiiiii', N'aaaa', N'aaaaa', N'Vietnam')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (8, N'11qqqqq', N'hanoi 4', N'single', N'Vietnam')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (9, N'dm thai quan', N'hanoi', N'single', N'Vietnam')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (10, N'11qqqqq', N'aaaaa', N'single', N'Vietnam')
SET IDENTITY_INSERT [dbo].[Publisher] OFF
GO
INSERT [dbo].[Role] ([role_id], [role_desc]) VALUES (1, 1)
INSERT [dbo].[Role] ([role_id], [role_desc]) VALUES (2, 2)
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (8, N'emp1@fpt.edu.vn', N'123333', N'123', N'a', N'b', N'c', 1, 1, CAST(N'2023-06-08T11:54:00' AS SmallDateTime))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (14, N'dat@123', N'123', N'123', N'datr', N'datr', N'dat', 1, 1, CAST(N'2000-11-11T00:00:00' AS SmallDateTime))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (23, N'dat@gmailss.com', N'123', N'123', N'dats', N'dats', N'dats', 1, 1, CAST(N'1900-05-04T00:00:00' AS SmallDateTime))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (24, N'datsing1911@gmail.com', N'123', N'123', N'a', N'b', N'c', 1, 1, CAST(N'2023-06-06T16:37:00' AS SmallDateTime))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (25, N'datsing1911@gmail.com', N'123', N'123', N'a', N'b', N'c', 2, 1, CAST(N'2023-06-06T16:38:00' AS SmallDateTime))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (26, N'datsing1911@gmail.com', N'123', N'123', N'a', N'b', N'c', 2, 1, CAST(N'2023-06-06T16:40:00' AS SmallDateTime))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (27, N'emp2@fpt.edu.vn', N'123', N'123', N'a', N'b', N'c', 2, 1, CAST(N'2023-06-06T23:16:00' AS SmallDateTime))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (28, N'dat123@123', N'123', N'123', N'a', N'b', N'c', 2, 1, CAST(N'2023-06-09T10:03:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Role] FOREIGN KEY([pub_id])
REFERENCES [dbo].[Publisher] ([pub_id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Role]
GO
ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthor_Author] FOREIGN KEY([author_id])
REFERENCES [dbo].[Author] ([author_id])
GO
ALTER TABLE [dbo].[BookAuthor] CHECK CONSTRAINT [FK_BookAuthor_Author]
GO
ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD  CONSTRAINT [FK_BookAuthor_Book] FOREIGN KEY([book_id])
REFERENCES [dbo].[Book] ([book_id])
GO
ALTER TABLE [dbo].[BookAuthor] CHECK CONSTRAINT [FK_BookAuthor_Book]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([pub_id])
REFERENCES [dbo].[Publisher] ([pub_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [Assignment2] SET  READ_WRITE 
GO
