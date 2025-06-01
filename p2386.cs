using System;

// p2386 - 도비의 영어 공부 (B2)
// #문자열
// 2025.6.1 solved

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string input = Console.ReadLine().ToLower();
            if (input == "#")
            {
                break;
            }
            char target = input[0];
            string str = input.Substring(2);
            int len = str.Length;
            int count = 0;
            for (int i = 0; i < len; i++)
            {
                if (str[i] == target)
                {
                    count++;
                }
            }
            Console.WriteLine($"{target} {count}");
        }        
    }
}
