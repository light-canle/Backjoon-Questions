using System;
using System.Linq;
using System.Collections.Generic;

// p1181 - 단어 정렬 - S5
// 해결 날짜 : 2023/8/20

public class Program
{
    public static void Main(string[] args)
    {
        int wordCount = int.Parse(Console.ReadLine());

        List<string> words = new List<string>();

        for (int i = 0; i < wordCount; i++)
        {
            words.Add(Console.ReadLine());
        }

        List<string> result = new List<string>();
        var some = (from word in words
                    orderby word.Length
                    group word by word.Length into sameLength
                    select sameLength.Distinct().OrderBy(x => x).ToList());

        foreach (var item in some)
        {
            result.AddRange(item);
        }
        
        foreach (var word in result)
        {
            Console.WriteLine(word);
        }
    }
}