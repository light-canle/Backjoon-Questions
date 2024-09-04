using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main(string[] args)
	{
	  int[] S = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
	  int n = S[0], p = S[1];
	  
	  List<int> nums = new List<int>();
	  
	  nums.Add(n);
	  
	  int cur = DigitPowSum(n, p);
	  while(!nums.Contains(cur))
	  {
	    nums.Add(cur);
	    cur = DigitPowSum(cur, p);
	  }
	  
	  int index = nums.IndexOf(cur);
	  
	  Console.WriteLine(index);
	}
	
	public static int DigitPowSum(int n, int p)
	{
	  string s = n.ToString();
	  int ans = 0;
	  foreach (var c in s)
	  {
	    ans += (int)Math.Pow(c - '0', p);
	  }
	  return ans;
	}
}
