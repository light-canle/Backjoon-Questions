using System;
using System.Text;

/// <summary>
/// p2447 - 별 찍기 - 10, G5
/// 해결 날짜 : 2024/4/3
/// </summary>

/*
재귀적으로 별을 찍는 문제
base
N = 3일 경우
***
* *
*** 의 형태로 그려진다.
recursive
N = 3^k(k는 자연수)인 경우
크기 N의 패턴은 공백으로 채워진 가운데의 N/3xN/3 정사각형을 N/3크기 패턴으로 둘러싼 형태이다.

재귀함수를 써서 이 패턴을 그려냈다. 우선 입력을 받으면 NxN크기의 2차원 bool 배열을 만든다.
true면 *, false면 띄어쓰기이다. 그 후 배열과 시작 위치, 크기를 재귀 함수에 전달해 크기가 3인 경우
기저 사례로 가운데를 제외한 모든 부분은 true로 지정한다. 크기가 3보다 큰 경우, 정사각형을 9등분 한 뒤,
가운데는 모두 공백으로, 나머지 칸들에는 N/3크기로 재귀함수를 적용한다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder output = new StringBuilder();
        int N = int.Parse(Console.ReadLine()!);

        bool[,] starArray = new bool[N, N];

        StarPattern(starArray, 0, 0, N);

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                output.Append(starArray[i,j] ? "*" : " ");
            }
            output.AppendLine();
        }

        Console.WriteLine(output);
    }

    public static void StarPattern(bool[,] array, int x, int y, int size)
    {
        int oneThird = size / 3;

        // base
        if (oneThird == 1) 
        {
            array[y, x] = true; array[y, x + 1] = true; array[y, x + 2] = true;
            array[y + 1, x] = true; array[y + 1, x + 1] = false; array[y + 1, x + 2] = true;
            array[y + 2, x] = true; array[y + 2, x + 1] = true; array[y + 2, x + 2] = true;
            return;
        }

        // recursive
        StarPattern(array, x, y, oneThird);
        StarPattern(array, x + oneThird, y, oneThird);
        StarPattern(array, x + 2 * oneThird, y, oneThird);

        StarPattern(array, x, y + oneThird, oneThird);
        Blank(array, x + oneThird, y + oneThird, oneThird); // 가운데는 N/3크기의 빈칸이다.
        StarPattern(array, x + oneThird * 2, y + oneThird, oneThird);

        StarPattern(array, x, y + oneThird * 2, oneThird);
        StarPattern(array, x + oneThird, y + oneThird * 2, oneThird);
        StarPattern(array, x + 2 * oneThird, y + oneThird * 2, oneThird);
    }
    public static void Blank(bool[,] array, int x, int y, int size)
    {
        for (int i = y; i < y + size; i++)
            for (int j = x; j < x + size; j++)
                array[i, j] = false;
    }
}
