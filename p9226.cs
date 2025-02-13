using System;

// p9226 - 도깨비말 (B2)
// #문자열
// 2025.2.14 solved

public class Program
{
    public static void Main(string[] args)
    {
        char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        while (true)
        {
            string input = Console.ReadLine();

            if (input == "#")
            {
                break;
            }

            int vowelCount = 0;
            int firstVowel = -1;
            int len = input.Length;
            for (int i = 0; i < len; i++)
            {
                if (vowels.Contains(input[i]))
                {
                    if (firstVowel == -1)
                    {
                        firstVowel = i;
                    }
                    vowelCount++;
                }
            }
            if (vowelCount == 0)
            {
                Console.WriteLine(input + "ay");
            }
            else
            {
                string left = input.Substring(firstVowel);
                string mid = input.Substring(0, firstVowel);
                Console.WriteLine(left + mid + "ay");
            }
        }
    }
}
