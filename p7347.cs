using System;

// p7347 - 플립과 시프트 (S2)
// #애드 혹 #홀짝성
// 2025.8.25 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine().Trim());

        for (int i = 0; i < t; i++)
        {
            int[] line = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), int.Parse);

            int len = line[0];
            int oddWhite = 0, evenWhite = 0, oddBlack = 0, evenBlack = 0;

            for (int j = 1; j <= len; j++)
            {
                if (line[j] == 0)
                {
                    if (j % 2 == 0)
                        evenWhite++;
                    else
                        oddWhite++;
                }
                else
                {
                    if (j % 2 == 0)
                        evenBlack++;
                    else
                        oddBlack++;
                }
            }

            // 전체 길이가 홀수이면 각 디스크가 어느 칸이든 갈 수 있어 언제나 모을 수 있다.
            // 전체 길이가 짝수이면 한 쪽의 디스크의 홀수 위치, 짝수 위치의 개수 차가 1 이하이면 모을 수 있다.
            bool makeGoal = 
                (len % 2 == 1) ||
                (Math.Abs(evenWhite - oddWhite) <= 1) || 
                (Math.Abs(evenBlack - oddBlack) <= 1);
            Console.WriteLine(makeGoal ? "YES" : "NO");
        }
    }
}
