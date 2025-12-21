#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;

// p11508 - 2+1 세일 (S4)
// #정렬 #그리디
// 2025.12.22 solved (12.21)

// 최소 가격을 구하려면 비싼 물건들을 무료로 받으면 되는데, 가격을 내림차순 정렬 후 3개씩 묶으면
// 그 묶음에서 3번째 물건은 무료가 된다. 이렇게 하면 비싼 순으로 무료가 되므로 가격이 최소가 된다.

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());

        List<int> prices = new();
        for (int i = 0; i < n; i++)
        {
            prices.Add(int.Parse(sr.ReadLine()));
        }
        // 역순 정렬
        prices.Sort(); prices.Reverse();
        long sum = 0;
        // 3개씩 묶어서 마지막 것은 무료가 된다.
        for (int i = 0; i < n; i++)
        {
            if (i % 3 != 2) sum += prices[i];
        }
        Console.WriteLine(sum);
    }
}
