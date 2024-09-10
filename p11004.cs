using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
  public static void Main(string[] args)
  {
    int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    int n = input[0], k = input[1];
    
    List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
    list.Sort();
    
    Console.WriteLine(list[k - 1]);
  }
}
