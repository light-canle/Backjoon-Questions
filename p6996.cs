using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string a = input[0];
            string b = input[1];

            int[] ca = new int[26];
            int[] cb = new int[26];
            for (int j = 0; j < a.Length; j++)
            {
                ca[a[j] - 'a']++;
            }
            for (int j = 0; j < b.Length; j++)
            {
                cb[b[j] - 'a']++;
            }

            bool isAnagram = true;
            for (int j = 0; j < 26; j++)
            {
                if (ca[j] != cb[j])
                {
                    isAnagram = false;
                    break;
                }
            }

            if (isAnagram)
            {
                Console.WriteLine($"{a} & {b} are anagrams.");
            }
            else
            {
                Console.WriteLine($"{a} & {b} are NOT anagrams.");
            }
        }
   }
}
