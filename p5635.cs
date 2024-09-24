using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p5635 - 생일, S5
/// 해결 날짜 : 2023/9/15
/// </summary>

// 가장 나이가 많은 사람과 나이가 적은 사람을 출력하는 문제(나이가 같다면 생일 순으로)
// DateTime을 쓰거나 년, 월, 일 순으로 정렬하면 더 적은 줄을 쓸 수도 있다.

public class Info
{
    public string Name { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        string[] input = Console.ReadLine().Split().ToArray();

        Info youngest = new Info
        {
            Name = input[0],
            Year = int.Parse(input[3]),
            Month = int.Parse(input[2]),
            Day = int.Parse(input[1])
        };

        Info oldest = new Info
        {
            Name = input[0],
            Year = int.Parse(input[3]),
            Month = int.Parse(input[2]),
            Day = int.Parse(input[1])
        };

        for (int i = 0; i < N - 1; i++)
        {
            input = Console.ReadLine().Split().ToArray();

            Info current = new Info
            {
                Name = input[0],
                Year = int.Parse(input[3]),
                Month = int.Parse(input[2]),
                Day = int.Parse(input[1])
            };

            if (current.Year < oldest.Year) oldest = current;
            else if (current.Year == oldest.Year &&
                current.Month < oldest.Month) oldest = current;
            else if (current.Year == oldest.Year &&
                current.Month == oldest.Month &&
                current.Day < oldest.Day) oldest = current;

            if (current.Year > youngest.Year) youngest = current;
            else if (current.Year == youngest.Year &&
                current.Month > youngest.Month) youngest = current;
            else if (current.Year == youngest.Year &&
                current.Month == youngest.Month &&
                current.Day > youngest.Day) youngest = current;
        }

        Console.WriteLine(youngest.Name);
        Console.WriteLine(oldest.Name);
    }
}