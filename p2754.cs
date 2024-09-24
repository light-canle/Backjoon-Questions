using System;

/// <summary>
/// p2754 - 학점계산, B5
/// 해결 날짜 : 2023/9/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();

        string[] grade = { "A+", "A0", "A-", "B+", "B0", "B-", 
            "C+", "C0", "C-", "D+", "D0", "D-", "F"};
        double[] point = { 4.3, 4.0, 3.7, 3.3, 3.0, 2.7, 2.3, 2.0, 1.7, 1.3, 1.0, 0.7, 0.0 };

        for (int i = 0; i < grade.Length; i++)
        {
            if (grade[i] == input)
            {
                Console.WriteLine($"{point[i]:F1}");
                break;
            }
        }
    }
}