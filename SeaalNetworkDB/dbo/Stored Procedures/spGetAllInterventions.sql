CREATE PROCEDURE [dbo].[spGetAllInterventions]
	


	AS
begin
	set nocount on;
	SELECT intervention.*,dir.*,sit.*,ide.*,eq.*,act.* from dbo.Intervention intervention

	 LEFT JOIN dbo.Direction dir ON intervention.DirectionId = dir.Id
	 LEFT JOIN dbo.Site sit ON intervention.SiteId = sit.Id
	 LEFT JOIN dbo.Identification ide ON intervention.IdentificationId = ide.Id
	 LEFT JOIN dbo.Equipement eq ON intervention.EquipemenetId = eq.Id
	 LEFT JOIN dbo.Action act ON intervention.ActionId = act.Id
	
	
	
end