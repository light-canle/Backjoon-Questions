using System;
using System.Linq;
using System.Collections.Generic;

// p1138 - 한 줄로 서기 (S2)
// #그리디
// 2025.6.13 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> left = Console.ReadLine().Split().Select(int.Parse).ToList();

        /*
        키가 1인 사람부터 N칸 중 어디에 들어갈지를 결정한다.
        최종 대기열 ret는 처음에 0으로 초기화 한다. 0은 아직 사람이 서지 않은 것이다.
        특정 키를 가진 사람의 위치가 확정되면 0이 해당 사람의 키로 바뀐다.
        왼쪽에 있는 사람 수를 skip이라 하자.
        최종 대기열에서의 위치를 idx라 하고, 처음에는 0으류 둔다.
        skip이 양수일 때, ret[idx]가 0이면, skip을 1 줄이고, idx를 1 옮겨 오른쪽으로 한 칸 이동한다.
        ret[idx]가 0이 아니면 skip을 유지하고, idx만 옮긴다. 이미 사람이 있는 자리이고,
        키가 작은 순으로 서고 있기에 이미 서 있는 사람은 자신보다 키가 큰 사람의 수에 해당되지 않기 때문이다.
        idx를 옮기다가 skip이 0이 되면 ret[idx]가 0인 빈칸이 나올 때까지 idx를 옮기고 확정된 자리에
        그 사람의 키를 집어 넣으면 된다.
        */
        List<int> ret = Enumerable.Repeat(0, n).ToList();
        for (int i = 1; i <= n; i++)
        {
            int skip = left[i - 1];
            int idx = 0;
            while (skip > 0)
            {
                if (ret[idx] == 0) skip--;
                idx++;
            }
            while (ret[idx] != 0) idx++;
            ret[idx] = i;
        }
        Console.WriteLine(string.Join(" ", ret));
    }
}
