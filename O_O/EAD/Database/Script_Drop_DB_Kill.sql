--USE [master];

DECLARE @kill VARCHAR(8000) = '';
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'
FROM sys.dm_exec_sessions
WHERE database_id = db_id('Curso') -- NOME DO BANCO A SER EXCLUIDO (TROCAR SEMPRE)

EXEC (@kill);

DROP DATABASE [Curso] -- NOME DO BANCO A SER EXCLUIDO (TROCAR SEMPRE)

--************* SE NAO FUNCIONAR O DE CIMA, ESSE DE BAIXO FUNCIONA ***********************************************************************

USE Cursos;
GO

ALTER DATABASE Curso SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE Curso;
GO