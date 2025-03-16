using System;
using System.IO;

// p15738 - 뒤집기 (S5)
// #구현
// 2025.3.16 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));

        int[] input = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

        int n = input[0];
        int k = input[1];
        int m = input[2];
        
        sr.ReadLine();

        // 바뀌는 부분의 범위
        int l = 0, r = 0;
        // k번째 요소의 현재 인덱스
        int cur = k - 1;
        for (int i = 0; i < m; i++)
        {
            int oper = int.Parse(sr.ReadLine());
            // 연산이 음수인 경우 끝에서 |oper|개가 바뀌는 범위가 된다.
            if (oper < 0)
            {
                l = n + oper; r = n - 1; 
            }
            else
            {
                l = 0; r = oper - 1;
            }

            // cur이 뒤집히는 범위에 속함
            if (l <= cur && cur <= r)
            {
                // 뒤집히는 영역의 중간점 (반정수일 수 있어서 double 사용)
                double half = (l + r) / 2.0;
                double diff = Math.Abs(half - cur);
                // 중간을 기준으로 왼쪽에 있으면 차이의 2배만큼 더해 오른쪽으로, 반대는 왼쪽으로 보낸다.
                // note : half는 정수 아니면 반정수이므로 2 * diff는 정수임이 보장된다.
                if (cur < half)
                {
                    cur = (int)(cur + 2 * diff);
                }
                else
                {
                    cur = (int)(cur - 2 * diff);
                }
            }
        }
        Console.WriteLine(cur + 1);
        sr.Close();
    }
}
