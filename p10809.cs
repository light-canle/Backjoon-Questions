using System;
using System.Linq;
using System.Collections.Generic;

// p10809 - 알파벳 찾기, B2
// 해결 날짜 : 2023/8/20

public class Program
{
    public static void Main(string[] args)
    {
        string word = Console.ReadLine();

        List<int> index = Enumerable.Repeat(-1, 26).ToList();

        for (int i = 0; i < word.Length; i++)
        {
            // 해당 알파벳이 나타나는 맨 처음 인덱스를 저장
            if (index[Convert.ToInt32(word[i]) - Convert.ToInt32('a')] == -1)
            {
                index[Convert.ToInt32(word[i]) - Convert.ToInt32('a')] = i;
            }
        }

        foreach (int i in index)
        {
            Console.Write(i.ToString() + ' ');
        }
        
    }
}
