using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int M = int.Parse(sr.ReadLine());

        int[] f = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int Q = int.Parse(sr.ReadLine());

        List<int[]> slist = new ();
        for (int i = 0; i <= M; i++)
        {
            slist.Add(new int[19]);
        }

        for (int j = 0; j < 19; j++)
        {
            for (int i = 1; i <= M; i++)
            {
                if (j == 0)
                {
                    slist[i][j] = f[i - 1];
                }
                else
                {
                    slist[i][j] = slist[slist[i][j - 1]][j - 1];
                }
            }
        }

        StringBuilder o = new ();
        for (int i = 0; i < Q; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int n = line[0], x = line[1];

            int num = 1 << 18;
            for (int j = 18; j >= 0; j--)
            {
                if (num <= n)
                {
                    n -= num;
                    x = slist[x][j];
                }
                num /= 2;
            }

            o.AppendLine(x.ToString());
        }

        Console.WriteLine(o);
        sr.Close();
    }
}
