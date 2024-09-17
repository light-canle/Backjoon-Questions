using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public class Program
{
  public static void Main(string[] args)
  {
    StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
    int n = int.Parse(sr.ReadLine());
    int[] input = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

    Dictionary<int, int> score = new Dictionary<int, int>();

    bool[] isExist = new bool[1000001];
    for (int i = 0; i < n; i++)
    {
      score[input[i]] = 0;
      isExist[input[i]] = true;
    }

    for (int i = 0; i < n; i++)
    {
      int k = input[i];
      while (k <= 1000000)
      {
        if (isExist[k])
        {
          score[k]--;
          score[input[i]]++;
        }
        k += input[i];
      }
    }

    List<int> result = new List<int>();

    for (int i = 0; i < n; i++)
    {
      result.Add(score[input[i]]);
    }

    Console.WriteLine(string.Join(" ", result));
  }
}
