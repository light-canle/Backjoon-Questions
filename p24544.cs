using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<int> point = Console.ReadLine().Split().Select(int.Parse).ToList();

        List<int> isSelected = Console.ReadLine().Split().Select(int.Parse).ToList();

        int allSum = point.Sum();
        int notSelectedSum = 0;

        for (int i = 0; i < isSelected.Count; i++)
        {
            if (isSelected[i] == 0)
            {
                notSelectedSum += point[i];
            }
        }

        Console.WriteLine(allSum);
        Console.WriteLine(notSelectedSum);
    }
}
