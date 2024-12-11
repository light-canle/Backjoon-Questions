using System;

public class Program
{
  public static void Main(string[] args)
	{
		while (true)
		{
		    string input = Console.ReadLine();
		        
		    if (input == null || input == "")
		    {
		        break;
		    }
		    else
		    {
		        long[] l = Array.ConvertAll(input.Split(), long.Parse);
		        long n = l[0], k = l[1];
		            
		        long total = 0, stamp = 0;
		        while (n > 0)
		        {
		            total += n;
                    stamp += n;
                    n = 0;
                    long add = stamp / k;
                    n += add;
                    stamp -= add * k;
		        }
                
		        Console.WriteLine(total);
		    }
    }
	}
}
