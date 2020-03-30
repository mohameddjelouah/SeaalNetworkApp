CREATE PROCEDURE [dbo].[spGettAllDirections]


AS
begin
	set nocount on;	
	SELECT * from  dbo.Direction AS A INNER JOIN dbo.Site AS B ON A.Id = B.DirectionID ;
end
