using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p1620 - 나는야 포켓몬 마스터 이다솜, S4
/// 해결 날짜 : 2023/9/6
/// </summary>

/*
키-값 쌍 배열인 사전(딕셔너리)을 사용한 문제
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();

        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int N, int M) = (input[0], input[1]);

        Dictionary<int, string> names = new Dictionary<int, string>();
        Dictionary<string, int> nums = new Dictionary<string, int>();
        for (int i = 1; i <= N; i++)
        {
            names.Add(i, sr.ReadLine());
            nums.Add(names[i], i);
        }

        for (int i = 1; i <= M; i++)
        {
            string some = sr.ReadLine();
            if (int.TryParse(some, out int num))
            {
                output.AppendLine(names[num]);
            }
            else
            {
                output.AppendLine(nums[some].ToString());
            }
        }

        Console.WriteLine(output.ToString());
    }
}

/*
C#에서는 names.First(x => x.Value == some).Key를 이용해서
값에서 역으로 키를 추적할 수 있지만 이것도 O(n)이 걸리는 작업이고, 이 문제에서는 시간 초과를 유발했다.
그래서 이 문제에는 키와 값의 배열이 반대가 된 다른 딕셔너리를 하나 더 만들어서 시간안에 풀 수 있었다.
물론 List<string>을 써서 메모리를 반만 써서 문제를 풀 수도 있었다.
*/