using System;
using System.Linq;
using System.Collections.Generic;

// p10709 - 기상캐스터 (S5)
// #시뮬레이션
// 2025.6.29 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        int n = input[0], m = input[1];
        List<string> list = new();
        for (int i = 0; i < n; i++)
        {
            list.Add(Console.ReadLine());
        }
        List<List<int>> ret = new ();
        for (int i = 0; i < n; i++)
        {
            ret.Add(new());
        }
        
        for (int i = 0; i < n; i++)
        {
            // 구름은 오른쪽으로 이동하므로 구름이 나오기 전 왼쪽은 전부 -1이다.
            int cur = -1;
            for (int j = 0; j < m; j++)
            {
                // 구름을 본 이후에는 오른쪽으로 1칸씩 떨어질 때마다 
                // 처음 구름을 만나게 되는 시간이 1씩 늘어난다.
                if (cur != -1)
                {
                    cur++;
                }
                // 구름을 만나면 바로 볼 수 있으므로 시간이 0이 된다.
                if (list[i][j] == 'c')
                {
                    cur = 0;
                }
                ret[i].Add(cur);
            }
        }

        foreach (var line in ret)
        {
            Console.WriteLine(string.Join(" ", line));
        }
    }
}
