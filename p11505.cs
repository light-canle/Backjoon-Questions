using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

public class Program
{
    public static int K = 1_000_000_007;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int N, int M, int K) = (input[0], input[1], input[2]);

        BigInteger[] A = new BigInteger[N];
        for (int i = 0; i < N; i++)
        {
            A[i] = BigInteger.Parse(sr.ReadLine());
        }
        BigInteger[] tree = new BigInteger[4 * N];
        Init(A, tree, 1, 0, N - 1);

        StringBuilder output = new();
        for (int i = 0; i < M + K; i++)
        {
            long[] line = sr.ReadLine().Split().Select(long.Parse).ToArray();
            int a = (int)line[0];
            int b = (int)line[1];
            long c = line[2];

            if (a == 1)
            {
                BigInteger cur = A[b - 1];
                Change(tree, 0, N - 1, 1, b - 1, cur, c);
                A[b - 1] = c;
            }
            else
            {
                output.AppendLine(PartProduct(tree, 0, N - 1, 1, b - 1, (int)c - 1).ToString());
            }
        }
        Console.WriteLine(output);
        sr.Close();
    }

    public static BigInteger Init(BigInteger[] A, BigInteger[] tree, int node, int start, int end)
    {
        if (start == end)
        {
            return tree[node] = A[start] % K;
        }
        int mid = (start + end) / 2;
        return tree[node] = ((Init(A, tree, node * 2, start, mid) % K) * (Init(A, tree, node * 2 + 1, mid + 1, end) % K)) % K;
    }
    public static BigInteger PartProduct(BigInteger[] tree, int start, int end, int node, int left, int right)
    {
        if (left > end || right < start) return 1;
        if (left <= start && end <= right) return tree[node] % K;
        int mid = (start + end) / 2;
        return ((PartProduct(tree, start, mid, node * 2, left, right) % K) * (PartProduct(tree, mid + 1, end, node * 2 + 1, left, right) % K)) % K;
    }
    public static BigInteger Change(BigInteger[] tree, int start, int end, int node, int index, BigInteger prev, BigInteger value)
    {
        if (index < start || index > end) return tree[node];
        if (start == end) 
        {
            return tree[node] = value % K;
        }
        int mid = (start + end) / 2;
        return tree[node] = ((Change(tree, start, mid, node * 2, index, prev, value) % K) * (Change(tree, mid + 1, end, node * 2 + 1, index, prev, value) % K)) % K;
    }
}
