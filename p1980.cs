using System;

// p1980 - 햄버거 사랑 (S4)
// #완전 탐색
// 2025.7.12 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int a = input[0], b = input[1], t = input[2];
        // a가 시간이 작은 쪽이 되도록 한다.
        if (a > b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        // 우선 시간이 적게 걸리는 쪽을 최대한 먹는다고 가정한다.
        // 이후 시간이 많이 걸리는 햄버거를 1개씩 늘리면서 콜라를 먹는
        // 시간이 더 적게 걸리는 경우가 있다면 그때의 개수로 갱신한다.
        int minR = a + 1;
        int large = 0;
        int count = t / a;
        while (large * b <= t)
        {
            int r = (t - large * b) % a;
            if (r < minR)
            {
                minR = r;
                count = large + (t - large * b) / a;
            }
            large++;
        }
        Console.WriteLine($"{count} {minR}");
    }
}
