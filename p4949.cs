using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// p4949 - 균형잡힌 세상, S4
/// 해결 날짜 : 2023/8/25
/// </summary>

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        StringBuilder output = new StringBuilder();
        List<char> sentense = new List<char>(); // .으로 끝나는 문장의 각 문자를 저장
        Stack<char> parentheses = new Stack<char>(); // 괄호의 유효성을 검사하기 위한 스텍

        while (true) 
        {
            // ======= 입력 =======
            // 문제에서 .으로 문장을 구분하기 때문에 특수한 입력 구문을 사용했다.
            sentense.Clear();
            parentheses.Clear();
            int input;
            do
            {
                input = Console.Read(); // 한 문자씩 받음 - ascii 코드 문자로 받는다.
                // \n과 같은 기호도 입력으로 받으므로, ascii 코드 출력 가능한 범위인지를 검사한다.
                if (32 <= input && input <= 126) 
                {
                    sentense.Add((char)input);
                }
            }
            while (input != (int)'.'); // 문장의 끝은 '.'이다.
            
            // 문장에 '.'밖에 없는 경우에는 모든 입력이 끝이 난다.
            if (sentense.Count == 1) break;

            // ======= 괄호 유효성 검사 =======
            bool isVaild = true;
            for (int i = 0; i < sentense.Count; i++)
            {
                // 왼쪽 괄호들은 스택에 넣는다.
                if (sentense[i] == '(') parentheses.Push('(');
                else if (sentense[i] == '[') parentheses.Push('[');
                // 오른쪽 괄호가 나온 경우 스택을 검사한다.
                // 스택이 비어있거나, 스택 맨 위 괄호가 짝이 맞지 않을 경우 유효하지 않다.
                else if (sentense[i] == ')')
                {
                    if (parentheses.Count == 0)
                    {
                        isVaild = false;
                        break;
                    }
                    char p = parentheses.Pop();
                    if (p != '(')
                    {
                        isVaild = false;
                        break;
                    }
                }
                else if (sentense[i] == ']')
                {
                    if (parentheses.Count == 0)
                    {
                        isVaild = false;
                        break;
                    }
                    char p = parentheses.Pop();
                    if (p != '[')
                    {
                        isVaild = false;
                        break;
                    }
                }
            }
            // 반복이 끝났음에도 스택이 비어있지 않다면 몇몇 왼쪽 괄호의 짝이 없는 것이므로 유효하지 않다.
            if (parentheses.Count != 0) isVaild = false;
            output.AppendLine((isVaild) ? "yes" : "no");
        }

        Console.WriteLine(output.ToString());
        sr.Close();
    }
}
