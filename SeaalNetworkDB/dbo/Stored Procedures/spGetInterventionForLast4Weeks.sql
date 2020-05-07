CREATE PROCEDURE [dbo].[spGetInterventionForLast4Weeks]



AS
begin

SELECT Weekdebut,Weekend, Count(InterventionDate)as _4WeeksInterventionCount
  FROM (
        (
        select CAST( DATEADD(WEEK,-1,GETDATE()) as date) weekdebut , CAST( DATEADD(WEEK,0,GETDATE()) as date) weekend 
        union all select CAST( DATEADD(WEEK,-2,GETDATE()) as date),CAST( DATEADD(WEEK,-1,GETDATE()) as date)
        union all select CAST( DATEADD(WEEK,-3,GETDATE()) as date),CAST( DATEADD(WEEK,-2,GETDATE()) as date)
        union all select CAST( DATEADD(WEEK,-4,GETDATE()) as date),CAST( DATEADD(WEEK,-3,GETDATE()) as date) 
        )weeks

left join dbo.Intervention
on (YEAR (weeks.weekdebut) = YEAR(InterventionDate) or YEAR (weeks.weekend) = YEAR(InterventionDate))
and

   (MONTH(weeks.weekdebut) = MONTH(InterventionDate) or MONTH(weeks.weekend) = MONTH(InterventionDate))
and 

   (InterventionDate >=weeks.weekdebut and InterventionDate < weeks.weekend)
   
       )


group by weekdebut,weekend
order by weekdebut,weekend


end