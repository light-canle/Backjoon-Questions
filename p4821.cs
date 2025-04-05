using System;
using System.Linq;

// p4821 - 페이지 세기 (S4)
// #문자열 #파싱
// 2025.4.5 solved

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            int page = int.Parse(Console.ReadLine());
            if (page == 0)
            {
                break;
            }
            // ',' 기준으로 분리
            string[] range = Console.ReadLine().Split(',');
            bool[] printed = new bool[page + 1];
            foreach (var s in range)
            {
                // '-' 기준으로 분리
                int[] r = s.Split('-').Select(int.Parse).ToArray();
                // 단일수 (- 없음) : page 이하이면 printed를 true로 설정
                if (r.Length == 1)
                {
                    if (r[0] <= page)
                    {
                        printed[r[0]] = true;
                    }
                }
                // 범위인 경우
                // 왼쪽 수가 더 크거나 왼쪽 수가 page를 넘어가면 무시
                else if (r.Length == 2)
                {
                    if (r[0] > r[1])
                    {
                        continue;
                    }
                    else if (r[0] > page)
                    {
                        continue;
                    }
                    // 오른쪽 수가 범위를 벗어나면 page까지만 추가
                    int left = r[0];
                    int right = Math.Min(r[1], page);
                    for (int p = left; p <= right; p++)
                    {
                        printed[p] = true;
                    }
                }
            }
            int toPrint = 0;
            for (int i = 1; i <= page; i++)
            {
                if (printed[i]) toPrint++;
            }
            Console.WriteLine(toPrint);
        }
    }
}
