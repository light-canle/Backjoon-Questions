using System;

public class Program
{
	  public static void Main(string[] args)
	  {
	      int caseNum = 1;
	      while (true)
	      {
	          long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
	          long L = input[0], P = input[1], V = input[2];
	    
	          if (L == 0 && P == 0 && V == 0) break;
	    
	          long amount = (V / P) * L + (V % P < L ? V % P : L);
	          Console.WriteLine($"Case {caseNum}: {amount}");
            caseNum++;
	      }
	  }
}
