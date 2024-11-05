using System;

public class Program
{
    public static void Main(string[] args)
    {
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        int sum = 0;
        int min = 10001;
        for (int i = 1; i <= 100; i++)
        {
            if (m <= i * i && i * i <= n)
            {
                sum += i * i;
                min = Math.Min(min, i * i);
            }
        }

        if (sum == 0)
        {
            Console.WriteLine(-1);
            return;
        }

        Console.WriteLine(sum);
        Console.WriteLine(min);
    }
}
