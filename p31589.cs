using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p31589 - 포도주 시음, S3
/// 해결 날짜 : 2024/3/11
/// </summary>

/*
문제의 조건에 따라 포도주 맛을 극대화 하기 위해서는 가장 높은 맛의 포도주 시음 
-> 가장 낮은 맛의 포도주 시음 -> 남은 것 중 가장 높은 것을 마신 뒤 가장 낮은 것을 마심
이런 식으로 K개에 대해 반복하면 구할 수 있다.
리스트 정렬 뒤, 두 포인터를 사용해서 번갈아가며 가장 큰 것, 가장 작은 것을 가져오는 그리디 알고리즘 문제
*/

public class Program
{

    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        // input
        int[] input = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
        (int N, int K) = (input[0], input[1]);
        List<int> list = sr.ReadLine()!.Split().Select(int.Parse).ToList();
        list.Sort();

        int low = 0, high = list.Count - 1;
        int cur = 0;

        int prev = 0;
        long taste = 0;
        while (cur < K)
        {
            cur++;
            if (cur % 2 == 1)
            {
                taste += list[high] - prev;
                prev = list[high];
                high--;
            }
            else
            {
                taste += (list[low] - prev > 0) ? list[low] - prev : 0;
                prev = list[low];
                low++;
            }
        }

        Console.WriteLine(taste);
    }
}