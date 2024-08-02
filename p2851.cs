using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = new int[10];
        for (int i = 0; i < 10; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        int[] pre = new int[11];

        for (int i = 0; i < 10; i++)
        {
            pre[i + 1] = pre[i] + arr[i];
        }
        int minDiff = 100;
        int ans = pre[0];

        for (int i = 1; i <= 10; i++)
        {
            if (Math.Abs(pre[i] - 100) <= minDiff)
            {
                minDiff = Math.Abs(pre[i] - 100);
                ans = pre[i];
            }
        }

        Console.WriteLine(ans);
    }
}
