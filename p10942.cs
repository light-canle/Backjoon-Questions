using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Program
{
  public static void Main(string[] args)
  {
    StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
    int n = int.Parse(sr.ReadLine());
    int[] input = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

    bool[,] dp = new bool[n+1, n+1];

    for (int i = 1; i <= n; i++)
    {
      for (int j = i; j <= n; j++)
      {
        if (i == j)
        {
          dp[i, j] = true;
        }
        else
        {
          dp[i, j] = Palindrome(input, i - 1, j - 1);
        }
      }
    }
    int Q = int.Parse(sr.ReadLine());
    StringBuilder sb = new();

    for (int k = 0; k < Q; k++)
    {
      int[] query = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
      int a = query[0];
      int b = query[1];
      sb.AppendLine(dp[a, b] ? "1" : "0");
    }
    Console.WriteLine(sb);
    sr.Close();
  }

  public static bool Palindrome(int[] arr, int start, int end)
  {
    if (start >= end)
    {
      return true;
    }
    else
    {
      if (arr[start] == arr[end])
      {
        return Palindrome(arr, start+1, end-1);
      }
      else
      {
        return false;
      }
    }
  }
}
