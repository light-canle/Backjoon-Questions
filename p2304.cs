using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<(int, int)> height = new List<(int, int)>();

        for (int i = 0; i < N; i++)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            height.Add((input[0], input[1]));
        }
        height.Sort((x, y) => x.Item1.CompareTo(y.Item1));

        (int, int) maxHeight = height[0];
        for (int i = 1; i < N; i++)
        {
            if (height[i].Item2 > maxHeight.Item2)
            {
                maxHeight = height[i];
            }
        }
        Stack<(int, int)> left = new();
        Stack<(int, int)> right = new();

        left.Push(height[0]);
        right.Push(height[^1]);
        int area = 0;
        
        for (int i = 1; i < N; i++)
        {
            if (height[i].Item2 > left.Peek().Item2)
            {
                area += left.Peek().Item2 * (height[i].Item1 - left.Peek().Item1);
                left.Push(height[i]);
            }
        }

        for (int i = N - 2; i >= 0; i--)
        {
            if (height[i].Item2 > right.Peek().Item2)
            {
                area += right.Peek().Item2 * (right.Peek().Item1 - height[i].Item1);
                right.Push(height[i]);
            }
        }

        area += maxHeight.Item2;
        area += (right.Peek().Item1 - maxHeight.Item1) * right.Peek().Item2;
        area += (maxHeight.Item1 - left.Peek().Item1) * left.Peek().Item2;

        Console.WriteLine(area);
    }
}
