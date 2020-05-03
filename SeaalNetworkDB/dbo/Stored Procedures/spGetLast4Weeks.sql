CREATE PROCEDURE [dbo].[spGetLast4Weeks]




AS
begin

SELECT Weekdebut,Weekend, Count(IncidentDate)as _4WeeksCount
  FROM (
        (
        select CAST( DATEADD(WEEK,-1,GETDATE()) as date) weekdebut , CAST( DATEADD(WEEK,0,GETDATE()) as date) weekend 
        union all select CAST( DATEADD(WEEK,-2,GETDATE()) as date),CAST( DATEADD(WEEK,-1,GETDATE()) as date)
        union all select CAST( DATEADD(WEEK,-3,GETDATE()) as date),CAST( DATEADD(WEEK,-2,GETDATE()) as date)
        union all select CAST( DATEADD(WEEK,-4,GETDATE()) as date),CAST( DATEADD(WEEK,-3,GETDATE()) as date) 
        )weeks

left join dbo.Incidents
on (YEAR (weeks.weekdebut) = YEAR(IncidentDate) or YEAR (weeks.weekend) = YEAR(IncidentDate))
and

   (MONTH(weeks.weekdebut) = MONTH(IncidentDate) or MONTH(weeks.weekend) = MONTH(IncidentDate)))

WHERE IncidentDate >=weeks.weekdebut
and   IncidentDate < weeks.weekend
group by weekdebut,weekend
order by weekdebut,weekend



--*****************this is the concat of weekend and week debut into one colomn
--AS
--begin
--SELECT CONCAT(Weekdebut,' ',Weekend) as weeks , Count(IncidentDate)as IncidentCount
--  FROM (
--        (
--        select CAST( DATEADD(WEEK,-1,GETDATE()) as date) weekdebut , CAST( DATEADD(WEEK,0,GETDATE()) as date) weekend 
--        union all select CAST( DATEADD(WEEK,-2,GETDATE()) as date),CAST( DATEADD(WEEK,-1,GETDATE()) as date)
--        union all select CAST( DATEADD(WEEK,-3,GETDATE()) as date),CAST( DATEADD(WEEK,-2,GETDATE()) as date)
--        union all select CAST( DATEADD(WEEK,-4,GETDATE()) as date),CAST( DATEADD(WEEK,-3,GETDATE()) as date) 
--        )weeks

--left join dbo.Incidents
--on (YEAR (weeks.weekdebut) = YEAR(IncidentDate) or YEAR (weeks.weekend) = YEAR(IncidentDate))
--and

--   (MONTH(weeks.weekdebut) = MONTH(IncidentDate) or MONTH(weeks.weekend) = MONTH(IncidentDate)))

--WHERE IncidentDate >=weeks.weekdebut
--and   IncidentDate < weeks.weekend
--group by weekdebut,weekend
--order by weekdebut,weekend

end