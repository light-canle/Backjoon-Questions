using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
  public static void Main(string[] args)
  {
    long n = long.Parse(Console.ReadLine());

    string ans = Convert(n);
    Console.WriteLine(ans);
  }

  public static string Convert(long n)
  {
    if (n == 0) return "0";
    List<char> ans = new();
    while (n != 0)
    {
      (long q, long r) = DivMod(n, -2l);
      n = q;
      ans.Add(r == 0 ? '0' : '1');
    }
    ans.Reverse();
    return new string(ans.ToArray());
  }

  public static (long, long) DivMod(long a, long b)
  {
    long q = a / b;
    long r = a % b;

    if (r < 0)
    {
      q++;
      r += Math.Abs(b);
    }
    return (q, r);
  }
}
