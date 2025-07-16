using System;
using System.IO;
using System.Collections.Generic;

// p18230 - 2xN 예쁜 타일링 (S1)
// #그리디 #정렬
// 2025.7.16 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], a = input[1], b = input[2];
        List<int> small = sr.ReadLine().Split().Select(int.Parse).ToList();
        List<int> large = sr.ReadLine().Split().Select(int.Parse).ToList();
        // 데이터 정렬 - 높은 거 부터 채워넣기 위해 정렬 후 뒤집기
        small.Sort(); small.Reverse();
        large.Sort(); large.Reverse();
        // 2×2 공간의 개수
        int evenPart = n / 2;
        // 2×2 단위 공간에 무엇을 채워 넣을지를 결정한다.
        // 작은 타일 2개의 합, 큰 타일 1개 중 예쁨 수치가 큰 것을 더한다.
        // 한 쪽이 모두 소비되면 다른 쪽을 넣는다.
        int sIdx = 0, lIdx = 0;
        int totalPretty = 0;
        for (int i = 0; i < evenPart; i++)
        {
            /*
            13 2 6
            9 8
            1 1 1 1 1 1
            위의 테스트 케이스처럼 n이 홀수, 2x1이 2개 남은 상태이면서 
            2×1타일의 예쁨 수치가 2×2타일보다 커 2×1타일을 우선 배치하면
            반복문이 끝난 뒤 2×1타일이 남은 게 없어 인덱스를 벗어나는 오류가 생긴다.
            2×1타일이 2개 남고 n이 홀수이면, 2x1타일 2개의 점수가 높더라도
            2x2를 배치하도록 해야 한다.
            */
            if (sIdx >= a - 1 || (n % 2 == 1 && a - sIdx == 2))
            {
                totalPretty += large[lIdx];
                lIdx++;
            }
            else if (lIdx >= b)
            {
                totalPretty += small[sIdx] + small[sIdx + 1];
                sIdx += 2;
            }
            else if (small[sIdx] + small[sIdx + 1] > large[lIdx])
            {
                totalPretty += small[sIdx] + small[sIdx + 1];
                sIdx += 2;
            }
            else
            {
                totalPretty += large[lIdx];
                lIdx++;
            }
        }
        // n이 홀수이면 2×1타일 하나를 추가로 넣어준다.
        if (n % 2 == 1)
        {
            totalPretty += small[sIdx];
        }
        Console.WriteLine(totalPretty);
        sr.Close();
    }
}
