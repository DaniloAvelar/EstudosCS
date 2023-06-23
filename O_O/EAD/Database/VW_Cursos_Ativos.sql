CREATE OR ALTER VIEW vwCursosAtivos AS

SELECT
    Course.id,
    Course.Tag,
    Course.Title,
    Course.Url,
    Course.Summary,
    Course.CreateDate,
    Category.Title AS Category,
    Author.Name AS Author
    
FROM
    Course
    INNER JOIN Category ON Course.CategoryId = Category.Id
    INNER JOIN AUTHOR ON Course.AuthorId = Author.Id

WHERE
    Course.Active = 1