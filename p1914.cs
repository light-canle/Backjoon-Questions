using System;
using System.Numerics;
using System.Text;

/// <summary>
/// p1914 - 하노이 탑, S1
/// 해결 날짜 : 2023/9/25
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder output = new StringBuilder();
        int N = int.Parse(Console.ReadLine());

        // 하노이탑 옮기는 횟수
        BigInteger count = BigInteger.Pow(2, N) - 1;
        output.AppendLine(count.ToString());

        // 20이하 일때만 과정 출력
        if (N <= 20)
        {
            Hanoi(N, 1, 2, 3, output);
        }
        Console.WriteLine(output);
    }

    // 탑을 옮기는 과정을 출력
    public static void Hanoi(int rings, int source, int aux, int target, StringBuilder output)
    {
        if (rings == 1)
        {
            output.AppendLine($"{source} {target}");
            return;
        }

        Hanoi(rings - 1, source, target, aux, output);
        output.AppendLine($"{source} {target}");
        Hanoi(rings - 1, aux, source, target, output);
    }
}