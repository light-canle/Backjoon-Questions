using System;

public class Program
{
    public static void Main(string[] args)
    {
        string docs = Console.ReadLine();
        string find = Console.ReadLine();

        int n = docs.Length;
        int w = find.Length;
        int cur = 0;

        int count = 0;
        while (cur + w <= n)
        {
            string sub = docs.Substring(cur, w);
            if (sub == find)
            {
                count++;
                cur += w;
            }
            else
            {
                cur++;
            }
        }
        Console.WriteLine(count);
    }
}
