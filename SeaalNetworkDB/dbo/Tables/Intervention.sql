CREATE TABLE [dbo].[Intervention]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InterventionDate] DATETIME2 NOT NULL, 
    [DirectionId] INT NOT NULL, 
    [SiteId] INT NOT NULL, 
    [IdentificationId] INT NOT NULL, 
    [EquipemenetId] INT NOT NULL, 
    [ActionId] INT NOT NULL, 
    [Rapport] NVARCHAR(MAX) NOT NULL,
)
