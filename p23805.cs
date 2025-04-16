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
        // 전체를 5x5부분으로 나눈다.
        // 각 부분의 크기는 n×n이다.
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                // 1, 3, 5번째 열은 @를 출력한다.
                if (j % 2 == 0)
                {
                    Fill(arr, i * n, j * n, n);
                }
                // 2번째 열은 1번 행에만, 4번째 열은 5번 행에만 @를 출력한다.
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

    // i, j부터 size×size 크기로 true를 채운다.
    public static void Fill(bool[,] arr, int i, int j, int size)
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
