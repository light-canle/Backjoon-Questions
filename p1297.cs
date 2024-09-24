using System;
using System.Linq;

/// <summary>
/// p1297 - TV 크기, B2
/// 해결 날짜 : 2023/10/8
/// </summary>

// 계산식은 풀이 노트 참고

public class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        (int D, int H, int W) = (input[0], input[1], input[2]);

        double k = Math.Sqrt((D * D) / (double)(H * H + W * W));

        int hLen = (int)(H * k);
        int wLen = (int)(W * k);

        Console.WriteLine($"{hLen} {wLen}");
    }
}