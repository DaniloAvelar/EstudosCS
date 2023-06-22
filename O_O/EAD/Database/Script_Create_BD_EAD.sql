PUSE [Curso]

--DROP TABLE[Aluno]
CREATE TABLE[Aluno](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Nome] NVARCHAR(80) NOT NULL,
    [DtNascimento] Datetime NOT NULL,
    [Email] NVARCHAR(150) NOT NULL UNIQUE,
    [Ativo] BIT NOT NULL DEFAULT(0),

    CONSTRAINT [PK_Aluno] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Aluno_Email] UNIQUE ([Email])
)
GO
--Criando Indice para pesquisa massiva pelo Nome e email do aluno

CREATE INDEX [IX_Aluno_Email] ON [Aluno]([Email])

--///////////////////////////////////////////////////////////////

--DROP TABLE[Curso]
CREATE TABLE[Curso](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Nome] NVARCHAR(80) NOT NULL,
    [CategoriaId] INT NOT NULL,

    CONSTRAINT [PK_Curso] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN Key ([CategoriaId])
        REFERENCES[Categoria]([Id])
)
GO

--DROP TABLE[Progresso]
CREATE TABLE[Progresso](
    [AlunoId] INT NOT NULL,
    [CursoId] INT NOT NULL,
    [Progresso] INT NOT NULL,
    [UltimaAtualizacao] DATETIME NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT PK_Progresso PRIMARY KEY ([AlunoId], [CursoId]),
)
GO

--DROP TABLE[Categoria]
CREATE TABLE[Categoria](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Nome] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id]),
)
GO



