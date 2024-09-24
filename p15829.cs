using System;
using System.Numerics;

/// <summary>
/// p15829 - Hashing, B2
/// 해결 날짜 : 2023/8/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());
        string str = Console.ReadLine();

        BigInteger hashNumber = 0;
        for (int i = 0; i < length; i++)
        {
            int charNum = UniqueNumber(str[i]);
            hashNumber += charNum * Pow(31, i);
            hashNumber %= 1234567891;
        }

        Console.WriteLine(hashNumber.ToString());
    }

    public static int UniqueNumber(char c)
    {
        return Convert.ToInt32(c) - Convert.ToInt32('a') + 1;
    }

    public static BigInteger Pow(BigInteger a, int b)
    {
        if (b == 0) return 1;
        BigInteger result = 1;
        for (int i = 0; i < b; i++)
        {
            result *= a;
        }
        return result;
    }
}
