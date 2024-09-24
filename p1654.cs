using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p1654 - 랜선 자르기, S2
/// 해결 날짜 : 2023/8/29
/// 힌트를 보고 해결
/// </summary>

/*
이분 탐색을 이용해서 최댓값을 찾는 문제
https://www.acmicpc.net/board/view/120865 글을 참고해서 해결했다.
이분 탐색의 특성과 오버플로우 문제 때문에 해결하는 데 고생을 했고,
결국에는 질문방을 참조해야 했다.

교훈
1. 정수 내에서 이분 탐색을 한 뒤, 나오는 2가지 답의 후보를 모두 검사해야 한다.
2. 값의 주어진 범위가 int일지라도, 계산 과정에서 (특히 덧셈과 곱셈) 이 둘의 계산 결과가
int를 벗어나는지를 검사해야 한다. 만약 초과한다면 long, BigInteger를 반드시 사용한다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        long[] input = sr.ReadLine().Split().Select(x => long.Parse(x)).ToArray();

        // 이 문제에서 올 수 있는 랜선의 길이는 2^31 - 1의 int 범위이지만,
        // 중앙값을 구하기 위해 더하는 과정에서 오버플로우가 날 수 있으므로,
        // 그 가능성을 차단하기 위해 처음부터 모든 변수를 long으로 지정했다.
        List<long> list = new List<long>();
        for (long i = 0; i < input[0]; i++)
        {
            list.Add(long.Parse(sr.ReadLine()));
        }

        long requiredCount = input[1];

        long start = 1;
        long end = list.Max();

        // 답의 범위가 2개로 추려질 때까지 반복
        while (start + 1 < end)
        {
            // 중앙값 계산
            long middle = (start + end) / 2;

            if (IsSuitable(list, middle, requiredCount))
            {
                start = middle;
            }
            else
            {
                end = middle;
            }
        }

        // 힌트를 받은 부분
        // 이분 탐색을 통해 답 후보를 줄여나가면, 답의 후보는 2개로 추려진다.(start, end가 1차이가 남)
        // 이때, end도 답이 될 가능성이 있기 때문에, start를 그대로 출력하지 말고,
        // end가 충족하는 답인지를 먼저 검사해야 한다.
        if (IsSuitable(list, end, requiredCount))
        {
            Console.WriteLine($"{end}");
        }
        else
        {
            Console.WriteLine($"{start}");
        }

        sr.Close();
    }

    // 해당 수(n)가 문제의 조건(해당 길이로 랜선을 잘랐을 때 N개가 나오는가?)을 만족시키는 지 검사한다.
    public static bool IsSuitable(List<long> list, long n, long requiredCount)
    {
        long numOfLAN = 0;
        for (int i = 0; i < list.Count; i++) 
        {
            numOfLAN += list[i] / n;
        }

        if (numOfLAN >= requiredCount) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
