using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p1011 - Fly me to the Alpha Centauri, G5
/// 해결 날짜 : 2023/9/4
/// </summary>

/*
2 * l(l+1)과 (l+1)^2 사이의 범위 내에서 적절한 수의 값을 찾아내는 문제
정확한 풀이는 풀이노트 참고
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();

        int N = int.Parse(sr.ReadLine());

        for (int i = 0; i < N; i++)
        {
            long[] input = sr.ReadLine().Split().Select(long.Parse).ToArray();
            long n = input[1] - input[0];
            if (n == 1)
            {
                output.AppendLine("1");
            }
            else if (n == 2)
            {
                output.AppendLine("2");
            }
            else 
            { 
                double k = Math.Sqrt(n);
                int l = (int)Math.Ceiling(k);

                if (n > l * (l - 1))
                {
                    output.AppendLine((2 * l - 1).ToString());
                }
                else
                {
                    output.AppendLine((2 * l - 2).ToString());
                }
            }
        }

        Console.WriteLine(output);
        sr.Close();
    }
}