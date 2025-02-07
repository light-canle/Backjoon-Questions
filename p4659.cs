using System;
using System.Linq;

// p4659 - 비밀번호 발음하기 (S5)
// #문자열
// 2025.2.7 solved

public class Program
{
    public static void Main(string[] args)
    {
        char[] vowels = {'a', 'e', 'i', 'o', 'u'};
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                break;
            }
            int len = input.Length;
            bool containVowel = false;
            bool noThree = true;
            bool noConsecutive = true;
            int rowVowel = 0;
            int rowConsonant = 0;
            int rowSame = 0;
            char prev = ' ';
            for (int i = 0; i < len; i++)
            {
                if (vowels.Contains(input[i]))
                {
                    containVowel = true;
                    rowVowel++;
                    rowConsonant = 0;
                }
                else
                {
                    rowConsonant++;
                    rowVowel = 0;
                }

                if (rowVowel >= 3 || rowConsonant >= 3)
                {
                    noThree = false;
                    break;
                }

                if (prev == input[i])
                {
                    rowSame++;
                }
                else
                {
                    rowSame = 1;
                }

                if (rowSame == 2 && !(prev == 'e' || prev == 'o'))
                {
                    noConsecutive = false;
                    break;
                }
                
                prev = input[i];
            }
            if (containVowel && noThree && noConsecutive)
            {
                Console.WriteLine($"<{input}> is acceptable.");
            }
            else
            {
                Console.WriteLine($"<{input}> is not acceptable.");
            }
        }
    }
}
