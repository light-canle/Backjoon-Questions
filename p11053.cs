using System;
using System.Linq;

/// <summary>
/// p11053 - 가장 긴 증가하는 부분 수열, S2
/// 해결 날짜 : 2024/4/5
/// </summary>

/*
알고리즘 참고 : https://4legs-study.tistory.com/106
LIS를 구하는 방법 중 DP를 사용하는 방법을 사용하였다.(길이만 필요함)
위의 사이트의 코드를 보지는 않아 그것과는 구현 방법이 다르다. 원래 LIS에서
dp[i]의 정의는 'i번째 인덱스에서 끝나는 LIS의 길이'인데 이 코드에서는 약간 
다르게 해석해서 dp[i]의 구성은 원본 코드와 다르나 정답은 도출한다.

이 코드에서는 dp[i]를 'i번째 인덱스 원소를 마지막으로 하는 수열 중 제일 긴 것'이다.
그래서 반복문 코드를 보면 LISLength 배열의 0 ~ i - 1번 인덱스를 순회하면서
(1)길이가 길면서 (2)제일 끝 원소(numbers[j])가 i번 인덱스의 값보다 작은 경우에만 previousMax에 저장한 뒤
LISLength[i]에는 previousMax + 1이 저장된다.
이렇게 되면 맨 마지막 원소에 LIS의 값이 들어간다는 보장이 없게 되므로
출력시 LISLength의 최댓값을 출력함으로써 LIS를 구하게 된다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()!);

        var numbers = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int[] LISLength = new int[N];
        for (int i = 0; i < N; i++)
        {
            if (i == 0) LISLength[i] = 1;
            else
            {
                int previousMax = 0;

                for (int j = 0; j < i; j++)
                {
                    // 마지막 원소가 numbers[i]가 작으면서, 길이가 제일 긴 것을 찾는다.
                    if (previousMax < LISLength[j] && numbers[i] > numbers[j])
                    {
                        previousMax = LISLength[j];
                    }
                }
                LISLength[i] = previousMax + 1;
            }
        }
        Console.WriteLine(LISLength.Max());
    }
}