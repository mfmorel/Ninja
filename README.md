# Ninja
Prog5 Ninja

# Introductie
Voor de opdracht ga je een Ninja app maken voor een
MOBA (Multiplayer Online Battle Arena). De nadruk bij
deze opdracht ligt op de interne kwaliteit en de architectuur
van de applicatie. De user interface is deze keer van
ondergeschikt belang. De concepten die tijdens de
workshops aan bod zijn gekomen zoals MVVM, Entity
framework en WPF dienen allemaal terug te komen in de te
bouwen applicatie, zie voor de gedetailleerde eisen
hiervoor ook de paragraaf Rubric. De applicatie moet
minstens voldoen aan de Knockout criteria.

# Context
Je bent gevraagd om voor een game studio een App te ontwikkelen waarmee gebruikers een lijst van
equipment kunnen beheren en deze toevoegen aan de inventory van een Ninja kunnen samenstellen.
De verschillende equipment onderdelen hebben een aantal eigenschappen (stats) en een bijbehorende
prijs (in gold). De gebruiker kan via je app bepalen wat de beste aankoop is bij een bepaald bedrag en
kijken wat de volledige stats zijn van de Ninja, als er equipement is aangeschaft. 

# Assesment
In week 10 komen jullie langs om jullie applicatie aan ons te presenteren. Bereid deze presentatie goed
voor. Je moet zelf onderbouwen welke onderdelen er zijn opgeleverd. Beide studenten moeten in staat
zijn om alle code uit te leggen. Is dit niet het geval, dan ontvangt de student die een onderdeel niet kan
uitleggen een 1. Als er onderdelen in de applicatie zitten die niet onderbouwd kunnen worden (of op de
juiste manier uitgelegd) dan worden er voor dit onderdeel geen punten uitgedeeld. 

# Functionele eisen

# Ninja
1. Het moet mogelijk zijn nieuwe ninjas toe te voegen, wijzigen en verwijderen (crud).
2. De ninja heeft een naam
3. De ninja heeft een hoeveelheid goud om equipment te kopen.
4. Het moet mogelijk zijn de inventory van de ninja leeg te maken. De gebruiker begint dan met een
naakte ninja. (En krijgt zijn geld terug).

# Equipment
5. Het moet mogelijk zijn nieuwe equipment toe te voegen, wijzigen en verwijderen (crud).
6. Per categorie moeten er minstens 3 verschillende equipment aanwezig zijn.
7. Equipment bevat minstens een van de volgende eigenschappen:
  ? Waarde in goud
  ? Een categorie [0]
  ? Hoeveelheid strength (rood)
  ? Hoeveelheid intelligence (blauw)
  ? Hoeveelheid agility (geel)
  
De categorieën zijn: Head, Shoulders, Chest, Belt, Legs, Boots

# Inventory van de Ninja

1. Het moet mogelijk zijn om een categorie te selecteren, en een van de bijbehorende equipment aan
de inventory van de ninja toe te voegen.
a. Het is niet mogelijk om equipment aan de inventory van de ninja toe te voegen indien deze
meer waard is dan de ninja nog aan goud over heeft.
2. De ninja mag maar 1 equipment van een bepaalde categorie hebben. Het is bijvoorbeeld niet
mogelijk om 2 chests aan de ninja toe te voegen .
3. Het moet mogelijk zijn om een equipment van een ninja te verwijderen. (verkopen)
a. Hij krijg dan het geld terug van de equipment.
4. Laat zien wat de opgetelde waarde is van de totale hoeveelheid strength van zijn inventory
5. Laat zien wat de opgetelde waarde is van de totale hoeveelheid intelligence van de inventory
6. Laat zien wat de opgetelde waarde is van de totale hoeveelheid agility van de inventory

# Tips

Het enablen en disablen van buttons kan problemen opleveren. Wil dit niet lukken, sla dit onderdeel dan
over. Lukt het wel, dan levert dit extra punten op!
Je kan het werk verdelen maar aangezien je het werk allebei moet kunnen uitleggen is het verstandig om
samen bepaalde onderdelen uit te werken.
Ga voor het assessment met elkaar rond de tafel zitten om alle onderdelen van de applicatie nog een
keer te bespreken. 

# Rubric (afvinklijst)
Als je alle knockout criteria hebt behaald krijg je al het cijfer 4. De rest van de punten ontvang je bij het
behalen van de overige criteria. 

# KO
[X]  Het moet mogelijk zijn om Ninjas te beheren (CRUD)

[X]  Het moet mogelijk zijn om Equipment te beheren (CRUD)

[X]  Het moet mogelijk zijn om Equipment te koppelen aan een Ninja

[X]  Er staat geen code in de 'code behind' file

[X]  De applicatie is gebouwd in WPF

[X]  De data in de applicatie word opgeslagen in een database

# Functioneel
[ ]  Als gebruiker wil ik dat ik validatiemeldingen zie als ik foute (of geen) gegevens invul

[X]  Als gebruiker wil ik dat er voor elk onderdeel in de applicatie een apart scherm is

[X]  Als gebruiker wil ik dat ik alle inventory van een ninja in 1 keer kan verkopen

[X]  Als gebruiker wil ik bij mijn ninja zijn totale stats (agility, strength, etc) kunnen zien. 

# WPF
[ ]  Als gebruiker wil ik dat buttons op de juiste manier en het juiste moment enabled of disabled zijn.

[ ]  Als architect wil ik dat er naast Relay commands ook gebruik gemaakt is van normale Commands

[ ]  Als architect wil ik dat er gebruik word gemaakt van Value converters (denk zelf na hoe)

# MvvM
[X]  Als architect wil ik dat er gebruik is gemaakt van meerdere view models

[X]  Als architect wil ik dat wijzigingen in 1 window meteen zichtbaar zijn in eventuele andere windows

[X]  Als architect wil ik dat het aanmaken van View Models netjes via de View Model Locator gaat

# Entity Framework
[ ]  Als datamanager wil ik dat er een database project aanwezig is met alle tabellen

[ ]  Als data architect wil ik dat de relatie tussen een Ninja en Gear een veel op veel relatie is

[ ]  Als datamanager wil ik dat er een Seed script aanwezig is met initiële test data

# Technisce eisen
[ ]  Als ontwikkelaar wil ik dat de code verder netjes OO is.

[ ]  Als Gebruiker wil ik dat de applicatie geen errors bevat (0 errors = 10 punten, 5+ errors = 0 punten)

# Extra
[ ]  Er is een extra klasse die verantwoordelijk is voor het aanmaken van schermen (router)

[X]  Visuele weergave van de ninja en zijn gear (meer dan alleen een lijst van equipment)

[ ]  Maak de categoriën die selecteer baar zijn ook mogelijk

[X]  Equipment is uitgebreid met een afbeelding

[ ]  Losse bonus punten
