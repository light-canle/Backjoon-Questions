using System;
using System.Linq;
using System.Collections.Generic;

// p5568 - 카드 놓기 (S4)
// #백트래킹
// 2025.3.7 solved

public class Program
{
    public static List<int> result;
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        List<int> list = new List<int>();
        for (int i = 0; i < n; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }
        result = new List<int>();
        Choice(list, new List<int>(), new bool[n], n, k, 0, 0);
        Console.WriteLine(result.Count);
    }
    // n개 증 k개를 고르는 모든 조합을 구한다.
    public static void Choice(List<int> list, List<int> cur, bool[] visited, int n, int k, int curChoice, int front)
    {
        if (curChoice == k)
        {
            GetOrder(cur);
            return;
        }

        // 조합을 구할 것이므로 front인자를 사용해 앞의 것을 가져오지 않게 한다.
        for (int i = front; i < n; i++)
        {
            if (visited[i]) continue;
            visited[i] = true;
            cur.Add(list[i]);
            Choice(list, cur, visited, n, k, curChoice + 1, i + 1);
            visited[i] = false;
            cur.RemoveAt(cur.Count - 1);
        }
    }

    public static void GetOrder(List<int> cur)
    {
        int len = cur.Count;
        GetOrder(cur, new List<int>(), new bool[len], len, len, 0);
    }

    // 구한 카드 조합에 대한 모든 순열을 구한 뒤 그 수들을 이어붙여 만든 수가
    // 중복되지 않은 경우 result에 추가한다.
    public static void GetOrder(List<int> list, List<int> cur, bool[] visited, int n, int k, int curChoice)
    {
        if (curChoice == k)
        {
            string ret = "";
            foreach (int i in cur)
            {
                ret += i.ToString();
            }
            int num = int.Parse(ret);
            if (!result.Contains(num))
            {
                result.Add(num);
            }
            return;
        }

        for (int i = 0; i < n; i++)
        {
            if (visited[i]) continue;
            visited[i] = true;
            cur.Add(list[i]);
            GetOrder(list, cur,  visited, n, k, curChoice + 1);
            visited[i] = false;
            cur.RemoveAt(cur.Count - 1);
        }
    }
}
