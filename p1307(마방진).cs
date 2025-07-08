using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p1307 - 마방진 (P4)
// #애드 혹 #구현
// 2025.7.8 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new (new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(Console.ReadLine());

        var magicSquare = MakeMagicSquare(n);

        foreach (var line in magicSquare)
        {
            sw.WriteLine(string.Join(" ", line));
        }
        sw.Flush();
        sw.Close();
    }

    public static List<List<int>> MakeMagicSquare(int n)
    {
        if (n == 2 || n < 0) return null;
        if (n == 1)
        {
            List<List<int>> ms = new();
            ms.Add(new());
            ms[0].Add(1);
            return ms;
        }
        else if (n % 2 == 1)
        {
            return OddMagicSquare(n);
        }
        else if (n % 4 == 0)
        {
            return Div4EvenMagicSquare(n);
        }
        else
        {
            return NotDiv4EvenMagicSquare(n);
        }
    }

    // https://ko.wikipedia.org/wiki/%EB%A7%88%EB%B0%A9%EC%A7%84
    // 홀수차 마방진 제작
    public static List<List<int>> OddMagicSquare(int n)
    {
        if (n % 2 == 0 || n < 3) return null;

        // nxn 크기 보드
        List<List<int>> magicSquare = new();
        for (int i = 0; i < n; i++)
        {
            magicSquare.Add(Enumerable.Repeat(0, n).ToList());
        }
        // 맨 상단 중앙에 1을 위치시키고 시작
        int y = 0, x = n / 2;
        int curNum = 1;
        while (curNum <= n * n)
        {
            magicSquare[y][x] = curNum;
            curNum++;
            // 다음 위치 선정
            // 1. 우선 오른쪽 위 칸에 다음 수를 배치하는 것을 원칙으로 한다.
            y -= 1; x += 1;
            // 2. 기존 위치가 보드의 맨 오른쪽 위칸이었던 경우 원래 위치의 바로 아래 칸으로 이동한다.
            if (y == -1 && x == n)
            {
                y += 2; x -= 1;
            }
            // 3. 보드의 위쪽으로 벗어난 경우 이동한 열의 맨 아래로 이동한다.
            else if (y == -1)
            {
                y = n - 1;
            }
            // 4. 보드의 오른쪽으로 벗어난 경우 이동한 행의 맨 왼쪽으로 이동한다.
            else if (x == n)
            {
                x = 0;
            }
            // 5. 해당 위치에 이미 수가 있는 경우 원래 위치의 바로 아래 칸으로 이동한다.
            // 2와 같은 경우이나 인덱스를 벗어나는 오류를 방지하기 위해 분리함
            else if (magicSquare[y][x] != 0)
            {
                y += 2; x -= 1;
            }
        }
        return magicSquare;
    }

    // https://ko.wikipedia.org/wiki/%EB%A7%88%EB%B0%A9%EC%A7%84
    // 4의 배수인 짝수 마방진 (4, 8, 12, ...)
    public static List<List<int>> Div4EvenMagicSquare(int n)
    {
        if (n % 2 == 1 || n < 4 || n % 4 != 0) return null;
        // nxn 크기 보드
        List<List<int>> magicSquare = new();
        for (int i = 0; i < n; i++)
        {
            magicSquare.Add(Enumerable.Repeat(0, n).ToList());
        }
        // 1 ~ n^2을 순서대로 쓴 것과 거꾸로 쓴 것을 만든다.
        List<List<int>> normal = new();
        List<List<int>> reverse = new();
        int cur = 1, rev = n * n;
        for (int i = 0; i < n; i++)
        {
            normal.Add(new());
            reverse.Add(new());
            for (int j = 0; j < n; j++)
            {
                normal[i].Add(cur);
                reverse[i].Add(rev);
                cur++; rev--;
            }
        }

        // 4x4 부분 보드를
        /*
        OXXO
        XOOX
        XOOX
        OXXO
        로 쪼갠 뒤, O부분에는 순서대로 쓴 것을 넣고, X부분에는 거꾸로 쓴 것을 넣는다.
        */
        int partNum = n / 4;
        for (int i = 0; i < partNum; i++)
        {
            for (int j = 0; j < partNum; j++)
            {
                int sy = 4 * i, sx = 4 * j;

                for (int y = 0; y < 4; y++)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        if (y == 0 || y == 3)
                        {
                            magicSquare[sy + y][sx + x] =
                            (x == 0 || x == 3) ? normal[sy + y][sx + x] : reverse[sy + y][sx + x];
                        }
                        else
                        {
                            magicSquare[sy + y][sx + x] =
                            (x == 1 || x == 2) ? normal[sy + y][sx + x] : reverse[sy + y][sx + x];
                        }
                    }
                }
            }
        }
        return magicSquare;
    }

    // https://m.blog.naver.com/askmrkwon/220768685076
    // 4의 배수가 아닌 짝수 마방진 (6, 10, 14, ...)
    public static List<List<int>> NotDiv4EvenMagicSquare(int n)
    {
        if (n % 2 == 1 || n < 4 || n % 4 != 2) return null;

        // 주어진 n = 4k + 2라고 둘 때, 2k + 1차 마방진을 가져온다.
        int half = n / 2;
        var halfSize = OddMagicSquare(half);

        // nxn 크기 보드
        List<List<int>> magicSquare = new();
        for (int i = 0; i < n; i++)
        {
            magicSquare.Add(Enumerable.Repeat(0, n).ToList());
        }

        // 마방진을 절반 크기로 4등분 한 후
        // 왼쪽 윗 부분에는 위에서 가져온 마방진을 넣고, 오른쪽 아래에는 n/2의 제곱을 각각의 수에 더한 것을,
        // 오른쪽 위에는 2 * (n/2)^2을 더한 것을, 왼쪽 아래에는 3 * (n/2)^2을 더한 것을 넣는다.
        int add = 0;
        for (int p = 0; p < 4; p++)
        {
            int sy = 0, sx = 0;
            switch (p)
            {
            case 0: break;
            case 1: sy = half; sx = half; break;
            case 2: sx = half; break;
            case 3: sy = half; break;
            }
            for (int y = 0; y < half; y++)
            {
                for (int x = 0; x < half; x++)
                {
                    magicSquare[sy + y][sx + x] = add + halfSize[y][x];
                }
            }
            add += half * half;
        }

        // 왼쪽 윗 부분과 왼쪽 아랫 부분의 처음 k개의 세로줄을 교환한다.
        int k = ((n / 2) - 1) / 2;
        int temp;
        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < half; j++)
            {
                temp = magicSquare[j][i];
                magicSquare[j][i] = magicSquare[j + half][i];
                magicSquare[j + half][i] = temp;
            }
        }
        // 오른쪽 윗 부분과 오른쪽 아랫 부분의 가장 오른쪽 k - 1개의 세로줄을 교환한다.
        for (int i = 0; i < k - 1; i++)
        {
            for (int j = 0; j < half; j++)
            {
                temp = magicSquare[j][n - 1 - i];
                magicSquare[j][n - 1 - i] = magicSquare[j + half][n - 1 - i];
                magicSquare[j + half][n - 1 - i] = temp;
            }
        }
        
        // 왼쪽 부분에 있는 홀수 마방진의 가운데 수와 그 옆 수를 교환한다.
        for (int i = -1; i <= 0; i++)
        {
            temp = magicSquare[half / 2][half / 2 + i];
            magicSquare[half / 2][half / 2 + i] = magicSquare[half + half / 2][half / 2 + i];
            magicSquare[half + half / 2][half / 2 + i] = temp;
        }
        
        return magicSquare;
    }
}
