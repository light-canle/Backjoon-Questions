using System;

public class Program
{
    public static void Main(string[] args)
    {
        string str = Console.ReadLine();
        int len = str.Length;

        int c = 0;
        for (int i = 0; i < len; i++)
        {
            if (str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || str[i] == 'o' || str[i] == 'u')
            {
                c++;
            }
        }
        Console.WriteLine(c);
    }
}
