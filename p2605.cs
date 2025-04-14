using System;
using System.Linq;
using System.Collections.Generic;

// p2605 - 줄 세우기 (B2)
// #가변 배열
// 2025.4.14 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

        List<int> ret = new();
        // insert로 해당 번호를 뽑은 인덱스에 삽입
        for (int i = 1; i <= n; i++)
        {
            ret.Insert(list[i - 1], i);
        }
        // 배열을 뒤집어야 규칙에 부합한다.
        ret.Reverse();
        Console.WriteLine(string.Join(" ",ret));
    }
}
