using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        
        List<List<double>> mat = new List<List<double>>();
        
        for (int i = 0; i < N; i++)
        {
            mat.Add(Console.ReadLine().Split().Select(double.Parse).ToList());
        }
        
        for (int i = 0; i < N; i++)
        {
            int minRow = i;
            double minValue = mat[i][i];
            for (int j = 0; j < N; j++)
            {
                if (minValue > mat[j][i])
                {
                    minRow = j;
                    minValue = mat[j][i];
                }
            }
            
            List<double> tmp = mat[minRow];
            mat[minRow] = mat[i];
            mat[i] = tmp;
        }
        
        for (int i = 0; i < N - 1; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                double ratio = mat[j][i] / mat[i][i];
                for (int k = 0; k < N + 1; k++)
                {
                    mat[j][k] -= mat[i][k] * ratio;
                }
            }
        }
        
        for (int i = 0; i < N; i++)
        {
            double ratio = mat[i][i];
            for (int j = 0; j < N + 1; j++)
            {
                mat[i][j] /= ratio;
            }
        }
        
        double[] ret = new double[N];
        
        for (int i = N - 1; i >= 0; i--)
        {
            ret[i] = mat[i][N];
            for (int j = N - 1; j > i; j--)
            {
                ret[i] -= mat[i][j] * ret[j];
            }
            ret[i] = Math.Round(ret[i], 0);
        }
        
        /*
        foreach (var row in mat)
        {
            Console.WriteLine(string.Join(" ", row));
        }
        */
        Console.WriteLine(string.Join(" ", ret));
    }
}
