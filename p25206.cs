using System;

/// <summary>
/// p25206 - 너의 평점은, S5
/// 해결 날짜 : 2023/9/3
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string input;
        double totalScore = 0;
        double totalCredit = 0;
        while(true)
        {
            input = Console.ReadLine();
            // 무한 입력을 종료하는 조건
            if (input == "\n" || input == "\0" 
                || input == "" || input == null)
            {
                break;
            }
            string[] splited = input.Split();
            // P인 과목은 계산에 포함되지 않음
            if (splited[2] == "P") continue;
            totalCredit += double.Parse(splited[1]);
            double score = 0;
            switch(splited[2])
            {
                case "A+": score = 4.5; break;
                case "A0": score = 4.0; break;
                case "B+": score = 3.5; break;
                case "B0": score = 3.0; break;
                case "C+": score = 2.5; break;
                case "C0": score = 2.0; break;
                case "D+": score = 1.5; break;
                case "D0": score = 1.0; break;
                case "F": score = 0.0; break;
            }
            totalScore += score * double.Parse(splited[1]);
        }

        Console.WriteLine(totalScore / totalCredit);
    }
}
