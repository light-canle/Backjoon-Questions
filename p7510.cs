using System;
using System.Linq;

/// <summary>
/// p7510 - 고급 수학, B3
/// 해결 날짜 : 2023/11/12
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < num; i++)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine($"Scenario #{i + 1}:");
            if (input[0] * input[0] + input[1] * input[1] == input[2] * input[2])
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            Console.WriteLine();
        }
    }
}