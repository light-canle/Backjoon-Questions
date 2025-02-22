using System;

// p16396 - 선 그리기 (B1)
// #구현
// 2025.2.22 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        bool[] filled = new bool[10001];
        for (int i = 0; i < n; i++)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            // from부터 to-1까지 true로 바꿈
            int from = range[0];
            int to = range[1];
            for (int j = from; j < to; j++)
            {
                filled[j] = true;
            }
        }
        // true인 것의 개수를 센다
        int count = 0;
        for (int i = 1; i < 10001; i++)
        {
            if (filled[i])
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}
