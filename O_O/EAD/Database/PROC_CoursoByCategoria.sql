CREATE OR ALTER PROCEDURE [prcGetCoursesByCategory]
    @CategoryId UNIQUEIDENTIFIER
AS
SELECT * FROM [Course] WHERE [CategoryId] = @CategoryId