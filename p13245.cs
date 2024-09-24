using System;
using System.IO;
using System.Linq;
using System.Numerics;

/// <summary>
/// p13245 - Sum of digits, G2
/// 해결 날짜 : 2023/9/22(solved.ac에는 9/21)
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int digit = input.ToString().Length;
        BigInteger digitSum = 0;

        BigInteger[] dCount = new BigInteger[16];
        dCount[0] = 1;
        BigInteger partSum = 1;
        BigInteger multipler = 10;
        for (int i = 1; i < 16; i++)
        {
            dCount[i] = partSum * 9 + multipler;
            partSum += dCount[i];
            multipler *= 10;
        }
        multipler = 1;
        BigInteger prev = 0;
        for (int i = 0; i < digit; i++)
        {
            int currentDigit = int.Parse(input[digit - i - 1].ToString());
            for (int j = 1; j < currentDigit; j++)
            {
                digitSum += multipler * j;
            }

            BigInteger subCount = 0;
            for (int j = 0; j < i; j++)
            {
                subCount += dCount[j];
            }
            digitSum += (i != 0) ? currentDigit * subCount * 45 : currentDigit;
            digitSum += (i != 0) ? (prev + 1) * currentDigit : 0;
            
            prev += currentDigit * multipler;
            multipler *= 10;
        }

        Console.WriteLine(digitSum);
    }
}