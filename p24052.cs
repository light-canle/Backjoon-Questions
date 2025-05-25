#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.Collections.Generic;

// p24052 - 알고리즘 수업 - 삽입 정렬 2 (B1)
// #정렬 #시뮬레이션
// 2025.5.25 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] info = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = info[0], k = info[1];
        List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

        int c = InsertionSort(list, k);
        if (c == k)
        {
            Console.WriteLine(string.Join(" ", list));
        }
        else
        {
            Console.WriteLine(-1);
        }
    }

    public static int InsertionSort(List<int> list, int k)
    { 
        int len = list.Count;
        int changed = 0;
        for (int i = 1; i < len; i++)
        {
            int loc = i - 1;
            int newItem = list[i];

            while (0 <= loc && newItem < list[loc])
            {
                list[loc + 1] = list[loc];
                changed++;
                if (changed == k)
                {
                    return changed;
                }
                loc--;
            }
            if (loc + 1 != i)
            {
                list[loc + 1] = newItem;
                changed++;
                if (changed == k)
                {
                    return changed;
                }
            }
        }
        return changed;
    }
}
