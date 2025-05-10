using System;

// p28431 - 양말 짝 맞추기 (B4)
// #구현
// 2025.5.10 solved

public class Program
{
    public static void Main(string[] args)
    {
        int[] count = new int[10];
        for (int i = 0; i < 5; i++)
        {
            int num = int.Parse(Console.ReadLine());
            count[num]++;
        }
        int ans = 0;
        for (int i = 0; i < 10; i++)
        {
            if (count[i] % 2 == 1)
            {
                ans = i;
                break;
            }
        }
        Console.WriteLine(ans);
    }
}
