#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Text;

// p28438 - 행렬 연산 (행렬 계산하기) (S3)
// #애드 혹
// 2025.11.7 solved (11.6)

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new();
        int[] size = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int n = size[0], m = size[1], q = size[2];

        int[,] matrix = new int[n, m];
        // 각 행과 열에 누적될 합
        int[] rowSum = new int[n];
        int[] columnSum = new int[m];
        for (int i = 0; i < q; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int queryNum = line[0], order = line[1], value = line[2];
            switch (queryNum)
            {
                case 1:
                    rowSum[order - 1] += value;
                    break;
                case 2:
                    columnSum[order - 1] += value;
                    break;
            }
        }
        // 누적시킨 합을 각 행과 열에 속한 수에 대해 적용
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] += rowSum[i];
                matrix[i, j] += columnSum[j];
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                output.Append(matrix[i, j]);
                if (j != m - 1) output.Append(" ");
            }
            output.AppendLine();
        }
        sw.WriteLine(output);
        sw.Flush();
    }
}
