CREATE TABLE [dbo].[FullSite]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DirectionId] INT NOT NULL, 
    [SiteId] INT NOT NULL, 
    [Address] NVARCHAR(MAX) NOT NULL, 
    [Mask] NVARCHAR(MAX) NOT NULL, 
    [DhcpId] INT NOT NULL
)
