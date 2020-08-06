CREATE PROCEDURE [dbo].[spInsertSiteEquipements]
	

	@Id				int,
	@SiteId		    int,
	@EquipementId		int,
	@EquipementHostname NVARCHAR (MAX),
	@EquipementIp       NVARCHAR (MAX)
	
AS
begin
	
	set nocount on 

	insert into dbo.SiteEquipements(SiteId,EquipementId,EquipementHostname,EquipementIp) values(@SiteId,@EquipementId,@EquipementHostname,@EquipementIp);

end