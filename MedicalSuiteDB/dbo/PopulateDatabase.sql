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
SET IDENTITY_INSERT [dbo].[Prescription] ON 
GO
INSERT [dbo].[Prescription] ([PrescriptionId], [PrescriptionName], [PrescriptionStrength], [PrescriptionDirections], [WrittenDate], [Notes], [CategoryId]) VALUES (1, N'Tylenol', N'250 mg', N'Take as needed', CAST(N'2023-03-31T09:33:00.000' AS DateTime), N'Take them all', 1)
GO
SET IDENTITY_INSERT [dbo].[Prescription] OFF
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LasLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (18, N'Brooke', N'Candy', N'BC@gmail.com', N'$2a$13$56rBz65j/TUleF51uRwjjehJTf8/0Q8h7rs1R5OUd0bKhbAlYdPVC', CAST(N'2024-04-01T22:10:29.000' AS DateTime), 1, 1, N'1234567890  ')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LasLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (21, N'Adam', N'Kramer', N'Adam.K@gmail.com', N'$2a$13$Q/xpkxeF.80RnAGZyrwb1Ori/FDToYbfQJYvB/l0tgilm2JfJRwlq', CAST(N'2024-04-01T21:32:45.000' AS DateTime), 1, 1, N'1223334444  ')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LasLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (27, N'juan', N'robledo', N'poop@poop.com', N'$2a$13$LD2VdzkEb42NA98gbmQfaeqZihX/HFjp5kizFi74W1MXuGQ8dZKna', CAST(N'2024-04-01T11:11:52.000' AS DateTime), 1, 1, N'111-222-3333')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LasLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (57, N'Samantha', N'Porter', N'sam_porter@gmail.com', N'$2a$13$GbZQ8Uheo37jhkNEw6tMxOaEJTROUUDwwWTnu34eoJPZS6hgSSAMq', CAST(N'2024-03-31T22:31:29.000' AS DateTime), 1, 1, N'111-222-3333')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LasLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (60, N'Steven', N'Icy', N'steveIce@gmail.com', N'$2a$13$OYFusMB0RYa1mdUuL9vdZ.n7sG/CdUKjaE9eG5FPYAqAxE1gFt4F2', CAST(N'2024-04-01T11:58:54.000' AS DateTime), 1, 1, N'1112223333  ')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LasLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (68, N'Analise', N'Keeting', N'AK@gmail.com', N'$2a$13$/Yc/c7XRMTsoYF7hLfIRFedRszjuWhiPJTzmCVXVLQoLS7bUzD9TS', CAST(N'2024-04-01T21:58:06.000' AS DateTime), 1, 1, N'0987654321  ')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LasLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (97, N'Jessica', N'Fernandez', N'jessiefernandez@gmail.com', N'$2a$13$SHJ/SR2gqNSY8ihcIn4GROtfFHnA56qJJNuJoHpiSFNm/Gxtjp8kG', CAST(N'2024-03-31T21:03:40.000' AS DateTime), 1, 1, N'123-456-7890')
GO
INSERT [dbo].[DoctorsOffice] ([DoctorsOfficeId], [DoctorsOfficeName], [StreetAddress], [City], [State], [ZipCode], [Phone], [PersonId]) VALUES (N'1', N'Nacogdoches Health Partners', N'4800 NE Stallings Dr #109', N'Nacogdoches', N'TX', N'75965', N'(936)559-0700', 18)
GO
INSERT [dbo].[Inventory] ([InventoryItemId], [DoctorsOfficeId], [InventoryItemCode], [InventoryItemName], [InventoryItemDescription], [InventoryItemPrice], [CategoryId]) VALUES (1, N'1', N'100', N'Asprin                                                                                              ', N'25mg 60 count                                                                                                                                                                                                                                             ', CAST(20.00 AS Decimal(5, 2)), 1)
GO
INSERT [dbo].[Inventory] ([InventoryItemId], [DoctorsOfficeId], [InventoryItemCode], [InventoryItemName], [InventoryItemDescription], [InventoryItemPrice], [CategoryId]) VALUES (2, N'1', N'101', N'Asprin                                                                                              ', N'50mg 60 count                                                                                                                                                                                                                                             ', CAST(35.00 AS Decimal(5, 2)), 1)
GO
INSERT [dbo].[Inventory] ([InventoryItemId], [DoctorsOfficeId], [InventoryItemCode], [InventoryItemName], [InventoryItemDescription], [InventoryItemPrice], [CategoryId]) VALUES (3, N'1', N'102', N'Asprin                                                                                              ', N'100mg 60 count                                                                                                                                                                                                                                            ', CAST(70.00 AS Decimal(5, 2)), 1)
GO
