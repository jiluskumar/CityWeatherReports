USE [master]
GO
/****** Object:  Database [cityweather]    Script Date: 10/12/2022 12:32:01 AM ******/
CREATE DATABASE [cityweather]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cityweather', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\cityweather.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cityweather_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\cityweather_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [cityweather] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cityweather].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cityweather] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cityweather] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cityweather] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cityweather] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cityweather] SET ARITHABORT OFF 
GO
ALTER DATABASE [cityweather] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cityweather] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cityweather] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cityweather] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cityweather] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cityweather] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cityweather] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cityweather] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cityweather] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cityweather] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cityweather] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cityweather] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cityweather] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cityweather] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cityweather] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cityweather] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cityweather] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cityweather] SET RECOVERY FULL 
GO
ALTER DATABASE [cityweather] SET  MULTI_USER 
GO
ALTER DATABASE [cityweather] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cityweather] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cityweather] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cityweather] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cityweather] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [cityweather] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'cityweather', N'ON'
GO
ALTER DATABASE [cityweather] SET QUERY_STORE = OFF
GO
USE [cityweather]
GO
/****** Object:  Table [dbo].[City]    Script Date: 10/12/2022 12:32:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[TouristRating] [smallint] NOT NULL,
	[TwoDigitCountryCode] [varchar](2) NULL,
	[ThreeDigitCountryCode] [varchar](3) NULL,
	[CityWeather] [smallint] NULL,
	[DateEstablisted] [date] NOT NULL,
	[EstimatedPopulation] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [cityweather] SET  READ_WRITE 
GO
