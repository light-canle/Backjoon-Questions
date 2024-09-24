using System;
using System.Linq;
using System.Collections.Generic;


public class Program
{
    public static void Main(string[] args)
    {
        List<int> list = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToList();
        if (list[0] == list[1]) Console.WriteLine("==");
        else if (list[0] > list[1]) Console.WriteLine(">");
        else Console.WriteLine("<");
    }
}
