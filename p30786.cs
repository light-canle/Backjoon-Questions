using System;
using System.IO;
using System.Collections.Generic;

// p30786 - 홀수 찾아 삼만리 (S3)
// #애드 혹 #홀짝성
// 2025.6.18 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(sr.ReadLine().Trim());
        // 1,1과의 거리가 홀수면, 홀수점, 짝수면 짝수점
        List<bool> point = new(); // false면 홀수점, true는 짝수점
        int odd = 0, even = 0;
        for (int i = 0; i < n; i++)
        {
            int[] input = Array.ConvertAll(sr.ReadLine().Trim().Split(), int.Parse);
            int x = input[0], y = input[1];
            // 각 점이 홀수점인지 짝수점인지를 판단한다.
            bool isEven = IsEven(x, y);
            if (isEven) even++;
            else odd++;
            point.Add(isEven);
        }

        /*
        note
        홀수점 -> 짝수점 경로는 홀수 길이
        홀수점 -> 홀수점, 짝수점 -> 짝수점 경로는 짝수 길이
        */
        // 짝수점이나 홀수점 중 한 쪽이 없으면 합이 짝수가 나올 수 밖에 없다.
        if (even == 0 || odd == 0)
        {
            sw.WriteLine("NO");
        }
        /*
        양쪽이 적어도 하나씩 있는 경우,
        모든 짝수점들을 우선 탐색 후 홀수점들을 탐색하면,
        짝수점에서 홀수점으로 넘어가는 부분만 홀수이고, 나머지 부분은 짝수이므로,
        전체 경로의 길이 합은 홀수가 된다.
        */
        else
        {
            List<int> ret = new();
            for (int i = 0; i < n; i++)
            {
                if (point[i]) ret.Add(i + 1);
            }
            for (int i = 0; i < n; i++)
            {
                if (!point[i]) ret.Add(i + 1);
            }
            sw.WriteLine("YES");
            sw.WriteLine(string.Join(" ", ret));
        }
        sw.Flush();
        sr.Close();
        sw.Close();
    }

    public static bool IsEven(int x, int y)
    {
        return (Math.Abs(x - 1) + Math.Abs(y - 1)) % 2 == 0;
    }
}
