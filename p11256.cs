using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine());

        for (int i = 0; i < T; i++)
        {
            int[] line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int J = line[0];
            int N = line[1];
            List<int> boxes = new List<int>();
            for (int j = 0; j < N; j++)
            {
                int[] box = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                boxes.Add(box[0] * box[1]);
            }
            boxes.Sort();
            boxes.Reverse();
            int minCount = 0;
            for (int j = 0; j < N; j++)
            {
                minCount++;
                if (J <= boxes[j])
                    break;
                J -= boxes[j];
            }
            Console.WriteLine(minCount);
        }
    }
}
