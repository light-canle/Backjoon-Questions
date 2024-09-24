using System;

/// <summary>
/// p2145 - 숫자 놀이, B2
/// 해결 날짜 : 2023/9/13
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string N = Console.ReadLine();

            if (N == "0") { break; }

            int digit = DigitSum(N);
            while (digit >= 10) digit = DigitSum(digit.ToString());
            Console.WriteLine(digit);
        }
    }
    public static int DigitSum(string num)
    {
        int sum = 0;
        foreach (var c in num) {
            sum += int.Parse(c.ToString());
        }
        return sum;
    }
}