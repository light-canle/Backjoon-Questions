using System;

// p2669 - 직사각형 네개의 합집합의 면적 구하기 (S5)
// #구현
// 800th solved problem
// 2025.4.6 solved

public class Program
{
    public static void Main(string[] args)
    {
        bool[,] filled = new bool[101, 101];

        for (int i = 0; i < 4; i++)
        {
            int[] rect = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            for (int y = rect[1]; y < rect[3]; y++)
            {
                for (int x = rect[0]; x < rect[2]; x++)
                {
                    filled[y, x] = true;
                }
            }
        }

        int area = 0;
        for (int y = 0; y <= 100; y++)
        {
            for (int x = 0; x <= 100; x++)
            {
                if (filled[y, x]) area++;
            }
        }
        Console.WriteLine(area);
    }
}
