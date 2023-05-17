internal class Program
{
    private static void Main(string[] args)
    {
        var array1 = new int[5];
        array1[0] = 12;
        array1[1] = 5;
        array1[2] = 8;
        array1[3] = 2;
        array1[4] = 4;

        int[] array2 = new int[3] { 65, 87, 99 };

        foreach (int i in array1)
        {
            Console.WriteLine(i);
        }

        foreach (int p in array2)
        {
            Console.WriteLine(p);
        }
    }
}