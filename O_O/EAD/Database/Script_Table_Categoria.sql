USE [EAD]
GO

CREATE TABLE [Categoria]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Titulo] NVARCHAR(160) NOT NULL,
    [Url] NVARCHAR(1024) NULL,
    [Sumario] NVARCHAR(2000) NOT NULL,
    [Ordem] INT NOT NULL,
    [Descricao] TEXT NOT NULL,
    [Destaque] BIT NOT NULL, -- 0 ou 1 - (Featured)

    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id])
);
GO