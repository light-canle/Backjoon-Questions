using System;
using System.Linq;
using System.IO;

/// <summary>
/// p2166 - 다각형의 면적, G5
/// 해결 날짜 : 2023/9/2
/// </summary>

/*
내가 해결한 최초의 골드 문제
주어진 다각형의 면적은 다각형을 이루는 변에서 y에 대한 x의 선적분 값들의 합과 같다.
한 변에서 integral(fun:x, dy)의 값은 0.5 * (x1 + x2) * (y2 - y1)과 같으므로
각 점들을 받으면서 이들의 값을 totalArea에 누적시킨 뒤, totalArea에 절댓값을 씌워서 계산했다.
(선적분은 방향에 따라 양수가 나올수도, 음수가 나올수도 있기 때문이다.)
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        
        int numPoint = int.Parse(sr.ReadLine());

        decimal totalArea = 0;

        int[] first_pos = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int, int) prevPos = (first_pos[0], first_pos[1]);
        for (int i = 0; i < numPoint - 1; i++)
        {
            int[] pos = sr.ReadLine().Split().Select(int.Parse).ToArray();
            (int, int) curPos = (pos[0], pos[1]);
            totalArea += (decimal)0.5 * (prevPos.Item1 + curPos.Item1) * (prevPos.Item2 - curPos.Item2);
            prevPos = curPos;
        }

        totalArea += (decimal)0.5 * (first_pos[0] + prevPos.Item1) * (prevPos.Item2 - first_pos[1]);
        Console.WriteLine($"{Math.Abs(totalArea):F1}");
        sr.Close();
    }
}
