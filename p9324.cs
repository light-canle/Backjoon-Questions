using System;
using System.IO;

// p9324 - 진짜 메시지 (S4)
// #문자열
// 2025.3.8 solved
public class Program
{
    public static void Main(string[] args)
    {
        StreamReader sr = new (new BufferedStream(Console.OpenStandardInput()));
        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            int[] alphabet = new int[26];
            char? mustNext = null;
            bool isValid = true;
            foreach (char c in line)
            {
                if (mustNext != null)
                {
                    // 나와야 할 문자가 아님
                    if (c != mustNext)
                    {
                        isValid = false;
                        break;
                    }

                    // 해당 문자는 수에 포함되지 않음
                    mustNext = null;
                    continue;
                }
                alphabet[c - 'A']++;

                // 같은 문자가 3번 나오면 다음에 그 문자가 한 번 더 와야 한다.
                if (alphabet[c - 'A'] == 3)
                {
                    mustNext = c;
                    alphabet[c - 'A'] = 0;
                }
            }
            // 나와야 할 문자가 나오지 않고 종료
            if (mustNext != null)
            {
                isValid = false;
            }
            Console.WriteLine(isValid ? "OK" : "FAKE");
        }
        sr.Close();
    }
}
