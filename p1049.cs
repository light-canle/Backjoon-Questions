using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1049 - 기타줄, S4
/// 해결 날짜 : 2023/9/5
/// </summary>

/*
간단한 그리디 알고리즘 문제
가장 저렴한 묶음과 낱개 가격을 선택한 뒤, 
묶음과 낱개의 개수를 조절해가며 가장 낮은 가격을 찾는다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        // N은 기타줄 수, M은 브랜드 수
        (int N, int M) = (input[0], input[1]);
        
        // 브랜드들의 묶음(6개)와 낱개 가격
        List<int> package = new List<int>();
        List<int> unit = new List<int>();
        for (int i = 0; i < M; i++)
        {
            int[] price = Console.ReadLine().Split().Select(int.Parse).ToArray();
            package.Add(price[0]);
            unit.Add(price[1]);
        }
        // 최소의 가격을 얻기 위해서는 가장 싼 묶음과 낱개의 가격만을 고려하면 된다.
        // 그러므로 최소 가격의 묶음과 낱개의 가격을 구한다.
        int minPackage = package.Min();
        int minUnit = unit.Min();

        // 우선 처음에는 모든 기타줄을 묶음으로 산 뒤 그 가격을 구한다.
        int packageCount = N / 6 + 1;
        int unitCount = 0;
        int minPrice = minPackage * (N / 6 + 1);
        // 이후 묶음을 하나씩 줄인 뒤, 모자란 만큼을 낱개로 산 가격을 
        // 기존의 최소 가격과 비교한다.
        while (packageCount >= 0) 
        {
            minPrice = Math.Min(minPrice, 
                minPackage * packageCount + minUnit * unitCount);
            packageCount--;
            unitCount = N - packageCount * 6;
        }
        // 최소 가격을 출력한다.
        Console.WriteLine(minPrice);
    }
}