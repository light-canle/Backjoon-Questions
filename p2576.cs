using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] nums = new int[7];
        bool hasOdd = false;
        int minOdd = 999999, sumOdd = 0;
        for (int i = 0; i < 7; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
            if (nums[i] % 2 == 1)
            {
                hasOdd = true;
                sumOdd += nums[i];
                minOdd = Math.Min(minOdd, nums[i]);
            }
        }
        if (hasOdd)
        {
            Console.WriteLine(sumOdd);
            Console.WriteLine(minOdd);
        }
        else
        {
            Console.WriteLine(-1);
        }
    }
}
