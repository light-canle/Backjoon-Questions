using System;

/// <summary>
/// p11282 - 한글, B4
/// 해결 날짜 : 2023/10/12
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        char 한글 = Convert.ToChar(N + Convert.ToInt32('가') - 1);
        Console.WriteLine(한글);
    }
}