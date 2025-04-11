using System;

// p10829 - 이진수 변환 (B2)
// #수학
// 2025.4.11 solved

public class Program
{
    public static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());
        string ret = "";
        while (n > 0)
        {
            ret += n % 2 == 0 ? "0" : "1";
            n /= 2;
        }
        ret = new string(ret.Reverse().ToArray());
        Console.WriteLine(ret);
    }
}
