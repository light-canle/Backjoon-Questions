using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = input[0], c = input[1];
        int[] interval = new int[n];
        bool[] shown = new bool[c + 1];
        for (int i = 0; i < n; i++)
        {
            interval[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            int t = interval[i];
            while (t <= c)
            {
                shown[t] = true;
                t += interval[i];
            }
        }

        int count = 0;
        for (int i = 1; i <= c; i++)
        {
            count += shown[i] ? 1 : 0;
        }
        Console.WriteLine(count);
    }
}
