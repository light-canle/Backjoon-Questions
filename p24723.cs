using System;

/// <summary>
/// p24723 - 녹색거탑, B4
/// 해결 날짜 : 2024/3/30
/// 200번째 브론즈 문제
/// </summary>

/*
층이 하나씩 증가할 때마다 어떤 블록의 윗면으로
떨어지는 경우의 수는 파스칼의 삼각형과 같다.
N층에 떨어지는 경우의 수는 파스칼의 삼각형의 특정 줄에 있는
수들의 합과 같으므로 2^N이 된다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()!); 
        Console.WriteLine((int)Math.Pow(2, N));
    }
}