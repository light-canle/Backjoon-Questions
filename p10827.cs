using System;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');

        string a = input[0];
        int b = int.Parse(input[1]);

        int dotPos = a.IndexOf('.');

        BigInteger numPart = BigInteger.Parse(a.Substring(0, dotPos) + a.Substring(dotPos + 1));

        int e = (a.Length - dotPos - 1) * b;

        BigInteger pow = BigInteger.Pow(numPart, b);

        string result = pow.ToString();

        if (result.Length <= e)
        {
            result = result.PadLeft(e + 1, '0');
        }
        Console.WriteLine(result.Substring(0, result.Length - e) + "." + result.Substring(result.Length - e));
    }
}  
