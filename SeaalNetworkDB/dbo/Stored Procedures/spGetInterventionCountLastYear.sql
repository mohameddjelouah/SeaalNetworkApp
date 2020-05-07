CREATE PROCEDURE [dbo].[spGetInterventionCountLastYear]


AS
begin

	            
	            SELECT DATEFROMPARTS(y,m,1) as InterventionsDate, Count(InterventionDate)as InterventiontCount
            FROM (
              SELECT y, m
              FROM
                (SELECT YEAR(GETDATE()) y UNION ALL SELECT YEAR(GETDATE())-1) years,
                (SELECT 1 m UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4
                  UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8
                  UNION ALL SELECT 9 UNION ALL SELECT 10 UNION ALL SELECT 11 UNION ALL SELECT 12) months) ym
              LEFT JOIN dbo.Intervention
              ON ym.y = YEAR(InterventionDate)
                 AND ym.m = MONTH(InterventionDate)
            WHERE
              (y=YEAR(GETDATE()) AND m<=MONTH(GETDATE()))
              OR
              (y<YEAR(GETDATE()) AND m>=MONTH(GETDATE()))
            GROUP BY y, m
            order by y, m


end