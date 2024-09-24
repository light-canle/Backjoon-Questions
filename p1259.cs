using System;

// p1259 팰린드롬수, B1
// 해결 날짜 : 2023/8/19

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (input == "0") break; 

            string ans = (IsPalindrome(input)) ? "yes" : "no";
            Console.WriteLine(ans);
        }
    }

    public static bool IsPalindrome(string num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            if (num[i] != num[num.Length - i - 1])
            {
                return false;
            }
        }
        return true;
    }
}
