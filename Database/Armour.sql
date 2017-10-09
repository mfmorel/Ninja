CREATE TABLE [dbo].[Armour]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Category] NCHAR(10) NULL, 
    [Strength] INT NULL, 
    [Intelligence] INT NULL, 
    [Agility] INT NULL, 
    [Name] NCHAR(100) NULL, 
    [Price] INT NULL, 
    [Picture_location] NCHAR(200) NULL
)
