/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Ninja (Name, Gold)
VALUES ('Dharok the Wretched', 350)

INSERT INTO Ninja (Name, Gold)
VALUES ('Guthan the Infested', 5000)

INSERT INTO Ninja (Name, Gold)
VALUES ('Torag the Corrupted', 800)

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Head', 'Dharoks helm', 35, '\Resources\Images\Dharoks helm.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Head', 'Torags helm', 80, '\Resources\Images\Torags helm.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Head', 'Guthans helm', 63, '\Resources\Images\Guthans helm.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Chest', 'Dharoks platebody', 35, '\Resources\Images\Dharoks platebody.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Chest', 'Torags platebody', 80, '\Resources\Images\Torags platebody.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Chest', 'Guthans platebody', 63, '\Resources\Images\Guthans platebody.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Legs', 'Dharoks platelegs', 35, '\Resources\Images\Dharoks platelegs.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Legs', 'Torags platelegs', 80, '\Resources\Images\Torags platelegs.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Legs', 'Guthans chainskirt', 63, '\Resources\Images\Guthans chainskirt.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Belt', 'Plated belt', 35, '\Resources\Images\Plated belt.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Belt', 'Belt', 80, '\Resources\Images\Belt.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Belt', 'Double belt', 63, '\Resources\Images\Double belt.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Boots', 'Chicken feet', 35, '\Resources\Images\Chicken feet.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Boots', 'Silly jester boots', 80, '\Resources\Images\Silly jester boots.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Boots', 'Fancy boots', 63, '\Resources\Images\Fancy boots.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Shoulder', 'Ailettes', 35, '\Resources\Images\Ailettes.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Shoulder', 'Mountain of the light', 80, '\Resources\Images\Mountain of the light.png')

INSERT INTO Armour(Category, Name, Price, Picture_location)
VALUES ('Shoulder', 'Vyrs proud pauldrons', 63, '\Resources\Images\Vyrs proud pauldrons.png')