using System;
using System.Linq;

/// <summary>
/// p6322 - 직각 삼각형의 두 변
/// 해결 날짜 : 2023/9/11
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int count = 1;
        while (true)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            (int a, int b, int c) = (input[0], input[1], input[2]);

            if (a == 0 && b == 0 && c == 0) break;

            // -1로 받은 변의 길이를 구함, 불가능 한 경우 Impossible. 출력
            double answer;
            if (a == -1)
            {
                answer = Math.Sqrt( c * c - b * b );
                Console.WriteLine($"Triangle #{count}");
                if (answer > 0 )
                    Console.WriteLine($"a = {answer:F3}");
                else
                    Console.WriteLine("Impossible.");
            }

            else if (b == -1)
            {
                answer = Math.Sqrt(c * c - a * a);
                Console.WriteLine($"Triangle #{count}");
                if (answer > 0)
                    Console.WriteLine($"b = {answer:F3}");
                else
                    Console.WriteLine("Impossible.");
            }

            else if (c == -1)
            {
                answer = Math.Sqrt(a * a + b * b);
                Console.WriteLine($"Triangle #{count}");
                if (answer > 0)
                    Console.WriteLine($"c = {answer:F3}");
                else
                    Console.WriteLine("Impossible.");
            }
            Console.WriteLine(); // 출력 형식을 위한 한 칸 띄우기
            count++;
        }   
    }
}