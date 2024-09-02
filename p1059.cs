using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main(string[] args)
	{
		int L = int.Parse(Console.ReadLine());
		int[] S = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
		int N = int.Parse(Console.ReadLine());
		
		int count = 0;
		
		for (int i = 1; i < 1000; i++)
		{
		  for (int j = i + 1; j <= 1000; j++)
		  {
		    if (N < i || N > j) continue;
		    bool noContain = true;
		    for (int k = 0; k < L; k++)
		    {
		      if (i <= S[k] && S[k] <= j)
		      {
		        noContain = false;
		        break;
		      }
		    }
		    if (!noContain) continue;
		    count++;
		  }
		}
		
		Console.WriteLine(count);
	}
}
