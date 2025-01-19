using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int n = input[0];
        int m = input[1];

        if (n == 0)
        {
            Console.WriteLine(0);
            return;
        }

        int[] weight = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int box = 0;
        int curSum = 0;
        int index = 0;
        while (index < n)
        {
            curSum += weight[index];
            if (curSum > m)
            {
                curSum = 0;
                box++;
            }
            else
            {
                index++;
            }
        }
        if (curSum > 0)
        {
            box++;
        }
        Console.WriteLine(box);
    }
}
