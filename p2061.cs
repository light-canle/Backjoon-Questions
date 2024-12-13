using System;
using System.Numerics;

public class Progarm
{
    public static void Main(string[] args)
    {
        BigInteger[] nums = Array.ConvertAll(Console.ReadLine().Split(), BigInteger.Parse);
        var k = nums[0];
        var l = (int)nums[1];
        
        bool isSafe = true;
        int bad = 0;
        for (int i = 2; i < l; i++)
        {
            if (k % i == 0)
            {
                isSafe = false;
                bad = i;
                break;
            }
        }
        if (isSafe)
        {
            Console.WriteLine("GOOD");
        }
        else
        {
            Console.WriteLine($"BAD {bad}");
        }
    }
}
