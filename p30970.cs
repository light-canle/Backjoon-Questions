using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());

        List<(int, int)> list = new List<(int, int)>();
        for (int i = 0; i < n; i++)
        {
            int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
            list.Add((input[0], input[1]));
        }

        var r1 = list.OrderBy(x => -x.Item1).ThenBy(x => x.Item2).ToList();
        var r2 = list.OrderBy(x => x.Item2).ThenBy(x => -x.Item1).ToList();
        Console.WriteLine($"{r1[0].Item1} {r1[0].Item2} {r1[1].Item1} {r1[1].Item2}");
        Console.WriteLine($"{r2[0].Item1} {r2[0].Item2} {r2[1].Item1} {r2[1].Item2}");
        sr.Close();
    }
}
