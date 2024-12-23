using System;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int len = input.Length;

        int height = 10;

        for (int i = 1; i < len; i++)
        {
            if (input[i] == input[i - 1])
            {
                height += 5;
            }
            else
            {
                height += 10;
            }
        }
        Console.WriteLine(height);
    }
}
