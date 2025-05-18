using System;

// p25191 - 치킨댄스를 추는 곰곰이를 본 임스 (B4)
// #사칙연산
// 2025.5.18 solved

public class Program
{
    public static void Main(string[] args)
    {
        int limit = int.Parse(Console.ReadLine());
        int[] c = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int coke = c[0], beer = c[1];
        int canEat = coke / 2 + beer;
        Console.WriteLine(Math.Min(canEat, limit));
    }
}
