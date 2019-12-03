CREATE PROCEDURE [dbo].[spEditIncident]



	@Id int ,
	@IncidentDate DATETIME2,
	@Direction NVARCHAR (MAX),
	@Site  NVARCHAR (MAX),
	@Nature  NVARCHAR (MAX),
	@Origin  NVARCHAR (MAX),
	@Operateur  NVARCHAR (MAX),
	@isClotured  BIT,
	@Solution  NVARCHAR (MAX),
	@ClotureDate  DATETIME2 ,
	@AddBy  NVARCHAR (MAX)
	AS
begin
	set nocount on;
	update Incidents set IncidentDate = @IncidentDate,Direction = @Direction,[Site] = @Site,Nature = @Nature,Origin = @Origin,Operateur = @Operateur,Solution = @Solution,ClotureDate = @ClotureDate,AddBy = @AddBy where Id = @Id;
end