using System;
using System.Linq;

/// <summary>
/// p1407 - 2로 몇 번 나누어질까, G4
/// 시작 날짜 : 2023/9/13
/// </summary>

/*
아래 코드는 시간 초과가 나지만 작은 범위 안에서의 정답을 보장한다.
테스트 비교용으로 좋다.
using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Console.ReadLine().Split().Select(long.Parse).ToArray();
        (long min, long max) = (input[0], input[1]);
        long sum = 0;
        for (long i = min; i <= max; i++)
        {
            sum += GCD_PowerOf2(i);
        }
        Console.WriteLine(sum);
    }

    public static long GCD_PowerOf2(long num)
    {
        long ans = 1;
        while (num % 2 == 0)
        {
            num /= 2;
            ans *= 2;
        }
        return ans;
    }
}
*/
/*
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Console.ReadLine().Split().Select(long.Parse).ToArray();
        (long min, long max) = (input[0], input[1]);

        long countAll = max - min + 1;
        // 홀수의 개수
        long countOdd = countAll / 2 + (min % 2 == 1 ? 1 : 0);
        // 8로 나누었을 때 나머지가 4인 수의 개수
        long countmod4 = (min % 8 <= 4) ? 1 : 0;
        countmod4 += ((max - (max % 8)) - (min + 8 - (min % 8))) / 8;
        countmod4 += (max % 8 >= 4) ? 1 : 0;
        // 8로 나누었을 때 나머지가 2, 6인 수의 개수
        long countmod26 = (min % 8 > 6) ? 0 : (min % 8 > 2 ? 1 : 2);
        countmod26 += ((max - (max % 8)) - (min + 8 - (min % 8))) / 4;
        countmod26 += (max % 8 < 2) ? 0 : (max % 8 < 6 ? 1 : 2);

        long sum = countOdd * 1 + countmod26 * 2 + countmod4 * 4
            + SumOfDiv8(max) - SumOfDiv8(min - 1);
    }

    public static long SumOfDiv8(long num)
    {
        long sum = 0;

        long current = 8;
        long count = num / 8;
        for (int i = 3; i <= 49; i++)
        {
            //sum += current * count;
        }

        return sum;
    }
}
*/