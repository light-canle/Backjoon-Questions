using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int count = 5;
        for (int i = 2; i <= n; i++)
        {
            count += 2 * (i + 1) + (i - 1);
            count %= 45678;
        }
        Console.WriteLine(count);
    }
}
