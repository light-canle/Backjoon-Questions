using System;

/// <summary>
/// p2744 - 대소문자 바꾸기, B5
/// 해결 날짜 : 2023/9/26
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        char[] input = Console.ReadLine().ToCharArray();
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsUpper(input[i]))
            {
                input[i] = char.ToLower(input[i]);
            }
            else if (char.IsLower(input[i]))
            {
                input[i] = char.ToUpper(input[i]);
            }
        }
        Console.WriteLine(string.Join("", input));
    }
}