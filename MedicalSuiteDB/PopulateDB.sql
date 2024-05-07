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
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (1, N'Schedule I')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (2, N'Schedule II')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (3, N'Schedule III')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (4, N'Schedule IV')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (5, N'Schedule V')
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1005, N'John', N'Doe', N'DrJohnDoe@gmail.com', N'$2a$13$JvGD/9wX6eNItgu7L1XcrOWXop9i9gm7eP3.dqtuyHD1wyILcdMLW', CAST(N'2024-05-06T00:21:55.187' AS DateTime), NULL, 1, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1006, N'gage', N'kolojaco', N'gk@gmail.com', N'$2a$13$PjqDySHkCGaVqmS7UpjwoevZ6tzCml70JPKxvTe0do4dWPkzCeUay', CAST(N'2024-05-05T20:30:51.173' AS DateTime), NULL, 3, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1007, N'Boe', N'Zienko', N'bz@gmail.com', N'$2a$13$5IpwXgLdHEO09RssgFsRm.Apl04c5NMWA4nz3rpY46GVa9aCDlQAu', CAST(N'2024-05-01T12:34:01.000' AS DateTime), NULL, 3, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1008, N'Oreoluwa', N'Oladele-Ajose', N'oo@gmail.com', N'$2a$13$hk7SYew24yMm/JPRjNNsBOx82ju3hbhJTyfKYYHUUbmk..EGKyDMS', CAST(N'2024-05-01T12:35:12.000' AS DateTime), NULL, 3, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1009, N'Jo''Hannah', N'Proctor', N'jp@gmail.com', N'$2a$13$JnWBON2FiKTnziI3EyvUyu7EdxwcLhZDE78Rux48Ign/EE7czaxpK', CAST(N'2024-05-01T13:05:30.987' AS DateTime), NULL, 2, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1010, N'Jeff', N'Zheng', N'jz@gmail.com', N'$2a$13$T0NxJbvk/IuFuZyK0M/qA.xAEIACFIhmnTOkFpny0yVzA/JpA8VEm', CAST(N'2024-05-01T13:38:21.613' AS DateTime), NULL, 3, N'1234567890')
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[Prescription] ON 

INSERT [dbo].[Prescription] ([PrescriptionId], [PrescriptionName], [PrescriptionStrength], [PrescriptionQuantity], [PrescriptionDirections], [WrittenDate], [ExpirationDate], [PrescriptionScheduleId], [PersonId], [DoctorsName]) VALUES (1, N'Lexapro', N'69', N'123', N'fuck 2 electric boogalalo', CAST(N'2020-08-05' AS Date), CAST(N'3030-03-03' AS Date), 3, 1006, N'1005')
INSERT [dbo].[Prescription] ([PrescriptionId], [PrescriptionName], [PrescriptionStrength], [PrescriptionQuantity], [PrescriptionDirections], [WrittenDate], [ExpirationDate], [PrescriptionScheduleId], [PersonId], [DoctorsName]) VALUES (2, N'biggie cheese', N'123123', N'123124', N'hoooooly shit', CAST(N'2050-05-05' AS Date), CAST(N'2051-12-31' AS Date), 4, 1008, N'1005')
INSERT [dbo].[Prescription] ([PrescriptionId], [PrescriptionName], [PrescriptionStrength], [PrescriptionQuantity], [PrescriptionDirections], [WrittenDate], [ExpirationDate], [PrescriptionScheduleId], [PersonId], [DoctorsName]) VALUES (4, N'ambidont', N'60mg', N'999999', N'have weird dreams', CAST(N'2020-05-06' AS Date), CAST(N'2020-06-06' AS Date), 2, 1006, N'Dr. John Doe')
SET IDENTITY_INSERT [dbo].[Prescription] OFF
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'General Sales List')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Pharmacy Medicines')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Prescription Only Medicines')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Controlled Drugs')
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([AppointmentId], [AppointmentDate], [AppointmentTime], [AppointmentNotes], [DoctorsName], [PersonId]) VALUES (1020, CAST(N'2010-10-10' AS Date), CAST(N'22:10:00' AS Time), N'SUGURY', N'John Doe MD', 1005)
INSERT [dbo].[Appointments] ([AppointmentId], [AppointmentDate], [AppointmentTime], [AppointmentNotes], [DoctorsName], [PersonId]) VALUES (2019, CAST(N'2005-05-05' AS Date), CAST(N'17:00:00' AS Time), N'55555555', N'Dr. John', 1005)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[InventoryItem] ON 

INSERT [dbo].[InventoryItem] ([InventoryItemId], [InventoryItemCode], [InventoryItemName], [InventoryItemDescription], [InventoryItemPrice], [CategoryId]) VALUES (1005, N'123', N'Bandaid                                                                                             ', N'for wounds & injuries                                                                                                                                                                                                                                     ', CAST(10.00 AS Decimal(5, 2)), 1)
INSERT [dbo].[InventoryItem] ([InventoryItemId], [InventoryItemCode], [InventoryItemName], [InventoryItemDescription], [InventoryItemPrice], [CategoryId]) VALUES (2005, N'312', N'needles                                                                                             ', N'pointy                                                                                                                                                                                                                                                    ', CAST(150.00 AS Decimal(5, 2)), 2)
SET IDENTITY_INSERT [dbo].[InventoryItem] OFF
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Doctor')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Nurse')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'Patient')
GO
