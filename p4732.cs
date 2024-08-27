using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, int> note = new Dictionary<string, int>() { {"C", 0}, {"C#", 1}, {"Db", 1}, {"D", 2}, {"D#", 3}, {"Eb", 3}, {"E", 4}, {"Fb", 4}, {"F", 5}, {"E#", 5}, {"F#", 6}, {"Gb", 6}, {"G", 7}, {"G#", 8}, {"Ab", 8}, {"A", 9}, {"A#", 10}, {"Bb", 10}, {"B", 11}, {"Cb", 11} };
        string[] code = new string[] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "***")
            {
                break;
            }
            var origin = input.Split().Select(x => x).ToList();
            
            int N = int.Parse(Console.ReadLine());
            var ret = new List<string>();
            
            for (int i = 0; i < origin.Count; i++)
            {
                ret.Add(code[(note[origin[i]] + N + 120) % 12]);
            }
            
            Console.WriteLine(string.Join(" ", ret));
        }
    }
}
