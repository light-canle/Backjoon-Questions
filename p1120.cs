using System;

/// <summary>
/// p1120 - 문자열, S4
/// 해결 날짜 : 2023/11/1
/// </summary>

// a와 b의 부분 문자열의 차이 중 최소를 구해서 출력하는 문제

public class Program
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine()!.Split();

        string a = input[0];
        string b = input[1];
        // a, b 길이 차이
        int lenDiff = b.Length - a.Length;
        // a와 b의 부분 문자열의 최소 차이 수
        int minDiff = a.Length;

        for (int i = 0; i <= lenDiff; i++)
        {
            string part = b.Substring(i, a.Length);
            int currentDiff = 0;
            // 현재 b의 부분 문자열과 a의 문자 차이 수를 구함
            for (int j = 0; j < a.Length; j++)
            {
                if (part[j] != a[j]) currentDiff++;
            }
            minDiff = Math.Min(minDiff, currentDiff);
        }

        Console.WriteLine(minDiff);
    }
}