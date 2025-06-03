using System;
using System.IO;

// p27930 - 당신은 운명을 믿나요? (B1)
// #문자열 #그리디
// 2025.6.3 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        string s = sr.ReadLine();
        int len = s.Length;
        string korea = "KOREA";
        string yonsei = "YONSEI";
        int kp = 0, yp = 0;
        // 각 문자열을 이루는 문자가 나오면 인덱스 이동
        // 먼저 끝에 도달한 문자열을 출력
        for (int i = 0; i < len; i++)
        {
            if (s[i] == korea[kp]) kp++;
            if (s[i] == yonsei[yp]) yp++;

            if (kp == 5)
            {
                Console.WriteLine("KOREA");
                break;
            }
            if (yp == 6)
            {
                Console.WriteLine("YONSEI");
                break;
            }
        }
        sr.Close();
    }
}
