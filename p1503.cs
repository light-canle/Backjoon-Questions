using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main(string[] args)
	{
	  long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	  long n = input[0], k = input[1];
	  
      List<long> list = new();
	  if (k > 0)
	  {
	    list = Console.ReadLine().Split().Select(long.Parse).ToList();
	  }
	  
	  long minDiff = 9999999, diff = 0;
	  for (long i = 1; i <= 2001; i++)
	  {
	    if (k > 0 && list.Contains(i)) continue;
	    for (long j = 1; j <= 2001; j++)
	    {
	      if (k > 0 && list.Contains(j)) continue;
	      for (long l = 1; l <= 2001; l++)
	      {
	        if (k > 0 && list.Contains(l)) continue;
	        if (i * j * l > 140556) break;
	        diff = Math.Abs(n - i * j * l);
	        if (diff < minDiff)
	        {
	           minDiff = diff;
	        }
	      }
	      if (i * j > 140556) break;
	    }
	  }
	  
	  Console.WriteLine(minDiff);
	}
}
