CREATE TABLE [dbo].[Incidents]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IncidentDate] DATETIME2 NOT NULL, 
    [Direction] NVARCHAR(MAX) NOT NULL, 
    [Site] NVARCHAR(MAX) NOT NULL, 
    [Nature] NVARCHAR(MAX) NOT NULL, 
    [Origin] NVARCHAR(MAX) NOT NULL, 
    [Operateur] NVARCHAR(MAX) NULL,
	[isClotured] BIT NOT NULL DEFAULT 1,
    [Solution] NVARCHAR(MAX) NULL, 
    [ClotureDate] DATETIME2 NULL, 
    [AddBy] NVARCHAR(200) NOT NULL, 
    
)
