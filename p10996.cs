using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        if (n == 1)
        {
            Console.WriteLine("*");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(Repeat("* ", n / 2) + (n % 2 == 1 ? "*" : ""));
            Console.WriteLine(Repeat(" *", n / 2) + (n % 2 == 1 ? " " : ""));
        }
    }

    public static string Repeat(string s, int n)
    {
        string result = "";
        for (int i = 0; i < n; i++)
        {
            result += s;
        }
        return result;
    }
}
