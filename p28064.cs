using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<string> words = new List<string>();
        for (int i = 1; i <= N; i++)
        {
            string word = Console.ReadLine();
            words.Add(word);
        }

        int pairCount = 0;

        for (int i = 0; i < N - 1; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                if (CanConnect(words[i], words[j]) || CanConnect(words[j], words[i]))
                {
                    pairCount++;
                }
            }
        }
        Console.WriteLine(pairCount);
    }

    public static bool CanConnect(string a, string b)
    {
        int min = Math.Min(a.Length, b.Length);

        bool connect = false;
        for (int i = 1; i <= min; i++)
        {
            if (a.Substring(a.Length - i) == b.Substring(0, i))
            {
                connect = true;
                break;
            }
        }

        return connect;
    }
}
