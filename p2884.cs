using System;
using System.Linq;
using System.Collections.Generic;

// p2884 - 알람 시계, B3
// 해결 날짜 : 2023/8/20

public class Program
{
    public static void Main(string[] args)
    {
        List<int> input = Console.ReadLine().ToLower().Split(' ').Select(x => int.Parse(x)).ToList();

        int hour = input[0];
        int minute = input[1];

        if (minute < 45) 
        {
            if (hour == 0) hour = 23;
            else { hour--; }
            minute += 60;
        }
        minute -= 45;

        Console.WriteLine($"{hour} {minute}");
    }
}
