CREATE PROCEDURE [dbo].[spGetAllSiteEquipement]
	

		@Id int
AS
begin
	set nocount on;
	SELECT siteEq.*,eq.* from dbo.SiteEquipements siteEq

	 LEFT JOIN dbo.Equipement eq ON siteEq.EquipementId = eq.Id
	 
	
	
	where SiteId = @Id ;
end

