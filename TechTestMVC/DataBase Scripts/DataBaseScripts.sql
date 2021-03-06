USE [TechTestMVC]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Admin', N'ADMIN', N'ADMINADMIN')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'Staff', N'STAFF', N'STAFFSTAFF')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3', N'Customer', N'CUSTOMER', N'CUSTOMERCUSTOMER')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Role]) VALUES (N'88ade222-96b5-46f8-a66f-2032151f4dc9', N'1@1.com', N'1@1.COM', N'1@1.com', N'1@1.COM', 1, N'AQAAAAEAACcQAAAAEN95NkE5/+XmmX2bO5ux0nhnz4Be3M0ZuIS6BzKoc8oXVVoqdG3p8zRnZFA4MAHD+g==', N'ECPE6XZWIIGBWKPJYNDQYRYJ7E47SJMK', N'6bf5b4af-25dc-4207-b1e1-681b962f6f1e', NULL, 0, 0, NULL, 1, 0, N'Admin')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Role]) VALUES (N'f420c776-3a91-4cc5-b5b7-d78da021c53d', N'2@2.com', N'2@2.COM', N'2@2.com', N'2@2.COM', 1, N'AQAAAAEAACcQAAAAECGlPLEpUw5tyQB+6d83gqSiqVlueUsbonG9NeYSwyq/DSQlW5NoZNWNljtgYwBx3w==', N'PP3AA4FDVFY7VPWQVIIZYBXEAZI7VANG', N'ae5e5073-0a53-4d4a-acd7-6da1b4246d95', NULL, 0, 0, NULL, 1, 0, N'Customer')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'88ade222-96b5-46f8-a66f-2032151f4dc9', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f420c776-3a91-4cc5-b5b7-d78da021c53d', N'3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200516142115_IdentityDb', N'3.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200516145337_IdentitySchema', N'3.0.0')
