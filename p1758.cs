using System;
using System.IO;
using System.Collections.Generic;

// p1758 - 알바생 강호 (S4)
// #그리디 #정렬
// 2025.2.3 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        List<int> list = new List<int>();

        for (int i = 0; i < n; i++)
        {
            list.Add(int.Parse(sr.ReadLine()));
        }

        // 뒷 순위로 갈 수록 팁의 감산이 커지므로
        // 큰 금액을 앞 순위에 배치해 감산을 줄이고
        // 작은 금약을 뒤에 배치에 음수가 아닌 0만큼의 팁을 받도록 한다.
        list.Sort();
        list.Reverse();

        long maxTip = 0;

        for (int i = 0; i < n; i++)
        {
            long tip = list[i] - i;
            maxTip += tip > 0 ? tip : 0;
        }
        Console.WriteLine(maxTip);
        sr.Close();
    }
}
