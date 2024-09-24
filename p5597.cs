using System;
using System.Linq;

/// <summary>
/// p5597 - 과제 안 내신 분..?, B5
/// 해결 날짜 : 2023/9/17
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        for (int i = 0; i < 28; i++)
        {
            numbers.Add(int.Parse(Console.ReadLine()));
        }

        for (int i = 1; i <= 30; i++)
        {
            if (!numbers.Contains(i))
            {
                Console.WriteLine(i);
            }
        }
    }
}