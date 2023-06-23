CREATE OR ALTER PROCEDURE prcDeletaAluno(
    @StudentId UNIQUEIDENTIFIER
)
AS
BEGIN TRANSACTION

    --Deletando Cursos vinculados ao Aluno (Primeiro)
    DELETE FROM
        StudentCourse
    WHERE
        StudentCourse.StudentId = @StudentId
    
    --Deletando o Aluno, após deletar seus cursos vinculados.
    DELETE FROM
        Student
    WHERE
        Student.id = @StudentId

COMMIT


/*Exemplo de Execução

    EXEC prcDeletaAluno 'af690936-401d-4408-a5be-2628eb32799c'

*/
