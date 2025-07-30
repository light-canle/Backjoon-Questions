using System;

// p23795 - 사장님 도박은 재미로 하셔야 합니다 (B4)
// #사칙연산
// 2025.7.30 solved

public class Program
{
    public static void Main(string[] args)
    {
        int sum = 0;
        while (true)
        {
            int n = int.Parse(Console.ReadLine()!);
            if (n == -1) break;
            sum += n;
        }
        Console.WriteLine(sum);
    }
}
