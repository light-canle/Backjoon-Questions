using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
  public static void Main(string[] args)
	{
	  StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
	  long[] input = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
	  long n = input[0], p = input[1], q = input[2];
	  Dictionary<long, long> seq = new Dictionary<long, long>();
	  seq[0] = 1;
	  
	  long ans = Find(seq, n, p, q);
	  Console.WriteLine(ans);
	  sr.Close();
	}
	
	public static long Find(Dictionary<long, long> seq, long n, long p, long q)
	{
	  if (seq.ContainsKey(n))
	  {
	    return seq[n];
	  }
	  
	  long a = Find(seq, n / p, p, q);
	  long b = Find(seq, n / q, p, q);
	  
	  return seq[n] = a + b;
	}
}
