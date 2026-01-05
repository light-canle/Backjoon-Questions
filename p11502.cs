#pragma warning disable CS8604, CS8602, CS8600

// p11502 - 세 개의 소수 문제 (S4)
// #완전 탐색 #에라토스테네스의 체
// 2026.1.5 solved

public class Program
{
    public static void Main(string[] args)
    {
        List<int> primes = new List<int>();
        bool[] isPrime = Enumerable.Repeat(true, 1001).ToArray();
        int i;
        for (i = 2; i * i <= 1000; i++)
        {
            if (isPrime[i])
            {
                primes.Add(i);
                for (int j = 2 * i; j <= 1000; j += i) isPrime[j] = false;
            }
        }
        for (; i <= 1000; i++)
        {
            if (isPrime[i]) primes.Add(i);
        }
        int n = int.Parse(Console.ReadLine());
        for (i = 0; i < n; i++)
        {
            int k = int.Parse(Console.ReadLine());
            foreach (var p in primes)
            {
                // 1000 이하의 홀수에 대해 한 소수 * 2 + 다른 소수의 형태로 나타낼 수 있다.
                // 그래서 2부터 시작해서 소수에 대해, q = k - 2p가 소수인 경우 k = p + p + q의 형태로 나타낼 수 있다.
                if (primes.Contains(k - 2 * p))
                {
                    Console.WriteLine($"{p} {p} {k - 2 * p}");
                    break;
                }
            }
        }
    }
}
