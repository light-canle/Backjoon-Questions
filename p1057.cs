using System;
using System.Linq;
using System.Collections.Generic;

public class Program{
    public static void Main(string[] args){
        List<int> input = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToList();
        int round = 1;
        int kim_num = input[1];
        int lim_num = input[2];

        while ((int)(Math.Ceiling(kim_num / 2.0)) != (int)(Math.Ceiling(lim_num / 2.0))){
            round++;
            kim_num = (int)(Math.Ceiling(kim_num / 2.0));
            lim_num = (int)(Math.Ceiling(lim_num / 2.0));
        }
        
        Console.WriteLine(round);
    }
}