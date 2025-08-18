using System;

// p10569 - 다면체 (B4)
// #기하학
// 2025.8.19 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int[] info = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int v = info[0], e = info[1];
            // v - e + f = 2 => f = e - v + 2
            Console.WriteLine(e - v + 2);
        }
    }
}
