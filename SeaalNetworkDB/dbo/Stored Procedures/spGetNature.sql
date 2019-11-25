CREATE PROCEDURE [dbo].[spGetNature]


AS
begin
	set nocount on;
	SELECT * from dbo.Nature;
end