using System;
using System.IO;
using System.Collections.Generic;

// p3000 - 직각 삼각형 (S1)
// #조합론 #기하학
// 2025.2.6 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int n = int.Parse(sr.ReadLine());

        List<(long, long)> dots = new();
        // 해당 x, y 좌표를 가진 점의 개수. 
        // 예로 xCount[2]는 x좌표가 2인 점의 개수이다.
        long[] xCount = new long[100001];
        long[] yCount = new long[100001];

        // 점 n개를 받는다.
        for (int i = 0; i < n; i++)
        {
            long[] dot = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            dots.Add((dot[0], dot[1]));
            xCount[dot[0]]++;
            yCount[dot[1]]++;
        }

        /*
        문제에서는 빗변이 아닌 두 변이 좌표축에 평행한 직각삼각형의 개수를 물었다.
        주어진 한 점을 기준으로 조건에 맞는 직각삼각형을 만들려면
        기준점과 x좌표가 같은 점 하나와 y좌표가 같은 점 하나를 고르면 된다.
        앞에서 특정 좌표값을 갖는 점의 개수를 저장해두었기 때문에
        우리가 한 점 (a, b)를 이용해 직각삼각형을 만들려고 하면
        그 개수는 (xCount[x] - 1) * (yCount[y] - 1)이 될 것이다. (1을 뺀 이유는 (a, b)는
        제외해야 하기 때문)
        */
        long count = 0;
        foreach (var (x, y) in dots)
        {
            long triangles = (xCount[x] - 1) * (yCount[y] - 1);
            count += triangles > 0 ? triangles : 0;
        }

        Console.WriteLine(count);
        sr.Close();
    }
}
