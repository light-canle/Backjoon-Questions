using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<List<int>> bingo = new();

        for (int i = 0; i < 5; i++)
        {
            bingo.Add(Console.ReadLine().Split().Select(int.Parse).ToList());
        }
        List<int> order = new();

        for (int i = 0; i < 5; i++)
        {
            order.AddRange(Console.ReadLine().Split().Select(int.Parse).ToList());
        }

        List<List<bool>> selected = new();
        for (int i = 0; i < 5; i++)
        {
            selected.Add(new List<bool>(Enumerable.Repeat(false, 5)));
        }

        int count = 0;
        foreach (int num in order)
        {
            count++;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (bingo[i][j] == num)
                    {
                        selected[i][j] = true;
                    }
                }
            }

            int completedLine = 0;
            // line check
            bool linePass = true;
            for (int i = 0; i < 5; i++)
            {
                linePass = true;
                for (int j = 0; j < 5; j++)
                {
                    if (!selected[i][j])
                    {
                        linePass = false;
                        break;
                    }
                }
                completedLine += linePass ? 1 : 0;
            }
            for (int i = 0; i < 5; i++)
            {
                linePass = true;
                for (int j = 0; j < 5; j++)
                {
                    if (!selected[j][i])
                    {
                        linePass = false;
                        break;
                    }
                }
                completedLine += linePass ? 1 : 0;
            }

            linePass = true;
            for (int i = 0; i < 5; i++)
            {
                if (!selected[i][i])
                {
                    linePass = false;
                    break;
                }
            }
            completedLine += linePass ? 1 : 0;
            linePass = true;
            for (int i = 0; i < 5; i++)
            {
                if (!selected[i][4 - i])
                {
                    linePass = false;
                    break;
                }
            }
            completedLine += linePass ? 1 : 0;
            if (completedLine >= 3)
            {
                Console.WriteLine(count);
                break;
            }
        }
    }
}
