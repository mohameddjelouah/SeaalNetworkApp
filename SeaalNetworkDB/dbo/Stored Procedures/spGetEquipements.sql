CREATE PROCEDURE [dbo].[spGetEquipements]
	

	AS
begin
	set nocount on;
	SELECT * from dbo.Equipement;
end