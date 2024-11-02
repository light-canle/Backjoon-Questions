using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));

        StringBuilder s = new();
        int T = int.Parse(sr.ReadLine());

        for (int i = 0; i < T; i++)
        {
            int[] size = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            List<int> a = sr.ReadLine().Split().Select(int.Parse).ToList();
            List<int> b = sr.ReadLine().Split().Select(int.Parse).ToList();

            a.Sort(); b.Sort();
            int currentA = 0, currentB = 0;
            int aSize = size[0], bSize = size[1];
            int count = 0;
            while (currentA < aSize && currentB < bSize)
            {
                if (a[currentA] <= b[currentB])
                {
                    currentA++;
                    count += currentB;
                }
                else
                {
                    currentB++;
                }
            }
            while (currentA < aSize) 
            {
                count += bSize;
                currentA++;
            }
            s.AppendLine(count.ToString());
        }
        
        Console.WriteLine(s);
        sr.Close();
    }
}
