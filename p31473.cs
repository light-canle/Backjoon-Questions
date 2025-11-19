#pragma warning disable CS8604, CS8602

using System;
using System.Linq;

// p31473 - 하늘과 핑크 (B1)
// #수학 #애드 혹
// 2025.11.19 solved

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int pinkSum = Console.ReadLine().Split().Select(int.Parse).Sum();
        int blueSum = Console.ReadLine().Split().Select(int.Parse).Sum();
        /*
        |a * pinkSum - b * blueSum|를 최소로 만드는 a, b는 무엇일까?
        pinkSum과 blueSum이 10^5 이하의 자연수, a, b는 절댓값이 10^6 이하인 정수이다.
        그러므로 a = blueSum, b = pinkSum으로 두면, 주어진 식은 항상 0이 된다.
        */
        Console.WriteLine($"{blueSum} {pinkSum}");
    }
}
