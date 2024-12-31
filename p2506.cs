using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int stack = 0;
        int score = 0;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == 1)
            {
                score += ++stack;
            }
            else
            {
                stack = 0;
            }
        }
        Console.WriteLine(score);
    }
}
