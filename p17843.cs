using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int[] time = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int h = time[0], m = time[1], s = time[2];

            List<double> angles = ClockHandAngle(h, m, s);

            angles.Sort();

            double minAngle = Math.Min(angles[1] - angles[0], angles[2] - angles[1]);
            minAngle = Math.Min(minAngle, 360 + angles[0] - angles[2]);

            Console.WriteLine(minAngle);
        }

    }

    public static List<double> ClockHandAngle(int h, int m, int s)
    {
        double sAngle = s * 6.0;
        double mAngle = m * 6.0 + s / 10.0;
        double hAngle = h * 30.0 + m / 2.0 + s / 120.0;

        return new List<double>(new double[] { hAngle, mAngle, sAngle });
    }
}
