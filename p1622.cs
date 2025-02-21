using System;

// p1622 - 공통 순열 (S4)
// #문자열 #정렬
// 2025.2.21 solved

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string s1 = Console.ReadLine();
            if (s1 == null)
            {
                break;
            }
            string s2 = Console.ReadLine();
            int[] s1Count = new int[26];
            int[] s2Count = new int[26];
            
            // 각 문자열에 a~z가 몇 개씩 있는지 센다.
            for (int i = 0; i < s1.Length; i++)
            {
                s1Count[s1[i] - 'a']++;
            }
            for (int i = 0; i < s2.Length; i++)
            {
                s2Count[s2[i] - 'a']++;
            }

            // 각 문자열에 공통으로 있는 문자를 찾아 a부터 z순으로 추가한다.
            string ret = "";

            for (int i = 0; i < 26; i++)
            {
                int min = Math.Min(s1Count[i], s2Count[i]);
                ret += new string((char)(i + 'a'), min);
            }
            Console.WriteLine(ret);
        }
    } 
}
