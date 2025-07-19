#pragma warning disable CS8604, CS8602, CS8600

using System;
using System.IO;

// p33985 - 그거 왜 말해! (S4)
// #애드 혹
// 2025.7.19 solved

/*
문제에서 제시된 연산을 하면 A는 앞에, B는 뒤에 위치한다.
A가 연속 : ABXX -> AABX -> AAAB (앞에서 부터 연산)
B가 연속 : XXAB -> XABB -> ABBB (뒤에서 부터 연산)
A가 시작, B가 끝인 임의의 문자열에 대하여 B 다음에 오는 A를 기준으로 경계를 나누면,
나눈 부분 문자열들을 위의 규칙으로 만들어 낼 수 있다. (AAB|AB|ABBB|AB|AAB|AB)
즉, s에서 맨 앞 문자가 A, 맨 뒤 문자가 B이기만 하면 가운데는 어떤 것이 와도 연산을 통해 s를 만들 수 있다.
*/
public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new(new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        
        string code = sr.ReadLine();
        Console.WriteLine(code[0] == 'A' && code[n-1] == 'B' ? "Yes" : "No");
    }
}
