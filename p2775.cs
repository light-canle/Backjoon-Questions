using System;

/// <summary>
/// p2775 - 부녀회장이 될테야, B1
/// 해결 날짜 : 2023/8/26
/// </summary>

public class Program
{
    public static long[,] list = new long[29, 29];
    public static void Main(string[] args)
    {
        int caseNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < caseNumber; i++)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Combination(k+n, k+1));
        }
    }

    public static long Combination(int n, int k)
    {
        if (n == k || k == 0) return 1;
        // DP(동적 계획법) 사용
        else if (list[n, k] != 0) return list[n, k];
        return list[n, k] = Combination(n-1, k-1) + Combination(n - 1, k);
    }
}
