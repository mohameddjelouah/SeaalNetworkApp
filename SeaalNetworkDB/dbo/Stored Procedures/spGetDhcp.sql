CREATE PROCEDURE [dbo].[spGetDhcp]
	

	
	AS
begin
	set nocount on;
	SELECT * from dbo.[Dhcp];
end