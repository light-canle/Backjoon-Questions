#pragma warning disable CS8604, CS8602, CS8600

using System;

// p14382 - 숫자세는 양 (Large) (S4)
// #시뮬레이션 #완전 탐색
// 2025.12.24 solved (12.23)

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            int k = int.Parse(Console.ReadLine());
            // 0의 배수는 0 밖에 없다.
            if (k == 0)
            {
                Console.WriteLine($"Case #{i}: INSOMNIA");
            }
            else
            {
                Console.WriteLine($"Case #{i}: {FindSleep(k)}");
            }
        }
    }

    public static int FindSleep(int k)
    {
        bool[] found = new bool[10];
        Func<bool[], bool> allFound = (arr) =>
        {
            for (int i = 0; i < 10; i++)
            {
                if (!arr[i]) return false;
            }
            return true;
        };
        int cur = k;
        while (true)
        {
            string str = cur.ToString();
            // 각 자리에 나온 수를 써놓는다.
            foreach (char c in str)
            {
                found[c - '0'] = true;
            }
            // 0 ~ 9가 적어도 1번씩 등장한 순간 그 수를 반환
            if (allFound(found)) return cur;
            cur += k;
        }
    }
}
