using System;
using System.Linq;

/// <summary>
/// p2154 - 수 이어 쓰기 3, B2
/// 해결 날짜 : 2023/11/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine()!);

        string ret = string.Join("", Enumerable.Range(1, num));

        Console.WriteLine(ret.IndexOf(num.ToString()) + 1);
    }
}