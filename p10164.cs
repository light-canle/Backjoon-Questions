#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Numerics;

// p10164 - 격자상의 경로 (S2)
// #조합론
// 2025.7.21 solved

/*
NxM 격자의 왼쪽 위에서 오른쪽 아래로 가는 경우의 수는
(N+M)! / N!M!이다.
문제에서 주어진 '격자'는 격자의 선을 따라 이동하는 것이 아닌 칸을 따라 이동하는 것이다.
위의 공식은 격자의 선을 따라갈 때 쓸 수 있는 공식이므로 이 문제에 적용하려면 n과 m에 1씩 빼서 적용한다.
중간에 O가 있는 경우를 고려하려면 O가 있는 좌표를 알아낸 뒤, (0,0)에서 O의 좌표가 있는 부분의 부분 격자 크기를 구한 뒤 공식을 적용하고,
O의 좌표부터 (N-1, M-1)까지의 부분 격자의 크기를 구한 뒤, 둘을 곱한다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = arr[0], m = arr[1], k = arr[2];

        if (k == 0)
        {
            Console.WriteLine(GridNM(n - 1, m - 1));
        }
        else
        {
            int y = (k - 1) / m, x = (k - 1) % m;
            Console.WriteLine(GridNM(y, x) * GridNM(n - 1 - y, m - 1 - x));
        }  
    }

    public static BigInteger GridNM(int m, int n)
    {
        return Factorial(m + n) / (Factorial(m) * Factorial(n));
    }

    public static BigInteger Factorial(int m) {
        BigInteger ret = 1;
        for (int i = 2; i <= m; i++)
        {
            ret *= i;
        }
        return ret;
    }
}
