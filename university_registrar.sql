USE [master]
GO
/****** Object:  Database [university_registrar]    Script Date: 6/13/2017 4:06:30 PM ******/
CREATE DATABASE [university_registrar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'university_registrar', FILENAME = N'C:\Users\epicodus\university_registrar.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'university_registrar_log', FILENAME = N'C:\Users\epicodus\university_registrar_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [university_registrar] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [university_registrar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [university_registrar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [university_registrar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [university_registrar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [university_registrar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [university_registrar] SET ARITHABORT OFF 
GO
ALTER DATABASE [university_registrar] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [university_registrar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [university_registrar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [university_registrar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [university_registrar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [university_registrar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [university_registrar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [university_registrar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [university_registrar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [university_registrar] SET  ENABLE_BROKER 
GO
ALTER DATABASE [university_registrar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [university_registrar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [university_registrar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [university_registrar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [university_registrar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [university_registrar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [university_registrar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [university_registrar] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [university_registrar] SET  MULTI_USER 
GO
ALTER DATABASE [university_registrar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [university_registrar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [university_registrar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [university_registrar] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [university_registrar] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [university_registrar] SET QUERY_STORE = OFF
GO
USE [university_registrar]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [university_registrar]
GO
/****** Object:  Table [dbo].[courses]    Script Date: 6/13/2017 4:06:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[time] [varchar](50) NULL,
	[credits] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[student_courses]    Script Date: 6/13/2017 4:06:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student_courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NULL,
	[course_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[students]    Script Date: 6/13/2017 4:06:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[doe] [datetime] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[courses] ON 

INSERT [dbo].[courses] ([id], [name], [time], [credits]) VALUES (5, N'c#', N'8pm', 3)
INSERT [dbo].[courses] ([id], [name], [time], [credits]) VALUES (6, N'PHP', N'2pm', 3)
INSERT [dbo].[courses] ([id], [name], [time], [credits]) VALUES (7, N'Android', N'1am', 3)
SET IDENTITY_INSERT [dbo].[courses] OFF
SET IDENTITY_INSERT [dbo].[student_courses] ON 

INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (10, 7, 6)
SET IDENTITY_INSERT [dbo].[student_courses] OFF
SET IDENTITY_INSERT [dbo].[students] ON 

INSERT [dbo].[students] ([id], [name], [doe]) VALUES (6, N'paul joe', CAST(N'2017-06-21T00:00:00.000' AS DateTime))
INSERT [dbo].[students] ([id], [name], [doe]) VALUES (7, N'Jun Dowd', CAST(N'2017-06-30T00:00:00.000' AS DateTime))
INSERT [dbo].[students] ([id], [name], [doe]) VALUES (8, N'John Dowd', CAST(N'2017-06-11T00:00:00.000' AS DateTime))
INSERT [dbo].[students] ([id], [name], [doe]) VALUES (10, N'Joey Joe Joe ', CAST(N'2017-03-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[students] OFF
USE [master]
GO
ALTER DATABASE [university_registrar] SET  READ_WRITE 
GO
