using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main(string[] args)
	{
		long N = long.Parse(Console.ReadLine());
			
		long count = 0;
		for (int i = 9; i >= 0; i--)
		{
			long p = (long)Math.Pow(10, i);
			if (p <= N)
			{
			  count += (N - p + 1) * (long)(i + 1);
			  count %= 1234567;
			  N = p - 1;
			}
		}
		Console.WriteLine(count);
	}
}
