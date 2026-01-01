#pragma warning disable CS8604, CS8602, CS8600

// p32385 - $\frac{1}{2}$(MatKor+ALPS)=AlKor (S3)
// #애드 혹
// 2026.1.2 solved (1.1)

/*
a_1 ~ a_n의 평균이 a_(n+1)이 되고 n+1개의 모든 항이 다른 수열을 찾는 문제이다.
우선 위의 조건이 만족하려면, a_1부터 a_n의 합이 n의 배수가 되어야 하고,
a_(n+1)은 가능한 n의 배수가 되면 안된다.

그래서 a_1 = 0, a_2 = n, ...으로 0부터 시작하는 n의 배수들을 나열한 뒤, 마지막에 a_n은 n(n-1)이 아닌 a_n = n^2으로 정의했다.
이렇게 하면 n개의 수의 합이 n(0.5n^2 - 0.5n + 1)이 된다.
a_(n+1) = 0.5n(n-1) + 1이 되는데, 이 수는 n이 2이상일 때, n(n-1)이 짝수이므로 양의 정수임이 보장되고,
n = 2일 때를 제외하고는 a_(n+1)은 n의 배수가 되지 않는다. n = 2일 때도, 수열은 0 4 2가 되어 문제 조건은 만족한다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(Console.ReadLine());
        List<long> list = new();
        for (int i = 0; i < n; i++)
        {
            list.Add(i == n - 1 ? n * n : i * n);
        }
        long sum = list.Sum();
        sw.WriteLine($"{string.Join(" ", list)} {sum / n}");
        sw.Flush();
    }
}
