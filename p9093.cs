#pragma warning disable CS8604, CS8602

using System;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < N; i++)
        {
            string[] words = Console.ReadLine().Split();
            for (int j = 0; j < words.Length; j++)
            {
                words[j] = Reverse(words[j]);
            }
            Console.WriteLine(string.Join(" ", words));
        }
    }

    public static string Reverse(string word)
    {
        int len = word.Length;
        string s = "";
        for (int i = len - 1; i >= 0; i--)
        {
            s += word[i];
        }
        return s;
    }
}
