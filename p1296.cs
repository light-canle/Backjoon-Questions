using System;
using System.Collections.Generic;

// p1296 - 팀 이름 정하기 (B1)
// #문자열 #사칙연산
// 2025.6.20 solved

public class Program
{
    public static void Main(string[] args)
    {
        int L = 0, O = 0, V = 0, E = 0;
        string name = Console.ReadLine();
        foreach(char c in name)
        {
            switch (c)
            {
            case 'L': L++; break;
            case 'O': O++; break;
            case 'V': V++; break;
            case 'E': E++; break;
            }
        }
        int n = int.Parse(Console.ReadLine());

        // 점수가 같으면 사전 순으로 앞서는 것을 골라야 하므로
        // 리스트에 이름들을 받고 정렬해 사전 순으로 점수를 검사한다.
        List<string> names = new();
        for (int i = 0; i < n; i++)
        {
            names.Add(Console.ReadLine());
        }
        names.Sort();
        
        int maxScore = -1;
        string teamName = "";
        foreach (var team in names)
        {
            int score = Score(team, L, O, V, E);
            if (score > maxScore)
            {
                maxScore = score;
                teamName = team;
            }
        }
        Console.WriteLine(teamName);
    }

    public static int Score(string name, int l, int o, int v, int e)
    {
        int L = l, O = o, V = v, E = e;
        foreach(char c in name)
        {
            switch (c)
            {
            case 'L': L++; break;
            case 'O': O++; break;
            case 'V': V++; break;
            case 'E': E++; break;
            }
        }
        return ((L + O) * (L + V) * (L + E) * (O + V) * (O + E) * (V + E)) % 100;
    }
}
