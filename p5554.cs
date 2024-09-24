using System;

/// <summary>
/// p5554 - 심부름 가는 길, B4
/// 해결 날짜 : 2023/11/18
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int totalTime = 0;
        for (int i = 0; i < 4; i++)
        {
            int curTime = int.Parse(Console.ReadLine()!);
            totalTime += curTime;
        }

        int x = totalTime / 60;
        int y = totalTime % 60;
        Console.WriteLine(x);
        Console.WriteLine(y);
    }
}