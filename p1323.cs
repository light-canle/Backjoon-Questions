using System;

// p1323 - 숫자 연결하기 (G4)
// #정수론 - 모듈러 성질 #비둘기집 원리 #분할 정복을 이용한 거듭제곱 연산
// 2025.6.23 solved

public class Program
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        long n = long.Parse(input[0]);
        long k = long.Parse(input[1]);

        int digit = n.ToString().Length;

        long remainder = n % k;
        // i는 n을 연속으로 쓴 횟수이다.
        for (int i = 1; i <= k + 1; i++)
        {
            // 나머지가 0이면 나누어 떨어진다.
            if (remainder == 0)
            {
                Console.WriteLine(i);
                break;
            }
            /* 
            n이 p자리 자연수 일때,
            n을 i - 1번 쓴 수 에서 1번 더 쓴다는 것은
            그 수를 sum이라고 했을 때,
            sum에 10 ^ (p * (i - 1)) * n을 더하는 것과 같다.
            예를 들어 n = 12라 했을 때,
            n을 1번 쓴 수는 a_1 = 12,
            n을 2번 쓴 수는 a_2 = 1212 = 1200 + 12 = a_1 + 10^2 * 12
            n을 3번 쓴 수는 a_3 = 121212 = 120000 + 1212 = a_2 + 10^4 * 12
            즉 횟수를 거듭할 때마다 10 ^ (p * (i - 1)) * n을 더하고 있음을 확인할 수 있다.
            
            모듈러의 성질에 의해
            (a + b) mod k = (a mod k + b mod k) mod k
            (a * b) mod k = ((a mod k) * (b mod k)) mod k

            즉 n을 1번씩 붙일 때마다 10 ^ (p * (i - 1)) * n를 k로 나눈 나머지를 더해주면
            아주 큰 수에 대한 나머지를 구하지 않고도 똑같은 결과를 낼 수 있다.
            모듈러 성질을 써서 10 ^ (p * (i - 1)) mod k와 n mod k를 따로 구한 뒤
            둘을 곱한 것을 k로 나눈 나머지를 구하고 이를 remainder라는 이전 수를 k로 나눈 나머지를
            저장하는 변수에 누적한 뒤 그 수에 대한 모듈러 연산을 수행해서 0이 나올 때까지 이를 반복한다.
            */
            remainder += (TensPowerModK(digit * i, k) * (n % k)) % k;
            remainder %= k;
        }
        /*
        어떤 자연수를 k로 나눈 나머지는 0 ~ k-1 사이에 있다.
        비둘기집 원리에 의해 n을 붙이는 작업을 k + 1번 하면 반드시 나머지가 같은 서로 다른 두 수가
        존재할 것이고, 그것이 등장한 순간부터 수를 붙일 때마다 등장하는 나머지는 이전과 동일한 조합이 된다.
        즉, k + 1번 반복하는 동안 0이 나오지 않으면 아무리 n을 뒤에 여러번 써도 k로 나누어 떨어지지 않음을 확인할 수 있다.
        */
        if (remainder != 0)
        {
            Console.WriteLine(-1);
        }
    }

    // 10 ^ n mod k의 값을 구한다,
    public static long TensPowerModK(long n, long k)
    {
        if (n == 0) return 1;
        if (n == 1) return 10 % k;

        long half = TensPowerModK(n / 2, k);
        if (n % 2 == 0)
            return (half * half) % k;
        else
            return ((half * half) % k * (10 % k)) % k;
    }
}
