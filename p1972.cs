using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        while (true)
        {
            string input = sr.ReadLine();
            if (input == "*")
            {
                break;
            }
            int len = input.Length;
            List<string> pairs = new();
            bool isSurprising = true;
            for (int i = 0; i < len - 1; i++)
            {
                pairs.Clear();
                for (int p = 0; p + i + 1 < len; p++)
                {
                    string pair = input[p].ToString() + input[p + i + 1];
                    if (pairs.Contains(pair))
                    {
                        isSurprising = false;
                        break;
                    }
                    pairs.Add(pair);
                }
                if (!isSurprising)
                    break;
            }
            if (isSurprising)
                sw.WriteLine($"{input} is surprising.");
            else
                sw.WriteLine($"{input} is NOT surprising.");
        }
        sw.Flush();
        sr.Close();
        sw.Close();       
    }
}
