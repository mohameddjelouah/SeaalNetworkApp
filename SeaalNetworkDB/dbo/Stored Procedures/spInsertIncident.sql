CREATE PROCEDURE [dbo].[spInsertIncident]
	@Id int,	
	@IncidentDate   DATETIME2,
	@Direction      NVARCHAR(MAX),
	@Site		    NVARCHAR(MAX),
	@Nature			NVARCHAR(MAX),
	@Origin         NVARCHAR(MAX),
	@Operateur	    NVARCHAR(MAX),
	@isClotured		BIT,
	@Solution		NVARCHAR (MAX),
	@ClotureDate	DATETIME2,
	@AddBy			NVARCHAR (200)
AS
begin
	
	set nocount on 

	insert into dbo.Incidents(IncidentDate,Direction,[Site],Nature,Origin,Operateur,isClotured,Solution,ClotureDate,AddBy) values(@IncidentDate,@Direction,@Site,@Nature,@Origin,@Operateur,@isClotured,@Solution,@ClotureDate,@AddBy);

end
	
