#pragma warning disable CS8604, CS8602, CS8600
using System;
using System.Collections.Generic;

// p25184 - 동가수열 구하기 (S4)
// #해 구성
// 2025.5.30 solved (solved.ac 5.29)

public class Program
{
    public static void Main(string[] args)
    {
        // 이 문제에서는 1 ~ n이 1개씩 있는 수열에서 인접한 값들의 차이가 floor(n/2) 이상이 되도록 수를 배치해야 한다.
        // 그래서 아래와 같은 방법으로 차이가 floor(n/2)가 되게 하는 방법을 수행했다.
        /*
        1. s = d = floor(n/2)로 정의
        2. 첫 항은 s, 그 다음 항은 s + d로 한다.
        3. s에 1을 뺀 뒤, 똑같이 s와 s + d를 다음으로 넣는다.
        4. s가 1이 될 때까지 반복한다.
        5. n이 홀수인 경우 마지막에 n을 추가해 준다.
        이렇게 하면 각 항끼리의 차이가 d 또는 d+1이 되어 조건에 맞게 된다.
        */
        int n = int.Parse(Console.ReadLine());
        int s = n / 2, d = n / 2;
        List<int> ret = new List<int>();
        if (n <= 3)
        {
            for (int i = 1; i <= n; i++) { ret.Add(i); }
        }
        else
        {
            for (int i = 0; i < d; i++)
            {
                ret.Add(s);
                ret.Add(s + d);
                s--;
            }
            if (n % 2 == 1) { ret.Add(n); }
        }
        Console.WriteLine(string.Join(" ", ret));
    }
}
