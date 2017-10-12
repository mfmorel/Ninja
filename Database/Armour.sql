CREATE TABLE [dbo].[Armour]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Category] NCHAR(10) NOT NULL, 
    [Strength] INT NOT NULL, 
    [Intelligence] INT NOT NULL, 
    [Agility] INT NOT NULL, 
    [Name] NCHAR(100) NOT NULL, 
    [Price] INT NOT NULL, 
    [Picture_location] NCHAR(200) NOT NULL
)
