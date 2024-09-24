using System;
using System.Linq;

/// <summary>
/// p1629 - 곱셈, S1
/// 시작 날짜 : 2023/9/4
/// 해결 날짜 : 2023/9/5
/// </summary>

/*
원래는 분할 정복을 이용해서 거듭제곱을 계산하면 되었으나,
구현이 잘못되었는지 시간초과가 발생했다.
그래서 나머지 연산자의 성질을 이용해서 곱하는 횟수를 비트마스킹 한 뒤
계산하였다.

% 연산자의 성질인 (ab mod c) = ((a mod c)(b mod c))mod c와
모든 자연수는 2^0부터 시작하는 2의 거듭제곱의 합으로 나타낼 수 있다는 성질을 이용했다.
(a^b) % c
(6^9) % 17

6 % 17 = 6
6^2 % 17 = 36 % 17 = 2
6^4 % 17 = 2^2 % 17 = 4
6^8 % 17 = 4^2 % 17 = 16

6^9 % 17 = (16 * 6) % 17 = 11
위의 예시 처럼 a, a^2, a^4, ...을 c로 나눈 나머지를 구한 뒤,
b의 이진수 표현 안에 1로 표시되는 비트에 해당하는 나머지들을 곱한 뒤 다시 c로 나눈 나머지를 구해서
큰 수의 거듭제곱의 나머지를 O(log b)시간에 계산할 수 있다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int[] list = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int a = list[0];
        int b = list[1];
        int c = list[2];

        int result = ProductDiv(a, b, c);
        Console.WriteLine(result);
    }

    public static int ProductDiv(int a, int b, int c)
    {
        // 곱하는 횟수(b) 비트마스킹
        long bit = 1;
        long currentValue = a % c;
        long result = 1;
        for (int i = 0; i < 31; i++)
        {
            // 해당 비트가 b안에 속해있는지 판단
            if ((b & bit) != 0)
            {
                // 만약 들어있다면, 이전 계산 결과에 곱하고 다시 c로 나눈 나머지를 구한다.
                result = ((result % c) * (currentValue % c)) % c;
            }
            currentValue = ((currentValue % c) * (currentValue % c)) % c;
            // 비트를 1칸 왼쪽으로 이동시킨다.
            bit <<= 1;
        }
        return (int)result;
    }
}


/*
이전 코드
시간 초과가 났지만 b < 10,000,000에서는 1초 안에 계산할 수 있다. 
using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int[] list = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int a = list[0];
        int b = list[1];
        int c = list[2];

        int result = ProductDiv(a, b, c);
        Console.WriteLine(result);
    }

    public static int ProductDiv(int a, int b, int c)
    {
        if (b == 0) { return 1; }
        if (b == 1) { return a % c; }
        if (b == 2) { return (a * a) % c; }
        else if (b % 3 == 1) 
        { 
            return (ProductDiv(a, b / 3, c) * ProductDiv(a, b / 3, c) * ProductDiv(a, b / 3, c) * ProductDiv(a, 1, c)) % c; 
        }
        else if (b % 3 == 2)
        {
            return (ProductDiv(a, b / 3, c) * ProductDiv(a, b / 3, c) * ProductDiv(a, b / 3, c) * ProductDiv(a, 2, c)) % c;
        }
        else
        {
            return (ProductDiv(a, b / 3, c) * ProductDiv(a, b / 3, c) * ProductDiv(a, b / 3, c)) % c;
        }
    }
}
*/