// See https://aka.ms/new-console-template for more information
//Soma();
//Subtracao();
//Divisao();
//Multiplicacao();
Menu();

static void Menu()
{
    Console.Clear();

    Console.WriteLine("O que deseja fazer?");
    Console.WriteLine("1 - Soma");
    Console.WriteLine("2 - Subtração");
    Console.WriteLine("3 - Divisão");
    Console.WriteLine("4 - Multiplicação");
    Console.WriteLine("5 - Sair");

    Console.WriteLine("---------------------");
    Console.WriteLine("Seleciona uma das opções: ");

    short res = short.Parse(Console.ReadLine());

    switch (res)
    {
        case 1: Soma(); break;
        case 2: Subtracao(); break;
        case 3: Divisao(); break;
        case 4: Multiplicacao(); break;
        case 5: System.Environment.Exit(0); break;
        default: Menu(); break;
    }
}

static void Soma()
{
    Console.Clear();

    Console.WriteLine("Primeiro valor:");
    float v1 = float.Parse(Console.ReadLine());

    Console.WriteLine("Segundo Valor:");
    float v2 = float.Parse(Console.ReadLine());

    //Console.WriteLine("VLR-1:" + v1);
    //Console.WriteLine("VLR-2:" + v2);

    float soma = v1 + v2;
    Console.WriteLine("O resultado da soma é: " + soma);
    Console.WriteLine($"O resultado da soma é: {soma}");
    Console.ReadKey();
    Menu();
}

static void Subtracao()
{

    Console.Clear();

    Console.WriteLine("Primeiro valor:");
    float v1 = float.Parse(Console.ReadLine());

    Console.WriteLine("Segundo Valor:");
    float v2 = float.Parse(Console.ReadLine());

    //Console.WriteLine("VLR-1:" + v1);
    //Console.WriteLine("VLR-2:" + v2);

    float sub = v1 - v2;
    Console.WriteLine("O resultado da subtração é: " + sub);
    Console.WriteLine($"O resultado da subtração é: {sub}");
    Console.ReadKey();
    Menu();
}

static void Divisao()
{

    Console.Clear();

    Console.WriteLine("Primeiro valor:");
    float v1 = float.Parse(Console.ReadLine());

    Console.WriteLine("Segundo Valor:");
    float v2 = float.Parse(Console.ReadLine());

    //Console.WriteLine("VLR-1:" + v1);
    //Console.WriteLine("VLR-2:" + v2);

    float div = v1 / v2;
    Console.WriteLine("O resultado da divisão é: " + div);
    Console.WriteLine($"O resultado da divisão é: {div}");
    Console.ReadKey();
    Menu();
}

static void Multiplicacao()
{

    Console.Clear();

    Console.WriteLine("Primeiro valor:");
    float v1 = float.Parse(Console.ReadLine());

    Console.WriteLine("Segundo Valor:");
    float v2 = float.Parse(Console.ReadLine());

    //Console.WriteLine("VLR-1:" + v1);
    //Console.WriteLine("VLR-2:" + v2);

    float mult = v1 * v2;
    Console.WriteLine("O resultado da multiplicação é: " + mult);
    Console.WriteLine($"O resultado da multiplicação é: {mult}");
    Console.ReadKey();
    Menu();
}