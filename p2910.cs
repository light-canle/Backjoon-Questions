using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
  public static void Main(string[] args)
  {
    int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

    int n = input[0];
    int c = input[1];

    List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

    List<int> dist = list.Distinct().ToList();

    Dictionary<int, int> count = new();

    foreach (int i in dist)
    {
      count.Add(i, list.Count(x => x == i));
    }

    dist = dist.OrderByDescending(x => count[x]).ToList();

    List<int> result = new();

    foreach (int i in dist)
    {
      for (int j = 0; j < count[i]; j++)
      {
        result.Add(i);
      }
    }
    Console.WriteLine(string.Join(" ", result));
  }
}
