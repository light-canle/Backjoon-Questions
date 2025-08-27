using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

// p1913 - 달팽이 (S3)
// #구현
// 2025.8.27 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        // 이동 방향 : 위, 오른쪽, 아래, 왼쪽
        (int, int)[] direction = {(0, -1), (1, 0), (0, 1), (-1, 0)};
        List<List<int>> arr = new();
        for (int i = 0; i < n; i++)
        {
            arr.Add(new());
            for (int j = 0; j < n; j++)
            {
                arr[i].Add(0);
            }
        }
        arr[n / 2][n / 2] = 1; // 중앙에 1을 넣음
        int y = n / 2, x = n / 2; // 시작 위치 (1의 인덱스)
        int next = 2; // 다음에 넣을 숫자
        int curDir = 0; // 현재 이동 방향, 처음은 위(0)으로 시작해서 90도 시계방향 회전
        int ky = y + 1, kx = x + 1; // 찾고자 하는 k의 위치 (1의 위치로 초기화)
        // delta는 현재 이동방향으로 이동하면서 채우는 수의 개수이다.
        for (int delta = 1; delta <= n - 1; delta++)
        {
            // 마지막에는 3번, 그외에는 현재 delta로는 2번 이동
            int repeat = delta == n - 1 ? 3 : 2;
            for (int j = 0; j < repeat; j++)
            {
                // 현재 이동방향으로 이동하면서 수를 채운다.
                for (int p = 0; p < delta; p++)
                {
                    x += direction[curDir].Item1;
                    y += direction[curDir].Item2;
                    arr[y][x] = next;
                    // 원하는 k를 찾음
                    if (next == k)
                    {
                        kx = x + 1; ky = y + 1;
                    }
                    // 다음 수 갱신
                    next++;
                }
                // 90도 회전
                curDir = (curDir + 1) % 4;
            }
        }

        StringBuilder ret = new();
        foreach (var line in arr)
        {
            ret.AppendLine(string.Join(" ", line));
        }
        ret.AppendLine($"{ky} {kx}");
        sw.Write(ret);
        sw.Flush();
        sw.Close();
    }
}
