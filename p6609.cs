using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string line = Console.ReadLine()!;
            if (line == null || line == "") 
            {
                return;
            }
            int[] input = line.Split(' ').Select(int.Parse).ToArray();
            int m = input[0], p = input[1], l = input[2];
            int e = input[3], r = input[4], s = input[5];
            int n = input[6];

            for (int i = 0; i < n; i++)
            {
                int nextL = e * m;
                int nextP = l / r;
                int nextM = p / s;

                l = nextL;
                p = nextP;
                m = nextM;
            }

            Console.WriteLine(m);
        }
    }
}
