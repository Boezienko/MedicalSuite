/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/****** Object:  Database [MedicalDB]    Script Date: 3/31/2024 9:43:18 PM ******/
CREATE DATABASE [MedicalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
 /* NOTICE THAT YOU SHOULD PUT YOUR OWN FILEPATH*/
( NAME = N'MedicalDB', FILENAME = N'C:\Users\boeaz\MedicalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MedicalDB_log', FILENAME = N'C:\Users\boeaz\MedicalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MedicalDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MedicalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MedicalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MedicalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MedicalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MedicalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MedicalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MedicalDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MedicalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MedicalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MedicalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MedicalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MedicalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MedicalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MedicalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MedicalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MedicalDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MedicalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MedicalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MedicalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MedicalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MedicalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MedicalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MedicalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MedicalDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MedicalDB] SET  MULTI_USER 
GO
ALTER DATABASE [MedicalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MedicalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MedicalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MedicalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MedicalDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MedicalDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MedicalDB] SET QUERY_STORE = OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/31/2024 9:43:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorsOffice]    Script Date: 3/31/2024 9:43:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorsOffice](
	[DoctorsOfficeId] [int] NOT NULL,
	[DoctorsOfficeName] [varchar](200) NOT NULL,
	[StreetAddress] [varchar](100) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](2) NOT NULL,
	[ZipCode] [varchar](10) NOT NULL,
	[Phone] [varchar](25) NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_DoctorsOffice] PRIMARY KEY CLUSTERED 
(
	[DoctorsOfficeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 3/31/2024 9:43:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[InventoryId] [int] NOT NULL,
	[DoctorsOfficeId] [int] NOT NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[InventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryCategory]    Script Date: 3/31/2024 9:43:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryCategory](
	[InventoryId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_InventoryCategory] PRIMARY KEY CLUSTERED 
(
	[InventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 3/31/2024 9:43:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PasswordHash] [text] NOT NULL,
	[LasLoginTime] [datetime] NOT NULL,
	[PrescriptionId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Telephone] [nchar](12) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prescription]    Script Date: 3/31/2024 9:43:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prescription](
	[PrescriptionId] [int] NOT NULL,
	[PrescriptionName] [varchar](50) NOT NULL,
	[PrescriptionStrength] [varchar](25) NOT NULL,
	[PrescriptionDirections] [varchar](100) NOT NULL,
	[WrittenDate] [datetime] NOT NULL,
	[Notes] [varchar](200) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Prescription] PRIMARY KEY CLUSTERED 
(
	[PrescriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/31/2024 9:43:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'General Sales List')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Pharmacy Medicines')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Prescirption Only Medicines')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Controlled Drugs')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LasLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (97, N'Jessica', N'Fernandez', N'jessiefernandez@gmail.com', N'$2a$13$SHJ/SR2gqNSY8ihcIn4GROtfFHnA56qJJNuJoHpiSFNm/Gxtjp8kG', CAST(N'2024-03-31T21:03:40.000' AS DateTime), 1, 1, N'123-456-7890')
GO
INSERT [dbo].[Prescription] ([PrescriptionId], [PrescriptionName], [PrescriptionStrength], [PrescriptionDirections], [WrittenDate], [Notes], [CategoryId]) VALUES (1, N'Tylenol', N'250 mg', N'Take as needed', CAST(N'2023-03-31T09:33:00.000' AS DateTime), N'Take them all', 1)
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Patient')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Nurse')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'Doctor')
GO
ALTER TABLE [dbo].[DoctorsOffice]  WITH CHECK ADD  CONSTRAINT [FK_DoctorsOffice_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[DoctorsOffice] CHECK CONSTRAINT [FK_DoctorsOffice_Person]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_DoctorsOffice] FOREIGN KEY([DoctorsOfficeId])
REFERENCES [dbo].[DoctorsOffice] ([DoctorsOfficeId])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_DoctorsOffice]
GO
ALTER TABLE [dbo].[InventoryCategory]  WITH CHECK ADD  CONSTRAINT [FK_InventoryCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[InventoryCategory] CHECK CONSTRAINT [FK_InventoryCategory_Category]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Prescription] FOREIGN KEY([PrescriptionId])
REFERENCES [dbo].[Prescription] ([PrescriptionId])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Prescription]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Role]
GO
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_Prescription_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Prescription] CHECK CONSTRAINT [FK_Prescription_Category]
GO
ALTER DATABASE [MedicalDB] SET  READ_WRITE 
GO
