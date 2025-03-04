using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p1497 - 기타콘서트 (S1)
// #비트마스킹 #조합론 #백트래킹
// 2025.3.4 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int n = input[0];
        int m = input[1];

        long[] canPlay = new long[n];
        // i번째 기타가 연주할 수 있는 곡의 번호를 이진법으로 모아서 한 long 정수에 저장 
        for (int i = 0; i < n; i++)
        {
            string[] guitar = Console.ReadLine().Split();

            string playlist = new string(guitar[1].Reverse().ToArray());

            long sum = 0;
            long part = 1;
            for (int j = 0; j < m; j++)
            {
                if (playlist[j] == 'Y') sum += part;
                part *= 2;
            }
            canPlay[i] = sum;
        }

        int maxCount = 0;
        int maxGuitar = 0;
        // 2^n가지 조합 모두 조사
        // 기타를 최소한 쓰면서 최대의 곡을 연주하는 경우를 찾음
        for (int i = (1 << n); i >= 0; i--)
        {
            long playAll = 0;
            int curGuitar = 0;
            int pow2j = 1;
            // 해당 i의 비트에 2^k가 들어가는가?
            for (int k = 0; k < n; k++)
            {
                // 들어가면 k번째 기타가 연주할 수 있는 곡의 이진수 표현을 or로 합침
                if ((i & pow2j) != 0)
                {
                    playAll |= canPlay[k];
                    curGuitar++;
                }
                pow2j *= 2;
            }

            // 비트에서 1의 개수를 세서 연주 가능한 곡의 수를 조사
            string bit = Convert.ToString(playAll, 2);
            int count = bit.Count(x => x == '1');
            // 연주할 수 있는 곡의 수가 최대
            if (count > maxCount)
            {
                maxCount = count;
                maxGuitar = curGuitar;
            }
            // 곡의 수는 동일하나 기타를 적게 쓰는 경우
            else if (count == maxCount)
            {
                if (curGuitar < maxGuitar)
                {
                    maxGuitar = curGuitar;
                }
            }
        }
        if (maxCount == 0)
        {
            Console.WriteLine("-1");
        }
        else
        {
            Console.WriteLine(maxGuitar);
        }
        
    }
}
