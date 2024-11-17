using System;
using System.Linq;
using System.Text;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int n = input[0], m = input[1];
        int[] A = new int[n];

        for (int i = 0; i < n; i++)
        {
            A[i] = int.Parse(sr.ReadLine());
        }
        int[] treeMin = new int[4 * n];
        int[] treeMax = new int[4 * n];
        Init(A, treeMin, 1, 0, n - 1);
        Init(A, treeMax, 1, 0, n - 1, true);
        StringBuilder output = new();
        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int a = line[0];
            int b = line[1];

            int min = Query(treeMin, 1, 0, n - 1, a - 1, b - 1, false);
            int max = Query(treeMax, 1, 0, n - 1, a - 1, b - 1, true);
            output.AppendLine($"{min} {max}");
        }
        Console.WriteLine(output);
        sr.Close();
    }

    public static int Init(int[] A, int[] tree, int node, int start, int end, bool isMax = false)
    {
        if (start == end)
        {
            return tree[node] = A[start];
        }
        int mid = (start + end) / 2;
        int left = Init(A, tree, 2 * node, start, mid, isMax);
        int right = Init(A, tree, 2 * node + 1, mid + 1, end, isMax);
        return tree[node] = isMax ? Math.Max(left, right) : Math.Min(left, right);
    }

    public static int Query(int[] tree, int node, int start, int end, int left, int right, bool isMax)
    {
        if (left > end || right < start) return isMax ? int.MinValue : int.MaxValue;
        if (left <= start && end <= right) return tree[node];
        int mid = (start + end) / 2;
        int leftValue = Query(tree, 2 * node, start, mid, left, right, isMax);
        int rightValue = Query(tree, 2 * node + 1, mid + 1, end, left, right, isMax);
        return isMax ? Math.Max(leftValue, rightValue) : Math.Min(leftValue, rightValue);
    }
}
