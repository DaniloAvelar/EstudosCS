USE [EAD]
GO

CREATE TABLE [Curso]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Tag] NVARCHAR(20) NOT NULL,
    [Titulo] NVARCHAR(160) NOT NULL,
    [Sumario] NVARCHAR(2000) NOT NULL,
    [Url] NVARCHAR(1024) NOT NULL,
    [Level] TINYINT NOT NULL,
    [DuracaoEmMinutos] INT NOT NULL,
    [DtCriacao] DATETIME NOT NULL,
    [DtAtualizacao] DATETIME NOT NULL,
    [Ativo] BIT NOT NULL,
    [Gratis] BIT NOT NULL,
    [Destaque] BIT NOT NULL,
    [AutorId] UNIQUEIDENTIFIER NULL,
    [CategoriaId] UNIQUEIDENTIFIER NULL,
    [Tags] NVARCHAR(160) NOT NULL,

    CONSTRAINT [PK_Curso] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Curso_Autor_AutorId] FOREIGN KEY ([AutorId]) REFERENCES [Autor]([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Curso_Categoria_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categoria]([id]) ON DELETE NO ACTION
);
GO