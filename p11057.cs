using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
  public static void Main(string[] args)
  {
    int n = int.Parse(Console.ReadLine());
    
    long[] count = new long[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
    long[] t = new long[10];
    for (int i = 1; i < n; i++)
    {
      for (int j = 0; j < 10; j++)
      {
        t[j] = 0;
      }
      for (int j = 0; j < 10; j++)
      {
        for (int k = 0; k <= j; k++)
        {
          t[j] += count[k];
          t[j] %= 10007;
        }
      }
      for (int j = 0; j < 10; j++)
      {
        count[j] = t[j];
      }
    }
    
    Console.WriteLine(count.Sum() % 10007);
  }
}
