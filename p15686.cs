using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p15686 - 치킨 배달 (G5)
// #백트래킹 #완전 탐색
// 2025.7.15 solved
// 900th solved problem

// 위치를 나타내는 구조체
public struct Position
{
    public int x, y;
    public Position(int _y, int _x)
    {
        y = _y; x = _x;
    }
}
public class Program
{
    public static int minChickenDist;
    public static List<Position> house;
    public static List<Position> chicken;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        minChickenDist = int.MaxValue;
        int[] size = Array.ConvertAll(sr.ReadLine().Trim().Split(), int.Parse);
        int n = size[0], m = size[1];
        List<List<int>> map = new();
        for (int i = 0; i < n; i++)
        {
            map.Add(sr.ReadLine().Trim().Split().Select(int.Parse).ToList());
        }

        // 집과 치킨집의 위치를 구해서 저장해 놓는다.
        house = new();
        chicken = new();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (map[i][j] == 1)
                {
                    house.Add(new Position(i, j));
                }
                else if (map[i][j] == 2)
                {
                    chicken.Add(new Position(i, j));
                }
            }
        }

        bool[] visited = new bool[chicken.Count];
        Position[] output = new Position[m];

        // 전체 치킨집 중 m개를 고르는 모든 조합을 만들어 낸 뒤 그 조합에서 치킨 거리를 구한다.
        // 치킨 거리는 도시에 있는 모든 집에 대하여 각 집마다 가장 가까운 치킨집까지의 택시 거리의 합이다.
        Combination(visited, output, chicken.Count, m, 0, 0);
        Console.WriteLine(minChickenDist);
        sr.Close();
    }

    // n : 치킨 집의 총 개수, m : 고를 개수, k : 현재 선택한 개수, front : 현재 재귀에서 탐색할 첫 요소의 인덱스
    public static void Combination(bool[] visited, Position[] output, int n, int m, int k, int front)
    {
        // m개를 모두 선정함
        if (k == m)
        {
            FindMinimumDistance(output);
            return;
        }

        for (int i = front; i < n; i++)
        {
            // 방문하지 않은 요소를 방문하고 다음 요소를 고르기 위한 재귀 진행
            if (!visited[i])
            {
                visited[i] = true;
                output[k] = chicken[i];
                Combination(visited, output, n, m, k + 1, i + 1);
                visited[i] = false;
            }
        }
    }

    // 현재 조합에서의 치킨 거리를 구하고 최솟값을 갱신한다.
    public static void FindMinimumDistance(Position[] output)
    {
        int curChickenDist = 0;
        foreach (var pos in house)
        {
            int curHouseMin = int.MaxValue;
            foreach (var cpos in output)
            {
                int dist = Distance(pos.x, pos.y, cpos.x, cpos.y);
                curHouseMin = Math.Min(curHouseMin, dist);
            }
            curChickenDist += curHouseMin;
        }
        minChickenDist = Math.Min(minChickenDist, curChickenDist);
    }

    // (x1, y1)과 (x2, y2) 사이의 택시 거리를 구한다.
    public static int Distance(int x1, int y1, int x2, int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }
}
