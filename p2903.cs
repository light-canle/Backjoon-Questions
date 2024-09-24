using System;

/// <summary>
/// p2903 - 중앙 이동 알고리즘, B3
/// 해결 날짜 : 2024/3/26
/// </summary>

/*
점을 찍는 규칙을 5단계 정도 진행해 보면
한 변에 점이 3, 5, 9, 17, 33...개로 +2, +4, +8, +16, ...만큼 증가한다.
이런 줄이 한 줄의 개수만큼 있으므로 전체 점은 3^2, 5^2, ...개가 된다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine()!);

        long sideDigitNum = 3;
        for (int i = 1; i < T; i++)
        {
            sideDigitNum += (int)Math.Pow(2, i);
        }
        Console.WriteLine(sideDigitNum * sideDigitNum);
    }
}