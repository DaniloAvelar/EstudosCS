using DAPPAPP.Models;
using Dapper;
using Microsoft.Data.SqlClient;

public class Program
{
    private static void Main(string[] args)
    {
        //Criando a String de Conexão ***Só funcionou com o Trust ao final da Connection String
        const string connectionString = "Server=localhost,1433;Database=EAD;User ID=sa;Password=q1w2e3#@!;TrustServerCertificate=True;";


        //Usando a conexão nesse local
        using (var connection = new SqlConnection(connectionString))
        {   
            //CreateCategory(connection);
            //UpdateCategory(connection);
            //DeleteCategory(connection);
            //ListaCategories(connection);
            // ProcExcluiAluno(connection);
            ProcCourseByCategory(connection);

        }

       
    }

    static void ListaCategories(SqlConnection connection)
    {
        //SELECT dos Dados
        //Importar DAPPER e usar a QUERY para economia e Intelesense de Código
        var categories = connection.Query<Category>("Select Id, Title From Category");
        foreach(var i in categories)
        {
            Console.WriteLine($"{i.Title} - {i.Id}");
        }
    }

    static void CreateCategory(SqlConnection connection)
    {
        
        /*Para o INSERT:
            1- Estancia a classe Models (Modelo)
            2- Atribua os valores, adicionando a cada propriedade o valor especifico que ela deve receber
            3- Monte o Insert SQL (Fora da conexão Dapper) 
                **Somente com @parametors, evitando SQL Injection
            4 - Monta a Execução do Dapper passando os capmos a serem inseridos no banco
        */

        //Estanciando Categoria para Insert fora da Conexão
        var category = new Category();
        category.Id = Guid.NewGuid();
        category.Title = "Teste";
        category.Url = "Teste";
        category.Description = "Teste";
        category.Order = 9;
        category.Summary = "Teste";
        category.Featured = false;

        //Insert SQL - Nunca concatena String (SQL Injection)
        var insertSql = @"INSERT INTO 
            [Category]
         VALUES(
            @Id,
            @Title,
            @Url,
            @Summary,
            @Order,
            @Description,
            @Featured
        )";

         //Criando conexão com Dapper para o INSERT
            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });
            
            Console.WriteLine ($"{rows} linha(s) inserida(s) com sucesso!");
    }

    static void UpdateCategory(SqlConnection connection)
    {
        var UpdateQuery = "UPDATE [Category] SET[Title]=@title WHERE [Id]=@id";
        var rows = connection.Execute(UpdateQuery, new{
            id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
            title = "FrontEnd - Alterado"
        });

        Console.WriteLine($"{rows} Registros Atualizados");
    }

    static void DeleteCategory(SqlConnection connection)
    {
        var DeleteQuery = "DELETE FROM [Category] WHERE [Id]=@id";
        var rows = connection.Execute(DeleteQuery, new{
            id = new Guid("ffa85595-1a65-4878-ae42-d9b454ef923b"),
        });

        Console.WriteLine($"{rows} Registros Excluído com sucesso!");
    }

    //Executando Procedures
    //Obrigatoriamente passar o '@' antes do nome do Parametro
    static void ProcExcluiAluno(SqlConnection connection)
    {
        var proc = "prcDeletaAluno";
        var param = new { @StudentId = "d85cb6e0-a962-4b4a-bfa4-4fd98cc6247d" };
        var sql = connection.Execute(
            proc,
            param,
            commandType: System.Data.CommandType.StoredProcedure
        );

        Console.WriteLine($"{sql} linhas afetadas");
    }

    static void ProcCourseByCategory(SqlConnection connection)
    {
        var proc = "prcGetCoursesByCategory";
        var param = new {@CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142"};
        var sql = connection.Query(
            proc,
            param,
            commandType: System.Data.CommandType.StoredProcedure
        );

        foreach(var i in sql)
        {
            Console.WriteLine($"{i.Tag} - {i.Title}");
        }
    }
}
