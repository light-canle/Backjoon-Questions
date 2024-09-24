using System;

/// <summary>
/// p17202 - 핸드폰 번호 궁합, B1
/// 해결 날짜 : 2023/10/4
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        string input1 = Console.ReadLine();
        string input2 = Console.ReadLine();
        string ans = "";

        for (int i = 0; i < 8; i++)
        {
            ans += input1[i];
            ans += input2[i];
        }

        while (ans.Length > 2)
        {
            string temp = "";
            for (int i = 0; i < ans.Length - 1; i++)
            {
                int digit1 = int.Parse(ans[i].ToString());
                int digit2 = int.Parse(ans[i + 1].ToString());
                temp += ((digit1 + digit2) % 10).ToString();
            }
            ans = temp;
        }
        Console.WriteLine(ans);
    }
}