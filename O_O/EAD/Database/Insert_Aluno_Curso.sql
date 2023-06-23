DECLARE @studentId UNIQUEIDENTIFIER = (SELECT NEWID())

INSERT INTO
    Student
VALUES(
    @studentId,
    'Danilo Avelar',
    'email@email.com.br',
    '12345678901',
    '12345678',
    Null,
    GETDATE()
)


INSERT INTO
    StudentCourse
VALUES(
    '5c349848-e717-9a7d-1241-0e6500000000',
    'af690936-401d-4408-a5be-2628eb32799c',
    50,
    0,
    '2023-01-15 16:24:55',
    GETDATE()
)
