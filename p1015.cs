using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

        // 정렬된 리스트를 구함
        var sorted = list.OrderBy(x => x).ToList();

        List<int> ret = new();
        // 정렬된 리스트에서 원본 배열의 값의 인덱스를 구함 - 이미 있는 경우 그 다음 것을 찾음
        for (int i = 0; i < n; i++)
        {
            int index = sorted.IndexOf(list[i]);
            while (ret.Contains(index))
            {
                index = sorted.IndexOf(list[i], index + 1);
            }
            ret.Add(index);
        }
        Console.WriteLine(string.Join(" ", ret));
    }
}
