using System;

public class Program
{
    public static void Main(string[] args)
    {
        string n = Console.ReadLine();
        int len = n.Length;
        int[] arr = new int[len];
        for (int i = 0; i < len; i++)
        {
            arr[i] = n[i] - '0';
        }

        int maxLen = 0;
        for (int i = 2; i <= len; i += 2)
        {
            for (int j = 0; j < len - i + 1; j++)
            {
                if (IsSymmetrical(arr, j, i))
                {
                    maxLen = Math.Max(maxLen, i);
                }
            }
        }
        Console.WriteLine(maxLen);
    }
    public static bool IsSymmetrical(int[] n, int start, int len)
    {
        int half = len / 2;
        int left = 0, right = 0;
        for (int i = start; i < start + half; i++)
        {
            left += n[i];
        }
        for (int i = start + half; i < start + len; i++)
        {
            right += n[i];
        }
        return left == right;
    }
}
