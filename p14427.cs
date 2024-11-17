using System;
using System.Linq;
using System.Text;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());

        int[] A = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int m = int.Parse(sr.ReadLine());
        int[] tree = new int[4 * n];
        Init(A, tree, 1, 0, n - 1);
        StringBuilder output = new();
        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int a = line[0];
            
            if (a == 1)
            {
                int b = line[1];
                int c = line[2];
                A[b - 1] = c;
                Change(tree, A, 0, n - 1, 1, b - 1);
            }
            else
            {
                output.AppendLine((tree[1] + 1).ToString());
            }
        }
        Console.WriteLine(output);
        sr.Close();
    }

    public static int Init(int[] A, int[] tree, int node, int start, int end)
    {
        if (start == end)
        {
            return tree[node] = start;
        }
        int mid = (start + end) / 2;
        int left = Init(A, tree, 2 * node, start, mid);
        int right = Init(A, tree, 2 * node + 1, mid + 1, end);
        return tree[node] = A[left] > A[right] ? right : left;
    }
    
    public static int Change(int[] tree, int[] A, int start, int end, int node, int index)
    {
        if (index < start || index > end) return tree[node];
        if (start == end) 
        {
            return tree[node];
        }
        int mid = (start + end) / 2;
        int left = Change(tree, A, start, mid, 2 * node, index);
        int right = Change(tree, A, mid + 1, end, 2 * node + 1, index);
        return tree[node] = A[left] > A[right] ? right : left;
    }
}
