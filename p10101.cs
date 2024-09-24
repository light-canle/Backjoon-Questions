using System;

/// <summary>
/// p10101 - 삼각형 외우기, B4
/// 해결 날짜 : 2023/9/6
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        if (a + b + c != 180)
        {
            Console.WriteLine("Error");
        }
        else if (a == b && a == c)
        {
            Console.WriteLine("Equilateral");
        }
        else if (a == b || a == c || b == c)
        {
            Console.WriteLine("Isosceles");
        }
        else
        {
            Console.WriteLine("Scalene");
        }
    }
}