using System;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string n = Console.ReadLine();
            if (n == "" || n == null)
            {
                break;
            }
            int num = int.Parse(n);
            Console.WriteLine(num % 6 == 0 ? "Y" : "N");
        }
    }
}
