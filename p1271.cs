using System;
using System.Linq;
using System.Numerics;

/// <summary>
/// p1271 - 엄청난 부자2, B5
/// 해결 날짜 : 2023/9/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        BigInteger[] input = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();

        Console.WriteLine(input[0] / input[1]);
        Console.WriteLine(input[0] % input[1]);
    }
}