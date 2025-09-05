using System;
using System.Linq;
using System.Collections.Generic;

// p3018 - 캠프파이어 (S3)
// #구현 #정렬 #배열(2차원)
// 2025.9.5 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());

        List<List<int>> known = new();
        for (int i = 0; i < n + 1; i++)
        {
            known.Add(new());
        }

        int totalSong = 0;
        for (int i = 0; i < e; i++)
        {
            List<int> participants = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            participants.RemoveAt(0); // 처음의 개수는 뺀다.
            participants.Sort();
            // 참가자 중 선영(1)이가 존재
            // 새로운 번호의 노래를 참가자 모두에게 알려준다.
            if (participants[0] == 1)
            {
                totalSong++;
                foreach (int p in participants)
                {
                    known[p].Add(totalSong);
                }
            }
            // 그 외 경우에는 서로가 알고 있는 노래를 공유한다.
            else
            {
                // 지금까지 나온 노래의 목록
                bool[] song = new bool[totalSong + 1];
                // 모든 참가자들이 아는 곡을 종합
                foreach (int p in participants)
                {
                    foreach (int s in known[p])
                    {
                        song[s] = true;
                    }
                }
                // 각 참가자에 대해 공유된 노래 중 자신이 몰랐던 것을 추가한다.
                foreach (int p in participants)
                {
                    for (int j = 1; j <= totalSong; j++)
                    {
                        if (song[j] && !known[p].Contains(j))
                        {
                            known[p].Add(j);
                        }
                    }
                }
            }
        }

        // 모든 곡을 아는 사람들의 번호를 반환
        List<int> ans = new();
        for (int i = 1; i <= n; i++)
        {
            if (known[i].Count == totalSong) ans.Add(i);
        }

        foreach (int a in ans)
        {
            Console.WriteLine(a);
        }
    }
}
