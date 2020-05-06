CREATE PROCEDURE [dbo].[spGetActions]


AS
begin
	set nocount on;
	SELECT * from dbo.Action;
end