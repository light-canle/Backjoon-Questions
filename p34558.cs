#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

// p34558 - Prime Median (G5)
// #누적 합 #에라토스테네스의 체
// 2025.10.4 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new();
        int t = int.Parse(sr.ReadLine());

        // 2 ~ 10^6 사이의 소수를 구한다.
        List<int> nums = Enumerable.Range(2, 999999).ToList();
        bool[] isPrime = Enumerable.Repeat(true, 1000001).ToArray();
        List<int> primes = new();
        for (int i = 2; i <= 1000; i++)
        {
            if (isPrime[i])
            {
                primes.Add(i);
                for (int j = i * 2; j <= 1000000; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        for (int i = 1001; i <= 1000000; i++)
        {
            if (isPrime[i]) primes.Add(i);
        }

        // 0~10^6 까지의 정수 K에 대해 1~K까지의 소수의 개수를 담은 누적 합 배열 생성
        List<int> primeCount = new();
        int primeIndex = 0;
        int nextPrime = primes[0];

        for (int i = 0; i <= 1000000; i++)
        {
            if (nextPrime == i)
            {
                primeIndex++;
                nextPrime = (primeIndex < primes.Count) ?primes[primeIndex] : 1000001;
            }

            primeCount.Add(primeIndex);
        }

        for (int i = 0; i < t; i++)
        {
            int[] range = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int left = range[0], right = range[1];
            // 구간을 받으면 구간 내의 소수의 개수를 검사
            int pCount = primeCount[right] - primeCount[left - 1];
            // 짝수이면 -1
            if (pCount % 2 == 0)
            {
                output.AppendLine((-1).ToString());
            }
            /* 
            홀수이면 아래와 같이 수행
            2를 1번 소수, 3을 2번 소수, ... 이런 식으로 크기 순으로 소수에 번호를 1부터 붙였을 때,
            primeCount[right]가 구간 내 가장 큰 소수의 번호가 된다.
            primeCount[right] - pCount + 1은 구간 내 가장 작은 소수의 번호가 되고,
            둘을 더한 뒤 평균을 낸 것이 우리가 찾는 중앙값 소수의 번호가 된다.
            primes는 0부터 시작하므로 우리가 찾은 번호에 1을 빼면 중앙값을 얻을 수 있다.
            */
            else
            {
                int index = ((primeCount[right] * 2 - pCount + 1) / 2) - 1;
                output.AppendLine((primes[index]).ToString());
            }
        }
        sw.WriteLine(output);
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
