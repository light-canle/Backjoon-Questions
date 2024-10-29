using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Queue<int> queue = new Queue<int>();
        for (int i = 1; i <= n; i++)
        {
            queue.Enqueue(i);
        }
        List<int> ret = new List<int>();
        while (queue.Count > 1)
        {
            int a = queue.Dequeue();
            int b = queue.Dequeue();
            ret.Add(a);
            queue.Enqueue(b);
        }
        ret.Add(queue.Dequeue());
        Console.WriteLine(string.Join(" ", ret));
    }
}
