using System;
using System.Linq;
using System.Collections.Generic;

// p9934 - 완전 이진 트리 (S1)
// #트리
// 2025.4.22 solved

public class Program
{
    public static void Main(string[] args)
    {
        int k = int.Parse(Console.ReadLine());
        int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        List<List<int>> lv = new();
        for (int i = 0; i < k; i++)
        {
            lv.Add(new());
        }

        // 완전 이진 트리를 inorder로 순회한 결과를 보면,
        // 각각의 원소의 깊이는 : 2 1 2 0 2 1 2 가 된다. (k = 3 기준)
        // m번째 원소는 m을 소인수분해 했을 때 2의 지수를 p라고 하면,
        // 그 깊이는 p - l이 됨을 알 수 있다.
        // 그래서 각 원소의 순서를 보고 어느 깊이에 들어갈 지를 결정한다.
        int len = nums.Length;
        for (int i = 0; i < len; i++)
        {
            int toAdd = ExpOfTwo(i + 1);
            lv[k - toAdd - 1].Add(nums[i]);
        }

        foreach (var l in lv)
        {
            Console.WriteLine(string.Join(" ", l));
        }
    }

    // 소인수분해 했을 때 2의 지수를 반환
    public static int ExpOfTwo(int n)
    {
        int e = 0;
        while (n % 2 == 0 && n > 0)
        {
            e++;
            n /= 2;
        }
        return e;
    }
}
