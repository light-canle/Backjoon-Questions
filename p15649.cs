using System;
using System.Linq;
using System.Text;

/// <summary>
/// p15649 - N과 M (1), S3
/// 해결 날짜 : 2023/10/9
/// </summary>

// N개 중 M개를 나열한 모든 순열을 출력하는 문제
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
        
        permutation(list, visited, output, 0, N, M, str);

        Console.WriteLine(str);
    }

    public static void permutation(int[] list, bool[] visited, int[] outlist, int depth, int n, int k, StringBuilder str)
    {
        // 순열에 들어갈 k개를 모두 선택함
        if (k == depth)
        {
            printArr(outlist, k, str);
            return;
        }

        for (int i = 0; i < n; i++)
        {
            // 현재 원소가 선택되지 않은 경우
            if (!visited[i])
            {
                visited[i] = true;
                // 순열에 이 원소를 추가
                outlist[depth] = list[i];
                // 순열의 다음 원소를 찾으러 감
                permutation(list, visited, outlist, depth + 1, n, k, str);
                // 이후 순열에서는 이 원소를 뺀다
                visited[i] = false;
            }
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