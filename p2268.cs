using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        int[] size = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = size[0];
        int m = size[1];
        long[] arr = new long[n];
        List<long> segTree = new List<long>(new long[4 * n]);
        StringBuilder output = new StringBuilder();
        for (int t = 0; t < m; t++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int mode = line[0], i = line[1], j = line[2];
            switch (mode)
            {
            case 0:
                if (i > j)
                {
                    int temp = i;
                    i = j;
                    j = temp;
                }
                output.AppendLine(PartSum(segTree, 0, n - 1, 1, i - 1, j - 1).ToString());
                break;
            case 1:
                long cur = arr[i - 1];
                Update(segTree, 1, 0, n - 1, i - 1, (long)j - cur);
                arr[i - 1] = j;
                break;
            }
        }

        sw.WriteLine(output);
        sw.Flush();
        sr.Close();
        sw.Close();
    }

    public static void Update(List<long> segTree, int node, int start, int end, int index, long value)
    {
        if (index < start || end < index) return;
        segTree[node] += value;
        if (start == end) return;
        int mid = (start + end) / 2;
        Update(segTree, node * 2, start, mid, index, value);
        Update(segTree, node * 2 + 1, mid + 1, end, index, value);
    }

    public static long PartSum(List<long> segTree, int start, int end, int node, int left, int right)
    {
        if (left > end || right < start) return 0;
        if (left <= start && end <= right) return segTree[node];
        int mid = (start + end) / 2;
        return PartSum(segTree, start, mid, node * 2, left, right) + PartSum(segTree, mid + 1, end, node * 2 + 1, left, right);
    }
}
