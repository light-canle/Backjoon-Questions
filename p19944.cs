using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int N = line[0];
        int M = line[1];

        if (M == 1 || M == 2)
            Console.WriteLine("NEWBIE!");
        else if (N >= M)
            Console.WriteLine("OLDBIE!");
        else
            Console.WriteLine("TLE!");
    }
}
