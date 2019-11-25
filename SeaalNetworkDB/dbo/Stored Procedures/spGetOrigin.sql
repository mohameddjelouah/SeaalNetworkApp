CREATE PROCEDURE [dbo].[spGetOrigin]
	
	AS
begin
	set nocount on;
	SELECT * from dbo.Origin;
end