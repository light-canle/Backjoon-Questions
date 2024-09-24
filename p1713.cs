using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1713 - 후보 추천하기, S1
/// 해결 날짜 : 2024/4/6
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()!);
        int times = int.Parse(Console.ReadLine()!);
        int[] nums = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        // 후보자의 번호, 그 후보자가 지금까지 받은 추천 수
        List<int> candidateList = new List<int>();
        List<int> candidateCount = new List<int>();

        for (int i = 0; i < times; i++)
        {
            // 이미 후보자에 있는 경우에는 추천 수를 1 증가
            if (candidateList.Contains(nums[i]))
            {
                int pos = candidateList.IndexOf(nums[i]);
                candidateCount[pos]++;
            }
            else if (candidateList.Count >= N)
            {
                // count가 가장 적은 사람을 후보에서 뺀다.
                // 가장 적은 사람이 여럿일 경우 먼저 들어간 사람을 뺀다.
                int minCount = candidateCount[0];
                int minPos = 0;
                for (int j = 0; j < N; j++)
                {
                    if (minCount > candidateCount[j])
                    {
                        minPos = j;
                        minCount = candidateCount[j];
                    }
                }
                // 그 자리의 원소를 지우고 새 원소를 맨 뒤에 넣는다.(이렇게 해야 먼저 등록된 후보를 구분 할 수 있다.)
                candidateCount.RemoveAt(minPos);
                candidateList.RemoveAt(minPos);
                candidateCount.Add(1);
                candidateList.Add(nums[i]);
            }
            else
            {
                // 맨 뒤에 후보를 넣음
                candidateCount.Add(1);
                candidateList.Add(nums[i]);
            }
        }

        candidateList.Sort();
        Console.WriteLine(string.Join(" ", candidateList));
    }
}