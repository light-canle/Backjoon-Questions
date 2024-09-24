using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1083 - 소트, G5
/// 시작 날짜 : 2023/9/9
/// </summary>

/*
'사전순으로 가장 뒷서는 것'의 의미를 정확하게 파악하지 못해서 미해결 된 문제
*/

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<string> list = Console.ReadLine().Split().ToList();
        int S = int.Parse(Console.ReadLine());

        var result = list;
        var finalSorted = list.OrderBy(x => x).Reverse().ToList();
        for (int i = 0; i < S; i++)
        {
            var currentList = list.ToList();
            for (int j = 0; j < N - 1; j++)
            {
                string temp = list[j];
                list[j] = list[j + 1];
                list[j + 1] = temp;
                if (string.Compare(string.Join(" ", list), string.Join(" ", result)) > 0)
                    result = list.ToList();
                list = currentList.ToList();
            }
            list = result.ToList();
            if (string.Compare(string.Join(" ", list), string.Join(" ", finalSorted)) == 0) break;
        }
        Console.WriteLine(string.Join(" ", result));
    }
}