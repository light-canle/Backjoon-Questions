using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p17103 - 골드바흐 파티션, S2
/// 해결 날짜 : 2024/3/8(solved.ac : 3/7)
/// </summary>

/*
2 ~ 1,000,000 사이에 있는 모든 소수의 배열을 구하기 위해 에라토스테네스의 체를 사용했다.
그 후 2부터 시작해서 어떤 소수에 대해 (입력된 수 - 소수)도 소수에 들어가는 지 판단하기 위해
(입력된 수 - 소수)가 primeList에 들어있는 지를 이진 탐색을 통해 풀었다.
*/

public class Program
{
    public static List<int> primeList;
    public static void Main(string[] args)
    {
        // 2 ~ 1,000,000 사이에 있는 소수의 배열을 구한다.
        List<int> list = Enumerable.Range(2, 999999).ToList();
        primeList = new List<int>();
        var cur = list[0];
        while (cur <= 1001)
        {
            cur = list[0];
            primeList.Add(cur);
            list = list.Where(x => x % cur != 0).ToList();
        }
        // sqrt(1000000) 이하의 소수에 대해서만 체를 적용하면 나머지 수는 모두 소수만 남는다. - 검증 필요, 일단 1000000에 대해서는 검증되었다.
        primeList.AddRange(list);

        
        int count = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < count; i++)
        {
            int ans = 0;
            int number = int.Parse(Console.ReadLine()!);
            int index = 0;
            int half = number / 2;
            while (primeList[index] <= half)
            {
                if (IsPrime(number - primeList[index])) { ans++; }
                index++;
            }
            Console.WriteLine(ans);
        }
        
    }

    // primeList에서 number가 존재하는지를 찾는다. - 이진 탐색 사용
    public static bool IsPrime(int number)
    {
        int low = 0;
        int high = primeList.Count - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (primeList[mid] == number)
                return true;
            else if (primeList[mid] < number)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return false;
    }
}