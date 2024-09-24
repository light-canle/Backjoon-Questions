using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p1874 - 스택 수열, S2
/// 해결 날짜 : 2023/8/29
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();

        int N = int.Parse(Console.ReadLine());

        List<int> list = new List<int>();

        for (int j = 0; j < N; j++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }

        Stack<int> stack = new Stack<int>();
        int inputNum = 1;

        int i = 0;
        while (i < N)
        {
            // 스택이 빈 경우 넣어야 할 수를 하나 넣어준다.
            if (stack.Count == 0)
            {
                stack.Push(inputNum);
                output.AppendLine("+");
                inputNum++;
            }
            // 수열에 넣을 수가 아직 스택에 안 들어갔을 때
            // 그 수까지 반복해서 스택에 넣고 pop을 해준다.
            else if (list[i] >= inputNum)
            {
                while (stack.First() < list[i] && inputNum <= N)
                {
                    stack.Push(inputNum);
                    output.AppendLine("+");
                    inputNum++;
                }
                stack.Pop();
                output.AppendLine("-");
                i++;
            }
            // 수열에 넣을 수가 스택에 있을 때 맨 위에 있지 않으면 NO를 출력
            // 아니면 그냥 pop을 해준다.
            else if (list[i] != stack.First())
            {
                output.Clear();
                output.AppendLine("NO");
                break;
            }
            else
            {
                stack.Pop();
                output.AppendLine("-");
                i++;
            }
            
        }
        Console.WriteLine(output);

        sr.Close();
    }
}
