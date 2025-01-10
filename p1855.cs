using System;

public class Program
{
    public static void Main(string[] args)
    {
        int k = int.Parse(Console.ReadLine());
        string str = Console.ReadLine();

        int len = str.Length;
        int row = len / k;
        char[,] arr = new char[row, k];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < k; j++)
            {
                if (i % 2 == 0)
                {
                    arr[i, j] = str[i * k + j];
                }
                else
                {
                    arr[i, k - j - 1] = str[i * k + j];
                }
            }
        }

        string ret = "";

        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < row; j++)
            {
                ret += arr[j, i];
            }
        }
        Console.WriteLine(ret);
    }
}
