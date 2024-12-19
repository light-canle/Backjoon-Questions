using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        Dictionary<string, int> dict = new Dictionary<string, int>();
        for (int i = 0; i < t; i++)
        {
            dict.Clear();
            int n = int.Parse(Console.ReadLine());
            for (int j = 0; j < n; j++)
            {
                string[] input = Console.ReadLine().Split();
                dict[input[0]] = int.Parse(input[1]);
            }
            int max = 0;
            string maxName = "";
            foreach (var item in dict)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    maxName = item.Key;
                }
            }
            Console.WriteLine(maxName);
        }
    }
}
