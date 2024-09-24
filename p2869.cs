using System;
using System.Linq;

/// <summary>
/// p2869 - 달팽이는 올라가고 싶다, B1
/// 해결 날짜 : 2023/8/28
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] inputs = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

        int A = inputs[0];
        int B = inputs[1];
        int V = inputs[2];

        Console.WriteLine((int)Math.Ceiling((double)(V - A) / (A - B)) + 1);
    }
}
