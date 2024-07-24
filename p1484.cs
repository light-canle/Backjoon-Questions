using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int G = int.Parse(Console.ReadLine());
        List<int> ans = new();
        int s = 1, e = 1;
        while (true)
        {
            if (e * e - s * s >= G) 
            {
                if (e * e - s * s > G && e - s == 1)
                    break;
                if (e * e - s * s == G)
                    ans.Add(e);
                s++;
            }
            else if (e * e - s * s < G) e++;
        }
        if (ans.Count == 0)
            Console.WriteLine(-1);
        else
        {
            foreach (int i in ans)
                Console.WriteLine(i);
        }
    }
}
