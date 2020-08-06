CREATE PROCEDURE [dbo].[spInsertSiteOperateurs]
	

	@Id				int,
	@SiteId		    int,
	@OperateurId	int
	
	
AS
begin
	
	set nocount on 

	insert into dbo.SiteOperateurs(SiteId,OperateurId) values(@SiteId,@OperateurId);

end