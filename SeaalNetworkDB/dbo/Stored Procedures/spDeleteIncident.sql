CREATE PROCEDURE [dbo].[spDeleteIncident]
@Id int
AS
begin
	
	set nocount on 

	delete from dbo.Incidents where Id = @Id ;

end