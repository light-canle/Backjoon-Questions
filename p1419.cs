using System;

// p1419 - 등차수열의 합 (G5)
// #수학 #애드 혹 #많은 조건 분기 (4개)
// 2025.9.4 solved

public class Program
{
    public static void Main(string[] args)
    {
        int l = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int ans = 0;
        // k=2 -> 2x+d
        // 1, 2를 제외한 모든 자연수
        if (k == 2)
        {
            if (r > 2)
                ans = r - Math.Max(3, l) + 1;
        }
        // k=3 -> 3x+3d = 3(x+d) || x+d는 2 이상 자연수를 생성
        // 6 이상의 3의 배수
        else if (k == 3)
        {
            if (r > 5)
            {
                // l이상 r이하의 3의 배수의 개수
                int upper = r / 3;
                int lower = (l - 1) / 3;

                ans = upper - lower;
                // 3이 범위에 포함되면 뺀다.
                ans -= l <= 3 ? 1 : 0;
            }
        }
        // k=4 -> 4x+6d = 2(2x+3d) || 2x+3d는 5와 7 이상 자연수를 생성
        // 10, 14 이상의 짝수
        else if (k == 4)
        {
            // l이상 r이하의 짝수의 개수
            int upper = r / 2;
            int lower = (l - 1) / 2;
            ans = upper - lower;
            // 2, 4, 6, 8, 12가 범위 내에 있으면 빼야 한다.
            int[] toRemove = {2, 4, 6, 8, 12};
            foreach (int n in toRemove)
            {
                if (l <= n && n <= r)
                    ans -= 1;
            }
        }
        // k=5 -> 5x+10d=5(x+2d) || x+2d는 3 이상의 자연수 생성
        // 15 이상의 5의 배수
        else if (k == 5)
        {
            // l이상 r이하의 5의 배수의 개수
            int upper = r / 5;
            int lower = (l - 1) / 5;
            ans = upper - lower;

            // 5, 10이 범위 내에 있으면 빼야 한다.
            int[] toRemove = {5, 10};
            foreach (int n in toRemove)
            {
                if (l <= n && n <= r)
                    ans -= 1;
            }
        }
        Console.WriteLine(ans);
    }
}
