#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

// p20956 - 아이스크림 도둑 지호 (G4)
// #정렬 #덱 #두 포인터
// 2025.10.17 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        sw.AutoFlush = true;
        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int n = input[0], m = input[1];

        List<int> amounts = sr.ReadLine().Split().Select(int.Parse).ToList();
        // 1. (아이스크림 양, 번호)의 크기 2의 튜플로 이루어진 리스트를 만든다.
        List<(int, int)> info = new List<(int, int)> ();
        for (int i = 0; i < n; i++)
        {
            info.Add((amounts[i], i + 1));
        }
        // 2. 튜플 리스트를 아이스크림 양의 내림차순으로, 같은 양 안에서는 번호의 오름차순으로 정렬
        info = info.OrderBy(x => -x.Item1).ThenBy(x => x.Item2).ToList();
        // 3. 양이 같은 튜플끼리 개별 리스트로 묶고, 그 안에서 번호만 따로 추출한다.
        List<List<int>> deque = info.GroupBy(x => x.Item1)
            .Select(x => x.Select(y => y.Item2).ToList()).ToList();

        // true이면 번호가 작은 것부터, false이면 큰 것부터 꺼낸다.
        bool toLeft = true;
        // 꺼낸 아이스크림의 순서
        List<int> result = new();
        // 개별 리스트에서 꺼낼 원소를 지정하는 두 포인터
        int left = 0, right = deque[0].Count - 1;
        // 현재 탐색하는 리스트
        int currentList = 0;
        int currentNum = 0;
        for (int i = 0; i < m; i++)
        {
            // 현재 리스트의 모든 요소를 탐색함
            if (left > right) {
                currentList++;
                left = 0;
                right = deque[currentList].Count - 1;
            }
            // toLeft가 true이면 번호가 작은 것부터 꺼낸다.
            if (toLeft)
            {
                currentNum = deque[currentList][left++];
            }
            else
            {
                currentNum = deque[currentList][right--];
            }

            result.Add(currentNum);
            // 양이 7의 배수인 경우 번호를 꺼내는 방향을 바꾼다. (문제의 표현으로는, 아이스크림의 순서를 뒤집는다.)
            if (amounts[currentNum - 1] % 7 == 0)
            {
                toLeft = !toLeft;
            }
        }

        StringBuilder output = new();
        foreach (var item in result)
        {
            output.AppendLine(item.ToString());   
        }
        sw.WriteLine(output);
        sr.Close();
        sw.Close();
    }
}
