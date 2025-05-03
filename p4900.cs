using System;
using System.Collections.Generic;

// p4900 - 7 더하기 (S3)
// #문자열
// 2025.5.3 solved

public class Program
{
    public static Dictionary<string, char> digit = new()
    {
        ["063"] = '0',
        ["010"] = '1',
        ["093"] = '2',
        ["079"] = '3',
        ["106"] = '4',
        ["103"] = '5',
        ["119"] = '6',
        ["011"] = '7',
        ["127"] = '8',
        ["107"] = '9',
    };
    public static Dictionary<char, string> reverse = new()
    {
        ['0'] = "063",
        ['1'] = "010",
        ['2'] = "093",
        ['3'] = "079",
        ['4'] = "106",
        ['5'] = "103",
        ['6'] = "119",
        ['7'] = "011",
        ['8'] = "127",
        ['9'] = "107",
    };
    public static void Main(string[] args)
    {
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "BYE")
            {
                break;
            }
            // 두 수를 가져옴
            string[] nums = line.Split(new char[] { '+', '=' });
            string A = nums[0], B = nums[1];
            Console.WriteLine($"{A}+{B}={Reverse(Parse(A) + Parse(B))}");
        }
    }

    // code로 주어진 수를 정수로 바꾼다.
    public static int Parse(string seg)
    {
        string ret = "";
        int len = seg.Length;

        for (int i = 0; i < len; i += 3)
        {
            // 3자리 씩 자른 뒤 그에 대응하는 자릿수로 반환
            string part = new string(new char[] { seg[i], seg[i + 1], seg[i + 2] });
            ret += digit[part];
        }
        return int.Parse(ret);
    }

    public static string Reverse(int n)
    {
        string strNum = n.ToString();
        string ret = "";
        foreach (var c in strNum)
        {
            // 자릿수에 대응하는 세자리 코드로 반환
            ret += reverse[c];
        }
        return ret;
    }
}
