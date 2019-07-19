CREATE PROCEDURE [dbo].[spInsertIncident]
	@Id int,	
	@IncidentDate   DATETIME2,
	@Direction      NVARCHAR (100),
	@Site		    NVARCHAR (200),
	@Nature			NVARCHAR (2000),
	@Operateur	    NVARCHAR (50),
	@isClotured		BIT,
	@Solution		NVARCHAR (MAX),
	@ClotureDate	DATETIME2,
	@AddBy			NVARCHAR (200)
AS
begin
	
	set nocount on 

	insert into dbo.Incidents(IncidentDate,Direction,[Site],Nature,Operateur,isClotured,Solution,ClotureDate,AddBy) values(@IncidentDate,@Direction,@Site,@Nature,@Operateur,@isClotured,@Solution,@ClotureDate,@AddBy);

end
	
