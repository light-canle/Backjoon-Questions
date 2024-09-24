using System;

/// <summary>
/// p15439 - 베라의 패션, B4
/// 해결 날짜 : 2024/3/30
/// </summary>

/*
상의의 색상 N 개중 1개를 고르면 하의의 색상을 상의와 다르게 하기 위해서
N - 1개 중 1개를 골라야 한다. 경우의 수는 N(N-1)
*/

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()!); 
        Console.WriteLine(N * (N - 1));
    }
}