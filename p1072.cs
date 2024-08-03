using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Console.ReadLine().Split().Select(long.Parse).ToArray();

        long x = input[0], y = input[1];

        int z = WinRate(x, y);

        if (z >= 99)
        {
            Console.WriteLine("-1");
            return;
        }

        long low = 0, high = 1_000_000_001;

        while (low < high)
        {
            long mid = (low + high) / 2;
            int newZ = WinRate(x + mid, y + mid);

            if (newZ > z)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        Console.WriteLine(low);
    }

    public static int WinRate(long x, long y)
    {
        return (int)(y * 100 / (double)x);
    }
}
