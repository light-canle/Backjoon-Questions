using System;

/// <summary>
/// p18108 - 1998년생인 내가 태국에서는 2541년생?!, B5
/// 해결 날짜 : 2024/3/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int year = int.Parse(Console.ReadLine()!);

        Console.WriteLine(year - 543);
    }
}