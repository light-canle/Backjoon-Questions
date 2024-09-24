using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1052 - 물병, G5
/// 해결 날짜 : 2024/4/6
/// </summary>

/*
이 문제는 N을 k개의 2의 제곱들의 합으로 표현할 수 있는지를 판단하고,
그럴 수 없다면 N에 더했을 때 k개의 2의 제곱들의 합으로 나타낼 수 있도록 하는 최소의 수를 구하는 문제이다.
그래서 N을 받은 뒤, 현재 N보다 작은 최대의 2의 제곱들을 찾아 합에 누적한 뒤 N에 차감하는 방식을 사용한다.
그런 뒤, k개의 2의 제곱들로 N을 구성할 수 있다면 0을, 그렇지 않다면 k개의 제곱들 중 최소인 것에 2를 곱하면
합이 N보다 커지게 될 것인데, 그렇게 해서 만들어진 새로운 합에 원래 N을 뺀다면 더해야 할 최소의 수를 구할 수 있다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int[] nums = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        (int N, int k) = (nums[0], nums[1]);
        int first = N;

        // 1 ~ 2^23까지의 2의 제곱을 저장
        List<int> powOfTwo = new List<int>();
        int cur = 1;
        for (int i = 0; i <= 23; i++)
        {
            powOfTwo.Add(cur);
            cur *= 2;
        }
        powOfTwo.Reverse();

        // 현재 N보다 작은 최대의 2의 제곱수를 구해서 N을 차감한다.
        int sum = 0, smallest = 0;
        for (int i = 0; i < k; i++)
        {
            if (N == 0)
            {
                break;
            }
            for (int j = 0; j <= 23; j++) 
            {
                if (N >= powOfTwo[j])
                {
                    sum += powOfTwo[j];
                    smallest = powOfTwo[j];
                    N -= powOfTwo[j];
                    break;
                }
            }
        }
        // N을 구성할 수 있으면 0을, 아닌 경우 smallest를 2배로 만들어 준 뒤
        // 합에서 기존의 N을 뺀 것을 출력한다.
        if (N == 0)
            Console.WriteLine(0);
        else
        {
            Console.WriteLine(sum + smallest - first);
        }
    }
}