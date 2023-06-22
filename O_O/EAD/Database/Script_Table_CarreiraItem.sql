USE [EAD]
GO

CREATE TABLE [CarreiraItem]
(
    [IdCarreira] UNIQUEIDENTIFIER NOT NULL,
    [IdCurso] UNIQUEIDENTIFIER NOT NULL,
    [Titulo] NVARCHAR(160) NOT NULL,
    [Descricao] TEXT NOT NULL,
    [Ordem] TINYINT NOT NULL,

    CONSTRAINT [PK_CarreiraItem] PRIMARY KEY ([IdCurso], [IdCarreira]),
    CONSTRAINT [FK_CarreiraItem_Carreira_IdCarreira] FOREIGN KEY ([IdCarreira]) REFERENCES [Carreira]([id]),
    CONSTRAINT [FK_CarreiraItem_Curso_IdCurso] FOREIGN KEY ([IdCurso]) REFERENCES [Curso]([id])
);
GO