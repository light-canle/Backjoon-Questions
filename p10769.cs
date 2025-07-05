using System;

// p10769 - 행복한지 슬픈지 (B1)
// #문자열
// 2025.7.5 solved

public class Program
{
    public static void Main(string[] args)
    {
        string text = Console.ReadLine();
        int happy = Count(text, ":-)");
        int sad = Count(text, ":-(");
        if (happy + sad == 0)
        {
            Console.WriteLine("none");
        }
        else if (happy == sad)
        {
            Console.WriteLine("unsure");
        }
        else if (happy > sad)
        {
            Console.WriteLine("happy");
        }
        else
        {
            Console.WriteLine("sad");
        }
    }

    // h에 포함된 n의 개수를 구한다.
    public static int Count(string h, string n)
    {
        int hlen = h.Length;
        int nlen = n.Length;
        int ret = 0;
        for (int i = 0; i + nlen < hlen; i++)
        {
            string part = h.Substring(i, nlen);
            ret += part == n ? 1 : 0;
        }
        return ret;
    }
}
