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
            //ProcCourseByCategory(connection);
            ReadView(connection);

        }


    }

    static void ListaCategories(SqlConnection connection)
    {
        //SELECT dos Dados
        //Importar DAPPER e usar a QUERY para economia e Intelesense de Código
        var categories = connection.Query<Category>("Select Id, Title From Category");
        foreach (var i in categories)
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

        Console.WriteLine($"{rows} linha(s) inserida(s) com sucesso!");
    }

    static void UpdateCategory(SqlConnection connection)
    {
        var UpdateQuery = "UPDATE [Category] SET[Title]=@title WHERE [Id]=@id";
        var rows = connection.Execute(UpdateQuery, new
        {
            id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
            title = "FrontEnd - Alterado"
        });

        Console.WriteLine($"{rows} Registros Atualizados");
    }

    static void DeleteCategory(SqlConnection connection)
    {
        var DeleteQuery = "DELETE FROM [Category] WHERE [Id]=@id";
        var rows = connection.Execute(DeleteQuery, new
        {
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
        var param = new { @CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
        var sql = connection.Query(
            proc,
            param,
            commandType: System.Data.CommandType.StoredProcedure
        );

        foreach (var i in sql)
        {
            Console.WriteLine($"{i.Tag} - {i.Title}");
        }
    }

    static void ReadView(Sqlconnection connection)
    {
        var sql = "Select * From [vwCorses]";
        var courses = connection.Query(sql);
        foreach (var i in courses)
        {
            Console.WriteLine($"{i.Id} - {i.Title}");
        }
    }

    //Mapeando Mais de um MODEL na mesma Query com Dapper, juntando como se fosse um Inner Join
    //Mapeamento 1 para 1

    static void OneToOne(Sqlconnection connection)
    {
        var sql = @"
            SELECT 
                *
            FROM
                CarrerItem
            INNER JOIN 
                Course ON CarrerItem.CourseId = Course.Id";

        //Tipando com mais de uma Model(mais de 1 tipo)
        /* 1 - A tabela do From da select
           2 - A tabela do Inner da Select
           3 - Junção esta dentro da tabela do FROM nesse caso, CarrerItem

           Depois da Instrução SQL, sempre usar a função para explicar como vai carregar o Curso dentro da Carreira
        */

        var items = connection.Query<CarrerItem, Course, CarrerItem>(
            sql,
            (carrerItem, course) =>
            {
                carrerItem.Course = course;
                return carrerItem;
            }, splitOn: "Id"); //Explicando onde uma tabela termina e outra começa, ou seja (Onde divide as tabelas)

        foreach (var item in items)
        {
            Console.WriteLine($"{item.Title} - Curso: {item.Course.Title}");
        }

    }

    static void OneToMany(SqlConnection connection)
    {
        var sql = @"
            SELECT
                [Career].[Id],
                [Career].[Title],
                [CareerItem].[CareerId],
                [CareerItem].[TItle]
            FROM
                [Career]
            INNER JOIN
                [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
            ORDER BY
                [Carrer].[Title]";

        var careers = new List<Career>();
        var items = connection.Query<Career, CareerItem, Career>(
            sql,
            //Quais objetos estão sendo mapeados?
            (career, item) =>
            {
                var car = career.Where(x => x.Id == career.Id).FirstOrDefault();
                if (car == null)
                {
                    car = career;
                    car.items.Add(item);
                    careers.Add(car);
                }
                else
                {
                    car.items.Add(item);
                }

                return career;
            }, splitOn: "CareerId"
        );

        // Percorrendo todas as carreiras
        foreach (var career in careers)
        {
            Console.WriteLine($"{career.Title}");

            //Percorrendo todos os itens dessa carreira
            foreach (var item in career.items)
            {
                Console.WriteLine($"{item.Title}");
            }
        }
    }
}
