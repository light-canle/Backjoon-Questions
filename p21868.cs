using System;

// p21868 - 미적분학 입문하기 (S2)
// #미적분학
// 2025.5.31 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int en = input[0]; // 엡실론 분자
        int ed = input[1]; // 엡실론 분모

        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int a = input[0]; // 1차항 계수
        int b = input[1]; // 상수

        int x0 = int.Parse(Console.ReadLine());

        int L = a * x0 + b; // 극한값 - 일차함수이므로 a*x0+b가 극한값

        // f(x)가 일차함수이므로 델타의 최댓값을 구해보면 엡실론에 a를 나눈 것이 된다.
        int dn = en;
        int dd = ed * Math.Abs(a);

        // a가 0이면 델타의 최대는 존재하지 않음
        if (a != 0)
        {
            int g = gcd(dn, dd);
            dn /= g;
            dd /= g;
        }
        else
        {
            dn = 0; dd = 0;
        }
        
        Console.WriteLine(L);
        Console.WriteLine($"{dn} {dd}");
    }

    public static int gcd(int a, int b)
    {
        if (b == 0) return a;
        return gcd(b, a % b);
    }
}
