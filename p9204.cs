using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

// p9204 - 체스 (G5)
// #격자 그래프
// 2025.9.2 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new();
        int t = int.Parse(sr.ReadLine().Trim());

        for (int i = 0; i < t; i++)
        {
            string[] line = sr.ReadLine().Trim().Split();
            if (line.Length < 4) continue;
            string start = line[0] + line[1], dest = line[2] + line[3];

            int startNum = NameToNumber(start);
            int destNum = NameToNumber(dest);

            // 두 칸의 색이 다르면 비숍이 도달 불가능하다.
            if (IsBlack(startNum) != IsBlack(destNum))
            {
                output.AppendLine("Impossible");
                continue;
            }

            // start == dest이면 안 움직여도 된다.
            if (startNum == destNum)
            {
                output.AppendLine($"0 {line[0]} {line[1]}");
                continue;
            }

            // 두 칸의 색이 같고 두 칸이 다르면, 최대 2번의 움직임으로 도달 가능하다.
            // start, dest 모두 현 위치에서 비숍이 갈 수 있는 위치를 구한다.
            List<int> reachableFromStart = new();
            List<int> reachableFromDest = new();

            // 대각선 4방향
            (int, int)[] dir = { (-1, -1), (1, -1), (1, 1), (-1, 1) };
            int cy, cx;
            // 현재 위치로 초기화한 뒤, 각각의 방향으로 뻗어나가며 범위를 벗어날 때까지 지나간 칸을 추가한다.
            for (int j = 0; j < 4; j++)
            {
                cy = startNum / 8; cx = startNum % 8;
                while (0 <= cy && cy < 8 && 0 <= cx && cx < 8)
                {
                    if (!reachableFromStart.Contains(cy * 8 + cx)) // 시작칸 중복 방지용
                        reachableFromStart.Add(cy * 8 + cx);
                    cy += dir[j].Item1;
                    cx += dir[j].Item2;
                }
            }

            for (int j = 0; j < 4; j++)
            {
                cy = destNum / 8; cx = destNum % 8;
                while (0 <= cy && cy < 8 && 0 <= cx && cx < 8)
                {
                    if (!reachableFromDest.Contains(cy * 8 + cx)) 
                        reachableFromDest.Add(cy * 8 + cx);
                    cy += dir[j].Item1;
                    cx += dir[j].Item2;
                }
            }

            // 만약 위치 리스트에 서로가 존재한다면 1번 안에 start -> end로 갈 수 있음을 뜻한다.
            if (reachableFromStart.Contains(destNum) && reachableFromDest.Contains(startNum))
            {
                output.AppendLine($"1 {line[0]} {line[1]} {line[2]} {line[3]}");
            }
            // 아니라면, 두 배열에 공통적으로 들어간 위치가 적어도 1개는 있는데 
            // 그 위치를 stopover라 하면 start -> stopover -> dest로 가면 된다.
            else
            {
                foreach (int stopover in reachableFromStart)
                {
                    if (reachableFromDest.Contains(stopover))
                    {
                        string so = NumberToName(stopover);
                        output.AppendLine($"2 {line[0]} {line[1]} {so[0]} {so[1]} {line[2]} {line[3]}");
                        break;
                    }
                }
            }
        }
        sw.WriteLine(output);
        sw.Flush();
        sr.Close();
        sw.Close();
    }

    // 체스판 칸의 이름을 번호로 바꾼다.
    // A1을 0, B1을 1, ... H1을 7, A2를 8, ... H2를 15, ... H8을 63으로 둔다.
    public static int NameToNumber(string name)
    {
        char file = name[0];
        char rank = name[1];
        return (file - 'A') + (rank - '1') * 8;
    }

    // 위의 방법으로 변환된 칸의 번호를 원래 이름으로 바꾼다.
    public static string NumberToName(int num)
    {
        return Convert.ToChar((num % 8 + 'A')) + (num / 8 + 1).ToString();
    }

    // A1칸을 기준으로 택시 거리가 짝수이면 검은색, 홀수이면 흰색 사각형이다.
    public static bool IsBlack(int num)
    {
        int fileDist = num % 8; // A파일은 0, H파일은 7
        int rankDist = num / 8; // 1랭크는 0, 8랭크는 7
        return (fileDist + rankDist) % 2 == 0;
    }
}
