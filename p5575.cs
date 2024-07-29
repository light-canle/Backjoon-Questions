using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 3; i++)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int h1 = arr[0];
            int m1 = arr[1];
            int s1 = arr[2];

            int h2 = arr[3];
            int m2 = arr[4];
            int s2 = arr[5];

            int time1 = h1 * 3600 + m1 * 60 + s1;
            int time2 = h2 * 3600 + m2 * 60 + s2;

            int diff = time2 - time1;
            int h = diff / 3600;
            diff %= 3600;
            int m = diff / 60;
            diff %= 60;
            int s = diff;
            
            Console.WriteLine(h + " " + m + " " + s);
        }
    }
}
