using System;

/// <summary>
/// p10699 - 오늘 날짜, B5
/// 해결 날짜 : 2023/8/23
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        DateTime thisTime = DateTime.Now;
        Console.WriteLine($"{thisTime.Year:0###}-{thisTime.Month:0#}-{thisTime.Day:0#}");
    }
}