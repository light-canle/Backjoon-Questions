using System;

// p1344 - 축구 (G4)
// #확률론 #조합론
// 2025.8.14 solved

public class Program
{
    public static void Main(string[] args)
    {
        double p1 = double.Parse(Console.ReadLine()) / 100.0;
        double p2 = double.Parse(Console.ReadLine()) / 100.0;
        // 적어도 하나가 소수일 확률은 1에서 둘다 소수가 아닐 확률을 뺀 것과 같다.
        Console.WriteLine(1 - Calculate(p1) * Calculate(p2));        
    }

    // X ~ B(18, p)에 대해 X=x가 소수가 아닐 확률을 구한다.
    public static double Calculate(double p)
    {
        double ret = 0;
        int[] notPrimes = { 0, 1, 4, 6, 8, 9, 10, 12, 14, 15, 16, 18 };
        foreach (int r in notPrimes)
        {
            ret += Combination(18, r) * Math.Pow(p, r) * Math.Pow(1 - p, 18 - r);
        }
        return ret;
    }

    // nCr의 근사값을 구한다.
    public static double Combination(int n, int k)
    {
        double ret = 1.0;
        for (int i = 1; i <= k; i++)
        {
            ret *= (n - i + 1.0) / (double)i;
        }
        return ret;
    }
}
