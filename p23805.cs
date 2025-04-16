using System;
using System.IO;

// p23805 - 골뱅이 찍기 - 돌아간 ㄹ (B3)
// #구현
// 2025.4.16 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(Console.ReadLine());

        bool[,] arr = new bool[5 * n, 5 * n];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (j % 2 == 0)
                {
                    Fill(arr, i * n, j * n, n);
                }
                else if ((j == 1 && i == 0) || (j == 3 && i == 4))
                {
                    Fill(arr, i * n, j * n, n);
                }
            }
        }
        for (int i = 0; i < 5 * n; i++)
        {
            for (int j = 0; j < 5 * n; j++)
            {
                sw.Write(arr[i, j] ? "@" : " ");
            }
            sw.WriteLine();
        }
        sw.Flush();
        sw.Close();
    }

    public static void Fill(bool [,] arr, int i, int j, int size)
    {
        for (int y = i; y < i + size; y++)
        {
            for (int x = j; x < j + size; x++)
            {
                arr[y, x] = true;
            }
        }
    }
}
