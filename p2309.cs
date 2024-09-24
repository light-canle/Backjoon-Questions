using System;
using System.Collections.Generic;

/// <summary>
/// p2309 - 일곱 난쟁이, B1
/// 해결 날짜 : 2023/8/28
/// </summary>

/*
간단한 완전 탐색 알고리즘으로 푸는 문제
입력이 9개로 제한되어 있어 완전 탐색으로 풀기에
매우 적합하다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int[] list = new int[9];
        int allHeight = 0;

        for (int i = 0; i < 9; i++)
        {
            list[i] = int.Parse(Console.ReadLine());
            allHeight += list[i];
        }

        List<int> real = new List<int>();

        // 아홉 난쟁이 중 진짜가 아닌 둘을 가려내기 위한 반복문
        for (int i = 0; i < 8; i++)
        {
            for (int j = i + 1; j < 9; j++)
            {
                // 아닌 둘을 찾음
                if (allHeight - list[i] - list[j] == 100)
                {
                    // 아닌 둘을 제외한 나머지 난쟁이의 키를 넣음
                    for (int k = 0; k < 9; k++)
                    {
                        if (k != i && k != j) real.Add(list[k]);
                    }
                    goto out_loop;
                }    
            }
        }
        out_loop:
        //정렬 후 출력
        real.Sort();
        foreach(int i in real)
        {
            Console.WriteLine(i);
        }
    }
}
