using System;

/// <summary>
/// p12865 - 평범한 배낭, G5
/// 해결 날짜 : 2023/10/28
/// </summary>

// 가장 기본적인 0-1 배낭 문제

public class Program
{
    // 물건 개수
    public static int N;
    // 판단한 물건 개수와 그 중 담은 물건들의 무게 합 안에서 가장 가치가 높은 것을 담는 배열
    public static int[,] saved;
    // 각 물건들의 무게와 가치를 담음
    public static int[] weigths;
    public static int[] values;
    public static void Main(string[] args)
    {
        string[] size = Console.ReadLine()!.Split();

        N = int.Parse(size[0]); // 총 물건 수
        int K = int.Parse(size[1]); // 담을 수 있는 최대 무게

        weigths = new int[N];
        values = new int[K];
        saved = new int[N, K + 1];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j <= K; j++)
            {
                saved[i, j] = -1;
            }
        }

        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine()!.Split();
            weigths[i] = int.Parse(input[0]);
            values[i] = int.Parse(input[1]);
        }

        package(K, 0);
        int max_value = saved[0, 0];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j <= K; j++)
            {
                max_value = Math.Max(max_value, saved[i, j]);
            }
        }
        Console.WriteLine(max_value);
    }

    // Source : 알고리즘 문제 해결 전략(구종만, 2012)
    // C++ 코드를 C#으로 변형
    public static int package(int capacity, int item_no)
    {
        // 기저 사례 : 모든 아이템을 다 판단해서 더 이상 담을 것이 없다.
        if (item_no == N) return 0;
        // 현재 아이템 수와 무게에서의 최고의 가치 값을 가져옴
        int cur = saved[item_no, capacity];
        // 이미 그것을 구한 경우, 그대로 반환
        if (cur != -1) return cur;

        // 현재 물건을 담지 않았을 때의 가치를 계산
        cur = package(capacity, item_no + 1);
        saved[item_no, capacity] = cur;

        // 현재 물건을 담을 수 있을 정도의 수용량이 남은 경우
        if (capacity >= weigths[item_no])
        {
            // 현재 물건을 담았을 때의 가치와 기존에 있던 최댓값을 비교해서 큰 쪽을 넣는다.
            cur = Math.Max(cur, package(capacity - weigths[item_no], item_no + 1) + values[item_no]);
            saved[item_no, capacity] = cur;
        }
        
        return cur;
    }
}

// 참고할 만한 사이트
// https://gsmesie692.tistory.com/113