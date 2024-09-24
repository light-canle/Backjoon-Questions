using System;
using System.Linq;
using System.Text;

/// <summary>
/// p11005 - 진법 변환 2, B1
/// 해겷 날짜 : 2024/3/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        (int N, int B) = (input[0], input[1]);

        Console.WriteLine(ConvertNum(N, B));
    }

    public static string ConvertNum(int N, int B)
    {
        StringBuilder digit = new StringBuilder();

        while (N >= 1)
        {
            int r = N % B;
            digit.Append(r < 10 ? Convert.ToChar(r + 48) : Convert.ToChar(r + 55));
            N /= B;
        }

        StringBuilder ans = new StringBuilder();

        foreach (char i in digit.ToString().Reverse())
        {
            ans.Append(i);
        }

        return ans.ToString();
    }
}