using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        string[] numbers = new string[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = Console.ReadLine()!;
        }

        int lastDigit = 1;
        while (!(NotOverlap(numbers, lastDigit))) lastDigit++;
        Console.WriteLine(lastDigit);
    }

    public static bool NotOverlap(string[] str, int lastDigit)
    {
        List<string> lastPart = new List<string>();

        foreach (string s in str)
        {
            int len = s.Length;
            string part = s.Substring(len - lastDigit);
            if (lastPart.Contains(part)) return false;
            lastPart.Add(part);
        }
        return true;
    }
}
