using System;

public class Program
{
    public static void Main(string[] args)
    {
        int k = int.Parse(Console.ReadLine());
        int digit = (int)Math.Log2(k + 1);
        int powDigit = (int)Math.Pow(2, digit) - 1;

        string ans = "";

        int order = k - powDigit;
        for (int i = 0; i < digit; i++)
        {
            if (order % 2 == 0)
            {
                ans = "4" + ans;
            }
            else
            {
                ans = "7" + ans;
            }
            order /= 2;
        }

        Console.WriteLine(ans);
    }
}
