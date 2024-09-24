using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// p1159 - 농구 경기, B2
/// 해결 날짜 : 2023/9/19
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<char> chars = new List<char>();

        for (int i = 0; i < N; i++)
        {
            chars.Add(Console.ReadLine()[0]);
        }

        int[] nums = new int[26];
        foreach (char c in chars)
        {
            nums[Convert.ToInt32(c) - Convert.ToInt32('a')]++;
        }

        if (nums.Max() < 5) 
        {
            Console.WriteLine("PREDAJA");
        }
        else
        {
            for (int i = 0; i < 26; i++)
            {
                if (nums[i] >= 5) Console.Write(Convert.ToChar(i + 97));
            }
        }
    }
}