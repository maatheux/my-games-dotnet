CREATE DATABASE [MyGames]
GO

USE [MyGames]
GO


CREATE TABLE [Publisher] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(80) NOT NULL,
    [Country] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Publisher] PRIMARY KEY([Id])
)


CREATE TABLE [Game] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(80) NOT NULL,
    [Description] TEXT NOT NULL,
    [Release] DATE NOT NULL,
    [Rating] INT NOT NULL,
    [FavoriteFlag] BIT NOT NULL,
    [WishlistFlag] BIT NOT NULL,
    [PublisherId] INT NOT NULL,

    CONSTRAINT [PK_Game] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Game_Publisher] FOREIGN KEY([PublisherId]) REFERENCES [Publisher]([Id]) 
)


CREATE TABLE [Category] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Category] PRIMARY KEY([Id])
)


CREATE TABLE [GameCategory] (
    [GameId] INT NOT NULL,
    [CategoryId] INT NOT NULL,

    CONSTRAINT [PK_Game_Category] PRIMARY KEY([GameId], [CategoryId])
)


CREATE TABLE [Company] (
    [Id] INT NOT NULL,
    [Name] NVARCHAR(80) NOT NULL,
    [Ceo] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Company] PRIMARY KEY ([Id])
)


CREATE TABLE [Plataforms] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(80) NOT NULL,
    [IdCompanyOwner] INT NOT NULL,

    CONSTRAINT [PK_Post] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Platform_Company] FOREIGN KEY([IdCompanyOwner]) REFERENCES [Company]([Id]),
)

CREATE TABLE [GamePlatform] (
    [GameId] INT NOT NULL,
    [PlatformId] INT NOT NULL,

    CONSTRAINT [PK_GameCategory] PRIMARY KEY([GameId], [PlatformId])
)
