using System;
using System.IO;

// p18221 - 교수님 저는 취업할래요 (S5)
// #기하학 #구현
// 2025.9.6 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        int[,] classroom = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int j = 0; j < n; j++)
            {
                classroom[i, j] = arr[j];
            }
        }

        int profY = -1, profX = -1;
        int seongY = -1, seongX = -1;
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (classroom[i, j] == 5)
                {
                    profY = i;
                    profX = j;
                }
                else if (classroom[i, j] == 2)
                {
                    seongY = i;
                    seongX = j;
                }
            }
        }

        int diffY = Math.Abs(profY - seongY);
        int diffX = Math.Abs(profX - seongX);

        int minX = Math.Min(seongX, profX);
        int maxX = Math.Max(seongX, profX);
        int minY = Math.Min(seongY, profY);
        int maxY = Math.Max(seongY, profY);
        
        int students = 0;
        for (int i = minY; i <= maxY; i++)
        {
            for (int j = minX; j <= maxX; j++)
            {
                if (classroom[i, j] == 1)
                {
                    students++;
                }
            }
        }

        if (diffX * diffX + diffY * diffY >= 25 && students >= 3)
        {
            Console.WriteLine(1);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}
