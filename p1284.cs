using System;

public class Program {
	public static void Main() {
		while (true)
		{
		    string n = Console.ReadLine();
		    if (n == "0")
		    {
		        break;
		    }
		    Console.WriteLine(Length(n));
		}
	}
	public static int Length(string n)
	{
	    int ret = 2;
	    foreach (char c in n)
	    {
	        switch(c)
	        {
	         case '0':
	             ret += 4;
	             break;
	         case '1':
	             ret += 2;
	             break;
	         default:
	             ret += 3;
	             break;
	        }
	    }
	    return ret + n.Length - 1;
    }
}
