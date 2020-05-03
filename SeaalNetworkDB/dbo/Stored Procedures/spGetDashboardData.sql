CREATE PROCEDURE [dbo].[spGetDashboardData]
	

		

	AS
begin

SELECT IncidentTotal,IncidentTotalClotorer,IncidentTotalNonClotorer
              FROM
                (
                    select COUNT(Incidents.IncidentDate) IncidentTotal 
                    from dbo.Incidents
                    
                ) IncidentTotal,
                
                (
                    select COUNT(*) IncidentTotalClotorer 
                    from dbo.Incidents
                    where Incidents.isClotured  = 1
                   
                    
                ) IncidentTotalClotorer,


                (
                    select COUNT(*) IncidentTotalNonClotorer 
                    from dbo.Incidents
                    where Incidents.isClotured  = 0
                   
                    
                ) IncidentTotalNonClotorer


                ;



   select      IncidentThisYear,IncidentThisYearCloturer, IncidentThisYearNonCloturer
          from


                (
                    select COUNT(Incidents.IncidentDate) IncidentThisYear 
                    from dbo.Incidents
                    where YEAR(Incidents.IncidentDate)  = YEAR(GETDATE())
                ) IncidentThisYear,

                (
                    select COUNT(Incidents.IncidentDate) IncidentThisYearCloturer 
                    from dbo.Incidents
                    where YEAR(Incidents.IncidentDate)  = YEAR(GETDATE()) and Incidents.isClotured  = 1
                ) IncidentThisYearCloturer,


                (
                    select COUNT(Incidents.IncidentDate) IncidentThisYearNonCloturer 
                    from dbo.Incidents
                    where YEAR(Incidents.IncidentDate)  = YEAR(GETDATE()) and Incidents.isClotured  = 0
                ) IncidentThisYearNonCloturer

                   ;

 select      IncidentThisMonth,IncidentThisMonthCloturer, IncidentThisMonthNonCloturer
          from


                (
                    select COUNT(Incidents.IncidentDate) IncidentThisMonth 
                    from dbo.Incidents
                    where MONTH(Incidents.IncidentDate)  = MONTH(GETDATE()) and YEAR(Incidents.IncidentDate)  = YEAR(GETDATE())
                ) IncidentThisMonth,

                (
                    select COUNT(Incidents.IncidentDate) IncidentThisMonthCloturer 
                    from dbo.Incidents
                    where MONTH(Incidents.IncidentDate)  = MONTH(GETDATE()) and YEAR(Incidents.IncidentDate)  = YEAR(GETDATE()) and Incidents.isClotured  = 1
                ) IncidentThisMonthCloturer,


                (
                    select COUNT(Incidents.IncidentDate) IncidentThisMonthNonCloturer 
                    from dbo.Incidents
                    where MONTH(Incidents.IncidentDate)  = MONTH(GETDATE()) and YEAR(Incidents.IncidentDate)  = YEAR(GETDATE()) and Incidents.isClotured  = 0
                ) IncidentThisMonthNonCloturer

                   ;


select IncidentLastYear ,IncidentLastYearCloturer,IncidentLastYearNonCloturer
from

                (
                    select COUNT(Incidents.IncidentDate) IncidentLastYear 
                    from dbo.Incidents
                    where YEAR(Incidents.IncidentDate)  = YEAR(GETDATE()) -1
                ) IncidentLastYear,

                 (
                    select COUNT(Incidents.IncidentDate) IncidentLastYearCloturer 
                    from dbo.Incidents
                    where YEAR(Incidents.IncidentDate)  = YEAR(GETDATE()) -1 and Incidents.isClotured  = 1
                ) IncidentLastYearCloturer,

                 (
                    select COUNT(Incidents.IncidentDate) IncidentLastYearNonCloturer 
                    from dbo.Incidents
                    where YEAR(Incidents.IncidentDate)  = YEAR(GETDATE()) -1 and Incidents.isClotured  = 0
                ) IncidentLastYearNonCloturer
 
    ;

 

 select IncidentLastMonth ,IncidentLastMonthCloturer,IncidentLastMonthNonCloturer
from

                (
                    select COUNT(Incidents.IncidentDate) IncidentLastMonth 
                    from dbo.Incidents

                    where 
                   
                    MONTH(Incidents.IncidentDate) = MONTH(GETDATE()) -1 and YEAR(Incidents.IncidentDate)  = YEAR(GETDATE()) and MONTH(GETDATE()) <> 1
                    or

                    MONTH(Incidents.IncidentDate) = MONTH(GETDATE()) -1 and YEAR(Incidents.IncidentDate)  = YEAR(GETDATE())-1 and MONTH(GETDATE()) = 1

                   
                    
                ) IncidentLastMonth,

                 (
                    select COUNT(Incidents.IncidentDate) IncidentLastMonthCloturer 
                    from dbo.Incidents
                    where MONTH(Incidents.IncidentDate)  = MONTH(GETDATE()) -1 and YEAR(Incidents.IncidentDate)  = YEAR(GETDATE()) and Incidents.isClotured  = 1
                ) IncidentLastMonthCloturer,

                 (
                    select COUNT(Incidents.IncidentDate) IncidentLastMonthNonCloturer 
                    from dbo.Incidents
                    where MONTH(Incidents.IncidentDate)  = MONTH(GETDATE()) -1 and YEAR(Incidents.IncidentDate)  = YEAR(GETDATE()) and Incidents.isClotured  = 0
                ) IncidentLastMonthNonCloturer

   ;
  select COUNT(Incidents.IncidentDate) IncidentYesterday
                    from dbo.Incidents
                    where Incidents.IncidentDate = DATEFROMPARTS(YEAR(getdate()),month(getdate()),day(GETDATE()) -1)
                
   ;
  select  COUNT(*) Sites 
  from dbo.Site

     ;
end
