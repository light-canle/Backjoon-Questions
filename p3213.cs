using System;

// p3213 - 피자 (S4)
// #그리디
// 2025.5.17 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        // 필요한 조각들의 개수
        int[] p = new int[3];
        for (int i = 0; i < n; i++)
        {
            string piece = Console.ReadLine();
            switch (piece)
            {
            case "1/4": p[0]++; break;
            case "1/2": p[1]++; break;
            case "3/4": p[2]++; break;
            }
        }
        /*
        우리가 필요로 하는 것은 '온전한' 조각으로 나누어주기 위한 피자의 최소 수이다.
        즉, 3/4크기 조각을 원하는 사람에게 1/4 + 1/2의 형태로 주는 것이 아닌 온전한 3/4 하나로 주기 위해 필요한 피자의 수를 원한다.
        */
        // 최종적으로 필요한 조각 수
        // 우선 3/4크기 조각의 수만큼 피자가 필요함
        int need = p[2];
        // 남는 1/4크기 조각의 수
        // 3/4조각을 자르고 나면 그 개수 만큼 1/4조각이 생긴다.
        int qBlank = p[2];
        // 3/4, 1/2 크기 조각은 하나의 피자에서 동시에 나올 수 없으므로 1/2크기를 위한 피자를 따로 마련한다.
        need += (p[1] / 2) + (p[1] % 2 == 0 ? 0 : 1);
        // 1/2조각이 홀수 개이면 남은 거로 1/4 조각 2개를 만들 수 있다.
        qBlank += p[1] % 2 == 0 ? 0 : 2;
        // 3/4, 1/2 조각을 만들고 남은 1/4 조각의 수를 필요한 1/4조각 수에서 뺀다.
        int remain = Math.Max(0, p[0] - qBlank);
        // 1/4조각이 더 필요한 경우 그만큼의 피자를 더 마련한다.
        need += (int)Math.Ceiling(remain / 4.0);
        Console.WriteLine(need);
    }
}
