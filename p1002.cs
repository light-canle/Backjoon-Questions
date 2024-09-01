using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main(string[] args)
	{
		int N = int.Parse(Console.ReadLine());
		
		for (int i = 0; i < N; i++)
		{
		  long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
		  
		  long x1 = input[0], y1 = input[1], r1 = input[2];
		  long x2 = input[3], y2 = input[4], r2 = input[5];
		  
		  // 1. 두 원 일치
		  if (x1 == x2 && y1 == y2 && r1 == r2)
		  {
		    Console.WriteLine(-1);
		    continue;
		  }
		  
		  long dist = DistSquare(x1, y1, x2, y2);
		  long dSquare = (r1 - r2) * (r1 - r2);
		  long rSquare = (r1 + r2) * (r1 + r2);
		  // 2. 외접 또는 내접
		  if (dist == rSquare || dist == dSquare)
		  {
		    Console.WriteLine(1);
		    continue;
		  }
		  
		  // 3. 만나지 않거나 한 원이 다른 원에 포함
		  if (dist > rSquare || dist < dSquare)
		  {
		    Console.WriteLine(0);
		    continue;
		  }
		  
		  // 4. 두 점에서 만남 (R - r < dist < R + r)
		  Console.WriteLine(2);
		}
	}
	public static long DistSquare(long x1, long y1, long x2, long y2)
	{
		return (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
	}
}
