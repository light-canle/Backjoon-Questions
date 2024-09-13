using System;
using System.Numerics;

public class Program
{
  public static void Main(string[] args)
  {
    int n = int.Parse(Console.ReadLine());

    if (n % 2 == 0 || n % 5 == 0)
    {
      Console.WriteLine(-1);
      return;
    }
    BigInteger cur = 1 % n;
    BigInteger k = 10 % n;
    int digit = 1;
    while (cur != 0)
    {
      cur = (cur + k) % n;
      k = (k * 10) % n;
      digit++;
    }
    Console.WriteLine(digit);
  }
}
