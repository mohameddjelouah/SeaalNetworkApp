CREATE PROCEDURE [dbo].[spGetIncidentById]
	@Id int 
	
AS
begin
	set nocount on;
	SELECT * from dbo.Incidents
	where Id = @Id ;
end
