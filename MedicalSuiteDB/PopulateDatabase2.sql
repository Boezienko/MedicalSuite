INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'General Sales List')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Pharmacy Medicines')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Prescirption Only Medicines')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Controlled Drugs')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Patient')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Nurse')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'Doctor')
GO
SET IDENTITY_INSERT [dbo].[Person] ON 
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1005, N'John', N'Doe', N'DrJohnDoe@gmail.com', N'$2a$13$JvGD/9wX6eNItgu7L1XcrOWXop9i9gm7eP3.dqtuyHD1wyILcdMLW', CAST(N'2024-05-01T12:32:06.000' AS DateTime), NULL, 1, N'1234567890')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1006, N'gage', N'kolojaco', N'gk@gmail.com', N'$2a$13$PjqDySHkCGaVqmS7UpjwoevZ6tzCml70JPKxvTe0do4dWPkzCeUay', CAST(N'2024-05-01T12:36:28.690' AS DateTime), NULL, 3, N'1234567890')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1007, N'Boe', N'Zienko', N'bz@gmail.com', N'$2a$13$5IpwXgLdHEO09RssgFsRm.Apl04c5NMWA4nz3rpY46GVa9aCDlQAu', CAST(N'2024-05-01T12:34:01.000' AS DateTime), NULL, 3, N'1234567890')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1008, N'Oreoluwa', N'Oladele-Ajose', N'oo@gmail.com', N'$2a$13$hk7SYew24yMm/JPRjNNsBOx82ju3hbhJTyfKYYHUUbmk..EGKyDMS', CAST(N'2024-05-01T12:35:12.000' AS DateTime), NULL, 3, N'1234567890')
GO
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [PasswordHash], [LastLoginTime], [PrescriptionId], [RoleId], [Telephone]) VALUES (1009, N'Jo''Hannah', N'Proctor', N'jp@gmail.com', N'$2a$13$JnWBON2FiKTnziI3EyvUyu7EdxwcLhZDE78Rux48Ign/EE7czaxpK', CAST(N'2024-05-01T12:38:14.000' AS DateTime), NULL, 3, N'1234567890')
GO
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
