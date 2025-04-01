using System;
using System.Numerics;
using System.Linq;

// p2729 - 이진수 덧셈 (B1)
// #사칙연산
// 2025.4.1 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] nums = Console.ReadLine().Split();
            BigInteger n1 = Convert(nums[0]);
            BigInteger n2 = Convert(nums[1]);
            Console.WriteLine(Bin(n1 + n2));
        }
    }

    public static BigInteger Convert(string num)
    {
        char[] rev = num.Reverse().ToArray();

        BigInteger mul = 1;
        BigInteger ret = 0;
        foreach (char c in rev)
        {
            ret += c == '1' ? mul : 0;
            mul *= 2;
        }
        return ret;
    }

    public static string Bin(BigInteger b)
    {
        if (b == 0) return "0";
        string ret = "";
        while (b > 0)
        {
            ret += (b % 2).ToString();
            b /= 2;
        }
        return new string(ret.Reverse().ToArray());
    }
}
