using System;
using System.Linq;
using System.Collections.Generic;

// p10871 - X보다 작은 수, B5
// 해결 날짜 : 2023/8/20

public class Program
{
    public static void Main(string[] args)
    {
        List<int> inform = Console.ReadLine().Split(' ')
            .Select(x => int.Parse(x)).ToList();
        List<int> list = Console.ReadLine().Split(' ')
            .Select(x => int.Parse(x)).ToList();

        List<int> answer = list.Where(x => x < inform[1]).ToList();

        foreach(int x in answer)
        {
            Console.Write(x.ToString() + ' ');
        }
    }
}
