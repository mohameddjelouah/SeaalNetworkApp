CREATE PROCEDURE [dbo].[spInsertIntervention]
	

		
	@InterventionDate   DATETIME2,
	@DirectionId      int,
	@SiteId		    int,
	@IdentificationId			int,
	@EquipemenetId         int,
	@ActionId	    int,
	@Rapport		NVARCHAR (MAX),
	@AddBy			NVARCHAR (200)
AS
begin
	
	set nocount on 

	insert into dbo.Intervention(InterventionDate,DirectionId,SiteId,IdentificationId,EquipemenetId,ActionId,Rapport,AddBy) values(@InterventionDate,@DirectionId,@SiteId,@IdentificationId,@EquipemenetId,@ActionId,@Rapport,@AddBy);

end