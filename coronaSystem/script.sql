USE [master]
GO
/****** Object:  Database [coronadetailsDB]    Script Date: 11/05/2023 16:14:52 ******/
CREATE DATABASE [coronadetailsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'coronadetailsDB', FILENAME = N'C:\Users\1\coronadetailsDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'coronadetailsDB_log', FILENAME = N'C:\Users\1\coronadetailsDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [coronadetailsDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [coronadetailsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [coronadetailsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [coronadetailsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [coronadetailsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [coronadetailsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [coronadetailsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [coronadetailsDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [coronadetailsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [coronadetailsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [coronadetailsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [coronadetailsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [coronadetailsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [coronadetailsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [coronadetailsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [coronadetailsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [coronadetailsDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [coronadetailsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [coronadetailsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [coronadetailsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [coronadetailsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [coronadetailsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [coronadetailsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [coronadetailsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [coronadetailsDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [coronadetailsDB] SET  MULTI_USER 
GO
ALTER DATABASE [coronadetailsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [coronadetailsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [coronadetailsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [coronadetailsDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [coronadetailsDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [coronadetailsDB] SET QUERY_STORE = OFF
GO
USE [coronadetailsDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [coronadetailsDB]
GO
/****** Object:  Table [dbo].[Coronavaccine]    Script Date: 11/05/2023 16:14:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coronavaccine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[manufacturer] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patients]    Script Date: 11/05/2023 16:14:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](30) NOT NULL,
	[last_name] [nvarchar](30) NOT NULL,
	[patientId] [nvarchar](9) NOT NULL,
	[city] [nvarchar](30) NOT NULL,
	[street] [nvarchar](50) NOT NULL,
	[numHouse] [int] NOT NULL,
	[dateofbirth] [date] NOT NULL,
	[telephone] [varchar](10) NULL,
	[mobilephone] [varchar](20) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[PositiveResultDate] [date] NULL,
	[RecoveryDate] [date] NULL,
	[imagepath] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[patientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vaccinesforpatients]    Script Date: 11/05/2023 16:14:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vaccinesforpatients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[patientId] [int] NOT NULL,
	[vaccineId] [int] NOT NULL,
	[Dateofvaccination] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[patients] ADD  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[Vaccinesforpatients]  WITH CHECK ADD FOREIGN KEY([patientId])
REFERENCES [dbo].[patients] ([id])
GO
ALTER TABLE [dbo].[Vaccinesforpatients]  WITH CHECK ADD FOREIGN KEY([vaccineId])
REFERENCES [dbo].[Coronavaccine] ([id])
GO
ALTER TABLE [dbo].[Coronavaccine]  WITH CHECK ADD CHECK  ((len([manufacturer])>=(2)))
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD CHECK  ((len([city])>=(2)))
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD CHECK  ((len([first_name])>=(2)))
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD CHECK  ((len([last_name])>=(2)))
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD CHECK  ((len([mobilephone])>=(10)))
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD CHECK  ((len([patientId])>(5)))
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD CHECK  ((len([street])>=(2)))
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD CHECK  ((len([telephone])>=(7)))
GO
USE [master]
GO
ALTER DATABASE [coronadetailsDB] SET  READ_WRITE 
GO
