
-- To create table Product

CREATE TABLE [dbo].[Products] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [ProductID]   VARCHAR (10) NOT NULL,
    [ProductName] VARCHAR (50) NOT NULL,
    [Quantity]    INT          NOT NULL,
    [DateCreated] DATETIME     DEFAULT (getdate()) NOT NULL,
    [DateUpdate]  DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_Product] UNIQUE NONCLUSTERED ([Id] ASC, [ProductID] ASC)
);


-- To add sample data to Product Table

SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([Id], [ProductID], [ProductName], [Quantity], [DateCreated], [DateUpdate]) VALUES (1, N'SM-N975', N'Samsung Galaxy Note 10 Plus', 10, N'2022-04-09 18:09:17', NULL)
INSERT INTO [dbo].[Products] ([Id], [ProductID], [ProductName], [Quantity], [DateCreated], [DateUpdate]) VALUES (2, N'SM-G996', N'Samsung Galaxy S21 Plus', 5, N'2022-04-09 18:10:40', NULL)
INSERT INTO [dbo].[Products] ([Id], [ProductID], [ProductName], [Quantity], [DateCreated], [DateUpdate]) VALUES (3, N'SM-G985', N'Samsung Galaxy S20 Plus', 8, N'2022-04-09 18:11:15', NULL)
INSERT INTO [dbo].[Products] ([Id], [ProductID], [ProductName], [Quantity], [DateCreated], [DateUpdate]) VALUES (4, N'A1661', N'iPhone 7', 12, N'2022-04-09 18:11:48', NULL)
INSERT INTO [dbo].[Products] ([Id], [ProductID], [ProductName], [Quantity], [DateCreated], [DateUpdate]) VALUES (5, N'A1784 ', N'iPhone 7 Plus', 7, N'2022-04-09 18:12:16', NULL)
INSERT INTO [dbo].[Products] ([Id], [ProductID], [ProductName], [Quantity], [DateCreated], [DateUpdate]) VALUES (6, N'A1865', N'iPhone X', 8, N'2022-04-09 18:12:45', NULL)
INSERT INTO [dbo].[Products] ([Id], [ProductID], [ProductName], [Quantity], [DateCreated], [DateUpdate]) VALUES (7, N'A1897', N'iPhone 8 Plus', 2, N'2022-04-09 18:13:02', NULL)
INSERT INTO [dbo].[Products] ([Id], [ProductID], [ProductName], [Quantity], [DateCreated], [DateUpdate]) VALUES (9, N'SM-G998', N'Samsung Galaxy S21 Ultra', 10, N'2022-04-10 12:36:03', N'2022-04-10 12:51:25')
INSERT INTO [dbo].[Products] ([Id], [ProductID], [ProductName], [Quantity], [DateCreated], [DateUpdate]) VALUES (10, N'SM-S908', N'Samsung Galaxy S22 Ultra', 10, N'2022-04-10 12:38:09', NULL)
INSERT INTO [dbo].[Products] ([Id], [ProductID], [ProductName], [Quantity], [DateCreated], [DateUpdate]) VALUES (11, N'SM-S915', N'Samsung Galaxy S22 Ultra 5G', 6, N'2022-04-10 13:19:29', NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
