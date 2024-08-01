using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
        list.Sort();

        for (int i = 1; i <= N; i++)
        {
            if (i == N)
            {
                Console.WriteLine(N);
                break;
            }
            else if (list[i - 1] != i)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}
