using System;

// p32132 - PlayStation이 아니에요 (B1)
// #문자열
// 2025.3.2 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();

        bool exist = true;

        // PS4, PS5를 찾아 수를 제거
        // 문자열 길이가 변하는 동작이므로 한 루프에 하나씩만 없앤다.
        while (exist)
        {
            exist = false;
            int i4 = input.IndexOf("PS4");
            if (i4 != -1)
            {
                exist = true;
                input = input.Remove(i4 + 2, 1);
                continue;
            }

            int i5 = input.IndexOf("PS5");
            if (i5 != -1)
            {
                exist = true;
                input = input.Remove(i5 + 2, 1);
                continue;
            }
        }
        Console.WriteLine(input);
    }
}
