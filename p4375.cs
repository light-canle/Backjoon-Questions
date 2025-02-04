using System;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "" || line == null)
            {
                break;
            }
            BigInteger n = BigInteger.Parse(line);

            int digit = 0;
            BigInteger cur = 0;
            BigInteger toAdd = 1;

            do 
            {
                cur += toAdd;
                cur %= n;
                toAdd *= 10;
                digit++;
            }
            while (cur > 0);
            Console.WriteLine(digit);
        }
    }
}
