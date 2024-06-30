using System;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        
        BigInteger[] input = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
        BigInteger A = input[0];
        BigInteger B = input[1];
        Console.WriteLine(A * B);
    }
}
