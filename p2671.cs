using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        string str = Console.ReadLine();
        Regex regex = new Regex(@"^((100+1+)|(01))+$");
        Match m = regex.Match(str);

        if (m.Success)
        {
            Console.WriteLine("SUBMARINE");
        }
        else
        {
            Console.WriteLine("NOISE");
        }
    }
}
