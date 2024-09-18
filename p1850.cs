using System;

public class Program
{
  public static void Main(string[] args)
  {
    long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

    long a = input[0];
    long b = input[1];

    long g = GCD(a, b);

    Console.WriteLine(new string('1', (int)g));
  }

  public static long GCD(long a, long b)
  {
    if (b == 0)
    {
      return a;
    }
    return GCD(b, a % b);
  }
}
