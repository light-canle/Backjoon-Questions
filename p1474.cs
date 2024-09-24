using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// p1474 - 밑 줄, S1
/// 해결 날짜 : 2024/3/9
/// </summary>

/*
그리디 알고리즘을 사용해서 단어들 사이에 밑줄을 어떻게 넣어야 할 지를 결정하는 문제
문제의 설명에 의하면 사전 순서에서 대문자는 '_'보다 빠르고, 소문자는 '_'보다 느리다.
즉, 사전 순으로 가장 빠른 단어를 만들기 위해서는 반드시 밑줄을 넣어야 하는 상황이 아니라면
대문자 앞에는 최대한 적게, 소문자 앞에는 최대한 많이 _를 넣어야 한다.
개수 차이가 1이어야 하므로 최소한 넣어야 하는 _의 개수를 구한 뒤, 추가로 넣어야 하는 부분을 찾아서
_를 넣어주면 된다.
*/

public class Program
{

    public static void Main(string[] args)
    {
        // input
        int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        (int N, int M) = (input[0], input[1]);
        List<string> list = new List<string>();
        // 단어들의 총 길이 합
        int wordLength = 0;

        for (int i = 0; i < N; i++)
        {
            string word = Console.ReadLine()!;
            wordLength += word.Length;
            list.Add(word);
        }

        // 넣어야 하는 밑줄의 총 개수
        int underLineCount = M - wordLength;
        // 각 단어 사이에 넣어야 하는 밑줄의 최소 수
        int minUnderLine = underLineCount / (N - 1);
        // 밑줄의 최소 개수 만큼 넣은 뒤 더 넣어야 하는 밑줄의 수
        int additionalLine = underLineCount - (minUnderLine * (N - 1));
        // 각 단어 사이에 넣을 _의 개수
        int[] lineCount = new int[N - 1];
        for (int i = 0; i < N - 1; i++)
        {
            // 남은 공간과 추가로 넣어야 하는 밑줄 수가 같다.
            // 즉 남은 공간에 밑줄을 모두 삽입해야 한다.
            if (additionalLine >= N - i - 1)
            {
                for (int j = i; j < N - 1; j++)
                {
                    lineCount[j] = minUnderLine + 1;
                }
                break;
            }
            // 넣어야 할 밑줄이 남음 - 뒤의 단어가 대문자인 경우에는 넣지 말고, 소문자인 경우에는 넣음
            else if (additionalLine > 0)
            {
                if (char.IsUpper(list[i + 1][0]))
                {
                    lineCount[i] = minUnderLine;
                }
                else
                {
                    lineCount[i] = minUnderLine + 1;
                    additionalLine--;
                }
            }
            // 더 넣어야 하는 밑줄이 없음 - 최소 개수만큼 넣음
            else
            {
                lineCount[i] = minUnderLine;
            }
        }
        // word generataion
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < N; i++)
        {
            output.Append(list[i]);
            // 단어 사이에 구한 개수만큼 밑줄을 넣음
            if (i != N - 1)
            {
                output.Append(new String('_', lineCount[i]));
            }
        }

        Console.WriteLine(output.ToString());
    }
}