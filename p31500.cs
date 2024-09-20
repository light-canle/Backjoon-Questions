using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Numerics;

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
        List<char> ret = new List<char>();
        if (system > 0)
        {
            bool isNegative = decNum < 0 ? true : false;
            BigInteger absNum = BigInteger.Abs(decNum);
            while (absNum >= system)
            {
                int remainder = (int)BigInteger.Remainder(absNum, system);
                ret.Add(Convert.ToChar(remainder + 33));
                absNum /= system;
            }
            ret.Add(Convert.ToChar((int)absNum + 33));

            ret.Reverse();
            StringBuilder result = new StringBuilder();
            if (isNegative) result.Append('~');
            foreach (char c in ret)
            {
                result.Append(c);
            }
            return result.ToString();
        }
        else
        {
            while (decNum != 0)
            {
                (var quotient, var remainder) = DivMod(decNum, system);
                ret.Add(Convert.ToChar((int)remainder + 33));
                decNum = quotient;
            }
            ret.Reverse();
            return new string(ret.ToArray());
        }
    }
    public static (BigInteger,  BigInteger) DivMod(BigInteger a, BigInteger b)
    {
        BigInteger q = a / b;
        BigInteger r = a % b;

        if (r < 0)
        {
            q++;
            r += BigInteger.Abs(b);
        }

        return (q, r);
    }
}
