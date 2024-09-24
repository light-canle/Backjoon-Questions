using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// p20920 - 영단어 암기는 괴로워, S3
/// 해결 날짜 : 2024/3/30
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));

        int[] input = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
        (int N, int M) = (input[0], input[1]);

        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        for (int i = 0; i < N; i++)
        {
            string word = sr.ReadLine()!;
            // 길이가 M 이상인 것만 넣음
            if (word.Length >= M) 
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }
        }
        // 많이 등장한 빈도 순으로 정렬 후 개별 리스트로 분화
        var ordered = wordCount.OrderBy(x => -x.Value)
            .GroupBy(x => x.Value)
            .ToList();
        List<List<KeyValuePair<string, int>>> sorted = 
            new List<List<KeyValuePair<string, int>>>();
        // 각 빈도수 별로 모인 리스트 내에서 단어의 길이, 알파벳 순으로 다시 정렬한다.
        for (int i = 0; i < ordered.Count; i++)
        {
            sorted.Add(ordered[i]
                .OrderBy(x => -x.Key.Length)
                .ThenBy(x => x.Key).ToList());
        }
        
        // 순서대로 출력
        StringBuilder output = new StringBuilder();
        foreach (var list in sorted)
        {
            foreach (var word in list)
                output.AppendLine(word.Key);
        }
        Console.WriteLine(output);
        sr.Close();
    }
}
