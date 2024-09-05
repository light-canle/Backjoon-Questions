using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.IO;
using System.Text;

public class Program
{
  public static void Main(string[] args)
	{
	  StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
	  int T = int.Parse(sr.ReadLine());
	  StringBuilder s = new StringBuilder();
	  for (int i = 0; i < T; i++)
	  {
	    long n = long.Parse(sr.ReadLine());
	    while (n >= 1)
	    {
	      string room = RoomNumber(n);
	      s.AppendLine(room);
	      n /= 2;
	    }
	  }
	  Console.WriteLine(s);
	  sr.Close();
	}
	
	public static int BinDigit(long n)
	{
	  int c = 0;
	  while (n > 0)
	  {
	    c++;
	    n /= 2;
	  }
	  return c;
	}
	
	public static string RoomNumber(long n)
	{
	  int floor = BinDigit(n);
	  string order = (n - Pow(2, floor - 1) + 1).ToString("D18");
	  
	  return floor + order;
	}
	
	public static long Pow(long a, int b)
	{
	  long ret = 1;
	  for (int i = 1; i <= b; i++)
	  {
	    ret *= a;
	  }
	  return ret;
	}
}
