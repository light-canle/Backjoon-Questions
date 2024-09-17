using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public class Program
{
  public static void Main(string[] args)
  {
    StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
    int T = int.Parse(sr.ReadLine());

    int a = int.Parse(sr.ReadLine());
    int[] l1 = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    int b = int.Parse(sr.ReadLine());
    int[] l2 = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

    int[] p1 = new int[a+1];
    int[] p2 = new int[b+1];

    int cur = 0;
    for (int i = 0; i < a; i++)
    {
      cur += l1[i];
      p1[i+1] = cur;
    }
    cur = 0;
    for (int i = 0; i < b; i++)
    {
      cur += l2[i];
      p2[i+1] = cur;
    }
    List<int> partSum1 = new();
    List<int> partSum2 = new();

    Dictionary<int, int> p2Count = new();
    
    for (int i = 0; i < a; i++)
    {
      for (int j = i + 1; j <= a; j++)
      {
        partSum1.Add(p1[j] - p1[i]);
      }
    }

    for (int i = 0; i < b; i++)
    {
      for (int j = i + 1; j <= b; j++)
      {
        int k = p2[j] - p2[i];
        partSum2.Add(k);
        if (p2Count.ContainsKey(k))
        {
          p2Count[k]++;
        }
        else
        {
          p2Count[k] = 1;
        }
      }
    }
    partSum2.Sort();
    long count = 0;
    foreach (int k in partSum1)
    {
      count += Contain(partSum2, T - k, p2Count);
    }
    Console.WriteLine(count);
  }

  public static long Contain(List<int> list, int value, Dictionary<int, int> count)
  {
    int low = 0;
    int high = list.Count - 1;

    while (low <= high)
    {
      int mid = (low + high) / 2;
      if (list[mid] == value)
      {
        return (long)count[value];
      }
      else if (list[mid] < value)
      {
        low = mid + 1;
      }
      else
      {
        high = mid - 1;
      }
    }
    return 0;
  }
}
