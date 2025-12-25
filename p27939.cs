#pragma warning disable CS8604, CS8602, CS8600

using System;

// p27939 - 가지 교배 (B1)
// #구현
// 2025.12.26 solved (12.25)

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        char[] kind = Array.ConvertAll(Console.ReadLine().Split(), char.Parse);
        int[] info = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int assistants = info[0], numOfKind = info[1];

        // 조수가 교배한 결과에 하나라도 흰색이 있으면 흰색을 만들 수 있다.
        bool hasWhite = false;
        for (int i = 0; i < assistants; i++)
        {
            bool hasPurple = false;
            int[] index = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            // 조수가 가지고 있는 품종 중 하나라도 보라색이 있으면 교배 결과는 보라색
            for (int j = 0; j < numOfKind; j++)
            {
                if (kind[index[j] - 1] == 'P')
                {
                    hasPurple = true;
                    break;
                }
            }
            // 보라색이 하나도 없어야 흰색이 나온다.
            if (!hasPurple)
            {
                hasWhite = true;
                // Note : 입력을 다 받아야 하므로, 이미 답을 찾았어도 break 하지 않음
            }
        }
        Console.WriteLine(hasWhite ? "W" : "P");
    }
}
