using System;

public class Program
{
    public static void Main(string[] args)
    {
        for (int i = 1000; i <= 9999; i++)
        {
            int d10 = DigitSum(i, 10);
            int d12 = DigitSum(i, 12);
            int d16 = DigitSum(i, 16);
            if (d10 == d12 && d12 == d16)
            {
                Console.WriteLine(i);
            }
        }
    }

    public static int DigitSum(int number, int b)
    {
        int digitSum = 0;
        while (number > 0)
        {
            digitSum += number % b;
            number /= b;
        }
        return digitSum;
    }
}
