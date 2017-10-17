CREATE TABLE [dbo].[Armour]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Category] VARCHAR(100) NOT NULL, 
    [Name] VARCHAR(100) NOT NULL, 
    [Price] INT NOT NULL, 
    [Picture_location] VARCHAR(1000) NOT NULL
)
