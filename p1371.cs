using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<string> lines = new();
        while (true)
        {
            string line = Console.ReadLine();
            if (line == null)
            {
                break;
            }
            lines.Add(line);
        }

        int[] frequency = new int[26];
        foreach (var line in lines)
        {
            foreach (var c in line)
            {
                if ('a' <= c && c <= 'z')
                {
                    frequency[(int)(c - 'a')]++;
                }
            }
        }

        int maxFreq = 0;
        string ret = "";
        for (int i = 0; i < 26; i++)
        {
            if (frequency[i] > maxFreq)
            {
                maxFreq = frequency[i];
                ret = ((char)('a' + i)).ToString();
            }
            else if (frequency[i] == maxFreq)
            {
                ret += ((char)('a' + i)).ToString();
            }
        }
        Console.WriteLine(ret);
    }
}
