#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.Collections.Generic;
using System.IO;

// p29791 - 에르다 노바와 오리진 스킬 (S4)
// #정렬 #구현
// 2025.12.8 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int n = arr[0], m = arr[1];
        List<int> skill1Time = sr.ReadLine().Split().Select(int.Parse).ToList();
        List<int> skill2Time = sr.ReadLine().Split().Select(int.Parse).ToList();
        skill1Time.Sort(); skill2Time.Sort();

        int useSkill1 = 0, useSkill2 = 0;
        int lastSkill1 = -1, lastSkill2 = -1;

        for (int i = 0; i < n; i++)
        {
            if (lastSkill1 == -1 || lastSkill1 + 100 <= skill1Time[i])
            {
                lastSkill1 = skill1Time[i];
                useSkill1++;
            }
        }

        for (int i = 0; i < m; i++)
        {
            if (lastSkill2 == -1 || lastSkill2 + 360 <= skill2Time[i])
            {
                lastSkill2 = skill2Time[i];
                useSkill2++;
            }
        }

        Console.WriteLine($"{useSkill1} {useSkill2}");
        sr.Close();
    }
}
