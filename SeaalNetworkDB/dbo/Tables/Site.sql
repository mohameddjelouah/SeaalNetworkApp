﻿CREATE TABLE [dbo].[Site]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [directionID] INT NOT NULL, 
    [site] NVARCHAR(MAX) NOT NULL
)