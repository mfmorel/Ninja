CREATE TABLE [dbo].[Ninja_equipment]
(
	[NinjaName] VARCHAR(100) NOT NULL PRIMARY KEY, 
    [ArmourID] INT NOT NULL, 
    CONSTRAINT [ArmourID] FOREIGN KEY ([ArmourID]) REFERENCES [Armour]([ID]), 
    CONSTRAINT [NinjaName] FOREIGN KEY ([NinjaName]) REFERENCES [Ninja]([Name]) 
)
