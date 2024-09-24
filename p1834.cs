using System;

/// <summary>
/// p1834 - 나머지와 몫이 같은 수, B1
/// 해결 날짜 : 2024/4/8(solved.ac : 4/7)
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()!);

        long sum = 0;
        // 몫과 나머지가 같은 수는 0과 i*N + i (1 <= i <= N - 1)이 된다.
        for (int i = 1; i < N; i++)
        {
            sum += i * (long)N + i;
        }
        Console.WriteLine(sum);
    }
}