using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        
        int t = int.Parse(sr.ReadLine());
        for (int i = 0; i < t; i++)
        {
            sr.ReadLine();
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

            int n = nums[0];
            int m = nums[1];

            List<int> corpsA = sr.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> corpsB = sr.ReadLine().Split(' ').Select(int.Parse).ToList();

            corpsA.Sort();
            corpsB.Sort();

            int a = 0, b = 0;
            while (a < n && b < m)
            {
                if (corpsA[a] < corpsB[b])
                {
                    a++;
                }
                else
                {
                    b++;
                }
            }

            if (a == n)
            {
                Console.WriteLine("B");
            }
            else
            {
                Console.WriteLine("S");
            }
        }
        sr.Close();       
    }    
}
