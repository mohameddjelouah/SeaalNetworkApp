CREATE TABLE [dbo].[Incidents]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IncidentDate] DATETIME2 NOT NULL, 
    [DirectionId] INT NOT NULL, 
    [SiteId] INT NOT NULL, 
    [NatureId] INT NOT NULL, 
    [OriginId] INT NOT NULL, 
    [OperateurId] INT NULL,
	[isClotured] BIT NOT NULL DEFAULT 1,
    [Solution] NVARCHAR(MAX) NULL, 
    [ClotureDate] DATETIME2 NULL, 
    [AddBy] NVARCHAR(MAX) NOT NULL,
    CONSTRAINT [FK_incident_ToDirection] FOREIGN KEY ([DirectionId]) REFERENCES Direction(Id) On DELETE CASCADE
    
    
    
    
)
