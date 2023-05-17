using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        //Obrigatório as utilização do "m" ao final
        decimal valor = 10.25m;

        //CULTURE ESPECIFICATION = Para especificar uma cultura de moeda (Pais)
        Console.WriteLine(valor.ToString(CultureInfo.CreateSpecificCulture("pt-BR")));

        // CURRENTECULTURE pega sempre a cultura da maquina para moedas e datas nesse caso (pt-BR)
        Console.WriteLine(valor.ToString(CultureInfo.CurrentCulture));

        //ARREDONDAMENTO DE VALORES MÉDIA, GERALMENTE SÓ RETIRA O PONTO OU VIRGULA MANTENDO O VALOR ANTERIOR A VIRGULA
        decimal vlr = 10536.25m;
        Console.WriteLine(Math.Round(vlr));

        //ARREDONDA PARA CIMA (CELLING)
        decimal vlr2 = 10536.68m;
        Console.WriteLine(Math.Ceiling(vlr2));

        //ARREDONDA PARA BAIXO (FLOOR)
        decimal vlr3 = 10536.25m;
        Console.WriteLine(Math.Floor(vlr3));

    }
}