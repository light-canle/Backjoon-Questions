using System;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        StringBuilder output = new StringBuilder();

        for (int i = 1; i <= N; i++)
        {
            if (i == 1)
                output.AppendLine(new string(' ', N - i) + "*");
            else
                output.AppendLine(new string(' ', N - i) + "*" + new string(' ', i * 2 - 3) + "*");
        }
        Console.WriteLine(output);
    }
}
