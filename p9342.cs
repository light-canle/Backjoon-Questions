using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string str = Console.ReadLine();
            Regex regex = new Regex(@"^[A-F]?A+F+C+[A-F]?$");
            Match m = regex.Match(str);
            if (m.Success)
            {
                Console.WriteLine("Infected!");
            }
            else
            {
                Console.WriteLine("Good");
            }
        }      
    }
}
