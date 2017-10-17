CREATE TABLE [dbo].[Ninja_equipment]
(
	[NinjaId]  INT NOT NULL , 
    [ArmourId] INT NOT NULL, 
    [Strength] INT NOT NULL, 
    [Intelligence] INT NOT NULL, 
    [Agility] INT NOT NULL, 
    CONSTRAINT [ArmourId] FOREIGN KEY ([ArmourId]) REFERENCES [Armour]([Id]), 
    CONSTRAINT [NinjaId] FOREIGN KEY ([NinjaId]) REFERENCES [Ninja]([Id]), 
    PRIMARY KEY ([ArmourId], [NinjaId]) 
)
