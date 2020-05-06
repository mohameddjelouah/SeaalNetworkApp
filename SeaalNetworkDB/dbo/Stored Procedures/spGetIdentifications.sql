CREATE PROCEDURE [dbo].[spGetIdentifications]


AS
begin
	set nocount on;
	SELECT * from dbo.Identification;
end