using System;

// p1737 - Pibonacci (G4)
// #DP
// 2025.2.7 solved

public class Program
{
    public static long[,] pibo;
    public static long k = 1_000_000_000_000_000_000;
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        /*
        pibo[a][b]는 P[a - b * pi]를 뜻한다.
        실제로 실수 인덱스를 사용할 수는 없고, 정의에 따라 정수에
        pi의 정수배 만큼을 뺀 양의 실수만 인덱스가 되므로 
        2차원 배열로 만들어서 실수 인덱스들을 저장한다.
        */
        pibo = new long[1001, 1001];

        pibo[1, 0] = pibo[2, 0] = pibo[3, 0] = 1;

        Console.WriteLine(Pibonacci(n, 0));
    }

    // P[a - b*pi]를 구한다.
    // Pibonacci의 정의에 따라 인덱스가 pi 이하이면 1,
    // pi보다 크면 재귀적으로 P[n - 1] + P[n - pi]를 구해서 반환한다.
    public static long Pibonacci(int a, int b)
    {
        if (pibo[a, b] != 0) return pibo[a, b]; // dp 사례 : 이미 있는 값은 반환
        double index = a - b * Math.PI; // 실수 인덱스를 구함
        if (index < 0) return 0; // 음수 인덱스는 존재하지 않음
        // 1번 식 : P[n] = 1 (0 <= n <= pi)
        else if (0 <= index && index <= Math.PI) return pibo[a, b] = 1;
        // 2번 식 : P[n] = P[n - 1] + P[n - pi] (n > pi)
        else return pibo[a, b] = ((Pibonacci(a - 1, b) % k) + (Pibonacci(a, b + 1) % k)) % k;
    }
}
