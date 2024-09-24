using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

// p1929 - 소수 구하기, S3
// 해결 날짜 - 2023/8/21

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
        StringBuilder output = new StringBuilder();

        for (int i = input[0]; i <= input[1]; i++)
        {
            if (IsPrime(i))
            {
                output.AppendLine(i.ToString());
            }
        }

        Console.WriteLine(output);
    }

    public static bool IsPrime(int num)
    {
        if (num == 1) return false;
        if (num == 2 || num == 3) return true;
        if (num % 6 != 1 && num % 6 != 5) return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}
