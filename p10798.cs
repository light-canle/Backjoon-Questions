using System;
using System.Linq;
using System.Text;

/// <summary>
/// p10798 - 세로읽기, B1
/// 해결 날짜 : 2024/3/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        char[,] list = new char[5, 15];
        for (int i = 0; i < 5; i++)
        {
            string input = Console.ReadLine()!;
            
            for (int j = 0; j < input.Length; j++)
            {
                list[i,j] = input[j];
            }
        }

        StringBuilder output = new StringBuilder();

        for (int j = 0; j < 15; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                if (list[i, j] != '\0')
                    output.Append(list[i,j]);
            }
        }

        Console.WriteLine(output);
    }
}