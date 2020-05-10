CREATE PROCEDURE [dbo].[spEditIntervention]
	

	@Id int,
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
	set nocount on;
	update Intervention set InterventionDate = @InterventionDate,DirectionId = @DirectionId,SiteId = @SiteId,IdentificationId = @IdentificationId,EquipemenetId = @EquipemenetId,ActionId = @ActionId,Rapport = @Rapport,AddBy = @AddBy where Id = @Id;
end