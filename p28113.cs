using System;

// p28113 - 정보섬의 대중교통 (B5)
// #구현
// 2025.6.27 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] line = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        int n = line[0], a = line[1], b = line[2];
        if (a > b)
        {
            Console.WriteLine("Subway");
        }
        else if (a < b)
        {
            Console.WriteLine("Bus");
        }
        else
        {
            Console.WriteLine("Anything");
        }
    }
}
