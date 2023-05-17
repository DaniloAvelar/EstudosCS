internal class Program
{
    private static void Main(string[] args)
    {
        //Criando array de 5 posições
        int[] arr = new int[5];

        try
        {
            // for (int i = 0; i < 10; i++)
            // {
            //     //Iterando arrayu até chegar a 10 posições
            //     arr[i] = i;
            //     Console.WriteLine(arr[i]);
            // }

            Cadastrar("");
        }
        //Sempre tratar os erros do mais específicos para os mais genéricos
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"O tamanho da lista é {arr.Length}, e foi ultrapassada.");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(ex);
        }
        catch (myException ex)
        {
            Console.WriteLine(ex.logDate);
            //Console.WriteLine(ex.Message);
            Console.WriteLine("Oops, algo deu errado!");
            Console.WriteLine("O Texto nao foi preenchido");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oops, algo deu errado!");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(ex.InnerException);
            Console.WriteLine(ex.Message);
        }
        // FINALLY SEMPRE É EXECUTADO
        finally
        {
            Console.Write("Chegamos ao fim.");
        }
    }

    private static void Cadastrar(string texto)
    {
        if (string.IsNullOrEmpty(texto))
            //throw new Exception("O texto nao pode ser nulo ou vazio");
            throw new myException(DateTime.Now);
    }

    //Criando uma classe especifica para gerar Data no momento que acontece o erro 
    public class myException : Exception
    {
        public myException(DateTime date)
        {
            logDate = date;
        }

        public DateTime logDate { get; set; }
    }
}