#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

// p16139 - 인간-컴퓨터 상호작용 (S1)
// #누적 합
// 2025.9.9 solved

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder output = new StringBuilder();

        string str = sr.ReadLine();
        int len = str.Length;
        // 누적 합 배열 생성 - psum['a'][i]는 문자열의 시작부터 i-1번 인덱스까지 등장한 'a'의 개수
        Dictionary<char, List<int>> psum = new();
        int[] count = new int[26]; // a~z의 누적 개수
        for (char c = 'a'; c <= 'z'; c++)
        {
            psum[c] = new() {0};
        }
        
        for (int i = 0; i < len; i++)
        {
            // 해당 인덱스에서 등장한 문자의 개수 갱신
            count[str[i] - 'a']++;
            // 지금까지 등장한 개수를 누적 합에 저장
            for (int j = 0; j < 26; j++)
            {
                psum[Convert.ToChar(j + 'a')].Add(count[j]);
            }
        }

        int q = int.Parse(sr.ReadLine());
        for (int i = 0; i < q; i++)
        {
            string[] input = sr.ReadLine().Split();
            char toFind = char.Parse(input[0]);
            int l = int.Parse(input[1]);
            int r = int.Parse(input[2]);
            // 0~i번 인덱스에서 등장한 개수가 psum[c][i+1]에 저장되어 있으므로 r + 1에서 l을 뺀다.
            output.AppendLine((psum[toFind][r + 1] - psum[toFind][l]).ToString());
        }
        sw.WriteLine(output);
        sw.Flush();
        sr.Close();
        sw.Close();
    }
}
