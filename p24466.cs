using System;
using System.Numerics;
using System.IO;
using System.Collections.Generic;

// p24466 - 도피 (G4)
// #DP #확률론 #그래프 #큰 수 계산
// 2025.8.31 solved
// 마르코프 체인

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] size = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = size[0], m = size[1];

        // 연결된 도시를 그래프로 저장
        Dictionary<int, List<(int, int)>> adj = new();
        for (int i = 0; i < n; i++)
        {
            adj[i] = new();
        }
        for (int i = 0; i < m; i++)
        {
            int[] road = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int u = road[0], v = road[1], w = road[2];
            adj[u].Add((v, w));
        }
        /* 
        i일 후에 특정 도시에 있을 확률을 계산
        prob[i, j]는 i일 후에 j번 도시에 있을 확률에 10^(2i+2)를 곱한 것이다.
        i일 후에 특정 도시에 있을 확률이 0이 아니면
        i일 후 그 도시에 있을 확률에다가 다음 도시로 연결된 도로로 갈 확률을 곱한 뒤 
        누적하는 방식으로 다음 날의 확률을 구할 수 있다.
        */
        BigInteger[,] prob = new BigInteger[10, n];
        prob[0, 0] = 100;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (prob[i, j] != 0)
                {
                    foreach (var road in adj[j])
                    {
                        prob[i + 1, road.Item1] += prob[i, j] * road.Item2;
                    }
                }
            }
        }

        // 9일 후 있을 확률이 가장 높은 도시를 구한다.
        List<int> city = new();
        BigInteger maxProb = 0;
        for (int i = 0; i < n; i++)
        {
            if (maxProb < prob[9, i])
            {
                city.Clear();
                city.Add(i);
                maxProb = prob[9, i];
            }
            else if (maxProb == prob[9, i])
            {
                city.Add(i);
            }
        }

        // 구한 maxProb를 10^20으로 나눈 뒤 소수점 18째 자리까지 출력한다.
        string ret = maxProb.ToString();
        if (ret.Length > 20)
        {
            int left = ret.Length - 20;
            ret = ret.Substring(0, left) + "." + ret.Substring(left, 18);
        }
        else if (ret.Length == 20)
        {
            ret = "0." + ret.Substring(0, 18);
        }
        else
        {
            int zeros = 20 - ret.Length > 18 ? 18 : 20 - ret.Length;
            int sub = 18 - zeros < 0 ? 0 : 18 - zeros;
            ret = "0." + new string('0', zeros) + ret.Substring(0, sub);
        }
        
        Console.WriteLine(string.Join(" ", city));
        Console.WriteLine(ret);
        sr.Close();
    }
}
