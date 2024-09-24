using System;
using System.Linq;
using System.Text;

/// <summary>
/// p15652 - N과 M(4), S3
/// 해결 날짜 : 2023/11/3
/// </summary>

// N개 중에서 M개로 이루어진 서로 다른 중복 조합들을 출력하는 문제

public class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        (int N, int M) = (input[0], input[1]);

        int[] list = Enumerable.Range(1, N).ToArray();
        int[] output = new int[N];
        StringBuilder str = new StringBuilder();

        RepeatCombination(list, output, 0, N, M, 0, str);

        Console.WriteLine(str);
    }

    public static void RepeatCombination(int[] list, int[] outlist, int depth, int n, int k, int j, StringBuilder str)
    {
        // 중복 조합에 들어갈 k개를 모두 선택함
        if (k == depth)
        {
            printArr(outlist, k, str);
            return;
        }

        for (int i = j; i < n; i++)
        {
            // 중복 조합에 이 원소를 추가
            outlist[depth] = list[i];
            // 중복 조합의 다음 원소를 찾으러 감 - 단 찾는 원소는 현재 원소 다음으로 제한
            RepeatCombination(list, outlist, depth + 1, n, k, i, str);
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