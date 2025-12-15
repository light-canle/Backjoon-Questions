#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

// p32865 - 컴소인의 크리스마스 (G5)
// #그리디 #정렬
// 2025.12.15 solved

public class Count
{
    public int problemNumber;   // 문제 번호
    public long failCount;      // 틀리는 횟수
    public Count(int problemNumber, long failCount)
    {
        this.problemNumber = problemNumber;
        this.failCount = failCount;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(sr.ReadLine());

        List<Count> failCount = new();
        long totalCount = 0; // 전체 틀리는 횟수
        for (int i = 0; i < n; i++)
        {
            long current = long.Parse(sr.ReadLine());
            failCount.Add(new (i + 1, current));
            totalCount += current;
        }
        // 틀리는 횟수가 정확하게 n - 1번이 아니면 트리 제작은 불가능하다.
        // 문제 개수 == 실패 횟수이면, 최선의 경우에도 마지막에 맞았습니다!가 필요할 때 실패 횟수가 1이 남은 문제만 남아 트리를 만들 수 없게 된다.
        // 그 외에 n - 1이 아닌 경우에는 아예 번갈아가면서 트리를 만드는게 불가능하다.
        if (totalCount != n - 1)
        {
            sw.WriteLine(-1);
        }
        else
        {
            // 틀려야 하는 횟수의 오름차순으로 정렬
            failCount = failCount.OrderBy(x => x.failCount).ToList();
            int left = 0, right = n - 1;

            // 길이는 무조건 2n - 1이다.
            // 정렬 후에 0부터 시작하는 포인터와 끝에서 시작하는 포인터를 둬서
            // 맞았습니다!가 필요할 때는 두 포인터 중 남은 틀린 횟수가 0인 것 (둘 다라면 오른쪽 우선)을 고른 뒤 포인터를 옮기고,
            // 틀렸습니다가 필요한 경우에는 오른쪽 포인터가 가리키는 문제의 번호를 출력하고 틀릴 횟수를 1 줄인다.
            int totalLength = 2 * n - 1;
            for (int i = 0; i < totalLength; i++)
            {
                // 맞았습니다 필요
                if (i % 2 == 0)
                {
                    // 오른쪽 포인터가 0이면 우선 처리해야 한다.
                    if (failCount[right].failCount == 0)
                    {
                        sw.WriteLine(failCount[right].problemNumber);
                        right--;
                    }
                    else if (failCount[left].failCount == 0)
                    {
                        sw.WriteLine(failCount[left].problemNumber);
                        left++;
                    }
                }
                // 틀렸습니다 필요
                else
                {
                    sw.WriteLine(failCount[right].problemNumber);
                    failCount[right].failCount -= 1;
                }
            }
        }
        sw.Flush();
    }
}
