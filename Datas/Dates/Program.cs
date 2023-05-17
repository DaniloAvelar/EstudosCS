using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        // var data = new DateTime();
        var data = DateTime.Now;

        //Formatando DATA Padrão BR
        var dataformatada = String.Format("{0:dd/MM/yyyy}", data);

        //Exibe a data por extenso
        //var dataformatada = String.Format("{0:D}", data);
        //var dataformatada = String.Format("{0:g}", data);
        //var dataformatada = String.Format("{0:f}", data);

        //Padrões para sistemas
        //var dataformatada = String.Format("{0:r}", data);
        //var dataformatada = String.Format("{0:s}", data);
        //var dataformatada = String.Format("{0:u}", data);

        var dataBr = new CultureInfo("pt-BR");
        Console.WriteLine(DateTime.Now.ToString("D", dataBr));

        Console.WriteLine(dataformatada);
    }
}