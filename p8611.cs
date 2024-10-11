using System;
using System.Collections.Generic;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        bool isExist = false;
        for (int b = 2; b <= 10; b++)
        {
            string convert = DecToOther(n, b);
            if (IsPalindrome(convert))
            {
                isExist = true;
                Console.WriteLine($"{b} {convert}");
            }
        }

        if (!isExist)
        {
            Console.WriteLine("NIE");
        }
    }

    public static string DecToOther(BigInteger n, int baseNum)
    {
        string result = "";
        while (n > 0)
        {
            BigInteger r = n % baseNum;
            result = r.ToString() + result;
            n /= baseNum;
        }
        return result;
    }

    public static bool IsPalindrome(string s)
    {
        int low = 0, high = s.Length - 1;
        while (low < high)
        {
            if (s[low] != s[high]) return false;
            low++;
            high--;
        }
        return true;
    }
}
