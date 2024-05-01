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
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'General Sales List')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Pharmacy Medicines')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Prescirption Only Medicines')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Controlled Drugs')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Doctor')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Nurse')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'Patient')
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1, N'gage', N'kolojaco', N'gk@gmail.com', N'$2a$13$szfBFu49Vgjr2L8XXEhfDeiP2B8VP4Y2m9BXvyrH8nOcq7z/CSV/S', CAST(N'2024-04-26T03:11:55.010' AS DateTime), NULL, 1, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (3, N'johanna', N'pister', N'pants@school.com', N'$2a$13$iKQvmzegpf3yBkhZ1Q0/5.tqD/y7OJkffx/.QGjf/T2cUiAbdX7pC', CAST(N'2024-05-01T00:08:35.030' AS DateTime), NULL, 3, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (4, N'Jo''Hannah', N'Proctor', N'didnotpisterpants@school.com', N'$2a$13$pBHQkDkGsExMkzwbPgsJNuBYkgZdKpd4HOpmOwM72ul6wH6J16IM2', CAST(N'2024-04-24T12:42:12.940' AS DateTime), NULL, 1, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (5, N'gage', N'kolojaco', N'gagekolojaco@gmail.com', N'$2a$13$huRtEr.1Ccs1hdrWljLbQuWrQvYEXiDT0g6FFrQjT7JdkkJwKg/Ja', CAST(N'2024-04-26T02:18:46.487' AS DateTime), NULL, 1, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1002, N'Ice', N'Spice', N'icespice@gmail.com', N'$2a$13$E7IokusCPHG/tJKoH/cXcOOkABdID9cq4M7B2jE3faAD0cFWT1jO.', CAST(N'2024-05-01T00:45:57.620' AS DateTime), NULL, 1, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1003, N'Greg', N'Art', N'GregA@gmail.com', N'$2a$13$99FTLA6sdi/rRWRQ8VcZre.xpZQbiFwZJic3HN6SXWnzrmlB9QptG', CAST(N'2024-04-30T23:06:06.000' AS DateTime), NULL, 3, N'1234567890')
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([AppointmentId], [AppointmentDate], [AppointmentTime], [AppointmentNotes], [DoctorsName], [PersonId]) VALUES (19, CAST(N'2010-10-10' AS Date), CAST(N'10:00:00' AS Time), N'101010101010', N'Dr.Binary', 1002)
INSERT [dbo].[Appointments] ([AppointmentId], [AppointmentDate], [AppointmentTime], [AppointmentNotes], [DoctorsName], [PersonId]) VALUES (20, CAST(N'2004-04-04' AS Date), CAST(N'04:00:00' AS Time), N'4444444444444', N'La''4sh', 3)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[InventoryItem] ON 

INSERT [dbo].[InventoryItem] ([InventoryItemId], [InventoryItemCode], [InventoryItemName], [InventoryItemDescription], [InventoryItemPrice], [CategoryId]) VALUES (5, N'sdfgh', N'sdfgh                                                                                               ', N'sdfgh                                                                                                                                                                                                                                                     ', CAST(10.00 AS Decimal(5, 2)), 4)
INSERT [dbo].[InventoryItem] ([InventoryItemId], [InventoryItemCode], [InventoryItemName], [InventoryItemDescription], [InventoryItemPrice], [CategoryId]) VALUES (7, N'12345', N'asdfghjk                                                                                            ', N'qwertyuio                                                                                                                                                                                                                                                 ', CAST(10.00 AS Decimal(5, 2)), 3)
SET IDENTITY_INSERT [dbo].[InventoryItem] OFF
GO
