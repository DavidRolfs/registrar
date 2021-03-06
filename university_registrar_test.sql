USE [master]
GO
/****** Object:  Database [university_registrar_test]    Script Date: 6/13/2017 4:07:21 PM ******/
CREATE DATABASE [university_registrar_test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'university_registrar', FILENAME = N'C:\Users\epicodus\university_registrar_test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'university_registrar_log', FILENAME = N'C:\Users\epicodus\university_registrar_test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [university_registrar_test] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [university_registrar_test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [university_registrar_test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [university_registrar_test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [university_registrar_test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [university_registrar_test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [university_registrar_test] SET ARITHABORT OFF 
GO
ALTER DATABASE [university_registrar_test] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [university_registrar_test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [university_registrar_test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [university_registrar_test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [university_registrar_test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [university_registrar_test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [university_registrar_test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [university_registrar_test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [university_registrar_test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [university_registrar_test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [university_registrar_test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [university_registrar_test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [university_registrar_test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [university_registrar_test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [university_registrar_test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [university_registrar_test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [university_registrar_test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [university_registrar_test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [university_registrar_test] SET  MULTI_USER 
GO
ALTER DATABASE [university_registrar_test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [university_registrar_test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [university_registrar_test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [university_registrar_test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [university_registrar_test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [university_registrar_test] SET QUERY_STORE = OFF
GO
USE [university_registrar_test]
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
USE [university_registrar_test]
GO
/****** Object:  Table [dbo].[courses]    Script Date: 6/13/2017 4:07:21 PM ******/
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
/****** Object:  Table [dbo].[student_courses]    Script Date: 6/13/2017 4:07:21 PM ******/
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
/****** Object:  Table [dbo].[students]    Script Date: 6/13/2017 4:07:21 PM ******/
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
SET IDENTITY_INSERT [dbo].[student_courses] ON 

INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (1, 1, 1)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (2, 2, 1)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (3, 3, 2)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (5, 5, 7)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (6, 8, 8)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (8, 11, 11)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (9, 12, 11)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (10, 13, 12)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (13, 18, 18)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (15, 21, 21)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (16, 22, 21)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (17, 23, 22)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (19, 25, 27)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (20, 28, 28)
INSERT [dbo].[student_courses] ([id], [student_id], [course_id]) VALUES (12, 15, 17)
SET IDENTITY_INSERT [dbo].[student_courses] OFF
USE [master]
GO
ALTER DATABASE [university_registrar_test] SET  READ_WRITE 
GO
