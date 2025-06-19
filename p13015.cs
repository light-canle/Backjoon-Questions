using System;
using System.IO;

// p13015 - 별 찍기 - 23 (S4)
// #구현
// 2025.6.19 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        int n = int.Parse(Console.ReadLine().Trim());
        string star1 = new string('*', n); // 길이 n인 별문자열 *****
        string star2 = "*" + new string(' ', n - 2) + "*"; // 길이 n인 양끝이 *이고, 가은데가 공백인 문자열 *   *
        sw.WriteLine(star1 + new string(' ', 2 * n - 3) + star1); // 첫 줄
        // 중간 부분 : 2번째 줄부터 n - 1번 줄까지 공백 하나 + star2 + 공백 2n - 5개 + star2로 구성되고
        // 줄이 내려갈 수록 앞 공백은 1칸 늘고, 중간 공백은 2칸씩 준다.
        for (int i = 0; i < n - 2; i++)
        {
            sw.WriteLine(new string(' ', i + 1) + star2 + new string(' ', 2 * n - 5 - 2 * i) + star2);
        }
        // 제일 중간 부분
        sw.WriteLine(new string(' ', n - 1) + star2 + new string(' ', n - 2) + "*");
        // 이 아래는 대칭이다.
        for (int i = n - 3; i >= 0; i--)
        {
            sw.WriteLine(new string(' ', i + 1) + star2 + new string(' ', 2 * n - 5 - 2 * i) + star2);
        }
        sw.WriteLine(star1 + new string(' ', 2 * n - 3) + star1); // 끝 줄
        sw.Flush();
        sw.Close();
    }
}
