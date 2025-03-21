using System;

// p1166 - 선물 (S3)
// #이분 탐색
// 2025.3.21 solved

/*
이 문제를 풀 때 오버플로우 문제 때문에 질문 게시판의 글을 일부 참고했다.
1. 이분 탐색에서 while이 아닌 for문을 택한 이유는
double형의 한계로 인해 절대/상대 오차가 10^(-10)보다 작은 low와 high가 없어
무한히 반복문이 반복될 위험이 있기 때문이다.

2. IsValid의 조건식은 이분탐색에 적절하나 오버플로우를
심하게 유발했다. -> l * w * h를 double로 캐스팅하고,
l, w, h를 int가 아닌 long으로 받음으로써 해결했다.
*/
public class Program
{
    public static void Main(string[] args)
    {
        long[] input = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

        long n = input[0];
        long l = input[1];
        long w = input[2];
        long h = input[3];

        long min = Math.Min(Math.Min(l, w), h);

        double low = 0;
        double high = 2.0 * min;

        double mid = 0;
        // 100000번 반복
        for (int i = 0; i < 100000; i++)
        {
            mid = (low + high) / 2;
            if (IsValid(n, l, w, h, mid))
            {
                low = mid;
            }
            else
            {
                high = mid;
            }
        }
        Console.WriteLine(mid);
    }

    public static bool IsValid(long n, long l, long w, long h, double a)
    {
        // 현재 상자의 부피
        // 오버플로우 주의!
        double vol = (double)l * w * h;

        // n개의 정육면체 부피가 상자보다 작고,
        // 상자 안에 그 정육면체들을 상자 밖으로 나오지 않게 하면서 전부 넣을 수 있는지를 판정
        return a * a * a * n <= vol && (long)(l / a) * (long)(w / a) * (long)(h / a) >= n;
    }
}
