CREATE TABLE [dbo].[Incidents]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IncidentDate] DATETIME2 NOT NULL, 
    [Direction] NVARCHAR(100) NOT NULL, 
    [Site] NVARCHAR(200) NOT NULL, 
    [Nature] NVARCHAR(2000) NOT NULL, 
    [Operateur] NVARCHAR(50) NOT NULL,
	[isClotured] INT NOT NULL,
    [Solution] NVARCHAR(MAX) NULL, 
    [ClotureDate] DATETIME2 NULL, 
    [AddBy] NVARCHAR(200) NOT NULL, 
    
)
