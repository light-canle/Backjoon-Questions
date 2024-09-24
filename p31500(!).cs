using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Numerics;

/// <summary>
/// p31500 - 이진수 곱셈, G3
/// 시작 날짜 : 2024/3/10
/// </summary>

// 시간 초과로 인한 미해결 문제

public class Program
{

    public static void Main(string[] args)
    {
        // input
        int system = int.Parse(Console.ReadLine()!);
        string num1 = Console.ReadLine()!;
        string num2 = Console.ReadLine()!;

        bool b1, b2;
        BigInteger n1 = ConvertDec(num1, system, out b1);
        BigInteger n2 = ConvertDec(num2, system, out b2);
        bool isNeg = (b1 != b2);
        //Console.WriteLine(n1);
        //Console.WriteLine(n2);
        //Console.WriteLine(isNeg);
        string result = DecToSystem(n1 * n2, system, isNeg);
        Console.WriteLine(result);

        //Console.WriteLine(ConvertDec(result, system, out b1));
    }

    // N진법 수를 10진수로 바꾼다.
    public static BigInteger ConvertDec(string num, int system, out bool isNeg)
    {
        BigInteger result = 0;
        isNeg = false;
        int digit = num.Length;
        for (int i = 0; i < digit; i++)
        {
            // ~ 처리
            if (num[i] == '~')
            {
                isNeg = true;
            }
            else
            {
                result += (Convert.ToInt32(num[i]) - 33) * BigInteger.Pow(system, digit - i - 1);
            }
        }

        return isNeg ? -result : result;
    }

    // 10진법 수를 N진법으로 바꾼다.
    public static string DecToSystem(BigInteger decNum, int system, bool isNeg)
    {
        if (decNum == 0) return "!";
        BigInteger first = decNum;
        StringBuilder sb = new StringBuilder();
        if (system > 0)
        {
            bool isNegative = decNum < 0 ? true : false;
            BigInteger absNum = BigInteger.Abs(decNum);
            while (absNum >= system)
            {
                int remainder = (int)BigInteger.Remainder(absNum, system);
                sb.Append(Convert.ToChar(remainder + 33));
                absNum /= system;
            }
            sb.Append(Convert.ToChar((int)absNum + 33));

            StringBuilder result = new StringBuilder();
            if (isNegative) result.Append('~');
            foreach (char c in sb.ToString().Reverse())
            {
                result.Append(c);
            }
            return result.ToString();
        }
        else
        {
            BigInteger absSystem = -system;
            if (isNeg)
            {
                decNum = -decNum;
            }
            int expon = 0;
            BigInteger divisor = 1;
            while (decNum != 0)
            {
                divisor = divisor * absSystem;
                BigInteger remain = decNum % divisor;
                //Console.WriteLine($"{divisor} {decNum} {remain}");
                if (remain != 0)
                {
                    BigInteger toSub = remain;
                    if (toSub > 0 && expon % 2 == 1)
                    {
                        toSub = -(divisor - toSub);
                    }
                    else if (toSub < 0 && expon % 2 == 0)
                    {
                        toSub = (divisor + toSub);
                    }
                    decNum -= toSub;

                    BigInteger digit = toSub / ((expon % 2 == 1 ? -1 : 1) * (divisor / absSystem));
                    //Console.WriteLine(digit.ToString());
                    sb.Append(Convert.ToChar((int)digit + 33));
                }
                else
                {
                    sb.Append("!");
                }

                expon += 1;
            }

            StringBuilder result = new StringBuilder();
            if (isNeg) result.Append('~');
            foreach (char c in sb.ToString().Reverse())
            {
                result.Append(c);
            }

            return result.ToString();
        }
    }
}