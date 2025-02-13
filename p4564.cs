using System;
using System.Collections.Generic;

// p4564 - 숫자 카드놀이 (B2)
// #구현
// 2025.2.13 solved

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 0) break;

            List<int> list = new List<int>();
            list.Add(n);
            while (n > 9)
            {
                n = DigitProduct(n);
                list.Add(n);
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }

    public static int DigitProduct(int n)
    {
        int product = 1;
        string s = n.ToString();
        foreach (char c in s)
        {
            product *= int.Parse(c.ToString());
        }
        return product;
    }
}
