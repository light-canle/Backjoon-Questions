#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;

// p17388 - 와글와글 숭고한 (B4)
// #구현
// 2025.12.29 solved (12.28)

public class Program
{
    public static void Main(string[] args)
    {
        int[] points = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        if (points.Sum() >= 100)
        {
            Console.WriteLine("OK");
        }
        else if (points[0] == points.Min())
        {
            Console.WriteLine("Soongsil");
        }
        else if (points[1] == points.Min())
        {
            Console.WriteLine("Korea");
        }
        else
        {
            Console.WriteLine("Hanyang");
        }
    }
}
