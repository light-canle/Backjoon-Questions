using System;

/// <summary>
/// p1343 - 폴리오미노, S5
/// 해결 날짜 : 2023/9/7
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string output = "";
        int Xcount = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == 'X')
            {
                Xcount++;
                if (Xcount == 4)
                {
                    output += "AAAA";
                    Xcount = 0;
                }
            }
            if (input[i] == '.')
            {
                if (Xcount % 2 != 0)
                {
                    output = "-1";
                    break;
                }
                if (Xcount == 4) { output += "AAAA"; }
                else if (Xcount == 2) { output += "BB"; }
                Xcount = 0;
                output += ".";
            }
        }
        if (Xcount % 2 != 0)
        {
            output = "-1";
        }
        else if (Xcount == 4) { output += "AAAA"; }
        else if (Xcount == 2){ output += "BB"; }
        Console.WriteLine(output);
    }
}