using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p17390 - 이건 꼭 풀어야 해! (S3)
// #누적 합 #정렬
// 2025.7.31 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int[] size = Array.ConvertAll(sr.ReadLine().Trim().Split(), int.Parse);
        int n = size[0], q = size[1];
        List<int> arr = sr.ReadLine().Trim().Split().Select(int.Parse).ToList();
        arr.Sort();
        // 누적합 배열 생성
        int[] prefix = new int[n + 1];
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += arr[i];
            prefix[i + 1] = sum;
        }
        for (int i = 0; i < q; i++)
        {
            int[] range = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int l = range[0], r = range[1];
            // l번째 부터 r번째 요소의 합 출력
            sw.WriteLine(prefix[r] - prefix[l - 1]);
        }
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
