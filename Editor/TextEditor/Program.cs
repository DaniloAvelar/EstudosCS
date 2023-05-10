internal class Program
{
    private static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Abrir Arquivo");
        Console.WriteLine("2 - Novo Arquivo");
        Console.WriteLine("0 - Sair");
        short option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 0: System.Environment.Exit(0); break;
            case 1: Abrir(); break;
            case 2: Editar(); break;
            default: Menu(); break;
        }
    }

    static void Abrir()
    {
        Console.Clear();
        Console.WriteLine("Onde seu arquivo esta salvo?");
        //Caminho do arquivo a ser lido, e digitado pelo usuario.
        string path = Console.ReadLine();

        //Instanciando o Leitor de texto StreamReader(path) passando o caminho como parametro
        using (var file = new StreamReader(path))
        {
            //Lendo até o final do arquivo e guardando em uma variavel String.
            string text = file.ReadToEnd();

            //Escrevendo o conteudo da variavel na tela.
            Console.WriteLine(text);
        }

        Console.WriteLine("");
        Console.ReadLine();
        Menu();
    }

    static void Editar()
    {
        Console.Clear();
        Console.WriteLine("Digite seu texto abaixo (ESC para sair!)");
        Console.WriteLine("----------------------- # -----------------------");
        string text = "";

        // Faça isso enquanto o usuário não apertat a tecla (ESC) nao sai do laço de repetição
        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;
        }

        while (Console.ReadKey().Key != ConsoleKey.Escape);

        Salvar(text);
    }

    static void Salvar(string text)
    {
        Console.Clear();
        Console.WriteLine("Qual endereço deseja salvar seu arquivo?");

        var path = Console.ReadLine();

        //Todo objeto passado dentro do Using ele ja abre e fecha,
        //Sem correr o risco de fechar posteriormente
        using (var file = new StreamWriter(path))
        {
            file.Write(text);
        }

        Console.WriteLine("Arquivo Salvo com sucesso!");
        Console.ReadLine();
        Menu();
    }
}