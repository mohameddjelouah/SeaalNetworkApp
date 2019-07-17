CREATE PROCEDURE [dbo].[spGetAllIncidents]
	
AS
begin
	set nocount on;
	SELECT * from dbo.Incidents;
end
