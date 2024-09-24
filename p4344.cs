using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p4344 - 평균은 넘겠지, B1
/// 해결 날짜 : 2023/9/7
/// 100번째 브론즈 문제
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int caseNum = int.Parse(sr.ReadLine());

        for (int i = 0; i < caseNum; i++)
        {
            // 0번 인덱스는 데이터 개수, 1번 부터는 각각의 데이터
            List<int> input = sr.ReadLine().Split().Select(int.Parse).ToList();;
            // 평균을 구함
            double avg = input.GetRange(1, input.Count - 1).Average();
            // 평균보다 높은 데이터 수를 구하고, 그 비율을 출력
            int upperAvgCount = input.GetRange(1, input.Count - 1).Where(x => x > avg).Count();
            double answer = upperAvgCount / (double)input[0];
            Console.WriteLine($"{answer*100:F3}%");
        }

        sr.Close();
    }
}