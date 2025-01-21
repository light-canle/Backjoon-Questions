using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] toping = Console.ReadLine().Split();

        var cheeses = new List<string>();
        for (int i = 0; i < n; i++)
        {
            string t = toping[i];
            if (t.EndsWith("Cheese"))
            {
                if (!cheeses.Contains(t))
                {
                    cheeses.Add(t);
                }
            }
        }
        Console.WriteLine(cheeses.Count >= 4 ? "yummy" : "sad");
    }
}
