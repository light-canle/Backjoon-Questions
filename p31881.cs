using System;
using System.IO;
using System.Text;

// p31881 - K512에 바이러스 퍼뜨리기 (B2)
// #시뮬레이션
// 2025.2.23 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new();
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], q = input[1];
        bool[] infected = new bool[n + 1];
        int infectedCount = 0;
        for (int i = 0; i < q; i++)
        {
            int[] query = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            if (query[0] == 1)
            {
                if (!infected[query[1]]) infectedCount++;
                infected[query[1]] = true;
            }
            else if (query[0] == 2)
            {
                if (infected[query[1]]) infectedCount--;
                infected[query[1]] = false;
            }
            else
            {
                output.AppendLine((n - infectedCount).ToString());
            }
        }
        Console.Write(output);
        sr.Close();
    }
}
