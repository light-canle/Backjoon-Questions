using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int total = 0;
        for (int i = 0; i < n; i++)
        {
            int size = int.Parse(Console.ReadLine());
            total += size;
        }
        total -= n - 1;
        Console.WriteLine(total);
    }
}
