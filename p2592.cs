#pragma warning disable CS8604, CS8602, CS8600

using System;

// p2592 - 대표값 (B2)
// #수학
// 2025.12.13 solved (12.12)

public class Program
{
    public static void Main(string[] args)
    {
        int sum = 0;
        int[] times = new int[100];
        for (int i = 0; i < 10; i++)
        {
            int n = int.Parse(Console.ReadLine());
            times[n/10]++;
            sum += n;
        }
        Console.WriteLine(sum / 10);
        int most = 0, mostValue = 0;
        for (int i = 0; i < 100; i++)
        {
            if (times[i] > mostValue)
            {
                mostValue = times[i]; 
                most = i * 10;
            }
        }
        Console.WriteLine(most);
    }
}
