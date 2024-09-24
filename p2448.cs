using System;
using System.IO;
using System.Text;

/// <summary>
/// p2448 - 별 찍기 - 11, G4
/// 해결 날짜 : 2024/4/3
/// </summary>


/*
재귀적으로 별을 찍는 문제
base
N = 3일 경우
  *  
 * * 
*****의 형태로 그려진다. (위에 띄어쓰기가 있다.)

N = 6일 경우
     *
    * *
   *****
  *     *
 * *   * *
***** *****의 형태로 그려진다. 이 큰 삼각형은 위 1칸, 아래 3칸의 구조로 이루어져 있다.
위 1칸과 아래 양쪽 칸은 N / 2패턴으로 이루어져 있고, 아래 가운데 칸은 N / 2패턴과 크기는 같지만 
모두 빈칸이고 뒤집어져 있는 삼각형 형태이다.

별 찍기 10과 비슷한 구조이나, 시간 초과가 많이 일어나서 약간 변형하였다.
배열 접근을 최소화 하기 위해 빈칸을 true, 별 칸을 false로 접근하게 하여 기저 사례의 실행 시간을 줄였다.
재귀 호출의 경우에는 3번의 재귀 + 1번의 Blank()로 이루어져 있고,
Blank() 안에서는 각 줄에서 x위치의 시작 부분이 줄을 내려갈 때마다 2칸 뒤에서 시작되므로 for문의 시작점을
코드에서 쓴 것과 같이 했다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder output = new StringBuilder();
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int N = int.Parse(Console.ReadLine()!);

        // false : *, true : 공백
        bool[,] starArray = new bool[N, 2 * N - 1];

        StarPattern(starArray, 0, 0, N);

        for (int i = 0; i < N; i++)
        {
            output.Append(new string(' ', N - i - 1));
            for (int j = 0; j < 2 * i + 1; j++)
            {
                output.Append(starArray[i,j] ? " " : "*");
            }
            output.AppendLine(new string(' ', N - i - 1));
        }

        sw.WriteLine(output);

        sw.Flush();
        sw.Close();
    }

    public static void StarPattern(bool[,] array, int x, int y, int size)
    {
        // base
        if (size == 3) 
        {
            array[y + 1, x + 1] = true;

            return;
        }
        int half = size / 2;
        // recursive
        StarPattern(array, x, y, half);

        StarPattern(array, x, y + half, half);
        Blank(array, x + 1, y + half, half);
        StarPattern(array, x + size, y + half, half);
    }
    public static void Blank(bool[,] array, int x, int y, int size)
    {
        for (int i = 0; i < size; i++)
            for (int j = 2 * i; j < (size * 2 - 1); j++)
                array[y + i, x + j] = true;
    }
}