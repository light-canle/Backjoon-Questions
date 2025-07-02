using System;
using System.Linq;
using System.Collections.Generic;

// p3258 - 컴포트 (S3)
// #그리디 #정렬
// 2025.7.2 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        int n = input[0], z = input[1], m = input[2];

        List<int> obstacle = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();

        // z에 도달하는 k를 찾음
        int k = 1;
        while (true)
        {
            // 시작 위치 초기화
            int curPos = 1;
            do
            {
                curPos += k; // k칸 이동
                // 보드가 원형이므로 n 초과시 나머지 연산을 이용한다.
                if (curPos > n)
                {
                    curPos %= n;
                    curPos = curPos == 0 ? n : curPos;
                }
            // 시작 위치로 돌아오거나 도착점에 도착하거나 장애물에 걸리면 종료
            } while (curPos != 1 && curPos != z && !obstacle.Contains(curPos));
            // 도착점에 도달함
            if (curPos == z)
            {
                break;
            }
            k++; // k증가
        }
        Console.WriteLine(k);
    }
}
