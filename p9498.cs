using System;

// p9498 - 시험 성적, B5
// 해결 날짜 : 2023/8/20

public class Program
{
    public static void Main(string[] args)
    {
        int score = int.Parse(Console.ReadLine());

        char ans;
        if (90 <= score && score <= 100) ans = 'A';
        else if (80 <= score && score <= 89) ans = 'B';
        else if (70 <= score && score <= 79) ans = 'C';
        else if (60 <= score && score <= 69) ans = 'D';
        else ans = 'F';

        Console.WriteLine(ans);
    }
}
