using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] current = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] end = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int curYear = current[0], curMonth = current[1], curDay = current[2];
        int endYear = end[0], endMonth = end[1], endDay = end[2];

        if (curYear == endYear)
        {
            Console.WriteLine($"D-{OrderOfDate(endYear, endMonth, endDay) - OrderOfDate(curYear, curMonth, curDay)}");
        }
        else if (curYear + 1000 < endYear)
        {
            Console.WriteLine("gg");
        }
        else
        {
            if (curYear + 1000 == endYear && (curMonth < endMonth || (curMonth == endMonth && curDay <= endDay)))
            {
                Console.WriteLine("gg");
                return;
            }
            int time = 0;
            time += (IsLeapYear(curYear) ? 366 : 365) - OrderOfDate(curYear, curMonth, curDay);
            for (int i = curYear + 1; i < endYear; i++)
            {
                time += IsLeapYear(i) ? 366 : 365;
            }
            time += OrderOfDate(endYear, endMonth, endDay);
            Console.WriteLine($"D-{time}");
        }
    }

    public static bool IsLeapYear(int year)
    {
        return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
    }

    // 해당 월, 일을 가진 날이 해당 년도에서 몇 번째 날인지 구한다. (1.1은 1, 12.31은 365또는 366)
    public static int OrderOfDate(int year, int month, int day)
    {
        int[] dates = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (IsLeapYear(year))
        {
            dates[2] = 29;
        }
        int time = 0;
        for (int i = 1; i < month; i++)
        {
            time += dates[i];
        }
        time += day;
        return time;
    }
}
