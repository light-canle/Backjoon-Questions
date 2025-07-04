using System;
using System.IO;

// p32979 - 아파트 (S5)
// #시뮬레이션 #큐
// 2025.7.4 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        int t = int.Parse(sr.ReadLine());
        int[] hands = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int[] lose = new int[t];
        int curPos = 0;
        for (int i = 0; i < t; i++)
        {
            // n - 1번 만큼 손을 위로 올림
            curPos += nums[i] - 1;
            // 전체 크기로 나눈 나머지를 구해 위치를 구함
            curPos %= 2 * n;
            // 해당 게임에서 진 사람의 번호를 등록
            lose[i] = hands[curPos];
        }
        Console.WriteLine(string.Join(" ", lose));
        sr.Close();
    }
}
