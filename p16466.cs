using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        List<int> arr = sr.ReadLine().Split().Select(int.Parse).ToList();
        arr.Sort();
        
        int ticket = 1;
        int index = 0;
        while (true)
        {
            if (index >= n)
                break;
            if (arr[index] != ticket)
                break;
            index++; ticket++;
        }
        Console.WriteLine(ticket);
        sr.Close();
    }
}
