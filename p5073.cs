using System;
using System.Linq;

/// <summary>
/// p5073 - 삼각형과 세 변, B3
/// 해결 날짜 : 2024/3/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            int[] pos = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            (int a, int b, int c) = (pos[0], pos[1], pos[2]);

            if (a == 0 && b == 0 && c == 0) return;

            if (a == b && b == c)
                Console.WriteLine("Equilateral");
            else if (Max(a, b, c) >= (a + b + c) - Max(a, b, c))
                Console.WriteLine("Invalid");
            else if (a == b || b == c || c == a)
                Console.WriteLine("Isosceles");
            else
                Console.WriteLine("Scalene");
        }
    }

    public static int Max(int a, int b, int c)
    {
        return Math.Max(Math.Max(a, b), c);
    }
}