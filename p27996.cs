using System;
using System.IO;

// p27996 - △ (S3)
// #트리 #애드 혹
// 2025.7.29 solved

/*
N개의 정점들 사이의 거리 합이 최소가 되게 하는 일반 트리는
1번 노드를 부모로 하고, 나머지 모든 노드가 1번 노드의 자식이자
리프 노드가 되는 트리이다.
이 트리에서 1번 노드와 다른 노드 사이의 거리는 1이고,
1번이 아닌 다른 노드끼리의 거리는 2가 된다.
거리 합은 1번 노드와 다른 노드 : (n - 1)
다른 노드끼리 (n-1개 중 2개를 고른 조합의 수) : ((n - 1)(n - 2) / 2) * 2가 된다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(Console.ReadLine().Trim());
        long distSum = (((long)n - 1L) * ((long)n - 2L)) + (n - 1L);
        sw.WriteLine(distSum);
        // 1번 노드와 붙어있는 다른 노드의 형태로 출력
        sw.WriteLine("2 1");
        for (int i = 3; i <= n; i++)
        {
            sw.WriteLine($"1 {i}");
        }
        sw.Flush();
        sw.Close();
    }
}
