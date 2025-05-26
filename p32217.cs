#pragma warning disable CS8604, CS8602, CS8600

// p32217 - 광선 다각형 만들기
// #기하
// 2025.5.26 solved

using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
        // 주어진 조건을 보면 n개의 거울을 놓게 되면 레이저 광선의 경로가 n+1각형을 만들게 된다.
        // 그리고 각각의 입사각의 2배가 각 다각형의 한 각의 크기가 된다.
        // 구하는 각의 크기는 n+1각형의 전체 내각의 합에 주어진 입사각들의 합의 2배를 빼면 된다.
        int angleSum = 180 * (n - 1);
        Console.WriteLine(angleSum - 2 * list.Sum());
    }
}
