using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p23827 - 수열 (Easy) (S4)
// #누적 합
// 2025.7.10 solved

/*
a1a2 + a1a3 + ... + a1an + 
     + a2a3 + ... + a2an +
...
                  + a(n-1)an
= a1 * (a2 + a3 + ... + an) +
  a2 * (a3 + a4 + ... + an) +
...
  a(n-1) * an
즉, a1 ~ an까지의 합을 저장한 변수를 만들고
더할 때마다 맨 앞의 값을 누적된 합에서 빼고
그 값에 뺀 값을 곱한 것을 정답에 더해주면 된다.
수가 커서 long을 써도 오버플로우가 날 수 있으므로
누적할 때마다 10억 7로 나누어 준다.
*/
public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        List<long> arr = sr.ReadLine().Trim().Split().Select(long.Parse).ToList();

        long other = arr.Sum();
        long result = 0;
        for (int i = 0; i < n - 1; i++)
        {
            other -= arr[i];
            result += arr[i] * other;
            result %= 1_000_000_007;
        }
        Console.WriteLine(result);
        sr.Close();
    }
}
