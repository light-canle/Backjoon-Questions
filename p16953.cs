using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        long[] pivot = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

        long a = pivot[0], b = pivot[1];

        long c = Find(a, 0, b);

        Console.WriteLine(c + 1 == 2000000000 ? -1 : c + 1);
    }

    public static long Find(long cur, long count, long b)
    {
        if (cur == b)
        {
            return count;
        }
        else if (cur < b)
        {
            long add1 = long.Parse(cur.ToString() + "1");
            return Math.Min(Find(cur * 2, count + 1, b), Find(add1, count + 1, b));
        }

        return 1999999999;
    }
}  
