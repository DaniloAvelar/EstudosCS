/* CRIANDO UMA VIEW PARA QUE PESQUISAR NO SEU RESULTADO */

CREATE OR ALTER VIEW vwContagemPorCategoria AS
    SELECT TOP 100
        [Categoria].[Id],
        [Categoria].[Nome],
        COUNT([Curso].[CategoriaId]) AS [Cursos]
    FROM 
        [Categoria]
        INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
    GROUP BY
        [Categoria].[Id],
        [Categoria].[Nome],
        [Curso].[CategoriaId]
    HAVING
        COUNT([Curso].[CategoriaId]) > 1


/* Rodando uma select com Clausula WHERE no resultado da VIEW montada anteriormente*/
    Select * from vwContagemPorCategoria
