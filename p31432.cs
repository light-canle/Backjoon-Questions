using System;
using System.Collections.Generic;

// p31432 - 소수가 아닌 수 3 (B1)
// #애드 혹
// 2025.4.27 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

        for (int i = 0; i < n; i++)
        {
            if (nums[i] % 2 == 0)
            {
                Console.WriteLine("YES");
                Console.WriteLine(nums[i] == 2 ? "22" : nums[i]);
                break;
            }
            else
            {
                Console.WriteLine("YES");
                switch (nums[i])
                {
                    case 1:
                        Console.WriteLine("111");
                        break;
                    case 3:
                        Console.WriteLine("33");
                        break;
                    case 5:
                        Console.WriteLine("55");
                        break;
                    case 7:
                        Console.WriteLine("77");
                        break;
                    case 9:
                        Console.WriteLine("9");
                        break;
                }
                break;
            }
        }
    }
}
