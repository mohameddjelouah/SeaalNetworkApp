CREATE PROCEDURE [dbo].[spGetAllIncidents]
	@isClotured bit
AS
begin
	set nocount on;
	SELECT inc.*,dir.*,sit.*,nat.*,ori.*,ope.* from dbo.Incidents inc

	 LEFT JOIN dbo.Direction dir ON inc.DirectionId = dir.Id
	 LEFT JOIN dbo.Site sit ON inc.SiteId = sit.Id
	 LEFT JOIN dbo.Nature nat ON inc.NatureId = nat.Id
	 LEFT JOIN dbo.Origin ori ON inc.OriginId = ori.Id
	 LEFT JOIN dbo.Operateur ope ON inc.OperateurId = ope.Id
	
	
	where isClotured = @isClotured ;
end
