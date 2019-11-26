CREATE PROCEDURE [dbo].[spGettAllDirections]


AS
begin
	set nocount on;	
	SELECT d.*,s.* from  dbo.Direction d INNER JOIN dbo.[Site] s ON d.Id = s.directionID;
end
