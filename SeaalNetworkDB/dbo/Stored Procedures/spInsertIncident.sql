CREATE PROCEDURE [dbo].[spInsertIncident]
	@Id int,	
	@IncidentDate   DATETIME2,
	@Direction      int,
	@Site		    int,
	@Nature			int,
	@Origin         int,
	@Operateur	    int,
	@isClotured		BIT,
	@Solution		NVARCHAR (MAX),
	@ClotureDate	DATETIME2,
	@AddBy			NVARCHAR (200)
AS
begin
	
	set nocount on 

	insert into dbo.Incidents(IncidentDate,DirectionId,SiteId,NatureId,OriginId,OperateurId,isClotured,Solution,ClotureDate,AddBy) values(@IncidentDate,@Direction,@Site,@Nature,@Origin,@Operateur,@isClotured,@Solution,@ClotureDate,@AddBy);

end
	
