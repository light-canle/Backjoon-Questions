using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            long num = long.Parse(Console.ReadLine());

            bool isValid = true;
            for (long j = 2; j <= 1000000; j++)
            {
                if (num % j == 0)
                {
                    isValid = false;
                    break;
                }
            }
            Console.WriteLine(isValid ? "YES" : "NO");
        }
    }
}
