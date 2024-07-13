using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int n = input[0];
        int m = input[1];

        if ((n + m) % 2 != 0 || n < m)
        {
            Console.WriteLine("-1");
            return;
        }
        int a = (n + m) / 2;
        int b = n - a;

        Console.WriteLine(a + " " + b);
    }
}
