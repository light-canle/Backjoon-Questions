using System;
using System.Linq;

/// <summary>
/// p9063 - 대지, B3
/// 해결 날짜 : 2024/3/27
/// </summary>

/*
모든 점들의 좌표들 중 가장 작거나 가장 큰 x, y좌표가 직사각형 땅의 경계가 된다.
점들의 좌표들 중에서 x, y 좌표의 최소, 최대값을 각각 찾아서 경계의 넓이를 구할 수 있다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine()!);
        int[] pos = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        int xMin = pos[0], xMax = pos[0], yMin = pos[1], yMax = pos[1];

        for (int i = 0; i < num - 1; i++)
        {
            int[] _pos = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            if (xMin > _pos[0]) xMin = _pos[0];
            if (xMax < _pos[0]) xMax = _pos[0];
            if (yMin > _pos[1]) yMin = _pos[1];
            if (yMax < _pos[1]) yMax = _pos[1];
        }

        Console.WriteLine((xMax - xMin) * (yMax - yMin));
    }
}