#pragma warning disable CS8604, CS8602, CS8600

using System;

// p2607 - 비슷한 단어 (S2)
// #문자열 #구현
// 2025.10.25 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string str = Console.ReadLine();
        int[] thisChars = new int[26];
        // 주어진 문자열의 각각의 문자 수를 센다.
        foreach (char c in str)
        {
            thisChars[c - 'A']++;
        }
        int similar = 0;
        for (int i = 0; i < n - 1; i++)
        {
            string other = Console.ReadLine();
            int[] otherChars = new int[26];
            foreach (char c in other)
            {
                otherChars[c - 'A']++;
            }
            int diff = 0;
            // 각각의 문자 수의 차이를 구한다.
            for (int j = 0; j < 26; j++)
            {
                diff += Math.Abs(thisChars[j] - otherChars[j]);
            }
            // diff <= 1은 str과 구성이 같은 문자열에서 1문자를 빼거나 추가한 것을 의미한다.
            // (diff == 2 && str.Length == other.Length)는 str과 구성이 같은 문자열에서 1문자를 다른 것으로 교체한 것을 의미한다.
            if (diff <= 1 || (diff == 2 && str.Length == other.Length)) similar++;
        }
        Console.WriteLine(similar);
    }
}
