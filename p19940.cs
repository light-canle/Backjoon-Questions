using System;

// p19940 - 피자 오븐 (G5)
// #그리디
// 2025.8.30 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            int[] ret = new int[5];
	        // 60 초과분에 대해서는 60버튼을 누르는 것이 제일 횟수가 적음
            // 0 ~ 59에 대해서만 고려한다.
            ret[0] = n / 60;
            n %= 60;
            
            int ten = n / 10; // 십의 자리 수
            int one = n % 10; // 일의 자리 수
            // 십자리에 상관없이 일의 자리가 0~4이면 +1을 누르는 게 효율적이다.
            if (0 <= one && one <= 4)
                ret[3] += one;
            /*
            끝이 5인 수를 만드는 가장 최소의 클릭
            5 -> 1 1 1 1 1
            15 -> 10 1 1 1 1 1
            25 -> 10 10 1 1 1 1 1
            35 -> 10 10 10 1 1 1 1 1 (60 -10 -10 -1 -1 -1 -1 -1도 있지만 60을 누르는 것을 적게 하는 것이 더 우선 순위가 높다.)
            45 -> 60 -10 -1 -1 -1 -1 -1
            55 -> 60 -1 -1 -1 -1 -1
            십의 자리가 4, 5인 경우에는 -1을 5번, 그 외에는 +1을 5번을 선택
            */
            else if (one == 5)
            {
                if (ten == 4 || ten == 5)
                    ret[4] += 5;
                else
                    ret[3] += 5;
            }
            /*
            6~9, 16~19, 26~29는 10을 하나 더 추가하고 -1을 누른다.
            36~39, 46~49, 56~59는 -10 하나에 +10이 상쇄되므로 추가하지 않는다.
            */
            else
            {
                if (ten <= 2)
                    ret[1] += 1;
                ret[4] += 10 - one;
            }

            // 0~29의 경우에는 +10만 추가한다.
            if (0 <= ten && ten <= 2)
                ret[1] += ten;
            /*
            30~35는 +10을 3번 누르는게 효율적이다.
            36~39는 60 -> -10 x 2 누르는게 효율적이다.
            */
            else if (ten == 3)
            {
                if (one >= 6)
                {
                    ret[0] += 1;
                    ret[2] += 2;
                }
                else
                    ret[1] += 3;
            }
            else
            {
                ret[0] += 1;
                /*
                45~49, 55~59는 +10과 -10 1개씩 상쇄되므로, 추가되는 -10이 하나 더 적다.
                */
                if (5 <= one && one <= 9)
                    ret[2] += 5 - ten;
                else
                    ret[2] += 6 - ten;
            }
            Console.WriteLine(string.Join(" ", ret));
        }
    }
}
