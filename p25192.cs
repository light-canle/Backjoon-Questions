using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p25192 - 인사성 밝은 곰곰이, S4
/// 해결 날짜 : 2024/3/30
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int N = int.Parse(sr.ReadLine()!);
        Dictionary<string, int> useEmoji = new Dictionary<string, int>();

        int emojiCount = 0;
        int newMember = 0;
        for (int i = 0; i < N; i++)
        {
            string name = sr.ReadLine()!;

            if (name == "ENTER")
            {
                newMember++;
            }
            else
            {
                if (!useEmoji.ContainsKey(name) || useEmoji[name] < newMember)
                {
                    useEmoji[name] = newMember;
                    emojiCount++;
                }
            }
        }

        Console.WriteLine(emojiCount);
        sr.Close();
    }
}