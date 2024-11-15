using System;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int a = input[0];
            int b = input[1];

            if (a == 0 && b == 0)
                return;
            Console.WriteLine(a+b);
        }
    }
}
