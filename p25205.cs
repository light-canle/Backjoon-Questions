using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        char[] consonant = new char[] { 'q', 'w', 'e', 'r', 't', 'a', 's', 'd', 'f', 'g', 'z', 'x', 'c', 'v' };
        int n = int.Parse(Console.ReadLine());
        string name = Console.ReadLine();

        char last = name[^1];

        bool endByConsonant = false;
        foreach (char c in consonant)
        {
            if (c == last)
            {
                endByConsonant = true;
                break;
            }
        }
        Console.WriteLine(endByConsonant ? 1 : 0);
   }
}
