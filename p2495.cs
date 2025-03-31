using System;

// p2495 - 연속구간 (B2)
// #문자열
// 2025.3.31 solved

public class Program
{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 3; i++)
        {
            string num = Console.ReadLine();

            char prev = num[0];
            int chain = 1;
            int maxChain = 1;
            int len = num.Length;
            for (int j = 1; j < len; j++)
            {
                if (prev != num[j])
                {
                    maxChain = Math.Max(maxChain, chain);
                    chain = 1;
                }
                else
                {
                    chain++;
                }
                prev = num[j];
            }
            maxChain = Math.Max(maxChain, chain);
            Console.WriteLine(maxChain);
        }
    }
}
