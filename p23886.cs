using System;
using System.IO;

// p23886 - 알프수 (B1)
// #문자열
// 2025.4.24 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        string num = sr.ReadLine();
        int len = num.Length;
        bool isAlpNum = true;
        int prev = Digit(num[0]), prevDiff = -10;
        for (int i = 1; i < len; i++)
        {
            int cur = Digit(num[i]);
            int curDiff = cur - prev;
            // 처음이 오르막이 아니면 false
            if (i == 1 && curDiff <= 0)
            {
                isAlpNum = false;
                break;
            }
            // 값이 같으면(평지이면) false
            if (curDiff == 0)
            {
                isAlpNum = false;
                break;
            }
            // 마지막이 내리막이 아니면 false
            if (i == len - 1 && curDiff > 0)
            {
                isAlpNum = false;
                break;
            }
            // 처음이 아닌 경우에 이전 경사도와 비교
            if (prevDiff != -10)
            {
                // 오르막 또는 내리막의 경사가 달라지면 false
                // 오르막에서 내리막이 되는 것은 괜찮음
                if (prevDiff * curDiff > 0 && prevDiff != curDiff)
                {
                    isAlpNum = false;
                    break;
                }
            }
            prevDiff = curDiff;
            prev = cur;
        }
        Console.WriteLine(isAlpNum ? "ALPSOO" : "NON ALPSOO");
        sr.Close();
    }

    public static int Digit(char c)
    {
        return (int)(c - '0');
    }
}
