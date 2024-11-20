using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int a = input[0], b = input[1];

        int hor = Math.Abs((b-1) / 4 - (a-1) / 4);
        int ver = Math.Abs((b % 4 == 0 ? 4 : b % 4) - (a % 4 == 0 ? 4 : a % 4));
        Console.WriteLine(hor + ver);
    }
}
