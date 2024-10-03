using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(':'), int.Parse);
        int gcd = GCD(arr[0], arr[1]);
        Console.WriteLine($"{arr[0] / gcd}:{arr[1] / gcd}");
    }

    public static int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}
