using System;

// p25592 - 바둑돌 게임 (B1)
// #시뮬레이션
// 2025.6.11 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        
        int c = 1;
        bool myTurn = true;
        // 각 턴마다 돌을 빼낸다.
        while (n >= c)
        {
            n -= c;
            c++;
            myTurn = !myTurn;
        }

        // 돌이 모자란 턴이 자신의 턴이 아니면 0, 자신의 턴이면 모자란 만큼 출력
        if (!myTurn)
            Console.WriteLine(0);
        else
            Console.WriteLine(c - n);
    }
}
