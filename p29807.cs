using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine());

        List<int> score = Console.ReadLine().Split().Select(int.Parse).ToList();

        if (T != 5)
            score.AddRange(Enumerable.Repeat(0, 5 - T));

        long id = 0;
        id += score[0] > score[2] ? (score[0] - score[2]) * 508 : (score[2] - score[0]) * 108;
        id += score[1] > score[3] ? (score[1] - score[3]) * 212 : (score[3] - score[1]) * 305;
        id += score[4] * 707;
        id *= 4763;
        Console.WriteLine(id);
    }
}
