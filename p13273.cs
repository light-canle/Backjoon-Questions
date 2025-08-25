using System;
using System.Linq;
using System.Collections.Generic;

// p13273 - 로마숫자 (G5)
// #구현 #문자열
// 2025.8.25 solved

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        
        int num = 0;
        for (int i = 0; i < t; i++)
        {
            string line = Console.ReadLine();
            if (int.TryParse(line, out num))
            {
                Console.WriteLine(ArabicToRoman(line));
            }
            else
            {
                Console.WriteLine(RomanToArabic(line));
            }
        }
    }

    public static int RomanToArabic(string roman)
    {
        int len = roman.Length;
        int ret = 0;
        Dictionary<char, int> value = new() {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        char cur = '\0', next = '\0';
        for (int i = 0; i < len; i++)
        {
            cur = roman[i];
            next = i < len - 1 ? roman[i + 1] : '\0';
            switch (cur)
            {
            case 'I':
                ret += (next == 'V' || next == 'X') ? -value[cur] : value[cur];
                break;
            case 'X':
                ret += (next == 'L' || next == 'C') ? -value[cur] : value[cur];
                break;
            case 'C':
                ret += (next == 'D' || next == 'M') ? -value[cur] : value[cur];
                break;
            default:
                ret += value[cur];
                break;
            }
        }
        return ret;
    }

    public static string ArabicToRoman(string arabic)
    {
        int len = arabic.Length;
        string ret = "";
        for (int i = 0; i < len; i++)
        {
            ret += PartRoman(arabic[i] - '0', len - i - 1);
        }
        return ret;
    }

    public static string PartRoman(int num, int pow)
    {
        string[] roman = {"I", "V", "X", "L", "C", "D", "M", "", ""};
        string one = roman[0 + pow * 2];
        string five = roman[1 + pow * 2];
        string ten = roman[2 + pow * 2];
        
        string ret = num switch {
            int i when 1 <= i && i <= 3 => Repeat(one, i), 
            int i when i == 4 => one + five,
            int i when i == 5 => five,
            int i when 6 <= i && i <= 8 => five + Repeat(one, i - 5),
            int i when i == 9 => one + ten,
            _ => ""
        };
        return ret;
    }

    public static string Repeat(string str, int time)
    {
        return string.Concat(Enumerable.Repeat(str, time));
    }
}
