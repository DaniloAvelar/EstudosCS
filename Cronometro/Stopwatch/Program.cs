internal class Program
{
    private static void Main(string[] args)
    {
        //Start(6);
        Menu();
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("S = Segundo");
        Console.WriteLine("M = Minuto");
        Console.WriteLine("0 = Sair");
        Console.WriteLine("Quanto tempo deseja contar?");

        string data = Console.ReadLine().ToLower();
        char type = char.Parse(data.Substring(data.Length - 1, 1));
        int tmp = int.Parse(data.Substring(0, data.Length - 1));
        int multiplier = 1;

        if (type == 'm')
        {
            multiplier = 60;
        }

        if (tmp == 0)
            System.Environment.Exit(0);

        PreStart(tmp * multiplier);

    }

    static void PreStart(int time)
    {
        Console.Clear();
        Console.WriteLine("Ready ...");
        Thread.Sleep(1000);
        Console.WriteLine("Set ...");
        Thread.Sleep(1000);
        Console.WriteLine("Go ...");
        Thread.Sleep(2500);

        Start(time);
    }

    static void Start(int time)
    {
        int cTime = 0;

        while (cTime != time)
        {
            Console.Clear();
            cTime++;
            Console.WriteLine(cTime);
            Thread.Sleep(1000);
        }

        Console.Clear();
        Console.WriteLine("Stopwatch finalizado!");
        Thread.Sleep(2500);
        Menu();
    }
}