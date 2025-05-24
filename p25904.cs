#pragma warning disable CS8604, CS8602, CS8600
using System;

// p25904 - 안녕 클레오파트라 세상에서 제일가는 포테이토칩 (B3)
// #시뮬레이션
// 2025.5.24 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] info = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = info[0], x = info[1];
        int[] tone = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int curIndex = 0; // 현재 말을 하는 사람의 인덱스
        while (true)
        {
            // 자신이 낼 수 있는 목소리 한계보다 높음
            if (tone[curIndex] < x)
            {
                Console.WriteLine(curIndex + 1); break;
            }
            // 톤을 높이고 다음 사람으로 이동
            x++;
            curIndex = (curIndex + 1) % n;
        }
    }
}
