using System;

// p5691 - 평균 중앙값 문제 (B3)
// #사칙연산
// 2025.3.12 solved

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            int[] line = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int a = line[0], b = line[1];
            if (a == 0 && b == 0)
            {
                break;
            }
            int diff = b - a;
            Console.WriteLine(a - diff);
        }
    }
}
