using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
  public static void Main(string[] args)
  {
	  int n = int.Parse(Console.ReadLine());
	  long[] a = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	  
	  long[] prefix = new long[n + 1];
	  
	  long cur = 0;
	  for (int i = 1; i <= n; i++)
	  {
	    cur += a[i - 1];
	    prefix[i] = cur;
	  }
	  
	  long minDiff = long.MaxValue;
	  long kk = 0;
	  for (int k = 1; k < n; k++)
	  {
	    for (int i = 1; i + k - 1 <= n; i++)
	    {
	      for (int j = i + k; j + k - 1 <= n; j++)
	      {
	        long l = prefix[i + k - 1] - prefix[i - 1];
	        long r = prefix[j + k - 1] - prefix[j - 1];
	        
	        if (minDiff >= Math.Abs(l - r))
	        {
	          minDiff = Math.Abs(l - r);
	          kk = k;
	        }
	      }
	    }
	  }
	  
	  Console.WriteLine(kk);
	  Console.WriteLine(minDiff);
  }
}
