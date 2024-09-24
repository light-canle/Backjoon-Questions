using System;
using System.Linq;

/// <summary>
/// p1074 - Z, S1
/// 해결 날짜 : 2023/9/6
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        (int N, int r, int c) = (input[0], input[1], input[2]);

        int order = 0;
        int answer = 0;
        SearchZ(r, c, 0, 0, (int)Math.Pow(2, N), ref order, ref answer);

        Console.WriteLine(answer);
    }

    public static void SearchZ(int findRow, int findCol, int currentRow, int currentCol,
        int currentSize, ref int order, ref int answer)
    {
        // 기저 사례 - 개별 칸에 도달한 경우 order를 1개만 더한다.
        // 추가적으로, 도달한 칸이 우리가 찾는 칸일 경우 answer에 그 순서를 넣어준다.
        if (currentSize == 1)
        {
            if (findRow == currentRow && findCol == currentCol) 
            {
                answer = order;
            }
            order++;
            return;
        }

        // 찾는 좌표가 거대한 Z 영역에서 어디 위치에 속하는지를 결정한다.
        /*
        ■■■■■■■■ 현재 영역을 2x2로 4등분 하였을 때,
        ■1 ■■2 ■ 왼쪽 위가 1사분면, 오른쪽 위가 2사분면,
        ■  ■■  ■ 왼쪽 아래가 3사분면, 오른쪽 아래가 4사분면이다.
        ■■■■■■■■ 수학의 사분면 순서와 다른데, 이는 우리가 이 배열을 Z 형태로 순회하기 때문에
        ■3 ■■4 ■ 먼저 순회하는 사분면부터 번호를 붙여주었다.
        ■  ■■  ■
        ■■■■■■■■
        */
        int quadrant = (findRow < currentRow + currentSize / 2) ? 1 : 3;
        quadrant += (findCol < currentCol + currentSize / 2) ? 0 : 1;

        // 해당하는 사분면만 순회
        // 앞 사분면에 해당하는 칸의 수는 order에 더한다.
        // 각 사분면에는 (current / 2)^2개의 칸들이 있으므로, 우리가 찾을 위치보다 선행하는
        // 사분면의 개수만큼 order에 누적한다.
        order += (quadrant - 1) * (currentSize / 2 * currentSize / 2);

        // 사분면에 해당하는 곳을 재귀적으로 방문
        if (quadrant == 1)
        {
            SearchZ(findRow, findCol, currentRow, currentCol,
            currentSize / 2, ref order, ref answer);
        }
        else if (quadrant == 2)
        {
            SearchZ(findRow, findCol, currentRow, currentCol + currentSize / 2,
            currentSize / 2, ref order, ref answer);
        }
        else if (quadrant == 3)
        {
            SearchZ(findRow, findCol, currentRow + currentSize / 2, currentCol,
            currentSize / 2, ref order, ref answer);
        }
        else if (quadrant == 4)
        {
            SearchZ(findRow, findCol, currentRow + currentSize / 2, currentCol + currentSize / 2,
            currentSize / 2, ref order, ref answer);
        }       
    }
}

/*
또 다른 방법
시간 초과가 나긴 했지만, 결과를 잘 도출해 낸다.
Z방향으로 순회해서 단일 칸에 도달한 경우 order를 1 더하고,
원하는 좌표를 찾았다면 현재 order를 넣는다.

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        (int N, int r, int c) = (input[0], input[1], input[2]);

        int order = 0;
        int answer = 0;
        SearchZ(r, c, 0, 0, (int)Math.Pow(2, N), ref order, ref answer);

        Console.WriteLine(answer);
    }

    public static void SearchZ(int findRow, int findCol, int currentRow, int currentCol,
        int currentSize, ref int order, ref int answer)
    {
        // 기저 사례
        if (currentSize == 1)
        {
            if (findRow == currentRow && findCol == currentCol) 
            {
                answer = order;
            }
            order++;
            return;
        }
        
        // 4등분으로 쪼개서 다시 같은 과정을 수행
        // Z모양으로 순회
        SearchZ(findRow, findCol, currentRow, currentCol, 
            currentSize / 2, ref order, ref answer);
        SearchZ(findRow, findCol, currentRow, currentCol + currentSize / 2,
            currentSize / 2, ref order, ref answer);
        SearchZ(findRow, findCol, currentRow + currentSize / 2, currentCol,
            currentSize / 2, ref order, ref answer);
        SearchZ(findRow, findCol, currentRow + currentSize / 2, currentCol + currentSize / 2,
            currentSize / 2, ref order, ref answer);
    }
}
*/