using System;

// p10162 - 전자레인지 (B3)
// #그리디
// 2025.3.13 solved

public class Program
{
    public static void Main(string[] args)
    {
        int min = int.Parse(Console.ReadLine());

        if (min % 10 != 0)
        {
            Console.WriteLine(-1);
            return;
        }
        int a = min / 300;
        min %= 300;
        int b = min / 60;
        min %= 60;
        int c = min / 10;
        Console.WriteLine(a + " " + b + " " + c);
    }
}
