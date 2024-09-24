using System;

/// <summary>
/// p5622 - 다이얼, B2
/// 해결 날짜 : 2024/3/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine()!;
        int time = 0;

        for (int i = 0; i < input.Length; i++)
        {
            time += FindNumber(input[i]);
        }

        Console.WriteLine(time);
    }

    public static int FindNumber(char digit)
    {
        switch (digit)
        {
            case 'A': case 'B': case 'C':
                return 3;
            case 'D': case 'E': case 'F':
                return 4;
            case 'G': case 'H': case 'I':
                return 5;
            case 'J': case 'K': case 'L':
                return 6;
            case 'M': case 'N': case 'O':
                return 7;
            case 'P': case 'Q': case 'R': case 'S':
                return 8;
            case 'T': case 'U': case 'V':
                return 9;
            case 'W': case 'X': case 'Y': case 'Z':
                return 10;
            default: return 0;
        }
    }
}