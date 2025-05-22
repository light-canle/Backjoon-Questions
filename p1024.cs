using System;
using System.Collections.Generic;

// p1024 - 수열의 합 (S2)
// #완전 탐색 #수학
// 2025.5.22 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = input[0]; // 합
        int l = input[1]; // 리스트 최소 길이

        // 실수(real) 형태로 치환
        decimal N = (decimal)n;

        // 정답 리스트의 길이
        int ansLen = -1;
        List<int> ret = new();
        // 길이를 l부터 100까지 대입
        for (int len = l; len <= 100; len++)
        {
            /*
            연속된 정수 l개의 합이 n일때,
            그들의 평균은 n / l이 된다.
            1. l이 짝수일 때
            l이 짝수일 때 합이 n이 되는 연속적인 정수의 리스트가 존재하려면 n / l이 반정수여야한다.
            예시로 n = 18, l = 4일때,
            3 4 5 6이 만족하는 정수 리스트인데, 이때 평균은 4.5이다.
            평균이 반정수 a인 길이 l인 정수 리스트는 a + 0.5부터 시작해 1씩 커지는 l/2개의 정수, a - 0.5부터 시작해 1씩 작아지는 l/2개의 정수로 이루어진다.
            2. l이 홀수일 때
            l이 짝수일 때 합이 n이 되는 연속적인 정수의 리스트가 존재하려면 n / l이 정수여야한다.
            예시로 n = 20, l = 5일때,
            2 3 4 5 6이 만족하는 정수 리스트인데, 이때 평균은 4이다.
            평균이 정수 a인 길이 l인 정수 리스트는 a + 1부터 시작해 1씩 커지는 (l-1)/2개의 정수, a - 1부터 시작해 1씩 작아지는 (l-1)/2개의 정수와 a로 이루어진다.
            문제의 조건에서 음이 아닌 정수 리스트를 요구했으므로, 가장 작은 정수가 0 이상인지를 체크해야 한다.
            */
            decimal avg = N / len;
            if (len % 2 == 0)
            {
                if (avg - (int)avg == 0.5m && (int)avg - (len / 2 - 1) >= 0)
                {
                    for (int j = 0; j < len / 2; j++)
                    {
                        ret.Add((int)avg - j);
                    }
                    for (int j = 0; j < len / 2; j++)
                    {
                        ret.Add((int)avg + 1 + j);
                    }
                    ansLen = len;
                    break;
                }
                
            }
            else
            {
                if (avg - (int)avg == 0.0m && (int)avg - (len / 2) >= 0)
                {
                    for (int j = 1; j <= len / 2; j++)
                    {
                        ret.Add((int)avg - j);
                    }
                    for (int j = 1; j <= len / 2; j++)
                    {
                        ret.Add((int)avg + j);
                    }
                    ret.Add((int)avg);
                    ansLen = len;
                    break;
                } 
            }
        }
        if (ansLen != -1)
        {
            ret.Sort();
            Console.WriteLine(string.Join(" ", ret));
        }
        else
        {
            Console.WriteLine(ansLen);
        }
    }
}
