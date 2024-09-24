using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p11659 - 구간 합 구하기 4, S3
/// 해결 날짜 : 2023/8/31
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new StringBuilder();

        int[] input = sr.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

        int numberCount = input[0];
        int caseNum = input[1];
        List<int> list = sr.ReadLine().Split().Select(x => int.Parse(x)).ToList();

        // 첫 원소 부터 현재 원소까지의 합을 저장하는 배열
        // 최대 합은 1000 x 100000 = 100000000(1억)으로 int 내에서 충분하다.
        // 예를 들어 list가 1 2 3 4 5인 경우
        // sumList 에는 1 3 6 10 15가 저장된다.
        int partialSum = 0;
        List<int> sumList = new List<int>();
        for (int i = 0; i < numberCount; i++)
        {
            partialSum += list[i];
            sumList.Add(partialSum);
        }

        int rangeSum;
        for (int i = 0; i < caseNum; i++)
        {
            int[] range = sr.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            /* 
            a ~ b번째 까지의 원소의 합 구하기
            a = 1인 경우 이미 sumList에 1번째 원소부터 b번째 까지의 합이 저장되어 있으므로
            sumList에서 range[1] - 1번째 값을 들고온다.
            아닐 경우 
            (k1 + k2 + ... + ka + k(a+1) + ... kb) - (k1 + k2 + ... k(a-1))이
            a번째 부터 b번째까지 원소의 합이 된다.
            즉 sumList에서 b번째 원소(1~b번째 까지의 합, 인덱스로는 range[1]-1)에서
            a-1번째 원소(1~a-1번째 까지의 합, 인덱스로는 range[0] - 2)를 빼야 원하는 값이 나온다.
            */ 
            if (range[0] == 1) rangeSum = sumList[range[1] - 1];
            else rangeSum = sumList[range[1] - 1] - sumList[range[0] - 2];
            output.AppendLine(rangeSum.ToString());
        }
       
        sw.WriteLine(output);

        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
