#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;

// p9742 - 순열 (S3)
// #백트래킹 #문자열 #정렬 #완전 탐색
// 2025.11.3 solved

public class Program
{
    public static char[] newOrder;
    public static bool[] visited;
    public static int left;
    public static string result;
    public static void Main(string[] args)
    {
        int[] facts = { 0, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800 };
        while (true)
        {
            string input = Console.ReadLine();
            if (input == null)
            {
                break;
            }
            char[] chars = input.Split()[0].ToCharArray();
            int len = chars.Length;
            int order = int.Parse(input.Split()[1]);
            // n개의 서로 다른 문자를 1번씩 써서 만들 수 있는 문자열은 n!개이다.
            if (order > facts[len])
            {
                Console.WriteLine($"{input} = No permutation");
                continue;
            }
            chars = chars.OrderBy(x => x).ToArray();
            newOrder = new char[len];
            visited = new bool[len];
            left = order - 1;
            FindOrder(chars, len, 0);
            Console.WriteLine($"{input} = {result}");
        }
    }

    // 사전 순으로 order 번째 문자열을 찾는다.
    public static void FindOrder(char[] list, int total, int depth)
    {
        // 이미 찾았으므로 탐색 불필요
        if (left < 0) return;
        if (total == depth)
        {
            // left가 0일 때 완성된 문자열이 우리가 찾는 문자열이다.
            if (left == 0)
            {
                result = new string(newOrder);
            }
            // 남은 개수 차감
            left--;
            return;
        }
        // 백트래킹으로 순열 생성
        for (int i = 0; i < list.Length; i++)
        {
            if (!visited[i])
            {
                visited[i] = true;
                newOrder[depth] = list[i];
                FindOrder(list, total, depth + 1);
                visited[i] = false;
            }
        }
    }
}
