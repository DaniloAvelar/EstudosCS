
CREATE DATABASE [Cursos]
GO

USE[Cursos]

--DROP TABLE[Categoria]
CREATE TABLE[Categoria](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Nome] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id]),
)
GO

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

