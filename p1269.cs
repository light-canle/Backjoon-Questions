using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p1269 - 대칭 차집합, S4
/// 해결 날짜 : 2023/11/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] nums = sr.ReadLine()!.Split().Select(int.Parse).ToArray();

        (int N, int M) = (nums[0], nums[1]);

        List<int> A = sr.ReadLine()!.Split().Select(int.Parse).OrderBy(x => x).ToList();
        List<int> B = sr.ReadLine()!.Split().Select(int.Parse).OrderBy(x => x).ToList();

        List<int> result = difference(A, B);
        result.AddRange(difference(B, A));

        Console.WriteLine(result.Distinct().Count());
        sr.Close();
    }
    // A - B를 구하는 메소드
    // a, b는 반드시 정렬되어 있어야 한다.
    public static List<int> difference(List<int> a, List<int> b)
    {
        List<int> A_B = new List<int>();
        int sizeA = a.Count;
        int sizeB = b.Count;
        int indexA = 0, indexB = 0;
        while (indexA < sizeA && indexB < sizeB)
        {
            // 현재 a리스트의 값이 b리스트의 값보다 같다는 뜻은 현재 a리스트 값이
            // b리스트에 없을 수도, 뒷 부분에 있을수도 있음을 뜻한다.
            if (a[indexA] > b[indexB])
                indexB++;
            // 현재 a리스트의 값이 b리스트의 값보다 같다는 뜻은 현재 a리스트 값은
            // b리스트에 확정적으로 있음을 뜻한다.
            else if (a[indexA] == b[indexB]) 
            {
                indexA++;
                indexB++;
            }
            // 현재 a리스트의 값이 b리스트의 값보다 작다는 뜻은 현재 a리스트 값은
            // b리스트에 없음을 뜻한다.
            else if (a[indexA] < b[indexB])
            {
                A_B.Add(a[indexA]);
                indexA++;
            }    
        }
        while (indexA < sizeA)
        {
            A_B.Add(a[indexA]);
            indexA++;
        }
        return A_B;
    }
}