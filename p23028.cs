#pragma warning disable CS8604, CS8602, CS8600
using System;

// p23028 - 5학년은 다니기 싫어요 (S5)
// #그리디
// 2025.5.27 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] info = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = info[0], major = info[1], total = info[2];

        (int, int)[] subjects = new (int, int)[10];

        for (int i = 0; i < 10; i++)
        {
            int[] p = Console.ReadLine().Split().Select(int.Parse).ToArray();
            subjects[i].Item1 = p[0];
            subjects[i].Item2 = p[1];
        }

        for (int i = 0; i < 8 - n; i++)
        {
            int left = 18; // 들을 수 있는 최대 학점
            // 전공 과목을 우선해서 듣는다.
            while (major < 66 && subjects[i].Item1 > 0)
            {
                major += 3; total += 3;
                subjects[i].Item1--;
                left -= 3;
            }
            total += Math.Min((subjects[i].Item1 + subjects[i].Item2) * 3, left);
        }
        // 졸업요건을 채웠는지 여부 판단
        if (major < 66 || total < 130)
        {
            Console.WriteLine("Nae ga wae");
        }
        else
        {
            Console.WriteLine("Nice");
        }
    }
}
