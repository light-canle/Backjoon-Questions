using System;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        string s = "WelcomeToSMUPC";

        Console.WriteLine(s[(N - 1) % s.Length]);
    }
}
