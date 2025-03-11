using System;

// p2490 - 윷놀이 (B3)
// #구현
// 2025.3.11 solved

public class Program
{
    public static void Main(string[] args)
    {
        char[] result = {'D', 'C', 'B', 'A', 'E'};
        for (int i = 0; i < 3; i++)
        {
            int[] ret = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int countBack = 0;
            foreach (int num in ret)
            {
                if (num == 1)
                {
                    countBack++;
                }
            }
            Console.WriteLine(result[countBack]);
        }
    }
}
