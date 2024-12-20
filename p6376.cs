using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("n e");
        Console.WriteLine("- -----------");

        double e = 0;
        for (int n = 0; n < 10; n++)
        {
            e += 1 / Factorial(n);
            if (n < 3)
                Console.WriteLine(n + " " + e);
            else
                Console.WriteLine($"{n} {e:F9}");
        }
    }

    public static double Factorial(int n)
    {
        if (n == 0)
            return 1.0;
        else
            return n * Factorial(n - 1);
    }
}
