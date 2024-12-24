using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] dates = {0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        while (true)
        {
            int[] date = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int day = date[0], month = date[1], year = date[2];
            if (month == 0 && day == 0 && year == 0) 
                break;

            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) 
            {
                dates[2] = 29;
            }
            else
            {
                dates[2] = 28;
            }
            
            int time = 0;
            for (int i = 1; i < month; i++)
            {
                time += dates[i];
            }
            time += day;
            Console.WriteLine(time);
        }
    }
}
