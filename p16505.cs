#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Text;

// p16505 - 별 (S1)
// #구현 #재귀
// 2025.11.9 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new();
        int n = int.Parse(Console.ReadLine());

        int size = (int)Math.Pow(2, n);
        bool[,] array = new bool[size, size];
        Fill(array, 0, 0, size);

        for (int i = size; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                output.Append(array[size - i, j] ? '*' : ' ');
            }
            output.AppendLine();
        }
        sw.WriteLine(output);
        sw.Close();
    }

    public static void Fill(bool[,] array, int y, int x, int size)
    {
        if (size == 1)
        {
            array[y, x] = true;
            return;
        }
        int half = size / 2;
        Fill(array, y, x, half);
        Fill(array, y, x + half, half);
        Fill(array, y + half, x, half);
    }
}
