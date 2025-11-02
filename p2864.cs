#pragma warning disable CS8604, CS8602, CS8600

using System;

// p2864 - 5와 6의 차이 (B2)
// #그리디 #문자열
// 2025.11.3 solved (11.2)

public class Program
{
    public static void Main(string[] args)
    {
        int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int min = ConvertSum(nums[0], nums[1], 6, 5);
        int max = ConvertSum(nums[0], nums[1], 5, 6);
        Console.WriteLine($"{min} {max}");
    }

    // a + b를 구한다. 이때 a, b에서 각 자리에 등장하는 from을 to로 바꾼다.
    public static int ConvertSum(int a, int b, int from, int to)
    {
        string aStr = a.ToString().Replace(from.ToString(), to.ToString());
        string bStr = b.ToString().Replace(from.ToString(), to.ToString());
        return int.Parse(aStr) + int.Parse(bStr);
    }
}
