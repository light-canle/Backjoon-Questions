using System;
using System.Linq;
using System.Text;

/// <summary>
/// p15651 - N과 M(3), S3
/// 해결 날짜 : 2023/11/2
/// </summary>

// N개 중 M개를 나열한 모든 중복 순열을 출력하는 문제
public class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        (int N, int M) = (input[0], input[1]);

        int[] list = Enumerable.Range(1, N).ToArray();
        bool[] visited = new bool[list.Length];
        int[] output = new int[N];
        StringBuilder str = new StringBuilder();

        RepeatPermutation(list, output, 0, N, M, str);

        Console.WriteLine(str);
    }

    public static void RepeatPermutation(int[] list, int[] outlist, int depth, int n, int k, StringBuilder str)
    {
        // k개를 모두 받은 경우 출력한다.
        if (k == depth)
        {
            printArr(outlist, k, str);
            return;
        }

        for (int i = 0; i < n; i++)
        {
            // 중복 순열이므로, 이미 방문했는지 여부는 중요하지 않다.
            outlist[depth] = list[i];
            RepeatPermutation(list, outlist, depth + 1, n, k, str);
        }
    }

    public static void printArr(int[] list, int k, StringBuilder str)
    {
        for (int i = 0; i < k; i++)
        {
            str.Append(list[i] + " ");
        }
        str.AppendLine();
    }
}