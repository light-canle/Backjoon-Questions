using System;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger ret = BigInteger.Pow(10, n);
        for (int i = 0; i < n; i++)
        {
            ret /= 2;
        }
        string numPart = ret.ToString();
        string s = "0." + new string('0', n - numPart.Length) + numPart;
        Console.WriteLine(s);
    }
}
