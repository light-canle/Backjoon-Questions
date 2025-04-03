using System;
using System.Linq;
using System.Collections.Generic;

// p2204 - 도비의 난독증 테스트 (B2)
// #문자열 #정렬
// 2025.4.3 solved

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 0)
            {
                break;
            }
            List<string> list = new();
            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }

            // 소문자 형태 기준 정렬
            list = list.OrderBy(x => x.ToLower()).ToList();
            Console.WriteLine(list[0]);
        }
    }
}
