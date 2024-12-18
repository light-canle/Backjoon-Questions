using System;

public class Program
{
    public static void Main(string[] args)
    {
        string find = Console.ReadLine();
        int flen = find.Length;

        int n = int.Parse(Console.ReadLine());

        string[] words = new string[n];

        for (int i = 0; i < n; i++)
        {
            words[i] = Console.ReadLine();
        }
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            bool found = false;
            for (int j = 0; j < 10; j++)
            {
                string match = "";
                for (int k = 0; k < flen; k++)
                {
                    match += words[i][(j + k) % 10];
                }
                if (match == find)
                {
                    found = true;
                    break;
                }
            }
            if (found) count++;
        }
        Console.WriteLine(count);
    }
}
