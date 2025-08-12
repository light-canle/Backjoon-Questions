using System;
using System.IO;

// p32141 - 카드 게임 (Easy) (B2)
// #그리디
// 2025.8.12 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int[] size = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = size[0]; // 카드의 수
        long h = size[1]; // 상대 체력
        int[] dmg = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        long cur = 0; // 현재 누적 합
        int idx = 0; // 현재 탐색 인덱스
        // 모든 카드를 쓰거나 상대 체력이 모두 소진될 때까지 반복
        // 대미지가 낮은 것부터 쓰면 최대한 많은 카드 사용 가능
        while (idx < n && cur < h)
        {
            cur += dmg[idx];
            idx++;
        }
        // 카드로 h 이상이 되면 그 때 개수, 안되면 -1 출력
        Console.WriteLine(cur >= h ? idx : -1);
        sr.Close();
    }
}
