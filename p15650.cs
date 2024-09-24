using System;
using System.Linq;
using System.Text;

/// <summary>
/// p15650 - N과 M(2), S3
/// 최초 해결 날짜 : 2020/9/4
/// 재풀이 날짜 : 2023/11/3
/// </summary>

// N개의 수중 M개로 이루어진 서로 다른 조합을 출력하는 문제
// 3년 전에 8중 반복문으로 푼 문제를 이번에 재귀를 이용해서 다시 풀었다.

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

        combination(list, visited, output, 0, N, M, 0, str);

        Console.WriteLine(str);
    }

    public static void combination(int[] list, bool[] visited, int[] outlist, int depth, int n, int k, int j, StringBuilder str)
    {
        // 조합에 들어갈 k개를 모두 선택함
        if (k == depth)
        {
            printArr(outlist, k, str);
            return;
        }

        for (int i = j; i < n; i++)
        {
            // 현재 조합에 선택되지 않은 경우
            if (!visited[i])
            {
                visited[i] = true;
                // 조합에 이 원소를 추가
                outlist[depth] = list[i];
                // 조합의 다음 원소를 찾으러 감 - 단 찾는 원소는 현재 원소 다음으로 제한
                combination(list, visited, outlist, depth + 1, n, k, i+1, str);
                // 이후 조합에서는 이 원소를 뺀다
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