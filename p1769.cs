using System;
using System.IO;

/// <summary>
/// p1769 - 3의 배수, S5
/// 해결 날짜 : 2023/9/4
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        string input = sr.ReadLine();

        int digitSum = 0;
        int numOfConvert = 0;
        // 한 자리 수가 아닌 경우에 각 자리의 합을 계산함
        if (input.Length > 1)
        {
            do
            {
                digitSum = DigitSum(input);
                numOfConvert++;
                input = digitSum.ToString();
            } while (digitSum >= 10);
        }
        // 한 자리 수인 경우 따로 변환을 하지 않음
        else
        {
            digitSum = int.Parse(input);
        }

        Console.WriteLine(numOfConvert);
        if (digitSum % 3 == 0)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }

    public static int DigitSum(string input)
    {
        int sum = 0;
        // 각 자리의 합 계산
        for (int i = 0; i < input.Length; i++)
        {
            // '0'의 ASCII 번호는 48이다.
            sum += Convert.ToInt32(input[i]) - 48;
        }
        return sum;
    }
}
