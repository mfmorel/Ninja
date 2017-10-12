CREATE TABLE [dbo].[Ninja]
(
	[Id]   INT IDENTITY(1,1) NOT NULL,
    [Name] VARCHAR(100) NOT NULL, 
    [Gold] INT NOT NULL, 
    [Head] INT NULL, 
    [Shoulder] INT NULL, 
    [Chest] INT NULL, 
    [Belt] INT NULL, 
    [Legs] INT NULL, 
    [Boots] INT NULL, 
    CONSTRAINT [PK_Ninja] PRIMARY KEY ([Id])
)
