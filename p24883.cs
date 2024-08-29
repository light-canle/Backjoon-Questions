using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main(string[] args)
	{
	    char input = Console.ReadLine()[0];
      Console.WriteLine((input == 'N' || input == 'n') ? "Naver D2" : "Naver Whale");
	}
}
