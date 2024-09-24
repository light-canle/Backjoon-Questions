using System;

/// <summary>
/// p2839 - 설탕 배달, S4
/// 시작 날짜 : 2020/9/4
/// 해결 날짜 : 2023/8/28
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        int count_5 = 0, count_3 = 0;
        if (N % 5 == 0)
        {
            count_5 = N / 5;
            count_3 = 0;
        }

        else
        {
            // 우선 5kg 봉지를 총량이 초과하지 않는 선에서 많이 가진 채로 시작한다.
            count_5 = N / 5;

            while (count_5 >= 0) 
            {
                // 용량을 초과할 때까지 3kg 봉지를 추가한다.
                do
                {
                    count_3++;
                } while (5 * count_5 + 3 * count_3 < N);
                // 만약 정확한 용량에 맞출 수 있다면 반복을 끝낸다.
                if (5 * count_5 + 3 * count_3 == N)
                {
                    break;
                }
                // 아닌 경우 5kg 봉지를 1개씩 제거한다.
                count_5--;
                count_3 = 0;
            }
            // 위 반복문은 5kg 봉지를 모두 제거 했는데도, 3kg만으로 만들 수 없다면 -1을 반환한다.
        }

        Console.WriteLine(count_5 + count_3);
    }
}
