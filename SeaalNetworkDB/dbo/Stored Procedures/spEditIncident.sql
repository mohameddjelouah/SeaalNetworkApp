CREATE PROCEDURE [dbo].[spEditIncident]



	@Id int ,
	@IncidentDate DATETIME2,
	@Direction int,
	@Site  int,
	@Nature  int,
	@Origin  int,
	@Operateur  int,
	@isClotured  BIT,
	@Solution  NVARCHAR (MAX),
	@ClotureDate  DATETIME2 ,
	@AddBy  NVARCHAR (MAX)
	AS
begin
	set nocount on;
	update Incidents set IncidentDate = @IncidentDate,DirectionId = @Direction,SiteId = @Site,NatureId = @Nature,OriginId = @Origin,OperateurId = @Operateur,isClotured=@isClotured,Solution = @Solution,ClotureDate = @ClotureDate,AddBy = @AddBy where Id = @Id;
end