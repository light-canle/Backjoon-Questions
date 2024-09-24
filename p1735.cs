using System;

/// <summary>
/// p1735 - 분수 합, S3
/// 해결 날짜 : 2023/9/3
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] input2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

        (int num, int deno) fraction1 = (input1[0], input1[1]);
        (int num, int deno) fraction2 = (input2[0], input2[1]);

        int commonDeno = fraction1.deno * fraction2.deno;

        fraction1.num *= commonDeno / fraction1.deno;
        fraction2.num *= commonDeno / fraction2.deno;

        (int num, int deno) fraction3 = (fraction1.num + fraction2.num, commonDeno);

        int div = GCD(fraction3.num, fraction3.deno);
        Console.WriteLine($"{fraction3.num / div} {fraction3.deno / div}");
    }

    public static int GCD(int a, int b)
    {
        int min = (a < b) ? a : b;
        int max = (a > b) ? a : b;

        if (max % min == 0) return min;
        return GCD(min, max % min);
    }
}
