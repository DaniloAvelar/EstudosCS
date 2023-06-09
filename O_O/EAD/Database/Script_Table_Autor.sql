USE [EAD]
GO

CREATE TABLE [Autor]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    [Titulo] NVARCHAR(80) NOT NULL,
    [Imagem] NVARCHAR(1024) NOT NULL,
    [Bio] NVARCHAR(2000) NOT NULL,
    [Url] NVARCHAR(450) NULL,
    [Email] NVARCHAR(160) NOT NULL,
    [Tipo] TINYINT NOT NULL, -- 0 a 255

    CONSTRAINT [PK_Autor] PRIMARY KEY ([Id])
);
GO

