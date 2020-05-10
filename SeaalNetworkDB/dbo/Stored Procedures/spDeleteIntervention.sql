CREATE PROCEDURE [dbo].[spDeleteIntervention]
	

	@Id int
AS
begin
	
	set nocount on 

	delete from dbo.Intervention where Id = @Id ;

end