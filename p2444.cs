using System;
using System.Text;

/// <summary>
/// p2444 - 별 찍기 - 7 - B3
/// 해결 날짜 : 2023/10/10
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        StringBuilder output = new StringBuilder();

        for (int i = 1; i <= N; i++)
        {
            string line = new string(' ', N - i)+
                          new string('*', 2 * i - 1);
            output.AppendLine(line);
        }
        for (int i = N - 1; i > 0; i--)
        {
            string line = new string(' ', N - i) +
                          new string('*', 2 * i - 1);
            output.AppendLine(line);
        }
        Console.WriteLine(output);
    }
}