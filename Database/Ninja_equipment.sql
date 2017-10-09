CREATE TABLE [dbo].[Ninja_equipment]
(
	[NinjaID] INT NOT NULL PRIMARY KEY, 
    [ArmourID] INT NOT NULL, 
    CONSTRAINT [NinjaID] FOREIGN KEY ([NinjaID]) REFERENCES [Ninja](ID), 
    CONSTRAINT [ArmourID] FOREIGN KEY ([ArmourID]) REFERENCES [Armour]([ID]) 
)
