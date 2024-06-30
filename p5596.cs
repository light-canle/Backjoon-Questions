using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        
        int[] s1 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] s2 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int t1 = s1.Sum();
        int t2 = s2.Sum();
        Console.WriteLine(Math.Max(t1, t2));
    }
}
