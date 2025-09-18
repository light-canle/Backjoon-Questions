#pragma warning disable CS8604, CS8602, CS8600

using System;

// p19939 - 박 터뜨리기 (S4)
// #그리디
// 2025.9.18 solved

/*
우선 바구니 마다 들어가는 공의 개수가 달라야 하므로,
K개의 바구니가 있을 때 최소 필요한 공의 양은 1 + 2 + 3 + ... K = K(K+1)/2개이다.
그 다음에 최소 개수 1, 2, ... , K부터 최대와 최소의 차이를 최소화하면서 공을 넣으려면,
제일 많은 바구니 부터 1개씩 넣으면 된다.
예시로, K=3일 때
n = 6 -> 1 2 3 // n = 7 -> 1 2 4 // n = 8 -> 1 3 4 // n = 9 -> 2 3 4 ...
최소의 개수를 기준으로, n을 최소의 개수에서 뺀 것을 K로 나누었을 때 나머지가 0이면 최대와 최소의 차이가 K-1이 되고,
그 외에는 K가 되게 만들 수 있는데 이게 최소 차이이다.
*/
public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = input[0], k = input[1];
        int minLimit = k * (k + 1) / 2;
        if (n < minLimit)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine((n - minLimit) % k == 0 ? k - 1 : k);
        }
    }
}
