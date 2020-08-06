CREATE PROCEDURE [dbo].[spGetAllSitesDetail]
	

	AS
begin
	set nocount on;

	SELECT fullsite.*,dir.*,sit.*,dhc.* from dbo.FullSite fullsite

	 LEFT JOIN dbo.Direction dir ON fullsite.DirectionId = dir.Id
	 LEFT JOIN dbo.[Site] sit ON fullsite.SiteId = sit.Id
	 LEFT JOIN dbo.[Dhcp] dhc ON fullsite.DhcpId = dhc.Id
	 
	
end