using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<int> longest = new List<int>();
        List<int> curList = new List<int>();
        int maxCount = 0;
        for (int i = 0; i <= N; i++)
        {
            int cur = i;
            int sec = N - i;
            int count = 1;
            curList.Clear();
            curList.Add(N);
            while (cur >= 0)
            {
                curList.Add(cur);
                int temp = cur;
                cur = sec;
                sec = temp - sec;
                count++;
            }
            if (count > maxCount)
            {
                maxCount = count;
                longest = curList.ToList();
            }
        }
        Console.WriteLine(maxCount);
        Console.WriteLine(string.Join(" ", longest));
    }
}
