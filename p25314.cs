using System;
using System.Text;

/// <summary>
/// p25314 - 코딩은 체육과목 입니다, B5
/// 해결 날짜 : 2024/3/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine()!);

        StringBuilder output = new StringBuilder();
        for (int i = 0; i < size / 4; i++)
        {
            output.Append("long ");
        }

        Console.WriteLine(output.ToString() + "int");
    }
}