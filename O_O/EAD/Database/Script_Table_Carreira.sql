USE [EAD]
GO

CREATE TABLE [Carreira]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Titulo] NVARCHAR(160) NOT NULL,
    [Sumario] NVARCHAR(2000) NOT NULL,
    [Url] NVARCHAR(1024) NULL,
    [DuracaoEmMinutos] INT NOT NULL,
    [Ativo] BIT NOT NULL, -- 0 ou 1
    [Destaque] BIT NOT NULL, -- 0 ou 1 - (Featured)
    [Tags] NVARCHAR(160) NOT NULL,

    CONSTRAINT [PK_Carreira] PRIMARY KEY ([Id])
);
GO
