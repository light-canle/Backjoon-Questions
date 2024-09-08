using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
  public static void Main(string[] args)
  {
    int[] i = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    int n = i[0], m = i[1];
    
    if (m == 0)
    {
      Console.WriteLine((int)Math.Pow(10, n));
      return;
    }
    
    string[] c = Console.ReadLine().Split();
    
    int limit = (int)Math.Pow(10, n) - 1;
    int count = 0;
    for (int j = 0; j <= limit; j++)
    {
      string p = j.ToString($"D{n}");
      
      bool valid = true;
      foreach (string k in c)
      {
        if (!p.Contains(k)) valid = false;
      }
      
      count += valid ? 1 : 0;
    }
    
    Console.WriteLine(count);
  }
}
