using System;
using System.Linq;
using System.Collections.Generic;

// p14244 - 트리 만들기 (S4)
// #트리 #해 구성하기
// 2025.5.1 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1];
        // n개의 노드 중 m개가 리프인 트리
        /* 
        m = 2이면 (k-1, k)끼리만 연결하면 자연스럽게 0, n-1이 리프가 된다.
        m = l (3 <= l <= n - 1)일 경우에는 3번 부터 l - 2개의 노드는 1번 노드와 연결하고 나머지는 k-1번과 연결시키면 된다. - n이 4 이상일 때 적용
        이러면 0, 2, ... l - 1번과 n-1번 노드가 리프가 된다.
        */
        List<(int, int)> ret = new();
        int toMove = m - 2;
        for (int i = 1; i < n; i++)
        {
            // i번 노드는 어디에 연결할 것인가?
            int connect = i - 1;
            if (3 <= i && i <= 2 + toMove)
            {
                connect = 1;
            }
            ret.Add((connect, i));
        }
        ret = ret.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();
        foreach (var k in ret)
        {
            Console.WriteLine($"{k.Item1} {k.Item2}");
        }
    }
}
