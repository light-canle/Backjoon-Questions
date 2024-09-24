using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p11653 - 소인수분해, B1
/// 해결 날짜 : 2023/9/13
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        int currentNum = 2;
        List<int> primes = new List<int>();
        // N이 소수인 경우 자신을 배열에 넣음
        if (IsPrime(N)) { primes.Add(N); }
        // 아닌 경우 2부터 시작해서 소수를 찾은 뒤 현재 수가 소수로 나뉘어질 경우
        // 소수로 나눈다.
        else
        {
            while (N > 1)
            {
                if (IsPrime(currentNum))
                {
                    while (N % currentNum == 0)
                    {
                        primes.Add(currentNum);
                        N /= currentNum;
                    }
                }
                currentNum++;
            }
        }

        foreach(int i in primes)
        {
            Console.WriteLine(i);
        }
    }

    // 소수 판별 함수
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