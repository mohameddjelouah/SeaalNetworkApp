CREATE PROCEDURE [dbo].[spInsertSiteDetail]


	@Id				int,
	@DirectionId   int,
	@SiteId		    int,
	@Address		NVARCHAR (MAX),
	@Mask			NVARCHAR (MAX),
	@DhcpId		    int
	
AS
begin
	
	set nocount on 

	insert into dbo.FullSite(DirectionId,SiteId,[Address],Mask,DhcpId) values(@DirectionId,@SiteId,@Address,@Mask,@DhcpId);

	select  SCOPE_IDENTITY() as Id;

end