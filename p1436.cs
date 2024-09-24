using System;
using System.Collections.Generic;

/// <summary>
/// p1436 - 영화감독 숌, S5
/// 해결 날짜 : 2023/8/28
/// </summary>

/*
문제에서 요구하는 수가 생각보다 크지 않아서, 완전 탐색으로 수가 666을 포함하고 있는지를
검사한 뒤, 그들 중 N번째 수를 찾아 출력하는 방식으로 했다.
*/
public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<int> numberList = new List<int>();

        int candidate = 666;

        while (numberList.Count < N)
        {
            if (Test(candidate)) numberList.Add(candidate);
            candidate++;
        }

        Console.WriteLine(numberList.Last());
    }

    public static bool Test(int n)
    {
        string str = n.ToString();

        if (str.Contains("666")) return true;
        else return false;
    }
}
