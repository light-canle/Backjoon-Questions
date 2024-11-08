using System;
using System.Collections.Generic;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<BigInteger> list = new List<BigInteger>();

        list.Add(new BigInteger(1));
        list.Add(new BigInteger(1));

        for (int i = 2; i < n; i++)
        {
            list.Add(list[i - 1] + list[i - 2]);
        }

        BigInteger w = 1;
        BigInteger h = 1;
        for (int i = 2; i <= n; i++)
        {
            if (i % 2 == 0) h += list[i - 1];
            else w += list[i - 1];
        }

        Console.WriteLine((w + h) * 2);
    }
}
