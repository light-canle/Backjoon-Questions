#pragma warning disable CS8604, CS8602

using System;
using System.IO;
using System.Collections.Generic;

// p25318 - solved.ac 2022 (S1)
// #구현 #문자열
// 2025.11.25 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        if (n == 0)
        {
            Console.WriteLine(0);
            return;
        }
        List<(double, int)> opinions = new();
        for (int i = 0; i < n; i++)
        {
            string[] info = sr.ReadLine()!.Trim().Split();
            string date = info[0];
            string time = info[1];
            int level = int.Parse(info[2]);
            double converted = TimeFrom2019(date, time);
            opinions.Add((converted, level));
        }

        double[] weights = new double[n];
        double lastTime = opinions[n - 1].Item1;

        // 시간에 따른 가중치를 구한다.
        double weightSum = 0;
        for (int i = 0; i < n; i++)
        {
            // 시간 차이를 구함
            double timeDiff = (lastTime - opinions[i].Item1) / 365.0;
            weights[i] = Math.Max(Math.Pow(0.5, timeDiff), Math.Pow(0.9, n - i - 1));
            weightSum += weights[i];
        }

        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += weights[i] * opinions[i].Item2;
        }

        double result = Math.Round(sum / weightSum, MidpointRounding.AwayFromZero);
        Console.WriteLine(result);
        sr.Close();
    }

    // 2019년 1월 1일 0시를 기준으로 지난 일 수와 시간을 실수 형태로 반환
    public static double TimeFrom2019(string date, string time)
    {
        int[] d = date.Split('/').Select(int.Parse).ToArray();
        int[] t = time.Split(':').Select(int.Parse).ToArray();
        if (d[0] < 2019) return 0;
        return DaysFrom2019(d[0], d[1], d[2]) + TimePercent(t[0], t[1], t[2]);
    }

    public static bool IsLeapYear(int year)
    {
        return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
    }

    // 2019년 1월 1일 부터 해당 날짜까지 경과한 날 수를 반환 (과거 날짜와 2019/01/01은 0)
    public static int DaysFrom2019(int year, int month, int day)
    {
        if (year < 2019) return 0;
        int ret = 0;
        for (int i = 2019; i < year; i++)
        {
            ret += IsLeapYear(i) ? 366 : 365;
        }
        return ret + OrderOfDay(month, day, IsLeapYear(year));
    }

    //  1월 1일 = 0, ... 12월 31일 = 364 / 윤년인 경우에는 2/29를 포함
    public static int OrderOfDay(int month, int day, bool isLeapYear)
    {
        int ret = 0;
        int[] days = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (isLeapYear)
        {
            days[2] = 29;
        }
        for (int i = 1; i < month; i++)
        {
            ret += days[i];
        }
        return ret + day - 1;
    }

    public static double TimePercent(int hour, int minute, int second)
    {
        return (hour * 3600 + minute * 60 + second) / 86400.0;
    }
}
