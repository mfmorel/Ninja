CREATE TABLE [dbo].[Armour]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Category] VARCHAR(100) NOT NULL, 
    [Strength] INT NOT NULL, 
    [Intelligence] INT NOT NULL, 
    [Agility] INT NOT NULL, 
    [Name] VARCHAR(100) NOT NULL, 
    [Price] INT NOT NULL, 
    [Picture_location] VARCHAR(100) NOT NULL
)
