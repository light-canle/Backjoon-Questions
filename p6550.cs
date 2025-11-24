#pragma warning disable CS8604, CS8602

using System;
using System.IO;

// p6550 - 부분 문자열 (S5)
// #문자열
// 2025.11.25 solved (11.24)

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        while (true)
        {
            string line = sr.ReadLine()!;
            if (line == null)
            {
                break;
            }
            string[] arr = line.Trim().Split();
            string sub = arr[0];
            string text = arr[1];
            // sub의 한 자리씩 비교함
            int len = sub.Length, pointer = 0;
            foreach (char c in text)
            {
                if (pointer == len) break;
                if (sub[pointer] == c) pointer++;
            }
            Console.WriteLine(pointer == len ? "Yes" : "No");
        }
        sr.Close();
    }
}
