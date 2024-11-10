using System;
using System.Collections.Generic;

public class Program
{
	public static void Main(string[] args)
	{
	  int n = int.Parse(Console.ReadLine());
	  
	  List<int> square = new List<int>();
	  
	  for (int i = 1; i * (i + 1) / 2 < 1_000_000_000; i++){
	    square.Add(i * (i + 1) / 2);
	  }
	  
	  int time = 0;
	  while (n > 0){
	    int t = Find(square, n);
	    int maxSmallerSquare = square[t];
	    n -= maxSmallerSquare;
	    time += (t + 1);
	  }
	  
	  Console.WriteLine(time);
	}
	
	public static int Find(List<int> list, int n)
	{
	  int ret = 0;
	  int len = list.Count;
	  while (list[ret] < n && ret < len - 1) ret++;
	  return list[ret] <= n ? ret : ret - 1;
	}
}
