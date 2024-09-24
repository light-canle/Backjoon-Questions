using System;

/// <summary>
/// p1340 - 연도 진행바, S5
/// 해결 날짜 : 2023/9/1
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string[] date = Console.ReadLine().Split();

        // 몇 월인지를 결정함
        string[] month_name = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
        int month = 1;
        for (int i = 0; i < month_name.Length; i++)
        {
            if (date[0] == month_name[i])
            {
                month = i + 1;
                break;
            }
        }
        // 입력 형식에 ,가 끝에 있으므로 이를 제거한 뒤 몇 일인지를 구함
        int day = int.Parse(date[1].Replace(',','\0'));
        
        int[] month_days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        // 윤년 검사
        bool leapYear = IsLeapYear(int.Parse(date[2]));
        if (leapYear) { month_days[1] = 29; }

        // 오늘까지 몇 일이 경과했는지를 구한다.
        double orderOfToday = 0;
        for (int i = 0; i < month - 1; i++)
        {
            orderOfToday += month_days[i];
        }
        orderOfToday += day - 1;

        // 시간, 분 처리
        int hour = int.Parse(date[3].Split(':')[0]);
        int minute = int.Parse(date[3].Split(':')[1]);
        // 하루는 1440분이므로 오늘 경과한 분을 1440으로 나눈다.
        orderOfToday += (double)(hour * 60 + minute) / 1440.0;

        // 현재 시작이 1년의 몇 %인지를 구한다.
        double daysOfYear = (leapYear) ? 366 : 365;
        Console.WriteLine($"{orderOfToday / daysOfYear * 100}");
    }

    // 윤년인지를 검사하는 함수
    public static bool IsLeapYear(int year)
    {
        if (year % 400 == 0) return true;
        else if (year % 4 == 0 && year % 100 != 0) return true;
        return false;
    }
}
