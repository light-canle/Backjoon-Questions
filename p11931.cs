using System;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(sr.ReadLine());

        List<int> nums = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(sr.ReadLine());
            nums.Add(num);
        }

        nums.Sort();
        nums.Reverse();

        sw.WriteLine(string.Join("\n", nums));
        sw.Flush();

        sr.Close();
        sw.Close();
    }
}
