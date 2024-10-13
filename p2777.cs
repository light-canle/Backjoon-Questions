using System;

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            int d = CountDigit(n);
            Console.WriteLine(d);
        }
    }

    public static int CountDigit(int n)
    {
        if (n < 10) return 1;
        int[] count = new int[4];
        int[] p = {2, 3, 5, 7};

        for (int i = 0; i < p.Length; i++)
        {
            if (n == 1) break;
            while (n > 1)
            {
                if (n % p[i] == 0)
                {
                    count[i]++;
                    n /= p[i];
                }
                else break;
            }
        }
        
        if (n != 1) return -1;
        int count8 = count[0] / 3;
        int count9 = count[1] / 2;
        int count4 = count[0] % 3 == 2 ? 1 : 0;
        int count6 = count[1] % 2 == 1 && count[0] % 3 == 1 ? 1 : 0;
        int count2 = count[0] % 3 == 1 && count[1] % 2 == 0 ? 1 : 0;
        int count3 = count[1] % 2 == 1 && count[0] % 3 != 1 ? 1 : 0;
        return count8 + count9 + count4 + count6 + count2 + count3 + count[2] + count[3];
    }
}
