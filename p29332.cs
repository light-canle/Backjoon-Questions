#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;

// p29332 - 보물 지도 (B2)
// #구현
// 2025.10.23 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        long? xmin, xmax, ymin, ymax;
        xmin = xmax = ymin = ymax = null;
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            long x = long.Parse(line[0]);
            long y = long.Parse(line[1]);
            switch (line[2])
            {
                // 특정 점보다 왼쪽에 있음 -> 주어진 점의 x좌표-1로 범위 제한
                // 이미 있는 경우에는 둘 중 작은 값으로
                case "L":
                    if (xmax == null) xmax = x - 1;
                    else xmax = Math.Min(xmax.Value, x - 1);
                    break;
                // 특정 점보다 오른쪽에 있음 -> 주어진 점의 x좌표+1로 범위 제한
                // 이미 있는 경우에는 둘 중 큰 값으로
                case "R":
                    if (xmin == null) xmin = x + 1;
                    else xmin = Math.Max(xmin.Value, x + 1);
                    break;
                // 특정 점보다 아래쪽에 있음 -> 주어진 점의 y좌표-1로 범위 제한
                // 이미 있는 경우에는 둘 중 작은 값으로
                case "D":
                    if (ymax == null) ymax = y - 1;
                    else ymax = Math.Min(ymax.Value, y - 1);
                    break;
                // 특정 점보다 위쪽에 있음 -> 주어진 점의 y좌표+1로 범위 제한
                // 이미 있는 경우에는 둘 중 작은 값으로
                case "U":
                    if (ymin == null) ymin = y + 1;
                    else ymin = Math.Max(ymin.Value, y + 1);
                    break;
            }
        }
        // 범위가 확정되지 않음
        if (xmin == null || xmax == null || ymin == null || ymax == null)
        {
            Console.WriteLine("Infinity");
        }
        // 가능한 x, y 범위가 없음
        else if (ymax < ymin || xmax < xmin)
        {
            Console.WriteLine(0);
        }
        // 범위 내 점의 개수를 구함
        else
        {
            Console.WriteLine((ymax - ymin + 1) * (xmax - xmin + 1));
        }
        sr.Close();
    }
}
