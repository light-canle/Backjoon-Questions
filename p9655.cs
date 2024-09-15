using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(n % 2 == 0 ? "CY" : "SK");
    }
}
