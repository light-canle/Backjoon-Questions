using System;
using System.IO;

/// <summary>
/// p10989 - 수 정렬하기 3, B1
/// 시작 날짜 : 2023/8/27
/// 해결 날짜 : 2023/8/28
/// </summary>

/*
본래 이 문제는 1~10000 사이의 수로 이루어진 최대 10,000,000개 짜리 배열을
오름차순으로 정렬하는 간단한 문제이지만,
c# 메모리 제한이 너무 엄격해서 10,000,000칸 짜리 short[]로는 문제 해결이 안 되었다.
그래서 1~10000 사이의 수들의 개수를 세는 10,000칸짜리 배열을 만든 뒤,
개수를 세어 그 개수만큼 출력하는 프로그램으로 대신 구현했다.
*/

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

        int N = int.Parse(sr.ReadLine());
        int[] numCount = Enumerable.Repeat(0, 10000).ToArray();
        for (int i = 0; i < N; i++)
        {
            numCount[int.Parse(sr.ReadLine()) - 1]++;
        }

        for (int i = 0; i < 10000; i++) 
        {
            for (int j = 0; j < numCount[i];  j++)
            {
                sw.WriteLine((i+1).ToString());
            }
        }
        
        sw.Flush();

        sw.Close();
        sr.Close();
    }
}
