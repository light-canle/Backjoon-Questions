using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
  public static void Main(string[] args)
  {
    string input = Console.ReadLine();
    int len = input.Length;
    int count = 0;
    for (int i = 0; i <= len - 4; i++)
    {
      string cur = input.Substring(i, 4);
      if (cur == "DKSH")
      {
        count++;
      }
    }
    Console.WriteLine(count);
  }
}
