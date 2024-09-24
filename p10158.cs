using System;
using System.Linq;

/// <summary>
/// p10158 - 개미, S3
/// 시작 날짜 : 2024/4/4
/// 해결 날짜 : 2024/4/5(solved.ac : 4/4)
/// </summary>

/*
개미의 움직임을 x, y좌표 분리해서 따로 생각해보자.
x좌표의 경우 처음에는 dx = 1로 시작하고 x좌표가 0, w에 도달하면 dx의 부호가 바뀐다.
이런식으로 x좌표의 변화를 잘 관찰하면 2w의 주기가 발생함을 알 수 있다.
같은 원리로 y좌표도 처음에는 dy = 1로 시작하고 y좌표가 0, h에 도달하면 dy의 부호가 바뀌어서
2h의 주기를 가짐을 알 수 있다.
그래서 time이 큰 경우에는 time을 2w, 2h로 나눈 나머지를 계산한 뒤,
그 횟수만큼 x, y 좌표의 변화량을 계산해서 최종적인 위치를 계산할 수 있다.
시간 복잡도 : O(w+h)
*/

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        int[] startPos = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        int time = int.Parse(Console.ReadLine()!);

        int dx = 1; int dy = 1;
        int x = startPos[0]; int y = startPos[1];
        int w = size[0]; int h = size[1];

        int moveX = time % (w * 2);
        int moveY = time % (h * 2);
        for (int i = 0; i < moveX; i++)
        {
            if (x == w || x == 0) dx *= -1; 
            x += dx; 
        }

        for (int i = 0; i < moveY; i++)
        {
            if (y == 0 || y == h) dy *= -1;
            y += dy;
        }

        Console.WriteLine($"{x} {y}");
    }
}