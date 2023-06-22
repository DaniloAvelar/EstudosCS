USE [EAD]
GO

CREATE TABLE [AlunoCurso]
(
    [IdCurso] UNIQUEIDENTIFIER NOT NULL,
    [IdAluno] UNIQUEIDENTIFIER NOT NULL,
    [Progresso] TINYINT NOT NULL,
    [Favorito] BIT NOT NULL,
    [DtInicio] DATETIME NOT NULL,
    [UltimaAtualizacao] DATETIME NULL DEFAULT(GETDATE()),

    CONSTRAINT [PK_AlunoCurso] PRIMARY KEY ([IdCurso], [IdAluno]),
    CONSTRAINT [FK_AlunoCurso_Aluno_IdAluno] FOREIGN KEY ([IdAluno]) REFERENCES [Aluno]([id]),
    CONSTRAINT [FK_AlunoCurso_Curso_IdCurso] FOREIGN KEY ([IdCurso]) REFERENCES [Curso]([id])
);
GO