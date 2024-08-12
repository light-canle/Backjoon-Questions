using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        string a = Console.ReadLine();      
        string b = Console.ReadLine();

        int len = a.Length;
        int len2 = b.Length;

        int[,] lcs = new int[len + 1, len2 + 1];
        string ans = "";

        for (int i = 0; i <= len; i++)
        {
            for (int j = 0; j <= len2; j++)
            {
                if (i == 0 || j == 0)
                {
                    lcs[i, j] = 0;
                }
                else if (a[i - 1] == b[j - 1])
                {
                    lcs[i, j] = lcs[i - 1, j - 1] + 1;
                }
                else
                {
                    lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                }
            }
        }

        int y = len, x = len2;

        while (lcs[y, x] != 0)
        {
            if (lcs[y - 1, x] == lcs[y, x])
            {
                y--;
            }
            else if (lcs[y, x - 1] == lcs[y, x])
            {
                x--;
            }
            else
            {
                ans += a[y - 1];
                y--;
                x--;
            }
        }
        Console.WriteLine(lcs[len, len2]);
        foreach (char c in ans.Reverse())
        {
            Console.Write(c);
        }
        Console.WriteLine();
    }
}
