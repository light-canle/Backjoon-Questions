#pragma warning disable CS8604, CS8602

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// p17406 - 배열 돌리기 4 (G4)
// #구현 #배열 #완전 탐색 #백트래킹
// 2025.11.26 solved

public class Program
{
    // 백트래킹 - 적용할 회전 연산의 순서를 정함
    public static int[] result;             // 완성된 순서
    public static bool[] visited;           // 해당 값을 방문했는지 여부
    // 받을 배열과 회전의 정보
    public static List<List<int>> list;     // 입력받는 배열
    public static List<List<int>> rotate;   // 입력받는 회전 정보
    public static int minValue;             // 구하고자 하는 최솟값
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1], s = input[2];

        visited = new bool[s];
        result = new int[s];
        minValue = int.MaxValue;

        list = new();
        for (int i = 0; i < n; i++)
        {
            list.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
        }

        rotate = new();
        for (int i = 0; i < s; i++)
        {
            rotate.Add(sr.ReadLine().Split().Select(int.Parse).ToList());
        }
        MakeOrder(s, 0);
        Console.WriteLine(minValue);
        
        sr.Close();
    }

    // 0 ~ n-1로 이루어진 순열을 생성하고, 만들어진 순열에 대해 그 순서로 회전을 적용함
    public static void MakeOrder(int n, int depth)
    {
        // 순열 완성됨
        if (depth == n)
        {
            minValue = Math.Min(FindArrayValue(), minValue);
            return;
        }
        // 백트래킹으로 모든 순열 생성
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                visited[i] = true;
                result[depth] = i;
                MakeOrder(n, depth + 1);
                visited[i] = false;
            }
        }
    }

    // 회전을 모두 적용한 뒤 배열의 값(합이 최소인 행)을 구한다.
    public static int FindArrayValue()
    {
        // 기존 배열에 영향을 주지 않도록 복사함
        List<List<int>> copyed = new();
        for (int i = 0; i < list.Count; i++)
        {
            copyed.Add(new());
            for (int j = 0; j < list[i].Count; j++)
            {
                copyed[i].Add(list[i][j]);
            }
        }

        // 주어진 순서로 회전을 적용
        foreach (int order in result)
        {
            Rotate(copyed, rotate[order][0], rotate[order][1], rotate[order][2]);
        }

        // 행을 이루는 요소들의 합의 최솟값을 구함
        int value = int.MaxValue;
        for (int i = 0; i < list.Count; i++)
        {
            value = Math.Min(value, copyed[i].Sum());
        }
        return value;
    }

    // list를 (sy, sx)를 중심으로 s단계에 걸쳐서 주어진 요소들을 1칸 씩 시계방향으로 움직인다.
    public static void Rotate(List<List<int>> list, int sy, int sx, int s)
    {
        (int, int)[] direction = { (0, 1), (1, 0), (0, -1), (-1, 0) }; 
        for (int lv = 1; lv <= s; lv++)
        {
            List<int> nums = new();
            // 중심에서 왼쪽 대각선으로 lv만큼 움직인 칸을 시작으로 잡는다.
            int y = sy - 1 - lv, x = sx - 1 - lv;
            // 시작 칸을 기준으로 해당 링에 속한 모든 값들을 시계 방향 순으로 저장한다. 
            for (int dir = 0; dir < 4; dir++)
            {
                for (int i = 0; i < 2 * lv; i++)
                {
                    nums.Add(list[y][x]);
                    y += direction[dir].Item1;
                    x += direction[dir].Item2;
                }
            }
            // 시계 방향으로 1칸씩 옮긴 값을 원래 배열에 다시 저장한다.
            int idx = nums.Count - 1;
            for (int dir = 0; dir < 4; dir++)
            {
                for (int i = 0; i < 2 * lv; i++)
                {
                    list[y][x] = nums[idx];
                    idx = (idx + 1) % nums.Count;
                    y += direction[dir].Item1;
                    x += direction[dir].Item2;
                }
            }
        }
    }
}
