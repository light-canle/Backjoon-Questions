#pragma warning disable CS8604, CS8602, CS8600

using System;


public class Program
{
    public static void Main(string[] args)
    {
        int month = int.Parse(Console.ReadLine());
        int day = int.Parse(Console.ReadLine());
        if (month == 1) 
        {
            Console.WriteLine("Before");
        }
        else if (month > 2)
        {
            Console.WriteLine("After");
        }
        else
        {
            if (day < 18)
            {
                Console.WriteLine("Before");
            }
            else if (day > 18) 
            {
                Console.WriteLine("After");
            }
            else
            {
                Console.WriteLine("Special");
            }
        }
    }
}
