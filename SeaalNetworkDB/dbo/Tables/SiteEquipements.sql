CREATE TABLE [dbo].[SiteEquipements]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SiteId] INT NOT NULL, 
    [EquipementId] INT NOT NULL, 
    [EquipementHostname] NVARCHAR(MAX) NOT NULL, 
    [EquipementIp] NVARCHAR(MAX) NOT NULL
)
