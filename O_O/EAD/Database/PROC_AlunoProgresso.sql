CREATE OR ALTER PROCEDURE prcEstudanteProgresso(
    @StudentId UNIQUEIDENTIFIER
)

/*
    Exemplo: EXEC prcEstudanteProgresso 'af690936-401d-4408-a5be-2628eb32799c'
*/

AS

SELECT
    Student.Name,
    Course.Title,
    StudentCourse.Progress,
    StudentCourse.LastUpdateDate
FROM
    StudentCourse
    INNER JOIN Student ON StudentCourse.StudentId = Student.Id
    INNER JOIN Course ON StudentCourse.CourseId = Course.Id
WHERE
    StudentCourse.StudentId = @StudentId
    AND StudentCourse.Progress < 100
    AND StudentCourse.Progress > 0
ORDER BY
    StudentCourse.LastUpdateDate DESC


