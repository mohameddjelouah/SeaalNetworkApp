CREATE PROCEDURE [dbo].[spGetAllIncidents]
	@isClotured bit
AS
begin
	set nocount on;
	SELECT * from dbo.Incidents where isClotured = @isClotured ;
end
