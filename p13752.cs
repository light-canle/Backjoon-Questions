using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('=', k));
        }
    }
}
