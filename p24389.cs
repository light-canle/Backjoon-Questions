using System;

// p24389 - 2의 보수 (B1)
// #비트마스킹
// 2025.5.2 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int complement = -n;

        int diff = 0;
        // 32개의 비트를 각각 비교하여 다르면 diff에 1을 더함
        for (int i = 0; i < 32; i++)
        {
            uint bit = 1u << i;
            if (((n & bit) ^ (complement & bit)) != 0)
            {
                diff += 1;
            }
        }
        Console.WriteLine(diff);
    }
}
