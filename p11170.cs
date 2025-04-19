using System;
using System.Linq;

// p11170 - 0의 개수 (B1)
// #구현
// 2025.4.19 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int[] c = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int l = c[0], r = c[1];
            
            int countZero = 0;
            for (int j = l; j <= r; j++)
            {
                countZero += j.ToString().Count(x => x == '0');
            }
            Console.WriteLine(countZero);
        }         
    }
}
