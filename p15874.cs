using System;
using System.IO;
using System.Text;

// p15874 - Caesar Cipher (B2)
// #문자열
// 2025.3.23 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] input = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
        int k = input[0], s = input[1];
        string code = sr.ReadLine();

        StringBuilder output = new();
        foreach (char c in code)
        {
            output.Append(Convert(c, k).ToString());
        }
        Console.WriteLine(output);
        sr.Close();
    }

    public static char Convert(char s, int k)
    {
        // 대문자
        if (65 <= s && s <= 90)
        {
            k %= 26;
            // 범위를 벗어나면 범위 안으로 넣어준다.
            if (s + k > 90)
            {
                return (char)(s + k - 26);
            }
            else
            {
                return (char)(s + k);
            }
        }
        // 소문자
        else if (97 <= s && s <= 122)
        {
            k %= 26;
            if (s + k > 122)
            {
                return (char)(s + k - 26);
            }
            else
            {
                return (char)(s + k);
            }
        }
        // 그 외 문자
        else
        {
            return s;
        }
    }
}
