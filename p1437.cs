using System;

// p1437 - 수 분해 (G4)
// #그리디
// 2025.10.22 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        if (n < 5)
        {
            Console.WriteLine(n);
            return;
        }
        /*
        5 이상의 n이 주어졌을 때 n을 3으로 나눈 몫과 나머지를 q, r이라고 하면
        r = 0 -> 3^q이 최댓값이 된다.
        r = 1 -> 2^2 * 3^(q-1)이 최댓값이 된다.
        r = 2 -> 2 * 3^q이 최댓값이 된다.
        */
        int r = n % 3;
        int count3 = n / 3, count2 = 0;

        if (r == 1)
        {
            count2 = 2;
            count3--;
        }
        else if (r == 2)
        {
            count2 = 1;
        }

        int ret = (int)Math.Pow(2, count2);
        for (int i = 0; i < count3; i++)
        {
            ret *= 3;
            ret %= 10_007;
        }
        Console.WriteLine(ret);
    }
}
