CREATE PROCEDURE [dbo].[spGetSitesByDirectionId]

@directionID int

AS
begin
	set nocount on;
	SELECT Id,[site] from dbo.Site
	where directionID = @directionID ;
end
