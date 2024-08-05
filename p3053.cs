using System;

public class Program
{
    public static void Main(string[] args)
    {
        int R = int.Parse(Console.ReadLine());

        double pi = Math.PI;
        Console.WriteLine($"{R * R * pi:F6}");
        Console.WriteLine($"{2 * R * R:F6}");
    }
}
