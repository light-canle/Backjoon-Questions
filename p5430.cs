using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// p5430 - AC, G5
/// 해결 날짜 : 2024/3/11(solved.ac : 3/10)
/// </summary>

/*
정수 배열에 Reverse, RemoveFirst 연산을 반복해서 수행했을 때 결과를 출력하는 문제
원소를 제거하는 방향이 맨 앞 밖에 없으므로, reverse를 짝수 번 했을 때는 처음 배열의 앞쪽 원소가,
홀수 번 했을 떄는 처음 배열의 뒤쪽 원소가 하나씩 빠지게 된다.
그래서 reverse를 한 횟수, 현재 배열에 포함된 원소의 최소 인덱스, 최대 인덱스를 저장한 뒤, 
D연산을 할 때마다 최소/최대 인덱스를 1씩 높이거나 낮추어서 연산이 끝났을 때 남아있는 원소들을 출력한다.
이때 reverse 횟수가 홀수이면 뒤집어진 배열을 출력한다.
*/

public class Program
{

    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();
        // input
        int count = int.Parse(sr.ReadLine()!);
        for (int i = 0; i < count; i++)
        {
            string func = sr.ReadLine()!;
            int listLength = int.Parse(sr.ReadLine()!);
            List<int> list = new List<int>();
            string listIn = sr.ReadLine()!;
            if (listLength > 0) 
            {
                list = listIn[1..^1].Split(',').Select(int.Parse).ToList();
            }

            int funcLength = func.Length;
            int lowPointer = 0;
            int highPointer = listLength - 1;
            int reverseCount = 0;
            bool error = false;
            for (int j = 0; j < funcLength; j++)
            {
                if (func[j] == 'R')
                {
                    reverseCount++;
                }
                else if (func[j] == 'D')
                {
                    if (reverseCount % 2 == 0)
                    {
                        lowPointer++;
                    }
                    else
                    {
                        highPointer--;
                    }

                    // error check
                    // lowPointer가 highPointer보다 정확히 1 큰 것은 배열이 비었다는 뜻
                    if (lowPointer > highPointer + 1)
                    {
                        error = true;
                        break;
                    }
                }
            }

            if (error)
            {
                output.AppendLine("error");
            }
            else
            {
                if (listLength == 0)
                {
                    output.AppendLine("[]");
                }
                else
                {
                    var ans = list.GetRange(lowPointer, highPointer - lowPointer + 1);
                    if (reverseCount % 2 == 1)
                        ans.Reverse();
                    output.AppendLine($"[{string.Join(",", ans)}]");
                }
            }
        }

        Console.WriteLine(output);
    }
}