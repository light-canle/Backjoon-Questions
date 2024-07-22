using System;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        string str = N.ToString();

        int ans = 0;
        for (int i = 0; i < str.Length; i++)
        {
            int power = str.Length - i - 1;
            int digit = int.Parse(str[i].ToString());
            ans += (digit <= 3 ? digit : digit - 1) * (int)Math.Pow(9, power);
        }

        Console.WriteLine(ans);
    }
}
