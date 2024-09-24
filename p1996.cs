using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// p1996 - 지뢰찾기, S5
/// 해결 날짜 : 2023/11/11
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int N = int.Parse(sr.ReadLine()!);
        StringBuilder output = new StringBuilder();

        List<string> list = new List<string>();
        for (int i = 0; i < N; i++)
        {
            list.Add(sr.ReadLine()!);
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                // 해당 칸이 지뢰인 경우
                if (char.IsDigit(list[i][j]))
                {
                    output.Append('*');
                    continue;
                }
                // 주변 8 칸의 지뢰의 개수를 센다.
                int mineCount = 0;
                for (int k = i - 1; k <= i + 1; k++)
                {
                    for (int l = j - 1; l <= j + 1; l++)
                    {
                        // 자신의 좌표는 검사하지 않음
                        if (k == i && l == j) { continue; }
                        // 영역에 벗어나는 지 체크, 그 후 주변 칸에 지뢰가 있으면 그 개수만큼 증가시킴
                        if (IsBoundary(k, l, N) && char.IsDigit(list[k][l]))
                            mineCount += int.Parse(list[k][l].ToString());
                    }
                }
                // 10 이상인 경우 M 출력
                if (mineCount > 9)
                {
                    output.Append("M");
                }
                else
                {
                    output.Append(mineCount.ToString());
                }
            }
            output.Append('\n');
        }

        Console.WriteLine(output);
        sr.Close();
    }

    // 영역을 벗어났는지 확인하는 함수
    public static bool IsBoundary(int y, int x, int size)
    {
        return (y >= 0 && y < size) && (x >= 0 && x < size);
    }
}