using System;

public class Program
{
    public static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());
        long low = 1, high = 1;

        int count = 0;
        while (low <= n)
        {
            long s = Sum(low, high);
            if (low == n)
            {
                count++;
                break;
            }
            else if (s > n)
            {
                low++;
            }
            else if (s <= n)
            {
                if (s == n) count++;
                high++;
            }
        }
        Console.WriteLine(count);
    }

    public static long Sum(long from, long to)
    {
        return (to * (to + 1)) / 2 - (from - 1) * from / 2;
    }
}
