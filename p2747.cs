using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(Fibonacci(n));
    }
    public static long Fibonacci(int n)
    {
        if (n == 0) return 0;
        if (n == 1 || n == 2) return 1;
        int a = 1, b = 1;
        int ret = 2;
        for (int i = 3; i <= n; i++)
        {
            ret = a + b;
            a = b;
            b = ret;
        }
        return ret;
    }
}
