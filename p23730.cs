using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int n = input[0], m = input[1];
        List<int> answer = sr.ReadLine().Split().Select(int.Parse).ToList();
        List<int> correct = sr.ReadLine().Split().Select(int.Parse).ToList();
        int[] ansSheet = new int[n];
        for (int i = 0; i < m; i++)
        {
            int index = correct[i] - 1;
            ansSheet[index] = answer[index];
        }

        for (int i = 0; i < n; i++)
        {
            if (ansSheet[i] != 0)
            {
                continue;
            }
            for (int choice = 1; choice <= 5; choice++)
            {
                if (i != 0 && ansSheet[i - 1] == choice)
                {
                    continue;
                }
                if (i != n - 1 && ansSheet[i + 1] == choice)
                {
                    continue;
                }
                if (answer[i] == choice)
                {
                    continue;
                }
                ansSheet[i] = choice;
                break;
            }
        }
        sw.WriteLine(string.Join(" ", ansSheet));
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
