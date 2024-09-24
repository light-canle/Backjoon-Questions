using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p24060 - 알고리즘 수업 - 병합 정렬 1, S3
/// 해결 날짜 : 2024/4/1
/// </summary>

/*
'저장'은 Merge함수 안에서 temp 임시 배열에 변수 값을 저장할 때
늘어나므로, 이때 횟수를 센다.
*/

public class Program
{
    public static int saveCount = 0;
    public static int objectiveCount = 0;
    public static int ans = -1;
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int[] input = sr.ReadLine()!.Trim().Split().Select(int.Parse).ToArray();
        objectiveCount = input[1];
        List<int> list = sr.ReadLine()!.Trim().Split().Select(int.Parse).ToList();

        MergeSort(list, 0, list.Count - 1);

        Console.WriteLine(ans);
    }

    public static void MergeSort(List<int> list, int lpos, int rpos)
    {
        if (lpos < rpos)
        {
            int q = (lpos + rpos) / 2;
            MergeSort(list, lpos, q);
            MergeSort(list, q + 1, rpos);
            Merge(list, lpos, q, rpos);
        }
    }

    public static void Merge(List<int> list, int lpos, int half, int rpos)
    {
        int i = lpos, j = half + 1, t = 0;
        int[] temp = new int[rpos - lpos + 1];
        while (i <= half && j <= rpos) 
        {
            if (list[i] <= list[j])
            {
                temp[t] = list[i];
                saveCount++;
                if (saveCount == objectiveCount) ans = list[i];
                t++; i++;
            }
            else 
            {
                temp[t] = list[j];
                saveCount++;
                if (saveCount == objectiveCount) ans = list[j];
                t++; j++;
            }
        }
        while (i <= half)
        {
            temp[t] = list[i];
            saveCount++;
            if (saveCount == objectiveCount) ans = list[i];
            t++; i++;
        }
        while (j <= rpos)
        {
            temp[t] = list[j];
            saveCount++;
            if (saveCount == objectiveCount) ans = list[j];
            t++; j++;
        }
        i = lpos; t = 0;
        while (i <= rpos)
            list[i++] = temp[t++];
    }
}