using System;
using System.Linq;
using System.Text;

/// <summary>
/// p4779 - 칸토어 집합, S3
/// 해결 날짜 : 2024/4/2(solved.ac : 4/1)
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder output = new StringBuilder();
        // 파일 끝까지 읽기
        // input을 받고 null인 경우 break로 빠져 나오면 된다.
        while (true)
        {
            string? input = Console.ReadLine()!;

            if (input == null || input == "") break;

            int N = int.Parse(input);

            output.AppendLine(CantorSet(N));
        }
        Console.WriteLine(output);
    }
    // 주어진 칸토어 집합의 특징을 보면 N단계 문자열은
    // (N-1단계 문자열)(3^(N-1)개의 빈칸)(N-1단계 문자열)의 구조로 이루어져 있고,
    // 0단계 문자열은 -이다. 이 구조를 반영하는 재귀함수를 구성했다.

    public static string CantorSet(int N)
    {
        if (N == 0) return "-";
        return CantorSet(N - 1) + Blank(N - 1) + CantorSet(N - 1);
    }
    public static string Blank(int N)
    {
        return new string(' ', (int)Math.Pow(3, N));
    }
}