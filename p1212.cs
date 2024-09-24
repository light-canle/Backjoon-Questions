using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// p1212 - 8진수 2진수, B2
/// 해결 날짜 : 2023/11/9
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        string input = sr.ReadLine();

        StringBuilder output = new StringBuilder();

        output.Append(OctToBin(input[0], true));

        for (int i = 1; i < input.Length; i++)
        {
            output.Append(OctToBin(input[i]));
        }

        Console.WriteLine(output);
        sr.Close();
    }

    public static string OctToBin(char input, bool firstDigit = false)
    {
        switch (input)
        {
            case '0': return (firstDigit) ? "0" : "000";
            case '1': return (firstDigit) ? "1" : "001";
            case '2': return (firstDigit) ? "10" : "010";
            case '3': return (firstDigit) ? "11" : "011";
            case '4': return "100";
            case '5': return "101";
            case '6': return "110";
            case '7': return "111";
            default: return "";
        }
    }
}