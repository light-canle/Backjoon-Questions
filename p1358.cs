using System;

// p1358 - 하키 (S4)
// #기하학
// 2025.8.29 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        double w = input[0], h = input[1], x = input[2], y = input[3];
        double r = h / 2.0;
        int p = input[4];

        int inLink = 0;
        for (int i = 0; i < p; i++)
        {
            bool hasInLink = false;
            double[] pos = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
            double px = pos[0], py = pos[1];

            if (x <= px && px <= x + w)
            {
                hasInLink = y <= py && py <= y + h;
            }
            else if (x - r <= px && px < x)
            {
                hasInLink = Distance(x, y + r, px, py) <= r;
            }
            else if (x + w < px && px <= x + w + r)
            {
                hasInLink = Distance(x + w, y + r, px, py) <= r;
            }
            inLink += hasInLink ? 1 : 0;
        }
        Console.WriteLine(inLink);
    }

    public static double Distance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(Math.Abs(x2-x1), 2) + Math.Pow(Math.Abs(y2-y1), 2));
    }
}
