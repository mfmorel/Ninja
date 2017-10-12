CREATE TABLE [dbo].[Ninja_equipment]
(
	[NinjaId]  INT NOT NULL PRIMARY KEY, 
    [ArmourId] INT NOT NULL, 
    CONSTRAINT [ArmourId] FOREIGN KEY ([ArmourId]) REFERENCES [Armour]([Id]), 
    CONSTRAINT [NinjaId] FOREIGN KEY ([NinjaId]) REFERENCES [Ninja]([Id]) 
)
