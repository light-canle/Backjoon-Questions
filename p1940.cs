using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        List<int> arr = Console.ReadLine().Split().Select(int.Parse).ToList();

        arr.Sort();

        int count = 0;
        int low = 0, high = n - 1;
        while (low < high)
        {
            if (arr[low] + arr[high] <= m)
            {
                if (arr[low] + arr[high] == m) count++;
                low++;
            }
            else
            {
                high--;
            }
        }
        Console.WriteLine(count);
    }
}
