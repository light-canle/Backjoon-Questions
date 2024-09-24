using System;
using System.Linq;

/// <summary>
/// p11055 - 가장 큰 증가하는 부분 수열, S2
/// 해결 날짜 : 2024/4/6
/// </summary>

/*
p11053(가장 긴 증가하는 부분 수열)과 비슷한 문제로 이 문제에서 사용한 코드를 약간 변형했다.
이 문제의 경우 증가하는 부분 수열을 찾는 것은 같으나 그 수열을 이루는 수들의 합이 제일 큰 것을 원한다.
그래서 p11053과 구조는 같으나 dp에 길이가 아닌 이전까지의 수들의 합에 현재 수를 더한 것을 저장해 놓는다는 차이가 있다.
+ 1이 들어가는 것이 아닌 + numbers[i]가 들어간다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()!);

        var numbers = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int[] LISSum = new int[N];
        for (int i = 0; i < N; i++)
        {
            if (i == 0) LISSum[i] = numbers[i];
            else
            {
                int previousMax = 0;

                for (int j = 0; j < i; j++)
                {
                    if (previousMax < LISSum[j] && numbers[i] > numbers[j])
                    {
                        previousMax = LISSum[j];
                    }
                }
                LISSum[i] = previousMax + numbers[i];
            }
        }
        Console.WriteLine(LISSum.Max());
    }
}