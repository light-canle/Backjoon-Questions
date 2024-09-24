using System;
using System.Linq;
using System.Collections.Generic;

// p1152 단어의 개수, B2
// 해결 날짜 : 2023/8/19

public class Program
{
    public static void Main(string[] args)
    {
        List<string> list = Console.ReadLine().Trim().Split(' ').ToList();

        // 입력이 "  "일 때, 빈 문자열이 list에 들어가는 경우가 있어서
        // 길이가 0인 문자열들은 리스트에서 제거해 준다.
        list.RemoveAll(s => s.Length == 0);

        Console.WriteLine(list.Count());
    }
}
