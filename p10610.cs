using System;
using System.IO;
using System.Linq;

/// <summary>
/// p10610 - 30, S4
/// 해결 날짜 : 2023/9/22
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int[] num = sr.ReadLine().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

        int[] count = new int[10];
        for (int i = 0; i < num.Length; i++)
        {
            count[num[i]]++;
        }
        if (count[0] == 0 || num.Sum() % 3 != 0) {
            Console.WriteLine(-1);
        }
        else
        {
            string result = "";
            for (int i = 9; i >= 0; i--) {
                result += new String(Convert.ToChar(i+48), count[i]);
            }
            Console.WriteLine(result);
        }
    }
}