using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		List<int> profit = new List<int>();
		List<int> cost = new List<int>();
		for (int i = 0; i < N; i++)
		{
		  int[] S = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
		  profit.Add(S[0]);
		  cost.Add(S[1]);
		}
		
		int maxProfit = 0;
		int price = 0;
		
		for (int i = 1; i <= 1000000; i++)
		{
		  int curProfit = 0;
		  for (int j = 0; j < N; j++)
		  {
		    if (i <= profit[j] && i > cost[j])
		    {
		      curProfit += i - cost[j];
		    }
		  }
		  if (curProfit > maxProfit)
		  {
		    maxProfit = curProfit;
		    price = i;
		  }
		}
		
		Console.WriteLine(price);
	}
}
