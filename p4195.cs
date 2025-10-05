#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

// p4195 - 친구 네트워크 (G2)
// #분리 집합 #해시와 맵
// 2025.10.5 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new();
        sw.AutoFlush = true;
        // 부모 노드
        Dictionary<string, string> parent = new();
        // 자신이 속한 집합의 크기
        Dictionary<string, int> unionSize = new();
        // 트리 집합의 높이
        Dictionary<string, int> rank = new();

        int t = int.Parse(sr.ReadLine());
        for (int i = 0; i < t; i++)
        {
            // 테스트 케이스마다 초기화
            parent.Clear();
            rank.Clear();
            int f = int.Parse(sr.ReadLine());
            for (int j = 0; j < f; j++)
            {
                string[] relation = sr.ReadLine().Trim().Split();
                string first = relation[0], second = relation[1];

                // 해시맵에 해당 이름이 없으면 추가해준다.
                if (!parent.ContainsKey(first))
                {
                    // 자신만 들어있는 집합으로 초기화
                    parent[first] = first;
                    unionSize[first] = 1;
                    rank[first] = 0;
                }
                if (!parent.ContainsKey(second))
                {
                    parent[second] = second;
                    unionSize[second] = 1;
                    rank[second] = 0;
                }

                // 두 집합을 합친다.
                Union(parent, rank, unionSize, first, second);
                // 루트 갱신
                FindRoot(parent, first);
                FindRoot(parent, second);
                // 크기 갱신 -> Union에서 루트끼리는 크기 업데이트를 했으므로, 자신의 집합의 크기는 그 집합의 루트의 unionSize에 들어있다.
                unionSize[first] = unionSize[parent[first]];
                unionSize[second] = unionSize[parent[second]];
                
                output.AppendLine($"{unionSize[first]}");
            }
        }
        sw.WriteLine(output);
        sr.Close();
        sw.Close();
    }

    // x가 속한 집합의 루트를 찾는다. x와 연결된 부모 노드를 따라가면서 거쳐간 노드의 부모를 모두 최종 루트 노드로 바꾼다.
    public static string FindRoot(Dictionary<string, string> parent, string x)
    {
        // 루트의 경우 자신을 반환
        if (x == parent[x]) return x;
        // 재귀하면서 부모 노드의 루트도 최종 루트로 바꿔나감
        return parent[x] = FindRoot(parent, parent[x]);
    }

    // x, y를 같은 집합에 속하도록 병합한다.
    public static void Union(Dictionary<string, string> parent, Dictionary<string, int> rank, Dictionary<string, int> unionSize, string x, string y)
    {
        // 두 집합의 루트 노드를 찾는다.
        x = FindRoot(parent, x);
        y = FindRoot(parent, y);

        // 이미 같은 집합에 속해 있음
        if (x == y) return;

        // Union by rank : 높이가 낮은 트리를 높은 트리에 붙인다.
        // x의 랭크가 더 낮음 -> x가 속한 트리를 y가 속한 트리에 합친다.
        if (rank[x] < rank[y])
        {
            parent[x] = y;
            // 병합 시 두 집합의 노드의 개수 합을 구하고 갱신
            unionSize[x] += unionSize[y];
            unionSize[y] = unionSize[x];
        }
        // x의 랭크가 더 높음 -> y가 속한 트리를 x가 속한 트리에 합친다.
        else
        {
            parent[y] = x;
            // 두 트리의 랭크가 같으면 x의 랭크를 1 올린다.
            // y의 트리에 x가 루트로 붙어서 랭크가 1 올랐다고 생각하면 된다.
            if (rank[x] == rank[y]) rank[x]++;
            unionSize[x] += unionSize[y];
            unionSize[y] = unionSize[x];
        }
    }
}
