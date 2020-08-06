CREATE PROCEDURE [dbo].[spGetAllSiteOrerateur]


	@Id int
AS
begin
	set nocount on;
	SELECT siteOp.*,op.* from dbo.SiteOperateurs siteOp

	 LEFT JOIN dbo.Operateur op ON siteOp.OperateurId = op.Id
	 
	
	
	where SiteId = @Id ;
end