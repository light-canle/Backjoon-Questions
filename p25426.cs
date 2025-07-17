#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Collections.Generic;

// p25426 - 일차함수들 (S4)
// #그리디 #정렬
// 2025.7.17 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        
        List<long> aList = new List<long>();
        long bSum = 0;
        for (int i = 0; i < n; i++)
        {
            int[] info = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = info[0], b = info[1];
            aList.Add(a);
            bSum += b;
        }
        // b는 상수항이므로 따로 더하면 된다.
        // a와 x가 모두 양수이므로 큰 a에 큰 x를 곱하면 최대가 된다.
        // a들을 정렬하고 작은 것부터 1, 2, ... , N까지 곱해서 더해준다.
        aList.Sort();
        long sum = bSum;
        for (int x = 1; x <= n; x++)
        {
            sum += aList[x - 1] * x;
        }
        Console.WriteLine(sum);
        sr.Close();
    }
}
