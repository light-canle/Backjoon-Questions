using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        if (n == 1 || n == 3)
        {
            Console.WriteLine(-1);
            return;
        }

        int c5 = n / 5;
        int remain = n % 5;
        while (remain % 2 != 0)
        {
            c5--;
            remain += 5;
        }
        Console.WriteLine(c5 + remain / 2);
    }
}
