using System;
using System.IO;

// p13900 - 순서쌍의 곱의 합 (S4)
// #누적 합
// 2025.5.13 solved

public class Program
{
    public static List<List<int>> score;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        long[] num = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

        long[] prefix = new long[n + 1];
        // 누적 합 저장
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += num[i];
            prefix[i + 1] = sum;
        }

        /* 
        구하는 곱들의 합은 경우의 수가 최대 100000*99999 / 2가지 이므로 완전 탐색으로는 안된다.
        i번째 원소에 대하여 i+1, i+2 ..., n번째 원소와 곱한 것들의 합은 i번째 원소와 그 뒤의 요소 모두를 곱한 것과 같고,
        이는 (prefix[n] - prefix[i+1]) * num[i]로 나타낼 수 있다.
        부분합을 이용하면 O(n)에 원하는 답을 구할 수 있다.
        */
        long result = 0;
        for (int i = 0; i < n; i++)
        {
            long mul = prefix[n] - prefix[i + 1];
            result += mul * num[i];
        }
        Console.WriteLine(result);
        sr.Close();
    }
}
