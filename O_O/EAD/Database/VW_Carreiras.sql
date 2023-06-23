CREATE OR ALTER VIEW vwCarreiras AS

SELECT
    Career.id,
    Career.Title,
    Career.Url,
    COUNT(Id) as Courses

FROM
    Career
    INNER JOIN CareerItem ON CareerItem.CareerId = Career.Id

GROUP BY
    Career.id,
    Career.Title,
    Career.Url