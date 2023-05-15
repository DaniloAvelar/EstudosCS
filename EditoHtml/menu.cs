using System;

namespace EditorHtml
{
    public static class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            DrawScreen();
            WriteOptions();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);

        }

        public static void DrawScreen()
        {
            DrawColuns(30);
            DrawLine(30, 10);
            DrawColuns(30);

        }

        public static void DrawColuns(int col)
        {
            //Função para desenhar as linha Superiores e inferiores
            Console.Write("+");
            for (int i = 0; i <= col; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.Write("\n");
        }

        public static void DrawLine(int col, int lin)
        {
            for (int line = 0; line <= lin; line++)
            {
                Console.Write("|");
                //SPC = Space (Espaço em branco)
                for (int spc = 0; spc <= col; spc++)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
                Console.Write("\n");
            }
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("=============================");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("Selecione uma opção abaixo");
            Console.SetCursorPosition(2, 7);
            Console.WriteLine("1 - Novo Arquivo");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("2 - Abrir Arquivo");
            Console.SetCursorPosition(2, 9);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(2, 11);
            Console.Write("Opção: ");
        }

        public static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1: Editor.Show(); break;
                case 2: Console.WriteLine("View"); break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: Show(); break;
            }
        }
    }
}