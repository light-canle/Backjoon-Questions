using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p18870 - 좌표 압축, S2
/// 해결 날짜 : 2023/9/9
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new StringBuilder();

        int N = int.Parse(sr.ReadLine());
        // N개의 수를 입력 받음
        var list = sr.ReadLine().Split().Select(int.Parse).ToList();
        // 각 수의 크기 순위를 매기기 위해서 중복되지 않은 수열을 만듦
        var disList = list.Distinct().ToList();
        // 정렬 - 이제 인덱스가 해당 수보다 작은 수의 개수가 된다.
        disList.Sort();

        // 접근 시간을 O(1)로 하기 위해 수를 넣으면 그 작은 수의 개수를 반환하는
        // 딕셔너리를 생성
        Dictionary<int, int> order = new Dictionary<int, int>();
        for (int i = 0; i < disList.Count; i++)
        {
            order.Add(disList[i], i);
        }
        // 딕셔너리를 이용해서 구한 순위(압축된 좌표)를 넣음
        foreach(int num in list)
        {
            output.Append(order[num] + " ");
        }

        sw.WriteLine(output.ToString());

        sw.Flush();
        sw.Close();
        sr.Close();
    }
}