using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        if (n % 2 == 1)
        {
            Console.WriteLine("Goose");
        }
        else
        {
            Console.WriteLine("Duck");
        }
    }
}
