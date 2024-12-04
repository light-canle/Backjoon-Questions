using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        long[] arr = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        
        long sum = 0;
        int[] dp = new int[n];
        int c1 = 0, c2 = 0;
        
        for (int i = 0; i < n; i++)
        {
            sum += arr[i];
            if (arr[i] == 1)
            {
                c1++;
            }
            else if (arr[i] % 2 == 1)
            {
                c2 += (int)(arr[i] - 3) / 2;
            }
            else
            {
                c2 += (int)arr[i] / 2;
            }
        }
        
        if (sum % 3 != 0)
        {
            Console.WriteLine("NO");
            return;
        }
        
        Console.WriteLine((c2 >= c1) ? "YES" : "NO");
    }
}
