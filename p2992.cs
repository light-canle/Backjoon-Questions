using System;
using System.Linq;
using System.Collections.Generic;

// p2992 - 크면서 작은 수 (S3)
// #백트래킹
// 2025.3.9 solved

public class Program
{
    public static List<int> nums;
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        char[] n = input.ToCharArray();
        int num = int.Parse(input);
        nums = new List<int>();
        int len = n.Length;
        GenNumber(n, new char[len], new bool[len], len, 0);
        nums.Sort();
        int numsLen = nums.Count;
        for (int i = 0; i < numsLen; i++)
        {
            if (nums[i] == num)
            {
                if (i == numsLen - 1)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine(nums[i + 1]);
                }
                break;
            }
        }
    }

    public static void GenNumber(char[] n, char[] ret, bool[] visited, int len, int cur)
    {
        if (cur == len)
        {
            string s = new string(ret);
            int num = int.Parse(s);
            if (!nums.Contains(num)) 
            {
                nums.Add(num);
            }
        }
        // 주어진 수를 나열하며 가능한 모든 조합을 찾는다.
        for (int i = 0; i < len; i++)
        {
            if (visited[i]) continue;
            ret[cur] = n[i];
            visited[i] = true;
            GenNumber(n, ret, visited, len, cur + 1);
            visited[i] = false;
        }
    }
}
