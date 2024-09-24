using System;

/// <summary>
/// p4134 - 다음 소수, S4
/// 해결 날짜 : 2024/3/8 (solved.ac : 3/7)
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < count; i++)
        {
            long number = long.Parse(Console.ReadLine()!);
            long ans = number;
            while (true)
            {
                if (IsPrime(ans)) break;
                ans++;
            }
            Console.WriteLine(ans);
        }
    }

    public static bool IsPrime(long number)
    {
        if (number == 0 || number == 1) return false;
        if (number == 2 || number == 3) return true;
        for (long i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}