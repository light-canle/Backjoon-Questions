using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p3273 - 두 수의 합, S3
/// 해결 날짜 : 2024/3/9(solved.ac : 3/8)
/// </summary>

// 합이 X가 되는 두수의 조합을 구하는 문제
// 어떤 수 a에 대해 a + b = X인 b가 있는 지를 찾기 위해 정렬 후 이진 탐색을 사용함
// 문제의 조건에 의해 (a, b), (b, a)는 중복이므로 마지막에 2로 나누어 출력했다.
// 시간 복잡도 : O(NlogN)

public class Program
{

    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int count = int.Parse(sr.ReadLine()!);
        List<int> list = sr.ReadLine()!.Split().Select(int.Parse).ToList();
        list.Sort();
        int sumValue = int.Parse(sr.ReadLine()!);

        int ans = 0;
        for (int i = 0; i < count; i++)
        {
            int n = list[i];
            if (Find(sumValue - n, list)) ans++;
        }
        
        Console.WriteLine(ans / 2);
        sr.Close();
    }

    // List에서 number가 존재하는지를 찾는다.
    public static bool Find(int number, List<int> list)
    {
        int low = 0;
        int high = list.Count - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (list[mid] == number)
                return true;
            else if (list[mid] < number)
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