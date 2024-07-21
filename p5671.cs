using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        bool[] list = new bool[5001];

        for (int i = 1; i <= 5000; i++)
        {
            list[i] = !Duplicate(i);
        }
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "" || input == null)
            {
                return;
            }

            int[] range = input.Split(' ').Select(int.Parse).ToArray();

            int s = range[0];
            int e = range[1];

            int c = 0;
            for (int i = s; i <= e; i++)
            {
                if (list[i]) c++;
            }
            Console.WriteLine(c);
        }
    }

    public static bool Duplicate(int num)
    {
        int[] count = new int[10];
        string numStr = num.ToString();

        for (int i = 0; i < numStr.Length; i++)
        {
            count[numStr[i] - '0']++;
        }

        for (int i = 0; i < 10; i++)
        {
            if (count[i] > 1) return true;
        }
        return false;
    }
}
