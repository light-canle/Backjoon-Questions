using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

// p17425 - 약수의 합 (G4)
// #정수론 #누적 합
// 2025.7.27 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(sr.ReadLine().Trim());
        // 약수의 합
        // divisor[k] = k의 약수 합
        List<int> divisorSum = new();
        // 약수의 합에 대한 누적합
        List<long> prefix = new();
        for (int i = 0; i <= 1000000; i++)
        {
            divisorSum.Add(0);
            prefix.Add(0);
        }

        // 1부터 10^6의 약수의 합을 구한다.
        /*
        i를 1부터 100만까지 늘려가면서
        i의 배수 증 100만 이하인 수 j의 divisor[j]에 i를 누적한다.
        i의 배수는 i를 약수로 가지기 때문에 이 방법으로
        1부터 100만까지의 약수 합을 한꺼번에 구할 수 있다.
        */
        for (int i = 1; i <= 1000000; i++)
        {
            for (int j = i; j <= 1000000; j += i)
            {
                divisorSum[j] += i;
            }
        }

        // 구한 divisorSum에 대한 누적합을 구한다.
        long s = 0;
        for (int i = 1; i <= 1000000; i++)
        {
            s += divisorSum[i];
            prefix[i] = s;
        }      

        // 1부터 k까지의 자연수의 약수의 합을 구한다.
        for (int i = 0; i < n; i++)
        {
            int k = int.Parse(sr.ReadLine().Trim());
            sw.WriteLine(prefix[k]);
        }
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
