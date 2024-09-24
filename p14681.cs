using System;

/// <summary>
/// p14681 - 사분면 고르기, B5
/// 해결 날짜 : 2023/8/27
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());

        int quadrant;
        if (x > 0)
        {
            quadrant = (y > 0) ? 1 : 4;
        }
        else
        {
            quadrant = (y > 0) ? 2 : 3;
        }

        Console.WriteLine(quadrant.ToString());
    }
}
