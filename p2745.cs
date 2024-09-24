using System;
using System.Linq;
using System.Numerics;

/// <summary>
/// p2745 - 진법 변환, B2
/// 해결 날짜 : 2024/3/11(solved.ac : 3/10)
/// </summary>
/// 
public class Program
{

    public static void Main(string[] args)
    {
        // input
        string[] input = Console.ReadLine()!.Split();
        int system = int.Parse(input[1]);
        BigInteger result = ConvertDec(input[0], system);
        Console.WriteLine(result);
    }

    // N진법 수를 10진수로 바꾼다.
    public static BigInteger ConvertDec(string num, int system)
    {
        BigInteger result = 0;
        int digit = num.Length;
        for (int i = 0; i < digit; i++)
        {
            if (char.IsNumber(num[i]))
                result += (Convert.ToInt32(num[i]) - 48) * BigInteger.Pow(system, digit - i - 1);
            else if (char.IsUpper(num[i]))
            {
                result += (Convert.ToInt32(num[i]) - 65 + 10) * BigInteger.Pow(system, digit - i - 1);
            }
        }

        return result;
    }
}