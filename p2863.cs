using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        double[] i1 = Console.ReadLine().Split().Select(double.Parse).ToArray();
        double a = i1[0], b = i1[1];
        double[] i2 = Console.ReadLine().Split().Select(double.Parse).ToArray();
        double c = i2[0], d = i2[1];
        double r0 = a / c + b / d;
        double r1 = c / d + a / b;
        double r2 = d / b + c / a;
        double r3 = b / a + d / c;
        double max = Math.Max(r0, Math.Max(r1, Math.Max(r2, r3)));
        double[] r = {r0, r1, r2, r3};
        for (int i = 0; i < 4; i++)
        {
            if (r[i] == max)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}
