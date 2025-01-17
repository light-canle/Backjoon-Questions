#pragma warning disable CS8604, CS8602, CS8600

using System;

public class Program
{
    public static void Main(string[] args)
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();

        int aLen = a.Length, bLen = b.Length;

        int[] countA = new int[26];
        int[] countB = new int[26];

        for (int i = 0; i < aLen; i++)
        {
            countA[a[i] - 'a']++;
        }
        for (int i = 0; i < bLen; i++)
        {
            countB[b[i] - 'a']++;
        }

        int toRemove = 0;
        for (int i = 0; i < 26; i++)
        {
            if (countA[i] > countB[i])
            {
                toRemove += countA[i] - countB[i];
            }
            else
            {
                toRemove += countB[i] - countA[i];
            }
        }
        Console.WriteLine(toRemove);
    }
}
