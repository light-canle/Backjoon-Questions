using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> triNums = new();
        int i = 1;
        int tri = 0;
        while (tri <= 1000)
        {
            tri += i;
            triNums.Add(tri);
            i++;
        }
        int N = int.Parse(Console.ReadLine());

        for (int j = 0; j < N; j++)
        {
            int num = int.Parse(Console.ReadLine());

            bool threeTri = false;
            for (int k = 0; k < triNums.Count; k++)
            {
                for (int l = 0; l < triNums.Count; l++)
                {
                    for (int m = 0; m < triNums.Count; m++)
                    {
                        if (triNums[k] + triNums[l] + triNums[m] == num)
                        {
                            threeTri = true;
                        }
                    }
                }
            }

            Console.WriteLine(threeTri ? 1 : 0);
        }
    }
}
