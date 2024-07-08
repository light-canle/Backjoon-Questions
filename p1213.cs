using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int[] count = new int[26];
        string s = Console.ReadLine();
        for (int i = 0; i < s.Length; i++)
        {
            count[s[i] - 'A']++;
        }
        int len = s.Length;

        char oddCount = '\0';
        if (len % 2 == 0)
        {
            for (int i = 0; i < 26; i++)
            {
                if (count[i] % 2 != 0)
                {
                    Console.WriteLine("I'm Sorry Hansoo");
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < 26; i++)
            {
                if (count[i] % 2 != 0)
                {
                    if (oddCount != '\0')
                    {
                        Console.WriteLine("I'm Sorry Hansoo");
                        return;
                    }
                    else
                    {
                        oddCount = (char)('A' + i);
                    }
                }
            }
        }

        string p = "";
        for (int i = 0; i < 26; i++)
        {
            p += new string((char)('A' + i), count[i] / 2);
        }

        if (len % 2 == 0)
        {
            p += new string(p.Reverse().ToArray());
        }
        else
        {
            string rev = new string(p.Reverse().ToArray());
            p += oddCount;
            p += rev;
        }
        Console.WriteLine(p);
    }
}
