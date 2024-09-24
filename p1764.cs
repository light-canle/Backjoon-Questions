using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p1764 - 듣보잡, S4
/// 해결 날짜 : 2023/9/11
/// </summary>

/*
입력이 최대 500,000개로 O(nlogn)안에 풀어야 하는,
두 문자열 배열에서 공통으로 있는 모든 문자열을 사전순으로 정렬한 것을 출력하는 문제
첫 번째 배열에 있는 어떤 문자열이 다른 배열에 있는지 조사하는 데는 O(n^2)가 걸린다.
그러므로, 여기서는 원소를 O(1)안에 탐색하는 해시(딕셔너리)를 사용했다.
우선 people이라는 이름의 딕셔너리에 첫 번째 배열의 문자열들을 입력받아 해당 딕셔너리의 키로 지정했다.
(값에 해당하는 키는 중요하지 않아서 0을 넣었다.)
그 후, 두 번째 배열의 문자열들을 입력받으면서 키로 지정해준다.
이때, 이미 들어있는 문자열일 경우 딕셔너리의 길이에 변화를 주지 않을 것이다.
그래서 키로 지정한 뒤, 딕셔너리의 크기가 변하지 않을 경우 그 문자열은 두 배열에 모두 속한 것이므로
finds에 넣어주었다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();

        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        (int aNum, int bNum) = (input[0], input[1]);

        // 첫 번째 배열 입력
        Dictionary<string, int> people = new Dictionary<string, int>();
        for (int i = 0; i < aNum; i++)
        {
            // 받은 문자열을 딕셔너리의 키로 저장
            people[sr.ReadLine()] = 0;
        }
        // 두 번째 배열 입력
        List<string> finds = new List<string>();
        for (int i = 0; i < bNum; i++)
        {
            // 받은 문자열, 현재 크기
            string name = sr.ReadLine();
            int currentSize = people.Count;
            // 키로 지정
            people[name] = 1;
            // 길이 변화가 없다면 그것은 이미 있는 문자열이다.
            if (people.Count == currentSize)
            {
                finds.Add(name);
            }
        }
        // 사전순 출력을 위한 정렬
        finds.Sort();
        // 개수와 문자열 출력
        output.AppendLine(finds.Count.ToString());
        foreach(string name in finds)
        {
            output.AppendLine(name);
        }

        Console.WriteLine(output.ToString());
        sr.Close();
    }
}