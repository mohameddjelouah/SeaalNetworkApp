CREATE PROCEDURE [dbo].[spGettAllDirections]


AS
begin
	set nocount on;	
	SELECT * from  dbo.Direction ;
end
