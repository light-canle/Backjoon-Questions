using System;

// p9693 - 시파르 (S4)
// #정수론
// 2025.6.5 solved

public class Program
{
    public static void Main(string[] args)
    {
        int c = 1;
        // n!를 소인수분해 했을 때 5의 계수를 저장하는 배열
        // n!의 5의 계수가 coeffFive[n]에 저장됨
        int[] coeffFive = new int[1000001];
        for (int i = 1; i <= 1000000; i++)
        {
            coeffFive[i] = coeffFive[i - 1] + CountFive(i);
        }
        
        while (true)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 0)
            {
                break;
            }
            // n!/10^m이 정수가 되게 되는 m의 최대는 n!를 소인수분해 했을 때
            // 5의 계수와 같다. 2×5=10이므로, 2와 5의 계수 중 작은 쪽이 10의 개수와 같은데
            // 2 이상의 정수에 대해 2의 계수는 5의 계수보다 항상 크기 때문이다.
            Console.WriteLine($"Case #{c}: {coeffFive[n]}");
            c++;
        }
    }

    // n을 소인수분해 했을 때 5의 계수를 반환
    public static int CountFive(int n)
    {
        int count = 0;
        while (n % 5 == 0)
        {
            count++;
            n /= 5;
        }
        return count;
    }
}
