using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class P11728{
    public static void Main(string[] args){
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        string[] size = sr.ReadLine().Split(' ');
        string[] list1 = sr.ReadLine().Split(' ');
        string[] list2 = sr.ReadLine().Split(' ');

        List<string> list = new List<string>();
        list.AddRange(list1.AsEnumerable<string>());
        list.AddRange(list2.AsEnumerable<string>());
        List<int> nums = list.Select(x => int.Parse(x)).ToList();

        nums.Sort();
        
        StringBuilder sb = new StringBuilder();

        int prev = -1000000001;
        foreach(var c in nums){
            if (c != prev)
                sb.Append($"{c} ");
            prev = c;
        }
        Console.WriteLine(sb.ToString().Trim());

        sr.Close();
        sw.Close();
    }
}