using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p2108 - 통계학, S3
/// 해결 날짜 : 2023/8/25
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int numCount = int.Parse(sr.ReadLine());

        List<int> numbers = new List<int>(); // 수들을 담는 리스트
        List<int> countList = Enumerable.Repeat(0, 8001).ToList(); // -4000~4000의 개수를 담는 리스트
        List<int> modeList = new List<int>(); // 최빈값을 담는 리스트
        double sum = 0;
        for (int i = 0; i < numCount; i++)
        {
            int num = int.Parse(sr.ReadLine());
            sum += num;
            numbers.Add(num);
            countList[num+4000]++;
        }
        numbers.Sort(); // 중앙값을 구하기 위한 정렬

        // 최빈값을 구하기 위해 리스트 순회
        int maxCount = 1;
        for (int i = 0; i < countList.Count; i++)
        {
            if (countList[i] > maxCount)
            {
                // 기존의 모든 최빈값 후보들을 지우고 그 값을 새로 넣는다.
                modeList.Clear();
                modeList.Add(i - 4000);
                maxCount = countList[i];
            }
            else if (countList[i] == maxCount)
            {
                modeList.Add(i - 4000);
            }
        }
        // modeList를 크기 순으로 정렬
        modeList.Sort();

        Console.WriteLine((long)Math.Round(sum / numCount)); 
        Console.WriteLine(numbers[numCount / 2]);
        // 최빈값이 여럿일 경우 2번째로 작은 값을 넣는다.
        int mode = (modeList.Count == 1) ? modeList[0] : modeList[1];
        Console.WriteLine(mode);
        Console.WriteLine(numbers.Max() - numbers.Min());

        sr.Close();
    }
}
