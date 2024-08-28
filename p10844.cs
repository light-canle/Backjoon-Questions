using System;

public class Program
{
  public static void Main(string[] args)
  {
    const long K = 1_000_000_000;
    int N = int.Parse(Console.ReadLine());
    
    long[] count = new long[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    long[] tmp = new long[10];
    
    for (int i = 1; i < N; i++)
    {
      for (int j = 0; j < 10; j++)
      {
        if (j == 0)
        {
          tmp[j] = count[j + 1] % K;
        }
        else if (j == 9)
        {
          tmp[j] = count[j - 1] % K;
        }
        else
        {
          tmp[j] = (count[j - 1] + count[j + 1]) % K;
        }
      }
      for (int j = 0; j < 10; j++)
      {
        count[j] = tmp[j];
      }
    }
    
    long ret = 0;
    for (int i = 0; i < 10; i++)
    {
      ret += count[i];
      ret %= K;
    }
    
    Console.WriteLine(ret);
  }
}
