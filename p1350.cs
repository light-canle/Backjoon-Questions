using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        long[] fileSize = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
        long cluster = long.Parse(Console.ReadLine());
        long count = 0;

        for (int i = 0; i < n; i++)
        {
            long part = fileSize[i] / cluster;
            long remain = fileSize[i] % cluster;
            count += part + (remain > 0 ? 1 : 0);
        }

        Console.WriteLine(cluster * count);
    }
}
