using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1565 - 수학, G4
/// 해결 날짜 : 2023/10/29
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] size = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        (int dSize, int mSize) = (size[0], size[1]);

        int[] D = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        int[] M = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        // 정답 후보 - M의 첫 번째 수의 약수들을 저장
        // D가 아닌 M으로 한 이유는 어떤 수의 배수는 무한 개이지만,
        // 약수의 개수는 적기 때문이다.
        List<int> candidate = FindDivisior(M[0]);
        
        // M의 있는 원소들과 candidate에 있는 요소들을 하나씩 비교해가며
        // M의 각 원소들의 약수인 것들만 추려서 넣는다.
        for (int i = 1; i < mSize; i++)
        {
            List<int> temp = new List<int>();
            for (int j = 0; j < candidate.Count; j++)
            {
                if (M[i] % candidate[j] == 0)
                    temp.Add(candidate[j]);
            }
            candidate = temp.ConvertAll(i => i);
        }

        // D의 있는 원소들과 candidate에 있는 요소들을 하나씩 비교해가며
        // D의 각 원소들의 배수인 것들만 추려서 넣는다.
        for (int i = 0; i < dSize; i++)
        {
            List<int> temp = new List<int>();
            for (int j = 0; j < candidate.Count; j++)
            {
                if (candidate[j] % D[i] == 0)
                    temp.Add(candidate[j]);
            }
            candidate = temp.ConvertAll(i => i);
        }

        Console.WriteLine(candidate.Count);
    }

    // 해당 수의 약수들을 찾아서 리스트로 반환하는 함수
    // 시간 복잡도 : O(sqrt(N))
    public static List<int> FindDivisior(int N)
    {
        List<int> list = new List<int>();
        // 우선 1은 모든 수의 약수가 된다.
        list.Add(1);
        // 자신을 넣음
        if (N != 1) list.Add(N);
        
        // 2부터 제곱근까지 반복
        for (int i = 2; i * i <= N; i++)
        {
            // i가 N의 약수이면 N / i도 약수가 된다.
            if (N % i == 0)
            {
                list.Add(i);
                if (i * i != N) list.Add(N / i);
            }
        }

        return list;
    }
}