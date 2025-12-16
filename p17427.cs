#pragma warning disable CS8604, CS8602, CS8600

using System;

// p17427 - 약수의 합 2 (S2)
// #정수론
// 2025.12.16 solved

public class Program
{
    public static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());

        long sum = 0;
        // 1부터 n까지 각각의 수의 약수의 합을 모두 더한다.
        for (long i = 1; i <= n; i++)
        {
            // i부터 n 이하의 i의 배수들은 모두 i를 약수로 가지고 있기 때문에,
            // 배수의 개수만큼 i를 누적시키면 된다.
            sum += i * (n / i);
        }
        Console.WriteLine(sum);
    }
}
