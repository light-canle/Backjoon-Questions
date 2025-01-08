using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<string> list = new();
        for (int i = 0; i < n; i++)
        {
            list.Add(Console.ReadLine());
        }
        
        int count = 0;
        while (list.Count > 0)
        {
            string word = list[0];
            count++;
            int len = word.Length;
            for (int i = 0; i < len; i++)
            {
                if (list.Contains(word))
                {
                    list.RemoveAll(w => w == word);
                }
                string temp = word.Substring(1);
                temp += word[0];
                word = temp;
            }
        }
        Console.WriteLine(count);
    }
}
