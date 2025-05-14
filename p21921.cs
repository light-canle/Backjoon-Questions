using System;
using System.IO;

// p21921 - 블로그 (S3)
// #누적 합 #슬라이딩 윈도우
// 2025.5.14 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], x = input[1];
        long[] num = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

        long[] prefix = new long[n + 1];
        // 누적 합 저장
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += num[i];
            prefix[i + 1] = sum;
        }

        // 아무도 방문을 안 함
        if (prefix[n] == 0)
        {
            Console.WriteLine("SAD");
            return;
        }
        // 연속 된 x일 동안의 블로그 방문 수의 최대를 구함
        long maxIncomer = 0; // 최대 방문자 수
        int count = 0; // 그것을 달성한 기간 수
        for (int i = x - 1; i < n; i++)
        {
            long periodSum = prefix[i + 1] - prefix[i - x + 1];
            if (periodSum > maxIncomer)
            {
                maxIncomer = periodSum;
                count = 1;
            }
            else if (periodSum == maxIncomer)
            {
                count++;
            }
        }
        Console.WriteLine(maxIncomer);
        Console.WriteLine(count);
        sr.Close();
    }
}
