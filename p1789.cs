using System;

/// <summary>
/// p1789, 수들의 합, S5
/// 해결 날짜 : 2023/9/2
/// </summary>

/*
이 문제는 1 ~ N까지의 합인 S가 주어졌을 때,
N을 구하는 문제로, 이차방정식의 근의 공식으로 풀었다.
식 유도는 풀이 노트의 p1789번을 참고
*/

public class Program
{
    public static void Main(string[] args)
    {
        long S = long.Parse(Console.ReadLine());

        long N = (int)(-0.5 + 0.5 * Math.Sqrt(1 + 8*S));

        Console.WriteLine(N);
    }
}