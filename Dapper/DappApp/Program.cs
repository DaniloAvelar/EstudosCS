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
            //Importar DAPPER e usar a QUERY para economia e Intelesense de Código
            var categories = connection.Query<Category>("Select Id, Title From Category");
            foreach(var i in categories)
            {
                 Console.WriteLine($"{i.Title} - {i.Id}");
            }
        }

       
    }
}