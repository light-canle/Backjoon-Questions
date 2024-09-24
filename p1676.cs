using System;

// p1676 - 팩토리얼 0의 개수, S5
// 해결 날짜 : 2023/8/20

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        int ans = 0;
        if (N != 0 && N != 1) 
        { 
            int countOfTwo = 0;
            int countOfFive = 0;
            for (int i = 2; i <= N; i++)
            {
                countOfTwo += PowerOfPrimeFactor(2, i);
                countOfFive += PowerOfPrimeFactor(5, i);
            }
            ans = (countOfFive > countOfTwo) ? countOfTwo : countOfFive;
        }
        Console.WriteLine(ans);
    }

    public static int PowerOfPrimeFactor(int factor, int n)
    {
        int count = 0;
        while (n % factor == 0)
        {
            n /= factor;
            count++;
        }
        return count;
    } 
}
