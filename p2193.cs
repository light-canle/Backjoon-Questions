using System;

/// <summary>
/// p2193 - 이친수, S3
/// 해결 날짜 : 2023/9/23
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine(Fibonacci(N));
    }

    public static long Fibonacci(int n)
    {
        if (n == 0) return 0;
        if (n == 1 || n == 2) return 1;
        long a = 1, b = 1;
        long result = 2;
        for (int i = 3; i <= n; i++)
        {
            result = a + b;
            a = b;
            b = result;
        }
        return result;
    }
}