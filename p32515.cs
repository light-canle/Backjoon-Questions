#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Text;

// p32515 - BB84 (B3)
// #문자열
// 2025.12.5 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder outKey = new();
        
        int n = int.Parse(sr.ReadLine());
        string send = sr.ReadLine();
        string sendBit = sr.ReadLine();
        string recieve = sr.ReadLine();
        string recieveBit = sr.ReadLine();

        bool wiretapped = false;
        for (int i = 0; i < n; i++)
        {
            // 두 기저가 다르면 무시
            if (send[i] != recieve[i]) { continue; }
            // 기저가 같은데 보낸 값과 받은 값이 다르면 도청당한 것이다.
            else if (sendBit[i] != recieveBit[i])
            {
                wiretapped = true;
                break;
            }
            outKey.Append(sendBit[i]);
        }
        if (wiretapped)
        {
            sw.WriteLine("htg!");
        }
        else
        {
            sw.WriteLine(outKey);
        }
        sw.Flush();
        sw.Close();
    }
}
