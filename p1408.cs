using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var current = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
        var goal = Console.ReadLine().Split(':').Select(int.Parse).ToArray();

        int curTime = current[0] * 3600 + current[1] * 60 + current[2];
        int goalTime = goal[0] * 3600 + goal[1] * 60 + goal[2];

        int time = 0;
        if (curTime > goalTime)
        {
            time = goalTime + 86400 - curTime;
        }
        else
        {
            time = goalTime - curTime;
        }
        int h = time / 3600;
        time -= h * 3600;
        int m = time / 60;
        time -= m * 60;
        int s = time;

        Console.WriteLine($"{h:D02}:{m:D02}:{s:D02}");
    }
}
