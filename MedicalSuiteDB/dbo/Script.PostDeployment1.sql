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
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Patient')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Nurse')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'Doctor')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'General Sales List')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Pharmacy Medicines')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Prescirption Only Medicines')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Controlled Drugs')
GO
INSERT [dbo].[Prescription] ([PrescriptionId], [PrescriptionName], [PrescriptionStrength], [PrescriptionDirections], [WrittenDate], [Notes], [CategoryId]) VALUES (1, N'Tylenol', N'250 mg', N'Take as needed', CAST(N'2023-03-31T09:33:00.000' AS DateTime), N'Take them all', 1)
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LasLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (27, N'juan', N'robledo', N'poop@poop.com', N'$2a$13$LD2VdzkEb42NA98gbmQfaeqZihX/HFjp5kizFi74W1MXuGQ8dZKna', CAST(N'2024-04-01T11:11:52.000' AS DateTime), 1, 1, N'111-222-3333')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LasLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (57, N'Samantha', N'Porter', N'sam_porter@gmail.com', N'$2a$13$GbZQ8Uheo37jhkNEw6tMxOaEJTROUUDwwWTnu34eoJPZS6hgSSAMq', CAST(N'2024-03-31T22:31:29.000' AS DateTime), 1, 1, N'111-222-3333')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LasLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (60, N'Steven', N'Icy', N'steveIce@gmail.com', N'$2a$13$OYFusMB0RYa1mdUuL9vdZ.n7sG/CdUKjaE9eG5FPYAqAxE1gFt4F2', CAST(N'2024-04-01T11:58:54.000' AS DateTime), 1, 1, N'1112223333  ')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LasLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (97, N'Jessica', N'Fernandez', N'jessiefernandez@gmail.com', N'$2a$13$SHJ/SR2gqNSY8ihcIn4GROtfFHnA56qJJNuJoHpiSFNm/Gxtjp8kG', CAST(N'2024-03-31T21:03:40.000' AS DateTime), 1, 1, N'123-456-7890')
GO
