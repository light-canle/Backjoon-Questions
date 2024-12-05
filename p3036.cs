using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        
        int first = arr[0];
        for (int i = 1; i < n; i++)
        {
            int div = GCD(first, arr[i]);
            int num = first / div;
            int den = arr[i] / div;
            Console.WriteLine($"{num}/{den}");
        }
    }
    public static int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}
