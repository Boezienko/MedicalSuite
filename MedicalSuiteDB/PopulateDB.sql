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
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (1, N'Analgesic')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (2, N'Antacids')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (3, N'Antianxiety ')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (4, N'Antiarrhythmic')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (5, N'Antibacterial')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (6, N'Antibiotic')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (7, N'Anticoagulant')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (8, N'Thrombolytic')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (9, N'Anticonvulsant')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (10, N'Antidepressant')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (11, N'Antidiarrheal')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (12, N'Antiemetics')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (13, N'Antifungals')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (14, N'Antihistamine')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (15, N'Antihypertensives')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (16, N'Anti-Inflammatory')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (17, N'Antineoplastic')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (18, N'Antipsychotic')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (19, N'Antipyretic')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (20, N'Antiviral')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (21, N'Barbiturate')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (22, N'Beta-Blocker')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (23, N'Bronchodilator')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (24, N'Cold Cure')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (25, N'Corticosteroid')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (26, N'Cough Suppressant')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (27, N'Cytotoxic')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (28, N'Decongestant')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (29, N'Diuretic')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (30, N'Expectorant')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (31, N'Hormone')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (32, N'Hypoglycemic (Oral)')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (33, N'Immunosuppressant')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (34, N'Laxative')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (35, N'Muscle Relaxant')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (36, N'Sex Hormone')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (37, N'Tranquilizer')
INSERT [dbo].[PrescriptionSchedule] ([PrescriptionScheduleId], [PrescriptionSchedules]) VALUES (38, N'Vitamin')
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1005, N'John', N'Doe', N'DrJohnDoe@gmail.com', N'$2a$13$JvGD/9wX6eNItgu7L1XcrOWXop9i9gm7eP3.dqtuyHD1wyILcdMLW', CAST(N'2024-05-07T11:23:02.813' AS DateTime), NULL, 1, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1006, N'gage', N'kolojaco', N'gk@gmail.com', N'$2a$13$PjqDySHkCGaVqmS7UpjwoevZ6tzCml70JPKxvTe0do4dWPkzCeUay', CAST(N'2024-05-05T20:30:51.173' AS DateTime), NULL, 3, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1007, N'Boe', N'Zienko', N'bz@gmail.com', N'$2a$13$5IpwXgLdHEO09RssgFsRm.Apl04c5NMWA4nz3rpY46GVa9aCDlQAu', CAST(N'2024-05-01T12:34:01.000' AS DateTime), NULL, 3, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1008, N'Oreoluwa', N'Oladele-Ajose', N'oo@gmail.com', N'$2a$13$hk7SYew24yMm/JPRjNNsBOx82ju3hbhJTyfKYYHUUbmk..EGKyDMS', CAST(N'2024-05-01T12:35:12.000' AS DateTime), NULL, 3, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1009, N'Jo''Hannah', N'Proctor', N'jp@gmail.com', N'$2a$13$JnWBON2FiKTnziI3EyvUyu7EdxwcLhZDE78Rux48Ign/EE7czaxpK', CAST(N'2024-05-01T13:05:30.987' AS DateTime), NULL, 2, N'1234567890')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1010, N'Jeff', N'Zheng', N'jz@gmail.com', N'$2a$13$T0NxJbvk/IuFuZyK0M/qA.xAEIACFIhmnTOkFpny0yVzA/JpA8VEm', CAST(N'2024-05-01T13:38:21.613' AS DateTime), NULL, 3, N'1234567890')
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'General Sales List')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Pharmacy Medicines')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Prescription Only Medicines')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Controlled Drugs')
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([AppointmentId], [AppointmentDate], [AppointmentTime], [AppointmentNotes], [DoctorsName], [PersonId]) VALUES (2019, CAST(N'2005-05-05' AS Date), CAST(N'17:00:00' AS Time), N'55555555', N'Dr. John', 1005)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[InventoryItem] ON 

INSERT [dbo].[InventoryItem] ([InventoryItemId], [InventoryItemCode], [InventoryItemName], [InventoryItemDescription], [InventoryItemPrice], [CategoryId]) VALUES (1005, N'123', N'Bandaid                                                                                             ', N'for wounds & injuries                                                                                                                                                                                                                                     ', CAST(10.00 AS Decimal(5, 2)), 1)
INSERT [dbo].[InventoryItem] ([InventoryItemId], [InventoryItemCode], [InventoryItemName], [InventoryItemDescription], [InventoryItemPrice], [CategoryId]) VALUES (2005, N'312', N'needles                                                                                             ', N'pointy                                                                                                                                                                                                                                                    ', CAST(150.00 AS Decimal(5, 2)), 2)
INSERT [dbo].[InventoryItem] ([InventoryItemId], [InventoryItemCode], [InventoryItemName], [InventoryItemDescription], [InventoryItemPrice], [CategoryId]) VALUES (3005, N'12345', N'Sutures                                                                                             ', N'for surguries and surgeries                                                                                                                                                                                                                               ', CAST(20.00 AS Decimal(5, 2)), 3)
SET IDENTITY_INSERT [dbo].[InventoryItem] OFF
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Doctor')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Nurse')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'Patient')
GO
